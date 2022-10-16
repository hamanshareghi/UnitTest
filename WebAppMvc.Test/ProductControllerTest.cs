using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAppMvc.Controllers;
using WebAppMvc.Models;
using WebAppMvc.Models.MockData;
using WebAppMvc.Services;
using Xunit;

namespace WebAppMvc.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void Index_Test()
        {

            // arrange
            moqData moqdata = new moqData();

            var moq = new Mock<IProductService>();

            moq.Setup(p => p.GetAll()).Returns(moqdata.GetAll());


            ProductController productController = new ProductController(moq.Object);
            // act

            var result = productController.Index();

            //assert

            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsAssignableFrom<List<Product>>(viewResult.ViewData.Model);

        }

        [Theory]
        [InlineData(1, -1)]
        public void Details_Test(long validId, long inValidId)
        {
            //arrange 
            moqData moqdata = new moqData();

            var moq = new Mock<IProductService>();

            moq.Setup(p => p.GetById(validId)).Returns(moqdata.GetAll().FirstOrDefault(s => s.Id == validId));

            ProductController productController = new ProductController(moq.Object);

            //act

            var result = productController.Details(validId);

            //assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);

            //***************************

            //arrange

            moq.Setup(s => s.GetById(inValidId)).Returns(moqdata.GetAll().FirstOrDefault(s => s.Id == inValidId));
            // act

            var invalidResult = productController.Details(inValidId);

            // assert
            Assert.IsType<NotFoundResult>(invalidResult);


        }

        [Fact]
        public void Create_Test()
        {
            //arrange
            var moq = new Mock<IProductService>();
            ProductController productController = new ProductController(moq.Object);

            Product product = new Product()
            {
                Id = 1,
                Description = "ccc",
                Name = "Mobile",
                Price = 14700

            };
            //act
            var result = productController.Create(product);
            //assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Null(redirect.ControllerName);

            //arrange

            Product inValidProduct = new Product()
            {
                Description = "invalid",
                Id = 2,
                Name = "",
                Price = 8500
            };
            productController.ModelState.AddModelError("Name","نام را وارد کنید");

            //act
            var invalidResult = productController.Create(inValidProduct);

            //assert

            Assert.IsType<BadRequestObjectResult>(invalidResult);
        }
    }
}