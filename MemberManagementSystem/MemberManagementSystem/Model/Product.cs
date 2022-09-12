using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    public class Product
    {
        private int _id;
        private string _name;
        private string _description { get; set; }
        private float _price;
        private int _quantity { get; set; }

        public Product(int id, string name, string desc, float price, int quantity)
        {
            _id = id;
            _name = name;
            _description = desc;
            _price = price;
            _quantity = quantity;
        }

        public Product(int id, string name, string desc) : this(id, name, desc, 0, 0) { }

        public Product(int id, string name, string desc, float price) : this(id, name, desc, price, 0) { }

        public void Sold(int num)
        {
            _quantity = _quantity - num;
        }

        public void NewStock(int num)
        {
            _quantity = _quantity + num;
        }

        // used to see if the product has same name or ID
        public bool Conflict(Product p)
        {
            if (p != null)
            {
                if (_id != p._id && _name != p._name)
                {
                    return true;
                }
            }

            return false;
        }

        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

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
    }
}
