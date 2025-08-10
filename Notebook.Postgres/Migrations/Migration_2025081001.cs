using FluentMigrator;

namespace Notebook.Postgres.Migrations;

[Migration(2025081001)]
public class Migration_2025081001 : Migration
{
    public override void Up()
    {
        var sql = @"
                ALTER TABLE users
                ADD COLUMN is_active boolean DEFAULT true not null;
            ";
        Execute.Sql(sql);
    }

    public override void Down()
    {
        var sql = @"
                ALTER TABLE users
                DROP COLUMN is_active";
        
        Execute.Sql(sql);
    }
}