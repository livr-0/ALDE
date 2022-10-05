using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    internal class Member : Record
    {
        private string _email;
        private string _phone;
        private bool _activeStatus;


        public Member(int id, string name, string email, string phone, bool activeStatus) : base(id, name)
        {
            _email = email;
            _phone = phone;
            _activeStatus = activeStatus;
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

        public bool ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }

        public new static string GetHeader()
        {
            return String.Format("{0},{1},{2},{3},{4}", nameof(ID), nameof(Name),nameof(Email),nameof(Phone), nameof(ActiveStatus));
        }

        public new static Record LoadFromLine(string line)
        {
            string[] parts = line.Split(',');
            return new Member(int.Parse(parts[0]), parts[1],parts[2],parts[3], Boolean.Parse(parts[4]));
        }

        // may be used to save for csv
        public override string ToString()
        {
            string returnString = ID.ToString() + ',';
            returnString += Name + ',';
            returnString += _email + ',';
            returnString += _phone + ',';
            returnString += _activeStatus.ToString();
            return returnString;
        }
    }
}
