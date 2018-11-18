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
    public partial class Help : MetroFramework.Forms.MetroForm
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            labellicence.Text = "Licence " + GlobalVars.iservice_company_key;
        }

        private void labellicence_Click(object sender, EventArgs e)
        {

        }
    }
}
