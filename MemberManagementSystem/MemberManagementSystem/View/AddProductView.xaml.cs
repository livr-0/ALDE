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
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        public AddProductView()
        {
            InitializeComponent();
        }

        // numbers only
        private void NumberOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // try to allow price format, eg. 6, 5.1, 5.20
        private void PriceOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]*('\'.[0-9]{0,2})?$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
