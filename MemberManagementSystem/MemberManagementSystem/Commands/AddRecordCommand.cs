using MemberManagementSystem.Model;
using MemberManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class AddRecordCommand<T> : CommandBase where T : Record
    {
        private readonly Book<T> _book;
        private readonly Func<T> _creatRecord;

        public AddRecordCommand(Book<T> book, Func<T> creatRecord)
        {
            _book = book;
            _creatRecord = creatRecord;
        }

        public override void Execute(object? parameter)
        {
            T record = _creatRecord();
            if (record != null)
            {
                _book.AddRecord(record);
            }
        }
    }
}
