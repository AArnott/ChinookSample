using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
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
                using (var sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication7.Chinook_Sqlite_AutoIncrementPKs.sql")))
                {
                    context.Database.ExecuteSqlCommand(sr.ReadToEnd());
                }

                var artists = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name);
                }
            }

            // I've disposed of the DbContext. All handles to the sqlite database file SHOULD
            // have been released by now.
            // Yet, this next line fails because the file is still locked.
            File.Delete("Chinook_Sqlite_AutoIncrementPKs.sqlite");

            // If I GC and finalize first, it works. This suggests the SQLite ADO.NET
            // provider does not properly implement the .NET dispose pattern.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete("Chinook_Sqlite_AutoIncrementPKs.sqlite");
        }
    }
}
