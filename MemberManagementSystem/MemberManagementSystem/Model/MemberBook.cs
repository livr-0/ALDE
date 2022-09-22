using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    ///// <summary>
    ///// NOt needed use the generic book
    ///// </summary>
    //internal class MemberBook
    //{
    //    private List<Member> _members;

    //    public MemberBook()
    //    {
    //        _members = new List<Member>();
    //    }

    //    public void AddMember(Member newM)
    //    {
    //        bool isNew = true;
    //        foreach (Member existingProduct in _members)
    //        {
    //            if (existingProduct.Conflict(newM))
    //            {
    //                isNew = false;
    //                break;
    //            }
    //        }

    //        if (isNew)
    //        {
    //            _members.Add(newM);
    //        }
    //    }

    //    public void RemoveMember(Member newM)
    //    {
    //        if (_members.Contains(newM))
    //        {
    //            _members.Remove(newM);
    //        }
    //    }

    //    public IEnumerable<Member> GetProduct(string name)
    //    {
    //        return _members.Where(p => p.Name.ToLower().Equals(name.ToLower()));
    //    }

    //    public IEnumerable<Member> GetProduct(int id)
    //    {
    //        return _members.Where(_product => _product.ID == id);
    //    }
    //}
}
