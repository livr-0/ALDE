using MemberManagementSystem.Model;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Stores
{
    internal class RecordViewModelStore
    {
        private ObservableCollection<ViewModelBase> _recordsToDisplay;
        private ObservableCollection<Record> _records;

        public IEnumerable<ViewModelBase> RecordsToDisplay => _recordsToDisplay;
        public IEnumerable<Record> Records => _records;

        public RecordViewModelStore()
        {
            _recordsToDisplay = new ObservableCollection<ViewModelBase>();
            _records = new ObservableCollection<Record>();
        }

        public void AddRecordViewModel(ViewModelBase r)
        {
            _recordsToDisplay.Add(r);
        }

        public void ClearRecords()
        {
            _recordsToDisplay.Clear();
        }

        public void AddRecord(Record r)
        {
            _records.Add(r);
        }
    }
}
