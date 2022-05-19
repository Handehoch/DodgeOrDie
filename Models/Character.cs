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
        public bool GoLeft { get; internal set; } = false;
        public bool GoRight { get; internal set; } = false;
        public bool GoUp { get; internal set; } = false;
        public bool GoDown { get; internal set; } = false;
        public bool GetDamaged { get; private set; } = false;
        public int Health { get; private set; }

        public readonly Image Sprite;
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

        public void GetDamage()
        {
            Health--;
            //EnableSaveFrames();
            //await DisableSaveFramesAsync();
        }

        //private void EnableSaveFrames()
        //{
        //    GetDamaged = true;
        //}

        //private Task DisableSaveFramesAsync()
        //{
        //    return Task.Run(() =>
        //    {
        //        Thread.Sleep(5000);
        //        GetDamaged = false;
        //    });
        //}
    }
}
