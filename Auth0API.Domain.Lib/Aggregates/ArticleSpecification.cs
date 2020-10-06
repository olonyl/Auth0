using Auth0API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Aggregates
{
    class ArticleSpecification
    {
        public static Specification<Articles> All()
        {
            return new AdHocSpecification<Articles>(p => true);
        }
    }
}
