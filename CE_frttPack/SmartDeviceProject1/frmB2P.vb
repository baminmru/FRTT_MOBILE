Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Text
Imports System.Xml
Imports System.IO
Imports Symbol
Imports Symbol.RFID3
Imports Symbol.ResourceCoordination
Imports System.Threading

Public Class frmB2P

    Private ReadP As Boolean = False
    Private fcode As Integer
    Public Sub New()
        InitializeComponent()
    End Sub


    Private Sub frmDecodeRFID_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Enabled = False
        StopReading()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub


  Private Sub ProcessTags(ByVal Tag__1 As IEnumerable(Of Symbol.RFID3.TagData))


    Try
      Dim maxRSSI_Tag As Symbol.RFID3.TagData = Nothing
      Dim strTagID As String = String.Empty
      Dim ok As Boolean

      Dim count As Integer = 0
      'Dim rdate As Date
      'rdate = Date.Now()
      For Each tag__2 As Symbol.RFID3.TagData In Tag__1
        ok = False
        'If tag__2.TagEventTimeStamp >= rdate.AddSeconds(-1) Then

          
          If tag__2.TagID.Substring(0, 2) = "03" Then
              ok = True
          End If


          System.Windows.Forms.Application.DoEvents()
          If ok Then
            If maxRSSI_Tag Is Nothing Then
              maxRSSI_Tag = tag__2
            Else
              If tag__2.PeakRSSI > maxRSSI_Tag.PeakRSSI Then
                maxRSSI_Tag = tag__2
              End If
            End If
          End If

        'End If
      Next
      If Not maxRSSI_Tag Is Nothing Then

        strTagID = maxRSSI_Tag.TagID

       


        If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)

        lblStatus.Text = "Получена метка"
        Try
          txtB.Text = strTagID
          strTagID = PackFilter(txtB.Text, 0)
          ss.SaveTAG(strTagID, PackID)

          lblStatus.Text = "Разгрузка коробки зафиксирована"
        Catch ex As Exception
          lblStatus.Text = "Ошибка сервера"
          Application.DoEvents()
        End Try
        Button1.Enabled = True
        Timer1.Enabled = False
        StopReading()
      End If
    Catch ex As Exception
      MessageBox.Show("Error:" & ex.Message, "CE_FRTTPACK")
    End Try
  End Sub




  Private Sub txtB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtB.TextChanged
    If txtB.Text <> "" Then
      ' process tagid
      If Not driver Is Nothing Then
        lblStatus.Text = "Расшифровка метки"
        Application.DoEvents()
        txtFT.Text = driver.ExtractFilter(txtB.Text)
        FilterCode = txtFT.Text
      End If

    End If
  End Sub



  Private Shared InTimer As Boolean = False
  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    If Not InTimer Then
      InTimer = True
      If m_ReaderAPI.IsConnected Then
        StartReadTags()
        Try

                    Dim Tags As IEnumerable(Of Symbol.RFID3.TagData) = m_ReaderAPI.Actions.GetReadTags(2)
          If Not Tags Is Nothing Then
            lblStatus.Text = "Чтение метки"
            ProcessTags(Tags)
          Else
            lblStatus.Text = lblStatus.Text + "*"
            If lblStatus.Text.Length > 30 Then
              lblStatus.Text = ""
            End If
          End If
        Catch ex As Exception
          txtB.Text = ""
          lblStatus.Text = lblStatus.Text + "*"
          If lblStatus.Text.Length > 30 Then
            lblStatus.Text = ""
          End If
        End Try
        Application.DoEvents()
      End If
      InTimer = False
    End If
  End Sub



    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click

        txtB.Text = ""
        txtFT.Text = ""
        FilterCode = ""
        lblStatus.Text = ""
        Button1.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Timer1.Enabled = False
        StopReading()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FilterCode = txtFT.Text
        FilterNum = driver.GetFilterID(FilterCode)
        StopReading()
        Dim f As frmSetFilter
        f = New frmSetFilter
        f.ShowDialog()
        f = Nothing
        Me.Close()
    End Sub
End Class