using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Data
{
    public interface IAccountDataLoader
    {
        IAccountDataStore GetCurrentAccountDataStore();
    }
}
