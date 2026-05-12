using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp
{
    public static class FileExtension
    {
        extension(File)
        {
            public static void SayHello(string fileName)
            {
                Console.WriteLine($"Hello File: {fileName}");
            }
        }
    }
    public static class ColorExtension
    {
        extension(Color)
        {
            public static Color GreenSmile()
            {
                return Color.FromArgb(83, 255, 26);
            }
        }
    }

}
