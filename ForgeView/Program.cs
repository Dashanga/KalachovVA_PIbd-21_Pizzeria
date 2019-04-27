using System;
using System.Windows.Forms;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;
using PizzeriaServiceImplementDB.Implementations;

namespace ForgeView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApiClient.Connect();
            MailClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
