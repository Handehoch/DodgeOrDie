using System.Drawing;
using System.Media;
using System.Collections.Generic;
using DodgeOrDie.Entities;
using DodgeOrDie.Controllers;
using DodgeOrDie.Models.Timer;

namespace DodgeOrDie.Models
{
    internal class Game
    {
        public readonly Playground Playground;
        public readonly Watch Watch;
        public readonly List<IEnemy> Enemies;
        public readonly System.Windows.Forms.Timer DifficultyController;
        public readonly System.Windows.Forms.Timer EnemySpawner;
        private readonly SoundPlayer _player;
        private int _maxEnemies;

        public bool IsMaxEnemies => Enemies.Count == _maxEnemies; 

        public bool IsPlaying { get; set; }

        public Game(Pen pen, int width, int height, int maxEnemies, int spawnRate)
        {
            Playground = new Playground(pen, width, height);
            Watch = new Watch(pen, width, height, Playground.EndPos.X, Playground.StartPos.Y);
            _maxEnemies = maxEnemies;
            Enemies = new List<IEnemy>();

            _player = new SoundPlayer(@"..\..\..\DodgeOrDie\Sprites\battle.wav");

            DifficultyController = new System.Windows.Forms.Timer() { Interval = 30 * 1000, };
            EnemySpawner = new System.Windows.Forms.Timer() { Interval = spawnRate, };
        }

        public void Start()
        {
            IsPlaying = true;
            Watch.Start();
            DifficultyController.Start();
            EnemySpawner.Start();
            GameScale.InversionController.Start();
            GameScale.ModeController.Start();
            _player.PlayLooping();
        }

        public void Stop()
        {
            IsPlaying = false;
            Watch.Stop();
            DifficultyController.Stop();
            EnemySpawner.Stop();
            GameScale.InversionController.Stop();
            GameScale.ModeController.Stop();
            _player.Stop();
        }

        public void Update(int width, int height)
        {
            Playground.Update(width, height, 0, 0);
            Watch.Update(Playground.Size.Width, Playground.Size.Height, Playground.EndPos.X, Playground.StartPos.Y);
        }

        public void IncreaseMaxEnemiesTo(int count)
        {
            _maxEnemies = count;
        }

        public void RomveAllEnemies()
        {
            Enemies.Clear();
        }
    }
}
