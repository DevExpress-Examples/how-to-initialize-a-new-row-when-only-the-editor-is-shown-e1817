Imports Microsoft.VisualBasic
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
				list.Add(New TestData() With {.Text = "Row" & i, .Number = i})
			Next i
			grid.DataSource = list
		End Sub
		Private Sub TableView_ShownEditor(ByVal sender As Object, ByVal e As EditorEventArgs)
			If view.FocusedRowHandle = GridControl.NewItemRowHandle Then
				e.Editor.RaiseEvent(New EditValueChangedEventArgs(e.Editor.EditValue, e.Editor.EditValue))
				e.Editor.EditValue = grid.GetCellValue(e.RowHandle, e.Column)
			End If
		End Sub

		Private Sub TableView_InitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
			grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns("Text"), "New Row")
			grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns("Number"), 999997)
		End Sub
	End Class
	Public Class TestData
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
	End Class

End Namespace
