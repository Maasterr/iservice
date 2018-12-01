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
    public partial class Documents : MetroFramework.Forms.MetroForm
    {
        public Documents()
        {
            InitializeComponent();
        }
        private string selected_iservice_documents_order_id;
        private string selected_iservice_documents_name;
        private string selected_iservice_documents_paid;
        private string selected_iservice_documents_date;
        private void Documents_Load(object sender, EventArgs e)
        {
            this.Text = "Documents for order #" + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number;
            dataGridViewDocs.DataSource = DataService.GetDocsByOrder(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number);
        }

        private void dataGridViewDocs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDocs.SelectedRows.Count > 0)
            {
                 selected_iservice_documents_order_id = Convert.ToString(dataGridViewDocs.SelectedRows[0].Cells[1].Value);
                selected_iservice_documents_name = Convert.ToString(dataGridViewDocs.SelectedRows[0].Cells[2].Value);
                selected_iservice_documents_paid = Convert.ToString(dataGridViewDocs.SelectedRows[0].Cells[3].Value);
                selected_iservice_documents_date = Convert.ToString(dataGridViewDocs.SelectedRows[0].Cells[4].Value);
            }
        }

        private void dataGridViewDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDocs.SelectedRows.Count > 0)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int height = 350;
            int workstotal = 0;
            int detailstotal = 0;
            Bitmap bmp = Properties.Resources.iService;
            Image newImg = bmp;
            e.Graphics.DrawImage(newImg, 600, 25, newImg.Width, newImg.Height);
            e.Graphics.DrawString(GlobalVars.iservice_company_name, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 25));
            e.Graphics.DrawString(GlobalVars.iservice_company_country + "," + GlobalVars.iservice_company_city + "," + GlobalVars.iservice_company_street + "," + GlobalVars.iservice_company_zipcode, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 50));
            e.Graphics.DrawString(GlobalVars.iservice_company_phone + "," + GlobalVars.iservice_company_email, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 75));
            e.Graphics.DrawString(GlobalVars.iservice_company_website, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 100));
            e.Graphics.DrawString("Invoice #" + selected_iservice_documents_name, new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString(DateTime.Now.ToString("dd.MM.yyyy"), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 140));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 155));



            e.Graphics.DrawString("Order number: " + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Orders status: " + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_status_name, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 205));
            e.Graphics.DrawString("Payment status: " + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_payment_status_name, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Client: " + GlobalVars.Client, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 180));
            e.Graphics.DrawString("Car: " + GlobalVars.regnumber, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 205));
            e.Graphics.DrawString("Mileage: " + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_mileage, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 230));
            e.Graphics.DrawString("Date of creation: " + DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_date_of_creation, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 255));

            if (DataService.GetOrderItems("Works", selected_iservice_documents_order_id).Count > 0)
            {
                e.Graphics.DrawString("Works", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 310));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 325));
                e.Graphics.DrawString("#", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, 350));
                e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, 350));
                e.Graphics.DrawString("QTY", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, 350));
                e.Graphics.DrawString("Price netto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 350));
                e.Graphics.DrawString("Price brutto", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 350));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 350));
               
                for (int i = 0; i < DataService.GetOrderItems("Works", selected_iservice_documents_order_id).Count; i++)
                {
                    height = height + 25;
                    e.Graphics.DrawString(i.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_items_description, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_orders_items_qty, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_items_price_netto, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_items_price_brutto, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                    e.Graphics.DrawString((Convert.ToInt32(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_orders_items_qty) * Convert.ToInt32(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_items_price_brutto)).ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
                    workstotal += (Convert.ToInt32(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_orders_items_qty) * Convert.ToInt32(DataService.GetOrderItems("Works", selected_iservice_documents_order_id)[i].iservice_items_price_brutto));
                }
                height = height + 25;
                e.Graphics.DrawString("Sum", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                e.Graphics.DrawString(workstotal.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            }
            if (DataService.GetOrderItems("Details", selected_iservice_documents_order_id).Count > 0)
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



                for (int i = 0; i < DataService.GetOrderItems("Details", selected_iservice_documents_order_id).Count; i++)
                {
                    height = height + 25;
                    e.Graphics.DrawString(i.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(35, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_items_description, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_orders_items_qty, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_items_price_netto, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, height));
                    e.Graphics.DrawString(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_items_price_brutto, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
                    e.Graphics.DrawString((Convert.ToInt32(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_orders_items_qty) * Convert.ToInt32(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_items_price_brutto)).ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
                    detailstotal += (Convert.ToInt32(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_orders_items_qty) * Convert.ToInt32(DataService.GetOrderItems("Details", selected_iservice_documents_order_id)[i].iservice_items_price_brutto));

                }
            }
            height = height + 25;
            e.Graphics.DrawString("Sum", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75, height));
            e.Graphics.DrawString(detailstotal.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));

            height = height + 80;
            e.Graphics.DrawString("Sum of Details: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString(detailstotal.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Sum of Works: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString(workstotal.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Sum: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString((detailstotal+workstotal).ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Discount: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString("0", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("Paid:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString("0", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));
            height = height + 25;
            e.Graphics.DrawString("To pay: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, height));
            e.Graphics.DrawString((detailstotal + workstotal).ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, height));



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
    }
}
