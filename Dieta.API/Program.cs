using AutoMapper;
using Dieta.API.Extensions;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using Dieta.Infrastructure.DietaContext;
using Dieta.Infrastructure.Repository;
using Dieta.Infrastructure.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("dietaConnection")));




builder.Services.AddHttpClient();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>();

//void ConfigureServices(IServiceCollection services)
//{ 
//    services.AddRepositories();
//    services.AddServices();
//}
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDietService, DietService>();

//builder.Services.AddScoped<IFoodRepository,FoodRepository>();
//builder.Services.AddScoped<IUserRepository,UserRepository>();
//builder.Services.AddScoped<IDietRepository,DietRepository>();
//builder.Services.AddScoped<IFoodService, FoodService>();


builder.Services.AddControllers();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
app.UseAuthentication();

app.MapControllers();

app.Run();
