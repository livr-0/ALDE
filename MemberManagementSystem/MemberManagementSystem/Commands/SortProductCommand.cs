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
        private List<Option> _options;
        public SortProductCommand(Book<Sales> s, Book<Product> p, RecordViewModelStore ps, RecordViewModelFactory f, ViewProductViewModel v)
        {
            _salesBook = s;
            _productBook = p;
            _productStore = ps;
            _factory = f;
            _viewProductViewModel = v;

            _options = new List<Option>();
            _options.Add(new SortByLeastRevenue(_productBook, _salesBook));
            _options.Add(new SortByMostRevenue(_productBook, _salesBook));
            _options.Add(new SortByLeastSales(_productBook, _salesBook));
            _options.Add(new SortByMostSales(_productBook, _salesBook));
        }

        public List<Option> Options => _options;

        public override void Execute(object? parameter)
        {
            Option o = _viewProductViewModel.Option;
            Dictionary<int, float> sortedProductList = o.SortedList;

            _productStore.ClearRecords();

            foreach (int pID in sortedProductList.Keys)
            {
                IEnumerable<Product> products = _productBook.Records.Where(p => p.ID == pID);
                foreach (Product prod in products)
                {
                    _productStore.AddRecord(prod);
                    _productStore.AddRecordViewModel(_factory.CreateRecordViewModel(prod));
                }
            }
        }

        internal abstract class Option
        {
            protected string _name;
            protected Book<Product> _pBook;
            protected Book<Sales> _sBook;
            protected Dictionary<int, float> _sortedList;
            public Option(Book<Product> pBook, Book<Sales> sBook)
            {
                _pBook = pBook;
                _sBook = sBook;
                _sortedList = new Dictionary<int, float>();
            }
            public string Name => _name;
            public abstract void Sort();

            public Dictionary<int, float> SortedList
            {
                get
                {
                    Sort();
                    return _sortedList;
                }
            }
        }

        internal class SortByMostRevenue : Option
        {
            public SortByMostRevenue(Book<Product> pBook, Book<Sales> sBook) : base(pBook, sBook)
            {
                _name = "Most Revenue";
            }
            public override void Sort()
            {
                _sortedList.Clear();
                IEnumerable<Product> products = _pBook.Records;

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Count(p.ID));
                }

                _sortedList = _sortedList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            public int Count(int pID)
            {
                IEnumerable<Sales> sales = _sBook.Records;
                int count = 0;

                foreach (Sales s in sales)
                {
                    if (s.ProductID == pID)
                    {
                        count += s.Quantity;
                    }
                }

                return count;
            }
        }
        internal class SortByLeastRevenue : SortByMostRevenue
        {
            public SortByLeastRevenue(Book<Product> pBook, Book<Sales> sBook) : base(pBook, sBook)
            {
                _name = "Least Revenue";
            }
            public override void Sort()
            {
                _sortedList.Clear();
                IEnumerable<Product> products = _pBook.Records;

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Count(p.ID));
                }

                _sortedList = _sortedList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        internal class SortByMostSales : Option
        {
            public SortByMostSales(Book<Product> pBook, Book<Sales> sBook) : base(pBook, sBook)
            {
                _name = "Most Sales";
            }

            public override void Sort()
            {
                IEnumerable<Product> products = _pBook.Records;
                _sortedList.Clear();

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Calculate(p.ID, p.Price));
                }

                _sortedList = _sortedList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            public float Calculate(int pID, float pPrice)
            {
                IEnumerable<Sales> sales = _sBook.Records;
                float revenue = 0;

                foreach (Sales s in sales)
                {
                    if (s.ID == pID)
                    {
                        revenue += pPrice * s.Quantity;
                    }
                }

                return revenue;
            }
        }

        internal class SortByLeastSales : SortByMostSales
        {
            public SortByLeastSales(Book<Product> pBook, Book<Sales> sBook) : base(pBook, sBook)
            {
                _name = "Least Sales";
            }

            public override void Sort()
            {
                IEnumerable<Product> products = _pBook.Records;
                _sortedList.Clear();

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Calculate(p.ID, p.Price));
                }

                _sortedList = _sortedList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}