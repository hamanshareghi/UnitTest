using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMvc.Controllers;
using WebAppMvc.Models;
using WebAppMvc.Models.MockData;
using WebAppMvc.Services;

namespace WebAppMvc.Test
{
    public class ProductApiControllerTest
    {
        moqData _moqdata;

        public ProductApiControllerTest()
        {
            _moqdata = new moqData();
        }

        [Fact]
        public void GetTest()
        {
            //arrange
            var moq = new Mock<IProductService>();
            moq.Setup(s => s.GetAll()).Returns(_moqdata.GetAll());
            ProductApiController apiController = new ProductApiController(moq.Object);

            //act

            var result = apiController.Get();

            //assert

            Assert.IsType<OkObjectResult>(result); 
            var list = result as OkObjectResult;
            Assert.IsType<List<Product>>(list.Value);
        }


        [Theory]
        [InlineData(1,-1)]
        public void GetById(long validId,long inValidId)
        {
            //arrange
            var moq = new Mock<IProductService>();
            moq.Setup(s => s.GetById(validId)).Returns(_moqdata.GetAll().FirstOrDefault(s => s.Id == validId));
            ProductApiController apiProduct = new ProductApiController(moq.Object);

            //act
            var result = apiProduct.Get(validId);

            //assert 
            Assert.IsType<OkObjectResult>(result);
            var product = result as OkObjectResult;
            Assert.IsType<Product>(product.Value);


            //arrange
          
            moq.Setup(s => s.GetById(inValidId)).Returns(_moqdata.GetAll().FirstOrDefault(s => s.Id == inValidId));

            //act
            var invalidResult = apiProduct.Get(inValidId);

            //assert 
            Assert.IsType<NotFoundResult>(invalidResult);

        }


        [Fact]
        public void Post_Test()
        {
            //arrange
            var moq = new Mock<IProductService>();

            ProductApiController apiController = new ProductApiController(moq.Object);

            Product product = new Product()
            {
                Id = 3,
                Description ="des3",
                Name="pro3",
                Price =5200
            };

            //act
            var result = apiController.Post(product);

            //assert
            Assert.IsType<StatusCodeResult>(result);

        }


        [Theory]
        [InlineData(1,-1)]
        public void Delete_Test(long validId,long inValidId)
        {
            //arrange
            var moq = new Mock<IProductService>();
            moq.Setup(s => s.Remove(validId));
            moq.Setup(s => s.GetById(validId)).Returns(_moqdata.GetAll().FirstOrDefault(s => s.Id == validId));
            ProductApiController apiProduct = new ProductApiController(moq.Object);

            //act
            var result = apiProduct.Delete(validId);
            var invalidResult = apiProduct.Delete(inValidId);

            //assert

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<NotFoundResult>(invalidResult);
        }
    }
}
