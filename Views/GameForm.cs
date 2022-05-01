using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DodgeOrDie.Controllers;
using DodgeOrDie.Models;

namespace DodgeOrDie
{
    public partial class GameForm : Form
    {
        private readonly Game _game;
        private readonly Timer _gameLoop;
        private readonly Size _size = new Size(1600, 900);

        public GameForm()
        {
            _game = new Game(new Pen(Color.White, 5f), _size.Width, _size.Height);
            InitializeComponent();
            ClientSize = _size;
            _gameLoop = new Timer() { Interval = 30 };
            _gameLoop.Tick += Update;
            _gameLoop.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            BackColor = Color.Black;
            _game.Start();
            KeyUp += CharacterMovement.RemoveKey;
            KeyDown += CharacterMovement.AddKey;
            KeyDown += (s, args) =>
            {
                if (args.KeyCode == Keys.Escape && _game.IsPlaying) _game.Stop();
                else if (args.KeyCode == Keys.Escape && !_game.IsPlaying) _game.Start();
            };
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _game.Update(ClientSize.Width, ClientSize.Height);
        }

        public void Update(object sender, EventArgs e)
        {
            base.Update();
            Invalidate();

            _game.Playground.TryMove();
            var direction = CharacterMovement.GetDirection(_game.Playground.Character);
            if(_game.IsPlaying) _game.Playground.Character.Move(direction.X, direction.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(_game.Playground.Pen, _game.Playground.Rectangle);
            e.Graphics.DrawImage(_game.Playground.Character.Sprite, _game.Playground.Character.X, _game.Playground.Character.Y);
            e.Graphics.DrawRectangle(_game.Watch.Pen, _game.Watch.Rectangle);
            e.Graphics.DrawString(_game.Watch.MeasureTime(), _game.Watch.Font, _game.Watch.Time.Brush, _game.Watch.Time.StartPos);
        }
    }
}
