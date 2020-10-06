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

                });
            }
        }
    }
}
