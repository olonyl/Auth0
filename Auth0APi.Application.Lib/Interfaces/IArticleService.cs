using Auth0API.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth0API.Application.Interfaces
{
    public interface IArticleService
    {
        List<ArticleDTO> GetArticles();
    }
}
