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
    public partial class NewWorkItem : MetroFramework.Forms.MetroForm
    {
        public NewWorkItem()
        {
            InitializeComponent();
        }
        private readonly warehouse_works frm1;
        private readonly String Status;
        public NewWorkItem(warehouse_works frm, String status)
        {
            InitializeComponent();
            frm1 = frm;     
            Status = status;
        }
        private void NewWorkItem_Load(object sender, EventArgs e)
        {

            btnAdd.Text = Status;
            if (Status == "Add")
            {
                this.Text = "New work item";
                labelEmployee.Text = GlobalVars.Employee;
                labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            }
            else
            {
                this.Text = "Edit work item";
                
               
                labelEmployee.Text = GlobalVars.selected_iservice_customers_employee;
                labelDate.Text = GlobalVars.selected_iservice_customers_date_of_creation;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
