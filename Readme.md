<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1817)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/InitNewRowWhenEditing/Window1.xaml) (VB: [Window1.xaml](./VB/InitNewRowWhenEditing/Window1.xaml))
* [Window1.xaml.cs](./CS/InitNewRowWhenEditing/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/InitNewRowWhenEditing/Window1.xaml.vb))
<!-- default file list end -->
# How to initialize a new row when only the editor is shown 


<p>Subscribe to the <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.FocusedRowHandleChanged.event">TableView.FocusedRowHandleChanged</a> event, and call the <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.AddNewRow.method">TableView.AddNewRow</a> method in this event handler.</p>

<br/>


