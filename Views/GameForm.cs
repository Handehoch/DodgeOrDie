using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class GameForm : Form
    {
        private readonly Game _game;

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Black;
            ClientSize = new Size(1600, 900);
            //WindowState = FormWindowState.Maximized;
            _game = new Game(new Playground(new Pen(Color.White, 5f), ClientSize.Width, ClientSize.Height));
            var gameLoop = new Timer() { Interval = 20 };
            gameLoop.Tick += Update;
            gameLoop.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            KeyDown += _game.Movement.KeyDownMove;
            KeyUp += _game.Movement.KeyUpMove;
        }

        protected override void OnResize(EventArgs e)
        {
            if (_game == null) return;
            _game.Playground.Update(ClientSize.Width, ClientSize.Height);
        }

        public void Update(object sender, EventArgs e)
        {
            //if (_game.Playground.IsPlayerOnPlayground())
            var direction = _game.Movement.GetDirection();
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
