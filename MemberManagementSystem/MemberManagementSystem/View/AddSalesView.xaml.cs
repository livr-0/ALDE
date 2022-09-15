using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace MemberManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AddSalesView.xaml
    /// </summary>
    public partial class AddSalesView : UserControl
    {
        public AddSalesView()
        {
            InitializeComponent();
        }

        // numbers only
        private void NumberOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DateTimeOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("([0-9]{2})/([0-9]{2})/([0-9]{4}) ([0-9]{2}):([0-9]{2}):([0-9]{2})");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
