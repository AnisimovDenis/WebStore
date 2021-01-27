using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData productData;

        public ProductsApiController(IProductData productData) => this.productData = productData;

        public BrandDTO GetBrandById(int id) => productData.GetBrandById(id);

        public IEnumerable<BrandDTO> GetBrands() => productData.GetBrands();

        public ProductDTO GetProductById(int id) => productData.GetProductById(id);

        [HttpPost]
        public IEnumerable<ProductDTO> GetProducts([FromBody] ProductFilter Filter = null) => productData.GetProducts(Filter);

        [HttpGet("sections/{id}")]
        public SectionDTO GetSectionById(int id) => productData.GetSectionById(id);

        [HttpGet("sections")]
        public IEnumerable<SectionDTO> GetSections() => productData.GetSections();
    }
}
