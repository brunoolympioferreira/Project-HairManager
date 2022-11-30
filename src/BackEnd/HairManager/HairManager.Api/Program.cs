using HairManager.Domain.Extension;
using HairManager.Infra;
using HairManager.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepository(builder.Configuration);

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

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados()
{
    var conexao = builder.Configuration.GetConnection();
    var nomeDatabase = builder.Configuration.GetDatabaseName();

    Database.CriarDatabase(conexao, nomeDatabase);

    //app.MigrateBancoDeDados();
}

public partial class Program { }
