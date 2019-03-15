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
    public partial class PopupBoxForm : Form
    {
        private string Message { get; set; }
        private string Title { get; set; }
        private string Buttons { get; set; }
        public bool YesClick { get; set; }

        public PopupBoxForm(string boxMessage, string buttonStyle)
        {
            Message = boxMessage;
            Title = "";
            Buttons = buttonStyle;
            InitializeComponent();
        }

        public PopupBoxForm(string boxMessage, string boxTitle, string buttonStyle)
        {
            Message = boxMessage;
            Title = boxTitle;
            Buttons = buttonStyle;
            InitializeComponent();
        }

        private void PopupBoxForm_Load(object sender, EventArgs e)
        {
            CenterToParent();

            //Set title and message
            lblTitle.Text = Title;
            txtboxPopUpBox.Text = Message;

            //Display appropriate buttons on Load
            if (Buttons == "OK")
            {
                btnOK.Enabled = true;
                btnOK.Visible = true;
            }
            else if (Buttons == "YesNo")
            {
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnYes.Visible = true;
                btnNo.Visible = true;
                YesClick = false;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            YesClick = true;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
