using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
            Dictionary<int, float> sortedProductList;
            if (_viewProductViewModel.DateRangeFrom != "" && _viewProductViewModel.DateRangeTo != "")
            {
                sortedProductList = o.Sort(_viewProductViewModel.DateRangeFrom, _viewProductViewModel.DateRangeTo);
            }
            else
            {
                sortedProductList = o.Sort();
            }

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
            public abstract Dictionary<int, float> Sort(IEnumerable<Sales> sales);

            public Dictionary<int, float> Sort()
            {
                return Sort(_sBook.Records);
            }
            public Dictionary<int, float> Sort(String fDate, String tDate)
            {
                if (string.IsNullOrEmpty(fDate) || string.IsNullOrEmpty(tDate))
                {
                    fDate = "01/01/0001";
                    tDate = "31/12/9999";
                }
                fDate += " 00:00:00"; tDate += " 00:00:00";
                DateTime fromDate = DateTime.ParseExact(fDate, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(tDate, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                return Sort(SalesInRange(fromDate, toDate));
            }
            protected IEnumerable<Sales> SalesInRange(DateTime fDate, DateTime tDate)
            {
                ObservableCollection<Sales> parsedSales = new ObservableCollection<Sales>();
                foreach (Sales s in _sBook.Records)
                {
                    DateTime salesDateTime = DateTime.Parse(s.DateTime);
                    if (salesDateTime >= fDate && salesDateTime <= tDate)
                    {
                        parsedSales.Add(s);
                    }
                }
                return parsedSales;
            }
        }

        internal class SortByMostRevenue : Option
        {
            public SortByMostRevenue(Book<Product> pBook, Book<Sales> sBook) : base(pBook, sBook)
            {
                _name = "Most Revenue";
            }
            public override Dictionary<int, float> Sort(IEnumerable<Sales> sales)
            {
                _sortedList.Clear();
                IEnumerable<Product> products = _pBook.Records;

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Count(p.ID, sales));
                }

                _sortedList = _sortedList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                return _sortedList;
            }

            public int Count(int pID, IEnumerable<Sales> sales)
            {
                
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
            public override Dictionary<int, float> Sort(IEnumerable<Sales> sales)
            {
                _sortedList.Clear();
                IEnumerable<Product> products = _pBook.Records;

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Count(p.ID, sales));
                }

                _sortedList = _sortedList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                return _sortedList;
            }
        }

        internal class SortByMostSales : Option
        {
            public SortByMostSales(Book<Product> pBook, Book<Sales> sBook) : base(pBook, sBook)
            {
                _name = "Most Sales";
            }

            public override Dictionary<int, float> Sort(IEnumerable<Sales> sales)
            {
                IEnumerable<Product> products = _pBook.Records;
                _sortedList.Clear();

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Calculate(p.ID, p.Price, sales));
                }

                _sortedList = _sortedList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                return _sortedList;
            }

            public float Calculate(int pID, float pPrice, IEnumerable<Sales> sales)
            {
                
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

            public override Dictionary<int, float> Sort(IEnumerable<Sales> sales)
            {
                IEnumerable<Product> products = _pBook.Records;
                _sortedList.Clear();

                foreach (Product p in products)
                {
                    _sortedList.Add(p.ID, Calculate(p.ID, p.Price, sales));
                }

                _sortedList = _sortedList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                return _sortedList;
            }
        }
    }
}