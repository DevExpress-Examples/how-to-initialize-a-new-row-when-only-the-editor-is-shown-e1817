Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.ComponentModel

Namespace InitNewRow_Editing

    Public Class InitNewRowOnEditingBehavior
        Inherits Behavior(Of TableView)

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AddHandler AssociatedObject.FocusedRowHandleChanged, AddressOf OnFocusedRowHandleChanged
            AddHandler AssociatedObject.AddingNewRow, AddressOf OnAddingNewRow
        End Sub

        Protected Overrides Sub OnDetaching()
            RemoveHandler AssociatedObject.FocusedRowHandleChanged, AddressOf OnFocusedRowHandleChanged
            RemoveHandler AssociatedObject.AddingNewRow, AddressOf OnAddingNewRow
            MyBase.OnDetaching()
        End Sub

        Private isLocked As Boolean

        Private Sub OnFocusedRowHandleChanged(ByVal sender As Object, ByVal e As FocusedRowHandleChangedEventArgs)
            If Not isLocked AndAlso AssociatedObject.FocusedRowHandle = DataControlBase.NewItemRowHandle Then
                isLocked = True
                AssociatedObject.AddNewRow()
                isLocked = False
            End If
        End Sub

        Private Sub OnAddingNewRow(ByVal sender As Object, ByVal e As AddingNewEventArgs)
            e.NewObject = New DataItem() With {.Text = "New Row", .Number = 999997}
        End Sub
    End Class
End Namespace
