using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    internal class Sales : Record
    {
        private string _productID;
        private string _memberID;
        private int _ID;
        private string _dateTime;
        private int _quantity;

        public Sales(int id, string productID, string memberID, string dateTime, int quantity) : base(id, "sales") // Dummy name, flag for changing base's props
        {
            _ID = id;
            _productID = productID;
            _memberID = memberID;
            _dateTime = dateTime;
            _quantity = quantity;
        }

        public int ID { get => _ID; }

        public string ProductID { get => _productID; set => _productID = value; }

        public string MemberID {get => _memberID; set => _memberID = value; }

        public string DateTime { get => _dateTime; set => _dateTime = value; }

        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
