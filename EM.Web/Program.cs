using EM.Web.Service;
using EM.Web.Service.IService;
using EM.Web.Services.Interfaces;
using EM.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);
Common.CouponAPIBase = builder.Configuration.GetValue<string>("ServiceUrls:CouponAPI");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IBaseService, BaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Coupon}/{action=Index}/{id?}");

app.Run();
