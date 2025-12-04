namespace Core;

public class WholesalePricing : IPricingStrategy
{
    public string CustomerType => "wholesale";
    public decimal CalculateFinalAmount(decimal amount)
        => amount * 0.7m; // 30% discount
}
