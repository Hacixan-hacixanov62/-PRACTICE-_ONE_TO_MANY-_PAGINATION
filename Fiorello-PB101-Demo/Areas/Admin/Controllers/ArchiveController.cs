using Fiorello_PB101_Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101_Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ArchiveController(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }


        public async Task<IActionResult> CategoryArchive()
        {
            return View(await _categoryService.GetAllArchveAsync());
        }
    }
}
