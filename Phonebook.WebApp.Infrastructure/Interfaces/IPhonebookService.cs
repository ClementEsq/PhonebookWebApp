using Phonebook.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.WebApp.Infrastructure.Interfaces
{
    public interface IPhonebookService
    {
        Task<Entry> CreatePhonebookEntry(Entry entry);
        Task<List<Entry>> GetPhonebookEntries();
        Task<Entry> GetSinglePhonebookEntry(int id);
        Task DeletePhonebookEntry(int id);
        Task EditPhonebookEntry(Entry entry);
    }
}
