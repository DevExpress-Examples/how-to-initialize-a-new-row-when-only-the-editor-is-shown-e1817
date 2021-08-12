using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System;
using System.Linq;

namespace InitNewRow_Editing {
    public class InitNewRowOnEditingBehavior : Behavior<TableView> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.FocusedRowHandleChanged += OnFocusedRowHandleChanged;
            AssociatedObject.InitNewRow += OnInitNewRow;
        }
        protected override void OnDetaching() {
            AssociatedObject.FocusedRowHandleChanged += OnFocusedRowHandleChanged;
            AssociatedObject.InitNewRow += OnInitNewRow;
            base.OnDetaching();
        }

        bool isLocked;
        void OnFocusedRowHandleChanged(object sender, FocusedRowHandleChangedEventArgs e) {
            if(!isLocked && AssociatedObject.FocusedRowHandle == GridControl.NewItemRowHandle) {
                isLocked = true;
                AssociatedObject.AddNewRow();
                isLocked = false;
            }
        }

        void OnInitNewRow(object sender, InitNewRowEventArgs e) {
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns["Text"], "New Row");
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns["Number"], 999997);
        }
    }
}
