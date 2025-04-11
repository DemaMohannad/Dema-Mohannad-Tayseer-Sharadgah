using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Biding.Application;
using Biding.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = builder.Configuration;
builder.Services.AddDbContext<BidingDbContext>((serviceProvider, options) =>
{ options.UseSqlServer(Configuration.GetConnectionString("DBConnection")); }, ServiceLifetime.Transient);
// Add services to the container.

builder.Services.AddScoped<DbContext>(provider => provider.GetService<BidingDbContext>());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITenderService, TenderService>();
builder.Services.AddScoped<IBidService,BidService>();
builder.Services.AddScoped<IEvaluationService,EvaluationService>();
builder.Services.AddScoped<ITenderTypeService,TenderTypeService>();
builder.Services.AddScoped<ITenderCategoryService,TenderCategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
