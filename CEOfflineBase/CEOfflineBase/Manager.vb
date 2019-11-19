Option Strict Off
Option Explicit On 

Imports System.Data
Imports System.xml
Imports System.io
Imports System.Data.Common
Imports System.Reflection



Public Class Manager
    Implements IDisposable

    Dim mOpenInstances As OpenInstances
    Dim mR2O As R2OMapItems
    Dim mTempFiles As Collection
    Private m_CustomObjects As NamedValues
    Private mFinder As Object
    Private m_DLLPath As String
    Private m_BD As BufferData
    Dim mXmlFile As String
    Dim mErrorMessage As String = String.Empty

    Dim mStorePath As String

    Public Property StorePath() As String
        Get
            StorePath = mStorePath
        End Get
        Set(ByVal Value As String)
            mStorePath = Value
        End Set
    End Property


    Public Property ErrorMessage() As String
        Get
            ErrorMessage = mErrorMessage
        End Get
        Set(ByVal Value As String)
            mErrorMessage = Value
        End Set
    End Property


    Public Sub New()
        MyBase.New()
        mOpenInstances = New OpenInstances
        mR2O = New R2OMapItems
        m_CustomObjects = New NamedValues
    End Sub

    Protected Overrides Sub Finalize()
        Dispose()
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose

        Try
            If Not mOpenInstances Is Nothing Then mOpenInstances.Dispose()


        Catch ex As Exception

        End Try
        mOpenInstances = Nothing


        Try
            If Not mR2O Is Nothing Then mR2O.Dispose()

        Catch ex As Exception

        End Try
        mR2O = Nothing

    End Sub



    Public Function GetInstanceObject(ByVal InstanceiD As Guid, ByVal ObjType As String) As Document.Doc_Base
        Dim o As Document.Doc_Base

        If (InstanceiD.Equals(Guid.Empty)) Then Return Nothing

        GetInstanceObject = Nothing

        ' kill broken object
        If Not mOpenInstances.Item(InstanceiD) Is Nothing Then
            If mOpenInstances.Item(InstanceiD).DOC Is Nothing Then
                mOpenInstances.Remove(InstanceiD)
            End If
        End If

        Dim rs As DataTable

        If mOpenInstances.Item(InstanceiD) Is Nothing Then
            On Error GoTo bye
            With mOpenInstances.Add(InstanceiD)
                .DOC = GetDoc(ObjType, "")
                .DOC.Manager = Me
                On Error GoTo bye
                .DOC.ID = InstanceiD
            End With
            rs = Nothing
        End If
        Dim obj As OpenInstance = mOpenInstances.Item(InstanceiD)
        If (Not obj Is Nothing) Then
            GetInstanceObject = obj.DOC
        End If
        Exit Function
