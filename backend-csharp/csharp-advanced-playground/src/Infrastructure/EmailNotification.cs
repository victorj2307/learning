using Core;

namespace Infrastructure;

public class EmailNotification : INotificationService
{
    public void NotifyInvoiceCreated(Guid invoiceId, string customerType, decimal amount, decimal finalAmount)
    {
        // In the real world this would call an email service. For the playground we'll output to console.
        Console.WriteLine($"[Notification] Email -> Invoice {invoiceId} created for {customerType}: {finalAmount} (original: {amount})");
    }
}
