﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradedLab3P4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var appcontx = new ApplicationContext();

            //appcontx.MainForm = new Form1();

            //appcontx.MainForm.Show();
           
            //Thread.Sleep(2000);
            Application.AddMessageFilter(new MessageHandler());
            Application.Run(new Form1());
            Application.Run(new GameForm());
        }
    }
}
