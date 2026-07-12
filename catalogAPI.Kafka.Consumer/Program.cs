// See https://aka.ms/new-console-template for more information

using catalogAPI.Consumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
{
    services.AddHostedService<ConsumerService>();
}).Build();

await host.RunAsync();