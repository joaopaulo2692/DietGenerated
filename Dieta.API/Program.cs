using AutoMapper;
using Dieta.API.DietaContext;
using Dieta.API.Repository;
using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DietasDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("dietaConnection")));


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<DietasDbContext>();

builder.Services.AddHttpClient();

//builder.Services.AddHttpClient<IAlimentoRepository, AlimentoRepository>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:44370");
//    client.DefaultRequestHeaders.Add("Accept", "application/+json");
//});
builder.Services.AddIdentity<Client, IdentityRole>()
    .AddEntityFrameworkStores<DietasDbContext>()
    .AddSignInManager<SignInManager<Client>>();

builder.Services.AddScoped<IFoodRepository,FoodRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();


builder.Services.AddControllers();

//builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();

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
