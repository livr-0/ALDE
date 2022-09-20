using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.ViewModel
{
    internal class SalesViewModel
    {
        private Sales _sale;

        public string SaleID => _sale.ID.ToString();
        public string MemberID => _sale.MemberID.ToString();
        public string ProductID => _sale.ProductID.ToString();
        public string DateTime => _sale.DateTime.ToString();
        public string Quantity => _sale.Quantity.ToString();

        public SalesViewModel(Sales sale)
        {
            _sale = sale;
        }

    }
}
