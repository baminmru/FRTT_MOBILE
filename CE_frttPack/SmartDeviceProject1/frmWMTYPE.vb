Public Class frmWMTYPE

    Private Sub frmWMTYPE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmWMTYPE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = System.Windows.Forms.Keys.Up) Then
            'Up
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Down) Then
            'Down
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Left) Then
            'Left
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Right) Then
            'Right
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Enter) Then
            'Enter
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MachineType = "'DF-10','KDF'"
        Dim f As frmWMGroup
        f = New frmWMGroup
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MachineType = "'Merlin','MULFI'"
        Dim f As frmWMGroup
        f = New frmWMGroup
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MachineType = "'FS'"
        Dim f As frmWMGroup
        f = New frmWMGroup
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MachineType = "'Linkup'"
        Dim f As frmWMGroup
        f = New frmWMGroup
        If f.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        f = Nothing
    End Sub
End Class