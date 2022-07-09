using Microsoft.AspNetCore.Mvc;
using FoodsOnline.Web.ViewModels;
using FoodsOnline.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodsOnline.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        #region GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetAll();

            if (result is null) return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "CategoryId", "Name");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "CategoryId", "Name");

            var result = await _productService.GetById(id);

            if (result is null) return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> Delete(int id)
        {
            var result = await _productService.GetById(id);

            if (result is null) return View("Error");

            return View(result);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Create(productViewModel);

                if (result != null) return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "CategoryId", "Name");
            }

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Update(productViewModel);

                if (result is not null) return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productService.Delete(id);

            if (!result) return View("Error");

            return RedirectToAction("Index");
        }
        #endregion
    }
}
