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

        public IEnumerable<ViewModelBase> RecordsToDisplay => _recordsToDisplay;

        public RecordViewModelStore()
        {
            _recordsToDisplay = new ObservableCollection<ViewModelBase>();
        }

        public void AddRecordViewModel(ViewModelBase r)
        {
            _recordsToDisplay.Add(r);
        }

        public void ClearRecords()
        {
            _recordsToDisplay.Clear();
        }
    }
}
