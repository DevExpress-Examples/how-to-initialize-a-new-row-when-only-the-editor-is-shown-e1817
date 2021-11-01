Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq

Namespace InitNewRow_Editing

    Public Class DataItem

        Public Property Text As String

        Public Property Number As Integer
    End Class

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Items As BindingList(Of DataItem)

        Public Sub New()
            Items = New BindingList(Of DataItem)(GetItems().ToList()) With {.AllowNew = True}
        End Sub

        Private Shared Function GetItems() As IEnumerable(Of DataItem)
            Return Enumerable.Range(0, 10).[Select](Function(i) New DataItem() With {.Text = "Row" & i, .Number = i})
        End Function
    End Class
End Namespace
