using AutoMapper;
using Dieta.API.DietaContext;
using Dieta.API.Interfaces;
using Dieta.API.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DietasDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("dietaConnection")));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DietasDbContext>();
//static ServiceProvider RegistrarServices()
//{
//    var services = new ServiceCollection();
//    services.AddSingleton<IAlimentoRepository, AlimentoRepository>();
//    services.AddSingleton<IMapper, Mapper>();
//    services.AddTransient<Controller>();
//    return services.BuildServiceProvider();
//}
builder.Services.AddHttpClient();

//builder.Services.AddHttpClient<IAlimentoRepository, AlimentoRepository>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:44370");
//    client.DefaultRequestHeaders.Add("Accept", "application/+json");
//});

builder.Services.AddScoped<IFoodRepository,AlimentoRepository>();


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

app.MapControllers();

app.Run();
