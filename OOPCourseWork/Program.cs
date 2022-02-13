using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPCourseWorkAPI;

namespace OOPCourseWork
{
    static class Program
    {

        // Connection String for the project
        public static string DBConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security = True; Database=VotingSystemDB";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Start Application
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
