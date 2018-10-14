using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iservice5
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login loginform = new Login();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else Application.Exit();
        }
    }
}
