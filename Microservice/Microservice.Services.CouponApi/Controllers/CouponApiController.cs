using AutoMapper;
using Microservice.Services.CouponApi.Data;
using Microservice.Services.CouponApi.Models;
using Microservice.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Microservice.Services.CouponApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CouponApiController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> Get()
        {
            var responseDto = new ResponseDto();
            try
            {
                var coupons = await _db.Coupons.ToListAsync();
                responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                responseDto.IsSucess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDto>> Get(int id)
        {
            var responseDto = new ResponseDto();
            try
            {
                var coupon = await _db.Coupons.FirstOrDefaultAsync(c => c.Id == id);
                if (coupon == null)
                {
                    responseDto.IsSucess = false;
                    responseDto.Message = "Coupon not found.";
                    return NotFound(responseDto);
                }

                responseDto.Result = _mapper.Map<CouponDto>(coupon);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                responseDto.IsSucess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto);
            }
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<ActionResult<ResponseDto>> GetByCode(string code)
        {
            var responseDto = new ResponseDto();
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    responseDto.IsSucess = false;
                    responseDto.Message = "Coupon code is required.";
                    return BadRequest(responseDto);
                }

                var coupon = await _db.Coupons
                    .FirstOrDefaultAsync(c => c.CouponCode.Equals(code, StringComparison.OrdinalIgnoreCase));

                if (coupon == null)
                {
                    responseDto.IsSucess = false;
                    responseDto.Message = "Coupon not found.";
                    return NotFound(responseDto);
                }

                responseDto.Result = _mapper.Map<CouponDto>(coupon);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                responseDto.IsSucess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> Post([FromBody] CouponDto couponDto)
        {
            var responseDto = new ResponseDto();
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(coupon);
                await _db.SaveChangesAsync();

                responseDto.Result = _mapper.Map<CouponDto>(coupon);
                return CreatedAtAction(nameof(Get), new { id = coupon.Id }, responseDto);
            }
            catch (Exception ex)
            {
                responseDto.IsSucess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDto>> Put([FromBody] CouponDto couponDto)
        {
            var responseDto = new ResponseDto();
            try
            {
                var existingCoupon = await _db.Coupons.FindAsync(couponDto.Id);
                if (existingCoupon == null)
                {
                    responseDto.IsSucess = false;
                    responseDto.Message = "Coupon not found.";
                    return NotFound(responseDto);
                }

                _mapper.Map(couponDto, existingCoupon);
                await _db.SaveChangesAsync();
                responseDto.Result = _mapper.Map<CouponDto>(existingCoupon);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                responseDto.IsSucess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDto>> Delete(int id)
        {
            var responseDto = new ResponseDto();
            try
            {
                var coupon = await _db.Coupons.FindAsync(id);
                if (coupon == null)
                {
                    responseDto.IsSucess = false;
                    responseDto.Message = "Coupon not found.";
                    return NotFound(responseDto);
                }

                _db.Coupons.Remove(coupon);
                await _db.SaveChangesAsync();
                responseDto.Result = _mapper.Map<CouponDto>(coupon);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                responseDto.IsSucess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto);
            }
        }
    }
}
