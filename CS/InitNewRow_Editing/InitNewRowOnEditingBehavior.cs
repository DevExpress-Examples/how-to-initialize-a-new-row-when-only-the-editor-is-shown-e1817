using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System.ComponentModel;

namespace InitNewRow_Editing {
    public class InitNewRowOnEditingBehavior : Behavior<TableView> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.FocusedRowHandleChanged += OnFocusedRowHandleChanged;
            AssociatedObject.AddingNewRow += OnAddingNewRow;
        }
        protected override void OnDetaching() {
            AssociatedObject.FocusedRowHandleChanged -= OnFocusedRowHandleChanged;
            AssociatedObject.AddingNewRow -= OnAddingNewRow;
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

        void OnAddingNewRow(object sender, AddingNewEventArgs e) {
            e.NewObject = new DataItem() {
                Text = "New Row",
                Number = 999997
            };
        }
    }
}
