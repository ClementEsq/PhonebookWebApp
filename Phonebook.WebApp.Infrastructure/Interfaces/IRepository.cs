using Phonebook.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.WebApp.Infrastructure.Interfaces
{
    public interface IRepository
    {
        Task Delete(int id);
        Task<List<Entry>> GetAll();
        Task<Entry> GetById(int id);
        Task<Entry> InsertOrUpdate(Entry entry);
    }
}
