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
        private string _dateTime;
        private int _quantity;

        public Sales(int id, string productID, string memberID, string dateTime, int quantity) : base(id, id.ToString()) // WARNING: Potential debt
        {
            _productID = productID;
            _memberID = memberID;
            _dateTime = dateTime;
            _quantity = quantity;
        }

        public string ProductID { get => _productID; set => _productID = value; }

        public string MemberID {get => _memberID; set => _memberID = value; }

        public string DateTime { get => _dateTime; set => _dateTime = value; }

        public int Quantity { get => _quantity; set => _quantity = value; }

        // may be used to save for csv
        public override string ToString()
        {
            string returnString = ID.ToString() + ',';
            returnString += ProductID.ToString() + ',';
            returnString += MemberID.ToString() + ',';
            returnString += DateTime + ',';
            returnString += Quantity.ToString() + ',';
            return returnString;
        }

        public new static Record LoadFromLine(string line)
        {
            string[] parts = line.Split(',');
            return new Sales(int.Parse(parts[0]), parts[1], parts[2], parts[3], int.Parse(parts[4]));
        }
    }
}
