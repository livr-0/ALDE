using MemberManagementSystem.Model;
using MemberManagementSystem.Stores;
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
        private readonly UserStore _userStore;

        public RemoveRecordCommand(Book<T> book, Action removeRecord, UserStore userStore)
        {
            _book = book;
            _removeRecord = removeRecord;
            _userStore = userStore;
        }

        public override bool CanExecute(object? parameter)
        {
            return _userStore.Position == User.StaffPosition.Manager || _userStore.Position == User.StaffPosition.Owner;
        }

        public override void Execute(object? parameter)
        {
            _removeRecord();
        }
    }
}
