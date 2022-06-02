using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using DodgeOrDie.Controllers;

namespace DodgeOrDie.Views
{
    public partial class StartForm : Form
    {
        private readonly PrivateFontCollection _fc;
        private Button _startButton;
        private Button _exitButton;

        public StartForm()
        {
            _fc = new PrivateFontCollection();
            _fc.AddFontFile(@"..\..\..\DodgeOrDie\Sprites\mainFont.ttf");
            //_titleFont = new Font(_fc.Families[0], (Width + Height) / 6);
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
            InitStartButton();
            InitExitButton();
        }

        public void InitStartButton()
        {
            _startButton = new Button();
            _startButton.Size = new Size(Width / 4, Height / 5);
            _startButton.Location = new Point(Width / 4 - _startButton.Width / 2, Height / 2 - _startButton.Height / 2);
            _startButton.Text = "Start Game";
            _startButton.BackColor = Color.White;
            _startButton.Font = new Font(_fc.Families[0], 24f);
            _startButton.Click += (s, e) => ScreenManager.CreateGame();
            Controls.Add(_startButton);
        }

        public void InitExitButton()
        {
            _exitButton = new Button();
            _exitButton.Size = new Size(Width / 4, Height / 5);
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
            e.Graphics.DrawString("Dodge or Die", new Font(_fc.Families[0], (Width + Height) / 25), new SolidBrush(Color.IndianRed), new PointF(Width / 6, Height / 8));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _startButton.Location = new Point(Width / 4 - _startButton.Width / 2, Height / 2 - _startButton.Height / 2);
            _startButton.Size = new Size(Width / 4, Height / 5);
            _exitButton.Location = new Point(Width / 2 + _exitButton.Width / 2, Height / 2 - _exitButton.Height / 2);
            _exitButton.Size = new Size(Width / 4, Height / 5);
        }
    }
}
