using Auth0API.Domain;
using Auth0API.Domain.Repositories;
using Auth0API.Domain.Seedwork;
using Auth0API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth0API.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        public IArticleRepository Article { get; private set; }

        public IEmployeeRepository Employee { get; private set; }
        public UnitOfWork(ApplicationContext db)
        {
            this.db = db;
            Article = new ArticleRepository(db);
            Employee = new EmployeeRepository(db);
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public int Commit()
        {
            return this.db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.db.SaveChangesAsync();
        }
    }
}
