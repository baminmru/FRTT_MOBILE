
Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Class frmFromList

    Private Sub frmFromList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim dtFT As DataTable
            dtFT = driver.GetFT()
            cmbFT.DisplayMember = "TheCode"
            cmbFT.ValueMember = "TheNum"
            cmbFT.DataSource = dtFT
            VS.Minimum = 0
            VS.Maximum = dtFT.Rows.Count - 1
        Catch

        End Try
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If cmbFT.SelectedIndex >= 0 Then
            FilterNum = cmbFT.SelectedValue
            FilterCode = cmbFT.Text
            Dim f As frmSetFilter
            f = New frmSetFilter
            f.ShowDialog()
            f = Nothing
            Me.Close()
        End If
    End Sub

    Private Sub cmbFT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFT.SelectedIndexChanged
        VS.Value = cmbFT.SelectedIndex
    End Sub

    Private Sub VS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VS.ValueChanged
        cmbFT.SelectedIndex = VS.Value
    End Sub
End Class