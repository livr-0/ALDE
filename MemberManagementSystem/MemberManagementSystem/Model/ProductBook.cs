using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    //// ProductBook
    //// A class for keeping track of current products
    //// can use generic book instead
    //public class ProductBook
    //{
    //    private List<Product> _products;

    //    public ProductBook()
    //    {
    //        _products = new List<Product>();
    //    }

    //    public void AddProduct(Product newP)
    //    { 
    //        bool isNew = true;
    //        foreach (Product existingProduct in _products)
    //        {
    //            if (existingProduct.Conflict(newP))
    //            {
    //                isNew = false;
    //                break;
    //            }
    //        }

    //        if (isNew)
    //        {
    //            _products.Add(newP);
    //        }
    //    }

    //    public void RemoveProduct(Product newP)
    //    {
    //        if(_products.Contains(newP))
    //        {
    //            _products.Remove(newP);
    //        }
    //    }

    //    public IEnumerable<Product> GetProduct(string name)
    //    {
    //        return _products.Where(p => p.Name.ToLower().Equals(name.ToLower()));
    //    }

    //    public IEnumerable<Product> GetProduct(int id)
    //    {
    //        return _products.Where(_product => _product.ID == id);
    //    }
    //}
}
