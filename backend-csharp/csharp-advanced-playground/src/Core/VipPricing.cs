namespace Core;

public class VipPricing : IPricingStrategy
{
    public string CustomerType => "vip";
    public decimal CalculateFinalAmount(decimal amount) => amount * 0.8m;
}
