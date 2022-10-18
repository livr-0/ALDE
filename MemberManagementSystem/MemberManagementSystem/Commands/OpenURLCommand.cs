using MemberManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MemberManagementSystem.Commands
{
    internal class OpenURLCommand : CommandBase
    {
        private string _url;
        public OpenURLCommand(string url)
        {
            _url = url;
        }

        public override void Execute(object? parameter)
        {
            Process.Start(new ProcessStartInfo { FileName = _url, UseShellExecute = true });
        }
    }
}
