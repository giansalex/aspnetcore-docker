using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using MicroService.Controllers;
using MicroService.Models;
using Xunit;

namespace MicroService.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            var repo = new ProductRepository();
            repo.Add(new Product
            {
                Id = 1,
                Nombre = "Barra",
                Monto = 21,
                Fecha = new DateTime(2017, 4, 3)
            });
            repo.Add(new Product
            {
                Id = 2,
                Nombre = "Cup",
                Monto = 25,
                Fecha = new DateTime(2017, 4, 5)
            });
            _controller = new ProductsController(repo);
        }

        [Fact]
        public void Get_products_all()
        {
            var r =_controller.Get();

            Assert.NotNull(r);
            Assert.True(r.Count() == 2);
        }

        [Fact]
        public void Add_product_success()
        {
            var product = new Product
            {
                Id = 3,
                Nombre = "Table",
                Monto = 21,
                Fecha = new DateTime(2017, 5, 2)
            };

            var response = _controller.Post(product);
            var prod = _controller.Get(product.Id);

            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(prod);
        }

        [Fact]
        public void Add_product_error()
        {
            var product = new Product
            {
                Id = 2,
                Monto = -1,
                Fecha = new DateTime(2017, 5, 2)
            };

            var response = _controller.Post(product);
            Trace.WriteLine(response.StatusCode);
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Get_one_product(int id)
        {
            var product = _controller.Get(id);

            Assert.NotNull(product);
        }
    }
}
