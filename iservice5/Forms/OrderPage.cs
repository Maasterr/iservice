using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iservice5
{
    public partial class OrderPage : MetroFramework.Forms.MetroForm
    {
        public OrderPage()
        {
            InitializeComponent(); 
        }
        private readonly Form1 frm1;
        private readonly String Status;
        public OrderPage(Form1 frm, String status)
        {
            InitializeComponent();
            frm1 = frm;
            Status = status;

        }
        String newinvocienumber;
        private void button3_Click(object sender, EventArgs e)
        {
           
           newinvocienumber = DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number + "/" + (DataService.GetDocsByOrder(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number).Count + 1);
            DialogResult dialogResult = MessageBox.Show("It will create new invoice number " + newinvocienumber, "Invoice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (Status == "Add")
            {
                if ((comboBoxOrderStatus.SelectedValue==null) || (ComboBoxPaymentStatus.SelectedValue == null))
                    MessageBox.Show("Required fields is empty", "Notification", MessageBoxButtons.OK);
                else if (DataService.UpdateOrder(GlobalVars.selected_iservice_orders_id, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), "", ComboBoxPaymentStatus.SelectedValue.ToString(), comboBoxOrderStatus.SelectedValue.ToString(), "", "", labelTotal.Text, textBoxMileage.Text) == null)
                {
                  //  for (int i = 0; i < DataService.GetOrderItems("Details", labelOrderNumber.Text).Count; i++)
                  //  {
                    //    dataGridViewItemsDetails.Rows.Add(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_id, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_type, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_category, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_subcategory, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_description, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_purchase_price_netto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_purchase_price_brutto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_netto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto);
                        foreach (DataGridViewRow row in dataGridViewItemsDetails.Rows)
                        {
                            if (DataService.CheckOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text)).Count == 0)
                              DataService.NewOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                            else
                                DataService.UpdateOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                        }
                   // }

                    
                    foreach (DataGridViewRow row in dataGridViewItemsWorks.Rows)
                    {
                        if (DataService.CheckOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text)).Count == 0)
                            DataService.NewOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                        else
                            DataService.UpdateOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                    }
                    frm1.updateordersdata();
                    this.Close();
                    MessageBox.Show("Succesfully saved", "Notification", MessageBoxButtons.OK);

                }
                else
                {
                    this.Close();
                    MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);


                }
            }
            else if (DataService.UpdateOrder(GlobalVars.selected_iservice_orders_id, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), "", ComboBoxPaymentStatus.SelectedValue.ToString(), comboBoxOrderStatus.SelectedValue.ToString(), "", "", labelTotal.Text, textBoxMileage.Text) == null)
            {
                foreach (DataGridViewRow row in dataGridViewItemsDetails.Rows)
                {
                   if (DataService.CheckOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text)).Count == 0)
                       DataService.NewOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                    else
                        DataService.UpdateOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                }
                foreach (DataGridViewRow row in dataGridViewItemsWorks.Rows)
                {
                    if (DataService.CheckOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text)).Count == 0)
                        DataService.NewOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                    else
                        DataService.UpdateOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                }
                frm1.updateordersdata();
                this.Close();
                MessageBox.Show("Succesfully saved", "Notification", MessageBoxButtons.OK);

            }
            else
            {
                this.Close();
                MessageBox.Show("Please try again later", "Error", MessageBoxButtons.OK);


            }
            

           

        }
        private int Heightcheck = 1;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int height = 350;
            Bitmap bmp = Properties.Resources.iService;
            Image newImg = bmp;
            e.Graphics.DrawImage(newImg, 600, 25, newImg.Width, newImg.Height);
            e.Graphics.DrawString(GlobalVars.iservice_company_name, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 25));
            e.Graphics.DrawString(GlobalVars.iservice_company_country +"," + GlobalVars.iservice_company_city + "," + GlobalVars.iservice_company_street + "," + GlobalVars.iservice_company_zipcode, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 50));
            e.Graphics.DrawString(GlobalVars.iservice_company_phone + "," + GlobalVars.iservice_company_email, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 75));
            e.Graphics.DrawString(GlobalVars.iservice_company_website, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 100));
            e.Graphics.DrawString("Invoice #" + newinvocienumber, new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString(DateTime.Now.ToString("dd.MM.yyyy"), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 140));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 155));


            e.Graphics.DrawString("Order number: " + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Orders status: " + comboBoxOrderStatus.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 205));
            e.Graphics.DrawString("Payment status: " + ComboBoxPaymentStatus.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Client: " +GlobalVars.Client, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 180));
            e.Graphics.DrawString("Car: " + GlobalVars.regnumber, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 205));
            e.Graphics.DrawString("Mileage: " + GlobalVars.selected_iservice_orders_mileage, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 230));
            
            if (dataGridViewItemsWorks.Rows.Count > 0) {
                e.Graphics.DrawString("Works", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 310));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 325));
                e.Graphics.DrawString("#", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, 350));
                e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, 350));
                e.Graphics.DrawString("QTY", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, 350));
                e.Graphics.DrawString("Price netto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 350));
                e.Graphics.DrawString("Price brutto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 350));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 350));
                for (int i = 0; i < dataGridViewItemsWorks.Rows.Count; i++)
            {
                    height = height + 25;
                e.Graphics.DrawString(i.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[i].Cells[4].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[i].Cells[5].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[i].Cells[8].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[i].Cells[9].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[i].Cells[10].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));                
            }
                height = height + 25;
                e.Graphics.DrawString("Sum", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                e.Graphics.DrawString(labelItemWorksTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            }
            if (dataGridViewItemsDetails.Rows.Count > 0)
            {
                height = height + 50;
                e.Graphics.DrawString("Details", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, height));
                height = height + 15;
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, height));
                height = height + 25;
                e.Graphics.DrawString("#", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                e.Graphics.DrawString("QTY", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                e.Graphics.DrawString("Price netto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                e.Graphics.DrawString("Price brutto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));

                for (int i = 0; i < dataGridViewItemsDetails.Rows.Count; i++)
                {
                    height = height + 25;
                    e.Graphics.DrawString(i.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsDetails.Rows[i].Cells[4].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsDetails.Rows[i].Cells[5].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsDetails.Rows[i].Cells[8].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsDetails.Rows[i].Cells[9].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsDetails.Rows[i].Cells[10].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
                    
                }
            }
            height = height + 25;
            e.Graphics.DrawString("Sum", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
            e.Graphics.DrawString(labelItemDetailsTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));

            height = height + 80;
             e.Graphics.DrawString("Sum of Details: " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
             e.Graphics.DrawString(labelItemDetailsTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
             height = height + 25;
            e.Graphics.DrawString("Sum of Works: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString(labelItemWorksTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Sum: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString(labelTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Discount: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString(labelTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Paid:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString("0", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("To pay: " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString(labelTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));



            float pageHeight = e.PageSettings.PrintableArea.Height;
            height = height + 150;
        /*
            if (height >= pageHeight)
            {
                e.HasMorePages = false;                       
            }
            else
            {
                e.HasMorePages = true;
                height = 30;
            }*/
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, height - 25));
            e.Graphics.DrawString("Employee: " + GlobalVars.Employee, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, height));
            e.Graphics.DrawString("Comments: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, height));


        }

        private void label18_Click(object sender, EventArgs e)
        {
           
        }
        private int totaldetails, totalworks;
        private void OrderPage_Load(object sender, EventArgs e)
        {
           
            //button6.Text = Status;

            labelRegNumber.Text = GlobalVars.regnumber;
            labelClient.Text = GlobalVars.Client;
            comboBoxOrderStatus.DataSource = DataService.GetOrderStatusList();
            comboBoxOrderStatus.ValueMember = "iservice_orders_status_id";
            comboBoxOrderStatus.DisplayMember = "iservice_orders_status_name";
            ComboBoxPaymentStatus.DataSource = DataService.GetOrderPaymentStatusList();
            ComboBoxPaymentStatus.ValueMember = "iservice_orders_payment_status_id";
            ComboBoxPaymentStatus.DisplayMember = "iservice_orders_payment_status_name";
            if (ComboBoxPaymentStatus.SelectedIndex == 1)
            {
                tableLayoutPanel11.Visible = true;
            }
            else tableLayoutPanel11.Visible = false;
            if (Status == "Add")
            {
                //this.Text = "New customer";
                labelEmployee.Text = GlobalVars.Employee;
                labelCreationDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                //labelOrderNumber.Text = "-";
                labelOrderNumber.Text = Convert.ToString(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number);


            }
            else
            {               
                labelEmployee.Text = GlobalVars.selected_iservice_orders_user_name;
                //this.Text = "Edit customer";
                comboBoxOrderStatus.SelectedValue = Convert.ToInt32(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_status_of_work);
                ComboBoxPaymentStatus.SelectedValue = Convert.ToInt32(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_status_of_payment);    
                labelOrderNumber.Text = Convert.ToString(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number);
                
                label_date_of_close.Text = DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_expiry_date;
                label_lastupdate.Text = DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_date_of_last_update;
                textBoxMileage.Text = DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_mileage;
                labelCreationDate.Text = DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_date_of_creation;

            }



            dataGridViewItemsWorks.RowHeadersVisible = false;
            dataGridViewItemsDetails.RowHeadersVisible = false;
           
            for (int i=0; i< DataService.GetOrderItems("Details", labelOrderNumber.Text).Count; i++)
            {
                if (DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_qty_type != "0")
                totaldetails = Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto) * Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty)/1000;
               else totaldetails = Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto) * Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty);
                dataGridViewItemsDetails.Rows.Add(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_id, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_type, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_category, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_subcategory, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_description, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_purchase_price_netto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_purchase_price_brutto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_netto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto, totaldetails);
            }
            for (int i = 0; i < DataService.GetOrderItems("Works", labelOrderNumber.Text).Count; i++)
            {
                if (DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_qty_type != "0")
                totalworks = Convert.ToInt32(DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_price_brutto) * Convert.ToInt32(DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_orders_items_qty)/1000;
                else totalworks = Convert.ToInt32(DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_price_brutto) * Convert.ToInt32(DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_orders_items_qty);


                dataGridViewItemsWorks.Rows.Add(DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_id, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_type, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_category, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_subcategory, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_description, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_orders_items_qty, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_purchase_price_netto, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_purchase_price_brutto, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_price_netto, DataService.GetOrderItems("Works", labelOrderNumber.Text)[i].iservice_items_price_brutto, totalworks);
            }
            updateworkstotal();
            updatedetailstotal();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            warehouse_details Warehouse_details = new warehouse_details(this);
            Warehouse_details.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            warehouse_works Warehouse_works = new warehouse_works(this);
            Warehouse_works.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewItemsDetails.SelectedRows)
            {
                dataGridViewItemsDetails.Rows.RemoveAt(row.Index);
                DataService.DelteOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text));
            }
            updatedetailstotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewItemsWorks.SelectedRows)
            {
                dataGridViewItemsWorks.Rows.RemoveAt(row.Index);
                DataService.DelteOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(labelOrderNumber.Text));
            }
          
            updateworkstotal();



        }
        public void updateworkstotal()
        {
            int sum = 0;
            for (int i = 0; i < dataGridViewItemsWorks.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridViewItemsWorks.Rows[i].Cells[10].Value);
            }
            labelItemWorksTotal.Text = sum.ToString();
            labelTotal.Text = (Convert.ToInt32(labelItemDetailsTotal.Text) + Convert.ToInt32(labelItemWorksTotal.Text)).ToString();

        }
        public void updatedetailstotal()
        {
            dataGridViewItemsDetails.Rows.Clear();
            for (int i = 0; i < DataService.GetOrderItems("Details", labelOrderNumber.Text).Count; i++)
            {
                if (DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_qty_type != "0")
                    totaldetails = Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto) * Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty) / 1000;
                else totaldetails = Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto) * Convert.ToInt32(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty);
                dataGridViewItemsDetails.Rows.Add(DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_id, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_type, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_category, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_subcategory, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_description, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_orders_items_qty, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_purchase_price_netto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_purchase_price_brutto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_netto, DataService.GetOrderItems("Details", labelOrderNumber.Text)[i].iservice_items_price_brutto, totaldetails);
            }

            int sumdetails = 0;
            for (int i = 0; i < dataGridViewItemsDetails.Rows.Count; ++i)
            {
                sumdetails += Convert.ToInt32(dataGridViewItemsDetails.Rows[i].Cells[10].Value);
            }
            labelItemDetailsTotal.Text = sumdetails.ToString();
           labelTotal.Text = (Convert.ToInt32(labelItemDetailsTotal.Text) + Convert.ToInt32(labelItemWorksTotal.Text)).ToString();
        }

      

        private void comboBoxOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           // labelClient.Text = comboBoxOrderStatus.SelectedValue.ToString();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxPaymentStatus.SelectedIndex == 1){
                tableLayoutPanel11.Visible = true;

            }
            else tableLayoutPanel11.Visible = false;

        }
    }
}
