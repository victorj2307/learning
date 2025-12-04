namespace Core;

public interface IPricingStrategy
{
    string CustomerType { get; }
    decimal CalculateFinalAmount(decimal amount);
}
