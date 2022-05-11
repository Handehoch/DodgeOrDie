using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DodgeOrDie.Views;
using DodgeOrDie.Controllers;

namespace DodgeOrDie
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var startForm = new StartForm();
            var gameForm = new GameForm();
            var pauseForm = new PauseForm();

            ScreenManager.InitWith(startForm, gameForm, pauseForm);
            Application.Run(startForm);
        }
    }
}
