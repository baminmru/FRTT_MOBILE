
Option Explicit On

Imports CEOfflineBase
Imports System
Imports System.xml
Imports System.Data

Namespace FRDFT


    ''' <summary>
    '''Реализация раздела Тип фильтрав виде коллекции
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDFT_INFO_col
        Inherits CEOfflineBase.Document.DocCollection_Base



        ''' <summary>
        '''Имя раздела в базе данных
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FRDFT_INFO"
        End Function



        ''' <summary>
        '''Вернуть даные текущей коллекции в виде DataTable
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Function CreateDataTable() As System.Data.DataTable
            Dim dt As DataTable
            dt = New DataTable
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", GetType(System.string))
            dt.Columns.Add("TheCode", GetType(System.string))
            dt.Columns.Add("Ftype_VAL", GetType(System.Int16))
            dt.Columns.Add("Ftype", GetType(System.string))
            dt.Columns.Add("TheNum", GetType(System.Int32))
            Return dt
        End Function



        ''' <summary>
        '''Создание нового элемента коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Function NewItem() As CEOfflineBase.Document.DocRow_Base
            NewItem = New FRDFT_INFO
        End Function


        ''' <summary>
        '''Получить элемент коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Function GetItem(ByVal vIndex As Object) As FRDFT.FRDFT_INFO
            On Error Resume Next
            GetItem = CType(MyBase.Item(vIndex), FRDFT.FRDFT_INFO)
        End Function


        ''' <summary>
        '''Получить элемент коллекции, более свежий вариант
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Shadows Function Item(ByVal vIndex As Object) As FRDFT.FRDFT_INFO
            On Error Resume Next
            Return GetItem(vIndex)
        End Function

    End Class
End Namespace

