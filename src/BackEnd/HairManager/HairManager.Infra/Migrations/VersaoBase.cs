using FluentMigrator.Builders.Create.Table;

namespace HairManager.Infra.Migrations
{
    public static class VersaoBase
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax InserirColunasPadrao(ICreateTableWithColumnOrSchemaOrDescriptionSyntax tabela)
        {
            return tabela
                .WithColumn("Id").AsGuid().PrimaryKey().Identity()
                .WithColumn("Created_At").AsDateTime().NotNullable()
                .WithColumn("Updated_At").AsDateTime().NotNullable();
        }
    }
}
