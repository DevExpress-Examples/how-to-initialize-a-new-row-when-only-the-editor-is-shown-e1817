using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace InitNewRow_Editing {
    public class DataItem {
        public string Text { get; set; }
        public int Number { get; set; }
    }
    public class MainViewModel : ViewModelBase {
        public BindingList<DataItem> Items { get; }
        public MainViewModel() {
            Items = new BindingList<DataItem>(GetItems().ToList()) { AllowNew = true };
        }
        static IEnumerable<DataItem> GetItems() {
            return Enumerable.Range(0, 10).Select(i => new DataItem() { Text = "Row" + i, Number = i });
        }
    }
}
