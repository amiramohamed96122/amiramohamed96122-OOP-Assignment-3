namespace RefactoringLab;

public interface IShippingCarrier
{
    string Name { get; }
    decimal Calculate(decimal weightKg);
}

public class AramexCarrier : IShippingCarrier
{
    public string Name => "Aramex";

    public decimal Calculate(decimal weightKg) => weightKg * 12m;
}

public class FedExCarrier : IShippingCarrier
{
    public string Name => "FedEx";

    public decimal Calculate(decimal weightKg) => weightKg * 15m;
}

public class DhlCarrier : IShippingCarrier
{
    public string Name => "DHL";

    public decimal Calculate(decimal weightKg) => weightKg * 18m;
}
public class UpsCarrier : IShippingCarrier
{
    public string Name => "UPS";

    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 14m;
    }
}

public class ShippingCostCalculator
{
    private readonly IEnumerable<IShippingCarrier> _carriers;

    public ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
    {
        _carriers = carriers;
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        var selectedCarrier = _carriers.FirstOrDefault(c => c.Name.Equals(carrier, StringComparison.OrdinalIgnoreCase));

        if (selectedCarrier is null)
            throw new ArgumentException($"Unknown carrier: {carrier}");

        return selectedCarrier.Calculate(weightKg);
    }
}