﻿using System;
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
    public partial class warehouse_details : MetroFramework.Forms.MetroForm
    {
        public warehouse_details()
        {
            InitializeComponent();
        }

        private void warehouse_details_Load(object sender, EventArgs e)
        {
            dataGridViewItemsDetails.DataSource = DataService.ItemsDetailsGetData();
            dataGridViewItemsDetails.Columns[0].Visible = false;
            dataGridViewItemsDetails.Columns[1].Visible = false;
            dataGridViewItemsDetails.Columns[2].Visible = false;
            dataGridViewItemsDetails.Columns[3].Visible = false;
            dataGridViewItemsDetails.Columns[5].Visible = false;
            dataGridViewItemsDetails.Columns[6].Visible = false;
            dataGridViewItemsDetails.Columns[4].HeaderCell.Value = "Description";
            dataGridViewItemsDetails.Columns[7].HeaderCell.Value = "Price netto";
            dataGridViewItemsDetails.Columns[8].HeaderCell.Value = "Price brutto";
            dataGridViewItemsDetails.EnableHeadersVisualStyles = false;
            dataGridViewItemsDetails.RowHeadersVisible = false;
            dataGridViewItemsDetails.AllowUserToAddRows = false;
        }
        private readonly OrderPage frm1;
        public warehouse_details(OrderPage frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            frm1.dataGridViewItemsDetails.Rows.Add(dataGridViewItemsDetails.SelectedCells[0].Value, dataGridViewItemsDetails.SelectedCells[1].Value, dataGridViewItemsDetails.SelectedCells[2].Value, dataGridViewItemsDetails.SelectedCells[3].Value, dataGridViewItemsDetails.SelectedCells[4].Value, dataGridViewItemsDetails.SelectedCells[5].Value, dataGridViewItemsDetails.SelectedCells[6].Value, dataGridViewItemsDetails.SelectedCells[7].Value, dataGridViewItemsDetails.SelectedCells[8].Value);

            frm1.updatedetailstotal();
            frm1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}