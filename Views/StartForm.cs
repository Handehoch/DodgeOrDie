using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class StartForm : Form
    {
        private GameForm gameForm;

        public StartForm()
        {
            InitializeComponent();
            gameForm = new GameForm();
            InitControls();
        }

        //TO-DO
        public void InitControls()
        {
            var startButton = new Button();
            startButton.Size = new Size(200, 100);
            startButton.Location = new Point(Width / 2 - startButton.Width / 2, Height / 2 - startButton.Height / 2);
            startButton.Text = "Start Game";
            startButton.Click += (s, e) => gameForm.Show();
            Controls.Add(startButton);
        }
    }
}
