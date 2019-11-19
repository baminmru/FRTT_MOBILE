
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
    '''Реализация строки раздела Вместимость в лотки
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDFT_INLOT
        Inherits CEOfflineBase.Document.DocRow_Base



        ''' <summary>
        '''Локальная переменная для поля Количество фильтров
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_FQuantoty As Long


        ''' <summary>
        '''Локальная переменная для поля Тип лотка
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Private m_TheLT As System.Guid



        ''' <summary>
        '''Очистить поля раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_FQuantoty=   
            ' m_TheLT=   
        End Sub



        ''' <summary>
        '''Количество полей в строке раздела
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides ReadOnly Property Count() As Long
            Get
                Count = 2
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
                            Value = TheLT
                        Case 2
                            Value = FQuantoty
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
                            TheLT = value
                        Case 2
                            FQuantoty = value
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
                        Return "TheLT"
                    Case 2
                        Return "FQuantoty"
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
            dr("Brief") = Brief
            If TheLT Is Nothing Then
                dr("TheLT") = system.dbnull.value
                dr("TheLT_ID") = System.Guid.Empty
            Else
                dr("TheLT") = TheLT.BRIEF
                dr("TheLT_ID") = TheLT.ID
            End If
            dr("FQuantoty") = FQuantoty
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
            If m_TheLT.Equals(System.Guid.Empty) Then
                nv.Add("TheLT", system.dbnull.value, dbtype.guid)
            Else
                nv.Add("TheLT", m_TheLT, dbtype.guid)
            End If
            nv.Add("FQuantoty", FQuantoty, dbtype.Int32)
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
            If reader.Table.Columns.Contains("TheLT") Then
                If isdbnull(reader.item("TheLT")) Then
                    If reader.Table.Columns.Contains("TheLT") Then m_TheLT = System.GUID.Empty
                Else
                    If reader.Table.Columns.Contains("TheLT") Then m_TheLT = New System.Guid(reader.item("TheLT").ToString())
                End If
            End If
            If reader.Table.Columns.Contains("FQuantoty") Then m_FQuantoty = reader.item("FQuantoty")
        End Sub


        ''' <summary>
        '''Доступ к полю Тип лотка
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property TheLT() As CEOfflineBase.Document.docrow_base
            Get

                TheLT = Me.Application.FindRowObject("FRDLT_INFO", m_TheLT, "FRDFT")
                AccessTime = Now
            End Get
            Set(ByVal Value As CEOfflineBase.Document.docrow_base)

                If Not Value Is Nothing Then
                    m_TheLT = Value.id
                Else
                    m_TheLT = System.Guid.Empty
                End If
                ChangeTime = Now
            End Set
        End Property


        ''' <summary>
        '''Доступ к полю Количество фильтров
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Property FQuantoty() As Long
            Get

                FQuantoty = m_FQuantoty
                AccessTime = Now
            End Get
            Set(ByVal Value As Long)

                m_FQuantoty = Value
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
            m_TheLT = New system.guid(node.Attributes.GetNamedItem("TheLT").Value)
            FQuantoty = node.Attributes.GetNamedItem("FQuantoty").Value
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
            node.SetAttribute("TheLT", m_TheLT.tostring)
            node.SetAttribute("FQuantoty", FQuantoty)
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

