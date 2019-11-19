Public Class frmSelectFSRC

    Private Sub cmdFromList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFromList.Click
        Dim f As frmFromList
        f = New frmFromList
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing
    End Sub

    Private Sub cmdManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManual.Click
        Dim f As frmManual
        f = New frmManual
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing

    End Sub

    Private Sub cmdFromWM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFromWM.Click
        Dim f As frmWMTYPE
        f = New frmWMTYPE
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class