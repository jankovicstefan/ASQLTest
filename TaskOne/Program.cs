using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter the path (e.g. D:/DirName/SubDirName...) \nOr enter 'c' for current directory: ");
                string path = Console.ReadLine();
                FileSerach fs = new FileSerach();
                List<String> files = fs.GetAllExecutableFiles(path);

                if (files.Count > 0)
                {
                    Console.WriteLine("\nExecutable files:");
                    foreach (var file in files)
                    {
                        Console.WriteLine(" - " + file);
                    }
                }
                else
                {
                    Console.WriteLine("This directory does not contain executable files with extensions .exe, .bat or .com");
                }
                Console.Write("\nContinue(y/n)?: ");
                if (Console.ReadLine() != "y")
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
