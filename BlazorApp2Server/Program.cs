using Blazor_MestreDetalhes.Data;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Blazor_MestreDetalhes.Service;
using Blazor_MestreDetalhes.Pages;
using Dieta.Infrastructure.Repository;
using Dieta.Infrastructure.DietaContext;
using Microsoft.EntityFrameworkCore;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Radzen;
using Dieta.API.Controllers;
using Microsoft.AspNetCore.Hosting;
using Dieta.Core.Interfaces.Service;
using Dieta.Infrastructure.Service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("dietaConnection")));
builder.Services.AddHttpClient();


builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDietService, DietService>();

builder.Services.AddScoped<UserController>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<PedidoService2>();
builder.Services.AddScoped<AlimentoService>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("dietaConnection")));


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>();
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Configurações de identidade, se necessário
//});

//builder.Services.AddScoped<IFoodRepository, FoodRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<SignInManager<ApplicationUser>>();

//builder.Services.AddHttpClient<IFoodRepository, FoodRepository>(client =>
//{

//    client.BaseAddress = new Uri("https://localhost:44370");
//    client.DefaultRequestHeaders.Add("Accept", "application/+json");
//});


builder.Services.AddRadzenComponents();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
