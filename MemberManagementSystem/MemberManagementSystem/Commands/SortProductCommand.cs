using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;

namespace MemberManagementSystem.Commands
{
    internal class SortProductCommand : CommandBase
    {
        private Book<Sales> _salesBook;
        private Book<Product> _productBook;
        private RecordViewModelStore _productStore;
        private RecordViewModelFactory _factory;
        private ViewProductViewModel _viewProductViewModel;
        public SortProductCommand(Book<Sales> s, Book<Product> p, RecordViewModelStore ps, RecordViewModelFactory f, ViewProductViewModel v)
        {
            _salesBook = s;
            _productBook = p;
            _productStore = ps;
            _factory = f;
            _viewProductViewModel = v;
        }

        internal abstract class Option
        {
            protected string _name;
            public Option() { }

            public string Name => _name;
            public abstract void Sort();
        }

        internal class SortByMostRevenue : Option
        {
            public SortByMostRevenue()
            {
                _name = "Most Revenue";
            }

            public string Name => _name;
            public override void Sort()
            {

            }

            public virtual void Order() { }
        }

        internal class SortByLeastRevenue : SortByMostRevenue
        {
            public SortByLeastRevenue()
            {
                _name = "Least Revenue";
            }
            public override void Sort()
            {

            }

            public override void Order() { }
        }

        internal class SortByMostSales : Option
        {
            public SortByMostSales()
            {
                _name = "Most Sales";
            }

            public override void Sort()
            {

            }

            public virtual void Order() { }
        }

        internal class SortByLeastSales : SortByMostSales
        {
            public SortByLeastSales()
            {
                _name = "Least Sales";
            }

            public override void Sort()
            {

            }

            public override void Order() { }
        }


        public override void Execute(object? parameter)
        {
            try
            {
                Option o = _viewProductViewModel.Option;
                o.Sort();
            }
            catch(Exception)
            {
                // Error handling here
            }
        }
    }
}
