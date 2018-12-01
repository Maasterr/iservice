using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iService
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }
        private readonly Form1 frm1;
        private readonly String Username;
        public Login(Form1 frm, String username)
        {
            InitializeComponent();
            frm1 = frm;
            Username = username;

        }
        private void Login_Load(object sender, EventArgs e)
        {
            metroTextBoxKey.Text = Convert.ToString(DataService.GetKey()[0].iservice_company_key);
            metroButton3.Text = "Check";
            checkkey();
            this.ControlBox = false;
            if (Username != null)
            {
                metroTextBoxUsername.Text = Username;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == true)
            {

            if (DataService.CheckLogin(metroTextBoxUsername.Text, metroTextBoxPassword.Text).Count >0)
            {
                GlobalVars.Employee = metroTextBoxUsername.Text;
                GlobalVars.Employee_id = DataService.CheckLogin(metroTextBoxUsername.Text, metroTextBoxPassword.Text)[0].iservice_users_id;
               
                this.DialogResult = DialogResult.OK;
                this.Close();
               
            }
            else
                MessageBox.Show("Error", "Notification", MessageBoxButtons.OK);

            }
            else
                MessageBox.Show("Key error", "Notification", MessageBoxButtons.OK);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkkey()
        {
            if (metroButton3.Text == "Check")
            {
                if (DataService.CheckKey(metroTextBoxKey.Text).Count > 0)
                {                 
                    DataService.UpdateKey(metroTextBoxKey.Text);
                    GlobalVars.iservice_company_key = Convert.ToInt32(metroTextBoxKey.Text);
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    metroTextBoxKey.Enabled = false;
                    metroButton3.Text = "Change";
                }
                else
                {
                    pictureBox3.Visible = false;
                    pictureBox2.Visible = true;
                }
            }
            else if (metroButton3.Text == "Change")
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
                metroTextBoxKey.Enabled = true;
                metroButton3.Text = "Check";
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            checkkey();
         }
    }
}
