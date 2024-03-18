using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Data
{
    public class AccountDataLoader : IAccountDataLoader
    {
        public IAccountDataStore GetCurrentAccountDataStore()
        {
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
            if (dataStoreType == "Backup")
            { 
                return new BackupAccountDataStore(); 
            }
            else
            {
                return new AccountDataStore();
            }
        }
    }
}
