namespace math_operations_api.ViewModels;

public record DescriptiveMMC
{
    public string OperationDescription { get; private set; }
    public string ResultDescription { get; private set; }
    public string FinalResult { get; private set; }

    public DescriptiveMMC(string operationDescription, string resultDescription, string finalResult)
    {
        this.OperationDescription = operationDescription;
        this.ResultDescription = resultDescription;
        this.FinalResult = finalResult; 
    }
}