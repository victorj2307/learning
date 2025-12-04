namespace Core;

public class PricingStrategyFactory
{
    private readonly Dictionary<string, IPricingStrategy> _strategies;

    public PricingStrategyFactory(IEnumerable<IPricingStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(
            s => s.CustomerType.ToLower(),
            s => s
        );
    }

    public IPricingStrategy GetStrategy(string customerType)
    {
        var normalizedType = customerType.ToLower();
        
        if (!_strategies.TryGetValue(normalizedType, out var strategy))
        {
            throw new ArgumentException(
                $"Unknown customer type: {customerType}"
            );
        }

        return strategy;
    }
}
