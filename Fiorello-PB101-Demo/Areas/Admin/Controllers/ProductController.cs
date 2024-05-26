using Fiorello_PB101_Demo.Data;
using Fiorello_PB101_Demo.Helpers;
using Fiorello_PB101_Demo.Models;
using Fiorello_PB101_Demo.Services.Interfaces;
using Fiorello_PB101_Demo.ViewModels.Baskets;
using Fiorello_PB101_Demo.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiorello_PB101_Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _productService.GetAllPaginateAsync(page, 4);

            var mappedDatas = _productService.GetMappedDatas(products);

            int totalPage = await GetPageCountAsync(4);

            Paginate<ProductVM> paginateDatas = new(mappedDatas, totalPage, page);

            return View(paginateDatas);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }


        //[HttpPost]
        //public IActionResult UpdateProductQuantity(int id, int quantity)
        //{
        //    List<BasketVM> basketDatas = new();

        //    if (_context.HttpContext.Request.Cookies["basket"] is not null)
        //    {
        //        basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_context.HttpContext.Request.Cookies["basket"]);
        //    }

        //    var basketItem = basketDatas.FirstOrDefault(m => m.Id == id);
        //    if (basketItem != null)
        //    {
        //        basketItem.Count = quantity;
        //    }

        //    _context.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketDatas));

        //    int totalCount = basketDatas.Sum(m => m.Count);
        //    decimal totalPrice = basketDatas.Sum(m => m.Count * m.Price);
        //    int basketCount = basketDatas.Count;

        //    var itemPrice = basketItem.Price * basketItem.Count;
        //    var subtotal = basketDatas.Sum(m => m.Count * m.Price);

        //    return Ok(new { basketCount, totalCount, totalPrice, itemPrice, subtotal });
        //}
    }
}





    