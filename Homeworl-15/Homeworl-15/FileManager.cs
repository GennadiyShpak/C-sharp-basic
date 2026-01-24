using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homeworl_15;

internal class FileManager
{
    public string GetInputFilePath()
    {
        Console.WriteLine("Please provide path to file");

        var fileLocation = Console.ReadLine();

        if (IsPathValid(fileLocation) && File.Exists(fileLocation))
        {
            return fileLocation;
        }
        else
        {
            Console.WriteLine("Your path invalid");
            return GetInputFilePath();
        }
    }

    public string GetOutputFilePath()
    {
        Console.WriteLine("Please provide path to target file");

        var fileLocation = Console.ReadLine();

        if (IsPathValid(fileLocation))
        {
            return fileLocation;
        }
        else
        {
            Console.WriteLine("Your path invalid");
            return GetOutputFilePath();
        }
    }

    public void CopyFile(string inputPath, string OutputPath)
    {
        File.Copy(inputPath, OutputPath, true);
    }

    public void CopyFileUsingStream(string inputPath, string outputPath)
    {
        using (StreamReader reader = new StreamReader(inputPath))
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
        }
    }

    private bool IsPathValid(string fileLocation)
    {
        try
        {
            Path.GetFullPath(fileLocation);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
