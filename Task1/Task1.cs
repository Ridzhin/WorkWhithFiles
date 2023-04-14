using System.IO;
using System.Threading.Tasks;


string FolderPath;
Console.WriteLine("Введите путь к папке:");
FolderPath = Console.ReadLine();

DirectoryInfo directory = new DirectoryInfo(FolderPath);
DirDelete(directory);

static void DirDelete (DirectoryInfo directory)
{ 
try
{
    if ((directory.Exists) && (directory.LastAccessTime < DateTime.Now.AddMinutes(-30)))
    {

        foreach (FileInfo file in directory.GetFiles())
        {
            if (file.LastAccessTime < DateTime.Now.AddMinutes(-30))
                file.Delete();
        }

        foreach (DirectoryInfo dir in directory.GetDirectories())
        {
            if (directory.LastAccessTime < DateTime.Now.AddMinutes(-30))
            dir.Delete(true);
        }
        Console.WriteLine("Файлы удалены");
    }

    else
    {
        Console.WriteLine("Нет фалов подлежащих удалению");
    }
}

    catch
    {
        Console.WriteLine("Операция невозможна");
    }
}