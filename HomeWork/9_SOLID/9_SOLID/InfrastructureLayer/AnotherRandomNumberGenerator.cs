public class AnotherRandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new Random();
    private readonly double _bias;

    public AnotherRandomNumberGenerator(double bias)
    {
        _bias = bias;
    }

    public int Generate(int min, int max)
    {
        int result = _random.Next(min, max);
        return (int)((result + max * _bias) / (1 + _bias));
    }
}