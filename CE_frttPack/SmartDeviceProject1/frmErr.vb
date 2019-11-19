Public Class frmErr
    Public msg As String
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmErr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMessage.Text = msg
        WakeUp()
        m_ReaderAPI.Reconnect()
       Timer1.Enabled = True
    End Sub

Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Timer1.Enabled = False
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
       Me.Close()
End Sub
End Class