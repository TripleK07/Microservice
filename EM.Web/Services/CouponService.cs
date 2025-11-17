using EM.Core.Models.Dto;
using EM.Web.Interfaces;
using EM.Web.Utilities;
using Newtonsoft.Json;

namespace EM.Web.Services
{
    public class CouponService : ICouponService
    {
        IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        
        public async Task<Boolean> CreateCouponAsync(CouponDto couponDto)
        {
            var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.POST,
                Data = couponDto,
                Url = Common.CouponAPIBase + "api/coupon"
            });
            return response.IsSuccess;
        }

        public async Task<Boolean> DeleteCouponAsync(int id)
        {
            var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.DELETE,
                Url = Common.CouponAPIBase + "api/coupon/" + id
            });
            return response.IsSuccess;
        }

        public async Task<List<CouponDto>> GetAllCouponsAsync()
        {
            var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.GET,
                Url = Common.CouponAPIBase + "api/coupon"
            });

            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                var resultList = JsonConvert.DeserializeObject<List<CouponDto>>(jsonResult);
                return resultList ?? new List<CouponDto>();
            }
            return new List<CouponDto>();
        }

        public async Task<CouponDto> GetCouponByIdAsync(int id)
        {
            var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.GET,
                Url = Common.CouponAPIBase + "api/coupon/" + id
            });

            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                var result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
                return result;
            }
            return null;
        }


        public async Task<CouponDto> GetCouponByCouponCodeAsync(string couponCode)
        {
            var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.GET,
                Url = Common.CouponAPIBase + "api/coupon/GetByCode/" + couponCode
            });  

            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                var result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
                return result;
            }
            return null;  
        }

        public async Task<Boolean> UpdateCouponAsync(CouponDto couponDto)
        {
            var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.PUT,
                Data = couponDto,
                Url = Common.CouponAPIBase + "api/coupon"
            });

            return response.IsSuccess;
        }
    }
}