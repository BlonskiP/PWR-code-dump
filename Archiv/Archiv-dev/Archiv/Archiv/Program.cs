using Archiv.Exceptions;
using Archiv.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archiv
{
    class Program
    {
            
        static void Main(string[] args)
        {
            try
            {
                if (HelpCheck(args))
                {
                    ArchivingManager.PrintHelp();
                }
                else if (ValidateArguments(args))
                {
                    try
                    {
                        ArchivingManager.Archiving(args[1], args[3], Int32.Parse(args[5]));
                    }
                    catch(Exception)
                    {
                        throw new WrongArgumentsException(args);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.LogMessage(" Błędy krytyczne - " +e.Message);
            }
            LogManager.LogMessage("Koniec sesji Archiv" + DateTime.Now);
        }
        static bool ValidateArguments(string[] args)
        {
            try
            {
                if (args.Length == 6 && args[0].Equals("#path") && args[2].Equals("#A") && args[4].Equals("#L"))
                    return true;
                throw new Exception("Error");
            }
            catch(Exception e)
            {
                throw new WrongArgumentsException(args);
            }   
           
        }
        static bool HelpCheck(string[] args)
        {
            LogManager.isOn = false;
            string[] helpCommands = { "/?", "/h", "/help", "?", "h", "#h", "#help", "-help", "-h" };

            try
            {
                if (helpCommands.Contains(args[0]))
                    return true;
                return false;
            }catch(Exception e)
            {
                throw new WrongArgumentsException(args);
            }
        }
    }
}
