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
        private Dictionary<int, T> _records;
        public IEnumerable<T> Records => _records.Values;

        private int _id;
        public int ID
        {
            get { _id++; return _id; }
        }

        public Book()
        {
            _records = new Dictionary<int, T>();
        }

        public void AddRecord(T newR)
        {
            if (!_records.ContainsKey(newR.ID))
            {
                _records.Add(newR.ID, newR);
            }
            //bool isNew = true;
            //foreach (T existingProduct in _records.Values)
            //{
            //    if (existingProduct.Conflict(newR))
            //    {
            //        isNew = false;
            //        break;
            //    }
            //}

            //if (isNew)
            //{
            //    _records.Add(newR.ID,newR);
            //}
        }

        public void RemoveRecord(T newR)
        {
            if (_records.ContainsKey(newR.ID))
            {
                if (newR.GetType() == typeof(Sales))
                {
                    _records.Remove(newR.ID);
                }
                else if (newR.GetType() == typeof(Product))
                {
                    (newR as Product).ActiveStatus = false;
                }
                else if (newR.GetType() == typeof(Member))
                {
                    (newR as Member).ActiveStatus = false;
                }
            }
        }

        public IEnumerable<int> GetRecordIDsByName(string name)
        {
            return GetRecordsByName(name).Select((r, ID) => r.ID);
        }

        public IEnumerable<T> GetRecordsByName(string name)
        {
            return _records.Values.Where(r => (
                r.Name.ToLower().Contains(name.ToLower()) 
                ));
        }
        //public IEnumerable<T> GetRecord(int id)
        //{
        //    return _records.Where(_record => _record.ID == id);
        //}

        public T GetSingleRecord(int id)
        {
            if (_records.ContainsKey(id))
            {
                return _records[id];
            }
            return null;
           
        }

        //public void SwapRecord(T newRecord)
        //{
        //    for (int i = 0; i < _records.Count; i++)
        //    {
        //        if (newRecord.ID == _records[i].ID)
        //        {
        //            _records[i] = newRecord;
        //            break;
        //        }

        //    }
        //}

        public void SaveBook(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            string header = (string)typeof(T).GetMethod("GetHeader").Invoke(null, new object[] { });
            sw.WriteLine(header);
            foreach (Record record in _records.Values)
            {
                sw.WriteLine(record.ToString());
            }
            sw.Close();
        }

        public static Book<T> LoadBook(string filePath)
        {
            Book<T> book = new Book<T>();

            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            int highestID = 0;
            while (true)
            {
                string line = sr.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                T record = (T)typeof(T).GetMethod("LoadFromLine").Invoke(null, new object[] {line});
                book.AddRecord(record);
                if(record.ID > highestID)
                {
                    highestID = record.ID;
                }
            }
            sr.Close();
            book._id = highestID;
            return book;
        }
    }
}
