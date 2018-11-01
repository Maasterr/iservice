using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace iservice5
{
    public partial class NewCustomer : MetroFramework.Forms.MetroForm
    {
        public NewCustomer()
        {
            InitializeComponent();
        }
        private readonly Form1 frm1;
        private readonly String Status;
        public NewCustomer(Form1 frm, String status)
        {
            InitializeComponent();
            frm1 = frm;
            Status = status;
           
        }
       
        private void NewCustomer_Load(object sender, EventArgs e)
        {
           
            btnAdd.Text = Status;
            if (Status == "Add")
            {    this.Text = "New customer";
            labelEmployee.Text = GlobalVars.Employee;
                labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
            else
            {
                this.Text = "Edit customer";
                textBoxName.Text = GlobalVars.selected_iservice_customers_name;
                textBoxSurname.Text = GlobalVars.selected_iservice_customers_surname;
                textBoxPatr.Text = GlobalVars.selected_iservice_customers_patronymic;
                textBoxCountry.Text = GlobalVars.selected_iservice_customers_country;
                textBoxCity.Text = GlobalVars.selected_iservice_customers_city;
                textBoxStreet.Text = GlobalVars.selected_iservice_customers_street;
                textBoxZipCode.Text = GlobalVars.selected_iservice_customers_zipcode;
                textBoxPhone.Text = GlobalVars.selected_iservice_customers_telephone;
                textBoxPhonehome.Text = GlobalVars.selected_iservice_customers_telephone_home;
                textBoxEmail.Text = GlobalVars.selected_iservice_customers_email;
                textBoxCompany.Text = GlobalVars.selected_iservice_customers_company;
                if (textBoxCompany.Text != "")
                    checkBox1.Checked = true;
                dateTimePickerBirthay.Value = Convert.ToDateTime(GlobalVars.selected_iservice_customers_date_of_birthday);
                labelEmployee.Text = GlobalVars.selected_iservice_customers_employee;
                labelDate.Text = GlobalVars.selected_iservice_customers_date_of_creation;
            }

        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Status == "Add")
            {
                if ((textBoxName.Text == "") || (textBoxSurname.Text == ""))
                    MessageBox.Show("Required fields is empty", "Notification", MessageBoxButtons.OK);
                else if (DataService.NewCustomer(textBoxName.Text, textBoxSurname.Text, textBoxPatr.Text, textBoxCountry.Text, textBoxCity.Text, textBoxStreet.Text, textBoxZipCode.Text, textBoxPhone.Text, textBoxPhonehome.Text, dateTimePickerBirthay.Value.Date.ToString("dd/MM/yyyy"), textBoxEmail.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), labelEmployee.Text, textBoxCompany.Text) == null)
                {
                    frm1.updateclientsdata();
                    this.Close();
                    MessageBox.Show("Succesfully added", "Notification", MessageBoxButtons.OK);

                }
                else
                {
                    this.Close();
                    MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);


                }
            }
            else if (DataService.EditCustomerById(GlobalVars.selected_iservice_customers_id,textBoxName.Text, textBoxSurname.Text, textBoxPatr.Text, textBoxCountry.Text, textBoxCity.Text, textBoxStreet.Text, textBoxZipCode.Text, textBoxPhone.Text, textBoxPhonehome.Text, dateTimePickerBirthay.Value.Date.ToString("dd/MM/yyyy"), textBoxEmail.Text, labelDate.Text, labelEmployee.Text, textBoxCompany.Text) == null)
            {
                frm1.updateclientsdata();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
        }

        private void dateTimePickerBirthay_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerBirthay.CustomFormat = "dd/MM/yyyy";
        }
    }
}
