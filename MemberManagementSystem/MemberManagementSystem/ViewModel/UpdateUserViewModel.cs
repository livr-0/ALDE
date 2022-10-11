using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class UpdateUserViewModel : ViewModelBase
    {
        Book<User> _userBook;

        private ObservableCollection<UserViewModel> _users;
        public IEnumerable<UserViewModel> Users => _users;
        public ICommand HomePage { get; }
        public ICommand AlterUser { get; }
        public ICommand DeleteUser { get; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _holder;

        public string Holder
        {
            get { return _holder; }
            set { _holder = value; OnPropertyChanged(nameof(Holder)); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        private string _userColor = "Gray";
        public string UserColor
        {
            get { return _userColor; }
            set { _userColor = value; OnPropertyChanged(nameof(UserColor)); }
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

        private string _userError = "";
        public string UserError
        {
            get { return _userError; }
            set { _userError = value; OnPropertyChanged(nameof(UserError)); }
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

        public IEnumerable<User.StaffPosition> Positions { get; }

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

        private UserViewModel _userViewModel;
        public UserViewModel SelectedUserViewModel
        {
            get { return _userViewModel; }
            set
            {
                _userViewModel = value;
                updateTextBoxes(); OnPropertyChanged(nameof(SelectedUserViewModel));
            }
        }

        public UpdateUserViewModel(Book<User> userBook, NavigateService navService)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _userBook = userBook;
            _users = new ObservableCollection<UserViewModel>();
            GatherUserViews(userBook);
            AlterUser = new UpdateRecordCommand<User>(userBook, UpdateUser);
            DeleteUser = new RemoveRecordCommand<User>(userBook, RemoveUser);
            Positions = new List<User.StaffPosition>() { User.StaffPosition.Staff, User.StaffPosition.Manager, User.StaffPosition.Owner };
        }

        private void GatherUserViews(Book<User> userBook)
        {
            _users.Clear();
            IEnumerable<User> members = userBook.Records;
            foreach (User member in members)
            {
                if (member.ActiveStatus)
                {
                    _users.Add(new UserViewModel(member));
                }
            }
        }

        private void updateTextBoxes()
        {
            if (SelectedUserViewModel != null)
            {
                Name = SelectedUserViewModel.Name;
                Holder = SelectedUserViewModel.Holder;
                Password = SelectedUserViewModel.Password;
                SelectedPos = SelectedUserViewModel.Position;
            }
            else
            {
                Name = null;
                Holder = null;
                Password = null;
                SelectedPos = User.StaffPosition.Staff;
            }
        }

        private void UpdateUser()
        {
            bool inputCorrect = true;

            if (SelectedUserViewModel == null)
            {
                UserColor = "Red";
                UserError = "Please Select a Product.";
            }
            else
            {
                UserColor = "Gray";
                UserError = "";
            }

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
                User uChanged = _userBook.GetSingleRecord(int.Parse(_userViewModel.ID));

                uChanged.Name = _name;
                uChanged.Holder = _holder;
                uChanged.Password = _password;
                uChanged.Position = _selectedPos;

                SubmitMsgColor = "Green";
                SubmitMsg = "User Updated";
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to update User.\nIf original data is needed, reselect user.";
            }

        }

        private void RemoveUser()
        {
            if (SelectedUserViewModel != null)
            {
                UserColor = "Gray";
                UserError = "";
                HolderColor = "Gray";
                HolderError = "";
                PasswordColor = "Gray";
                PasswordError = "";
                NameColor = "Gray";
                NameError = "";

                _userBook.RemoveRecord(SelectedUserViewModel.Member);
                GatherUserViews(_userBook);
                SubmitMsgColor = "Green";
                SubmitMsg = "User Removed";
            }
            else
            {
                UserColor = "Red";
                UserError = "Please Select a User.";

                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to delete User.";
            }
        }
    }
}
