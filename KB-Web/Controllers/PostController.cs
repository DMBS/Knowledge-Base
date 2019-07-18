using AutoMapper;
using KB_BAL.DTO_Model;
using KB_BAL.Interfaces;
using KB_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KB_Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController (IPostService serv)
        {
            postService = serv;
        }

        // GET: Post
        public ActionResult ListofArticles()
        {
            var DTOarticles = postService.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOArticle, ArticleViewModels>()).CreateMapper();
            var articleViewModel = mapper.Map<IEnumerable<DTOArticle>, List<ArticleViewModels>>(DTOarticles);
            
            return View(articleViewModel);
        }
    }
}