using Archiv.Res;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Archiv.Managers
{
    public class ArchivingManager
    {
        
        
        public static bool Archiving(String path,String extension, int MaxQueueSize)
        {
            if (Directory.Exists(path))
            {
                List<String> fileNames = new List<String>();
                String regex = @"." + extension;
                Regex rgx = new Regex(regex);
                fileNames = Directory.GetFiles(path)
                    .Where(filePath => rgx.IsMatch(Path.GetExtension(filePath)))
                    .OrderBy(filePath => File.GetCreationTime(filePath))
                    .ToList();
                
                
                for (int i = 0; i < MaxQueueSize; i++)
                        fileNames.RemoveAt(fileNames.Count-1);
               
                foreach (var file in fileNames)
                {
                    ArchivingManager.deleteFile(file);
                }
                
                return true;
            }
            else
                throw new Exception();
        }

        private static void deleteFile(string file)
        {
            if(File.Exists(file))
            {
                File.Delete(file);
                LogManager.LogMessage(Announcements.FileIsBeingArchiving +file);
            }
            else
            LogManager.LogMessage(Announcements.FileDontExist+file);
        }

        public static void PrintHelp() {
            Console.WriteLine("Przykład składni \n" +
                "archiv #path c:\\kopia #A zip #L 8");
            Console.WriteLine("Po #path następuje ścieżka do katalogu");
            Console.WriteLine("Po #A następnuje szukane rozszerzenie pliku: np. 'txt' , 'rar' , '.rar' , ' *.rar' itp. ");
            Console.WriteLine("Po #L następnuje liczba plików które mają pozostać w katalogu");
            Console.WriteLine("Powyższy przykład działa następujaco: ");
            Console.WriteLine(" W katalogu c:\\kopia plików z rozszerzeniem zip ma pozostać 8 najmłodszych");

        }
    }
}
