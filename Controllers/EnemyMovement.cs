﻿using System;
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
        public static Point GetDirection(Playground pg, IEnemy enemy)
        {
            if (pg.Character.X < enemy.X && pg.Rectangle.Top <= enemy.Y && pg.Rectangle.Bottom >= enemy.Y) return new Point(-1, 0);
            if (pg.Character.X > enemy.X && pg.Rectangle.Top <= enemy.Y && pg.Rectangle.Bottom >= enemy.Y) return new Point(1, 0);
            if (pg.Character.Y < enemy.Y && pg.Rectangle.Left <= enemy.X && pg.Rectangle.Right >= enemy.X) return new Point(0, -1);
            return new Point(0, 1);
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