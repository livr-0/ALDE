using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class ViewUserViewModel : ViewModelBase
    {
        Book<User> _userBook;
        RecordViewModelStore _userStore;

        public IEnumerable<ViewModelBase> Users => _userStore.RecordsToDisplay;

        public ICommand HomePage { get; }
        public ICommand UpdateUserPage { get; }
        public ICommand ClearSearch { get; }

        public ViewUserViewModel(Book<User> userBook, NavigateService navService, RecordViewModelFactory recordViewModelFactory)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
           // UpdateUserPage = new NavigateCommand(navService, nameof(UpdateUserViewModel));
            _userStore = new RecordViewModelStore();
            _userBook = userBook;
            ClearSearch = new ResetRecordViewStoreCommand<User>(_userStore, _userBook, recordViewModelFactory);
            ClearSearch.Execute(null);
        }
    }
}
