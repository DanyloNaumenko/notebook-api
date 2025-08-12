create table if not exists users (
    id uuid primary key not null,
    login text not null,
    password_hash text not null,
    is_active boolean not null default true
);

create table if not exists notes (
    id uuid primary key not null,
    title text not null,
    content text not null,
    creation_time timestamp not null,
    is_active boolean not null default true,
    user_id uuid not null references users(id)
);

create table if not exists sessions (
    id uuid primary key,
    user_id uuid not null references users(id),
    token text not null unique,
    created_at timestamp with time zone not null default timezone('utc', now()),
    expires_at timestamp with time zone not null,
    is_active boolean not null default true
);