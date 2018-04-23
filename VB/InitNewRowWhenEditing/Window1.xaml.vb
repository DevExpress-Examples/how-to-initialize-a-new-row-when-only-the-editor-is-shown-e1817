Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.ComponentModel
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Editors

Namespace InitNewRowWhenEditing
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()

            Dim list As New BindingList(Of TestData)() With {.AllowNew = True}
            For i As Integer = 0 To -1
                list.Add(New TestData() With { _
                    .Text = "Row" & i, _
                    .Number = i _
                })
            Next i
            grid.ItemsSource = list
        End Sub

        Private Sub TableView_InitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
            grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns("Text"), "New Row")
            grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns("Number"), 999997)
        End Sub

        Private isLocked As Boolean
        Private Sub TableView_FocusedRowHandleChanged(ByVal sender As Object, ByVal e As FocusedRowHandleChangedEventArgs)
            If Not isLocked AndAlso view.FocusedRowHandle = GridControl.NewItemRowHandle Then
                isLocked = True
                view.AddNewRow()
                isLocked = False
            End If
        End Sub
    End Class

    Public Class TestData
        Public Property Text() As String
        Public Property Number() As Integer
    End Class
End Namespace