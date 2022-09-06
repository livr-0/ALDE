using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManagementSystem.Commands
{
    /// <summary>
    /// All commands should inherit form this class
    /// Commands are encapsulation of instrucitons that can be attached to buttons.
    /// The CommandBase class handles the checking of whether the command can execute and what happens when executed.
    /// </summary>
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
