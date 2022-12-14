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
            IEnumerable<T> records = _recordBook.Records;

            foreach (T record in records)
            {
                bool active = true;

                if (record.GetType() == typeof(Product))
                {
                    active = (record as Product).ActiveStatus;
                }
                else if (record.GetType() == typeof(Member))
                {
                    active = (record as Member).ActiveStatus;
                }
                else if (record.GetType() == typeof(User))
                {
                    active = (record as User).ActiveStatus;
                }

                if (active)
                {
                    _recordStore.AddRecordViewModel(_facotry.CreateRecordViewModel(record));
                }
            }
        }
    }
}
