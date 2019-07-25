using AutoMapper;
using KB_BAL.DTO_Model;
using KB_BAL.Interfaces;
using KB_Web.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace KB_Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        /// <summary>
        /// CTOR - dependency injections
        /// </summary>
        /// <param name="serv"></param>
        public PostController (IPostService serv)
        {
            postService = serv;
        }

        // List of Articles
        public ActionResult ListofArticles(int? id)

        {
            
            var result = id == null ? postService.GetArticlesWithCategoryName() : postService.GetFilterArticles(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOArticle, ArticleViewModels>()).CreateMapper();
            var articleViewModel = mapper.Map<IEnumerable<DTOArticle>, List<ArticleViewModels>>(result);

            return View(articleViewModel);
        }

        //List of Categories
        public ActionResult ListofCategories()
        {
            var DTOcategories = postService.GetCountOfArticlesInCategory();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOCategory, CategoryViewModels>()).CreateMapper();
            var categoriesViewModel = mapper.Map<IEnumerable<DTOCategory>, List<CategoryViewModels>>(DTOcategories);

            return View(categoriesViewModel);
        }


        //Create Category
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory([Bind(Exclude = "Badge")] CategoryViewModels category, HttpPostedFileBase badge)
        {
            if (ModelState.IsValid)
            {
                if (badge != null)
                {
                    category.Badge = new byte[badge.ContentLength];
                    badge.InputStream.Read(category.Badge, 0, badge.ContentLength);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryViewModels, DTOCategory>()).CreateMapper();
                var DTOCategory = mapper.Map<CategoryViewModels,DTOCategory>(category);
                postService.CreateCategoryDTO(DTOCategory);
            }

            return RedirectToAction("ListOfCategories", "Post");
        }

        public ActionResult CreateArticle()
        {
            ViewBag.CategoryNames = new SelectList(postService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleViewModels, DTOArticle>()).CreateMapper();
                var DTOArticle = mapper.Map<ArticleViewModels, DTOArticle>(article);
                postService.CreateArticleDTO(DTOArticle);
            }

            return RedirectToAction("ListOfArticles", "Post");
        }

        public ActionResult ArticleDetails (int? id)
        {
            var DTOArticleDetails = postService.GetArticleDetails(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOArticle, ArticleViewModels>()).CreateMapper();
            var articleDetailsViewModel = mapper.Map<DTOArticle,ArticleViewModels>(DTOArticleDetails);

            return View(articleDetailsViewModel);
        }

        public ActionResult DeleteArticle (int? id)
        {
            postService.DeleteArticleDTO(id);
            return RedirectToAction("ListOfArticles");

        }

        public ActionResult EditArticle (int? id)
        {
            var article = postService.GetArticleById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOArticle, ArticleViewModels>()).CreateMapper();
            var articleEditViewModel = mapper.Map<DTOArticle, ArticleViewModels>(article);

            if (articleEditViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryNames = new SelectList(postService.GetCategories(), "Id", "Name");

            return View(articleEditViewModel);
        }

        [HttpPost]
        public ActionResult EditArticle (ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleViewModels, DTOArticle>()).CreateMapper();
                var DTOArticle = mapper.Map<ArticleViewModels, DTOArticle>(article);
                postService.EditArticleDTO(DTOArticle);
            }

            return RedirectToAction("ListOfArticles", "Post");
        }
    }
}