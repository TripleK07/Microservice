using AutoMapper;
using EM.Core.Models.Dto;
using EM.Services.CouponAPI.Models;

namespace EM.Services.CouponAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponDto>();
            CreateMap<CouponDto, Coupon>();
        }
    }
}
