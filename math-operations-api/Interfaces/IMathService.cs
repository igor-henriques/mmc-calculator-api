namespace math_operations_api.Interfaces;

public interface IMathService
{
    string CalculateMMC(List<long> values);
    DescriptiveMMC CalculateMMC_WithDescription(List<long> values);
}