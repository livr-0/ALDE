using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Stores
{
    /// <summary>
    /// The Navigation Store holds the current viewModel that is active this also therefore determines the current view
    /// Changeing the CurrentViewModel Property Directly is bad practice instead use the Navigation Service
    /// </summary>
    internal class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        /// <summary>
        /// Should you really be using this? or could go use the navigation service?
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
