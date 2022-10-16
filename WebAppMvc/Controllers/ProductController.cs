using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;
using WebAppMvc.Services;

namespace WebAppMvc.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductController
        public IActionResult Index()
        {
            var data = _productService.GetAll();
            return View(data);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(long id)
        {
            var data = _productService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 _productService.Add(product);
                return RedirectToAction(nameof(Index));

            

        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(long id)
        {
            var data = _productService.GetById(id);
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Product product)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(long id)
        {
            var data = _productService.GetById(id);
            return View(data);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, Product product)
        {

            var data = _productService.GetById(id);
            _productService.Remove(data.Id);
            return RedirectToAction(nameof(Index));

        }
    }
}
