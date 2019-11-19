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

Public Class frmSH2P

   
    Private myReadNotifyHandler As EventHandler = Nothing
    Private myStatusNotifyHandler As EventHandler = Nothing
    Private isReaderInitiated As Boolean = False
    Private MyTrigger As Symbol.ResourceCoordination.Trigger = Nothing
    Private MyTriggerHandler As Symbol.ResourceCoordination.Trigger.TriggerEventHandler = Nothing
    Private TriggerDev As Symbol.ResourceCoordination.TriggerDevice = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

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
        myScanSampleAPI.StartRead(False)
    End Sub

   


    Private Sub frmSH2P__Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            myScanSampleAPI.StopRead()
            myScanSampleAPI.DetachReadNotify()
            myScanSampleAPI.DetachStatusNotify()
        Catch ex As Exception

        End Try
      
        
        If MyTrigger IsNot Nothing Then
            MyTrigger.Dispose()
        End If
        If Not myScanSampleAPI Is Nothing Then
            myScanSampleAPI = Nothing
        End If
    End Sub

   

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        ' Initialize the API reference.
        If myScanSampleAPI Is Nothing Then
            myScanSampleAPI = New CE_FRTTPACK.BarcodeAPI
        End If

        Me.isReaderInitiated = myScanSampleAPI.InitReader()

        If Not Me.isReaderInitiated Then

            MessageBox.Show("Ошибка подключения к сканеру штрихкодов")
            Me.Close()
        Else ' If the reader has been initialized

            Me.myStatusNotifyHandler = New EventHandler(AddressOf myReader_StatusNotify)
            myScanSampleAPI.AttachStatusNotify(myStatusNotifyHandler)

            Me.myReadNotifyHandler = New EventHandler(AddressOf myReader_ReadNotify)
            myScanSampleAPI.AttachReadNotify(myReadNotifyHandler)

        End If
        SetupTriggerResource()

    End Sub

    Private Sub HandleData(ByVal TheReaderData As Symbol.Barcode.ReaderData)
        txtSH.Text = TheReaderData.Text
    
    End Sub 'HandleData

    Private Sub myReader_ReadNotify(ByVal Sender As Object, ByVal e As EventArgs)
        ' Checks if the Invoke method is required because the ReadNotify delegate is called by a different thread
        If Me.InvokeRequired Then
            ' Executes the ReadNotify delegate on the main thread
            Me.Invoke(myReadNotifyHandler, New Object() {Sender, e})

        Else

            ' Get ReaderData
            Dim TheReaderData As Symbol.Barcode.ReaderData = myScanSampleAPI.Reader.GetNextReaderData()

            Select Case TheReaderData.Result

                Case Symbol.Results.SUCCESS

                    HandleData(TheReaderData)
                    myScanSampleAPI.StopRead()

                Case Symbol.Results.E_SCN_READTIMEOUT

                    myScanSampleAPI.StartRead(False)

                Case Symbol.Results.CANCELED

                Case Symbol.Results.E_SCN_DEVICEFAILURE
                    myScanSampleAPI.StopRead()

                    myScanSampleAPI.StartRead(False)

                Case Else


                    If TheReaderData.Result = Symbol.Results.E_SCN_READINCOMPATIBLE Then
                        myScanSampleAPI.StopRead()
                        myScanSampleAPI.DetachReadNotify()
                        myScanSampleAPI.DetachStatusNotify()
                        MessageBox.Show("Ошибка работы сканера штрихкодов")
                        Me.Close()
                        Return
                    End If

            End Select
        End If
    End Sub 'myReader_ReadNotify


    ''' <summary>
    ''' Status notification handler.
    ''' </summary>
    Private Sub myReader_StatusNotify(ByVal Sender As Object, ByVal e As EventArgs)
        ' Checks if the Invoke method is required because the StatusNotify delegate is called by a different thread
        If Me.InvokeRequired Then
            ' Executes the StatusNotify delegate on the main thread
            Me.Invoke(myStatusNotifyHandler, New Object() {Sender, e})

        Else

            ' Get ReaderData
            Dim TheStatusData As Symbol.Barcode.BarcodeStatus = myScanSampleAPI.Reader.GetNextStatus()

            Select Case TheStatusData.State

                Case Symbol.Barcode.States.WAITING

                    'Me.myScanSampleAPI.StopRead()
                    'Me.myScanSampleAPI.StartRead(False)


                Case Symbol.Barcode.States.IDLE


                Case Symbol.Barcode.States.READY


                Case Else

            End Select
        End If
    End Sub 'myReader_StatusNotify
 


    Private Sub MenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        txtFT.Text = ""

        lblStatus.Text = ""
        cmdWrite.Enabled = False
        FilterCode = ""
        FilterNum = 0
    End Sub

    Private Sub MenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite.Click
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

Private Sub txtSH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSH.TextChanged
        txtFT.Text = driver.GetFilterIDSH(txtSH.Text)
        FilterCode = txtFT.Text
        FilterNum = driver.GetFilterID(FilterCode)
        If FilterNum <> 0 Then
            cmdWrite.Enabled = True
        End If
End Sub
End Class