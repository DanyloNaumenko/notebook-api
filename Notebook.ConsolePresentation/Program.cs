// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;

var connection = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
    