using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validator validate = new Validator();
            if (validate.Year(txtYear.Text))
            {
                if (validate.Session(txtSession.Text))
                {
                    Form2 obj = new Form2();
                    obj.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong input for the Session\n Either Fall, Winter or Summer");
                    txtYear.Focus();
                }
            }
            else
            {
                MessageBox.Show("Wrong input for the year\n From 2020 to 2029");
                txtYear.Focus();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to exit the app?", "Exit", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question).ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "Aurelien Ebeng Djeungoue Mokube 202211536";
            txtSession.Text = "Summer";
            txtYear.Text = "2023";
        }
    }
    
}
