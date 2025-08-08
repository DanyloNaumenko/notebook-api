using FluentMigrator;

namespace Notebook.Postgres.Migrations;

[Migration(20250807_1)]
public class Migration_20250807_1 :  Migration
{
    public override void Up()
    {
        var sql = $@"
                    create table if not exists sessions (
                    id uuid primary key,
                    user_id uuid not null references users(id),
                    token text not null unique,
                    created_at timestamp with time zone not null default timezone('utc', now()),
                    expires_at timestamp with time zone not null,
                    is_active boolean not null default true
                );
                ";       
        Execute.Sql(sql);
    }

    public override void Down()
    {
        var sql = "drop table if exists sessions";
        Execute.Sql(sql);
    }
}