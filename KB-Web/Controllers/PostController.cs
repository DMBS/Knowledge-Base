﻿using AutoMapper;
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
        public ActionResult ListofArticles()
        {
            var DTOarticles = postService.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOArticle, ArticleViewModels>()).CreateMapper();
            var articleViewModel = mapper.Map<IEnumerable<DTOArticle>, List<ArticleViewModels>>(DTOarticles);
            
            return View(articleViewModel);
        }

        //List of Categories
        public ActionResult ListofCategories()
        {
            var DTOcategories = postService.GetCategories();
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
        public ActionResult CreateCategory(CategoryViewModels category, HttpPostedFileBase badge)
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

            return View(category);
        }
    }
}