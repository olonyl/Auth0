using Auth0API.Domain.Entities;
using Auth0API.Domain.Seedwork;
using Auth0API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth0API.Infrastructure.Initializer
{
    public class Initializer : IInitializer
    {
        private readonly ApplicationContext _db;
        public Initializer(ApplicationContext db)
        {
            _db = db;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }
            if (_db.Employee.Count() == 0)
            {
                _db.Employee.Add(new Employees
                {
                    Address ="My Address",
                    City="Managua",
                    Country="Nicaragua",
                    FirstName="Olonyl",
                    LastName="Landeros",
                    PhoneNumber ="89804255"
                });
                _db.Employee.Add(new Employees
                {
                    Address = "My Address 2",
                    City = "Managua",
                    Country = "Nicaragua",
                    FirstName = "Jose",
                    LastName = "Rocha",
                    PhoneNumber = "777865555"
                });
                _db.Employee.Add(new Employees
                {
                    Address = "My Address 3",
                    City = "Masaya",
                    Country = "Nicaragua",
                    FirstName = "Pepe",
                    LastName = "Ruiz",
                    PhoneNumber = "876565454"
                });
                _db.SaveChanges();
            }
            if (_db.Article.Count() == 0)
            {
                _db.Article.Add(new Articles
                {
                   Name= "Building",
                   CreationDate = DateTime.Now.ToString(),
                   Description="Building Process",
                   UrlImage= "http://lorempixel.com/640/480/technics"

                });
                _db.Article.Add(new Articles
                {
                    Name = "Sport",
                    CreationDate = DateTime.Now.ToString(),
                    Description = "Breaking News",
                    UrlImage = "http://lorempixel.com/640/480/business"

                });
                _db.SaveChanges();
            }
        }
    }
}
