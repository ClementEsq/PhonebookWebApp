using Phonebook.WebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.WebApp.Models;

namespace Phonebook.WebApp.Infrastructure.DataAccessLayer
{
    public class Repository : IRepository
    {
        private readonly IDataContext DataContext;

        public Repository(IDataContext DataContext)
        {
            this.DataContext = DataContext;
        }

        public async Task Delete(int id)
        {
            var entries = this.DataContext.GetContext();

            foreach (var entry in entries)
            {
                if(entry.Id == id)
                {
                    await Task.Run(() => entries.Remove(entry));
                    this.DataContext.Save(entries);
                    break;
                }
            }
        }

        public async Task<List<Entry>> GetAll()
        {
            var entries = await Task.Run(() => this.DataContext.GetContext());
            return entries.ToList();
        }

        public async Task<Entry> GetById(int id)
        {
            var entries = await Task.Run(() => this.DataContext.GetContext());
            var entry = entries.Where(e => e.Id == id).FirstOrDefault();
            return entry;
        }

        public async Task<Entry> InsertOrUpdate(Entry entry)
        {
            var entries = await Task.Run(() => this.DataContext.GetContext());
            var tempEntry = await GetById((int)entry.Id);
            var isExists = tempEntry != null;

            if(!isExists)
            {
                int id = entries.Count();
                entry.Id = ++id;
                entries.Add(entry);
            }
            else
            {
                await Task.Run(() => Update(ref entries, entry));
            }

            this.DataContext.Save(entries);
            return entry;
        }

        private void Update(ref IList<Entry> entries, Entry entry)
        {
            entries.First(e => e.Id == entry.Id).Name = entry.Name;
            entries.First(e => e.Id == entry.Id).MobileNumber = entry.MobileNumber;
            entries.First(e => e.Id == entry.Id).HomeNumber = entry.HomeNumber;
            entries.First(e => e.Id == entry.Id).EmailAddress = entry.EmailAddress;
        }
    }
}
