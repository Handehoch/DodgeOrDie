using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Controllers;
using DodgeOrDie.Models.Timer;
using DodgeOrDie.Entities;
using DodgeOrDie.Models.Enemies;

namespace DodgeOrDie.Models
{
    internal class Game
    {
        public readonly Playground Playground;
        public readonly Watch Watch;
        public readonly List<IEnemy> Enemies;
        private int _maxEnemies;

        public bool IsMaxEnemies 
        { 
            get => Enemies.Count == _maxEnemies; 
        }

        public bool IsPlaying { get; set; }

        public Game(Pen pen, int width, int height)
        {
            Playground = new Playground(pen, width, height);
            Watch = new Watch(pen, width, height, Playground.EndPos.X, Playground.StartPos.Y);
            _maxEnemies = 10;
            Enemies = new List<IEnemy>();
        }

        public void Start()
        {
            IsPlaying = true;
            Watch.Start();
        }

        public void Stop()
        {
            IsPlaying = false;
            Watch.Stop();
        }

        public void Update(int width, int height)
        {
            Playground.Update(width, height, 0, 0);
            Watch.Update(Playground.Size.Width, Playground.Size.Height, Playground.EndPos.X, Playground.StartPos.Y);
        }

        public void IncreaseMaxEnemies(int count)
        {
            _maxEnemies = count;
        }
    }
}
