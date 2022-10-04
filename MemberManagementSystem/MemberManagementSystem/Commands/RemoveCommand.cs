using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class RemoveRecordCommand<T> : CommandBase where T : Record
    {
        private readonly Book<T> _book;
        private readonly Action _removeRecord;

        public RemoveRecordCommand(Book<T> book, Action removeRecord)
        {
            _book = book;
            _removeRecord = removeRecord;
        }

        public override void Execute(object? parameter)
        {
            _removeRecord();
        }
    }
}
