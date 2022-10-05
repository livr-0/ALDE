using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class SortProductCommand : CommandBase
    {
        private Dictionary<Options, string> _options;
        public SortProductCommand() {
            _options = new Dictionary<Options, string>();
            _options.Add(Options.MostSales, "Most Sales");
            _options.Add(Options.MostRevenue, "Most Revenue");
            _options.Add(Options.LeastSales, "Least Sales");
            _options.Add(Options.LeastRevenue, "Least Revenue");
        }
        public enum Options
        {
            MostSales,
            MostRevenue,
            LeastSales,
            LeastRevenue
        }
        public string OptionName(Options o) { return _options[o]; }
        public override void Execute(object? parameter) { }
    }
}
