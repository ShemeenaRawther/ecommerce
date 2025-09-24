using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetAllCoupons();
        Task<ResponseDto?> GetCouponById(int id);
        Task<ResponseDto?> GetCouponByCode(string code);
        Task<ResponseDto?> CreateCoupon(CouponDto couponDto);
        Task<ResponseDto?> UpdateCoupon(CouponDto couponDto);
        Task<ResponseDto?> DeleteCoupon(int id);
    }
}
