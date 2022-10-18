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
        private UserStore _store;
        private Book<User> _userBook;
        private LoginViewModel _login;
        private NavigateCommand _nav;

        public UserStore Store { get; set; }
        public Book<User> UserBook { get; set; }
        public LoginViewModel Login { get; set; }
        public NavigateCommand Nav { get; set; }

        public AttemptLogin(UserStore store, Book<User> users, LoginViewModel login, NavigateCommand navcommand)
        {
            _store = store;
            _userBook = users;
            _login = login;
            _nav = navcommand;
        }
        public override void Execute(object? parameter)
        {
            IEnumerable<User> users = _userBook.GetRecordsbyExactName(Login.Username);
            if (users.Any())
            {
                if (users.First().Password == Login.Password)
                {
                    Store.Username = users.First().Name;
                    Store.Position = users.First().Position;
                    //set up store
                    Nav.Execute(null);
                }
            }
        }
    }
}
