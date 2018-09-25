using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace iservice5
{
    public partial class NewCar : MetroFramework.Forms.MetroForm
    {
        public NewCar()
        {
            InitializeComponent();
        }
        private readonly Form1 frm1;
        private readonly String Status;
        public NewCar(Form1 frm, String status)
        {
            InitializeComponent();
            frm1 = frm;
            Status = status;

        }

        private void NewCar_Load(object sender, EventArgs e)
        {
            labelName.Text = GlobalVars.Client;
            
        
            if (Status == "Add")
            {
                btnAdd.Text = GlobalString.Add;
                this.Text = "New car";
                labelEmployee.Text = GlobalVars.Employee;
                labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
            else
            {
                btnAdd.Text = GlobalString.Save;
                this.Text = "Edit car";
                labelName.Text = GlobalVars.selected_iservice_customers_name;
                textBoxReg.Text = GlobalVars.selected_iservice_cars_reg_number;
                textBoxVin.Text = GlobalVars.selected_iservice_cars_vin;
                textBoxBrand.Text = GlobalVars.selected_iservice_cars_brand;
                textBoxModel.Text = GlobalVars.selected_iservice_cars_model;
                textBoxYear.Text = GlobalVars.selected_iservice_cars_year;
                textBoxColor.Text = GlobalVars.selected_iservice_cars_color;

                labelEmployee.Text = GlobalVars.selected_iservice_cars_employee;
                labelDate.Text = GlobalVars.selected_iservice_cars_date_of_creation;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Status == "Add")
            {
                if ((textBoxReg.Text == "") || (textBoxVin.Text == "") || (textBoxBrand.Text == "") || (textBoxModel.Text == "") || (textBoxYear.Text == ""))
                    MessageBox.Show("Required fields is empty", "Notification", MessageBoxButtons.OK);
                else if (DataService.NewCar(GlobalVars.selected_iservice_customers_id, textBoxReg.Text, textBoxBrand.Text, textBoxModel.Text, textBoxVin.Text, textBoxYear.Text, textBoxColor.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), labelEmployee.Text) == null)
                {
                    frm1.updatecarsdata();
                    this.Close();
                    MessageBox.Show("Succesfully added", "Notification", MessageBoxButtons.OK);

                }
                else
                {
                    this.Close();
                    MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);


                }
            }
          else if (DataService.EditCar(GlobalVars.selected_iservice_cars_id, textBoxReg.Text, textBoxBrand.Text, textBoxModel.Text, textBoxVin.Text, textBoxYear.Text, textBoxColor.Text) == null)
            {
                frm1.updatecarsdata();
                this.Close();
                MessageBox.Show("Succesfully saved", "Notification", MessageBoxButtons.OK);

            }
            else
            {
                this.Close();
                MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
