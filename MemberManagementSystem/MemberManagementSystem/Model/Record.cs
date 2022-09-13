using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    public class Record
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Record(int id, string name) { ID = id; Name = name; }

        // used to see if the product has same name or ID
        public virtual bool Conflict(Record r)
        {
            if (r != null)
            {
                if (ID == r.ID && Name == r.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
