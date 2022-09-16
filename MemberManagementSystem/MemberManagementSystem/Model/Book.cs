using System;
using System.Collections.Generic;
using System.IO;
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

        public void SaveBook(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            for (int i = 0; i < _records.Count; i++)
            {
                sw.Write(_records[i].ToString());
            }
            sw.Close();
        }

        public static Book<T> LoadBook(string filePath)
        {
            Book<T> book = new Book<T>();

            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            while (true)
            {
                string line = sr.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                T record = (T)typeof(T).GetMethod("LoadFromLine").Invoke(null, new object[] {line});
                book.AddRecord(record);
            }
            return book;
        }
    }
}
