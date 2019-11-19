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
Imports System.Runtime.InteropServices
Imports Symbol
Imports Symbol.RFID3
Imports Symbol.ResourceCoordination
Imports System.Threading


Public Class frmChangeFilter

  

    Public Sub New()
        InitializeComponent()
    
    End Sub

    


   

    Private Sub frmDecodeRFID_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Enabled = False
        StopReading()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            
            Dim dtFT As DataTable
            dtFT = driver.GetFT()
            cmbFT.DisplayMember = "TheCode"
            cmbFT.ValueMember = "TheNum"
            cmbFT.DataSource = dtFT
            Timer1.Enabled = True

        Catch
          
        End Try
    End Sub

  

    Private Sub ProcessTags(ByVal Tag__1 As IEnumerable(Of Symbol.RFID3.TagData))


        Try
            Dim maxRSSI_Tag As Symbol.RFID3.TagData = Nothing
            Dim strTagID As String = String.Empty

            Dim count As Integer = 0
            'Dim rdate As Date
            'rdate = Date.Now()
            For Each tag__2 As Symbol.RFID3.TagData In Tag__1
                'If tag__2.TagEventTimeStamp >= rdate.AddSeconds(-1) Then
                    System.Windows.Forms.Application.DoEvents()

                    If maxRSSI_Tag Is Nothing Then
                        maxRSSI_Tag = tag__2
                    Else
                        If tag__2.PeakRSSI > maxRSSI_Tag.PeakRSSI Then
                            maxRSSI_Tag = tag__2
                        End If
                    End If
               ' End If
            Next
            If Not maxRSSI_Tag Is Nothing Then

                strTagID = maxRSSI_Tag.TagID

              


                If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)
                lblStatus.Text = "Запрос к серверу"
                Application.DoEvents()
                Try
                    strTagID = ss.EncodeTag(strTagID)
                    txtTagID.Text = strTagID
                    Timer1.Enabled = False
                    StopReading()
                Catch ex As Exception
                    lblStatus.Text = "Ошибка сервера"
                    Application.DoEvents()
                End Try



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

    Private Sub txtTagID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTagID.TextChanged
        If txtTagID.Text <> "" Then
            ' process tagid
            If Not driver Is Nothing Then
                lblStatus.Text = "Расшифровка метки"
                Application.DoEvents()
                txtFT.Text = driver.ExtractFilter(txtTagID.Text)
                txtLT.Text = driver.ExtractLCode(txtTagID.Text) + " " + driver.ExtractLName(txtTagID.Text)
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
                    txtTagID.Text = ""
                End Try

            End If
            InTimer = False
        End If

    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        txtTagID.Text = ""
        txtLT.Text = ""
        txtFT.Text = ""
        lblStatus.Text = ""
        Timer1.Enabled = True
    End Sub
    Shared resultOK As Boolean = False
    Shared Sub OnSaveReady(ByVal ar As System.IAsyncResult)
    Try
        resultOK = ss.EndSaveTAG(ar)
    Catch ex As Exception
        resultOK = False
    End Try

    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cmbFT.SelectedIndex >= 0 Then

            If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)
            lblStatus.Text = "Передаем на сервер"
            Application.DoEvents()
             Dim sTag As String
                sTag = PackFilter(txtTagID.Text, cmbFT.SelectedValue)
              Dim cb As AsyncCallback
                cb = New AsyncCallback(AddressOf OnSaveReady)
                resultOK = False
                ss.BeginSaveTAG(sTag, PackID, cb, Nothing)
                Dim cnt As Integer
                cnt = 30
                While cnt > 0
                  System.Threading.Thread.Sleep(100)
                  cnt -= 1
                  If resultOK Then
                    Exit While
                  End If
                  Application.DoEvents()
                End While
                If resultOK Then
                  Else
                  ss.Dispose()
                   ss = Nothing
                   lblStatus.Text = "Ошибка записи"
                End If
          
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub lblStatus_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStatus.ParentChanged

    End Sub
End Class