using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Microservices.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> couponList = new();
            ResponseDto? response = await _couponService.GetAllCoupons();
            if(response != null && response.IsSucess)
            {
                couponList = JsonConvert.DeserializeObject<List<CouponDto>>(response.Result.ToString());
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(couponList);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCoupon(couponDto);
                if (response != null && response.IsSucess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View();
        }

    
        public async Task<IActionResult> CouponDelete(int couponId)
        {

            ResponseDto? response = await _couponService.GetCouponById(couponId);
            if (response != null && response.IsSucess)
            {
                CouponDto? dto = JsonConvert.DeserializeObject<CouponDto>(response.Result.ToString());
                return View(dto);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _couponService.DeleteCoupon(couponDto.Id);
            if (response != null && response.IsSucess)
            {
                TempData["success"] = "coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View();
        }
    }
}
