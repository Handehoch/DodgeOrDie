using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Models;
using System.Drawing;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Controllers
{
    internal static class EnemyMovement
    {
        public static System.Windows.Vector GetDirection(Playground pg, IEnemy enemy, GameMode mode)
        {
            if(mode == GameMode.AimToPlayer) return GetDiagonalDirection(pg, enemy);

            if (new Random().Next(10) == 5) return GetDiagonalDirection(pg, enemy);

            if (pg.Player.X < enemy.X && pg.Rectangle.Top <= enemy.Y && pg.Rectangle.Bottom >= enemy.Y) return new System.Windows.Vector(-1, 0);
            if (pg.Player.X > enemy.X && pg.Rectangle.Top <= enemy.Y && pg.Rectangle.Bottom >= enemy.Y) return new System.Windows.Vector(1, 0);
            if (pg.Player.Y < enemy.Y && pg.Rectangle.Left <= enemy.X && pg.Rectangle.Right >= enemy.X) return new System.Windows.Vector(0, -1);
            return new System.Windows.Vector(0, 1);
        }

        private static System.Windows.Vector GetDiagonalDirection(Playground pg, IEnemy enemy)
        {
            var vector = new System.Windows.Vector(pg.Player.X - enemy.X, pg.Player.Y - enemy.Y);
            vector.Normalize();
            return vector;
        }

        public static Point GetValidPlaceToAppear(Playground pg, int width, int height)
        {
            var rnd = new Random();
            var validPlaces = new List<Point>
            {
                new Point(rnd.Next(56, pg.Rectangle.Left - 56), rnd.Next(pg.Rectangle.Top + 45, pg.Rectangle.Bottom - 45)),
                new Point(rnd.Next(pg.Rectangle.Left + 56, pg.Rectangle.Right - 56), rnd.Next(45, pg.Rectangle.Top - 45)),
                new Point(rnd.Next(pg.Rectangle.Right + 56, width - 56), rnd.Next(pg.Rectangle.Top + 45, pg.Rectangle.Bottom - 45)),
                new Point(rnd.Next(pg.Rectangle.Left + 56, pg.Rectangle.Right - 56), rnd.Next(pg.Rectangle.Bottom + 45, height - 45))
            };

            return validPlaces[rnd.Next(validPlaces.Count)];
        }
    }
}
