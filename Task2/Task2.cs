using System.IO;
using System.Threading.Tasks;

string FolderPath;
Console.WriteLine("Введите путь к папке:");
FolderPath = Console.ReadLine();
DirectoryInfo Task2 = new DirectoryInfo(FolderPath);
try
{
    if (Task2.Exists)
    { 
    var Size = DirSize(Task2);
    Console.WriteLine("Размер папкки = {0} байт", Size);
    }
}

catch
{
    Console.WriteLine("Операция невозможна");
}
static long DirSize(DirectoryInfo directory)
{   
    long Size = 0;
    FileInfo[] files = directory.GetFiles();

    foreach (FileInfo file in files)
    {
        Size += file.Length;
    }
    DirectoryInfo[] directoryes = directory.GetDirectories();

    foreach (DirectoryInfo dir in directoryes)
    {
        Size += DirSize(dir);
    }
    return (Size);
}