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
    public partial class PayDebtForm : Form
    {
        public decimal Debt { get; set; }
        public decimal AmountPaid { get; set; }

        public PayDebtForm(decimal debt)
        {
            Debt = debt;

            InitializeComponent();
        }

        private void PayDebtForm_Load(object sender, EventArgs e)
        {
            CenterToParent();

            txtboxDebtInfo.Text = Debt.ToString("C");

            //run accept button click event when "enter" is pressed
            AcceptButton = btnPayDebt;
        }

        private void txtboxAmountToPay_TextChanged(object sender, EventArgs e)
        {
            //enable payDebt button if text is present in AmountToPay text box
            btnPayDebt.Enabled = !string.IsNullOrWhiteSpace(txtboxAmountToPay.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPayDebt_Click(object sender, EventArgs e)
        {
            //see if value in text box is valid
            if (Decimal.TryParse(txtboxAmountToPay.Text, out decimal amountTowardsDebt))
            {
                if (amountTowardsDebt <= Debt)
                {
                    PopupBoxForm popupPayDebt = new PopupBoxForm(
                        "Are you sure you would like to pay this amount?\r\n" +
                            $"{amountTowardsDebt.ToString("C")}",
                        "Pay Debt?", "YesNo"); // create new PopUpBox
                    popupPayDebt.ShowDialog(this); //display Popup box as child form

                    //If Yes was clicked...
                    if (popupPayDebt.YesClick)
                    {
                        Debt -= amountTowardsDebt;
                        AmountPaid = amountTowardsDebt;
                        Close();
                    }
                }
                else
                {
                    PopupBoxForm popupAmountTooHigh = new PopupBoxForm(
                        "The amount entered must be lower than or equal to the total debt.",
                        "OK"); // create new PopUpBox
                    popupAmountTooHigh.ShowDialog(this); //display Popup box as child form

                    txtboxAmountToPay.Text = "";
                }   
            }
            else
            {
                PopupBoxForm popupInvalidInput = new PopupBoxForm(
                    "Invalid input - Please try again.", "OK"); // create new PopUpBox
                popupInvalidInput.ShowDialog(this); //display Popup box as child form

                txtboxAmountToPay.Text = "";
            }
        }
    }
}
