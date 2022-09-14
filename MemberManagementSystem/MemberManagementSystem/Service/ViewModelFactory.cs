using MemberManagementSystem.Model;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Service
{
    /// <summary>
    /// This is responsible for creating the ViewModels when requested
    /// Requests will usually be made by a navigation service
    /// </summary>
    internal class ViewModelFactory
    {
        private NavigateService _navService;
        private Book<Member> _memberBook;
        private Book<Product> _productBook;

        private Book<Sales> _salesBook;

        /// <summary>
        /// Any paramters that may be needed for a new viewmodel needto be passed into ViewModelFacotryConstructed
        /// </summary>
        public ViewModelFactory(NavigateService navService, Book<Member> memberBook, Book<Product> productBook, Book<Sales> salesBook)
        {
            _navService = navService;
            _memberBook = memberBook;   
            _productBook = productBook;
            _salesBook = salesBook;
        }

        /// <summary>
        /// This Handles the Creation of ViewModel
        /// </summary>
        /// <param name="t">The Type name of a creatable viewmodel</param>
        /// <returns>A new instance of the viewmpodel of type t</returns>
        /// <exception cref="ArgumentException"></exception>
        public ViewModelBase CreateViewModel(string viewModelName)
        {
            switch (viewModelName)
            {
                case nameof(HomeViewModel):
                    return CreateHomeViewModel();
                case nameof(AddMemberViewModel):
                    return CreateAddMemberViewModel();
                case nameof(AddProductViewModel):
                    return CreateAddProductViewModel();
                case nameof(AddSalesViewModel):
                    return CreateAddSalesViewModel();
            }

            throw new ArgumentException(String.Format("{0} is not a type of creatable viewmodel", viewModelName));
        }

        private ViewModelBase CreateAddMemberViewModel()
        {
            return new AddMemberViewModel(_navService, _memberBook);
        }
        private ViewModelBase CreateAddProductViewModel()
        {
            return new AddProductViewModel(_navService, _productBook);
        }

        private ViewModelBase CreateAddSalesViewModel() {
            return new AddSalesViewModel(_navService, _salesBook);
        }

        private ViewModelBase CreateHomeViewModel()
        {
            return new HomeViewModel(_navService);
        }
    }
}
