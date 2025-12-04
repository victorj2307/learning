using System.Collections.Concurrent;
using Core;

namespace Infrastructure;

public class InvoiceRepository : IInvoiceRepository
{
    // Simple thread-safe in-memory store for learning
    private readonly ConcurrentDictionary<Guid, InvoiceRecord> _store = new();

    public void Save(InvoiceRecord invoice)
    {
        _store[invoice.Id] = invoice;
        Console.WriteLine($"[Persistence] Invoice saved: {invoice.Id} (final={invoice.FinalAmount})");
    }

    public InvoiceRecord? GetById(Guid id)
    {
        _store.TryGetValue(id, out var record);
        return record;
    }
}
