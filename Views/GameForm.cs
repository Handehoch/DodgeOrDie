using System;
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
    public partial class GameForm : Form
    {
        internal readonly Game Game;
        private readonly Timer _gameLoop;
        private readonly Timer _enemySpawner;
        private readonly Size _size = new Size(1920, 1080);

        public GameForm()
        {
            Game = new Game(new Pen(Color.White, 5f), _size.Width, _size.Height);
            InitializeComponent();
            ClientSize = _size;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            _enemySpawner = new Timer { Interval = GameScale.SpawnRate };
            _enemySpawner.Tick += SpawnEmeny;
            _enemySpawner.Tick += KillEnemy;
            _enemySpawner.Start();
            _gameLoop = new Timer() { Interval = 20 };
            _gameLoop.Tick += Update;
            _gameLoop.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            BackColor = Color.Black;
            Game.Start();
            KeyUp += CharacterMovement.RemoveKey;
            KeyDown += CharacterMovement.AddKey;
            KeyDown += (s, args) =>
            {
                if (args.KeyCode == Keys.Escape && Game.IsPlaying)
                {
                    Game.Stop();
                    ScreenManager.ShowPauseForm();
                }
                else if (args.KeyCode == Keys.Escape && !Game.IsPlaying)
                {
                    Game.Start();
                    ScreenManager.ShowPauseForm();
                }
            };
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
            var direction = CharacterMovement.GetDirection(Game.Playground.Character);
            if(Game.IsPlaying) Game.Playground.Character.Move(direction.X, direction.Y);

            Game.Enemies.ForEach(enemy => enemy.Move(GameScale.EnemySpeed));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(Game.Playground.Pen, Game.Playground.Rectangle);
            e.Graphics.DrawImage(Game.Playground.Character.Sprite, Game.Playground.Character.X, Game.Playground.Character.Y);
            e.Graphics.DrawRectangle(Game.Watch.Pen, Game.Watch.Rectangle);
            e.Graphics.DrawString(Game.Watch.MeasureTime(), Game.Watch.Font, Game.Watch.Time.Brush, Game.Watch.Time.StartPos);
            
            foreach(var enemy in Game.Enemies)
                e.Graphics.DrawImage(enemy.Sprite, new Point(enemy.X, enemy.Y));
        }

        private void EnlargeDifficult()
        {
            if (!Game.IsPlaying) return;

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

        private void KillEnemy(object sender, EventArgs e)
        {
            if (!Game.IsMaxEnemies) return;

            Game.Enemies.RemoveAt(0);
        }
    }
}
