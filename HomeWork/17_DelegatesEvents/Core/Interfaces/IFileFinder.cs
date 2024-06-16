using DelegatesProject.Core.Models;

namespace DelegatesProject.Core.Interfaces;

public interface IFileFinder
{
    event EventHandler<FileArgs> FileFound;
    
    bool TerminateSearch { get; set; }

    void Search(string dir);
}