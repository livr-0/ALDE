using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MemberManagementSystem.ViewModel;

namespace MemberManagementSystem.Commands
{
    internal class ExportCSVCommand<T> : CommandBase where T : Record
    {
        RecordViewModelStore _recordStore;
        String _filePath;
        String _fileExt;
        String _fileTitle;

        public ExportCSVCommand(RecordViewModelStore recordStore, string fileTitle)
        {
            _recordStore = recordStore;
            _filePath = "../../../Reports/report";
            _fileExt = "csv";
            _fileTitle = fileTitle;
        }

        private String CreateFile()
        {
                int ix = 0;
                string fileName;
                do {
                    ix++;
                    fileName = String.Format("{0}{1}.{2}", _filePath, ix, _fileExt);
                } while (File.Exists(fileName));
                return fileName;
        }

        public override void Execute(object? parameter)
        {
            String newFile = CreateFile();
            using StreamWriter fileWriter = new StreamWriter(File.Open(newFile, FileMode.CreateNew));
            string header = (string)typeof(T).GetMethod("GetHeader").Invoke(null, new object[] { });
            fileWriter.WriteLine(_fileTitle);
            fileWriter.WriteLine(header);

            foreach (T r in _recordStore.Records)
            {
                fileWriter.WriteLine("" + r.ToString());
            }
            fileWriter.Close();
        }
    }
}
