﻿namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Categories;

    using Microsoft.AspNetCore.Mvc;
    using System;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 5;

        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        public IActionResult ByName(string name, int page = 1)
        { 
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            viewModel.ForumPosts = this.postsService
              .GetByCategoryId<ForumPostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);
            var count = this.postsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            viewModel.CurrentPage = page;
            return this.View(viewModel);

        }
    }
}
