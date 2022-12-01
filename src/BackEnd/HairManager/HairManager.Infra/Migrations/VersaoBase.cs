using FluentMigrator.Builders.Create.Table;

namespace HairManager.Infra.Migrations
{
    public static class VersaoBase
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax InserirColunasPadrao(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
        {
            return table
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Created_At").AsDateTime().NotNullable()
                .WithColumn("Updated_At").AsDateTime().NotNullable();
        }
    }
}
