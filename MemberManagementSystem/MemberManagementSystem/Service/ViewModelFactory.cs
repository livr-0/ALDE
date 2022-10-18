using MemberManagementSystem.Model;
using MemberManagementSystem.Stores;
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
        private readonly Book<User> _userBook;
        private RecordViewModelFactory _recordViewModelFactory;
        private UserStore _userStore;

        /// <summary>
        /// Any paramters that may be needed for a new viewmodel needto be passed into ViewModelFacotryConstructed
        /// </summary>
        public ViewModelFactory(NavigateService navService, Book<Member> memberBook, Book<Product> productBook, Book<Sales> salesBook, Book<User> userBook)
        {
            _navService = navService;
            _memberBook = memberBook;   
            _productBook = productBook;
            _salesBook = salesBook;
            _userBook = userBook;
            _recordViewModelFactory = new RecordViewModelFactory(memberBook, productBook, salesBook, userBook);
            _userStore = new UserStore();
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
                case nameof(AddUserViewModel):
                    return CreateAdduserViewModel();
                case nameof(ViewSalesViewModel):
                    return CreateViewSalesViewModel();
                case nameof(ViewProductViewModel):
                    return CreateViewProductViewModel();
                case nameof(ViewMemberViewModel):
                    return CreateViewMemberViewModel();
                case nameof(ViewUserViewModel):
                    return CreateViewUserViewModel();
                case nameof(UpdateProductViewModel):
                    return CreateUpdateProductViewModel();
                case nameof(UpdateSalesViewModel):
                    return CreateUpdateSalesViewModel();
                case nameof(UpdateMemberViewModel):
                    return CreateUpdateMemberViewModel();
                case nameof(UpdateUserViewModel):
                    return CreateUpdateUserViewModel();
                case nameof(LoginViewModel):
                    return CreateLoginViewModel();
            }

            throw new ArgumentException(String.Format("{0} is not a type of creatable viewmodel", viewModelName));
        }

        private ViewModelBase CreateLoginViewModel()
        {
            return new LoginViewModel(_navService, _userBook, _userStore);
        }

        private ViewModelBase CreateUpdateUserViewModel()
        {
            return new UpdateUserViewModel(_userBook, _navService, _userStore);
        }

        private ViewModelBase CreateViewUserViewModel()
        {
            return new ViewUserViewModel(_userBook,_navService,_recordViewModelFactory, _userStore);
        }

        private ViewModelBase CreateAdduserViewModel()
        {
           return new AddUserViewModel(_navService,_userBook, _userStore);
        }

        private ViewModelBase CreateViewSalesViewModel()
        {
            return new ViewSalesViewModel(_salesBook, _navService, _recordViewModelFactory, _memberBook, _productBook, _userStore);
        }
        private ViewModelBase CreateViewMemberViewModel()
        {
            return new ViewMemberViewModel(_memberBook, _navService, _recordViewModelFactory, _userStore);
        }

        private ViewModelBase CreateViewProductViewModel()
        {
            return new ViewProductViewModel(_salesBook, _productBook, _navService, _recordViewModelFactory, _userStore);
        }

        private ViewModelBase CreateAddMemberViewModel()
        {
            return new AddMemberViewModel(_navService, _memberBook, _userStore);
        }
        private ViewModelBase CreateAddProductViewModel()
        {
            return new AddProductViewModel(_navService, _productBook, _userStore);
        }

        private ViewModelBase CreateAddSalesViewModel() {
            return new AddSalesViewModel(_navService, _salesBook, _productBook, _memberBook, _userStore);
        }

        private ViewModelBase CreateUpdateProductViewModel()
        {
            return new UpdateProductViewModel(_productBook, _navService, _userStore);
        }

        private ViewModelBase CreateUpdateSalesViewModel()
        {
            return new UpdateSalesViewModel(_salesBook, _navService, _productBook, _memberBook, _userStore);
        }
        private ViewModelBase CreateUpdateMemberViewModel()
        {
            return new UpdateMemberViewModel(_memberBook, _navService, _userStore);
        }

        private ViewModelBase CreateHomeViewModel()
        {
            return new HomeViewModel(_navService, _userStore);
        }
    }
}
