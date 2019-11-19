Option Strict Off
Option Explicit On
Imports System.Data



Public Class NamedValue
    'Именованные значения
    Public TheName As String
    'Public DataType As DbType
    Public int_DataType As DbType
    Public Direction As ParameterDirection
    Private _Value As Object
    Public Size As Long

    Public Sub New()
        DataType = DbType.String
        Direction = ParameterDirection.Input
    End Sub

    Property DataType() As DbType
        Get
            DataType = int_DataType
        End Get
        Set(ByVal value As DbType)
           
            int_DataType = value

        End Set
    End Property

    Property Value() As Object
        Get
            Value = _Value
        End Get
        Set(ByVal value2 As Object)
            If value2 Is Nothing Then
                _Value = value2
                Exit Property
            End If
           
            _Value = value2

        End Set
    End Property

    Public Sub ORACLE_GUID()
        If UCase(_Value.GetType().ToString()) = UCase("System.GUID") Then
            _Value = "{" + _Value.ToString().ToUpper() + "}"
        End If
        DataType = DbType.String
        Size = 38
    End Sub
End Class
