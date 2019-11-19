
Option Explicit On

Imports System
Imports System.IO
Imports CEOfflineBase
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace FRDLT


    ''' <summary>
    '''Реализация строки раздела Справочник типов лотков
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDLT_INFO
        Inherits CEOfflineBase.Document.DocRow_Base



        ''' <summary>
        '''Локальная переменная для поля Бумажный лоток
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_IsPaper As enumBoolean


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack4)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber4 As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack1)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber1 As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack0)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber As Double


        ''' <summary>
        '''Локальная переменная для поля Номер на метке
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_LabelNumber As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack7)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber7 As Long


        ''' <summary>
        '''Локальная переменная для поля Название
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_TheName As String


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack3)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber3 As Long


        ''' <summary>
        '''Локальная переменная для поля Код
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_TheCode As String


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack6)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber6 As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack9)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber9 As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack8)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber8 As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack5)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber5 As Long


        ''' <summary>
        '''Локальная переменная для поля Номер следующего лотка (pack2)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_NxtNumber2 As Long



        ''' <summary>
        '''Очистить поля раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_IsPaper=   
            ' m_NxtNumber4=   
            ' m_NxtNumber1=   
            ' m_NxtNumber=   
            ' m_LabelNumber=   
            ' m_NxtNumber7=   
            ' m_TheName=   
            ' m_NxtNumber3=   
            ' m_TheCode=   
            ' m_NxtNumber6=   
            ' m_NxtNumber9=   
            ' m_NxtNumber8=   
            ' m_NxtNumber5=   
            ' m_NxtNumber2=   
        End Sub



        ''' <summary>
        '''Количество полей в строке раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides ReadOnly Property Count() As Long
            Get
                Count = 14
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
                            Value = TheName
                        Case 3
                            Value = IsPaper
                        Case 4
                            Value = LabelNumber
                        Case 5
                            Value = NxtNumber
                        Case 6
                            Value = NxtNumber1
                        Case 7
                            Value = NxtNumber2
                        Case 8
                            Value = NxtNumber3
                        Case 9
                            Value = NxtNumber4
                        Case 10
                            Value = NxtNumber5
                        Case 11
                            Value = NxtNumber6
                        Case 12
                            Value = NxtNumber7
                        Case 13
                            Value = NxtNumber8
                        Case 14
                            Value = NxtNumber9
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
                            TheName = value
                        Case 3
                            IsPaper = value
                        Case 4
                            LabelNumber = value
                        Case 5
                            NxtNumber = value
                        Case 6
                            NxtNumber1 = value
                        Case 7
                            NxtNumber2 = value
                        Case 8
                            NxtNumber3 = value
                        Case 9
                            NxtNumber4 = value
                        Case 10
                            NxtNumber5 = value
                        Case 11
                            NxtNumber6 = value
                        Case 12
                            NxtNumber7 = value
                        Case 13
                            NxtNumber8 = value
                        Case 14
                            NxtNumber9 = value
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
                        Return "TheName"
                    Case 3
                        Return "IsPaper"
                    Case 4
                        Return "LabelNumber"
                    Case 5
                        Return "NxtNumber"
                    Case 6
                        Return "NxtNumber1"
                    Case 7
                        Return "NxtNumber2"
                    Case 8
                        Return "NxtNumber3"
                    Case 9
                        Return "NxtNumber4"
                    Case 10
                        Return "NxtNumber5"
                    Case 11
                        Return "NxtNumber6"
                    Case 12
                        Return "NxtNumber7"
                    Case 13
                        Return "NxtNumber8"
                    Case 14
                        Return "NxtNumber9"
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
            dr = destdatatable.NewRow
            On Error Resume Next
            dr("ID") = ID
            dr("Brief") = TheCode + " " + TheName
            dr("TheCode") = TheCode
            dr("TheName") = TheName
            Select Case IsPaper
                Case enumBoolean.Boolean_Da
                    dr("IsPaper") = "Да"
                    dr("IsPaper_VAL") = -1
                Case enumBoolean.Boolean_Net
                    dr("IsPaper") = "Нет"
                    dr("IsPaper_VAL") = 0
            End Select 'IsPaper
            dr("LabelNumber") = LabelNumber
            dr("NxtNumber") = NxtNumber
            dr("NxtNumber1") = NxtNumber1
            dr("NxtNumber2") = NxtNumber2
            dr("NxtNumber3") = NxtNumber3
            dr("NxtNumber4") = NxtNumber4
            dr("NxtNumber5") = NxtNumber5
            dr("NxtNumber6") = NxtNumber6
            dr("NxtNumber7") = NxtNumber7
            dr("NxtNumber8") = NxtNumber8
            dr("NxtNumber9") = NxtNumber9
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
            nv.Add("TheCode", TheCode, dbtype.string)
            nv.Add("TheName", TheName, dbtype.string)
            nv.Add("IsPaper", IsPaper, dbtype.int16)
            nv.Add("LabelNumber", LabelNumber, dbtype.Int32)
            nv.Add("NxtNumber", NxtNumber, dbtype.double)
            nv.Add("NxtNumber1", NxtNumber1, dbtype.Int32)
            nv.Add("NxtNumber2", NxtNumber2, dbtype.Int32)
            nv.Add("NxtNumber3", NxtNumber3, dbtype.Int32)
            nv.Add("NxtNumber4", NxtNumber4, dbtype.Int32)
            nv.Add("NxtNumber5", NxtNumber5, dbtype.Int32)
            nv.Add("NxtNumber6", NxtNumber6, dbtype.Int32)
            nv.Add("NxtNumber7", NxtNumber7, dbtype.Int32)
            nv.Add("NxtNumber8", NxtNumber8, dbtype.Int32)
            nv.Add("NxtNumber9", NxtNumber9, dbtype.Int32)
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
            If reader.Table.Columns.Contains("TheCode") Then m_TheCode = reader.item("TheCode").ToString()
            If reader.Table.Columns.Contains("TheName") Then m_TheName = reader.item("TheName").ToString()
            If reader.Table.Columns.Contains("IsPaper") Then m_IsPaper = reader.item("IsPaper")
            If reader.Table.Columns.Contains("LabelNumber") Then m_LabelNumber = reader.item("LabelNumber")
            If reader.Table.Columns.Contains("NxtNumber") Then m_NxtNumber = reader.item("NxtNumber")
            If reader.Table.Columns.Contains("NxtNumber1") Then m_NxtNumber1 = reader.item("NxtNumber1")
            If reader.Table.Columns.Contains("NxtNumber2") Then m_NxtNumber2 = reader.item("NxtNumber2")
            If reader.Table.Columns.Contains("NxtNumber3") Then m_NxtNumber3 = reader.item("NxtNumber3")
            If reader.Table.Columns.Contains("NxtNumber4") Then m_NxtNumber4 = reader.item("NxtNumber4")
            If reader.Table.Columns.Contains("NxtNumber5") Then m_NxtNumber5 = reader.item("NxtNumber5")
            If reader.Table.Columns.Contains("NxtNumber6") Then m_NxtNumber6 = reader.item("NxtNumber6")
            If reader.Table.Columns.Contains("NxtNumber7") Then m_NxtNumber7 = reader.item("NxtNumber7")
            If reader.Table.Columns.Contains("NxtNumber8") Then m_NxtNumber8 = reader.item("NxtNumber8")
            If reader.Table.Columns.Contains("NxtNumber9") Then m_NxtNumber9 = reader.item("NxtNumber9")
        End Sub


        ''' <summary>
        '''Доступ к полю Код
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
        '''Доступ к полю Название
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property TheName() As String
            Get

                TheName = m_TheName
                AccessTime = Now
            End Get
            Set(ByVal Value As String)

                m_TheName = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Бумажный лоток
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property IsPaper() As enumBoolean
            Get

                IsPaper = m_IsPaper
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean)

                m_IsPaper = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер на метке
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property LabelNumber() As Long
            Get

                LabelNumber = m_LabelNumber
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_LabelNumber = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack0)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber() As Double
            Get

                NxtNumber = m_NxtNumber
                AccessTime = Now
            End Get
            Set(ByVal Value As Double)

                m_NxtNumber = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack1)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber1() As Long
            Get

                NxtNumber1 = m_NxtNumber1
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber1 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack2)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber2() As Long
            Get

                NxtNumber2 = m_NxtNumber2
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber2 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack3)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber3() As Long
            Get

                NxtNumber3 = m_NxtNumber3
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber3 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack4)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber4() As Long
            Get

                NxtNumber4 = m_NxtNumber4
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber4 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack5)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber5() As Long
            Get

                NxtNumber5 = m_NxtNumber5
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber5 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack6)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber6() As Long
            Get

                NxtNumber6 = m_NxtNumber6
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber6 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack7)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber7() As Long
            Get

                NxtNumber7 = m_NxtNumber7
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber7 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack8)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber8() As Long
            Get

                NxtNumber8 = m_NxtNumber8
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber8 = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Номер следующего лотка (pack9)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property NxtNumber9() As Long
            Get

                NxtNumber9 = m_NxtNumber9
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_NxtNumber9 = Value
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
            TheName = node.Attributes.GetNamedItem("TheName").Value
            IsPaper = node.Attributes.GetNamedItem("IsPaper").Value
            LabelNumber = node.Attributes.GetNamedItem("LabelNumber").Value
            NxtNumber = node.Attributes.GetNamedItem("NxtNumber").Value
            NxtNumber1 = node.Attributes.GetNamedItem("NxtNumber1").Value
            NxtNumber2 = node.Attributes.GetNamedItem("NxtNumber2").Value
            NxtNumber3 = node.Attributes.GetNamedItem("NxtNumber3").Value
            NxtNumber4 = node.Attributes.GetNamedItem("NxtNumber4").Value
            NxtNumber5 = node.Attributes.GetNamedItem("NxtNumber5").Value
            NxtNumber6 = node.Attributes.GetNamedItem("NxtNumber6").Value
            NxtNumber7 = node.Attributes.GetNamedItem("NxtNumber7").Value
            NxtNumber8 = node.Attributes.GetNamedItem("NxtNumber8").Value
            NxtNumber9 = node.Attributes.GetNamedItem("NxtNumber9").Value
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
            node.SetAttribute("TheName", TheName)
            node.SetAttribute("IsPaper", IsPaper)
            node.SetAttribute("LabelNumber", LabelNumber)
            node.SetAttribute("NxtNumber", NxtNumber)
            node.SetAttribute("NxtNumber1", NxtNumber1)
            node.SetAttribute("NxtNumber2", NxtNumber2)
            node.SetAttribute("NxtNumber3", NxtNumber3)
            node.SetAttribute("NxtNumber4", NxtNumber4)
            node.SetAttribute("NxtNumber5", NxtNumber5)
            node.SetAttribute("NxtNumber6", NxtNumber6)
            node.SetAttribute("NxtNumber7", NxtNumber7)
            node.SetAttribute("NxtNumber8", NxtNumber8)
            node.SetAttribute("NxtNumber9", NxtNumber9)
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

