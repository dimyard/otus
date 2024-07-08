using HomeWork._23_Tasks.Core.Entities;
using HomeWork._23_Tasks.Core.Interfaces;

namespace HomeWork._23_Tasks.Infrastructure;

public class FileReader : IFileReader
{
    public async Task<FileContent> ReadFileAsync(FileInfo fileInfo)
    {
        var content = await File.ReadAllTextAsync(fileInfo.FullName);
        
        return new FileContent { Content = content };
    }
}