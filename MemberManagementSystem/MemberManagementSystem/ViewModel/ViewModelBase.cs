using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.ViewModel
{
    /// <summary>
    /// All View Models must inherit from this class
    /// ViewModelBase cotnains the handler for notifying the update of PropertyChanges
    /// </summary>
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Whenever a Property is changed in a view model this should be called in the setter to notify the change of value.
        /// </summary>
        /// <param name="propertyName">The Symbol Being Changed</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
