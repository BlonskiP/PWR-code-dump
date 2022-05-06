using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archiv.Res;

namespace Archiv.Exceptions
{
    class WrongArgumentsException : SystemException
    {
        string message;
        public WrongArgumentsException(string[] args)
        {
            try
            {
                message = Environment.NewLine;
                if (args.Length == 0 || args.Length > 6)
                {
                    message += Announcements.WrongNumberOfArgumentsError + Environment.NewLine;
                    return;
                }
                if (!args[0].Equals("#path"))
                {
                    message += Announcements.FirstArgumentError + Environment.NewLine;
                }
                else if (!ValidatePath(args[1]))
                {
                    message += Announcements.WrongPath + '"'+ args[1]+ '"' +Environment.NewLine;
                }
                if (!args[2].Equals("#A"))
                {
                    message += Announcements.SecondArgumentError + Environment.NewLine;
                }
                if (!args[4].Equals("#L"))
                {
                    message += Announcements.ThirdArgumentError + Environment.NewLine;
                }
                else
                    try
                    {
                        int temp = int.Parse(args[5]);
                        if (temp < 0)
                            message += Announcements.FileNumberArgumentError + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        message += Announcements.FileNumberArgumentError + Environment.NewLine;
                    }
            }
            catch (IndexOutOfRangeException)
            {   
                message += Announcements.WrongNumberOfArgumentsError + Environment.NewLine;
            }
        }

        private bool ValidatePath(string path)
        {
            if(!Directory.Exists(path))
            {
                //message += path + Announcements.WrongPath + Environment.NewLine;
                return false;
            }
            return true;
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }

    }
}
