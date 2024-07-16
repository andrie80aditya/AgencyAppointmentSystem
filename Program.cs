using AgencyAppointmentSystem.Services;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using AgencyAppointmentSystem.Data;
using Microsoft.EntityFrameworkCore;
using AgencyAppointmentSystem.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AppointmentsDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Autofac configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // Register repositories
    containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
    
    // Register services here
    containerBuilder.RegisterType<AppointmentService>().As<IAppointmentService>();
    containerBuilder.RegisterType<HolidayService>().As<IHolidayService>();
    containerBuilder.RegisterType<AppointmentSettingsService>().As<IAppointmentSettingsService>();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agency Appointment System", Version = "v1" });
});

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
