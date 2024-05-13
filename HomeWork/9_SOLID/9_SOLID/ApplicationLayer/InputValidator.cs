public class InputValidator
{
    public int GetValidNumber(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        int number;

        while (!int.TryParse(input, out number))
        {
            Console.WriteLine("Cannot parse the input. Please try to enter a correct number.");
            input = Console.ReadLine();
        }

        return number;
    }
}