bye:
    End Function





    Public Sub SaveDocumentToXML(ByVal xmlPath As String, ByVal doc As Document.Doc_Base)
        Dim x As New Xml.XmlDocument
        x.LoadXml("<" & doc.TypeName & "></" & doc.TypeName & ">")
        doc.XMLSave(x.LastChild, x)
        x.Save(xmlPath & doc.ID.ToString() & ".xml")
    End Sub

    Protected Function GetDoc(ByVal name As String, Optional ByVal Root As String = "") As Document.Doc_Base

        Dim funcAssembly As Document.Doc_Base
        Dim asm As System.Reflection.Assembly
        funcAssembly = Nothing
        asm = Nothing
        Try
            If DLLPath <> "" Then
                Try
                    asm = System.Reflection.Assembly.LoadFrom(DLLPath + "\CE_" & name & ".dll")
                Catch
                End Try
            End If
            If asm Is Nothing Then
                If Root <> "" Then
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(Root + "\CE_" & name & ".dll")
                    Catch
                    End Try
                End If
            End If
            'ATAS
            'If asm Is Nothing Then
            '    Dim FileName As String

            'FileName = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\CE_" & name & ".dll"
            'Try
            '    If (File.Exists(FileName)) Then
            '        asm = System.Reflection.Assembly.LoadFrom(FileName)
            '    End If
            'Catch ex As System.Exception
            'End Try
            'If (asm Is Nothing) Then
            '    Try
            '        FileName = AppDomain.CurrentDomain.DynamicDirectory + "\CE_" & name & ".dll"
            '        If (File.Exists(FileName)) Then
            '            asm = System.Reflection.Assembly.LoadFrom(FileName)
            '        Else
            '            Try
            '                funcAssembly = CType(System.Activator.CreateInstance(name, "CE_" & name & "." & name & ".Application").Unwrap(), Document.Doc_Base)
            '            Catch e2 As System.Exception
            '                Dim i As Integer = 0
            '                Return Nothing
            '            End Try
            '        End If
            '    Catch e1 As System.Exception
            '    End Try


            'End If
            'End If

            If Not asm Is Nothing Then
                If (funcAssembly Is Nothing) Then
                    funcAssembly = CType(asm.CreateInstance("CE_" & name & "." & name & ".Application"), Document.Doc_Base)
                End If
            End If

        Catch
        End Try
        Return funcAssembly


    End Function

    Public Function DeleteInstanceByID(ByVal ID As System.Guid) As Boolean
        Return FreeInstanceObject(ID)

    End Function

    Public Function DeleteInstance(ByVal Instance As Document.Doc_Base) As Boolean
        Return FreeInstanceObject(Instance.ID)

    End Function

    Public Function NewInstance(ByVal InstanceiD As Guid, ByVal ObjType As String, ByVal Name As String) As Document.Doc_Base
        Dim doc As Document.Doc_Base
        doc = GetInstanceObject(InstanceiD, ObjType)
        If Not doc Is Nothing Then
            doc.Name = Name
            SaveDocumentToXML(StorePath, doc)
        End If

        Return doc
    End Function

  

   

    Public Function FreeInstanceObject(ByVal InstanceID As Guid) As Boolean
        On Error Resume Next
        If mOpenInstances.Item(InstanceID) Is Nothing Then
            FreeInstanceObject = True
        Else
            If mOpenInstances.Item(InstanceID).DOC Is Nothing Then
                mOpenInstances.Remove(InstanceID)
                FreeInstanceObject = True
            Else
                On Error Resume Next
                If mOpenInstances.Item(InstanceID).Locked = False Then
                    mOpenInstances.Item(InstanceID).DOC.Dispose()
                    mOpenInstances.Item(InstanceID).DOC.Manager = Nothing
                    On Error GoTo bye
                    mOpenInstances.Item(InstanceID).DOC = Nothing
                    mOpenInstances.Remove(InstanceID)
                    FreeInstanceObject = True
                Else
                    FreeInstanceObject = False
                End If
            End If
        End If
        Exit Function
bye:
        FreeInstanceObject = False
    End Function


    Public Function GetInstanceObjectFromXML(ByVal XMLPath As String) As Object
        Dim xdom As XmlDocument
        xdom = New XmlDocument
        xdom.Load(XMLPath)
        Dim InstanceiD As Guid, TypeName As String
        Dim anode As XmlElement
        Dim e_list As XmlNodeList
        anode = xdom.LastChild.FirstChild
        TypeName = anode.Attributes.GetNamedItem("TYPENAME").Value
        InstanceiD = New System.Guid(anode.Attributes.GetNamedItem("ID").Value)

        If mOpenInstances.Item(InstanceiD) Is Nothing Then
            On Error GoTo bye
            With mOpenInstances.Add(InstanceiD)
                .DOC = GetDoc(TypeName, "")
                .DOC.Manager = Me
                .DOC.ID = InstanceiD
            End With
        End If

        mOpenInstances.Item(InstanceiD).DOC.XMLLoad(xdom.LastChild, 1)
        GetInstanceObjectFromXML = mOpenInstances.Item(InstanceiD).DOC
        xdom = Nothing
        Exit Function
