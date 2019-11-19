Imports System.Data
Imports System.IO

Public Class frmSync
  Private stopSync As Boolean = False
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
    stopSync = True
    Me.Close()
    End Sub

  Private Sub cmdSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSync.Click
    stopSync = False
    Dim i As Integer
    Dim cnt As Integer = 0

    If ss Is Nothing Then ss = New SyncService.FRTT_CE_Sync(ServiceURL)
    txtOut.Text = ""
    Dim trycnt As Integer
    trycnt = 3
    While trycnt > 0
      Application.DoEvents()
      If stopSync Then Exit Sub
      trycnt -= 1
      Try
        cnt = ss.GetFTCount()
      Catch ex As Exception
        txtOut.Text = ex.Message
        Exit Sub
      End Try

    End While
    If cnt = 0 Then Exit Sub
    Dim sXml As String

    txtOut.Text = "Фильтров в базе данных " & cnt.ToString() & vbCrLf
    pbPhase.Minimum = 0
    pbPhase.Maximum = 1 + cnt
    pbPhase.Value = 0

    '  Передать в базу информацию о состоянии счетчиков лотков
    Dim j As Integer

    Dim xdr As System.IO.DirectoryInfo = Nothing
    CE_Manager.StorePath = StorePath & "\FRPACK\"
    CE_LT = Nothing



    pbPhase.Value = 1

    Dim DataLoaded As Boolean = False

    ' выгрузить из базы справочник типов лотков

    trycnt = 3
    While trycnt > 0
      Application.DoEvents()
      If stopSync Then Exit Sub
      trycnt -= 1
      txtOut.Text = "Выгрузка актуального справочника типов лотков " & vbCrLf & txtOut.Text
      Dim x2 As New Xml.XmlDocument
      Try
        x2.LoadXml(ss.GetLT())
        Exit While
      Catch ex As Exception
        txtOut.Text = ex.Message
        Exit Sub
      End Try
    End While
    If trycnt = 0 Then
      If MsgBox("Продолжить синхронизацию?", MsgBoxStyle.YesNo, "Подтверждение") = MsgBoxResult.No Then
        Exit Sub
      End If
    End If

    trycnt = 3
    While trycnt > 0
      Application.DoEvents()
      If stopSync Then Exit Sub
      trycnt -= 1
      Try
        CE_LT = CE_Manager.GetInstanceObjectFromXMLText(ss.GetLT())
        CE_Manager.SaveDocumentToXML(StorePath + "\FRDLT\" + CE_LT.ID.ToString() + ".xml", CE_LT)
        Exit While

      Catch ex As Exception
        txtOut.Text = ex.Message & vbCrLf & txtOut.Text
      End Try

    End While
    If trycnt = 0 Then
      If MsgBox("Продолжить синхронизацию?", MsgBoxStyle.YesNo, "Подтверждение") = MsgBoxResult.No Then
        Exit Sub
      End If
    End If



    ' выгрузить из базы справочники типов фильтров

    txtOut.Text = "Выгрузка актуального справочника типов фильтров " & vbCrLf & txtOut.Text
    'cnt = ss.GetFTCount()

    For i = 0 To cnt - 1
      pbPhase.Value = 2 + i
      trycnt = 3
      While trycnt > 0
        Application.DoEvents()
        If stopSync Then Exit Sub
        trycnt -= 1
        Try
          sXml = ss.GetFT(i)
        Catch ex As Exception
          sXml = ""
          txtOut.Text = ex.Message
        End Try
        Try
          If sXml <> "" Then
            CE_FT = CE_Manager.GetInstanceObjectFromXMLText(sXml)
            If CE_FT.FRDFT_INFO.Count > 0 Then
              CE_Manager.SaveDocumentToXML(StorePath + "\FRDFT\" + CE_FT.ID.ToString() + ".xml", CE_FT)
              txtOut.Text = CE_FT.FRDFT_INFO.Item(1).TheCode & vbCrLf & txtOut.Text
              Exit While
            End If
          End If
        Catch ex As Exception

          txtOut.Text = "(" + i.ToString() + ")" + ex.Message & "___XML START___" & vbCrLf & sXml & vbCrLf & "___XML END___" & vbCrLf & txtOut.Text
        End Try
      End While
      If trycnt = 0 Then
        If MsgBox("Продолжить синхронизацию?", MsgBoxStyle.YesNo, "Подтверждение") = MsgBoxResult.No Then
          Exit Sub
        End If
      End If

    Next

    'If txtOut.Text = "" Then
      txtOut.Text = "Синхронизация завершена " & vbCrLf & txtOut.Text
    'End If



  End Sub
End Class