using EM.Core.Models.Dto;

namespace EM.Web.Interfaces
{
    public interface ICouponService
    {
        Task<List<CouponDto>> GetAllCouponsAsync();
        Task<CouponDto> GetCouponByIdAsync(int id);
        Task<CouponDto> GetCouponByCouponCodeAsync(string couponCode);
        Task<Boolean> CreateCouponAsync(CouponDto couponDto);
        Task<Boolean> UpdateCouponAsync(CouponDto couponDto);
        Task<Boolean> DeleteCouponAsync(int id);
    }
}