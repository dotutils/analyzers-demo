namespace DotUtils;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Give a space separated list of numbers to sum:");
        Calculator.Sum(Console.ReadLine()!.Split());
        Console.WriteLine($"Result: " );
    }
}