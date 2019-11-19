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
Imports Symbol.RFID3.Events
Imports Symbol.ResourceCoordination
Imports System.Threading

Public Class frmMain


  Private m_TagTable As Hashtable
  Private m_StartTime As TimeSpan

  Private m_TagTotalCount As UInt32
  Private m_IsConnected As Boolean
  Private m_UpdateReadHandler As UpdateRead = Nothing
  Private m_UpdateStatusHandler As updateStatusResult = Nothing
  Private Delegate Sub UpdateRead(ByVal eventData As ReadEventData)
  Private Delegate Sub updateStatusResult(ByVal eventData As StatusEventData)


    Private Function ReaderConnected()

        m_ReaderAPI = New RFIDReader("127.0.0.1", 5084, 0)

        Try
          m_ReaderAPI.Connect()
        Catch ex As System.Exception
          Return False
        End Try

        Return True
  End Function

    Private Sub ReaderDisconnected()
    Try
          If m_ReaderAPI IsNot Nothing Then
            m_ReaderAPI.Disconnect()
          End If
    Catch ex As Exception

    End Try

    End Sub
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim f As frmPassword
        f = New frmPassword
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then

            If f.txtPassword.Text = ClosePassword Then
                Shutdown()
                driver = Nothing
                ShowWindow(FindWindow("HHTaskBar", Nothing), SW_SHOWNORMAL)
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub cmdDecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecode.Click
        Dim f As frmDecodeRFID
        f = New frmDecodeRFID
        LastSavedTag = ""
        f.ShowDialog()
        f = Nothing
    End Sub

   

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ShowWindow(FindWindow("HHTaskBar", Nothing), SW_SHOWNORMAL)
        Shutdown()
        driver = Nothing

        Application.Exit()
    End Sub


  Private Sub Shutdown()
  
    If m_ReaderAPI IsNot Nothing Then
      Try
         m_ReaderAPI.Disconnect()
      Catch ex As Exception

      End Try

    End If
    m_ReaderAPI = Nothing


    If Not myScanSampleAPI Is Nothing Then
      Try
        myScanSampleAPI.TermReader()
      Catch ex As Exception

      End Try

      myScanSampleAPI = Nothing
    End If
  End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

   



        CE_Manager = New CEOfflineBase.Manager
        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("\FRTTPACKConfig.xml")
            Dim node As XmlElement
            node = xml.LastChild()
            PackID = (node.Attributes.GetNamedItem("PackID").Value)
            ClosePassword = (node.Attributes.GetNamedItem("ClosePassword").Value)
            ServiceURL = (node.Attributes.GetNamedItem("ServiceURL").Value)
        Catch

        End Try

       Me.Text = "FRTT #" + PackID.ToString


        StorePath = "\FRPACK"

        Dim xdr As System.IO.DirectoryInfo = Nothing
        CE_Manager.StorePath = StorePath

        CE_Manager.DLLPath = "\Program Files\frtt"

        Try
            xdr = New DirectoryInfo(StorePath & "\FRDLT\")
        Catch
        End Try
        If Not xdr Is Nothing Then

            For Each fl As FileInfo In xdr.GetFiles()
                Try
                    CE_LT = CE_Manager.GetInstanceObjectFromXML(fl.FullName)

                Catch
                End Try
            Next
        End If



        XFT = New Collection

        Try
            xdr = New DirectoryInfo(StorePath & "\FRDFT\")
        Catch
        End Try
        If Not xdr Is Nothing Then

            For Each fl As FileInfo In xdr.GetFiles()
                Try
                    CE_FT = CE_Manager.GetInstanceObjectFromXML(fl.FullName)
                    XFT.Add(CE_FT, CE_FT.ID.ToString())
                Catch
                End Try
            Next
        End If

        Dim ok As Boolean = False
        Dim trycnt As Integer = 20
        While (trycnt > 0) And (Not ok)
          Try
            ok = ReaderConnected()
          Catch
            ok = False
          End Try
            If Not ok Then
                Thread.Sleep(1000)
                trycnt -= 1
            End If
        End While
        If ok Then
            ShowWindow(FindWindow("HHTaskBar", Nothing), 0)
        Else
            MessageBox.Show("Error: Reader not initialized", "CE_FRTTPACK")
            ReaderDisconnected()
            Application.[Exit]()
        End If


    End Sub

    Private Sub packB2P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles packB2P.Click
        Dim f As frmB2P
        f = New frmB2P
        LastSavedTag = ""
        f.ShowDialog()
        f = Nothing
    End Sub

    Private Sub cmdP2B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As frmP2B
        f = New frmP2B
        f.ShowDialog()
        f = Nothing
    End Sub

    'Private Sub cmdNewLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim f As frmNew
    '    f = New frmNew
    '    f.ShowDialog()
    '    f = Nothing
    'End Sub

    Private Sub cmdSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSync.Click
        Dim f As frmSync
        f = New frmSync
        f.ShowDialog()
        f = Nothing
    End Sub

    Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    Try

      Dim strPath As String = Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName
      strPath = strPath.Replace(Assembly.GetExecutingAssembly().ManifestModule.Name, "DeviceReader.Config")
      Dim configStreamStr As String = String.Empty

      driver = New FRTTTools_OFL()



      m_ReaderMgmt = New ReaderManagement
      m_TagTable = New Hashtable(100)

    Catch ex As Exception
      MessageBox.Show(ex.Message, "CE_FRTTPACK")
      Application.[Exit]()

    End Try

  End Sub

   

    Private Sub packSH2P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles packSH2P.Click
        Dim f As frmSH2P
        f = New frmSH2P
        LastSavedTag = ""
        f.ShowDialog()
        f = Nothing
    End Sub

Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        MsgBox("EMDK 2.8, V.14/10/2014 ", MsgBoxStyle.OkOnly, "FRTT REPACK")
End Sub
End Class
