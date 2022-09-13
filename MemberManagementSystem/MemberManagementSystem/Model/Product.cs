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
    }
}
