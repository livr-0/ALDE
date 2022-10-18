using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using MemberManagementSystem.Commands;
using MemberManagementSystem.Service;
using static System.Net.WebRequestMethods;

namespace MemberManagementSystem.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        private string _userManualURL;

        public string UserManualURL
        {
            get => _userManualURL;
        }
        public ICommand OpenUserManual { get; }
        public ICommand AddMemberPage{ get; }
        public ICommand AddSalesPage { get; }
        public ICommand AddProductPage { get; }
        public ICommand AddUserPage { get; }
        public ICommand ViewMemberPage { get; }
        public ICommand ViewSalesPage { get; }
        public ICommand ViewProductPage { get; }
        public ICommand ViewUserPage { get; }
        public HomeViewModel(NavigateService navService)
        {
            _userManualURL = "http://docs.google.com/document/d/e/2PACX-1vRYjZd2a218nfu8J-17-BgB_KSo5vXImL36_Yuk0j0LsChp7y5l2x1z-CxWExTkM1Q3f7x2tzNydnlM/pub";
            AddMemberPage = new NavigateCommand(navService, nameof(AddMemberViewModel));
            AddSalesPage = new NavigateCommand(navService, nameof(AddSalesViewModel));
            AddProductPage = new NavigateCommand(navService, nameof(AddProductViewModel));
            AddUserPage = new NavigateCommand(navService, nameof(AddUserViewModel));

            ViewMemberPage = new NavigateCommand(navService, nameof(ViewMemberViewModel));
            ViewSalesPage = new NavigateCommand(navService, nameof(ViewSalesViewModel));
            ViewProductPage = new NavigateCommand(navService, nameof(ViewProductViewModel));
            ViewUserPage = new NavigateCommand(navService, nameof(ViewUserViewModel));

            OpenUserManual = new OpenURLCommand(UserManualURL);
        }
    }
}
