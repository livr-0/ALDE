using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MemberManagementSystem.Commands;
using MemberManagementSystem.Service;

namespace MemberManagementSystem.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {

        public ICommand AddMemberPage{ get; }
        public ICommand AddSalesPage { get; }
        public ICommand AddProductPage { get; }
        public ICommand AddUserPage { get; }
        public ICommand ViewMemberPage { get; }
        public ICommand ViewSalesPage { get; }
        public ICommand ViewProductPage { get; }

        public HomeViewModel(NavigateService navService)
        {
            AddMemberPage = new NavigateCommand(navService, nameof(AddMemberViewModel));
            AddSalesPage = new NavigateCommand(navService, nameof(AddSalesViewModel));
            AddProductPage = new NavigateCommand(navService, nameof(AddProductViewModel));
            AddUserPage = new NavigateCommand(navService, nameof(AddUserViewModel));

            ViewMemberPage = new NavigateCommand(navService, nameof(ViewMemberViewModel));
            ViewSalesPage = new NavigateCommand(navService, nameof(ViewSalesViewModel));
            ViewProductPage = new NavigateCommand(navService, nameof(ViewProductViewModel));
        }
    }
}
