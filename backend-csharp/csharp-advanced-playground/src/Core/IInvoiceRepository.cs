namespace Core;

public record InvoiceRecord(Guid Id, string CustomerType, decimal Amount, decimal FinalAmount, DateTime CreatedAt);

public interface IInvoiceRepository
{
    void Save(InvoiceRecord invoice);
    InvoiceRecord? GetById(Guid id);
}
