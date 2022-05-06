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

namespace DodgeOrDie.Views
{
    public partial class PauseForm : Form
    {
        private readonly PrivateFontCollection _fc;
        private Button _resumeButton;
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
            //KeyDown += (s, e) => {
            //    if (e.KeyCode == Keys.Escape) _gameForm.BringToFront();
            //};
        }

        public void InitControls()
        {
            InitStartButton();
            InitSettingsButton();
        }

        public void InitStartButton()
        {
            _resumeButton = new Button();
            _resumeButton.Size = new Size(Width / 4, Height / 5);
            _resumeButton.Location = new Point(Width / 4 - _resumeButton.Width / 2, Height / 2 - _resumeButton.Height / 2);
            _resumeButton.Text = "Resume";
            _resumeButton.BackColor = Color.White;
            _resumeButton.Font = new Font(_fc.Families[0], 24f);
            //_resumeButton.Click += (s, e) => {
            //    _gameForm.BringToFront();
            //    //_gameForm.Game.Start();
            //};
            Controls.Add(_resumeButton);
        }

        public void InitSettingsButton()
        {
            _exitButton = new Button();
            _exitButton.Size = new Size(Width / 4, Height / 5);
            _exitButton.Location = new Point(Width / 2 + _exitButton.Width / 2, Height / 2 - _exitButton.Height / 2);
            _exitButton.Text = "Exit";
            _exitButton.TextAlign = ContentAlignment.MiddleCenter;
            _exitButton.BackColor = Color.White;
            _exitButton.Font = new Font(_fc.Families[0], 24f);

            //_exitButton.Click += (s, e) => {
            //    _startForm.Close();
            //};
            Controls.Add(_exitButton);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("Game Paused", new Font(_fc.Families[0], (Width + Height) / 25), new SolidBrush(Color.IndianRed), new PointF(Width / 6, Height / 8));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _resumeButton.Location = new Point(Width / 4 - _resumeButton.Width / 2, Height / 2 - _resumeButton.Height / 2);
            _resumeButton.Size = new Size(Width / 4, Height / 5);
            _exitButton.Location = new Point(Width / 2 + _exitButton.Width / 2, Height / 2 - _exitButton.Height / 2);
            _exitButton.Size = new Size(Width / 4, Height / 5);
        }
    }
}
