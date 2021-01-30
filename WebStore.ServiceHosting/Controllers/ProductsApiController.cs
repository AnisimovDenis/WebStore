using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData productData;

        public ProductsApiController(IProductData productData) => this.productData = productData;

        [HttpGet("brands/{id}")]
        public BrandDTO GetBrandById(int id) => productData.GetBrandById(id);

        [HttpGet("brands")]
        public IEnumerable<BrandDTO> GetBrands() => productData.GetBrands();

        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id) => productData.GetProductById(id);

        [HttpPost]
        public IEnumerable<ProductDTO> GetProducts([FromBody] ProductFilter Filter = null) => productData.GetProducts(Filter);

        [HttpGet("sections/{id}")]
        public SectionDTO GetSectionById(int id) => productData.GetSectionById(id);

        [HttpGet("sections")]
        public IEnumerable<SectionDTO> GetSections() => productData.GetSections();
    }
}
