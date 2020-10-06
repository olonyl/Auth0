using Auth0API.Domain.Entities;
using Auth0API.Domain.Repositories;
using Auth0API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Articles>, IArticleRepository
    {
        ApplicationContext db;
        public ArticleRepository(ApplicationContext db) : base(db)
        {
            this.db = db;
        }
    }
}
