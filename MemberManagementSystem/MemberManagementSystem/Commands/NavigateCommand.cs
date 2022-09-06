using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MemberManagementSystem.Commands
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly string _viewModelName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="t">Type Name of View Model to Navigate to</param>
        public NavigateCommand(NavigationService navigationService, string viewModelName)
        {
            _navigationService = navigationService;
            _viewModelName = viewModelName;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_viewModelName);
        }
    }
}
