using MemberManagementSystem.Model;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Service
{
    internal class RecordViewModelFactory
    {
        private Book<Member> _memberBook;
        private Book<Product> _productBook;

        private Book<Sales> _salesBook;
        private Book<User> _userBook;

        public RecordViewModelFactory(Book<Member> memberBook, Book<Product> productBook, Book<Sales> salesBook, Book<User> userBook)
        {
            _memberBook = memberBook;
            _productBook = productBook;
            _salesBook = salesBook;
            _userBook = userBook;
        }
        public ViewModelBase CreateRecordViewModel(Record r)
        {
            string type = r.GetType().Name;
            switch (type)
            {
                case nameof(Sales):
                    return new SalesViewModel((Sales)r, _memberBook, _productBook);
                case nameof(MemberManagementSystem.Model.Member):
                    return new MemberViewModel((Member)r);
                case nameof(MemberManagementSystem.Model.Product):
                    return new ProductViewModel((Product)r);
                case nameof(MemberManagementSystem.Model.User):
                    return new UserViewModel((User)r);
            }
            throw new ArgumentException(r.GetType().ToString() + " is not a record type");
        }
    }
}
