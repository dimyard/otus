namespace DelegatesProject.Presentation;

using DelegatesProject.Application.Services;
using DelegatesProject.Core.Models;
using DelegatesProject.Extensions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ready.");
        string sampleFilesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SampleFiles");
        
        if (!Directory.Exists(sampleFilesDirectory))
        {
            Console.WriteLine("Sample files directory not found.");
            return;
        }

        var files = new List<string>(Directory.GetFiles(sampleFilesDirectory));
        
        // Sample of usage GetMax
        string maxFile = files.GetMaximum((file => new FileInfo(file).Length));
        Console.WriteLine($"Max file: {maxFile}");

        // Sample of usage FileFinder
        var fileSearcher = new FileFinder();
        fileSearcher.FileFound += OnFileFound;
        fileSearcher.Search(sampleFilesDirectory);
        Console.WriteLine("Done.");
        Console.ReadLine();
    }

    static void OnFileFound(object sender, FileArgs e)
    {
        Console.WriteLine($"File detected: {e.FileName}");

        // Cancel search sample
        if (e.FileName.EndsWith("stop.txt"))
        {
            ((FileFinder)sender).TerminateSearch = true;
        }
    }

}

