    Option Explicit On 
    Imports System.Data
    Imports System.xml
Imports System.Data.Common
    
    Namespace Document
    
    Public MustInherit Class Doc_Base
        Implements IDisposable

        Private m_Manager As Manager
        Private findCash As Collection
        Private m_ID As Guid
        Private m_StatusID As Guid
        Private m_Name As String
      
        Protected MustOverride Function MyTypeName() As String
        Public MustOverride Sub Dispose() Implements System.IDisposable.Dispose


        Public ReadOnly Property TypeName() As String
            Get
                TypeName = MyTypeName()
            End Get
        End Property


        Public Property Name() As String
            Get
                Name = m_Name
            End Get
            Set(ByVal Value As String)
                m_Name = Value
            End Set
        End Property

        Public Property Manager() As Manager
            Get
                Manager = m_Manager
            End Get
            Set(ByVal m As Manager)
                If Not m_Manager Is Nothing Then Exit Property
                m_Manager = m

            End Set
        End Property

        Public Property ID() As Guid
            Get
                ID = m_ID
            End Get
            Set(ByVal V As Guid)
                m_ID = V
            End Set
        End Property


        Public ReadOnly Property Parent() As Object
            Get
                Parent = Nothing
            End Get
        End Property

        Public ReadOnly Property Application() As Doc_Base
            Get
                Application = Me
            End Get
        End Property



        Public Sub AddToCash(ByVal key As String, ByVal Item As Object)
            On Error Resume Next
            If findCash Is Nothing Then findCash = New Collection
            If findCash.Contains(key) Then
                If findCash.Item(key) Is Nothing Then
                    findCash.Remove(key)
                    findCash.Add(Item, key)
                End If
            Else
                findCash.Add(Item, key)
            End If

        End Sub

        Public Sub RemoveFromCash(ByVal key As String)
            On Error Resume Next
            If findCash Is Nothing Then Exit Sub
            If findCash.Contains(key) Then
                findCash.Remove(key)
            End If
        End Sub
      

        Public Property StatusID() As Guid
            Get
                On Error Resume Next


                StatusID = m_StatusID
            End Get
            Set(ByVal newid As Guid)
                m_StatusID = newid
            End Set
        End Property

      
        Public Function FindRowObject(ByVal StrID As String, ByVal RowID As Guid, ByVal ObjType As String) As DocRow_Base
            Dim obj As Doc_Base
            Dim Rowobj As DocRow_Base = Nothing
            Dim i As Long
            Dim m_FindObject As DocRow_Base
            m_FindObject = Nothing
            FindRowObject = Nothing
            If StrID = "" Then Exit Function
            If RowID.Equals(System.Guid.Empty) Then Exit Function
            If findCash Is Nothing Then
                findCash = New Collection
            End If
            On Error Resume Next
            m_FindObject = Nothing
            If findCash.Contains(StrID & CheckIDtoID_ORACLE(RowID.ToString())) Then
                m_FindObject = findCash.Item(StrID & CheckIDtoID_ORACLE(RowID.ToString()))
            End If

            If Not m_FindObject Is Nothing Then
                If m_FindObject.Application Is Nothing Then
                    m_FindObject = Nothing
                    findCash.Remove(StrID & CheckIDtoID_ORACLE(RowID.ToString()))
                Else
                    FindRowObject = m_FindObject
                    Exit Function
                End If
            End If



            Dim cachedID As Guid
            cachedID = Manager.GetRowCashedObject(RowID)
            If Not cachedID.Equals(Guid.Empty) Then
                If Not ID.Equals(cachedID) Then
                    obj = Manager.GetInstanceObject(cachedID, ObjType)
                    Rowobj = obj.FindRowObject(StrID, RowID, obj.TypeName)
                End If
            End If

            If Rowobj Is Nothing Then

                'use old search style
                Rowobj = FindObject(StrID, RowID.ToString())
            End If

            If Rowobj Is Nothing Then Exit Function
            FindRowObject = Rowobj
            Rowobj = Nothing
            obj = Nothing
        End Function

        Protected MustOverride Function FindInCollections(ByVal Table As String, ByVal RowID As String) As DocRow_Base

        Private inFindObject As Boolean

        Public Function FindObject(ByVal Table As String, ByVal RowID As String) As DocRow_Base
            Dim m_FindObject As DocRow_Base
            FindObject = Nothing
            RowID = CheckIDtoID_ORACLE(RowID)
            If Table = "" Then Exit Function
            If RowID = "" Then Exit Function
            If RowID = CheckIDtoID_ORACLE(System.Guid.Empty.ToString()) Then
                Exit Function
            End If
            If inFindObject Then Exit Function
            inFindObject = True
            If findCash Is Nothing Then
                findCash = New Collection
            End If
            On Error Resume Next
            If findCash.Contains(Table & CheckIDtoID_ORACLE(RowID)) Then
                m_FindObject = findCash.Item(Table & CheckIDtoID_ORACLE(RowID))
            Else
                m_FindObject = Nothing
            End If
            If Not m_FindObject Is Nothing Then
                If m_FindObject.Application Is Nothing Then
                    m_FindObject = Nothing
                    findCash.Remove(Table & CheckIDtoID_ORACLE(RowID))
                End If
            End If

            m_FindObject = FindInCollections(Table, RowID)

            If Not m_FindObject Is Nothing Then
                If Not findCash.Contains(Table & CheckIDtoID_ORACLE(RowID)) Then
                    findCash.Add(m_FindObject, Table & CheckIDtoID_ORACLE(RowID))
                End If
            End If
            FindObject = m_FindObject
            m_FindObject = Nothing
            inFindObject = False
        End Function


        Public Function Brief() As String
            Brief = Name
        End Function


        Public Sub XMLLoad(ByVal node As XmlNode, Optional ByVal LoadMode As Integer = 0)
            On Error Resume Next
            Dim anode As XmlElement
            Dim e_list As XmlNodeList
            On Error Resume Next
            If node.Name <> "APPLICATION" Then
                anode = node.FirstChild
            Else
                anode = node
            End If
            If TypeName <> anode.Attributes("TYPENAME").Value Then Exit Sub
           
            m_ID = New System.Guid(anode.Attributes("ID").Value)
            m_Name = anode.Attributes("NAME").Value
            If Not anode.Attributes("STATUS") Is Nothing Then

                Dim tmpguid As System.Guid
                tmpguid = New System.Guid(anode.Attributes("STATUS").Value)
                If Not tmpguid.Equals(System.Guid.Empty) Then
                    StatusID = tmpguid
                End If
            End If
           
            XMLLoadCollections(anode, LoadMode)
        End Sub

        Protected MustOverride Sub XMLLoadCollections(ByVal node As XmlNode, Optional ByVal LoadMode As Integer = 0)

        Public Sub XMLSave(ByVal node As XmlElement, ByVal Xdom As XmlDocument)
            Dim anode As XmlElement
            On Error Resume Next
            anode = Xdom.CreateElement("APPLICATION")
            anode.SetAttribute("ID", m_ID.ToString)
            anode.SetAttribute("TYPENAME", TypeName)
            anode.SetAttribute("NAME", m_Name)
            anode.SetAttribute("STATUS", StatusID.ToString())
            node.AppendChild(anode)
            XMLSaveCollections(anode, Xdom)
        End Sub

        Public MustOverride Sub XMLSaveCollections(ByVal node As XmlElement, ByVal Xdom As XmlDocument)

        Public Sub New()

        End Sub

        Public Overridable ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property

        Public Overridable Function GetDocCollection_Base(ByVal Index As Long) As DocCollection_Base
            Return Nothing
        End Function

    End Class
    End Namespace