using CSVConvert;
using test;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddCsvConverter();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
