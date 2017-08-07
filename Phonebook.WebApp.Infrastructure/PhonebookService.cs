using Phonebook.WebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.WebApp.Models;

namespace Phonebook.WebApp.Infrastructure
{
    class PhonebookService : IPhonebookService
    {
        private readonly IRepository Repository;

        public PhonebookService(IRepository Repository)
        {
            this.Repository = Repository;
        }

        public async Task<Entry> CreatePhonebookEntry(Entry entry)
        {
            try
            {
                return await Repository.InsertOrUpdate(entry);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePhonebookEntry(int id)
        {
            try
            {
                await Repository.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditPhonebookEntry(Entry entry)
        {
            try
            {
                await Repository.InsertOrUpdate(entry);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Entry>> GetPhonebookEntries()
        {
            try
            {
                return await Repository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Entry> GetSinglePhonebookEntry(int id)
        {
            try
            {
                return await Repository.GetById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
