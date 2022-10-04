using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class UpdateMemberViewModel : ViewModelBase
    {
        Book<Member> _memberBook;

        private ObservableCollection<MemberViewModel> _member;
        public IEnumerable<MemberViewModel> Members => _member;
        public ICommand HomePage { get; }
        public ICommand AlterMember { get; }
        public ICommand DeleteMember { get; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }


        private MemberViewModel _selectedMember;
        public MemberViewModel SelectedMember
        {
            get { return _selectedMember; }
            set { _selectedMember = value;
                updateTextBoxes(); OnPropertyChanged("SelectedMember"); }
        }

        public UpdateMemberViewModel(Book<Member> memberBook, NavigateService navService)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _memberBook = memberBook;
            _member = new ObservableCollection<MemberViewModel>();
            GatherMemberViews(memberBook);
            AlterMember = new UpdateRecordCommand<Member>(memberBook, UpdateMember);
            DeleteMember = new RemoveRecordCommand<Member>(memberBook, RemoveMember);
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

        private void updateTextBoxes()
        {
            Name = SelectedMember.Name.ToString();
            Email = SelectedMember.Email.ToString();
            Phone = SelectedMember.Phone.ToString();
        }

        private void UpdateMember()
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Phone))
            {
                Member mChanged = _memberBook.GetSingleRecord(int.Parse(_selectedMember.ID));

                mChanged.Name = _name;
                mChanged.Email = _email;
                mChanged.Phone = _phone;

                // _productBook.SwapRecord(pChanged);
            }


        }

        private void RemoveMember()
        {
            if (SelectedMember != null)
            {
                _memberBook.RemoveRecord(SelectedMember.Member);
            }
        }
    }
}