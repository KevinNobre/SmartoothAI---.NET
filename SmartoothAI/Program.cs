using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Data;
using SmartoothAI.Infrastructure.Repositories;
using SmartoothAI.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmartoothDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
