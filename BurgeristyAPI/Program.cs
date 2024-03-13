using Burgeristy.BusinessLayer.Abstract;
using Burgeristy.BusinessLayer.Concrete;
using Burgeristy.DataAccessLayer.Abstract;
using Burgeristy.DataAccessLayer.Concrete;
using Burgeristy.DataAccessLayer.EntityFramework;
using BurgeristyAPI.Hubs;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IBookingService,BookingManager>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<IProductDal,EfProductDal>();
builder.Services.AddScoped<IBookingDal,EfBookingDal>();
builder.Services.AddSignalR();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
app.Run();
