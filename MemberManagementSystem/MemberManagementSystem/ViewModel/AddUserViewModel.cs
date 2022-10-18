using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
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

        private string _holderColor = "Gray";
        public string HolderColor
        {
            get { return _holderColor; }
            set { _holderColor = value; OnPropertyChanged(nameof(HolderColor)); }
        }

        private string _passwordColor = "Gray";
        public string PasswordColor
        {
            get { return _passwordColor; }
            set { _passwordColor = value; OnPropertyChanged(nameof(PasswordColor)); }
        }

        private string _nameColor = "Gray";
        public string NameColor
        {
            get { return _nameColor; }
            set { _nameColor = value; OnPropertyChanged(nameof(NameColor)); }
        }

        
        private string _holderError = "";
        public string HolderError
        {
            get { return _holderError; }
            set { _holderError = value; OnPropertyChanged(nameof(HolderError)); }
        }

        private string _passwordError = "";
        public string PasswordError
        {
            get { return _passwordError; }
            set { _passwordError = value; OnPropertyChanged(nameof(PasswordError)); }
        }

        private string _nameError = "";
        public string NameError
        {
            get { return _nameError; }
            set { _nameError = value; OnPropertyChanged(nameof(NameError)); }
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

        private string _submitMsg = "";
        public string SubmitMsg
        {
            get { return _submitMsg; }
            set { _submitMsg = value; OnPropertyChanged(nameof(SubmitMsg)); }
        }

        public string _submitMsgColor = "Red";
        public string SubmitMsgColor
        {
            get { return _submitMsgColor; }
            set { _submitMsgColor = value; OnPropertyChanged(nameof(SubmitMsgColor)); }
        }

        public IEnumerable<User.StaffPosition> Positions { get; }


        public AddUserViewModel(NavigateService navService, Book<User> userBook, UserStore userStore)
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
            bool inputCorrect = true;

            if (_holder == null)
            {
                inputCorrect = false;
                HolderColor = "Red";
                HolderError = "Please enter the user holder's name.";
            }
            else
            {
                HolderColor = "Gray";
                HolderError = "";
            }

            if (_password == null)
            {
                inputCorrect = false;
                PasswordColor = "Red";
                PasswordError = "Please enter a password.";
            }
            else
            {
                PasswordColor = "Gray";
                PasswordError = "";
            }

            if (_name == null)
            {
                inputCorrect = false;
                NameColor = "Red";
                NameError = "Please enter a username.";
            }
            else
            {
                NameColor = "Gray";
                NameError = "";
            }

            if (inputCorrect)
            {
                User newUser = new User(_userBook.ID, Name, Password, Holder, SelectedPos, true);

                if (_userBook.RecordExists(newUser))
                {
                    SubmitMsgColor = "Red";
                    SubmitMsg = "User already exists";
                }
                else
                {
                    SubmitMsgColor = "Green";
                    SubmitMsg = "User Created";
                    return newUser;
                }
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to create User";
            }

            return null;
        }
    }
}