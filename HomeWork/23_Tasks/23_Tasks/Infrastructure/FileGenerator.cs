namespace HomeWork._23_Tasks.Infrastructure;

public class FileGenerator
{
    public FileGenerator(DirectoryInfo? directoryInfo = null, int filesMinCount = 3, int filesMaxCount = 10)
    {
        directoryInfo ??= new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "GeneratedFiles"));
        DirectoryPath = directoryInfo;
        FilesMinCount = filesMinCount;
        FilesMaxCount = filesMaxCount;
    }

    private DirectoryInfo DirectoryPath { get; init; }
    private static Random Random { get; set; }= new Random();
    private int FilesMinCount { get; init; }
    private int FilesMaxCount { get; init; }

    public void GenerateFiles(int filesMinCount = 3, int filesMaxCount = 10)
    {
        if (!DirectoryPath.Exists)
        {
            DirectoryPath.Create();
        }

        var fileCount = Random.Next(FilesMinCount, FilesMaxCount + 1);

        for (int i = 0; i < fileCount; i++)
        {
            var fileName = Path.Combine(DirectoryPath.FullName, $"new_law_file_{i + 1}.txt");
            var content = GenerateRandomContent();
            File.WriteAllText(fileName, content);
        }
    }

    private string GenerateRandomContent()
    {
        var length = Random.Next(100000, 10000000);
        const string chars = "МНОГБУКВ ";
        var fileContent = Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray();
        
        return new string(fileContent);
    }
}