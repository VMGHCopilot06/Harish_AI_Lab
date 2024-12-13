using System;
using System.IO;

namespace APIMDemoAPI
{
    public class FileUploader
    {
        public static void UploadFile(string sourceFilePath)
        {
            string destinationDirectory = @"C:\tmp";
            string fileName = Path.GetFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(destinationDirectory, fileName);

            try
            {
                // Ensure the destination directory exists
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Copy the file to the destination directory
                File.Copy(sourceFilePath, destinationFilePath, true);
                Console.WriteLine($"File uploaded successfully to {destinationFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
