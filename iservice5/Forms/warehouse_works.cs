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
    public partial class warehouse_works : MetroFramework.Forms.MetroForm
    {
        
        public warehouse_works()
        {
            InitializeComponent();
        }

        private void warehouse_works_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < DataService.ItemsWorksGetData().Count; i++)
            {
                dataGridViewItemsWorks.Rows.Add(DataService.ItemsWorksGetData()[i].iservice_items_id, DataService.ItemsWorksGetData()[i].iservice_items_type, DataService.ItemsWorksGetData()[i].iservice_items_category, DataService.ItemsWorksGetData()[i].iservice_items_subcategory, DataService.ItemsWorksGetData()[i].iservice_items_description, DataService.ItemsWorksGetData()[i].iservice_items_qty, DataService.ItemsWorksGetData()[i].iservice_items_purchase_price_netto, DataService.ItemsWorksGetData()[i].iservice_items_purchase_price_brutto, DataService.ItemsWorksGetData()[i].iservice_items_price_netto, DataService.ItemsWorksGetData()[i].iservice_items_price_brutto);
            }
            dataGridViewItemsWorks.RowHeadersVisible = false;
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
                frm1.dataGridViewItemsWorks.Rows.Add(dataGridViewItemsWorks.SelectedCells[0].Value, dataGridViewItemsWorks.SelectedCells[1].Value, dataGridViewItemsWorks.SelectedCells[2].Value, dataGridViewItemsWorks.SelectedCells[3].Value, dataGridViewItemsWorks.SelectedCells[4].Value, "1", dataGridViewItemsWorks.SelectedCells[5].Value, dataGridViewItemsWorks.SelectedCells[6].Value, dataGridViewItemsWorks.SelectedCells[8].Value, dataGridViewItemsWorks.SelectedCells[9].Value, dataGridViewItemsWorks.SelectedCells[9].Value);
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

               
                labeltext.Text = dataGridViewItemsWorks.SelectedRows[0].Cells[4].Value.ToString();
                
                GlobalVars.selected_iservice_items_id = Convert.ToInt32(dataGridViewItemsWorks.SelectedRows[0].Cells[0].Value);
                 }
            else
                labeltext.Text = "Please select item";

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
            forms.NewWorkItem newitem = new forms.NewWorkItem(this, "Add");
            newitem.Show();

        }
    }
}
