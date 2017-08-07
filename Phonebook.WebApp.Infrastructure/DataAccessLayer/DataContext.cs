using Phonebook.WebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.WebApp.Models;

namespace Phonebook.WebApp.Infrastructure.DataAccessLayer
{
    public class DataContext : IDataContext
    {
        private IList<Entry> Entries;

        public DataContext(IList<Entry> Entries)
        {
            this.Entries = Entries;
        }

        public IList<Entry> GetContext()
        {
            return this.Entries;
        }

        public void Save(IList<Entry> entries)
        {
            this.Entries = entries;
        }
    }
}
