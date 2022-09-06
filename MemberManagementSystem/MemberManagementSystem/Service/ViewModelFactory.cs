using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Service
{
    /// <summary>
    /// This is responsible for creating the ViewModels when requested
    /// Requests will usually be made by a navigation service
    /// </summary>
    internal class ViewModelFactory
    {
        /// <summary>
        /// Any paramters that may be needed for a new viewmodel needto be passed into ViewModelFacotryConstructed
        /// </summary>
        public ViewModelFactory()
        {

        }

        /// <summary>
        /// This Handles the Creation of ViewModel
        /// </summary>
        /// <param name="t">The Type name of a creatable viewmodel</param>
        /// <returns>A new instance of the viewmpodel of type t</returns>
        /// <exception cref="ArgumentException"></exception>
        public ViewModelBase CreateViewModel(string viewModelName)
        {
            switch (viewModelName)
            {
                case nameof(HomeViewModel):
                    return CreateHomeViewModel();
            }

            throw new ArgumentException(String.Format("{0} is not a type of creatable viewmodel", viewModelName));
        }

        private ViewModelBase CreateHomeViewModel()
        {
            return new HomeViewModel();
        }
    }
}
