using FluentValidation;
using FluentValidation.AspNetCore;
using KanhaDairy.BAL.Validators;
using KanhaDairy.DAL.Data;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.DAL.Repositories;
using KanhaDairyAPI.AutoMapping;
using KanhaDairyAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ✅ Validation Field (BAL)
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ItemValidator>();
//builder.Services.AddValidatorsFromAssembly(typeof(ItemValidator).Assembly);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .Select(x => new
            {
                Field = x.Key,
                Errors = x.Value?.Errors.Select(e => e.ErrorMessage)
            });

        return new BadRequestObjectResult(new
        {
            Status = false,
            Message = "Validation Failed",
            Errors = errors
        });
    };
});
///================================================
// ✅ DbContext (DAL)
builder.Services.AddDbContext<KanhaDairyDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

// ✅ Generic Repository (DAL)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// ✅ BAL Services
builder.Services.AddBALServices();

// ✅ AutoMapper Services
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




// ✅ Swagger --Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ SeriLog -- Services Read config from appsettings.json
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// ✅ Middleware pipeline --Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<KanhaDairyAPI.Middleware.GlobalExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();
app.UseSerilogRequestLogging(); // logs all HTTP requests
app.Run();
   
