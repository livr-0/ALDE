using MemberManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.ViewModel
{
    internal class MemberViewModel
    {
        private Member _member;

        public string ID => _member.ID.ToString();
        public string Name => _member.Name.ToString();
        public string Phone => _member.Phone.ToString();
        public string Email => _member.Email.ToString();

        public MemberViewModel(Member member)
        {
            _member = member;
        }

    }
}
