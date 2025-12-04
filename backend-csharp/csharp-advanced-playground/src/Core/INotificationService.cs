namespace Core;

public interface INotificationService
{
    void NotifyInvoiceCreated(Guid invoiceId, string customerType, decimal amount, decimal finalAmount);
}
