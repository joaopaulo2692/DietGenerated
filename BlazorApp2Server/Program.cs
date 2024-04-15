using Blazor_MestreDetalhes.Data;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Blazor_MestreDetalhes.Service;
using Blazor_MestreDetalhes.Pages;
using Dieta.API.Repository;
using Dieta.API.Interfaces;
using Dieta.API.DietaContext;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<PedidoService2>();
builder.Services.AddScoped<AlimentoService>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<DietasDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("dietaConnection")));

builder.Services.AddScoped<IFoodRepository, AlimentoRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<IFoodRepository, AlimentoRepository>(client =>
{

    client.BaseAddress = new Uri("https://localhost:44370");
    client.DefaultRequestHeaders.Add("Accept", "application/+json");
});

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
