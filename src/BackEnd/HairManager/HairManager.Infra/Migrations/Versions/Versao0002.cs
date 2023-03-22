﻿using FluentMigrator;

namespace HairManager.Infra.Migrations.Versions;

[Migration((long)NumeroVersoes.CriarTabelaFuncionarios, "Cria tabela funcionarios")]
public class Versao0002 : Migration
{
    public override void Down() { }

    public override void Up()
    {
        CriarTabelaEnderecos();
        CriarTabelaFuncionarios();
    }

    private void CriarTabelaEnderecos()
    {
        var table = VersaoBase.InserirColunasPadrao(Create.Table("Enderecos"));

        table
            .WithColumn("Rua").AsString(100).NotNullable()
            .WithColumn("Numero").AsString(5).NotNullable()
            .WithColumn("Complemento").AsString(50).Nullable()
            .WithColumn("Bairro").AsString(50).NotNullable()
            .WithColumn("Cidade").AsString(50).NotNullable()
            .WithColumn("Estado").AsString(25).NotNullable()
            .WithColumn("Pais").AsString(25).NotNullable();
    }

    private void CriarTabelaFuncionarios()
    {
        var table = VersaoBase.InserirColunasPadrao(Create.Table("Funcionarios"));

     table
        .WithColumn("Nome").AsString(100).NotNullable()
        .WithColumn("Telefone").AsString(20).NotNullable()
        .WithColumn("Data_Nascimento").AsDate().NotNullable()
        .WithColumn("Nacionalidade").AsString(20).NotNullable()
        .WithColumn("EnderecoId").AsInt64().NotNullable().ForeignKey("FK_Funcionario_Endereco_Id","Funcionarios", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
        .WithColumn("CTPS_Numero").AsString(10).NotNullable()
        .WithColumn("CTPS_Serie").AsString(10).NotNullable()
        .WithColumn("CPF").AsString(11).NotNullable()
        .WithColumn("RG").AsString(10).NotNullable()
        .WithColumn("PIS").AsString(15).NotNullable()
        .WithColumn("Reservista").AsString(15).NotNullable()
        .WithColumn("Cargo").AsString(20).NotNullable()
        .WithColumn("Salario").AsDecimal().NotNullable()
        .WithColumn("Estado_Civil").AsDecimal().NotNullable()
        .WithColumn("Data_Admissao").AsDate().NotNullable()
        .WithColumn("Data_Demissao").AsDate().Nullable()
        .WithColumn("Status").AsString().NotNullable()
        .WithColumn("Vencimento_Ferias").AsDate().NotNullable();
    }
}