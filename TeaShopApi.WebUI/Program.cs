using TeaShopApi.Business.Abstract;
using TeaShopApi.Business.Concrete;
using TeaShopApi.DataAccess.Abstract;
using TeaShopApi.DataAccess.Context;
using TeaShopApi.DataAccess.EntityFramework;
using TeaShopApi.Entity.Concrete;
using TeaShopApi.WebUI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TeaContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IMessageDal,EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<TeaContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
