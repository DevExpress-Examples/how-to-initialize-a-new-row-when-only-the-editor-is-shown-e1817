Imports System.Windows
Imports System.Windows.Controls
Imports System.ComponentModel
Imports DevExpress.Xpf.Grid

Namespace InitNewRowWhenEditing

    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim list As BindingList(Of TestData) = New BindingList(Of TestData)() With {.AllowNew = True}
            For i As Integer = 0 To 0 - 1
                list.Add(New TestData() With {.Text = "Row" & i, .Number = i})
            Next

            Me.grid.ItemsSource = list
        End Sub

        Private Sub TableView_InitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
            Me.grid.SetCellValue(DataControlBase.NewItemRowHandle, Me.grid.Columns("Text"), "New Row")
            Me.grid.SetCellValue(DataControlBase.NewItemRowHandle, Me.grid.Columns("Number"), 999997)
        End Sub

        Private isLocked As Boolean

        Private Sub TableView_FocusedRowHandleChanged(ByVal sender As Object, ByVal e As FocusedRowHandleChangedEventArgs)
            If Not isLocked AndAlso Me.view.FocusedRowHandle = DataControlBase.NewItemRowHandle Then
                isLocked = True
                Me.view.AddNewRow()
                isLocked = False
            End If
        End Sub
    End Class

    Public Class TestData

        Public Property Text As String

        Public Property Number As Integer
    End Class
End Namespace
