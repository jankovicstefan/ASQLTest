using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskOne
{
    class FileSerach
    {
        public List<String> files = new List<string>();        
        public List<String> options = new List<string>();
        
        public void FileSearch()
        {
            files = null;
        }

            /// <summary>
            /// This function filters data, of specific directory or current directory,
            /// with specific extensions and writes it in the list. 
            /// For current directory please type 'C' or 'c' in console.
            /// </summary>
            /// <param name="path"></param>
            /// <returns> 
            /// List with executable files (as string) of 
            /// specific directory given by path or current directory
            /// </returns>
        public List<String> GetAllExecutableFiles(String path)
        {
            options.Add("*.exe");
            options.Add("*.com");
            options.Add("*.bat");

            if (Directory.Exists(path))
            {
                foreach (String opt in options)
                {
                    foreach (String file in Directory.GetFiles(path, opt)) 
                    { 
                        DirectoryInfo dirInfo = new DirectoryInfo(file);
                        files.Add(dirInfo.Name);
                    } 
                }
            } 
            else if (path == "c" || path == "C")
            {
                foreach (String opt in options)
                {
                    foreach (String file in Directory.GetFiles(Directory.GetCurrentDirectory(),opt))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(file);
                        files.Add(dirInfo.Name);
                    }
                }
            }
            else
            {
                Console.WriteLine("Directory does not exists! Please check entered path!");
                
            }
            return files;
        }
    }
}
