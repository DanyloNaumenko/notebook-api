// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Notebook.Postgres;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("Postgres");
    


    