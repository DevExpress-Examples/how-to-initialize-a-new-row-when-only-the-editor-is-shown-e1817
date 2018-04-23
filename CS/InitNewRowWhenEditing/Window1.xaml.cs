using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors;

namespace InitNewRowWhenEditing {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();

            BindingList<TestData> list = new BindingList<TestData>() { AllowNew = true };
            for (int i = 0; i < 0; i++)
                list.Add(new TestData() { Text = "Row" + i, Number = i });
            grid.DataSource = list;
        }
        private void TableView_ShownEditor(object sender, EditorEventArgs e) {
            if (view.FocusedRowHandle == GridControl.NewItemRowHandle) {
                e.Editor.RaiseEvent(new EditValueChangedEventArgs(e.Editor.EditValue, e.Editor.EditValue));
                e.Editor.EditValue = grid.GetCellValue(e.RowHandle, e.Column);
            }
        }

        private void TableView_InitNewRow(object sender, InitNewRowEventArgs e) {
            grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns["Text"], "New Row");
            grid.SetCellValue(GridControl.NewItemRowHandle, grid.Columns["Number"], 999997);
        }
    }
    public class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
    }

}
