using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.ViewModel
{
    internal class UserViewModel : ViewModelBase
    {
        private User _user;
        public User Member
        {
            get => _user;
        }

        public string ID => _user.ID.ToString();
        public string Name => _user.Name;

        public string Holder => _user.Holder;
        public User.StaffPosition Position => _user.Position;

        public string Password => _user.Password;

        public string IDName
        {
            get { return _user.ID.ToString() + " - " + _user.Name.ToString(); }
        }

        public UserViewModel(User user)
        {
            _user = user;
        }
    }
}
