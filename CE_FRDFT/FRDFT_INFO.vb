
Option Explicit On

Imports System
Imports System.IO
Imports CEOfflineBase
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace FRDFT


    ''' <summary>
    '''Реализация строки раздела Тип фильтра
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDFT_INFO
        Inherits CEOfflineBase.Document.DocRow_Base



        ''' <summary>
        '''Локальная переменная для поля Код типа фильтра
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_TheCode As String


        ''' <summary>
        '''Локальная переменная для поля Тип фильтра
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_Ftype As enumFilterType


        ''' <summary>
        '''Локальная переменная для поля Номер фильтра
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_TheNum As Long



        ''' <summary>
        '''Очистить поля раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheCode=   
            ' m_Ftype=   
            ' m_TheNum=   
        End Sub



        ''' <summary>
        '''Количество полей в строке раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides ReadOnly Property Count() As Long
            Get
                Count = 3
            End Get
        End Property



        ''' <summary>
        '''Получить \Задать поле по номеру 
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Property Value(ByVal Index As Object) As Object
            Get
                If Microsoft.VisualBasic.IsNumeric(Index) Then
                    Dim l As Long
                    l = CLng(Index)
                    Select Case l
                        Case 0
                            Value = ID
                        Case 1
                            Value = TheCode
                        Case 2
                            Value = Ftype
                        Case 3
                            Value = TheNum
                    End Select
                Else
                    On Error Resume Next
                    Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
                End If
            End Get
            Set(ByVal value As Object)
                If Microsoft.VisualBasic.IsNumeric(Index) Then
                    Dim l As Long
                    l = CLng(Index)
                    Select Case l
                        Case 0
                            ID = value
                        Case 1
                            TheCode = value
                        Case 2
                            Ftype = value
                        Case 3
                            TheNum = value
                    End Select
                Else
                    Try
                        Try
                            Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Set, value)
                        Catch ex As Exception
                            Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Let, value)
                        End Try
                    Catch ex As Exception
                    End Try
                End If
            End Set

        End Property



        ''' <summary>
        '''Название поля по номеру
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function FieldNameByID(ByVal Index As Long) As String
            If Microsoft.VisualBasic.IsNumeric(Index) Then
                Dim l As Long
                l = CLng(Index)
                Select Case l
                    Case 0
                        Return "ID"
                    Case 1
                        Return "TheCode"
                    Case 2
                        Return "Ftype"
                    Case 3
                        Return "TheNum"
                End Select
            End If
        End Function



        ''' <summary>
        '''Заполнить строку таблицы данными из полей
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub FillDataTable(ByRef DestDataTable As System.Data.DataTable)
            Dim dr As DataRow
            dr = DestDataTable.NewRow
            On Error Resume Next
            dr("ID") = ID
            dr("Brief") = TheCode
            dr("TheCode") = TheCode
            Select Case Ftype
                Case enumFilterType.FilterType_Cerniy
                    dr("Ftype") = "Черный"
                    dr("Ftype_VAL") = 0
                Case enumFilterType.FilterType_Drugoy
                    dr("Ftype") = "Другой"
                    dr("Ftype_VAL") = -1
                Case enumFilterType.FilterType_Beliy
                    dr("Ftype") = "Белый"
                    dr("Ftype_VAL") = 1
            End Select 'Ftype
            dr("TheNum") = TheNum
            DestDataTable.Rows.Add(dr)
        End Sub



        ''' <summary>
        '''Найти строку в коллекции по идентификатору
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As CEOfflineBase.Document.DocRow_Base
            Dim mFindInside As CEOfflineBase.Document.DocRow_Base = Nothing
            Return Nothing
        End Function



        ''' <summary>
        '''Заполнить коллекцю именованных полей
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub Pack(ByVal nv As CEOfflineBase.NamedValues)
            nv.Add("TheCode", TheCode, DbType.String)
            nv.Add("Ftype", Ftype, DbType.Int16)
            nv.Add("TheNum", TheNum, DbType.Int32)
            nv.Add(PartName() & "id", ID, DbType.Guid)
        End Sub




        ''' <summary>
        '''Заполнить поля из именованной коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            On Error Resume Next

            RowRetrived = True
            RetriveTime = Now
            If reader.Table.Columns.Contains("TheCode") Then m_TheCode = reader.Item("TheCode").ToString()
            If reader.Table.Columns.Contains("Ftype") Then m_Ftype = reader.Item("Ftype")
            If reader.Table.Columns.Contains("TheNum") Then m_TheNum = reader.Item("TheNum")
        End Sub


        ''' <summary>
        '''Доступ к полю Код типа фильтра
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property TheCode() As String
            Get

                TheCode = m_TheCode
                AccessTime = Now
            End Get
            Set(ByVal Value As String)

                m_TheCode = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Тип фильтра
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property Ftype() As enumFilterType
            Get

                Ftype = m_Ftype
                AccessTime = Now
            End Get
            Set(ByVal Value As enumFilterType)

                m_Ftype = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер фильтра
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property TheNum() As Long
            Get

                TheNum = m_TheNum
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_TheNum = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Заполнить поля данными из XML
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Sub XMLUnpack(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
            Dim e_list As XmlNodeList
            On Error Resume Next
            TheCode = node.Attributes.GetNamedItem("TheCode").Value
            Ftype = node.Attributes.GetNamedItem("Ftype").Value
            TheNum = node.Attributes.GetNamedItem("TheNum").Value
            Changed = True
        End Sub
        Public Overrides Sub Dispose()
        End Sub


        ''' <summary>
        '''Записать данные раздела в XML файл
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
            On Error Resume Next
            node.SetAttribute("TheCode", TheCode)
            node.SetAttribute("Ftype", Ftype)
            node.SetAttribute("TheNum", TheNum)
        End Sub





        ''' <summary>
        '''Количество дочерних разделов
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property



        ''' <summary>
        '''Доступ к дочернему разделу по номеру
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As CEOfflineBase.Document.DocCollection_Base
            Select Case Index
            End Select
            Return Nothing
        End Function
    End Class
End Namespace

