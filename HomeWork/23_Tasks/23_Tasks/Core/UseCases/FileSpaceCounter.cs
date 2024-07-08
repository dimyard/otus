using HomeWork._23_Tasks.Core.Interfaces;

namespace HomeWork._23_Tasks.Core.UseCases;

public class FileSpaceCounter
{
    private IFileReader _fileReader;

    public FileSpaceCounter(IFileReader fileFinder)
    {
        _fileReader = fileFinder;
    }
    
    public async Task<int> CountSpacesInFilesInDirectoryAsync(DirectoryInfo directoryInfo)
    {
        var fileInfos = directoryInfo.GetFiles();
        
        return await CountSpacesInFilesAsync(fileInfos);
    }
    
    public async Task<int> CountSpacesInFilesAsync(IEnumerable<FileInfo> fileInfos)
    {
        var tasks = fileInfos.Select(x => _fileReader.ReadFileAsync(x));
        var resultsList = await Task.WhenAll(tasks);
        
        return resultsList.Sum(fileContent => fileContent.Content.Count(q => q == ' '));
    } 
}