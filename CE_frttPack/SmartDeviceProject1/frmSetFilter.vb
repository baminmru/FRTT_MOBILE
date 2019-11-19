
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

Public Class frmSetFilter
    Dim strTagID As String = String.Empty
    Private MyTrigger As Symbol.ResourceCoordination.Trigger = Nothing
    Private MyTriggerHandler As Symbol.ResourceCoordination.Trigger.TriggerEventHandler = Nothing
    Private TriggerDev As Symbol.ResourceCoordination.TriggerDevice = Nothing

    Public Sub SetupTriggerResource()
        Try
            'create a trigger object
            TriggerDev = New Symbol.ResourceCoordination.TriggerDevice(Symbol.ResourceCoordination.TriggerID.ALL_TRIGGERS, DirectCast(Nothing, Symbol.ResourceCoordination.TriggerState()))

            MyTrigger = New Symbol.ResourceCoordination.Trigger(TriggerDev)

            'create an event handler and attach a handler method for trigger
            MyTriggerHandler = New Symbol.ResourceCoordination.Trigger.TriggerEventHandler(AddressOf MyTriggerH)

            AddHandler MyTrigger.Stage2Notify, MyTriggerHandler
        Catch ex As Exception
            MessageBox.Show("Failed to create Trigger: " & ex.Message, "Error")

            Me.Close()
            Return
        End Try
    End Sub


    Private Sub MyTriggerH(ByVal sender As Object, ByVal evt As Symbol.ResourceCoordination.TriggerEventArgs)
        If cmdWrite.Enabled Then
            cmdWrite_Click(sender, evt)
        End If
    End Sub

    Private Sub frmSetFilter_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Enabled = False
        StopReading()
        If MyTrigger IsNot Nothing Then
            MyTrigger.Dispose()
        End If
    End Sub

    Private Sub frmSetFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblFT.Text = FilterCode
        FilterNum = driver.GetFilterID(FilterCode)
        SetupTriggerResource()
        Timer1.Enabled = True
    End Sub

    Private Shared InTimer As Boolean = False
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not InTimer Then
            InTimer = True
            WakeUp()
           Application.DoEvents()
           If m_ReaderAPI.IsConnected Then
                StartReadTags()
                Try

                    Dim Tags As IEnumerable(Of Symbol.RFID3.TagData) = m_ReaderAPI.Actions.GetReadTags(2)
                    If Not Tags Is Nothing Then
                        InTimer = False
                        ProcessTags(Tags)
                    Else
                        lblTag.Text = lblTag.Text + "*"
                        If lblTag.Text.Length > 30 Then
                            lblTag.Text = "*"
                        End If
                    End If
                Catch ex As Exception
                    lblTag.Text = lblTag.Text + "E"
                    If lblTag.Text.Length > 30 Then
                        lblTag.Text = "E"
                    End If
                End Try
                Application.DoEvents()
            Else
                lblTag.Text = lblTag.Text + "C"
                If lblTag.Text.Length > 30 Then
                    lblTag.Text = "C"
                End If
            End If
            InTimer = False
        End If

    End Sub

    Private Sub ProcessTags(ByVal Tag__1 As IEnumerable(Of Symbol.RFID3.TagData))


        Try
            Dim maxRSSI_Tag As Symbol.RFID3.TagData = Nothing


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
                'End If
            Next
            If Not maxRSSI_Tag Is Nothing Then

                strTagID = maxRSSI_Tag.TagID

              
                lblTag.Text = strTagID
                If LastSavedTag <> strTagID Then
                  cmdWrite.Enabled = True
                  Timer1.Enabled = False
                  StopReading()
                  'lblTag.Text = lblTag.Text + "W"
                  'If lblTag.Text.Length > 30 Then
                  '    lblTag.Text = "W"
                  'End If
                  If IsOn() Then
                    cmdWrite_Click(Me, Nothing)
                  End If

                End If


            End If
        Catch ex As Exception
            'MessageBox.Show("Error:" & ex.Message, "CE_FRTTPACK")
        End Try
    End Sub
    Shared resultOK As Boolean = False
    Shared Sub OnSaveReady(ByVal ar As System.IAsyncResult)
    Try
        resultOK = ss.EndSaveTAG(ar)
    Catch ex As Exception
        resultOK = False
    End Try

    End Sub



    Private Sub cmdWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite.Click
        If FilterNum >= 0 Then

            If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)
            WakeUp()
            Application.DoEvents()
            Try
                Dim sTag As String
                sTag = PackFilter(strTagID, FilterNum)

                ss.SaveTAG(sTag, PackID)
                'Dim cb As AsyncCallback
                'cb = New AsyncCallback(AddressOf OnSaveReady)
                'resultOK = False
                'ss.BeginSaveTAG(sTag, PackID, cb, Nothing)
                'Dim cnt As Integer
                'cnt = 30
                'While cnt > 0
                '  System.Threading.Thread.Sleep(100)
                '  cnt -= 1
                '  If resultOK Then
                '    Exit While
                '  End If
                '  Application.DoEvents()
                'End While
                'If resultOK Then
                'LastSavedTag = strTagID
                Dim f As frmOK
                f = New frmOK
                f.ft = FilterCode
                If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  cmdWrite.Enabled = False
                  Timer1.Enabled = True
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End If

                 f = Nothing
                lblTag.Text = ""
                'Else
                '  ss.Dispose()
                '  ss = Nothing
                '  Dim f As frmErr
                '  f = New frmErr
                '  f.msg = "Ошибка обращения к базе данных"
                '  If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '    cmdWrite.Enabled = False
                '    Timer1.Enabled = True
                '  Else
                '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                '    Me.Close()
                '  End If
                '  f = Nothing
                '  lblTag.Text = ""
                'End If

            Catch ex As Exception
              ss.Dispose()
                ss = Nothing
                Dim f As frmErr
                f = New frmErr
                f.msg = ex.Message
                If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  cmdWrite.Enabled = False
                  Timer1.Enabled = True
                Else
                  Me.DialogResult = Windows.Forms.DialogResult.Cancel
                  Me.Close()
                End If
                f = Nothing
                lblTag.Text = ""

            End Try
        Else
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        lblTag.Text = ""
        strTagID = ""
        cmdWrite.Enabled = False
        Timer1.Enabled = True
    End Sub
End Class