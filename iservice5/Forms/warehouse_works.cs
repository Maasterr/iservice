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
    public partial class warehouse_works : MetroFramework.Forms.MetroForm
    {
        
        public warehouse_works()
        {
            InitializeComponent();
        }

        private void warehouse_works_Load(object sender, EventArgs e)
        {
            dataGridViewItemsWorks.DataSource = DataService.ItemsWorksGetData();
            dataGridViewItemsWorks.Columns[0].Visible = false;
            dataGridViewItemsWorks.Columns[1].Visible = false;
            dataGridViewItemsWorks.Columns[2].Visible = false;
            dataGridViewItemsWorks.Columns[3].Visible = false;
            dataGridViewItemsWorks.Columns[5].Visible = false;
            dataGridViewItemsWorks.Columns[6].Visible = false;
            dataGridViewItemsWorks.Columns[9].Visible = false;
            dataGridViewItemsWorks.Columns[10].Visible = false;
            dataGridViewItemsWorks.Columns[11].Visible = false;
            dataGridViewItemsWorks.Columns[4].HeaderCell.Value = "Description";
            dataGridViewItemsWorks.Columns[7].HeaderCell.Value = "Price netto";
            dataGridViewItemsWorks.Columns[8].HeaderCell.Value = "Price brutto";
            dataGridViewItemsWorks.EnableHeadersVisualStyles = false;
            dataGridViewItemsWorks.RowHeadersVisible = false;
            dataGridViewItemsWorks.AllowUserToAddRows = false;
        }
        private readonly OrderPage frm1;
        public warehouse_works(OrderPage frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            bool Found = false;
            if (frm1.dataGridViewItemsWorks.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in frm1.dataGridViewItemsWorks.Rows)
                {
                    
                    if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(dataGridViewItemsWorks.SelectedCells[0].Value))
                    {
                        row.Cells[5].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells[5].Value));
                        row.Cells[10].Value = (Convert.ToInt32(row.Cells[5].Value) * Convert.ToInt32(row.Cells[9].Value)).ToString();
                        Found = true;
                    }
                }         
            }
            if (!Found)
            {
                frm1.dataGridViewItemsWorks.Rows.Add(dataGridViewItemsWorks.SelectedCells[0].Value, dataGridViewItemsWorks.SelectedCells[1].Value, dataGridViewItemsWorks.SelectedCells[2].Value, dataGridViewItemsWorks.SelectedCells[3].Value, dataGridViewItemsWorks.SelectedCells[4].Value, "1", dataGridViewItemsWorks.SelectedCells[5].Value, dataGridViewItemsWorks.SelectedCells[6].Value, dataGridViewItemsWorks.SelectedCells[7].Value, dataGridViewItemsWorks.SelectedCells[8].Value, dataGridViewItemsWorks.SelectedCells[8].Value);
            }

            frm1.updateworkstotal();
            frm1.Refresh();
    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewItemsWorks_Click(object sender, EventArgs e)
        {
            if (dataGridViewItemsWorks.SelectedRows.Count > 0)
            {
                labelDesc.Text = Convert.ToString(dataGridViewItemsWorks.SelectedCells[4].Value);
                labelNetto.Text = Convert.ToString(dataGridViewItemsWorks.SelectedCells[7].Value);
                labelBrutto.Text = Convert.ToString(dataGridViewItemsWorks.SelectedCells[8].Value);
            }
        }
    }
}