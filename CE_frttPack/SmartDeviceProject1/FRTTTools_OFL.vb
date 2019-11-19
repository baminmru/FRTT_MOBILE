Option Explicit On
Imports System.Data

Public Class FRTTTools_OFL

    Public Function GetLT() As DataTable
        Dim dtLT As DataTable
        dtLT = CE_LT.FRDLT_INFO.GetDataTable()

        Dim dr As DataRow()
        dr = dtLT.Select("", "Brief")
        Dim r As DataRow
        Dim dt1 As DataTable = Nothing
        Dim i As Integer, j As Integer
        dt1 = CE_LT.FRDLT_INFO.GetDataTable()
        dt1.Rows.Clear()
        For i = 0 To dtLT.Rows.Count - 1
            r = dt1.NewRow
            For j = 0 To dt1.Columns.Count - 1
                r.Item(j) = dr(i).Item(j)
            Next
            dt1.Rows.Add(r)
        Next
        Return dt1
    End Function

    Public Function GetFT() As DataTable
        Dim dtFT As DataTable = Nothing
        Dim dt1 As DataTable = Nothing
        Dim i As Integer, j As Integer
        dtFT = Nothing

        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If dtFT Is Nothing Then
                    dtFT = CE_FT.FRDFT_INFO.GetDataTable
                    dt1 = CE_FT.FRDFT_INFO.GetDataTable
                    dt1.Rows.Clear()

                Else
                    CE_FT.FRDFT_INFO.Item(1).FillDataTable(dtFT)
                End If
            End If

        Next
        Dim dr As DataRow()
        dr = dtFT.Select("", "Brief")
        Dim r As DataRow

        For i = 0 To dtFT.Rows.Count - 1
            r = dt1.NewRow
            For j = 0 To dt1.Columns.Count - 1
                r.Item(j) = dr(i).Item(j)
            Next
            dt1.Rows.Add(r)
        Next
        Return dt1
    End Function

    Public Function GetFilterID(ByVal FilterCode As String) As Integer

        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If CE_FT.FRDFT_INFO.Item(1).TheCode = FilterCode Then
                    Return CE_FT.FRDFT_INFO.Item(1).TheNum
                End If
            End If
        Next
        Return 0
    End Function

    Public Function GetFilterIDSH(ByVal FilterCode As String) As String
        Dim s1 As String
        Dim s2 As String
        s1 = FilterCode.Replace(".", "")
        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then

                s2 = CE_FT.FRDFT_INFO.Item(1).TheCode.Replace(".", "")

                If s1.IndexOf(s2) >= 0 Then
                    Return CE_FT.FRDFT_INFO.Item(1).TheCode
                End If

                If s2.IndexOf(s1) >= 0 Then
                    Return CE_FT.FRDFT_INFO.Item(1).TheCode
                End If

            End If
        Next
        Return ""
    End Function



    Public Function GetFilterRowID(ByVal FilterCode As String) As Guid
        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If CE_FT.FRDFT_INFO.Item(1).TheCode = FilterCode Then
                    Return CE_FT.FRDFT_INFO.Item(1).ID
                End If
            End If
        Next

        Return Guid.Empty
    End Function



    Public Function GetFRDLT() As CE_FRDLT.FRDLT.Application
        Return Module1.CE_LT
    End Function



    Public Function GetFRDFT(ByVal id As String) As CE_FRDFT.FRDFT.Application
        Dim ft As CE_FRDFT.FRDFT.Application
        Dim nid As Guid
        nid = New Guid(id)

        For Each ft In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If CE_FT.FRDFT_INFO.Item(1).ID.Equals(nid) Then
                    Return ft
                End If
            End If
        Next
        Return Nothing
    End Function



    Public Function GetLTypeRowID(ByVal TypeCode As String) As Guid
        Dim i As Long
        For i = 1 To CE_LT.FRDLT_INFO.Count
            If CE_LT.FRDLT_INFO.Item(i).TheCode = TypeCode Then
                Return CE_LT.FRDLT_INFO.Item(i).ID
            End If
        Next

        Return Guid.Empty
    End Function



    Public Function GetFilteRow(ByVal FilterCode As String) As CE_FRDFT.FRDFT.FRDFT_INFO
        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If CE_FT.FRDFT_INFO.Item(1).TheCode = FilterCode Then
                    Return CE_FT.FRDFT_INFO.Item(1)
                End If
            End If
        Next

        Return Nothing
    End Function




    Public Function GetLTypeRow(ByVal TypeCode As String) As CE_FRDLT.FRDLT.FRDLT_INFO
        Dim i As Long
        For i = 1 To CE_LT.FRDLT_INFO.Count
            If CE_LT.FRDLT_INFO.Item(i).TheCode = TypeCode Then
                Return CE_LT.FRDLT_INFO.Item(i)
            End If
        Next


        Return Nothing
    End Function



    Public Function ExtractFilter(ByVal Label As String) As String
        Dim fs As String
        If Label.Length = 24 Then


            fs = Label.Substring(12, 10)
            For Each Module1.CE_FT In XFT
                If CE_FT.FRDFT_INFO.Count > 0 Then
                    If CE_FT.FRDFT_INFO.Item(1).TheNum = Val("&H0" + fs) Then
                        Return CE_FT.FRDFT_INFO.Item(1).TheCode
                    End If
                End If
            Next
        End If

        Return ""
    End Function




    Public Function ExtractFilterOnly(ByVal Label As String) As String
        Dim fs As String
        If Label.Length = 24 Then


            fs = Label.Substring(12, 10)
            For Each Module1.CE_FT In XFT
                If CE_FT.FRDFT_INFO.Count > 0 Then
                    If CE_FT.FRDFT_INFO.Item(1).TheNum = Val("&H0" + fs) Then
                        Return CE_FT.FRDFT_INFO.Item(1).TheCode
                    End If
                End If
            Next
        End If

        Return ""
    End Function



    Public Function FilterExists(ByVal FCode As String) As Boolean
        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If CE_FT.FRDFT_INFO.Item(1).TheCode = FCode Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function



    Public Function FilterExists2(ByVal FCode As String) As Boolean
        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If Replace(CE_FT.FRDFT_INFO.Item(1).TheCode, ".", "") = Replace(FCode, ".", "") Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function




    Public Function GetRealFilterCode(ByVal FCode As String) As String
        For Each Module1.CE_FT In XFT
            If CE_FT.FRDFT_INFO.Count > 0 Then
                If Replace(CE_FT.FRDFT_INFO.Item(1).TheCode, ".", "") = Replace(FCode, ".", "") Then
                    Return CE_FT.FRDFT_INFO.Item(1).TheCode
                End If
            End If
        Next
        Return ""
    End Function






    Public Function ExtractLCode(ByVal Label As String) As String
        Dim i As Long
        If Label.Length = 24 Then
            For i = 1 To CE_LT.FRDLT_INFO.Count
                If CE_LT.FRDLT_INFO.Item(i).LabelNumber = Val("&H0" + Label.Substring(0, 2)).ToString() Then
                    Return CE_LT.FRDLT_INFO.Item(i).TheCode
                End If
            Next
        End If

        Return ""

    End Function


    Public Function ExtractLName(ByVal Label As String) As String
        Dim i As Long
        If Label.Length = 24 Then
            For i = 1 To CE_LT.FRDLT_INFO.Count
                If CE_LT.FRDLT_INFO.Item(i).LabelNumber = Val("&H0" + Label.Substring(0, 2)).ToString() Then
                    Return CE_LT.FRDLT_INFO.Item(i).TheName
                End If
            Next

        End If

        Return ""
    End Function








    Public Function IsPaperBox(ByVal LBL As String) As Boolean
        Dim i As Long
        For i = 1 To CE_LT.FRDLT_INFO.Count
            If CE_LT.FRDLT_INFO.Item(i).LabelNumber = Val("&H0" + LBL.Substring(0, 2)).ToString() Then
                Return CE_LT.FRDLT_INFO.Item(i).IsPaper = CE_FRDLT.FRDLT.enumBoolean.Boolean_Da
            End If
        Next
        Return False
    End Function

   


    Public Function BuildNewTag(ByVal TCode As Integer, ByVal FID As ULong) As String
        Dim TagID As String

        Dim BoxNum As ULong
        Dim i As Integer
        For i = 1 To CE_LT.FRDLT_INFO.Count
            If CE_LT.FRDLT_INFO.Item(i).LabelNumber = TCode Then

                Select Case PackID
                    Case "0"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber = CE_LT.FRDLT_INFO.Item(i).NxtNumber + 1
                    Case "1"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber1 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber1 = CE_LT.FRDLT_INFO.Item(i).NxtNumber1 + 1
                    Case "2"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber2 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber2 = CE_LT.FRDLT_INFO.Item(i).NxtNumber2 + 1
                    Case "3"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber3 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber3 = CE_LT.FRDLT_INFO.Item(i).NxtNumber3 + 1
                    Case "4"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber4 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber4 = CE_LT.FRDLT_INFO.Item(i).NxtNumber4 + 1
                    Case "5"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber5 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber5 = CE_LT.FRDLT_INFO.Item(i).NxtNumber5 + 1
                    Case "6"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber6 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber6 = CE_LT.FRDLT_INFO.Item(i).NxtNumber6 + 1
                    Case "7"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber7 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber7 = CE_LT.FRDLT_INFO.Item(i).NxtNumber7 + 1
                    Case "8"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber8 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber8 = CE_LT.FRDLT_INFO.Item(i).NxtNumber8 + 1
                    Case "9"
                        BoxNum = CE_LT.FRDLT_INFO.Item(i).NxtNumber9 + 1
                        CE_LT.FRDLT_INFO.Item(i).NxtNumber9 = CE_LT.FRDLT_INFO.Item(i).NxtNumber9 + 1
                End Select

                CE_Manager.SaveDocumentToXML(StorePath + "\FRDLT\", CE_LT)
                Exit For
            End If
        Next
        Dim BoxCode As String
        BoxCode = Hex(BoxNum)
        While BoxCode.Length < 7
            BoxCode = "0" + BoxCode
        End While
        BoxCode = PackID + BoxCode

        Dim BID As String
        BID = Hex(TCode And &H3F)

        If BID.Length = 1 Then
            BID = "0" + BID
        End If


        TagID = BID + BoxCode + Calc12(BID + BoxCode)

        BoxCode = Hex(FID)
        While BoxCode.Length < 10
            BoxCode = "0" + BoxCode
        End While
        TagID = TagID + BoxCode + Calc24(TagID + BoxCode)
        Return TagID
    End Function

    




   


    Public Function ExtractLNumber(ByVal TagID As String)
        Dim lStr As String
        If TagID.Length = 24 Then
            lStr = TagID.Substring(2, 8)
            Return Val("&H0" + lStr)
        End If
        Return "0"
    End Function





   



End Class


