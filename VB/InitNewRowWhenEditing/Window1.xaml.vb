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
Imports DevExpress.Wpf.Grid
Imports DevExpress.Wpf.Editors

Namespace InitNewRowWhenEditing
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Public Partial Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()

            Dim list As BindingList(Of TestData) = New BindingList(Of TestData)() With {.AllowNew = True}
			For i As Integer = 0 To -1
'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
'ORIGINAL LINE: list.Add(New TestData() { Text = "Row" + i, Number = i });
                list.Add(New TestData() With {.Text = "Row" & i, .Number = i})
			Next i
			grid.DataSource = list
		End Sub
		Private Sub TableView_ShownEditor(ByVal sender As Object, ByVal e As EditorEventArgs)
			If view.FocusedRowHandle = GridControl.NewItemRowHandle Then
				e.Editor.RaiseEvent(New RoutedEventArgs(BaseEdit.EditValueChangedEvent))
				e.Editor.EditValue = grid.GetCellValue(e.RowHandle, e.Column)
			End If
		End Sub

		Private Sub TableView_InitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
			grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns("Text"), "New Row")
			grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns("Number"), 999997)
		End Sub
	End Class
    Public Class TestData
        Private _text As String
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property
        Private _number As String
        Public Property Number() As String
            Get
                Return _number
            End Get
            Set(ByVal value As String)
                _number = value
            End Set
        End Property
    End Class
End Namespace


