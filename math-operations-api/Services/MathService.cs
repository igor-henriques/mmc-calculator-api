namespace math_operations_api.Services;

public class MathService : IMathService
{
    public string CalculateMMC(List<long> values)
    {
        long result = 1;
        long lastPrimeNumber = 2;

        while (values.Any(n => n != 1))
        {
            while (values.All(n => (float)n / (float)lastPrimeNumber % 1 > 0))
                lastPrimeNumber = GetNextPrime(lastPrimeNumber);

            bool getResultFlag = false;

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] is 1 | (float)values[i] / (float)lastPrimeNumber % 1 > 0)
                {
                    continue;
                }

                values[i] = values[i] / lastPrimeNumber;

                if (!getResultFlag)
                {
                    result *= lastPrimeNumber;
                    getResultFlag = true;
                }
            }
        }

        return result.ToString();
    }

    public DescriptiveMMC CalculateMMC_WithDescription(List<long> values)
    {
        StringBuilder sb = new StringBuilder();

        long result = 1;
        long lastPrimeNumber = 2;
        List<long> results = new();

        while (values.Any(n => n != 1))
        {
            while (values.All(n => (float)n / (float)lastPrimeNumber % 1 > 0))
                lastPrimeNumber = GetNextPrime(lastPrimeNumber);

            bool getResultFlag = false;

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] is 1 | (float)values[i] / (float)lastPrimeNumber % 1 > 0)
                {
                    continue;
                }

                sb.AppendLine(GetText(values));

                values[i] = values[i] / lastPrimeNumber;

                if (!getResultFlag)
                {
                    result *= lastPrimeNumber;

                    results.Add(lastPrimeNumber);

                    getResultFlag = true;
                }
            }
        }

        sb.AppendLine(GetText(values));

        return new DescriptiveMMC(sb.ToString(), string.Join(", ", results), result.ToString());
    }

    private bool IsPrime(long n)
    {
        if (n is 0) return false;

        var counter = 0;

        for (long i = 1; i <= n; i++)
        {
            if (n % i == 0)
                counter++;

            if (counter > 2) break;
        }

        return counter == 2;
    }

    private long GetNextPrime(long currentPrime = 0)
    {
        while (!IsPrime(++currentPrime)) { }

        return currentPrime;
    }

    private string GetText(List<long> n)
    {
        return string.Join(", ", n);
    }
}