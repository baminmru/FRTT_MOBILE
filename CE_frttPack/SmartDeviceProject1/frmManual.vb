Public Class frmManual

    Private Sub cmdCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCE.Click
        txtFT.Text = ""
    End Sub

    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        txtFT.Text += "7"
    End Sub

    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        txtFT.Text += "8"
    End Sub

    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        txtFT.Text += "9"
    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        txtFT.Text += "4"
    End Sub

    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        txtFT.Text += "5"
    End Sub

    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        txtFT.Text += "6"
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        txtFT.Text += "1"
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        txtFT.Text += "2"
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        txtFT.Text += "3"
    End Sub

    Private Sub cmdDOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDOT.Click
        txtFT.Text += "."
    End Sub

    Private Sub cmd0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd0.Click
        txtFT.Text += "0"
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If driver.FilterExists(txtFT.Text) Then
            FilterCode = txtFT.Text
            FilterNum = driver.GetFilterID(FilterCode)
            Dim f As frmSetFilter
            f = New frmSetFilter
            f.ShowDialog()
            f = Nothing
            Me.Close()
        Else
            MsgBox("Фильтр:" + txtFT.Text + " не обнаружен.")
        End If
       
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class