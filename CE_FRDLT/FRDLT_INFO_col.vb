
Option Explicit On

Imports CEOfflineBase
Imports System
Imports System.xml
Imports System.Data

Namespace FRDLT


    ''' <summary>
    '''Реализация раздела Справочник типов лотковв виде коллекции
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDLT_INFO_col
        Inherits CEOfflineBase.Document.DocCollection_Base



        ''' <summary>
        '''Имя раздела в базе данных
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FRDLT_INFO"
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
            dt.Columns.Add("TheName", GetType(System.string))
            dt.Columns.Add("IsPaper_VAL", GetType(System.Int16))
            dt.Columns.Add("IsPaper", GetType(System.string))
            dt.Columns.Add("LabelNumber", GetType(System.Int32))
            dt.Columns.Add("NxtNumber", GetType(System.double))
            dt.Columns.Add("NxtNumber1", GetType(System.Int32))
            dt.Columns.Add("NxtNumber2", GetType(System.Int32))
            dt.Columns.Add("NxtNumber3", GetType(System.Int32))
            dt.Columns.Add("NxtNumber4", GetType(System.Int32))
            dt.Columns.Add("NxtNumber5", GetType(System.Int32))
            dt.Columns.Add("NxtNumber6", GetType(System.Int32))
            dt.Columns.Add("NxtNumber7", GetType(System.Int32))
            dt.Columns.Add("NxtNumber8", GetType(System.Int32))
            dt.Columns.Add("NxtNumber9", GetType(System.Int32))
            Return dt
        End Function



        ''' <summary>
        '''Создание нового элемента коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Function NewItem() As CEOfflineBase.Document.DocRow_Base
            NewItem = New FRDLT_INFO
        End Function


        ''' <summary>
        '''Получить элемент коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Function GetItem(ByVal vIndex As Object) As FRDLT.FRDLT_INFO
            On Error Resume Next
            GetItem = CType(MyBase.Item(vIndex), FRDLT.FRDLT_INFO)
        End Function


        ''' <summary>
        '''Получить элемент коллекции, более свежий вариант
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Shadows Function Item(ByVal vIndex As Object) As FRDLT.FRDLT_INFO
            On Error Resume Next
            Return GetItem(vIndex)
        End Function

    End Class
End Namespace

