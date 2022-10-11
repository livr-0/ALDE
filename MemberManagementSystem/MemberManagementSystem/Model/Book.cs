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
            if (newR != null && !_records.ContainsKey(newR.ID))
            {
                IEnumerable<T> matchRecords = GetRecordsbyExactName(newR.Name);
                if (matchRecords.Any())
                {
                    newR.ID = matchRecords.First().ID;
                    var indexOfOld = _records.FirstOrDefault(r => r.Value.ID == newR.ID);
                    _records.Add(indexOfOld.Key, newR);
                }
                else
                {
                    _records.Add(newR.ID, newR);
                }
            }
        }

        public void RemoveRecord(T newR)
        {
            if (_records.ContainsKey(newR.ID))
            {
                if (newR.GetType() == typeof(Product))
                {
                    (newR as Product).ActiveStatus = false;
                }
                else if (newR.GetType() == typeof(Member))
                {
                    (newR as Member).ActiveStatus = false;
                }
                else if (newR.GetType() == typeof(User))
                {
                    (newR as User).ActiveStatus = false;
                }
                else
                {
                    _records.Remove(newR.ID);
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
        public IEnumerable<T> GetRecordsbyExactName(string name)
        {
            return _records.Values.Where(r => (
                r.Name.ToLower().Equals(name.ToLower())
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

        public bool RecordExists(T checkRecord)
        {
            foreach (var record in _records)
            {
                if(record.Value.Conflict(checkRecord))
                {
                    if (record.Value.GetType() == typeof(Product) && (record.Value as Product).ActiveStatus == true)
                    {
                        return true;
                    }
                    else if (record.Value.GetType() == typeof(Member) && (record.Value as Member).ActiveStatus == true)
                    {
                        return true;
                    }
                    else if (record.Value.GetType() == typeof(User) && (record.Value as User).ActiveStatus == true)
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
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
