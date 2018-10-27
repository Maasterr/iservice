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
        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (Status == "Add")
            {
                if ((comboBoxOrderStatus.SelectedValue==null) || (ComboBoxPaymentStatus.SelectedValue == null))
                    MessageBox.Show("Required fields is empty", "Notification", MessageBoxButtons.OK);
               
                else if (DataService.NewOrder(GlobalVars.selected_iservice_cars_id, GlobalVars.Employee_id, labelCreationDate.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), "", ComboBoxPaymentStatus.SelectedValue.ToString(), comboBoxOrderStatus.SelectedValue.ToString(), "", "", labelTotal.Text, textBoxMileage.Text) == null)
                {

                    foreach (DataGridViewRow row in dataGridViewItemsDetails.Rows)
                    {

                        DataService.NewOrderItem(DataService.GetLastOrderNumber()[0].iservice_orders_number, Convert.ToInt32(row.Cells[0].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                      

                    }
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
            else if (DataService.UpdateOrder(GlobalVars.selected_iservice_orders_id, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), "", ComboBoxPaymentStatus.SelectedValue.ToString(), comboBoxOrderStatus.SelectedValue.ToString(), "", "", labelTotal.Text, textBoxMileage.Text) == null)
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.iService;
            Image newImg = bmp;

            e.Graphics.DrawImage(newImg, 20, 20, newImg.Width, newImg.Height);
            e.Graphics.DrawString("Order number: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Client: " + GlobalVars.Client, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 205));
            e.Graphics.DrawString("Car: " + GlobalVars.regnumber, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Orders status: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 180));
            e.Graphics.DrawString("Payment status: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 205));
            e.Graphics.DrawString("Comments: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 230));
            e.Graphics.DrawString("Employee:" + GlobalVars.Employee, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 180));

            int height = 350;
            if (dataGridViewItemsWorks.Rows.Count > 0) {
                e.Graphics.DrawString("Works", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(35, 300));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 325));
                e.Graphics.DrawString("#", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, 350));
                e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, 350));
                e.Graphics.DrawString("QTY", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, 350));
                e.Graphics.DrawString("Price netto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 350));
                e.Graphics.DrawString("Price brutto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 350));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 350));
                for (int i = 1; i <= dataGridViewItemsWorks.Rows.Count; i++)
            {
                    height = height + 25;
                e.Graphics.DrawString(i.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[0].Cells[4].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                e.Graphics.DrawString("2", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[0].Cells[7].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[0].Cells[8].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                e.Graphics.DrawString("500", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
                
            }
            }
            if (dataGridViewItemsDetails.Rows.Count > 0)
            {
                height = height + 50;
                e.Graphics.DrawString("Details", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(35, height));
                height = height + 25;
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, height));
                height = height + 25;
                e.Graphics.DrawString("#", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                e.Graphics.DrawString("QTY", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                e.Graphics.DrawString("Price netto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                e.Graphics.DrawString("Price brutto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));

                for (int i = 1; i <= dataGridViewItemsDetails.Rows.Count; i++)
                {
                    height = height + 25;
                    e.Graphics.DrawString(i.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[0].Cells[4].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                    e.Graphics.DrawString("2", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[0].Cells[7].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                    e.Graphics.DrawString(Convert.ToString(dataGridViewItemsWorks.Rows[0].Cells[8].Value), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                    e.Graphics.DrawString("500", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
                    
                }
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {
           
        }

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

            if (Status == "Add")
            {
                this.Text = "New customer";
                labelEmployee.Text = GlobalVars.Employee;
                labelCreationDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                labelOrderNumber.Text = "-";
             
                
            }
            else
            {
                
                labelEmployee.Text = GlobalVars.selected_iservice_orders_user_name;
                this.Text = "Edit customer";
                comboBoxOrderStatus.SelectedValue = Convert.ToInt32(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_status_of_work);
                ComboBoxPaymentStatus.SelectedValue = Convert.ToInt32(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_status_of_payment);    
                labelOrderNumber.Text = Convert.ToString(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number);
                textBoxMileage.Text = DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_mileage;             
                labelCreationDate.Text = GlobalVars.selected_iservice_orders_date_of_creation;
                label_date_of_close.Text = GlobalVars.selected_iservice_orders_expiry_date;
                label_lastupdate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                textBoxMileage.Text = GlobalVars.selected_iservice_orders_mileage;
                dataGridViewItemsWorks.DataSource = DataService.GetOrderItems("Works", labelOrderNumber.Text);
            }

          
            
            dataGridViewItemsWorks.RowHeadersVisible = false;
            dataGridViewItemsDetails.RowHeadersVisible = false;



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
            foreach ( DataGridViewRow row in dataGridViewItemsDetails.SelectedRows)
            dataGridViewItemsDetails.Rows.RemoveAt(row.Index);
            updatedetailstotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewItemsWorks.SelectedRows)
                dataGridViewItemsWorks.Rows.RemoveAt(row.Index);
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

        }
    }
}
