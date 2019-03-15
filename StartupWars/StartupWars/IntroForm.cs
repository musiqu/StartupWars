using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupWars
{
    public partial class IntroForm : Form
    {
        public string Difficulty { get; set; }
        public decimal StartBank { get; set; }
        public decimal StartDebt { get; set; }
        public int GameLength { get; set; }

        public IntroForm()
        {
            InitializeComponent();
        }

        private void IntroForm_Load(object sender, EventArgs e)
        {
            CenterToParent(); //center to main form
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            //initialize game for "Easy"
            Difficulty = "Easy";
            StartBank = 100000.00M;
            StartDebt = 25000.00M;
            GameLength = 24;
            Close();
        }
    }
}
