using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace mssqlping
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count() != 1)
            {
                Console.WriteLine("");
                Console.WriteLine("USAGE: mssqlping <instance-name>");
                Console.WriteLine("<instance-name> is the host and optional instance of a Microsoft SQL Server instance.  To ping the default instance, just specify a hostname. Note this utility uses trusted connections so if you run this in the context of a user who does not have access to a database instance, you'll get an error; if you get such an error keep in mind there is a running database instance, you just aren't allowed to use it!");
                Console.WriteLine("");
                Console.WriteLine("Examples:");
                Console.WriteLine("mssqlping sqlbox1");
                Console.WriteLine("Ping the default SQL Server instance on the host named SQLBOX1");
                Console.WriteLine(@"mssqlping rack6box2\sharepoint");
                Console.WriteLine("Ping the SQL Server instance named SHAREPOINT on host RACK6BOX2");
                Console.WriteLine("");
                Console.WriteLine("");
            } else
            {
                string instance = args[0];
                Console.WriteLine("Pinging " + instance);

                string act = "setting connection parameters";
                try
                {
                    using (SqlConnection con = new SqlConnection("Server=" + instance+";Trusted_Connection=true;"))
                    {
                        act = "opening connection";
                        con.Open();

                        act = "getting cmd object";
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandText = "SELECT @@VERSION";

                        act = "running query";
                        string result = cmd.ExecuteScalar().ToString();

                        act = "disposing of cmd";
                        cmd.Dispose();

                        act = "closing connection";
                        con.Close();

                        Console.WriteLine("Connected to " + result);
                    } // using: SqlConnection
                } // try
                catch(Exception ex)
                {
                    Console.WriteLine("Error " + act + ": " + ex.ToString());
                } // catch

            } // if..else: one command line argument found?
            //Console.ReadKey();

        }
    }
}
