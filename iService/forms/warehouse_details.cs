﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iService
{
    public partial class warehouse_details : MetroFramework.Forms.MetroForm
    {
        public warehouse_details()
        {
            InitializeComponent();
        }

        private void warehouse_details_Load(object sender, EventArgs e)
        {
            //dataGridViewItemsDetails.DataSource = DataService.ItemsDetailsGetData();
            labeldesc.Text = "";
            labelqtywh.Text = "";

            for (int i = 0; i < DataService.ItemsDetailsGetData().Count; i++)
            {
                dataGridViewItemsDetails.Rows.Add(DataService.ItemsDetailsGetData()[i].iservice_items_id, DataService.ItemsDetailsGetData()[i].iservice_items_type, DataService.ItemsDetailsGetData()[i].iservice_items_category, DataService.ItemsDetailsGetData()[i].iservice_items_subcategory, DataService.ItemsDetailsGetData()[i].iservice_items_description, DataService.ItemsDetailsGetData()[i].iservice_items_qty, DataService.ItemsDetailsGetData()[i].iservice_items_purchase_price_netto, DataService.ItemsDetailsGetData()[i].iservice_items_purchase_price_brutto, DataService.ItemsDetailsGetData()[i].iservice_items_price_netto, DataService.ItemsDetailsGetData()[i].iservice_items_price_brutto,"", DataService.ItemsDetailsGetData()[i].iservice_items_qty_type);
            }
            dataGridViewItemsDetails.RowHeadersVisible = false;
            /*
            dataGridViewItemsDetails.Columns[0].Visible = false;
            dataGridViewItemsDetails.Columns[1].Visible = false;
            dataGridViewItemsDetails.Columns[2].Visible = false;
            dataGridViewItemsDetails.Columns[3].Visible = false;
            dataGridViewItemsDetails.Columns[5].Visible = false;
            dataGridViewItemsDetails.Columns[6].Visible = false;
            dataGridViewItemsDetails.Columns[4].HeaderCell.Value = "Description";
            dataGridViewItemsDetails.Columns[7].HeaderCell.Value = "Price netto";
            dataGridViewItemsDetails.Columns[8].HeaderCell.Value = "Price brutto";
            //dataGridViewItemsDetails.EnableHeadersVisualStyles = false;
            dataGridViewItemsDetails.RowHeadersVisible = false;
            dataGridViewItemsDetails.AllowUserToAddRows = false;
            */
        }
        private readonly Заказ frm1;
        public warehouse_details(Заказ frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            bool Found = false;
            if (frm1.dataGridViewItemsDetails.Rows.Count > 0)
            {
                dataGridViewItemsDetails.SelectedRows[0].Cells[5].Value = (Convert.ToInt32(dataGridViewItemsDetails.SelectedRows[0].Cells[5].Value.ToString()) - Convert.ToInt32(textBox1.Text)).ToString();

                foreach (DataGridViewRow row in frm1.dataGridViewItemsDetails.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(dataGridViewItemsDetails.SelectedCells[0].Value))
                    {
                        labelqtywh.Text = dataGridViewItemsDetails.SelectedRows[0].Cells[5].Value.ToString();
                        row.Cells[5].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells[5].Value));
                        row.Cells[10].Value = (Convert.ToInt32(row.Cells[5].Value) * Convert.ToInt32(row.Cells[9].Value)).ToString();
                        Found = true;
                        DataService.UpdateOrderItem(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));

                    }
                }
            }
            if (!Found)
            {
                DataService.NewOrderItem(Convert.ToInt32(dataGridViewItemsDetails.SelectedCells[0].Value), Convert.ToInt32(DataService.GetOrdersById(GlobalVars.selected_iservice_orders_id)[0].iservice_orders_number), Convert.ToString(textBox1.Text), Convert.ToString(dataGridViewItemsDetails.SelectedCells[8].Value), Convert.ToString(dataGridViewItemsDetails.SelectedCells[9].Value));                              
                //frm1.dataGridViewItemsDetails.Rows.Add(dataGridViewItemsDetails.SelectedCells[0].Value, dataGridViewItemsDetails.SelectedCells[1].Value, dataGridViewItemsDetails.SelectedCells[2].Value, dataGridViewItemsDetails.SelectedCells[3].Value, dataGridViewItemsDetails.SelectedCells[4].Value, textBox3.Text, dataGridViewItemsDetails.SelectedCells[5].Value, dataGridViewItemsDetails.SelectedCells[6].Value, dataGridViewItemsDetails.SelectedCells[8].Value, dataGridViewItemsDetails.SelectedCells[9].Value, dataGridViewItemsDetails.SelectedCells[9].Value);
            }
         
            frm1.updatedetailstotal();
            frm1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewItemsDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewItemsDetails.SelectedRows.Count > 0)
            {
                labeltext.Text = dataGridViewItemsDetails.SelectedRows[0].Cells[4].Value.ToString(); 
                labeldesc.Text = dataGridViewItemsDetails.SelectedRows[0].Cells[4].Value.ToString();
                labelqtywh.Text = dataGridViewItemsDetails.SelectedRows[0].Cells[5].Value.ToString(); 
                textBox1.Text = "1";
            }
        }
        public void updatedetailsdata()
        {
            dataGridViewItemsDetails.Rows.Clear();
            for (int i = 0; i < DataService.ItemsWorksGetData().Count; i++)
            {
                dataGridViewItemsDetails.Rows.Add(DataService.ItemsWorksGetData()[i].iservice_items_id, DataService.ItemsWorksGetData()[i].iservice_items_type, DataService.ItemsWorksGetData()[i].iservice_items_category, DataService.ItemsWorksGetData()[i].iservice_items_subcategory, DataService.ItemsWorksGetData()[i].iservice_items_description, DataService.ItemsWorksGetData()[i].iservice_items_qty, DataService.ItemsWorksGetData()[i].iservice_items_purchase_price_netto, DataService.ItemsWorksGetData()[i].iservice_items_purchase_price_brutto, DataService.ItemsWorksGetData()[i].iservice_items_price_netto, DataService.ItemsWorksGetData()[i].iservice_items_price_brutto, "", DataService.ItemsDetailsGetData()[i].iservice_items_qty_type);
            }
            dataGridViewItemsDetails.ClearSelection();
            labeltext.Text = "Please select item";

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            forms.NewDetailItem newitem = new forms.NewDetailItem(this,null, "Add");
            newitem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            forms.NewDetailItem newitem = new forms.NewDetailItem(this,null, "Edit");
            newitem.Show();
        }
    }
}
