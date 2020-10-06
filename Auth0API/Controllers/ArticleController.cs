using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth0API.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleServicee;
        public ArticleController(IArticleService articleService)
        {
            this._articleServicee = articleService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var articles = this._articleServicee.GetArticles();
                if (articles == null) return NotFound();

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}