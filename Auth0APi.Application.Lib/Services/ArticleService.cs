using Auth0API.Application.DTO;
using Auth0API.Application.Interfaces;
using Auth0API.Application.SeedWork;
using Auth0API.Domain;
using Auth0API.Domain.Repositories;
using Auth0API.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth0API.Application.Services
{
    public class ArticleService : IArticleService
    {
        readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
        }
        public List<ArticleDTO> GetArticles()
        {
            var retVal = _articleRepository.GetAll();
            return retVal.ProjectedAsCollection<ArticleDTO>();
        }
    }
}
