using Microservices.Web.Models;
using Microservices.Web.Utility;

namespace Microservices.Web.Service.IService
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateCoupon(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/coupon/",
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCoupon(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
                Data = null
            });
        }

        public async Task<ResponseDto?> GetAllCoupons()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = null
            });
       }

        public async Task<ResponseDto?> GetCouponByCode(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode,
                Data = null
            });
        }

        public async Task<ResponseDto?> GetCouponById(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
                Data = null
            });
        }
        
        public async Task<ResponseDto?> UpdateCoupon(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + "/api/coupon/",
                Data = couponDto
            });
        }
    }
}
