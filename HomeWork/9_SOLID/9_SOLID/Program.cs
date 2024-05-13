
public partial class Program
{
    static void Main(string[] args)
    {
        var randomNumberGenerator = new AnotherRandomNumberGenerator(2);
        var inputValidator = new InputValidator();
        var gameEngine = new GameEngine(randomNumberGenerator, inputValidator);
        
        gameEngine.StartGame();
    }
}