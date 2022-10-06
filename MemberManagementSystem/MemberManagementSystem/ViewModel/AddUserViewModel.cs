using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class AddUserViewModel : ViewModelBase
    {
        private Book<User> _userBook;

        private string _holder;

        public string Holder
        {
            get { return _holder; }
            set
            {
                _holder = value;
                OnPropertyChanged(nameof(Holder));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private User.StaffPosition _selectedPos;

        public User.StaffPosition SelectedPos
        {
            get { return _selectedPos; }
            set
            {
                _selectedPos = value;
                OnPropertyChanged(nameof(SelectedPos));
            }
        }

        public IEnumerable<User.StaffPosition> Positions { get; }


        public AddUserViewModel(NavigateService navService, Book<User> userBook)
        {
            _userBook = userBook;
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            SubmitUser = new AddRecordCommand<User>(userBook, CreateUser);
            Positions = new List<User.StaffPosition>() {User.StaffPosition.Staff,User.StaffPosition.Manager,User.StaffPosition.Owner };
        }

        public ICommand HomePage { get; }
        public ICommand SubmitUser { get; }

        private User CreateUser()
        {
            return new User(_userBook.ID, Name, Password, Holder, SelectedPos, true);
        }
    }
}