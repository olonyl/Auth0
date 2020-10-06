using Auth0API.Domain.Entities;
using Auth0API.Domain.Repositories;
using Auth0API.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth0API.Infrastructure
{
    public class ApplicationContext : DbContext, IQueryableUnitOfWork
    {
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Articles> Article { get; set; }

        IArticleRepository IUnitOfWork.Article => throw new NotImplementedException();

        IEmployeeRepository IUnitOfWork.Employee => throw new NotImplementedException();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int Commit()
        {
            return base.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
