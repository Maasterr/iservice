using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iService.forms
{
    public partial class Help : MetroFramework.Forms.MetroForm
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            labellicence.Text = "Лицензия " + GlobalVars.iservice_company_key;
            label1.Text = "iservice v" + Application.ProductVersion;
        }

        private void labellicence_Click(object sender, EventArgs e)
        {

        }
    }
}
