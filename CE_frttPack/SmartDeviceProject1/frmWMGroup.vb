Public Class frmWMGroup

    Private Sub cmdCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCE.Click
        txtMG.Text = ""
    End Sub

    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        txtMG.Text += "7"
    End Sub

    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        txtMG.Text += "8"
    End Sub

    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        txtMG.Text += "9"
    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        txtMG.Text += "4"
    End Sub

    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        txtMG.Text += "5"
    End Sub

    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        txtMG.Text += "6"
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        txtMG.Text += "1"
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        txtMG.Text += "2"
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        txtMG.Text += "3"
    End Sub

    Private Sub cmdDOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDOT.Click
        txtMG.Text += "."
    End Sub

    Private Sub cmd0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd0.Click
        txtMG.Text += "0"
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        MachineNUM = txtMG.Text

        If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)
        Dim cnt As Integer
        cnt = 0
        Try
            cnt = ss.GetWMFTCount(MachineType, MachineNUM)
        Catch ex As Exception
            cnt = 0
        End Try

        If cnt <= 3 And cnt > 0 Then
            Dim f As frmGetGroupFT
            f = New frmGetGroupFT
            f.FTCount = cnt
            If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                Me.Close()
            End If
            f = Nothing
        Else
            MsgBox("Ошибка в номере группы")
        End If

     

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class