﻿using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.ViewModel
{
    internal class ProductViewModel
    {
        private Product _product;

        public string ProductID => _product.ID.ToString();
        public string Name => _product.Name.ToString();
        public string Description => _product.Description.ToString();
        public string Price => _product.Price.ToString();
        public string Quantity => _product.Quantity.ToString();

        public ProductViewModel(Product product)
        {
            _product = product;
        }

    }
}