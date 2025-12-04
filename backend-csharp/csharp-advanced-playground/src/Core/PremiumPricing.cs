namespace Core;

public class PremiumPricing : IPricingStrategy
{
    public string CustomerType => "premium";
    public decimal CalculateFinalAmount(decimal amount) => amount * 0.9m;
}
