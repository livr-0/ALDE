using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class UpdateRecordCommand<T> : CommandBase where T : Record
    {
        private readonly Book<T> _book;
        private readonly Action _updateRecord;

        public UpdateRecordCommand(Book<T> book, Action updateRecord)
        {
            _book = book;
            _updateRecord = updateRecord;
        }

        public override void Execute(object? parameter)
        {
            _updateRecord();
        }
    }
}
