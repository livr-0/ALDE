using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagementSystem.Model
{
    internal class Book<T> where T : Record
    {
        private List<T> _records;

        public Book()
        {
            _records = new List<T>();
        }

        public void AddRecord(T newR)
        {
            bool isNew = true;
            foreach (T existingProduct in _records)
            {
                if (existingProduct.Conflict(newR))
                {
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                _records.Add(newR);
            }
        }

        public void RemoveRecord(T newR)
        {
            if (_records.Contains(newR))
            {
                _records.Remove(newR);
            }
        }

        public IEnumerable<T> GetRecord(string name)
        {
            return _records.Where(p => p.Name.ToLower().Equals(name.ToLower()));
        }

        public IEnumerable<T> GetRecord(int id)
        {
            return _records.Where(_record => _record.ID == id);
        }
    }
}
