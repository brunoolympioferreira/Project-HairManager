using FluentMigrator;

namespace HairManager.Infra.Migrations.Versions;

[Migration((long)NumeroVersoes.CriarTabelaUsuario, "Cria tabela usuario")]
public class Versao0001 : Migration
{
    public override void Down() { }

    public override void Up()
    {
        var table = VersaoBase.InserirColunasPadrao(Create.Table("Usuario"));

        table
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("ConfirmeSenha").AsString(2000).NotNullable()
            .WithColumn("Status").AsBoolean().NotNullable();            
    }
}
