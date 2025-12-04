namespace Core;

public class RegularPricing : IPricingStrategy
{
    public string CustomerType => "regular";
    public decimal CalculateFinalAmount(decimal amount) => amount;
}
