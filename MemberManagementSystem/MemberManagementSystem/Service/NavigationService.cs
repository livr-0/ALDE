using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Service
{
    internal class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelFactory _creator;

        public NavigationService(NavigationStore navigationStore, ViewModelFactory creator)
        {
            _navigationStore = navigationStore;
            _creator = creator;
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
