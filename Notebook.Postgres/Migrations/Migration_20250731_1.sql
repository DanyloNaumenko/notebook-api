create extension if not exists "uuid-ossp";

create table if not exists users (
    id uuid primary key DEFAULT uuid_generate_v4(),
    login text not null unique,
    password_hash text not null
);

create table if not exists notes (
    id uuid primary key default uuid_generate_v4(),
    title text not null,
    content text not null,
    creation_time timestamp not null,
    user_id uuid not null,
    constraint notes_userid_fkey foreign key (user_id) references users(id)
);