using System.IO;
using System.Threading.Tasks;

string FolderPath;
Console.WriteLine("Введите путь к папке:");
FolderPath = Console.ReadLine();
DirectoryInfo Task3 = new DirectoryInfo(FolderPath);
try
{
    if (Task3.Exists)
    {
        var Size1 = DirSize(Task3);
        Console.WriteLine("Размер папки = {0} байт", Size1);
        DirDelete(Task3);
        var Size2 = DirSize(Task3);
        Console.WriteLine("Размер папки после удаления = {0} байт", Size2);
        Console.WriteLine("Освобожденно = {0} байт", Size1 - Size2);
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


static void DirDelete(DirectoryInfo directory)
{
    int count = 0;

            foreach (FileInfo file in directory.GetFiles())
            {
                    file.Delete();
                    count = count + 1;
            }

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                    dir.Delete(true);
                    count = count + 1;
            }
            Console.WriteLine("Файлы удалено {0}", count );
}

