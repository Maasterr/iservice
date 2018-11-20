using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iservice5
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            InitializeComponent();
            for(int i = 0; i <= 500; i++)
            {
                Thread.Sleep(5);
            }
            t.Abort();
        }
        public void StartForm()
        {
            forms.SplashScreen splashform = new forms.SplashScreen();
            Application.Run(splashform);
            //Application.Run(new forms.Splash());
        }


        private void btnService_Click(object sender, EventArgs e)
        {
            TextStatus.Text = btnService.Text;
            panel_dashboard.Visible = false;
            panel4.Visible = true;
            tableLayoutPanelCompanySetting.Visible = false;
            panelCompanySetting.Visible = false;
            panel_timeline.Visible = false;
            panelwarehouse.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel_setting_import.Visible = false;
        }

        private void btnTimeLine_Click(object sender, EventArgs e)
        {
            TextStatus.Text = btnService.Text;
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panelCompanySetting.Visible = false;
            panel_timeline.Visible = true;
            panelwarehouse.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel_setting_import.Visible = false;
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panel_dashboard.Visible = true;
            panel4.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panelCompanySetting.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel_setting_import.Visible = false;
            panelwarehouse.Visible = false;
            TextStatus.Text = btnDashboard.Text;
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            //warehouse newcustomer1 = new warehouse();
            //newcustomer1.Show();
            TextStatus.Text = btnService.Text;
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panelCompanySetting.Visible = false;
            panel_timeline.Visible = false;
            panelwarehouse.Visible = true;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel_setting_import.Visible = false;
            TextStatus.Text = btnService.Text + " --> " + btnWarehouse.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            panel_setting_import.Visible = false;
            panelCompanySetting.Visible = true;
            panelwarehouse.Visible = false;
            tableLayoutPanelCompanySetting.Visible = true;
            TextStatus.Text = btnDashboard.Text + " --> " + button_company.Text;

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
                DataService.NewOrder(GlobalVars.selected_iservice_cars_id, GlobalVars.Employee_id, "", DateTime.Now.ToString("yyyy-MM-dd hh:mm"), "", "", "", "", "", "","");
                GlobalVars.selected_iservice_orders_id = DataService.GetLastOrderNumber()[0].iservice_orders_id;
                dataGridViewOrders.ClearSelection();
                labelOrders.Text = "Please select order";
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
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                OrderPage editorder = new OrderPage(this, "Edit");
                editorder.Show();
            }
            else
                MessageBox.Show("Please select order", "Notification", MessageBoxButtons.OK);
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
            //Order panel
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\images\logo.png";
            try
            {
               pictureBoxSettingLogo.Image = Image.FromFile(appPath);
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            textBoxDocPath.Text = DataService.CompanyGetData(GlobalVars.iservice_company_key)[0].iservice_company_path;
            GlobalVars.iservice_company_path = textBoxDocPath.Text;
            //Order panel end

            labelLicence.Text = "Licence " + GlobalVars.iservice_company_key;
            dataGridViewOrdersinProcess.DataSource = DataService.GetOrderStatusList();
            dataGridView_lastactivecars.DataSource = DataService.GetOrderStatusList();
            dataGridView_lastactivecustomers.DataSource = DataService.GetOrderStatusList();
            dataGridView_lastclosedorders.DataSource = DataService.GetOrderStatusList();
            dataGridView_lastmadejobs.DataSource = DataService.GetOrderStatusList();
            dataGridView_lastsolddetails.DataSource = DataService.GetOrderStatusList();
            dataGridViewOrdersinProcess.ClearSelection();
            dataGridView_lastactivecars.ClearSelection();
            dataGridView_lastactivecustomers.ClearSelection();
            dataGridView_lastclosedorders.ClearSelection();
            dataGridView_lastmadejobs.ClearSelection();
            dataGridView_lastsolddetails.ClearSelection();

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
            panel_dashboard.Visible = true;
            panel4.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panelCompanySetting.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            tableLayoutPanelCompanySetting.Visible = false;
            panel_setting_import.Visible = false;
            panelwarehouse.Visible = false;
            TextStatus.Text = btnDashboard.Text;

            dataGridViewClients.DataSource = DataService.GetAllCustomers();
            dataGridViewClients.ClearSelection();
            tableLayoutPanelCompanySetting.Visible = false;






            dataGridViewTimeLine.Rows.Add("6.00-6.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("6.30-7.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("7.00-7.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("7.30-8.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("8.00-8.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("8.30-9.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("9.00-9.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("9.30-10.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("10.00-10.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("10.30-11.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("11.00-11.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("11.30-12.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("12.00-12.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("12.30-13.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("13.00-13.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("13.30-14.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("14.00-14.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("14.30-15.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("15.00-15.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("15.30-16.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("16.00-16.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("16.30-17.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("17.00-17.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("17.30-18.00", "", "", "");
            dataGridViewTimeLine.Rows.Add("18.00-18.30", "", "", "");
            dataGridViewTimeLine.Rows.Add("18.30-19.00", "", "", "");
            // dataGridViewTimeLine.Rows.Add("19.00-19.30", "", "", "");
            //dataGridViewTimeLine.Rows.Add("19.30-20.00", "", "", "");

            dataGridViewTimeLine.Rows[0].Visible = false;
            dataGridViewTimeLine.Rows[1].Visible = false;
            dataGridViewTimeLine.Rows[2].Visible = false;
            dataGridViewTimeLine.Rows[3].Visible = false;
            for (int j = 1; j < dataGridViewTimeLine.Columns.Count; ++j)
            {
                if (DataService.TimelineGetDayByDateandStation("14",j.ToString()).Count > 0) { 
                 
                        dataGridViewTimeLine[j, 0].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_600_630;
                        dataGridViewTimeLine[j, 1].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_630_700;
                        dataGridViewTimeLine[j, 2].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_700_730;
                        dataGridViewTimeLine[j, 3].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_730_800;
                        dataGridViewTimeLine[j, 4].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_800_830;
                        dataGridViewTimeLine[j, 5].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_830_900;
                        dataGridViewTimeLine[j, 6].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_900_930;
                        dataGridViewTimeLine[j, 7].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_930_1000;
                        dataGridViewTimeLine[j, 8].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1000_1030;
                        dataGridViewTimeLine[j, 9].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1030_1100;
                        dataGridViewTimeLine[j, 10].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1100_1130;
                        dataGridViewTimeLine[j, 11].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1130_1200;
                        dataGridViewTimeLine[j, 12].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1200_1230;
                        dataGridViewTimeLine[j, 13].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1230_1300;
                        dataGridViewTimeLine[j, 14].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1300_1330;
                        dataGridViewTimeLine[j, 15].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1330_1400;
                        dataGridViewTimeLine[j, 16].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1400_1430;
                        dataGridViewTimeLine[j, 17].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1430_1500;
                        dataGridViewTimeLine[j, 18].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1500_1530;
                        dataGridViewTimeLine[j, 19].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1530_1600;
                        dataGridViewTimeLine[j, 20].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1600_1630;
                        dataGridViewTimeLine[j, 21].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1630_1700;
                        dataGridViewTimeLine[j, 22].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1700_1730;
                        dataGridViewTimeLine[j, 23].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1730_1800;
                        dataGridViewTimeLine[j, 24].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1800_1830;
                        dataGridViewTimeLine[j, 24].Value = DataService.TimelineGetDayByDateandStation("14",j.ToString())[0].iservice_timeline_1830_1900;
                    }          
            }

            for (int i = 0; i < DataService.ItemsDetailsGetData().Count; i++)
            {
                dataGridViewItemsDetails.Rows.Add(DataService.ItemsDetailsGetData()[i].iservice_items_id, DataService.ItemsDetailsGetData()[i].iservice_items_type, DataService.ItemsDetailsGetData()[i].iservice_items_category, DataService.ItemsDetailsGetData()[i].iservice_items_subcategory, DataService.ItemsDetailsGetData()[i].iservice_items_description, DataService.ItemsDetailsGetData()[i].iservice_items_qty, DataService.ItemsDetailsGetData()[i].iservice_items_purchase_price_netto, DataService.ItemsDetailsGetData()[i].iservice_items_purchase_price_brutto, DataService.ItemsDetailsGetData()[i].iservice_items_price_netto, DataService.ItemsDetailsGetData()[i].iservice_items_price_brutto, "", DataService.ItemsDetailsGetData()[i].iservice_items_qty_type);
            }
            dataGridViewItemsDetails.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSettingLogo.InitialImage = null;
                pictureBoxSettingLogo.Image.Dispose();
                pictureBoxSettingLogo.Image = null;
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

                        if (s2 != null)
                        {

                            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(Int32.Parse(s2));
                            dataGridViewOrders.ClearSelection();



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
        private void dataGridViewCars_CurrentCellChanged(object sender, EventArgs e)
        {
           
        }
        private void dataGridViewClients_CurrentCellChanged(object sender, EventArgs e)
        {
           
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
                GlobalVars.selected_iservice_cars_customers_id = Convert.ToInt32(dataGridViewCars.SelectedRows[0].Cells[1].Value);
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




            String s = null;
            if (dataGridViewCars.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewClients.Rows)
                {

                    if (Convert.ToInt32(row.Cells[0].Value) == GlobalVars.selected_iservice_cars_customers_id)
                    {

                        dataGridViewClients.Rows[row.Index].Selected = true;
                        dataGridViewClients.FirstDisplayedScrollingRowIndex = dataGridViewClients.SelectedRows[0].Index;


                        s = dataGridViewClients.SelectedRows[0].Cells[0].Value.ToString();
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

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\images\logo.png";

            if (DataService.CompanySetData(GlobalVars.iservice_company_key, textBoxSettingsName.Text, textBoxSettingsCountry.Text, textBoxSettingsCity.Text, textBoxSettingsStreet.Text, textBoxSettingsZipCode.Text, textBoxSettingsPhone.Text, textBoxSettingsFax.Text, textBoxSettingsVAT.Text, textBoxSettingsWebsite.Text, textBoxSettingsEmail.Text, textBoxDocPath.Text) == null)
            {
                 Bitmap bmp = new Bitmap(pictureBoxSettingLogo.Image);
                pictureBoxSettingLogo.InitialImage = null;
                pictureBoxSettingLogo.Image.Dispose();
                pictureBoxSettingLogo.Image = null;
                if (System.IO.File.Exists(appPath))
                    System.IO.File.Delete(appPath);
                bmp.Save(appPath, System.Drawing.Imaging.ImageFormat.Png);
              
                 MessageBox.Show("Succesfully saved", "Notification", MessageBoxButtons.OK);

                GlobalVars.iservice_company_path = textBoxDocPath.Text;

               
            }
            else
            {
                MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);

               
            }
            //Thread.Sleep(2000);
            try
            {
                pictureBoxSettingLogo.Image = Image.FromFile(appPath);
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        private void dataGridViewOrders_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                labelOrders.Text = dataGridViewOrders.SelectedRows[0].Cells[3].Value.ToString();
                GlobalVars.OrderNumber = labelOrders.Text;
                GlobalVars.selected_iservice_orders_id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                GlobalVars.selected_iservice_orders_cars_id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[1].Value);
                GlobalVars.selected_iservice_orders_user_name = Convert.ToString(dataGridViewOrders.SelectedRows[0].Cells[15].Value);
                GlobalVars.selected_iservice_orders_mileage = Convert.ToString(dataGridViewOrders.SelectedRows[0].Cells[14].Value);
            }
            else
                labelOrders.Text = "Please select order";



            String s2 = null;
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewCars.Rows)
                {

                    if (Convert.ToInt32(row.Cells[0].Value) == GlobalVars.selected_iservice_orders_cars_id)
                    {
                        dataGridViewCars.Rows[row.Index].Selected = true;
                        dataGridViewCars.FirstDisplayedScrollingRowIndex = dataGridViewCars.SelectedRows[0].Index;
               
                        s2 = dataGridViewCars.SelectedRows[0].Cells[0].Value.ToString();
                        labelCars.Text = dataGridViewCars.SelectedRows[0].Cells[2].Value.ToString();
                        GlobalVars.regnumber = labelCars.Text;
                        GlobalVars.selected_iservice_cars_id = Convert.ToInt32(dataGridViewCars.SelectedRows[0].Cells[0].Value);
                        GlobalVars.selected_iservice_cars_customers_id = Convert.ToInt32(dataGridViewCars.SelectedRows[0].Cells[1].Value);
                        GlobalVars.selected_iservice_cars_reg_number = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[2].Value);
                        GlobalVars.selected_iservice_cars_vin = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[3].Value);
                        GlobalVars.selected_iservice_cars_brand = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[4].Value);
                        GlobalVars.selected_iservice_cars_model = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[5].Value);
                        GlobalVars.selected_iservice_cars_date_of_creation = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[8].Value);
                        GlobalVars.selected_iservice_cars_year = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[6].Value);
                        GlobalVars.selected_iservice_cars_color = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[7].Value);
                        GlobalVars.selected_iservice_cars_employee = Convert.ToString(dataGridViewCars.SelectedRows[0].Cells[9].Value);
                    }
                }
            }
            String s = null;
            if (dataGridViewCars.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewClients.Rows)
                {

                    if (Convert.ToInt32(row.Cells[0].Value) == GlobalVars.selected_iservice_cars_customers_id)
                    {

                        dataGridViewClients.Rows[row.Index].Selected = true;
                        dataGridViewClients.FirstDisplayedScrollingRowIndex = dataGridViewClients.SelectedRows[0].Index;


                        s = dataGridViewClients.SelectedRows[0].Cells[0].Value.ToString();
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

                }

            }

        }
        public void updateclientsdata()
        {
            dataGridViewClients.DataSource = DataService.GetAllCustomers();
            dataGridViewClients.ClearSelection();
            labelClients.Text = "Please select clients";
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";

        }
        public void updatecarsdata()
        {
            dataGridViewCars.DataSource = DataService.GetCarsByCustomer(GlobalVars.selected_iservice_customers_id);
            dataGridViewCars.ClearSelection();
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";

        }
        public void updateordersdata()
        {
            labelOrders.Text = "Please select order";
            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(GlobalVars.selected_iservice_cars_id);
            dataGridViewOrders.ClearSelection();
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

        private void button_search_cars_Click(object sender, EventArgs e)
        {

            dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
            dataGridViewCars.DataSource = DataService.GetCarsByWord(textBox_search_cars.Text);
            dataGridViewClients.ClearSelection();
            dataGridViewCars.ClearSelection();
            labelClients.Text = "Please select clients";
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);
        }

        private void button_search_cars_all_Click(object sender, EventArgs e)
        {
            dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
            dataGridViewCars.DataSource = DataService.GetAllCars();
            dataGridViewClients.ClearSelection();
            dataGridViewCars.ClearSelection();
            labelClients.Text = "Please select clients";
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
            

            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);
        }

        private void textBox_search_cars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;             
            dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
            dataGridViewCars.DataSource = DataService.GetCarsByWord(textBox_search_cars.Text);
            dataGridViewClients.ClearSelection();
            dataGridViewCars.ClearSelection();
            labelClients.Text = "Please select clients";
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
            dataGridViewOrders.DataSource = DataService.GetOrdersByCar(-1);
            }
        }


        private void button_search_orders_Click(object sender, EventArgs e)
        {
            dataGridViewOrders.DataSource = DataService.GetOrdersByWord(textBox_search_orders.Text);
            dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
            dataGridViewCars.DataSource = DataService.GetCarsByWord("");
            dataGridViewClients.ClearSelection();
            dataGridViewCars.ClearSelection();
            dataGridViewOrders.ClearSelection();
            labelClients.Text = "Please select clients";
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
        }

        private void button_search_orders_all_Click(object sender, EventArgs e)
        {
            dataGridViewOrders.DataSource = DataService.GetAllOrders();
            dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
            dataGridViewCars.DataSource = DataService.GetCarsByWord("");
            dataGridViewClients.ClearSelection();
            dataGridViewCars.ClearSelection();
            dataGridViewOrders.ClearSelection();
            labelClients.Text = "Please select clients";
            labelCars.Text = "Please select car";
            labelOrders.Text = "Please select order";
        }

        private void textBox_search_orders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                dataGridViewOrders.DataSource = DataService.GetOrdersByWord(textBox_search_orders.Text);
                dataGridViewClients.DataSource = DataService.GetCustomersByWord("");
                dataGridViewCars.DataSource = DataService.GetCarsByWord("");
                dataGridViewClients.ClearSelection();
                dataGridViewCars.ClearSelection();
                dataGridViewOrders.ClearSelection();
                labelClients.Text = "Please select clients";
                labelCars.Text = "Please select car";
                labelOrders.Text = "Please select order";
            }

        }

        private void dataGridViewOrders_CurrentCellChanged(object sender, EventArgs e)
        {

        }

       

        private void button_company_Click(object sender, EventArgs e)
        {
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            panel_setting_import.Visible = false;
            panelCompanySetting.Visible = true;
            tableLayoutPanelCompanySetting.Visible = true;
            TextStatus.Text = btnDashboard.Text + " --> " + button_company.Text;

        }

        private void button_employee_Click(object sender, EventArgs e)
        {
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = true;
            panel_setting_orders.Visible = false;
            panel_setting_import.Visible = false;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = true;
            TextStatus.Text = btnDashboard.Text + " --> " + button_employee.Text;

        }

        private void button_orders_Click(object sender, EventArgs e)
        {
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = true;
            panel_setting_import.Visible = false;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = true;
            TextStatus.Text = btnDashboard.Text + " --> " + button_orders.Text;

        }

        private void dataGridViewOrdersinProcess_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 40;
            foreach (DataGridViewRow dr in dataGridViewOrdersinProcess.Rows)
            {
                height += dr.Height;
            }

            dataGridViewOrdersinProcess.Height = height;
        }

        private void tableLayoutPanel6_Paint(object sender, EventArgs e)
        {
            dataGridViewOrdersinProcess.ClearSelection();
            dataGridView_lastactivecars.ClearSelection();
            dataGridView_lastactivecustomers.ClearSelection();
            dataGridView_lastclosedorders.ClearSelection();
            dataGridView_lastmadejobs.ClearSelection();
            dataGridView_lastsolddetails.ClearSelection();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewOrdersinProcess.ClearSelection();
            dataGridView_lastactivecars.ClearSelection();
            dataGridView_lastactivecustomers.ClearSelection();
            dataGridView_lastclosedorders.ClearSelection();
            dataGridView_lastmadejobs.ClearSelection();
            dataGridView_lastsolddetails.ClearSelection();
        }

        private void button_setting_import_Click(object sender, EventArgs e)
        {
            panel_dashboard.Visible = false;
            panel4.Visible = false;
            panel_timeline.Visible = false;
            panel_setting_employee.Visible = false;
            panel_setting_orders.Visible = false;
            panel_setting_import.Visible = true;
            panelCompanySetting.Visible = false;
            tableLayoutPanelCompanySetting.Visible = true;
            TextStatus.Text = btnDashboard.Text + " --> " + button_setting_import.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "CSV File (*.csv)|*.csv;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                label25.Text = opnfd.FileName;
                String[] row = System.IO.File.ReadAllLines(opnfd.FileName);
                String[] data_col = null;
                int header = 0;
                // String st = File.ReadAllText(opnfd.FileName);
                foreach (string line in row)
                {
                    if (header == 1) { 

                        data_col = line.Split(';');
                        Array.Resize(ref data_col, data_col.Length + 1);
                        if (DataService.CheckCustomer(data_col[0], data_col[1], data_col[2]).Count > 0)
                        {
                            data_col[data_col.Length - 1] = "Exist";
                        }else data_col[data_col.Length - 1] = "Not exist";
                        // {
                        //    fo
                        // }
                        // else
                        //{
                       
                       
                        dataGridView1.Rows.Add(data_col);
                }
                    header = 1;
                   // }
                  //  MessageBox.Show(line);
                }
               // dataGridView1.DataSource = sr;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataService.NewCustomer(Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[7].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value), "", Convert.ToString(row.Cells[10].Value), "", "", Convert.ToString(row.Cells[0].Value));
                row.Cells[11].Value = "Imported";


            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            forms.Documents doc = new forms.Documents();
            doc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "CSV File (*.csv)|*.csv;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                label1.Text = opnfd.FileName;
                String[] row = System.IO.File.ReadAllLines(opnfd.FileName);
                String[] data_col = null;
                int header = 0;
                // String st = File.ReadAllText(opnfd.FileName);
                foreach (string line in row)
                {
                    if (header == 1)
                    {

                        data_col = line.Split(';');
                        Array.Resize(ref data_col, data_col.Length + 1);
                        if (DataService.CheckCustomer(data_col[0], data_col[1], data_col[2]).Count > 0)
                        {
                            data_col[data_col.Length - 1] = "Exist";
                        }
                        else data_col[data_col.Length - 1] = "Not exist";
                        // {
                        //    fo
                        // }
                        // else
                        //{


                        dataGridView2.Rows.Add(data_col);
                    }
                    header = 1;
                    // }
                    //  MessageBox.Show(line);
                }
                // dataGridView1.DataSource = sr;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //DataService.NewCar(Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[7].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value), "", Convert.ToString(row.Cells[10].Value), "", "", Convert.ToString(row.Cells[0].Value));
                //row.Cells[11].Value = "Imported";


            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            forms.About about = new forms.About();
            about.Show();
        }

        private void Hello_Click(object sender, EventArgs e)
        {
            forms.Help help = new forms.Help();
            help.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDocPath.Text = folderDialog.SelectedPath;
                }
            }
        }

      
    }

   
}
