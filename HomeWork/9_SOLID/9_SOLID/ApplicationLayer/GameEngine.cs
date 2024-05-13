public class GameEngine
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    private readonly InputValidator _inputValidator;

    public GameEngine(IRandomNumberGenerator randomNumberGenerator, InputValidator inputValidator)
    {
        _randomNumberGenerator = randomNumberGenerator;
        _inputValidator = inputValidator;
    }

    public void StartGame()
    {
        int maxAttempt = _inputValidator.GetValidNumber("Enter number of attempts ...");
        int maxNumber = _inputValidator.GetValidNumber("Enter maximum value to generate number ...");

        int neededNumber = _randomNumberGenerator.Generate(1, maxNumber);
        bool result = false;

        for (int i = 0; i < maxAttempt; i++)
        {
            int guess = _inputValidator.GetValidNumber("Enter your guess:");
            if (guess == neededNumber)
            {
                result = true;
                Console.WriteLine("Right. You won.");
                break;
            }
                
            Console.WriteLine(guess > neededNumber ? "Nope. Try to input a smaller value." : "Nope. Try to input a larger value.");
        }

        if (!result)
        {
            Console.WriteLine($"You lose. The number was {neededNumber}. Try again.");
        }
    }
}