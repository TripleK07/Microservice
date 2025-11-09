namespace EM.Services.CouponAPI.Helper
{
    public static class ObjectExtensions
    {
        public static bool IsNull<T>(this T obj) where T : class
            => obj == null;
    }
}
