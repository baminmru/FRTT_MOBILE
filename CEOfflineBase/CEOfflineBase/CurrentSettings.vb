Module CurrentSettings


    Public Function IsNULL_SQL(ByVal ValName As String, ByVal ValReplace As String) As String
       
        IsNULL_SQL = " isnull(" + ValName + "," + ValReplace + ") "

    End Function

    Public Function FormatDT(ByVal value As Date, Optional ByVal bFull As Boolean = False) As String
        Dim tmpDateTime As Date
  
        'FormatDT = Format(value, "yyyy-mm-dd HH:MM:SS")
        'FormatDT = Format(value, "yyyy-mm-dd")
        If bFull Then
            FormatDT = MakeMSSQLDate(value)

        Else
            tmpDateTime = DateSerial(Year(value), Month(value), Day(value))
            FormatDT = MakeMSSQLDate(tmpDateTime)
        End If

    End Function

    Public Function MakeODBCDate(ByVal d As Date) As String
        'yyyy-mm-dd hh:mi:ss(24h)
        If IsDBNull(d) Then
            MakeODBCDate = "NULL"
        Else
            MakeODBCDate = Right("0000" & Year(d), 4) & "-" & Right("00" & Month(d), 2) & "-" & Right("00" & Day(d), 2) & " " & Right("00" & Hour(d), 2) & ":" & Right("00" & Minute(d), 2) & ":" & Right("00" & Second(d), 2)
        End If
    End Function

    'ѕреобразование даты дл€ включени€ в sql запрос
    'Parameters:
    '[IN]   d , тип параметра: Date  - дата
    'Returns:
    '  значение типа String
    'See Also:
    '  MakeODBCDate
    'Example:
    ' dim variable as String
    ' variable = me.MakeMSSQLDate(<параметры>)
    Public Function MakeMSSQLDate(ByVal d As Date) As String
        If IsDBNull(d) Then
            MakeMSSQLDate = "NULL"
        Else
            MakeMSSQLDate = "convert(datetime,'" & MakeODBCDate(d) & "',120)"
        End If
    End Function

    Public Function MakeORACLEDate(ByVal d As Date) As String
        If IsDBNull(d) Then
            MakeORACLEDate = "NULL"
        Else
            MakeORACLEDate = "to_date('" & MakeODBCDate(d) & "','YYYY-MM-DD HH24:MI:SS')"
        End If
    End Function


    Public Function GUID2String(ByVal gIn As System.Guid) As String
        If gIn.Equals(System.Guid.Empty) Then
            Return ""
        Else
            Return "{" + gIn.ToString().ToUpper() + "}"
        End If
    End Function

    Public Function CheckIDtoID_ORACLE(ByVal sIn As String) As String
        If Len(sIn) <= 0 Then Return ""

        If (Not Left(sIn, 1) = "{") And (Len(sIn) = 36) Then
            sIn = "{" + sIn + "}"
        End If
        Return sIn.ToUpper()
    End Function

End Module
