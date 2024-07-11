using System;
using Globals;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DotNet_Salon_Manager
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new exemplo());            
        }
    }
}
