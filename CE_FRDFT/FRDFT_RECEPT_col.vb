
Option Explicit On

Imports CEOfflineBase
Imports System
Imports System.xml
Imports System.Data

Namespace FRDFT


    ''' <summary>
    '''Реализация раздела Рецептурав виде коллекции
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDFT_RECEPT_col
        Inherits CEOfflineBase.Document.DocCollection_Base



        ''' <summary>
        '''Имя раздела в базе данных
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FRDFT_RECEPT"
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
            dt.Columns.Add("PODAlias", GetType(System.string))
            dt.Columns.Add("WiteFilter_ID", GetType(System.guid))
            dt.Columns.Add("WiteFilter", GetType(System.string))
            dt.Columns.Add("BlackFilter_ID", GetType(System.guid))
            dt.Columns.Add("BlackFilter", GetType(System.string))
            Return dt
        End Function



        ''' <summary>
        '''Создание нового элемента коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Function NewItem() As CEOfflineBase.Document.DocRow_Base
            NewItem = New FRDFT_RECEPT
        End Function


        ''' <summary>
        '''Получить элемент коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Function GetItem(ByVal vIndex As Object) As FRDFT.FRDFT_RECEPT
            On Error Resume Next
            GetItem = CType(MyBase.Item(vIndex), FRDFT.FRDFT_RECEPT)
        End Function


        ''' <summary>
        '''Получить элемент коллекции, более свежий вариант
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Shadows Function Item(ByVal vIndex As Object) As FRDFT.FRDFT_RECEPT
            On Error Resume Next
            Return GetItem(vIndex)
        End Function

    End Class
End Namespace

