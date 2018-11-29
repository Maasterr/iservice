using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iservice5.forms
{
    public partial class About : MetroFramework.Forms.MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            labellicence.Text = "Licence " + GlobalVars.iservice_company_key;
            label1.Text = "iservice v" + Application.ProductVersion;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
