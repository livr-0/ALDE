using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigateService _navigationService;
        private readonly string _viewModelName;
        private readonly User.StaffPosition[] _allowedPositions;
        private readonly UserStore _userStore;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="t">Type Name of View Model to Navigate to</param>
        public NavigateCommand(NavigateService navigationService, string viewModelName) : this(navigationService, viewModelName, null, new User.StaffPosition[0])
        {
            
        }

        public NavigateCommand(NavigateService navigationService, string viewModelName, UserStore userStore, params User.StaffPosition[] allowedPositions)
        {
            _navigationService = navigationService;
            _viewModelName = viewModelName;
            _allowedPositions = allowedPositions;
            _userStore = userStore;
        }

        public override bool CanExecute(object? parameter)
        {
            if(_allowedPositions.Length == 0)
            {
                return true;
            }
            for (int i = 0; i < _allowedPositions.Length; i++)
            {
                if(_userStore.Position == _allowedPositions[i])
                {
                    return true;
                }
            }

            return false;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_viewModelName);
        }
    }
}
