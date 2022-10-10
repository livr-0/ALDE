using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class ViewMemberViewModel : ViewModelBase
    {
        Book<Member> _memberBook;
        RecordViewModelStore _memberStore;

        public IEnumerable<ViewModelBase> Member => _memberStore.RecordsToDisplay;

        public ICommand HomePage { get; }
        public ICommand UpdateMemberPage { get; }
        public ICommand ClearSearch { get; }

        public ViewMemberViewModel(Book<Member> memberBook, NavigateService navService, RecordViewModelFactory recordViewModelFactory)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            UpdateMemberPage = new NavigateCommand(navService, nameof(UpdateMemberViewModel));
            _memberStore = new RecordViewModelStore();
            _memberBook = memberBook;
            ClearSearch = new ResetRecordViewStoreCommand<Member>(_memberStore, _memberBook, recordViewModelFactory);
            ClearSearch.Execute(null);
        }

        //private void GatherMemberViews(Book<Member> memberBook)
        //{
        //    _member.Clear();
        //    IEnumerable<Member> members = memberBook.Records;
        //    foreach (Member member in members)
        //    {
        //        _member.Add(new MemberViewModel(member));
        //    }
        //}
    }
}