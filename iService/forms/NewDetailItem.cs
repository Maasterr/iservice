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
        private readonly Form1 frm2;
        private readonly String Status;
       
        public NewDetailItem(warehouse_details frm, Form1 frmm, String status)
        {
            InitializeComponent();
            if (frm!=null)
            frm1 = frm;
            else frm2 = frmm;
            Status = status;
        }
       
        private void NewDetailItem_Load(object sender, EventArgs e)
        {

            btnAdd.Text = Status;
            if (Status == "Add")
            {
                this.Text = "Новая запчасть или материал";
                labelEmployee.Text = GlobalVars.Employee;
                labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                else if (DataService.NewItem("Details", 1, 1, textBoxDesc.Text, textBoxPricePNetto.Text, textBoxPricePBrutto.Text, textBoxPriceNetto.Text, textBoxPriceBrutto.Text, GlobalVars.Employee, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), textBoxqty.Text, comboBoxqtytype.SelectedIndex.ToString()) == null)
                {
                    if (frm1 != null)
                        frm1.updatedetailsdata();
                    else
                        frm2.updatedetailsdata();
                    this.Close();
                    MessageBox.Show("Succesfully added", "Notification", MessageBoxButtons.OK);
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
