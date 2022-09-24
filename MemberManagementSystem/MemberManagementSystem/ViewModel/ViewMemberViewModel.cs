using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class ViewMemberViewModel : ViewModelBase
    {
        Book<Member> _memberBook;

        private ObservableCollection<MemberViewModel> _member;
        public IEnumerable<MemberViewModel> Member => _member;

        public ICommand HomePage { get; }
        public ICommand UpdateMemberPage { get; }

        public ViewMemberViewModel(Book<Member> memberBook, NavigateService navService)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            UpdateMemberPage = new NavigateCommand(navService, nameof(UpdateMemberViewModel));
            _memberBook = memberBook;
            _member = new ObservableCollection<MemberViewModel>();
            GatherMemberViews(memberBook);
        }

        private void GatherMemberViews(Book<Member> memberBook)
        {
            _member.Clear();
            IEnumerable<Member> members = memberBook.Records;
            foreach (Member member in members)
            {
                _member.Add(new MemberViewModel(member));
            }
        }
    }
}