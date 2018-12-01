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
    public partial class NewDetailItem : MetroFramework.Forms.MetroForm
    {
        public NewDetailItem()
        {
            InitializeComponent();
        }
        private readonly warehouse_details frm1;
        private readonly String Status;
        public NewDetailItem(warehouse_details frm, String status)
        {
            InitializeComponent();
            frm1 = frm;
            Status = status;
        }
        private void NewDetailItem_Load(object sender, EventArgs e)
        {

            btnAdd.Text = Status;
            if (Status == "Add")
            {
                this.Text = "New detail";
                labelEmployee.Text = GlobalVars.Employee;
                labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            }
            else
            {
                this.Text = "Edit detail";


                labelEmployee.Text = GlobalVars.selected_iservice_customers_employee;
                labelDate.Text = GlobalVars.selected_iservice_customers_date_of_creation;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Status == "Add")
            {
                if ((textBoxDesc.Text == "") || (textBoxPriceNetto.Text == "") || (textBoxPriceBrutto.Text == "") || (textBoxqty.Text == ""))
                    MessageBox.Show("Required fields is empty", "Notification", MessageBoxButtons.OK);
                else if (DataService.NewItem("Details", 1, 1, textBoxDesc.Text, textBoxPricePNetto.Text, textBoxPricePBrutto.Text, textBoxPriceNetto.Text, textBoxPriceBrutto.Text, GlobalVars.Employee, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), DateTime.Now.ToString("yyyy-MM-dd hh:mm"), textBoxqty.Text, comboBoxqtytype.SelectedIndex.ToString()) == null)
                {
                    frm1.updatedetailsdata();
                    this.Close();
                    MessageBox.Show("Succesfully added" + comboBoxqtytype.SelectedIndex.ToString(), "Notification", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);


                }
            }
        }
    }
}
