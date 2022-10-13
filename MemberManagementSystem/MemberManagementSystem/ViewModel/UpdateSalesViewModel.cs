using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class UpdateSalesViewModel : ViewModelBase
    {
        Book<Sales> _salesBook;
        Book<Product> _productBook;
        Book<Member> _memberBook;

        private ObservableCollection<SalesViewModel> _sales;
        public IEnumerable<SalesViewModel> Sales => _sales;
        public ICommand HomePage { get; }
        public ICommand AlterSales { get; }
        public ICommand DeleteSales { get; }

        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        private ObservableCollection<ProductViewModel> _product;
        public IEnumerable<ProductViewModel> Products => _product;

        private ProductViewModel _selectedProduct;
        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value; OnPropertyChanged("SelectedProduct");
            }
        }

        private ObservableCollection<MemberViewModel> _member;
        public IEnumerable<MemberViewModel> Members => _member;

        private MemberViewModel _selectedMember;
        public MemberViewModel SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                _selectedMember = value; OnPropertyChanged("SelectedMember");
            }
        }

        private string _dateTime;

        public string DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; OnPropertyChanged(nameof(DateTime)); }
        }

        private SalesViewModel _selectedSales;
        public SalesViewModel SelectedSales
        {
            get { return _selectedSales; }
            set
            {
                _selectedSales = value;
                updateTextBoxes(); OnPropertyChanged("SelectedSales");
            }
        }

        private string _salesColor;
        public string SalesColor
        {
            get { return _salesColor; }
            set { _salesColor = value; OnPropertyChanged(nameof(SalesColor)); }
        }

        private string _productColor;
        public string ProductColor
        {
            get { return _productColor; }
            set { _productColor = value; OnPropertyChanged(nameof(ProductColor)); }
        }

        private string _memberColor = "Gray";
        public string MemberColor
        {
            get { return _memberColor; }
            set { _memberColor = value; OnPropertyChanged(nameof(MemberColor)); }
        }

        private string _dateTimeColor = "Gray";
        public string DateTimeColor
        {
            get { return _dateTimeColor; }
            set { _dateTimeColor = value; OnPropertyChanged(nameof(DateTimeColor)); }
        }
        // can add regex for date time
        //private Regex _priceRegex = new Regex("[0-9]*(.[0-9]{0,2})$");

        private string _quantityColor = "Gray";
        public string QuantityColor
        {
            get { return _quantityColor; }
            set { _quantityColor = value; OnPropertyChanged(nameof(QuantityColor)); }
        }
        private Regex _quantityRegex = new Regex("[0-9]*");

        private string _salesError = "";
        public string SalesError
        {
            get { return _salesError; }
            set { _salesError = value; OnPropertyChanged(nameof(SalesError)); }
        }

        private string _productError = "";
        public string ProductError
        {
            get { return _productError; }
            set { _productError = value; OnPropertyChanged(nameof(ProductError)); }
        }

        private string _memberError = "";
        public string MemberError
        {
            get { return _memberError; }
            set { _memberError = value; OnPropertyChanged(nameof(MemberError)); }
        }

        private string _dateTimeError = "";
        public string DateTimeError
        {
            get { return _dateTimeError; }
            set { _dateTimeError = value; OnPropertyChanged(nameof(DateTimeError)); }
        }

        private string _quantityError = "";
        public string QuantityError
        {
            get { return _quantityError; }
            set { _quantityError = value; OnPropertyChanged(nameof(QuantityError)); }
        }

        private string _submitMsg = "";
        public string SubmitMsg
        {
            get { return _submitMsg; }
            set { _submitMsg = value; OnPropertyChanged(nameof(SubmitMsg)); }
        }

        public string _submitMsgColor = "Red";
        public string SubmitMsgColor
        {
            get { return _submitMsgColor; }
            set { _submitMsgColor = value; OnPropertyChanged(nameof(SubmitMsgColor)); }
        }

        public UpdateSalesViewModel(Book<Sales> salesBook, NavigateService navService, Book<Product> productBook, Book<Member> memberBook)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _salesBook = salesBook;
            _productBook = productBook;
            _memberBook = memberBook;
            _sales = new ObservableCollection<SalesViewModel>();
            _product = new ObservableCollection<ProductViewModel>();
            _member = new ObservableCollection<MemberViewModel>();
            GatherSalesViews(salesBook);
            GatherProductViews(productBook);
            GatherMemberViews(memberBook);
            AlterSales = new UpdateRecordCommand<Sales>(salesBook, UpdateSales);
            DeleteSales = new RemoveRecordCommand<Sales>(salesBook, RemoveSales);
        }

        private void GatherSalesViews(Book<Sales> salesBook)
        {
            _sales.Clear();
            IEnumerable<Sales> salesRecords = salesBook.Records;
            foreach (Sales sales in salesRecords)
            {
                _sales.Add(new SalesViewModel(sales, _memberBook, _productBook));
            }
        }

        private void GatherProductViews(Book<Product> productBook)
        {
            _product.Clear();
            IEnumerable<Product> products = productBook.Records;
            foreach (Product product in products)
            {
                if (product.ActiveStatus)
                {
                    _product.Add(new ProductViewModel(product));
                }
            }
        }

        private void GatherMemberViews(Book<Member> memberBook)
        {
            _member.Clear();
            IEnumerable<Member> members = memberBook.Records;
            foreach (Member member in members)
            {
                if (member.ActiveStatus)
                {
                    _member.Add(new MemberViewModel(member));
                }
            }
        }

        private void updateTextBoxes() 
        {
            if (_selectedSales != null)
            {
                foreach (ProductViewModel p in _product)
                {
                    if (p.ProductID == _selectedSales.ProductID)
                    {
                        SelectedProduct = p;
                        break;
                    }
                }

                foreach (MemberViewModel m in _member)
                {
                    if (m.ID == _selectedSales.MemberID)
                    {
                        SelectedMember = m;
                        break;
                    }
                }

                DateTime = SelectedSales.DateTime.ToString();
                Quantity = SelectedSales.Quantity.ToString();
            }
            else
            {
                SelectedProduct = null;
                SelectedMember = null;
                DateTime = null;
                Quantity = null;
            }
        }

        private void UpdateSales()
        {
            bool inputCorrect = true;

            if (_selectedSales == null)
            {
                inputCorrect = false;
                SalesColor = "Red";
                SalesError = "Please select Sales.";
            }
            else
            {
                SalesColor = "Gray";
                SalesError = "";
            }

            if (_selectedProduct == null)
            {
                inputCorrect = false;
                ProductColor = "Red";
                ProductError = "Please select Product.";
            }
            else
            {
                ProductColor = "Gray";
                ProductError = "";
            }

            if (_selectedMember == null)
            {
                inputCorrect = false;
                MemberColor = "Red";
                MemberError = "Please select Member.";
            }
            else
            {
                MemberColor = "Gray";
                MemberError = "";
            }

            if (_dateTime == null)
            {
                inputCorrect = false;
                DateTimeColor = "Red";
                DateTimeError = "Please enter date time.";
            }
            else
            {
                DateTimeColor = "Gray";
                DateTimeError = "";
            }

            if (_quantity == null || _quantityRegex.IsMatch(_quantity) == false)
            {
                inputCorrect = false;
                QuantityColor = "Red";
                QuantityError = "Please enter quantity of product.\nIntegers only";
            }

            if (inputCorrect)
            {
                Sales sChanged = _salesBook.GetSingleRecord(int.Parse(_selectedSales.SalesID));

                sChanged.ProductID = int.Parse(SelectedProduct.ProductID);
                sChanged.MemberID = int.Parse(SelectedMember.ID);
                sChanged.Quantity = int.Parse(Quantity);
                sChanged.DateTime = DateTime;
                SubmitMsgColor = "Green";
                SubmitMsg = "Sales Updated";
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to update Sales";
            }
        }

        private void RemoveSales()
        {
            if (SelectedSales != null)
            {
                SalesColor = "Gray";
                SalesError = "";
                ProductColor = "Gray";
                ProductError = "";
                MemberColor = "Gray";
                MemberError = "";
                DateTimeColor = "Gray";
                DateTimeError = "";
                QuantityColor = "Gray";
                QuantityError = "";

                _salesBook.RemoveRecord(SelectedSales.Sale);
                GatherSalesViews(_salesBook);
                SubmitMsgColor = "Green";
                SubmitMsg = "User Removed";
            }
            else
            {
                SalesColor = "Red";
                SalesError = "Please Select a Sales.";

                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to delete User.";
            }
        }
    }
}