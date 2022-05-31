using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgeOrDie.Controllers
{
    internal static class GameScale
    {
        public static int MaxEnemies = 10;
        public static int EnemySpeed = 10;
        public static int SpawnRate = 500;
        public static bool IsControlInverted = false;
        public static Timer InversionController;
        public static Timer ModeController;
        public static GameMode Mode;
        public static int BlankAmount = 3; //Абилка, позволяющая очистить экран от всех врагов

        static GameScale()
        {
            Mode = GameMode.Straight;

            InversionController = new Timer() { Interval = 30 * 1000, };
            InversionController.Tick += (s, e) =>
            {
                IsControlInverted = !IsControlInverted;
                InversionController.Interval = IsControlInverted ? 10 * 1000 : 30 * 1000;
            };

            ModeController = new Timer() { Interval = 40 * 1000, };
            ModeController.Tick += (s, e) =>
            {
                Mode = Mode == GameMode.Straight ? GameMode.AimToPlayer : GameMode.Straight;
            };
        }

        public static void RestoreToDeafult()
        {
            MaxEnemies = 10;
            EnemySpeed = 10;
            SpawnRate = 500;
            BlankAmount = 3;
            IsControlInverted = false;
            InversionController.Stop();
            InversionController.Interval = 30 * 1000;
            ModeController.Stop();
        }

        public static void Increase()
        {
            MaxEnemies += 2;
            EnemySpeed += 1;

            if(SpawnRate > 200)
                SpawnRate -= 15;
        }
    }

    internal enum GameMode
    {
        Straight,
        AimToPlayer
    }
}
