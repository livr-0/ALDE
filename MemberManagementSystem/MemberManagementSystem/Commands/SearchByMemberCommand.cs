using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Commands
{
    internal class SearchByMemberCommand : CommandBase
    {
        Book<Member> _memberBook;
        Book<Sales> _salesBook;
        RecordViewModelStore _salesStore;
        RecordViewModelFactory _factory;
        ViewSalesViewModel _viewSalesViewModel;

        public SearchByMemberCommand(Book<Member> memberBook, Book<Sales> salesBook, RecordViewModelStore salesStore, RecordViewModelFactory factory, ViewSalesViewModel viewSalesViewModel)
        {
            _memberBook = memberBook;
            _salesBook = salesBook;
            _salesStore = salesStore;
            _factory = factory;
            _viewSalesViewModel = viewSalesViewModel;
        }

        public override void Execute(object? parameter)
        {
            string search = _viewSalesViewModel.MemberSearch;
            if (search == null) return;
            int id;
            if(int.TryParse(search, out id))
            {
                AddMembers(id);
            }
            else
            {
                IEnumerable<int> ids = _memberBook.GetRecordIDsByName(search);
                AddMembers(ids.ToArray());
            }
           


        }


        private void AddMembers(params int[] ids)
        {
            _salesStore.ClearRecords();
            foreach (int id in ids)
            {
                IEnumerable<Sales> sales = _salesBook.Records.Where(s => s.MemberID == id);
                foreach (Sales sale in sales)
                {
                    _salesStore.AddRecordViewModel(_factory.CreateRecordViewModel(sale));
                }
            }
        }
    }
}
