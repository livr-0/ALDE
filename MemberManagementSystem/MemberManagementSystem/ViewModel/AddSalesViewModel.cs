using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class AddSalesViewModel : ViewModelBase
    {
        Book<Sales> _salesBook;
        Book<Product> _productBook;
        Book<Member> _memberBook;

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

        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
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

        public AddSalesViewModel(NavigateService navService, Book<Sales> salesBook, Book<Product> productBook, Book<Member> memberBook)
        {
            _salesBook = salesBook;
            _productBook = productBook;
            _memberBook = memberBook;
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _product = new ObservableCollection<ProductViewModel>();
            GatherProductViews(productBook);
            _member = new ObservableCollection<MemberViewModel>();
            GatherMemberViews(memberBook);
            SubmitSales = new AddRecordCommand<Sales>(salesBook, CreateSales);
        }



        public ICommand HomePage { get; }
        public ICommand SubmitSales { get; }

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

        private Sales CreateSales()
        {
            bool inputCorrect = true;

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
            else
            {
                QuantityColor = "Gray";
                QuantityError = "";
            }

            if (inputCorrect)
            {
                int quantity = int.Parse(Quantity);

                Sales newSales = new Sales(_salesBook.ID, int.Parse(SelectedProduct.ProductID), int.Parse(SelectedMember.ID), DateTime, quantity);

                if (_salesBook.RecordExists(newSales))
                {
                    SubmitMsgColor = "Red";
                    SubmitMsg = "Sales already exists";
                }
                else
                {
                    SelectedProduct.Product.Quantity = SelectedProduct.Product.Quantity - quantity;
                    SubmitMsgColor = "Green";
                    SubmitMsg = "Sales Created";
                    return newSales;
                }
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to create Sales";
            }

            return null;
        }

    }
}