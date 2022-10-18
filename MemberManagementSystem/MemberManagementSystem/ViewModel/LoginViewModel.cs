using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        private Book<User> _userBook;

        private string _username;
        private UserStore _store;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public UserStore Store { get;}
        public Book<User> Userbook { get; } 

        public LoginViewModel(NavigateService navService, Book<User> userBook, UserStore store)
        {
            _userBook = userBook;
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _store = store;
            AttemptLogin = new AttemptLogin(Store, Userbook, this, new NavigateCommand(navService, nameof(HomeViewModel))); //needs to rework NavigateCommand to have account, or find way to store user in main window otherwise.
        }
        public ICommand HomePage { get; }
        public ICommand AttemptLogin { get; }
    }
}