using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace DodgeOrDie.Models
{
    internal class Character
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Speed { get; private set; }
        public bool GotDamaged { get; private set; } = false;
        public int Health { get; private set; }
        public Image Sprite { get; private set; }

        public bool GoLeft, GoRight, GoUp, GoDown;
        public readonly int Size = 32;

        public Character(int x, int y)
        {
            Update(x, y);
            Health = 3;
            Sprite = new Bitmap(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\redHeart.png");
        }

        public void Update(int x, int y)
        {
            X = x / 2;
            Y = y / 2;
            Speed = (x + y) / 300;
        }

        public void Move(double dx, double dy)
        {
            X += (int)dx * Speed;
            Y += (int)dy * Speed;
        }

        public async void GetDamage()
        {
            Health--;
            GotDamaged = true;
            await DisableSaveFramesAsync(3000);
        }

        private Task DisableSaveFramesAsync(int milliseconds) => Task.Run(() => {
            Thread.Sleep(milliseconds);
            GotDamaged = false;
        });

        public async void PingOnDamage(int amount)
        {
            if (amount <= 0) return;

            for (var i = 0; i < amount; i++)
                await DisableSpriteFor(3000 / amount);
        }

        private Task DisableSpriteFor(int milliseconds) => Task.Run(() => {
            Sprite = null;
            Thread.Sleep(milliseconds);
            Sprite = new Bitmap(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\redHeart.png");
        });
    }
}
