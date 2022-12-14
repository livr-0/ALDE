using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    public class Product : Record
    {
        private string _description;
        private float _price;
        private int _quantity;
        private bool _activeStatus;

        public Product(int id, string name, string desc, float price, int quantity, bool activeStatus) : base(id, name)
        {
            _description = desc;
            _price = price;
            _quantity = quantity;
            _activeStatus = activeStatus;
        }

        public Product(int id, string name, string desc) : this(id, name, desc, 0, 0, true) { }

        public Product(int id, string name, string desc, float price) : this(id, name, desc, price, 0, true) { }

        /*public bool Sold(int num)
        {
            if (_quantity - num > 0)
            {
                _quantity = _quantity - num;
                return true;
            }
            return false;
        }

        public void NewStock(int num)
        {
            _quantity = _quantity + num;
        }*/

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
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
            if (_description.Contains(','))
            {
                returnString += '"' + _description + '"' + ',';
            }
            {
                returnString += _description + ',';
            }
            returnString += string.Format("{0:C2},", _price);
            returnString += _quantity.ToString() + ",";
            returnString += _activeStatus.ToString();
            return returnString;
        }

        public new static string GetHeader()
        {
            return String.Format("{0},{1},{2},{3},{4},{5}", nameof(ID), nameof(Name),nameof(Description),nameof(Price),nameof(Quantity),nameof(ActiveStatus));
        }

        public new static Record LoadFromLine(string line)
        {
            string productCSV = line;
            string[] productDetails = productCSV.Split(',');
            int num = Int32.Parse(productDetails[0]);

            // incase a description has a comma
            string desc = productDetails[2];
            int currentIndex = 2;
            if (productDetails[2][0] == '"')
            {
                desc = productDetails[2].Substring(1);
                for (int i = 3; i < productDetails.Length; i++)
                {
                    desc += productDetails[i];
                    currentIndex++;
                    if (productDetails[i].EndsWith('"'))
                    {
                        desc = desc.Substring(0, desc.Length - 1);
                        break;
                    }
                }
            }

            float price = float.Parse(productDetails[currentIndex + 1].Substring(1));
            int quantity = Int32.Parse(productDetails[currentIndex + 2]);
            bool activeStatus = Boolean.Parse(productDetails[currentIndex + 3]);

            return new Product(num, productDetails[1], desc, price, quantity, activeStatus);
            
        }
    }
}
