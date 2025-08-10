using FluentMigrator;
using FluentMigrator.Postgres;

namespace Notebook.Postgres.Migrations;

[Migration(20250731101)]
public class Migration_2025073101 : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            create table if not exists users (
                id uuid primary key not null,
                login text not null,
                password_hash text not null
            );

            create table if not exists notes (
                id uuid primary key not null,
                title text not null,
                content text not null,
                creation_time timestamp with time zone not null,
                user_id uuid not null references users(id)
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql(@"
            drop table if exists notes;
            drop table if exists users;
        ");
    }
}