bye:
        xdom = Nothing
    End Function

    Public Function GetInstanceObjectFromXMLText(ByVal XMLText As String) As Object
        Dim xdom As XmlDocument
        xdom = New XmlDocument
        xdom.LoadXml(XMLText)
        Dim InstanceiD As Guid, TypeName As String
        Dim anode As XmlElement
        Dim e_list As XmlNodeList
        anode = xdom.LastChild.FirstChild
        TypeName = anode.Attributes.GetNamedItem("TYPENAME").Value
        InstanceiD = New System.Guid(anode.Attributes.GetNamedItem("ID").Value)

        If mOpenInstances.Item(InstanceiD) Is Nothing Then
            On Error GoTo bye
            With mOpenInstances.Add(InstanceiD)
                .DOC = GetDoc(TypeName, "")
                .DOC.Manager = Me
                .DOC.ID = InstanceiD
            End With
        End If

        mOpenInstances.Item(InstanceiD).DOC.XMLLoad(xdom.LastChild, 1)
        GetInstanceObjectFromXMLText = mOpenInstances.Item(InstanceiD).DOC
        xdom = Nothing
        Exit Function
bye:
        xdom = Nothing
    End Function


    Public Sub StoreTempFileData(ByVal Path As String, Optional ByVal PartName As String = "", Optional ByVal RowID As String = "")
        If mTempFiles Is Nothing Then
            mTempFiles = New Collection
        End If
        Dim temp As TempFileInfo
        temp = New TempFileInfo
        temp.PathToFile = Path
        temp.RowID = RowID
        temp.PartName = PartName
        mTempFiles.Add(temp)
    End Sub

    Private Sub KillTempFiles()
        If mTempFiles Is Nothing Then Exit Sub

        Dim temp As TempFileInfo
        On Error Resume Next
        For Each temp In mTempFiles
            'ATAS Kill(temp.PathToFile)
        Next temp
        mTempFiles = Nothing
    End Sub
    Public Shared Function GetFile(ByVal filePath As String) As Byte()
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim data() As Byte = br.ReadBytes(fs.Length)

        br.Close()
        fs.Close()

        Return data
    End Function
    Public Property DLLPath() As String
        Get
            DLLPath = m_DLLPath
        End Get
        Set(ByVal Value As String)
            m_DLLPath = Value
        End Set
    End Property

    Private Function BufferData() As BufferData
        If m_BD Is Nothing Then
            m_BD = New BufferData
        End If
        BufferData = m_BD
    End Function

    Public Sub SetBuffer(ByVal PartName As String, ByVal Data As String)
        BufferData.Add(Data, PartName)
    End Sub

    Public Function GetBuffer(ByVal PartName As String) As String
        GetBuffer = ""
        On Error Resume Next
        GetBuffer = BufferData.Item(PartName).Data
    End Function

    Public Sub ClearBuffer(ByVal PartName As String)
        BufferData.Remove(PartName)
    End Sub

    Public Sub AddToCash(ByVal RowID As Guid, ByVal ItemID As Guid)
        On Error Resume Next

        If mR2O.Item(RowID) Is Nothing Then
            mR2O.Add(RowID).ID = ItemID
        End If

    End Sub


    Public Sub RemoveFromCash(ByVal RowID As Guid)
        On Error Resume Next
        If Not mR2O.Item(RowID) Is Nothing Then
            mR2O.Remove(RowID)
        End If

    End Sub

    Public Function GetRowCashedObject(ByVal RowID As Guid) As Guid
        On Error Resume Next
        If Not mR2O.Item(RowID) Is Nothing Then
            Return mR2O.Item(RowID).ID
        End If
        Return Guid.Empty
    End Function


    Public Function AddCustomObjects(ByRef obj As Object, ByVal Name As String) As Boolean
        On Error Resume Next
        Err.Clear()
        Call m_CustomObjects.Add(Name, obj)
        AddCustomObjects = (Err.Number = 0)
     
    End Function

    Public Function GetCustomObjects(ByVal Name As String) As Object
        On Error Resume Next
        GetCustomObjects = m_CustomObjects.Item(Name).Value
    End Function

    Public Function RemoveCustomObjects(ByVal Name As String) As Boolean
        On Error Resume Next
        Err.Clear()
        Call m_CustomObjects.Remove(Name)
        RemoveCustomObjects = (Err.Number = 0)
    End Function

   


    
End Class
