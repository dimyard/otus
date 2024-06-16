using DelegatesProject.Core.Interfaces;
using DelegatesProject.Core.Models;

namespace DelegatesProject.Application.Services;

public class FileFinder : IFileFinder
{
    public event EventHandler<FileArgs> FileFound;
    
    public bool TerminateSearch { get; set; }

    protected virtual void OnFileFound(FileArgs fileAgrs)
    {
        FileFound.Invoke(this, fileAgrs);
    }

    public void Search(string dir)
    {
        if (!Directory.Exists(dir))
            throw new DirectoryNotFoundException($"Cant find dir: {dir}.");

        TerminateSearch = false;
        foreach (var file in Directory.GetFiles(dir))
        {
            if (TerminateSearch)
                break;

            OnFileFound(new FileArgs { FileName = file });
        }
    }
}