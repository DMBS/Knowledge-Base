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
    public class HomeController : Controller
    {
        private IPostService postservice;

        public HomeController (IPostService serv)
        {
            postservice = serv;
        }

        public ActionResult Index()
        {
            var DTOArticles = postservice.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOArticle, ArticleViewModels>()).CreateMapper();
            var articleViewModel = mapper.Map<IEnumerable<DTOArticle>, IEnumerable<ArticleViewModels>>(DTOArticles);

            return View(articleViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}