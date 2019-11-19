Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.xml
Imports System.Data.Common

Namespace Document
    Public MustInherit Class DocCollection_Base
        Implements IDisposable


        Private mCol As Collection
        Private m_Application As Doc_Base
        Private m_Parent As Object
        Private m_Filter As String
        Private LastCheckTime As Date
        Private m_LastLang As String
        Private _sort As String
        Private SortDV As DataView

        Public Sub New()
            MyBase.New()
            mCol = New Collection
        End Sub


        Protected MustOverride Function CreateDataTable() As DataTable
        Public MustOverride Function ChildPartName() As String

        Public Overridable Function IsTree() As Boolean
            IsTree = False
        End Function
        Protected MustOverride Function NewItem() As DocRow_Base

        Public Property Sort() As String
            Get
                Return _sort
            End Get
            Set(ByVal value As String)
                _sort = value
                ReSort()
            End Set
        End Property


        Private mInResort As Boolean = False

        Public Sub ReSort()
            If _sort = "" Then
                SortDV = Nothing
            Else
                If mInResort Then Exit Sub
                mInResort = True
                Dim tmpDT As DataTable = GetDataTable()
                Try

                    SortDV = tmpDT.DefaultView
                    SortDV.Sort = _sort
                Catch
                    SortDV = tmpDT.DefaultView
                End Try
                If SortDV.Count <> tmpDT.Rows.Count Then
                    SortDV = Nothing
                End If
                mInResort = False
            End If
        End Sub

        Public Function GetDataTable() As DataTable
            Dim dt As DataTable, i As Long
            dt = CreateDataTable()

            For i = 1 To Count
                CType(mCol.Item(i), DocRow_Base).FillDataTable(dt)
            Next

            Return dt
        End Function


        Public Property Parent() As Object
            Get
                Parent = m_Parent
            End Get
            Set(ByVal Value As Object)
                m_Parent = Value
            End Set
        End Property

        Public Property Application() As Doc_Base
            Get
                Application = m_Application
            End Get
            Set(ByVal Value As Doc_Base)
                m_Application = Value
            End Set
        End Property


    

        Private Sub CloseParents()
            m_Application = Nothing
            m_Parent = Nothing
        End Sub


       

        Public Overridable Function Add(Optional ByVal ID As String = "") As DocRow_Base
            Dim LID As Guid
            Dim o As DocRow_Base
            If ID = "" Then
                LID = System.Guid.NewGuid
            Else
                LID = New Guid(ID)
            End If
            On Error Resume Next
            If mCol.Count > 0 Then
                If Not mCol.Contains(CheckIDtoID_ORACLE(LID.ToString())) Then
                    GoTo addnew
                Else
                    Add = mCol.Item(CheckIDtoID_ORACLE(LID.ToString()))
                    Exit Function
                End If
            End If
addnew:
            o = NewItem()
            o.ID = LID
            'o.RowRetrived = False
            o.Parent = Me
            o.Application = Me.Application
            Me.Application.AddToCash(ChildPartName() & CheckIDtoID_ORACLE(LID.ToString), o)
            Add = o
            mCol.Add(o, CheckIDtoID_ORACLE(o.ID.ToString))
            o = Nothing
        End Function

        Public Function Item(ByVal ID As Object) As DocRow_Base
            On Error Resume Next
            Dim o As DocRow_Base
            Item = Nothing
            If IsNumeric(ID) Then
                If SortDV Is Nothing Then
                    Item = mCol.Item(ID)
                Else
                    If SortDV.Count <> mCol.Count Then
                        ReSort()
                    End If
                    Err.Clear()
                    Item = mCol.Item(CheckIDtoID_ORACLE(SortDV(CType(ID, Integer) - 1)("ID").ToString()))
                End If
                Exit Function
            End If
            ID = CheckIDtoID_ORACLE(ID)
            If mCol.Contains(ID) Then
                Item = mCol.Item(ID)
                Exit Function
            End If
        End Function

        Public Function FindObject(ByVal Table As String, ByVal InstID As String) As Object
            Dim m_FindObject As Object, i As Long
            Dim obj As DocRow_Base


            FindObject = Nothing
            m_FindObject = Nothing
            If Table = "" Then Exit Function
            If InstID = "" Then Exit Function
            If InstID = System.Guid.Empty.ToString Then Exit Function

            If Table = ChildPartName() Then
                obj = Item(InstID)
                m_FindObject = obj
                If Not m_FindObject Is Nothing Then GoTo OK
            End If
            For i = 1 To mCol.Count
                obj = Item(i)
                m_FindObject = obj.FindObject(Table, InstID)
                If Not m_FindObject Is Nothing Then Exit For
            Next
