using EM.Core.Models.Dto;
using EM.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EM.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ILogger<CouponController> _logger;
        private readonly ICouponService _couponService;

        public CouponController(ILogger<CouponController> logger, ICouponService couponService)
        {
            _logger = logger;
            _couponService = couponService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllCoupons()
        {
            var response = await _couponService.GetAllCouponsAsync();
            return PartialView("_CouponTable", response);
        }

        public IActionResult Create()
        {
            return PartialView("_Create", new CouponDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _couponService.CreateCouponAsync(couponDto);
                if (response)
                {
                    return Json(new { isSuccess = true, message = "Coupon created successfully" });
                }
            }
            return Json(new { isSuccess = false, message = "Error while creating coupon" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _couponService.GetCouponByIdAsync(id);
            if (response != null)
            {
                return PartialView("_Create", response);
            }
            return PartialView("_Create", new CouponDto());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _couponService.UpdateCouponAsync(couponDto);
                if (response)
                {
                    return Json(new { isSuccess = true, message = "Coupon updated successfully" });
                }
            }
            return Json(new { isSuccess = false, message = "Error while updating coupon" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _couponService.DeleteCouponAsync(id);
            if(response)
            {
                return Json(new { isSuccess = true, message = "Coupon deleted successfully" });
            }
            return Json(new { isSuccess = false, message = "Error while deleting coupon" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}