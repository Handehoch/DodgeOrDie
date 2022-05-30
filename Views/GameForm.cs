﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DodgeOrDie.Controllers;
using DodgeOrDie.Models;
using DodgeOrDie.Models.Enemies;
using DodgeOrDie.Helpers;
using System.Linq;

namespace DodgeOrDie
{
    public delegate void CharacterEventHandler();

    public partial class GameForm : Form
    {
        internal readonly Game Game;
        private readonly Timer _gameLoop;
        private readonly Timer _enemySpawner;
        private Health[] _healthbar;
        private Blank[] _blanks;
        private readonly Size _size = new Size(1920, 1080);

        public event CharacterEventHandler CharacterDamaged;

        public GameForm()
        {
            Game = new Game(new Pen(Color.White, 5f), _size.Width, _size.Height);
            InitializeComponent();
            ClientSize = _size;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            DoubleBuffered = true;
            BackColor = Color.Black;
            InitInGameUI();

            _enemySpawner = new Timer { Interval = GameScale.SpawnRate };
            _enemySpawner.Tick += SpawnEmeny;
            _enemySpawner.Start();

            _gameLoop = new Timer() { Interval = 20 };
            _gameLoop.Tick += Update;
            _gameLoop.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Game.Start();

            CharacterDamaged += DealDamageToCharacter;
            CharacterDamaged += EndGame;

            GameScale.InversionController.Start();

            KeyUp += PlayerMovement.RemoveKey;
            KeyDown += PlayerMovement.AddKey;
            KeyDown += (s, args) =>
            {
                if (args.KeyCode == Keys.Escape && Game.IsPlaying)
                {
                    Game.Stop();
                    ScreenManager.ShowPauseForm();
                }
            };
        }

        private void InitInGameUI()
        {
            _healthbar = new Health[Game.Playground.Player.Health];
            var delta = 10;
            for (var i = 0; i < _healthbar.Length; i++)
            {
                _healthbar[i] = new Health(delta, 10);
                delta += 35;
            }

            _blanks = new Blank[GameScale.BlankAmount];
            delta = 10;
            for(var i = 0; i < _blanks.Length; i++)
            {
                _blanks[i] = new Blank(delta, 50);
                delta += 35;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Game.Update(ClientSize.Width, ClientSize.Height);
        }

        public void Update(object sender, EventArgs e)
        {
            base.Update();
            Invalidate();

            Game.Playground.TryMoveCharacter();

            var direction = PlayerMovement.GetDirection(Game.Playground.Player, GameScale.IsControlInverted);
            if (Game.IsPlaying)
            {
                Game.Playground.Player.Move(direction.X, direction.Y);
                Game.Enemies.ForEach(enemy => enemy.Move(GameScale.EnemySpeed));
                KillEnemy();
                IncreaseDifficulty();
                CharacterDamaged();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(Game.Playground.Pen, Game.Playground.Rectangle);
            e.Graphics.DrawRectangle(Game.Watch.Pen, Game.Watch.Rectangle);
            e.Graphics.DrawString(Game.Watch.MeasureTime(), Game.Watch.Font, Game.Watch.Time.Brush, Game.Watch.Time.StartPos);
            
            foreach(var enemy in Game.Enemies)
                e.Graphics.DrawImage(enemy.Sprite, new PointF((float)enemy.X, (float)enemy.Y));

            for(var i = 0; i < Game.Playground.Player.Health; i++)
                e.Graphics.DrawImage(_healthbar[i].Sprite, _healthbar[i].StartPos);

            for(var i = 0; i < GameScale.BlankAmount; i++)
                e.Graphics.DrawImage(_blanks[i].Sprite, _blanks[i].StartPos);

            if (Game.Playground.Player.Sprite == null) return;
            e.Graphics.DrawImage(Game.Playground.Player.Sprite, Game.Playground.Player.X, Game.Playground.Player.Y);

        }

        private TimeSpan GetCurrentTimeSpan() => TimeSpan.FromMilliseconds(Game.Watch.ElapsedMilliseconds);

        private void IncreaseDifficulty()
        {
            if (!Game.IsPlaying) return;

            var time = GetCurrentTimeSpan();
            if (Math.Abs(time.TotalSeconds % 20) < 0.01)
            {
                GameScale.Increase();
                Game.IncreaseMaxEnemiesTo(GameScale.MaxEnemies);
                _enemySpawner.Interval = GameScale.SpawnRate;
            }
        }

        private void SpawnEmeny(object sender, EventArgs e)
        {
            if (Game.IsMaxEnemies) return;

            var enemy = new RushingEnemy();
            var position = EnemyMovement.GetValidPlaceToAppear(Game.Playground, Width, Height);
            enemy.Appear(position.X, position.Y);
            enemy.SetDirection(EnemyMovement.GetDirection(Game.Playground, enemy));
            Game.Enemies.Add(enemy);
        }

        private void KillEnemy(/*object sender, EventArgs e*/)
        {
            if (!Game.IsMaxEnemies) return;

            foreach(var enemy in Game.Enemies.ToList())
                if(!enemy.Location.IsInsideBounds(Width, Height))
                    Game.Enemies.Remove(enemy);
        }

        private void DealDamageToCharacter()
        {
            foreach(var enemy in Game.Enemies.ToList())
            {
                if (Game.Playground.Player.InteractsWith(enemy) && !Game.Playground.Player.GotDamaged)
                {
                    Game.Playground.Player.GetDamage();
                    Game.Playground.Player.PingOnDamage(30);
                    Game.Enemies.Remove(enemy);
                }
            }
        }

        private void EndGame()
        {
            if (Game.Playground.Player.Health <= 0)
            {
                Game.Stop();
                ScreenManager.CloseGameForm();
                ScreenManager.ShowStartForm();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space && GameScale.BlankAmount > 0)
            {
                Game.RomveAllEnemies();
                GameScale.BlankAmount--;
            }
        }
    }   
}
