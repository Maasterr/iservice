﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace iService
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");

            Login loginform = new Login();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
                
            }
            else Application.Exit();
        }
    }
}
