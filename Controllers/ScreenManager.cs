using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Views;
using DodgeOrDie.Controllers;
using System.Windows.Forms;

namespace DodgeOrDie.Controllers
{
    internal class ScreenManager
    {
        private static StartForm _startForm;
        private static GameForm _gameForm;
        private static PauseForm _pauseForm;

        public static void InitWith(StartForm startForm, GameForm gameForm, PauseForm pauseForm)
        {
            _startForm = startForm;
            _gameForm = gameForm;
            _pauseForm = pauseForm;
        }

        public static void CloseGame()
        {
            _startForm.Close();
        }

        public static void CreateGame()
        {
            _gameForm = new GameForm();
            CharacterMovement.Clear();
            _gameForm.Show();
        }

        public static void ShowPauseForm()
        {
            _pauseForm.Show();
            _pauseForm.BringToFront();
        }

        public static void ResumeGame()
        {
            _pauseForm.SendToBack();
            _gameForm.BringToFront();
            _gameForm.Game.Start();
            CharacterMovement.Clear();
        }

        public static void ClosePauseForm()
        {
            _pauseForm.Close();
        }

        public static void CloseGameForm()
        {
            _gameForm?.Close();
        }

        public static void ShowStartForm()
        {
            _startForm?.Show();
        }
    }
}
