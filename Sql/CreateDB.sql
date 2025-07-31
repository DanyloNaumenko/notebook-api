create extension if not exists "uuid-ossp";

create table if not exists users (
    id uuid primary key,
    login text not null unique,
    passwordhash text not null
);

create table if not exists notes (
    id uuid primary key,
    title text not null,
    content text not null,
    creationtime timestamp not null,
    userid uuid not null
);

alter table notes drop constraint if exists notes_userid_fkey;

alter table notes
add constraint notes_userid_fkey
foreign key (userid)
references users(id);