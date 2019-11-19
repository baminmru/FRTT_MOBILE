Public Class frmGetGroupFT

    Public FTCount As Integer
    Public FT1 As String
    Public FT2 As String
    Public FT3 As String

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmGetGroupFT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)
        Dim i As Integer
        i = 0
        If i < FTCount Then

            Try
                FT1 = ss.GetWMFT(MachineType, MachineNUM, i)
                FT2 = FT1
                FT3 = FT1
            Catch ex As Exception

            End Try
        End If
        i += 1
        If i < FTCount Then

            Try
                FT2 = ss.GetWMFT(MachineType, MachineNUM, i)
            Catch ex As Exception
                FT3 = FT2
            End Try
        End If
        i += 1
        If i < FTCount Then

            Try
                FT3 = ss.GetWMFT(MachineType, MachineNUM, i)
            Catch ex As Exception

            End Try
        End If

        cmdF1.Text = FT1
        cmdF2.Text = FT2
        cmdF3.Text = FT3


        If FTCount = 1 Then
            cmdF2.Visible = False
            cmdF3.Visible = False
        End If
        If FTCount = 2 Then
            cmdF3.Visible = False
        End If
    End Sub

    Private Sub cmdF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF1.Click
        FilterCode = FT1
        Dim f As frmSetFilter
        f = New frmSetFilter
        f.ShowDialog()
        f = Nothing
        Me.Close()
    End Sub

    Private Sub cmdF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF2.Click
        FilterCode = FT2
        Dim f As frmSetFilter
        f = New frmSetFilter
        f.ShowDialog()
        f = Nothing
        Me.Close()
    End Sub

    Private Sub cmdF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF3.Click
        FilterCode = FT3
        Dim f As frmSetFilter
        f = New frmSetFilter
        f.ShowDialog()
        f = Nothing
        Me.Close()
    End Sub
End Class