/*
using CoreDemo.SolidExamples.Notifications;
using CoreDemo.SolidExamples.Persistence;
using CoreDemo.SolidExamples.PricingStrategies;
using CoreDemo.SolidExamples.Services;

Console.WriteLine("=== Invoice Generator (SOLID Playground) ===");

// 1. Setup dependencies manually (later we'll add real DI)
var pricingFactory = new PricingStrategyFactory();
var repository = new InvoiceRepository();
var notifier = new EmailNotification();

var invoiceService = new InvoiceService(
    pricingFactory,
    repository,
    notifier
);

// 2. Execute a sample workflow
Console.WriteLine("Creating invoices...\n");

var id1 = invoiceService.CreateInvoice("regular", 100);
var id2 = invoiceService.CreateInvoice("vip", 200);
var id3 = invoiceService.CreateInvoice("wholesale", 500);

Console.WriteLine("\nDone!");
Console.WriteLine($"Created invoices: {id1}, {id2}, {id3}");
*/

/*
using Core;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register Pricing Strategies
services.AddSingleton<PricingStrategyFactory>();

// Register Repository
services.AddSingleton<IInvoiceRepository, InvoiceRepository>();

// Register Notification Service
services.AddSingleton<INotificationService, EmailNotification>();

// Register Orchestrator
services.AddSingleton<InvoiceService>();

// Register the Use Case
builder.Services.AddTransient<InvoiceUseCase>();

var provider = services.BuildServiceProvider();

var invoiceService = provider.GetRequiredService<InvoiceService>();

Console.WriteLine("=== Invoice Generator with DI ===\n");

invoiceService.CreateInvoice("regular", 100);
invoiceService.CreateInvoice("vip", 250);
invoiceService.CreateInvoice("wholesale", 500);

Console.WriteLine("\nDone with DI!");
*/

using AppHost.UseCases;
using Core;
using Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

// Pricing Strategies
builder.Services.AddSingleton<IPricingStrategy, RegularPricing>();
builder.Services.AddSingleton<IPricingStrategy, VipPricing>();
builder.Services.AddSingleton<IPricingStrategy, PremiumPricing>();
builder.Services.AddSingleton<IPricingStrategy, WholesalePricing>();

// Factory (will receive strategies via constructor injection)
builder.Services.AddSingleton<PricingStrategyFactory>();

// Domain Service
builder.Services.AddSingleton<InvoiceService>();

// Infrastructure Implementations
builder.Services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddSingleton<INotificationService, EmailNotification>();

// Use Cases
builder.Services.AddTransient<InvoiceUseCase>();

var host = builder.Build();

// Resolve and run the use case
var app = host.Services.GetRequiredService<InvoiceUseCase>();
app.Run();
