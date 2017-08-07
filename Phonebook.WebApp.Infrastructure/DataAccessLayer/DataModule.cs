using Autofac;
using Phonebook.WebApp.Infrastructure.Interfaces;
using Phonebook.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.WebApp.Infrastructure.DataAccessLayer
{
    public class DataModule : Module
    {
        private List<Entry> PhonebookEntries;

        public DataModule(List<Entry> PhonebookEntries)
        {
            this.PhonebookEntries = PhonebookEntries;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterDataAccessModules(builder);
            RegisterServiceModules(builder);
        }

        private void RegisterDataAccessModules(ContainerBuilder builder)
        {
            builder.Register(c => new DataContext(this.PhonebookEntries)).As<IDataContext>().SingleInstance();
            builder.RegisterType<Repository>().As<IRepository>().InstancePerRequest();
        }

        private void RegisterServiceModules(ContainerBuilder builder)
        {
            builder.RegisterType<PhonebookService>().As<IPhonebookService>().InstancePerRequest();
        }
    }
}
