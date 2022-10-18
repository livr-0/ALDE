using MemberManagementSystem.Model;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Stores
{
    /// <summary>
    /// Holds username and rank after login.
    /// </summary>
    internal class UserStore
    {
        private User.StaffPosition _position;
        private string _username;
        /// <summary>
        /// Holds name to display on other pages, position for determining positions
        /// </summary>
        public User.StaffPosition Position { get; set; }
        public string Username { get; set; }
    }
}
