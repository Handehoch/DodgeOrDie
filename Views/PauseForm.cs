using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Windows.Forms;
using DodgeOrDie.Controllers;

namespace DodgeOrDie.Views
{
    public partial class PauseForm : Form
    {
        private readonly PrivateFontCollection _fc;
        private Button _resumeButton;
        private Button _newGameButton;
        private Button _exitButton;

        public PauseForm()
        {
            _fc = new PrivateFontCollection();
            _fc.AddFontFile(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\HalfBoldPixel7-2rw3.ttf");
            InitControls();
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            ClientSize = new Size(1920, 1080);
            Load += (s, e) => OnSizeChanged(EventArgs.Empty);
        }

        public void InitControls()
        {
            InitResumeButton();
            InitNewGameButton();
            InitExitButton();
        }

        public void InitResumeButton()
        {
            _resumeButton = new Button();
            _resumeButton.Size = new Size(Width / 4, Height / 10);
            _resumeButton.Location = new Point(Width / 4 - _resumeButton.Width / 2, Height / 2 - _resumeButton.Height / 2);
            _resumeButton.Text = "Resume";
            _resumeButton.BackColor = Color.White;
            _resumeButton.Font = new Font(_fc.Families[0], 24f);
            _resumeButton.Click += (s, e) => ScreenManager.ResumeGame();
            Controls.Add(_resumeButton);
        }

        public void InitNewGameButton()
        {
            _newGameButton = new Button();
            _newGameButton.Size = new Size(Width / 4, Height / 10);
            _newGameButton.Location = new Point(Width / 4, Height / 2 - _newGameButton.Height / 2);
            _newGameButton.Text = "New Game";
            _newGameButton.TextAlign = ContentAlignment.MiddleCenter;
            _newGameButton.BackColor = Color.White;
            _newGameButton.Font = new Font(_fc.Families[0], 24f);
            _newGameButton.Click += (s, e) => ScreenManager.CreateGame();
            Controls.Add(_newGameButton);
        }

        public void InitExitButton()
        {
            _exitButton = new Button();
            _exitButton.Size = new Size(Width / 4, Height / 10);
            _exitButton.Location = new Point(Width / 2 + _exitButton.Width / 2, Height / 2 - _exitButton.Height / 2);
            _exitButton.Text = "Exit";
            _exitButton.TextAlign = ContentAlignment.MiddleCenter;
            _exitButton.BackColor = Color.White;
            _exitButton.Font = new Font(_fc.Families[0], 24f);
            _exitButton.Click += (s, e) => ScreenManager.CloseGame();
            Controls.Add(_exitButton);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("Game Paused", new Font(_fc.Families[0], (Width + Height) / 23), new SolidBrush(Color.IndianRed), new PointF(Width / 6, Height / 8));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _resumeButton.Size = new Size(Width / 4, Height / 10);
            _resumeButton.Location = new Point((int)(Width / 2.5) - (int)(_resumeButton.Width / 10), Height / 2 - _resumeButton.Height / 2);
            _newGameButton.Size = new Size(Width / 4, Height / 10);
            _newGameButton.Location = new Point((int)(Width / 2.5) - (int)(_newGameButton.Width / 10), Height - (Height / 2 - _newGameButton.Height / 2));
            _exitButton.Size = new Size(Width / 4, Height / 10 );
            _exitButton.Location = new Point((int)(Width / 2.5) - (int)(_exitButton.Width / 10), Height - ((int)(Height / 2.5) - _exitButton.Height / 2));
        }
    }
}
