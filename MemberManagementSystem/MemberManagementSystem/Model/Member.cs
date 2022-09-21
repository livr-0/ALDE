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



        public Member(int id, string name, string email, string phone) : base(id, name)
        {
            _email = email;
            _phone = phone;
        }

        //public void AddSale(int saleID)
        //{
        //    bool isNew = true;
        //    foreach (int existingSaleID in _salesRecordIDs)
        //    {
        //        if (existingSaleID == saleID)
        //        {
        //            isNew = false;
        //            break;
        //        }
        //    }

        //    if (isNew)
        //    {
        //        _salesRecordIDs.Add(saleID);
        //    }
        //}

        //public void RemoveSale(int saleID)
        //{
        //    if (_salesRecordIDs.Contains(saleID))
        //    {
        //        _salesRecordIDs.Remove(saleID);
        //    }
        //}

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

        //public IEnumerable<int> SalesRecordIDs => _salesRecordIDs;

        public new static string GetHeader()
        {
            return String.Format("{0},{1},{2},{3}", nameof(ID), nameof(Name),nameof(Email),nameof(Phone));
        }

        public new static Record LoadFromLine(string line)
        {
            string[] parts = line.Split(',');
            return new Member(int.Parse(parts[0]), parts[1],parts[2],parts[3]);
        }

        // may be used to save for csv
        public override string ToString()
        {
            string returnString = ID.ToString() + ',';
            returnString += Name + ',';
            returnString += _email + ',';
            returnString += _phone;
            return returnString;
        }
    }
}
