using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ChinookContext())
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(@"c:\Users\andarno\Documents\Visual Studio 2015\Projects\ConsoleApplication7\Chinook_Sqlite_AutoIncrementPKs.sql"));
                var artists = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name);
                }
            }
        }
    }
}
