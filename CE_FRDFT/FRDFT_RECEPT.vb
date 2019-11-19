
Option Explicit On

Imports System
Imports System.IO
Imports CEOfflineBase
Imports System.Xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace FRDFT


    ''' <summary>
    '''Реализация строки раздела Рецептура
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDFT_RECEPT
        Inherits CEOfflineBase.Document.DocRow_Base



        ''' <summary>
        '''Локальная переменная для поля Название машины (LESMES)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_PODAlias As String


        ''' <summary>
        '''Локальная переменная для поля Черный фильтр
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_BlackFilter As System.Guid


        ''' <summary>
        '''Локальная переменная для поля Белый фильтр
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_WiteFilter As System.Guid



        ''' <summary>
        '''Очистить поля раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_PODAlias=   
            ' m_BlackFilter=   
            ' m_WiteFilter=   
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
                            Value = PODAlias
                        Case 2
                            Value = WiteFilter
                        Case 3
                            Value = BlackFilter
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
                            PODAlias = value
                        Case 2
                            WiteFilter = value
                        Case 3
                            BlackFilter = value
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
                        Return "PODAlias"
                    Case 2
                        Return "WiteFilter"
                    Case 3
                        Return "BlackFilter"
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
            dr("Brief") = Brief
            dr("PODAlias") = PODAlias
            If WiteFilter Is Nothing Then
                dr("WiteFilter") = System.DBNull.Value
                dr("WiteFilter_ID") = System.Guid.Empty
            Else
                dr("WiteFilter") = WiteFilter.BRIEF
                dr("WiteFilter_ID") = WiteFilter.ID
            End If
            If BlackFilter Is Nothing Then
                dr("BlackFilter") = System.DBNull.Value
                dr("BlackFilter_ID") = System.Guid.Empty
            Else
                dr("BlackFilter") = BlackFilter.BRIEF
                dr("BlackFilter_ID") = BlackFilter.ID
            End If
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
            nv.Add("PODAlias", PODAlias, DbType.String)
            If m_WiteFilter.Equals(System.Guid.Empty) Then
                nv.Add("WiteFilter", System.DBNull.Value, DbType.Guid)
            Else
                nv.Add("WiteFilter", m_WiteFilter, DbType.Guid)
            End If
            If m_BlackFilter.Equals(System.Guid.Empty) Then
                nv.Add("BlackFilter", System.DBNull.Value, DbType.Guid)
            Else
                nv.Add("BlackFilter", m_BlackFilter, DbType.Guid)
            End If
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
            If reader.Table.Columns.Contains("PODAlias") Then m_PODAlias = reader.Item("PODAlias").ToString()
            If reader.Table.Columns.Contains("WiteFilter") Then
                If IsDBNull(reader.Item("WiteFilter")) Then
                    If reader.Table.Columns.Contains("WiteFilter") Then m_WiteFilter = System.Guid.Empty
                Else
                    If reader.Table.Columns.Contains("WiteFilter") Then m_WiteFilter = New System.Guid(reader.Item("WiteFilter").ToString())
                End If
            End If
            If reader.Table.Columns.Contains("BlackFilter") Then
                If IsDBNull(reader.Item("BlackFilter")) Then
                    If reader.Table.Columns.Contains("BlackFilter") Then m_BlackFilter = System.Guid.Empty
                Else
                    If reader.Table.Columns.Contains("BlackFilter") Then m_BlackFilter = New System.Guid(reader.Item("BlackFilter").ToString())
                End If
            End If
        End Sub


        ''' <summary>
        '''Доступ к полю Название машины (LESMES)
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property PODAlias() As String
            Get

                PODAlias = m_PODAlias
                AccessTime = Now
            End Get
            Set(ByVal Value As String)

                m_PODAlias = Value
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Белый фильтр
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property WiteFilter() As CEOfflineBase.Document.DocRow_Base
            Get

                WiteFilter = Me.Application.FindRowObject("FRDFT_INFO", m_WiteFilter, "FRDFT")
                AccessTime = Now
            End Get
            Set(ByVal Value As CEOfflineBase.Document.DocRow_Base)

                If Not Value Is Nothing Then
                    m_WiteFilter = Value.id
                Else
                    m_WiteFilter = System.Guid.Empty
                End If
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Черный фильтр
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property BlackFilter() As CEOfflineBase.Document.DocRow_Base
            Get

                BlackFilter = Me.Application.FindRowObject("FRDFT_INFO", m_BlackFilter, "FRDFT")
                AccessTime = Now
            End Get
            Set(ByVal Value As CEOfflineBase.Document.DocRow_Base)

                If Not Value Is Nothing Then
                    m_BlackFilter = Value.id
                Else
                    m_BlackFilter = System.Guid.Empty
                End If
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
            PODAlias = node.Attributes.GetNamedItem("PODAlias").Value
            m_WiteFilter = New System.Guid(node.Attributes.GetNamedItem("WiteFilter").Value)
            m_BlackFilter = New System.Guid(node.Attributes.GetNamedItem("BlackFilter").Value)
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
            node.SetAttribute("PODAlias", PODAlias)
            node.SetAttribute("WiteFilter", m_WiteFilter.ToString)
            node.SetAttribute("BlackFilter", m_BlackFilter.ToString)
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

