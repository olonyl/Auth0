﻿using Auth0API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Aggregates
{
    class ArticleSpecification
    {
        public static Specification<Article> All()
        {
            return new AdHocSpecification<Article>(p => true);
        }
    }
}
