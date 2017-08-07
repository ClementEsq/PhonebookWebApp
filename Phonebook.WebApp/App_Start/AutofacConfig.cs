using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Phonebook.WebApp.Infrastructure.DataAccessLayer;
using Phonebook.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Phonebook.WebApp
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register dependencies
            builder.RegisterModule(new DataModule(Seed()));

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static List<Entry> Seed()
        {
            return new List<Entry>
            {
                new Entry() { Id = 1, Name = "John", HomeNumber = "12345", MobileNumber = "23453", EmailAddress = "John@test.com" },
                new Entry() { Id = 2, Name = "Pete", HomeNumber = "72726", MobileNumber = "93737", EmailAddress = "Pete@test.com" },
                new Entry() { Id = 3, Name = "Kevin", HomeNumber = "288373", MobileNumber = "83737", EmailAddress = "Kevin@test.com" },
                new Entry() { Id = 4, Name = "David", HomeNumber = "26652", MobileNumber = "773653", EmailAddress = "David@test.com" },
                new Entry() { Id = 5, Name = "Ian", HomeNumber = "77373", MobileNumber = "77474", EmailAddress = "Ian@test.com" },
                new Entry() { Id = 6, Name = "Paul", HomeNumber = "77664", MobileNumber = "23453", EmailAddress = "Paul@test.com" }
            };
        }
    }
}