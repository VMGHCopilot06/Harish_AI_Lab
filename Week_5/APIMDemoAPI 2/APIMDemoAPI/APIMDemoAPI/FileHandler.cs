using System;
using System.IO;

namespace APIMDemoAPI
{
    public class FileHandler
    {
        public static void CopyFile(string sourceFilePath, string destinationDirectory)
        {
            try
            {
                // Print the full paths for debugging
                Console.WriteLine($"Source File Path: {Path.GetFullPath(sourceFilePath)}");
                Console.WriteLine($"Destination Directory: {Path.GetFullPath(destinationDirectory)}");

                // Check if the source file exists
                if (!File.Exists(sourceFilePath))
                {
                    throw new FileNotFoundException("The source file does not exist.", sourceFilePath);
                }

                // Check if the destination directory exists, if not, create it
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                    Console.WriteLine("Destination directory created.");
                }

                // Construct the destination file path
                string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(sourceFilePath));

                // Copy the file to the destination
                File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                Console.WriteLine("File copied successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.FileName}");
                System.Diagnostics.Debugger.Break(); // Break into the debugger
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
                System.Diagnostics.Debugger.Break(); // Break into the debugger
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                System.Diagnostics.Debugger.Break(); // Break into the debugger
            }
        }

        public static void Main(string[] args)
        {
            string sourceFilePath = "path/to/your/sourceFile.txt";
            string destinationDirectory = "path/to/your/destinationDirectory";

            CopyFile(sourceFilePath, destinationDirectory);
        }
    }
}
