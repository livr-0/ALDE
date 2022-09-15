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
            bool opened = false;
            int i = 0;
            string[] parts = new string[4];
            string str = "";
            foreach (char c in line)
            {
                
                if(c == '"') { opened = !opened; continue; }
                if (!opened)
                {
                    if(c == ',')
                    {
                        parts[i] = str;
                        i++;
                        str = "";
                        continue;
                    }
                }
                str += c;
            }
            return new Product(int.Parse(parts[0]), parts[1], parts[2],float.Parse(parts[3]),int.Parse(parts[4]));
        }
    }
}
