using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;
using Ticaret.Core.DbModels.Identity;
using Ticaret.Core.DbModels.OrderAggregate;
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

            CreateMap<Core.DbModels.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<OrderItemUrlResolver>());
            CreateMap<AddressDto, Core.DbModels.OrderAggregate.Address>().ReverseMap();

        }
    }
}
