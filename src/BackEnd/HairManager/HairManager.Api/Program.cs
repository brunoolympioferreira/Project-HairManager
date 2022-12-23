using HairManager.Api.Filtros;
using HairManager.Application;
using HairManager.Application.Utils.Automapper;
using HairManager.Domain.Extension;
using HairManager.Infra;
using HairManager.Infra.AcessoRepositories;
using HairManager.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepository(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperConfiguration());
}).CreateMapper());

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados()
{
    using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    using var context = serviceScope.ServiceProvider.GetService<HairManagerContext>();

    bool? databaseInMemory = context?.Database?.ProviderName?.Equals("Microsoft.EntityFrameworkCore.InMemory");

    if (!databaseInMemory.HasValue || !databaseInMemory.Value)
    {
        var conexao = builder.Configuration.GetConnection();
        var nomeDatabase = builder.Configuration.GetDatabaseName();

        Database.CriarDatabase(conexao, nomeDatabase);

        app.MigrateBancoDeDados();
    }
}

public partial class Program { }
