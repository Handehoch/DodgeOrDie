using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DodgeOrDie.Controllers;
using DodgeOrDie.Models;
using DodgeOrDie.Views;

namespace DodgeOrDie
{
    public partial class GameForm : Form
    {
        internal readonly Game Game;
        private readonly Timer _gameLoop;
        private readonly Size _size = new Size(1920, 1080);

        public GameForm()
        {
            Game = new Game(new Pen(Color.White, 5f), _size.Width, _size.Height);
            InitializeComponent();
            ClientSize = _size;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
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
                    //_pauseWindow = new PauseForm(_startForm, this);
                    //_pauseWindow.Show();
                }
                else if (args.KeyCode == Keys.Escape && !Game.IsPlaying)
                {
                    //_pauseWindow.Close();
                    Game.Start();
                    //this.BringToFront();
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

            Game.Playground.TryMove();
            var direction = CharacterMovement.GetDirection(Game.Playground.Character);
            if(Game.IsPlaying) Game.Playground.Character.Move(direction.X, direction.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(Game.Playground.Pen, Game.Playground.Rectangle);
            e.Graphics.DrawImage(Game.Playground.Character.Sprite, Game.Playground.Character.X, Game.Playground.Character.Y);
            e.Graphics.DrawRectangle(Game.Watch.Pen, Game.Watch.Rectangle);
            e.Graphics.DrawString(Game.Watch.MeasureTime(), Game.Watch.Font, Game.Watch.Time.Brush, Game.Watch.Time.StartPos);
        }
    }
}
