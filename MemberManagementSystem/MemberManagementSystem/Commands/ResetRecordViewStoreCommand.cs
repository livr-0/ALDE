using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class ResetRecordViewStoreCommand<T> : CommandBase where T : Record
    {
        RecordViewModelStore _recordStore;
        Book<T> _recordBook;
        RecordViewModelFactory _facotry;

        public ResetRecordViewStoreCommand(RecordViewModelStore recordStore, Book<T> recordBook, RecordViewModelFactory facotry)
        {
            _recordStore = recordStore;
            _recordBook = recordBook;
            _facotry = facotry;
        }

        public override void Execute(object? parameter)
        {
                _recordStore.ClearRecords();
                IEnumerable<T> sales = _recordBook.Records;
                foreach (T s in sales)
                {
                    _recordStore.AddRecordViewModel(_facotry.CreateRecordViewModel(s));
                }
        }
    }
}
