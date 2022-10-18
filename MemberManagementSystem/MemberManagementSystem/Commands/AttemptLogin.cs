using MemberManagementSystem.Model;
using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class AttemptLogin : CommandBase
    {
        private Book<User> _userBook;
        private LoginViewModel _login;
        private NavigateCommand _nav;
        private UserStore _userStore;

        //public UserStore Store { get; set; }
        //public Book<User> UserBook { get; set; }
        //public LoginViewModel Login { get; set; }
        //public NavigateCommand Nav { get; set; }

        public AttemptLogin(UserStore userstore, Book<User> users, LoginViewModel login, NavigateCommand navcommand)
        {
            _userBook = users;
            _login = login;
            _nav = navcommand;
            _userStore = userstore;
        }
        public override void Execute(object? parameter)
        {
            if(_login.Username != null && _login.Password != null)
            {
                IEnumerable<User> users = _userBook.GetRecordsbyExactName(_login.Username);
                if (users.Any())
                {
                    if (users.First().Password == _login.Password)
                    {
                        _userStore.Username = users.First().Name;
                        _userStore.Position = users.First().Position;
                        //set up store
                        _nav.Execute(null);
                    }
                }
            }
            
        }
    }
}
