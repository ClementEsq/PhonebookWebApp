using Phonebook.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.WebApp.Infrastructure.Interfaces
{
    public interface IDataContext
    {
        IList<Entry> GetContext();
        void Save(IList<Entry> entries);
    }
}
