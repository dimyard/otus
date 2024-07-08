using System.Diagnostics;
using System.Text;
using HomeWork._23_Tasks.Core.UseCases;
using HomeWork._23_Tasks.Infrastructure;

namespace HomeWork._23_Tasks.ConsoleApp;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "GeneratedFiles"));
        
        EnsureFilesExist(directoryInfo);
        
        var fileReader = new FileReader();
        var fileSpaceCounter = new FileSpaceCounter(fileReader);
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = await fileSpaceCounter.CountSpacesInFilesInDirectoryAsync(directoryInfo);
        stopwatch.Stop();
        
        Console.WriteLine($"⭐  Spaces count: {result}. \r\n⏳  Elapsed time: {stopwatch.Elapsed.Microseconds} ms." +
                          $"\r\n📂 Directory: {directoryInfo}" +
                          $"\r\n📃 Files count: {directoryInfo.GetFiles().Length}");
        
        var fileInfos = directoryInfo.GetFiles()[..3].Select(x => new FileInfo(x.FullName)).ToList();
        Console.WriteLine("🧝‍ ️3 files now... ");
        stopwatch.Restart();
        stopwatch.Start();
        result = await fileSpaceCounter.CountSpacesInFilesAsync(fileInfos);
        stopwatch.Stop();
        
        Console.WriteLine($"⭐  Spaces count: {result}. \r\n⏳  Elapsed time: {stopwatch.Elapsed.Microseconds} ms." +
                          $"\r\n📂 Directory: {directoryInfo}" +
                          $"\r\n📃 Files count: {fileInfos.Count}");
    }
    
    private static void EnsureFilesExist(DirectoryInfo directoryInfo)
    {
        if (directoryInfo.Exists && directoryInfo.GetFiles().Any(x => x.FullName.EndsWith(".txt"))) 
            return;
        
        var fileGenerator = new FileGenerator();
        fileGenerator.GenerateFiles();
        Console.WriteLine($"🔥 Generated files in directory: {directoryInfo}");
    }
}