using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class AddMemberViewModel : ViewModelBase
    {
        private Book<Member> _memberBook;

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

        public AddMemberViewModel(NavigateService navService, Book<Member> memberBook)
        {
            _memberBook = memberBook;
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            SubmitMember = new AddRecordCommand<Member>(memberBook, CreateMember);
        }



        public ICommand HomePage { get; }
        public ICommand SubmitMember { get; }

        private Member CreateMember()
        {
            return new Member(_memberBook.ID, Name, Email, Phone);
        }





    }
}