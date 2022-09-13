using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Service
{
    internal class NavigateService
    {
        private readonly NavigateStore _navigationStore;
        private ViewModelFactory _creator;

        public ViewModelFactory Creator
        {
            set { _creator = value; }
        }

        public NavigateService(NavigateStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        /// <summary>
        /// This call allows for the changing of the active viewModel
        /// </summary>
        /// <param name="t">The Type Name of the ViewModel to be changed to</param>
        public void Navigate(string viewModelName)
        {
            _navigationStore.CurrentViewModel = _creator.CreateViewModel(viewModelName);
        }
    }
}
