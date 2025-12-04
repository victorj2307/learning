namespace Core;

public class InvoiceService
{
    private readonly PricingStrategyFactory _pricingStrategyFactory;
    private readonly IInvoiceRepository _repository;
    private readonly INotificationService _notifications;

    public InvoiceService(
        PricingStrategyFactory pricingStrategyFactory,
        IInvoiceRepository repository,
        INotificationService notifications)
    {
        _pricingStrategyFactory = pricingStrategyFactory;
        _repository = repository;
        _notifications = notifications;
    }

    public Guid CreateInvoice(string customerType, decimal amount)
    {
        var strategy = _pricingStrategyFactory.GetStrategy(customerType);
        var finalAmount = strategy.CalculateFinalAmount(amount);

        var id = Guid.NewGuid();

        var record = new InvoiceRecord(
            Id: id,
            CustomerType: customerType,
            Amount: amount,
            FinalAmount: finalAmount,
            CreatedAt: DateTime.UtcNow
        );

        // Save to persistence
        _repository.Save(record);

        // Trigger notifications
        _notifications.NotifyInvoiceCreated(id, customerType, amount, finalAmount);

        return id;
    }

    
}
