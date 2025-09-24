using AutoMapper;
using Microservice.Services.CouponApi.Data;
using Microservice.Services.CouponApi.Models;
using Microservice.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;


namespace Microservice.Services.CouponApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponApiController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons); ;
            }
            catch (Exception ex)
            {                
                _responseDto.IsSucess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(coupon=>coupon.Id==id);                
                _responseDto.Result = _mapper.Map<CouponDto>(coupon); 
            }
            catch (Exception ex)
            {
                _responseDto.IsSucess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(coupon => coupon.CouponCode.ToLower() == code.ToLower());
                if(coupon == null)
                {
                    _responseDto.IsSucess = false;
                }
                _responseDto.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responseDto.IsSucess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]        
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                _db.Coupons.Add(_mapper.Map<Coupon>(couponDto));
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(couponDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSucess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                _db.Coupons.Update(_mapper.Map<Coupon>(couponDto));
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(couponDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSucess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var coupon = _db.Coupons.Find(id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();                
            }
            catch (Exception ex)
            {
                _responseDto.IsSucess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
