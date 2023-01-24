using Proxx.ConsoleView;
using Proxx.Domain;

internal static class Program
{
    private static void Main()
    {
        GameRunner.RunGameWithSquareField(new ConsoleGameWithSquareFieldIO());
        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();
    }
}
