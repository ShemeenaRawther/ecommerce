using AutoMapper;
using Microservice.Services.CouponApi.Models;
using Microservice.Services.CouponApi.Models.Dto;

namespace Microservice.Services.CouponApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var configuration = new MapperConfiguration(config=>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return configuration;
        }
    }
}
