Option Strict Off
Option Explicit On
Friend Class BufferData
    Implements IDisposable

    'local variable to hold collection
    Private mCol As Collection

    Public Function Add(ByVal Data As String, ByVal PartName As String) As BufferInfo
        'create a new object
        Dim objNewMember As BufferInfo

        'UPGRADE_NOTE: Object objNewMember may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        objNewMember = Nothing
        On Error Resume Next


        objNewMember = mCol.Item(PartName)
        If objNewMember Is Nothing Then
            objNewMember = New BufferInfo
            mCol.Add(objNewMember, PartName)
        End If

        'set the properties passed into the method
        objNewMember.Data = Data
        objNewMember.PartName = PartName

        'return the object created
        Add = objNewMember
        'UPGRADE_NOTE: Object objNewMember may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        objNewMember = Nothing


    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As BufferInfo
        Get
            On Error Resume Next
            Item = Nothing
            If IsNumeric(vntIndexKey) Then
                Item = mCol.Item(vntIndexKey)
            Else
                If mCol.Contains(vntIndexKey) Then
                    Item = mCol.Item(vntIndexKey)
                End If
            End If

        End Get
    End Property



    Public ReadOnly Property Count() As Integer
        Get
            Count = mCol.Count()
        End Get
    End Property

    Public Sub Remove(ByVal vntIndexKey As Object)
        On Error Resume Next
        mCol.Remove(vntIndexKey.ToString())
    End Sub


    Private Sub Class_Initialize_Renamed()
        mCol = New Collection
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub



    

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If
            mCol.Clear()
            mCol = Nothing
            MyBase.Finalize()
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class