OK:
            FindObject = m_FindObject
            m_FindObject = Nothing
        End Function

        Public ReadOnly Property Count() As Long
            Get
                Count = mCol.Count
            End Get
        End Property

        Public Sub Remove(ByVal vntIndexKey As Object)
            On Error Resume Next
            Dim obj As DocRow_Base

            If IsNumeric(vntIndexKey) Then
                obj = CType(mCol.Item(vntIndexKey), DocRow_Base)
            Else
                obj = CType(mCol.Item(CheckIDtoID_ORACLE(vntIndexKey)), DocRow_Base)
            End If
          
            Me.Application.RemoveFromCash(ChildPartName() & CheckIDtoID_ORACLE(obj.ID.ToString))
            If IsNumeric(vntIndexKey) Then
                mCol.Remove(vntIndexKey.ToString())
            Else
                mCol.Remove(CheckIDtoID_ORACLE(vntIndexKey))
            End If
        End Sub

       

        

      
        Public Sub Dispose() Implements System.IDisposable.Dispose
            CloseParents()
            Dim i As Long
            Dim o As DocRow_Base
            For i = 1 To Count
                o = mCol.Item(i)
                o.Dispose()
                o.CloseParents()
            Next
            While Count > 0
                Remove(1)
            End While
            SortDV = Nothing
        End Sub

        Public Sub XMLSave(ByRef ParentNode As XmlElement, ByVal Xdom As XmlDocument)
            Dim o As DocRow_Base
            Dim i As Long
            Dim pnode As XmlElement
            pnode = Xdom.CreateElement(ChildPartName() & "_COL")


            Dim node As XmlElement
            ParentNode.AppendChild(pnode)
            For i = 1 To mCol.Count
                o = CType(mCol.Item(i), DocRow_Base)
                node = Xdom.CreateElement(ChildPartName())
                pnode.AppendChild(node)
                o.XMLSave(node, Xdom)
            Next
        End Sub


        
        Public Sub XMLLoad(ByRef NodeList As XmlNodeList, Optional ByVal LoadMode As Integer = 0)
            On Error Resume Next
            Dim o As DocRow_Base
            Dim node As XmlElement
            Dim pnode As XmlElement
            pnode = NodeList.Item(0) ' was - 1

            NodeList = pnode.SelectNodes(ChildPartName)
            Dim bufcol As Collection
            bufcol = Nothing
            If LoadMode = 1 Then
                bufcol = New Collection
            End If
            Dim j As Long
            For j = 0 To NodeList.Count - 1 'was - For j = 1 To NodeList.Count
                node = NodeList.Item(j)

                ' append mode
                If LoadMode = 0 Then
                    If Item(node.Attributes.GetNamedItem("ID").Value) Is Nothing Then
                        Add(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                    Else
                        Item(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                    End If
                End If
                ' replace mode
                If LoadMode = 1 Then
                    If Item(node.Attributes.GetNamedItem("ID").Value) Is Nothing Then
                        Add(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                    Else
                        Item(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                    End If
                    bufcol.Add(Item(node.Attributes.GetNamedItem("ID").Value), node.Attributes.GetNamedItem("ID").Value)
                End If
                ' copy with new ID mode
                If LoadMode = 2 Then
                    Add().XMLLoad(node, LoadMode)
                End If
            Next
            ' remove extra items from collection
            If LoadMode = 1 Then
                Dim i As Long
                ' remove existing
removeAgain:
                For i = 1 To Count
                    If bufcol.Item(Item(i).ID.ToString()) Is Nothing Then
                        Remove(Item(i).ID.ToString())
                        GoTo removeAgain
                    End If
                Next
                bufcol = Nothing
            End If
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