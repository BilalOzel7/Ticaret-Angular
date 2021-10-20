using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;
using Ticaret.Core.Interfaces;
using Ticaret.Core.Specification;
using Ticaret.Infrastructure.DataContext;
using Ticaret.WebAPI.Dtos;

namespace Ticaret.WebAPI.Controllers
{
    
    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepository,
           IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification();
            var data = await _productRepository.ListAsync(spec);
            //return Ok(data);
            //return data.Select(product => new ProductToReturnDto
            //{
            //    ProductId = product.ProductId,
            //    ProductName = product.ProductName,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand != null ? product.ProductBrand.ProductBrandName : string.Empty,
            //    ProductType = product.ProductType != null ? product.ProductType.ProductTypeName : string.Empty
            //}).ToList();
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);
            //return await _productRepository.GetEntityWithSpec(spec);
            var product=await _productRepository.GetEntityWithSpec(spec);
            //return new ProductToReturnDto
            //{
            //    ProductId=product.ProductId,
            //    ProductName=product.ProductName,
            //    PictureUrl=product.PictureUrl,
            //    Price=product.Price,
            //    ProductBrand = product.ProductBrand !=null ? product.ProductBrand.ProductBrandName:string.Empty,
            //    ProductType=product.ProductType !=null ? product.ProductType.ProductTypeName:string.Empty
            //};
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        { 
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}
