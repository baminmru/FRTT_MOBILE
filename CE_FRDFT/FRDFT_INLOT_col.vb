
Option Explicit On

Imports CEOfflineBase
Imports System
Imports System.xml
Imports System.Data

Namespace FRDFT


    ''' <summary>
    '''Реализация раздела Вместимость в лоткив виде коллекции
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class FRDFT_INLOT_col
        Inherits CEOfflineBase.Document.DocCollection_Base



        ''' <summary>
        '''Имя раздела в базе данных
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FRDFT_INLOT"
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
            dt.Columns.Add("TheLT_ID", GetType(System.guid))
            dt.Columns.Add("TheLT", GetType(System.string))
            dt.Columns.Add("FQuantoty", GetType(System.Int32))
            Return dt
        End Function



        ''' <summary>
        '''Создание нового элемента коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Protected Overrides Function NewItem() As CEOfflineBase.Document.DocRow_Base
            NewItem = New FRDFT_INLOT
        End Function


        ''' <summary>
        '''Получить элемент коллекции
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Function GetItem(ByVal vIndex As Object) As FRDFT.FRDFT_INLOT
            On Error Resume Next
            GetItem = CType(MyBase.Item(vIndex), FRDFT.FRDFT_INLOT)
        End Function


        ''' <summary>
        '''Получить элемент коллекции, более свежий вариант
        ''' </summary>
        ''' <remarks>
        '''
        ''' </remarks>
        Public Shadows Function Item(ByVal vIndex As Object) As FRDFT.FRDFT_INLOT
            On Error Resume Next
            Return GetItem(vIndex)
        End Function

    End Class
End Namespace

