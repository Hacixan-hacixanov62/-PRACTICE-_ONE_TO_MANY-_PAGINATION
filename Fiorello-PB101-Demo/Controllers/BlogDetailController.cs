﻿using Fiorello_PB101_Demo.Services.Interfaces;
using Fiorello_PB101_Demo.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101_Demo.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogDetailController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();
            BlogVM blog = await _blogService.GetByIdAsync((int)id);
            if (blog is null) return NotFound();
            return View(blog);
        }
    }
}
