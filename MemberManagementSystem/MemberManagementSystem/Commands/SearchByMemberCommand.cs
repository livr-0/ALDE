using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MemberManagementSystem.Commands.SortProductCommand;

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
            string fDate = _viewSalesViewModel.DateRangeFrom;
            string tDate = _viewSalesViewModel.DateRangeTo;
            if(string.IsNullOrEmpty(fDate) || string.IsNullOrEmpty(tDate))
            {
                fDate = "01/01/0001";
                tDate = "31/12/9999";
            }
            fDate += " 00:00:00"; tDate += " 00:00:00";
            SimpleDateRange sorter = new SimpleDateRange(_salesBook);
            IEnumerable<Sales> rangedSales = sorter.SortByDate(fDate, tDate);


            _salesStore.ClearRecords();
            foreach (int id in ids)
            {

                IEnumerable<Sales> sales = rangedSales.Where(s => s.MemberID == id);
                               
                foreach (Sales sale in sales)
                {
                    _salesStore.AddRecord(sale);
                    _salesStore.AddRecordViewModel(_factory.CreateRecordViewModel(sale));
                }
            }
        }
    }

    internal class SimpleDateRange : Option
    {
        public SimpleDateRange(Book<Sales> sBook) : base(null, sBook)
        {
        }

        public IEnumerable<Sales> SortByDate(string fDate, string tDate)
        {
            DateTime fromDate = DateTime.ParseExact(fDate, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(tDate, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            return SalesInRange(fromDate, toDate);
        }
        public override Dictionary<int, float> Sort(IEnumerable<Sales> sales)
        {
            throw new NotImplementedException();
        }
    }
}
