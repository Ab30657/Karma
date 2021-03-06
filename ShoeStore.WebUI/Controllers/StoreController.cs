﻿using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Concrete;
using ShoeStore.Domain.Entities;
using ShoeStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.WebUI.Controllers
{
    public class StoreController : Controller
    {
        private IProductRepos repos;
        public StoreController(IProductRepos reposPara)
        {
            repos = reposPara;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop(string selectedCategory, string selectedSubCategory, int page=1)
        {
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = repos.Products.Where(x => (selectedCategory == null || selectedCategory == x.Category.CategoryName) && (selectedSubCategory == null || selectedSubCategory == x.SubCategory.Name)).OrderBy(x => x.ProductId).Skip((page - 1) * 6),
                PageViewModel = new PageViewModel
                {
                    TotalItems = repos.Products.Where(x => (selectedCategory == null || selectedCategory == x.Category.CategoryName) && (selectedSubCategory == null || selectedSubCategory == x.SubCategory.Name)).Count(),
                    CurrentPage=page,
                    ItemsPerPage=6// Opt for Change
                },
                FilterViewModel= new FilterViewModel
                {
                    SelectedCategory=selectedCategory,
                    SelectedSubCategory=selectedSubCategory
                }
            };

            return View(viewModel);
        }

        public FileContentResult GetFile(int productId)
        {
            Product product = repos.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                return File(product.Image, product.ImageMIMEType);
            }
            else { return null; }
        }

    }
}