using FluentMigrator;
using FluentMigrator.Postgres;

namespace Notebook.Postgres.Migrations;

[Migration(202507311_1)]
public class Migration_20250731_1 : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            create table if not exists users (
                id uuid primary key,
                login text not null unique,
                password_hash text not null
            );

            create table if not exists notes (
                id uuid primary key,
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