Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Linq

Namespace InitNewRow_Editing
	Public Class InitNewRowOnEditingBehavior
		Inherits Behavior(Of TableView)

		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			AddHandler AssociatedObject.FocusedRowHandleChanged, AddressOf OnFocusedRowHandleChanged
			AddHandler AssociatedObject.InitNewRow, AddressOf OnInitNewRow
		End Sub
		Protected Overrides Sub OnDetaching()
			AddHandler AssociatedObject.FocusedRowHandleChanged, AddressOf OnFocusedRowHandleChanged
			AddHandler AssociatedObject.InitNewRow, AddressOf OnInitNewRow
			MyBase.OnDetaching()
		End Sub

		Private isLocked As Boolean
		Private Sub OnFocusedRowHandleChanged(ByVal sender As Object, ByVal e As FocusedRowHandleChangedEventArgs)
			If Not isLocked AndAlso AssociatedObject.FocusedRowHandle = GridControl.NewItemRowHandle Then
				isLocked = True
				AssociatedObject.AddNewRow()
				isLocked = False
			End If
		End Sub

		Private Sub OnInitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
			AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns("Text"), "New Row")
			AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns("Number"), 999997)
		End Sub
	End Class
End Namespace
