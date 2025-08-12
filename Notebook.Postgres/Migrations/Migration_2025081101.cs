using FluentMigrator;

namespace Notebook.Postgres.Migrations;

[Migration(2025081101)] 
public class Migration_2025081101 : Migration
{
    public override void Up()
    {
        var sql = @"ALTER TABLE notes 
                    ADD COLUMN is_active boolean not null 
                    DEFAULT true;";
        
        Execute.Sql(sql);
    }

    public override void Down()
    {
        var sql = @"ALTER TABLE notes DROP COLUMN is_active;";
        Execute.Sql(sql);
    }
}