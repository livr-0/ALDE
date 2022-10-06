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

        //private Permission _selectedperm;

        //public Permission SelectedPerm
        //{
        //    get { return _selectedperm; }
        //    set
        //    {
        //        _selectedperm = value;
        //        OnPropertyChanged(nameof(SelectedPerm));
        //    }
        //}

        //IEnumerable<Permssion> Perms {get;}


        //public AddUserViewModel(NavigateService navService, Book<User> userBook)
        //{
        //        _userBook = userBook;
        //        HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
        //        SubmitUser = new AddRecordCommand<Member>(userBook, CreateUser);
                  //Perms = new List<Perms>() {};
        //}

        public ICommand HomePage { get; }
        public ICommand SubmitUser { get; }

        //private User CreateUser()
        //{
        //    return new User(_userBook.ID, Name, Holder, Password, Permission,true);
        //}
    }
}