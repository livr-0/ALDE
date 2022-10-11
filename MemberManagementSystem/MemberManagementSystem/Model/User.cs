using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    public class User : Record
    {
        public enum StaffPosition
        {
            Staff,
            Manager,
            Owner
        }
        private string _password;
        private string _holder;
        private StaffPosition _position;
        private bool _activeStatus;

        public User(int id, string name, string pass, string holder, StaffPosition position, bool activeStatus) : base(id, name)
        {
            _password = pass;
            _holder = holder;
            _position = position;
            _activeStatus = activeStatus;
        }

        public User(int id, string name, string pass, string holder) : this(id, name, pass, holder, 0, true) { }


      

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Holder
        {
            get { return _holder; }
            set { _holder = value; }
        }

        public StaffPosition Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public bool ActiveStatus
        {
            get { return _activeStatus;}
            set { _activeStatus = value;}
        }

        // may be used to save for csv
        public override string ToString()
        {
            string returnString = ID.ToString() + ',';
            returnString += Name + ',';
            if (_password.Contains(','))
            {
                returnString += '"' + _password + '"' + ',';
            }
            {
                returnString += _password + ',';
            }
            returnString += _holder.ToString() + ",";
            returnString += _position.ToString() + ",";
            returnString += _activeStatus.ToString();
            return returnString;
        }

        public new static string GetHeader()
        {
            return String.Format("{0},{1},{2},{3},{4},{5}", nameof(ID), nameof(Name),nameof(Password),nameof(Holder),nameof(Position),nameof(ActiveStatus));
        }

        public new static Record LoadFromLine(string line)
        {
            string userCSV = line;
            string[] userDetails = userCSV.Split(',');
            int num = Int32.Parse(userDetails[0]);

            // incase a description has a comma
            string pass = userDetails[2];
            int currentIndex = 2;
            if (userDetails[2][0] == '"')
            {
                pass = userDetails[2].Substring(1);
                for (int i = 3; i < userDetails.Length; i++)
                {
                    pass += userDetails[i];
                    currentIndex++;
                    if (userDetails[i].EndsWith('"'))
                    {
                        pass = pass.Substring(0, pass.Length - 1);
                        break;
                    }
                }
            }

            string holder = userDetails[currentIndex + 1];
            StaffPosition position = (StaffPosition)Enum.Parse(typeof(StaffPosition), userDetails[currentIndex + 2], true);
            bool activeStatus = Boolean.Parse(userDetails[currentIndex + 3]);

            return new User(num, userDetails[1], pass, holder, position, activeStatus);
            
        }
    }
}
