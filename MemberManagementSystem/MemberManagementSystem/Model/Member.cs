using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    internal class Member : Record
    {
        private string _email{ get; set; }
        private string _phone;
        private List<int> _salesRecordIDs;



        public Member(int id, string name, string email, string phone) : base(id, name)
        {
            _email = email;
            _phone = phone;
            List<int> _salesRecords = new List<int>();
        }

        public void AddSale(int saleID)
        {
            bool isNew = true;
            foreach (int existingSaleID in _salesRecordIDs)
            {
                if (existingSaleID == saleID)
                {
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                _salesRecordIDs.Add(saleID);
            }
        }

        public void RemoveSale(int saleID)
        {
            if (_salesRecordIDs.Contains(saleID))
            {
                _salesRecordIDs.Remove(saleID);
            }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public IEnumerable<int> SalesRecordIDs => _salesRecordIDs;
    }
}
