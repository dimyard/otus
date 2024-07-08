using HomeWork._23_Tasks.Core.Entities;

namespace HomeWork._23_Tasks.Core.Interfaces;

public interface IFileReader
{
    Task<FileContent> ReadFileAsync(FileInfo fileInfo);
}