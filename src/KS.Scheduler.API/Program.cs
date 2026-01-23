using KS.Scheduler.Application.UseCases;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using KS.Scheduler.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KSSchedulerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<IPresencaRepository, PresencaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<CriarPartidaUseCase>();
builder.Services.AddScoped<ConfirmarPresencaUseCase>();
builder.Services.AddScoped<CancelarPresencaUseCase>();
builder.Services.AddScoped<ObterPartidaUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("LiberarGeral",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("LiberarGeral");
app.UseAuthorization();
app.MapControllers();

app.Run();