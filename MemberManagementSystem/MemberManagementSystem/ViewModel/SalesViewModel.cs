using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.ViewModel
{
    internal class SalesViewModel : ViewModelBase
    {
        private Sales _sale;
        private Book<Member> _memberBook;
        private Book<Product> _productBook;

        public Sales Sale
        {
            get { return _sale; }
        }

        public string SalesID => _sale.ID.ToString();

        public string MemberID => _sale.MemberID.ToString();

        public string MemberName
        {
            get
            {
                Member m = _memberBook.GetSingleRecord(_sale.MemberID);
                if (m == null) return "Discontinued";
                return m.Name;
            }
        }
        public string ProductID => _sale.ProductID.ToString();
        public string ProductName
        {
            get
            {
                Product p = _productBook.GetSingleRecord(_sale.ProductID);
                if (p == null) return "Discontinued";
                return p.Name;
            }
        }
        public string DateTime => _sale.DateTime.ToString();
        public string Quantity => _sale.Quantity.ToString();

        public SalesViewModel(Sales sale, Book<Member> memberBook, Book<Product> productBook)
        {
            _sale = sale;
            _memberBook = memberBook;
            _productBook = productBook;
        }
    }
}
