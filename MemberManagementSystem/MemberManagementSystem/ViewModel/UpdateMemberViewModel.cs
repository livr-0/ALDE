using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
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

        private string _memberColor = "Gray";
        public string MemberColor
        {
            get { return _memberColor; }
            set { _memberColor = value; OnPropertyChanged(nameof(MemberColor)); }
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

        private string _memberError = "";
        public string MemberError
        {
            get { return _memberError; }
            set { _memberError = value; OnPropertyChanged(nameof(MemberError)); }
        }

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
                if (member.ActiveStatus)
                {
                    _member.Add(new MemberViewModel(member));
                }
            }
        }

        private void updateTextBoxes()
        {
            if (_selectedMember != null)
            {
                Name = SelectedMember.Name.ToString();
                Email = SelectedMember.Email.ToString();
                Phone = SelectedMember.Phone.ToString();
            }
            else
            {
                Name = null;
                Email = null;
                Phone = null;
            }
        }

        private void UpdateMember()
        {
            bool inputCorrect = true;

            if (_selectedMember == null)
            {
                MemberColor = "Red";
                MemberError = "Please Select a Product.";
            }
            else
            {
                MemberColor = "Gray";
                MemberError = "";
            }

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
                Member mChanged = _memberBook.GetSingleRecord(int.Parse(_selectedMember.ID));

                mChanged.Name = _name;
                mChanged.Email = _email;
                mChanged.Phone = _phone;

                SubmitMsgColor = "Green";
                SubmitMsg = "Member Updated";
                // _productBook.SwapRecord(pChanged);
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to update Member.\nIf original data is needed, reselect member.";
            }


        }

        private void RemoveMember()
        {
            if (SelectedMember != null)
            {
                MemberColor = "Gray";
                MemberError = "";
                NameColor = "Gray";
                NameError = "";
                EmailColor = "Gray";
                EmailError = "";
                PhoneColor = "Gray";
                PhoneError = "";

                _memberBook.RemoveRecord(SelectedMember.Member);
                GatherMemberViews(_memberBook);
                SubmitMsgColor = "Green";
                SubmitMsg = "Member Removed";
            }
            else
            {
                MemberColor = "Red";
                MemberError = "Please Select a Member.";

                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to delete Member.";
            }
        }
    }
}