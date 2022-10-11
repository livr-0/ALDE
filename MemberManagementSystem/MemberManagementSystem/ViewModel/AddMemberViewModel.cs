using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Windows.Input;
using System.Text.RegularExpressions;

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

        private string _nameColor = "Gray";
        public string NameColor
        {
            get { return _nameColor; }
            set { _nameColor = value; OnPropertyChanged(nameof(NameColor)); }
        }

        private string _emailColor = "Gray";
        public string EmailColor
        {
            get { return _emailColor; }
            set { _emailColor = value; OnPropertyChanged(nameof(EmailColor)); }
        }
        private Regex _emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private string _phoneColor = "Gray";
        public string PhoneColor
        {
            get { return _phoneColor; }
            set { _phoneColor = value; OnPropertyChanged(nameof(PhoneColor)); }
        }
        private Regex _phoneRegex = new Regex(@"^[0-9]{2}\s[0-9]{4}\s[0-9]{4}$");

        private string _nameError = "";
        public string NameError
        {
            get { return _nameError; }
            set { _nameError = value; OnPropertyChanged(nameof(NameError)); }
        }

        private string _emailError = "";
        public string EmailError
        {
            get { return _emailError; }
            set { _emailError = value; OnPropertyChanged(nameof(EmailError)); }
        }

        private string _phoneError = "";
        public string PhoneError
        {
            get { return _phoneError; }
            set { _phoneError = value; OnPropertyChanged(nameof(PhoneError)); }
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
            bool inputCorrect = true;

            if (_name == null)
            {
                inputCorrect = false;
                NameColor = "Red";
                NameError = "Please enter member name.";
            }
            else
            {
                NameColor = "Gray";
                NameError = "";
            }

            if (_email == null || _emailRegex.IsMatch(_email) == false)
            {
                inputCorrect = false;
                EmailColor = "Red";
                EmailError = "Please enter a proper email.";
            }
            else
            {
                EmailColor = "Gray";
                EmailError = "";
            }

            if (_phone == null || _phoneRegex.IsMatch(_phone) == false)
            {
                inputCorrect = false;
                PhoneColor = "Red";
                PhoneError = "Please enter phone number in the format:\n03 2234 4562";
            }
            else
            {
                PhoneColor = "Gray";
                PhoneError = "";
            }

            if (inputCorrect)
            {

                Member newMember = new Member(_memberBook.ID, Name, Email, Phone, true);

                if (_memberBook.RecordExists(newMember))
                {
                    SubmitMsgColor = "Red";
                    SubmitMsg = "Member already exists";
                }
                else
                {
                    SubmitMsgColor = "Green";
                    SubmitMsg = "Member Created";
                    return newMember;
                }
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to create Member";
            }

            return null;
        }





    }
}