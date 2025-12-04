using Core;

namespace AppHost.UseCases;

public class InvoiceUseCase
{
    private readonly InvoiceService _invoiceService;

    public InvoiceUseCase(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public void Run()
    {
        Console.WriteLine("Running Invoice Use Case...");

        string customerType = "regular";
        decimal amount = 150m;

        var invoiceId = _invoiceService.CreateInvoice(customerType, amount);

        Console.WriteLine($"Invoice created successfully:");
        Console.WriteLine($" - InvoiceId: {invoiceId}");
        Console.WriteLine($" - CustomerType: {customerType}");
        Console.WriteLine($" - Amount: {amount}");
    }
}
