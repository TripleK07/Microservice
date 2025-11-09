using AutoMapper;
using EM.Core.Models.Dto;
using EM.Services.CouponAPI.Data;
using EM.Services.CouponAPI.Helper;
using EM.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EM.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponController(AppDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public IActionResult Get() {
            IEnumerable<Coupon> objList = _db.Coupons.ToList();
            var data = _mapper.Map<List<CouponDto>>(objList);

            if (data.Any())
            {
                _response.Result = data;
                _response.IsSuccess = true;
                return Ok(_response);
            }

            _response.IsSuccess = false;
            _response.Message = "No data found";
            return NotFound(_response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            Coupon coupon = _db.Coupons.Find(id);
            var data = _mapper.Map<CouponDto>(coupon);
            if (!data.IsNull())
            {
                _response.Result = data;
                _response.IsSuccess = true;
                return Ok(_response);
            }

            _response.IsSuccess = false;
            _response.Message = "No data found";
            return NotFound(_response);
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public IActionResult GetByCode(string code)
        {
            Coupon coupon = _db.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
            var data = _mapper.Map<CouponDto>(coupon);
            if (!data.IsNull())
            {
                _response.Result = data;
                _response.IsSuccess = true;
                return Ok(_response);
            }

            _response.IsSuccess = false;
            _response.Message = "No data found";
            return NotFound(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                coupon.CouponId = 0;
                _db.Coupons.Add(coupon);
                await _db.SaveChangesAsync();

                _response.IsSuccess = true;
                _response.Result = coupon;
                return Created("Get", _response);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException.Message, null, 500, "Internal Server Error", "Unexpected exception");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                 _db.Coupons.Update(coupon);
                await _db.SaveChangesAsync();

                _response.IsSuccess = true;
                _response.Result = coupon;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException.Message, null, 500, "Internal Server Error", "Unexpected exception");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var coupon = _db.Coupons.Find(id);

                if (coupon.IsNull())
                    return NotFound();

                _db.Coupons.Remove(coupon);
                await _db.SaveChangesAsync();

                _response.IsSuccess = true;
                _response.Result = coupon;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException.Message, null, 500, "Internal Server Error", "Unexpected exception");
            }
        }
    }
}
