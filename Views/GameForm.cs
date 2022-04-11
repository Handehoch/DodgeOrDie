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

        public GameForm()
        {
            InitializeComponent();
            ClientSize = new Size(1366, 768);
            _game = new Game(new Playground(new Pen(Color.White, 5f), ClientSize.Width, ClientSize.Height));
            _gameLoop = new Timer() { Interval = 30 };
            _gameLoop.Tick += Update;
            _gameLoop.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            BackColor = Color.Black;
            //WindowState = FormWindowState.Maximized;
            KeyDown += Movement.AddKey;
            KeyUp += Movement.RemoveKey;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(_game != null) _game.Playground.Update(ClientSize.Width, ClientSize.Height);
        }

        public void Update(object sender, EventArgs e)
        {
            var direction = Movement.GetDirection(_game.Playground.Character);
            _game.Playground.TryMove();
            _game.Playground.Character.Move(direction.X, direction.Y);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(_game.Playground.Pen, _game.Playground.Rectangle);
            e.Graphics.DrawImage(_game.Playground.Character.Sprite, _game.Playground.Character.X, _game.Playground.Character.Y);
        }
    }
}
