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
                _users.Add(new UserViewModel(member));
            }
        }

        private void updateTextBoxes()
        {
            Name = SelectedUserViewModel.Name.ToString();
            Holder = SelectedUserViewModel.Holder.ToString();
            Password = SelectedUserViewModel.Password.ToString();
            SelectedPos = SelectedUserViewModel.Position;
        }

        private void UpdateUser()
        {
            if (!string.IsNullOrEmpty(Holder) && !string.IsNullOrEmpty(Password))
            {
                User uChanged = _userBook.GetSingleRecord(int.Parse(_userViewModel.ID));

                uChanged.Name = _name;
                uChanged.Holder = _holder;
                uChanged.Password = _password;
                uChanged.Position = _selectedPos;
            }


        }

        private void RemoveUser()
        {
            if (SelectedUserViewModel != null)
            {
                _userBook.RemoveRecord(SelectedUserViewModel.Member);
            }
        }
    }
}
