using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeOrDie.Controllers
{
    internal static class GameScale
    {
        public static int MaxEnemies = 10;
        public static int EnemySpeed = 10;
        public static int SpawnRate = 500;
        public static bool IsControlInverted = false;

        public static void Increase()
        {
            MaxEnemies += 2;
            EnemySpeed += 2;

            if(SpawnRate > 200)
                SpawnRate -= 20;
        }
    }
}
