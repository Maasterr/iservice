using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iservice5
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
            this.ControlBox = false;
            if (Username != null)
            {
                metroTextBoxUsername.Text = Username;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
