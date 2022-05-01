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
    public partial class StartForm : Form
    {
        private GameForm _gameForm;
        private readonly PrivateFontCollection _fc;
        private Button _startButton;
        private Button _settingsButton;

        public StartForm()
        {
            InitializeComponent();
            _fc = new PrivateFontCollection();
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            _fc.AddFontFile(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\HalfBoldPixel7-2rw3.ttf");
            InitControls();
        }

        public void InitControls()
        {
            InitStartButton();
            InitSettingsButton();
        }

        public void InitStartButton()
        {
            _startButton = new Button();
            _startButton.Size = new Size(200, 100);
            _startButton.Location = new Point(Width / 4 - _startButton.Width / 2, Height / 2 - _startButton.Height / 2);
            _startButton.Text = "Start Game";
            _startButton.BackColor = Color.White;
            _startButton.Font = new Font(_fc.Families[0], 24f);
            _startButton.Click += (s, e) => {
                _gameForm = new GameForm();
                _gameForm.Show();
            };
            Controls.Add(_startButton);
        }

        public void InitSettingsButton()
        {
            _settingsButton = new Button();
            _settingsButton.Size = new Size(200, 100);
            _settingsButton.Location = new Point(Width / 2 + _settingsButton.Width / 2, Height / 2 - _settingsButton.Height / 2);
            _settingsButton.Text = "Settings";
            _settingsButton.TextAlign = ContentAlignment.MiddleCenter;
            _settingsButton.BackColor = Color.White;
            _settingsButton.Font = new Font(_fc.Families[0], 24f);
            Controls.Add(_settingsButton);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("Dodge or Die", new Font(_fc.Families[0], 52f), new SolidBrush(Color.IndianRed), new PointF(Width / 6, Height / 8));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
    }
}
