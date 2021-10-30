using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;
using Ticaret.Core.DbModels.Identity;
using Ticaret.WebAPI.Dtos;

namespace Ticaret.WebAPI.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.ProductBrandName))
                .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.ProductTypeName))
                .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
