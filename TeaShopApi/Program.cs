using TeaShopApi.Business.Abstract;
using TeaShopApi.Business.Concrete;
using TeaShopApi.DataAccess.Abstract;
using TeaShopApi.DataAccess.Context;
using TeaShopApi.DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDrinkDal,EfDrinkDal>(); 
builder.Services.AddScoped<IDrinkService,DrinkManager>();

builder.Services.AddScoped<IQuestionDal, EfQuestionDal>();
builder.Services.AddScoped<IQuestionService,QuestionManager>();

builder.Services.AddScoped<IStaticticsDal, EfStatisticsDal>();
builder.Services.AddScoped<IStatisticService, StatisticsManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>(); 
builder.Services.AddScoped<ITestimonialService,TestimonialManager>();

builder.Services.AddScoped<IMessageDal,EfMessageDal>();
builder.Services.AddScoped<IMessageService,MessageManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddDbContext<TeaContext>();

builder.Services.AddMvc();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt =>
{
    opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
