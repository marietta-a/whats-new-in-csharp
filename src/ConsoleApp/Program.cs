
using ConsoleApp;
using System.Diagnostics;
using System.Drawing;

partial class Program
{
    static void Main(string[] args)
    {
        var stackOverflow = new StackOverflow();
        try
        {
            stackOverflow.AssignValue();
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
