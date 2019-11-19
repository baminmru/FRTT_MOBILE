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

Public Class frmP2B
    Private ReadB As Boolean = False
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
                    If Not ReadB Then
                        If tag__2.TagID.Substring(0, 2) = "01" Or tag__2.TagID.Substring(0, 2) = "02" Then
                            ok = True
                        End If
                    Else
                        If tag__2.TagID.Substring(0, 2) = "03" Then
                            ok = True
                        End If
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
                If Not ReadB Then

                    lblStatus.Text = "Запрос к серверу"
                    Application.DoEvents()
                    Try
                        strTagID = ss.EncodeTag(strTagID)

                    Catch ex As Exception
                        lblStatus.Text = "Ошибка сервера"
                        Application.DoEvents()
                    End Try

                    txtP.Text = strTagID
                    txtB.Text = ""
                Else
                    lblStatus.Text = "Регистрация переупаковки"
                    Try
                        strTagID = PackFilter(strTagID, fcode)

                        ss.SaveTAG(strTagID, PackID)
                        txtB.Text = strTagID

                        strTagID = PackFilter(txtP.Text, 0)

                        ss.SaveTAG(strTagID, PackID)
                        ReadB = False
                        txtP.Text = strTagID
                        lblStatus.Text = "Переупаковка проведена"
                    Catch ex As Exception
                        lblStatus.Text = "Ошибка сервера"
                        Application.DoEvents()
                    End Try
                End If


            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "CE_FRTTPACK")
        End Try
    End Sub



    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Timer1.Enabled = False
        StopReading()
        Me.Close()

    End Sub

    Private Sub txtP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP.TextChanged
        If txtP.Text <> "" Then
            ' process tagid
            If Not driver Is Nothing Then
                lblStatus.Text = "Расшифровка метки"
                Application.DoEvents()
                txtFT.Text = driver.ExtractFilter(txtP.Text)
                fcode = driver.GetFilterID(txtFT.Text)
                ReadB = True
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
                    End If
                Catch ex As Exception
                    txtP.Text = ""
                End Try

            End If
            InTimer = False
        End If
    End Sub



    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        ReadB = False
        txtP.Text = ""
        txtB.Text = ""
        txtFT.Text = ""
        lblStatus.Text = ""
    End Sub


End Class