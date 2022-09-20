using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    public class Product : Record
    {
        private string _description { get; set; }
        private float _price;
        private int _quantity { get; set; }

        public Product(int id, string name, string desc, float price, int quantity): base(id, name)
        {
            _description = desc;
            _price = price;
            _quantity = quantity;
        }

        public Product(int id, string name, string desc) : this(id, name, desc, 0, 0) { }

        public Product(int id, string name, string desc, float price) : this(id, name, desc, price, 0) { }

        public bool Sold(int num)
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
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
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
            returnString += string.Format("${0,12:C2},", _price);
            returnString += _quantity.ToString();
            return returnString;
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

           return new Product(num, productDetails[1], desc, price, quantity);
            
        }
    }
}
