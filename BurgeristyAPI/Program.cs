using Burgeristy.BusinessLayer.Abstract;
using Burgeristy.BusinessLayer.Concrete;
using Burgeristy.DataAccessLayer.Abstract;
using Burgeristy.DataAccessLayer.Concrete;
using Burgeristy.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IBookingService,BookingManager>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<IProductDal,EfProductDal>();
builder.Services.AddScoped<IBookingDal,EfBookingDal>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();