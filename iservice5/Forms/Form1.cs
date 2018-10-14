using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iservice5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnService_Click(object sender, EventArgs e)
        {
            TextStatus.Text = btnService.Text;
           // panel1.Visible = false;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel4.Visible = true;
        }

        private void btnTimeLine_Click(object sender, EventArgs e)
        {
            TextStatus.Text = btnTimeLine.Text;
            panel4.Visible = false;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
           
           
            TextStatus.Text = btnService.Text;
        }



        private void btnOrders_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel4.Visible = true;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            TextStatus.Text = btnService.Text;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            TextStatus.Text = btnService.Text + " --> " + btnEmployee.Text;
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            warehouse newcustomer1 = new warehouse();
            newcustomer1.Show();
            panel4.Visible = false;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            TextStatus.Text = btnService.Text + " --> " + btnWarehouse.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panelCompanySetting.Visible = true;
            tableLayoutPanelCompanySetting.Visible = true;
            // panel1.Visible = true;
        }
        private void pictureBoxNewClient_Click(object sender, EventArgs e)
        {
           
                NewCustomer newcustomer = new NewCustomer(this, "Add");
                newcustomer.Show();
           
           
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
            if (GlobalVars.regnumber != null)
            {
                OrderPage orderpage = new OrderPage(this,"Add");
                orderpage.Show();

            }
            else
                MessageBox.Show("Please select car", "Notification", MessageBoxButtons.OK);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (GlobalVars.Client != null)
            {
                NewCar newcar = new NewCar(this, "Add");
                newcar.Show();
            }
            else
                MessageBox.Show("Please select client", "Notification", MessageBoxButtons.OK);
            
        }
        private void button23_Click(object sender, EventArgs e)
        {
            if (GlobalVars.Client != null)
            {
                NewCar newcar = new NewCar(this, "Edit");
                newcar.Show();
            }
            else
                MessageBox.Show("Please select car", "Notification", MessageBoxButtons.OK);
        }
        private void button29_Click(object sender, EventArgs e)
        {
            if (GlobalVars.OrderNumber != null)
            {
                OrderPage editorder = new OrderPage(this, "Edit");
                editorder.Show();
            }
            else
                MessageBox.Show("Please select car", "Notification", MessageBoxButtons.OK);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            NewCustomer newcustomer = new NewCustomer(this, "Save");
            newcustomer.Show();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            labelEmployee.Text = GlobalVars.Employee;
            
            textBoxSettingsName.Text = GlobalVars.iservice_company_name;
            textBoxSettingsCountry.Text = GlobalVars.iservice_company_country;
            textBoxSettingsCity.Text = GlobalVars.iservice_company_city;
            textBoxSettingsStreet.Text = GlobalVars.iservice_company_street;
            textBoxSettingsZipCode.Text = GlobalVars.iservice_company_zipcode;
            textBoxSettingsPhone.Text = GlobalVars.iservice_company_phone;
            textBoxSettingsFax.Text = GlobalVars.iservice_company_fax;
            textBoxSettingsEmail.Text = GlobalVars.iservice_company_email;
            textBoxSettingsVAT.Text = GlobalVars.iservice_company_vat_number;
            textBoxSettingsWebsite.Text = GlobalVars.iservice_company_website;

          //  panel1.Visible = false;
            panelCompanySetting.Visible = false;
            panel4.Visible = true;
            dataGridViewClients.DataSource = DataService.GetAllCustomers();
            dataGridViewClients.ClearSelection();
            tableLayoutPanelCompanySetting.Visible = false;







        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSettingLogo.Image = new Bitmap(opnfd.FileName);

            }
 
        }
        private void button12_Click(object sender, EventArgs e)
        {
            dataGridViewClients.DataSource = DataService.GetCustomersByWord(textBox3.Text);
            dataGridViewClients.ClearSelection();
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
           dataGridViewCars.DataSource = DataService.GetCarsByCustomer(-1);

            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);


        }
        private void dataGridViewClients_Click(object sender, EventArgs e)
        {
            String s=null;
            if (dataGridViewClients.SelectedRows.Count > 0)
            {   s = dataGridViewClients.SelectedRows[0].Cells[0].Value.ToString();
                labelClients.Text = dataGridViewClients.SelectedRows[0].Cells[1].Value.ToString() + " " + dataGridViewClients.SelectedRows[0].Cells[2].Value.ToString();
              GlobalVars.Client = labelClients.Text;

                GlobalVars.selected_iservice_customers_id = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_id;
                GlobalVars.selected_iservice_customers_name = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_name;
                GlobalVars.selected_iservice_customers_surname = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_surname;
                GlobalVars.selected_iservice_customers_patronymic = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_patronymic;
                GlobalVars.selected_iservice_customers_country = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_country;
                GlobalVars.selected_iservice_customers_city = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_city;
                GlobalVars.selected_iservice_customers_street = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_street;
                GlobalVars.selected_iservice_customers_zipcode = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_zipcode;
                GlobalVars.selected_iservice_customers_telephone = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_telephone;
                GlobalVars.selected_iservice_customers_telephone_home = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_telephone_home;
                GlobalVars.selected_iservice_customers_date_of_birthday = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_date_of_birthday;
                GlobalVars.selected_iservice_customers_date_of_creation = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_date_of_creation;
                GlobalVars.selected_iservice_customers_email = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_email;
                GlobalVars.selected_iservice_customers_employee = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_employee;
                GlobalVars.selected_iservice_customers_company = DataService.GetCustomersById(Int32.Parse(s))[0].iservice_customers_company;



            }
            else
                labelCars.Text = "Please select client";

         
           if (s != null)
            {
                try
                {
                    dataGridViewCars.DataSource = DataService.GetCarsByCustomer(Int32.Parse(s));
                    dataGridViewCars.ClearSelection();


                    if (dataGridViewCars.SelectedRows.Count > 0)
                    {
                        labelCars.Text = dataGridViewCars.SelectedRows[0].Cells[2].Value.ToString();

                        GlobalVars.regnumber = labelCars.Text;



                        String s2 = dataGridViewCars.SelectedRows[0].Cells[0].Value.ToString();

                        /* if(e.RowIndex==9)
                       {
                           MessageBox.Show((e.RowIndex+1).ToString() +" Row Clicked");
                       }
                        */
                        if (s2 != null)
                        {

                            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(Int32.Parse(s2));
                          



                            if (dataGridViewOrders.SelectedRows.Count > 0)
                            {
                                labelOrders.Text = dataGridViewOrders.SelectedRows[0].Cells[3].Value.ToString();
                                GlobalVars.OrderNumber = labelOrders.Text;
                            }
                            else
                                labelOrders.Text = "Please select order";




                        }


                    }
                    else
                    {
                        labelCars.Text = "Please select car";
                        labelOrders.Text = "Please select order";
                        dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);
                    }


                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              

            }



        }

       

        private void dataGridViewCars_Click(object sender, EventArgs e)
        {
            String s2=null;
            if (dataGridViewCars.SelectedRows.Count > 0)
            {
                s2 = dataGridViewCars.SelectedRows[0].Cells[0].Value.ToString();
                labelCars.Text = dataGridViewCars.SelectedRows[0].Cells[2].Value.ToString();
                GlobalVars.regnumber = labelCars.Text;
                GlobalVars.selected_iservice_cars_id = Convert.ToInt32(dataGridViewCars.SelectedRows[0].Cells[0].Value);
                GlobalVars.selected_iservice_cars_reg_number = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[2].Value);
                GlobalVars.selected_iservice_cars_vin = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[3].Value);
                GlobalVars.selected_iservice_cars_brand = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[4].Value);
                GlobalVars.selected_iservice_cars_model = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[5].Value);
                GlobalVars.selected_iservice_cars_date_of_creation = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[8].Value);
                GlobalVars.selected_iservice_cars_year = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[6].Value);
                GlobalVars.selected_iservice_cars_color = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[7].Value);
                GlobalVars.selected_iservice_cars_employee = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[9].Value);
            }
            else
                labelCars.Text = "Please select car";

            if (s2 != null)
            {
                try
                {
                    dataGridViewOrders.DataSource = DataService.GetOrdersByCar(Int32.Parse(s2));

                    if (dataGridViewOrders.SelectedRows.Count > 0)
                    {
                        labelOrders.Text = dataGridViewOrders.SelectedRows[0].Cells[3].Value.ToString();
                        GlobalVars.OrderNumber = labelOrders.Text;
                    }
                    else
                        labelOrders.Text = "Please select order";

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DataService.CompanySetData(GlobalVars.iservice_company_inside_id, textBoxSettingsName.Text, textBoxSettingsCountry.Text, textBoxSettingsCity.Text, textBoxSettingsStreet.Text, textBoxSettingsZipCode.Text, textBoxSettingsPhone.Text, textBoxSettingsFax.Text, textBoxSettingsVAT.Text, textBoxSettingsWebsite.Text, textBoxSettingsEmail.Text) == null)
            {
                MessageBox.Show("Succesfully saved", "Notification", MessageBoxButtons.OK);
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\images\logo.png";
                pictureBoxSettingLogo.Image.Save(appPath, System.Drawing.Imaging.ImageFormat.Png);
                label19.Text = "Saved";
            }
            else
            {
                MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);

                label19.Text = "Error";
            }
        }

       
        private void dataGridViewOrders_Click(object sender, EventArgs e)
        {
            if (dataGridViewCars.SelectedRows.Count > 0)
            {
                labelOrders.Text = dataGridViewOrders.SelectedRows[0].Cells[3].Value.ToString();
                GlobalVars.OrderNumber = labelOrders.Text;
                GlobalVars.selected_iservice_orders_id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                labelOrders.Text = Convert.ToString(dataGridViewOrders.SelectedRows[0].Cells[0].Value);

            }
            else
                labelOrders.Text = "Please select order";
            labelOrders.Text = Convert.ToString(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
        }
        public void updateclientsdata()
        {
            dataGridViewClients.DataSource = DataService.GetAllCustomers();
            dataGridViewClients.ClearSelection();
        }
        public void updatecarsdata()
        {
            dataGridViewCars.DataSource = DataService.GetCarsByCustomer(GlobalVars.selected_iservice_customers_id);
            dataGridViewCars.ClearSelection();
        }
       

      

        private void textBox3_Enter(object sender, DragEventArgs e)
        {
                
            }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                dataGridViewClients.DataSource = DataService.GetCustomersByWord(textBox3.Text);
                dataGridViewClients.ClearSelection();
                labelCars.Text = "Please select car";
                labelOrders.Text = "Please select order";
                dataGridViewCars.DataSource = DataService.GetCarsByCustomer(-1);
                dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);
            }
        }

        private void buttonShowAllCustomers_Click(object sender, EventArgs e)
        {
            dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
            dataGridViewClients.ClearSelection();
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
            dataGridViewCars.DataSource = DataService.GetCarsByCustomer(-1);

            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }

   
}
