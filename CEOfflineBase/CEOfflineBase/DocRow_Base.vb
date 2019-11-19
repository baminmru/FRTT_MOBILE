    Option Strict Off
    Option Explicit On
    
    Imports System
    Imports System.Data
    Imports System.XML
Imports System.Data.Common
    
    Namespace Document
    
    Public MustInherit Class DocRow_Base
        Implements IDisposable

        Private m_Application As Doc_Base
        Private m_Parent As DocCollection_Base
        Private m_ID As Guid
        Private m_Brief As String
        Private m_SecureStyleID As Guid
        Private m_RowRetrived As Boolean = False
        Private m_Changed As Boolean = False
        Private m_Deleted As Boolean = False
        Private m_RetriveTime As Date
        Private m_ChangeTime As Date
        Private m_AccessTime As Date

        Public Event Change(ByVal fieldName As String, ByVal OldValue As Object, ByRef NewValue As Object)

        Public Overridable Property Value(ByVal Index As Object) As Object
            Get
                Return DBNull.Value
            End Get
            Set(ByVal value As Object)

            End Set
        End Property

        Public Overridable ReadOnly Property Count() As Long
            Get
                Count = 0
            End Get
        End Property

        Public Overridable Function FieldNameByID(ByVal Index As Long) As String
            Return String.Empty
        End Function

        Public Overridable ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property

        Public ReadOnly Property Deleted() As Boolean
            Get
                Deleted = m_Deleted
            End Get
        End Property
        Public Property Changed() As Boolean
            Get
                Changed = m_Changed
            End Get
            Set(ByVal Value As Boolean)
                m_Changed = Value
            End Set
        End Property

     
        Public Function PartName() As String
            Return Parent.ChildPartName()
        End Function
        Protected Friend Sub CloseParents()
            m_Application = Nothing
            m_Parent = Nothing
        End Sub
        Public Property RowRetrived() As Boolean
            Get
                RowRetrived = m_RowRetrived
            End Get
            Set(ByVal Value As Boolean)
                m_RowRetrived = Value
            End Set

        End Property

        Public Property RetriveTime() As Date
            Get
                RetriveTime = m_RetriveTime
            End Get
            Set(ByVal Value As Date)
                m_RetriveTime = Value
            End Set

        End Property

        Public Property ChangeTime() As Date
            Get
                ChangeTime = m_ChangeTime
            End Get
            Set(ByVal Value As Date)
                m_ChangeTime = Value
            End Set
        End Property
        Public Property AccessTime() As Date
            Get
                AccessTime = m_AccessTime
            End Get
            Set(ByVal newAccessTime As Date)
                m_AccessTime = newAccessTime
                If m_AccessTime <= m_RetriveTime Then m_AccessTime = m_RetriveTime.AddSeconds(1)
            End Set
        End Property


        

        Private inFindObject As Boolean
        Public Function FindObject(ByVal Table As String, ByVal InstID As String) As Object
            Dim m_FindObject As Object
            m_FindObject = Nothing
            FindObject = Nothing
            If Table = "" Then Exit Function
            If InstID = "" Then Exit Function
            If InstID = System.Guid.Empty.ToString Then Exit Function
            If inFindObject Then Exit Function
            inFindObject = True
            If Table = PartName() Then
                If (New System.Guid(InstID)).Equals(ID) Then
                    m_FindObject = Me
                End If
            End If
            If m_FindObject Is Nothing Then
                m_FindObject = FindInside(Table, InstID)
            End If
            FindObject = m_FindObject
            m_FindObject = Nothing
            inFindObject = False
        End Function
       
        Friend Sub OnChange(ByVal fieldName As String, ByVal OldValue As Object, ByRef NewValue As Object)
            RaiseEvent Change(fieldName, OldValue, NewValue)
        End Sub


        Public Sub XMLLoad(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
            On Error Resume Next
            Dim e_list As System.Xml.XmlNodeList
            Dim e_ As XmlNode
            If LoadMode <> 2 Then
                If Not node.Attributes.GetNamedItem("ID") Is Nothing Then
                    m_ID = New System.Guid(node.Attributes.GetNamedItem("ID").Value)
                End If
            End If
            m_RetriveTime = System.DateTime.MinValue
            m_RetriveTime = m_RetriveTime.AddTicks(node.Attributes.GetNamedItem("RetriveTime").Value)
            m_ChangeTime = System.DateTime.MinValue
            m_ChangeTime = m_ChangeTime.AddTicks(node.Attributes.GetNamedItem("ChangeTime").Value)
            m_AccessTime = System.DateTime.MinValue
            m_AccessTime = m_AccessTime.AddTicks(node.Attributes.GetNamedItem("AccessTime").Value)

            XMLUnpack(node, LoadMode)

           

            On Error GoTo bye

            m_Changed = True
            m_RowRetrived = True
            m_Brief = ""
            On Error Resume Next
            Exit Sub
bye:
        End Sub


        Public Sub XMLSave(ByVal node As XmlElement, ByVal Xdom As System.Xml.XmlDocument)
            On Error Resume Next
            Dim e_ As XmlElement

            node.SetAttribute("ID", m_ID.ToString())
            If m_RetriveTime = System.DateTime.MinValue Then m_RetriveTime = DateSerial(1899, 12, 30) ' System.DateTime.Parse("12/30/1899")
            node.SetAttribute("RetriveTime", m_RetriveTime.Ticks)
            If m_ChangeTime = System.DateTime.MinValue Then m_ChangeTime = DateSerial(1899, 12, 30) ' System.DateTime.Parse("12/30/1899")
            node.SetAttribute("ChangeTime", m_ChangeTime.Ticks)
            If m_AccessTime = System.DateTime.MinValue Then m_AccessTime = DateSerial(1899, 12, 30) ' System.DateTime.Parse("12/30/1899")
            node.SetAttribute("AccessTime", m_AccessTime.Ticks)

            XLMPack(node, Xdom)

        End Sub



        Public Sub New()
            MyBase.New()
        End Sub

        Public Property Parent() As DocCollection_Base
            Get
                Parent = m_Parent
            End Get
            Set(ByVal Value As DocCollection_Base)
                If m_Parent Is Nothing Then
                    m_Parent = Value
                End If
            End Set
        End Property

        Public Property Application() As Doc_Base
            Get
                Application = m_Application
            End Get
            Set(ByVal Value As Doc_Base)
                If m_Application Is Nothing Then
                    m_Application = Value
                End If
            End Set
        End Property


        Public Overridable ReadOnly Property Brief() As String
            Get
          
                Return m_Brief
            End Get
        End Property

        Public Property ID() As Guid
            Get
                ID = m_ID
            End Get
            Set(ByVal V As Guid)
                m_ID = V
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim dynStr As System.Text.StringBuilder = New System.Text.StringBuilder(Me.GetType().Name)
            dynStr.Append(":")
            dynStr.Append("  ID=")
            dynStr.Append(Me.m_ID)
            dynStr.Append("  Brief=")
            dynStr.Append(Me.m_Brief)
            Return dynStr.ToString()
        End Function

        Public MustOverride Function FindInside(ByVal StrID As String, ByVal InstID As String) As Document.DocRow_Base
        Public MustOverride Sub Unpack(ByVal row As DataRow)
        Public MustOverride Sub Pack(ByVal nv As NamedValues)
        Public MustOverride Sub CleanFields()
        Public MustOverride Sub Dispose() Implements System.IDisposable.Dispose
        Public MustOverride Sub FillDataTable(ByRef DestDataTable As DataTable)
        Protected MustOverride Sub XMLUnpack(ByVal node As XmlNode, Optional ByVal LoadMode As Integer = 0)
        Protected MustOverride Sub XLMPack(ByVal node As XmlElement, ByVal Xdom As System.Xml.XmlDocument)

        Public Overridable Function GetDocCollection_Base(ByVal Index As Long) As Document.DocCollection_Base
            Return Nothing
        End Function

     
    End Class
    End Namespace