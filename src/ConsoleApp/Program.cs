
using ConsoleApp;
using System.Diagnostics;
using System.Drawing;

partial class Program
{
    static void Main(string[] args)
    {
        //var directory = Directory.GetCurrentDirectory();
        //Console.WriteLine(directory); // ConsoleApp\\bin\\Debug\\net10.0

        ///// Use Path.Combine to change the path to the parent directory
        //var parentDirectory = Path.Combine(directory, "../../..");

        //// Use Path.GetFullPath to resolve the parent directory path
        //parentDirectory = Path.GetFullPath(parentDirectory);
        //Console.WriteLine(parentDirectory); // ConsoleApp


        File.SayHello("Introduction.pdf");

        Color.GreenSmile();
    }
}
