namespace iservice5.forms
{
    partial class Documents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Documents));
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewDocs = new System.Windows.Forms.DataGridView();
            this.iservice_documents_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iservice_documents_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iservice_documents_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iservice_documents_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iservice_documents_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocs)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.dataGridViewDocs, 0, 0);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(23, 73);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(754, 355);
            this.tableLayoutPanel13.TabIndex = 35;
            // 
            // dataGridViewDocs
            // 
            this.dataGridViewDocs.AllowUserToAddRows = false;
            this.dataGridViewDocs.AllowUserToDeleteRows = false;
            this.dataGridViewDocs.AllowUserToResizeColumns = false;
            this.dataGridViewDocs.AllowUserToResizeRows = false;
            this.dataGridViewDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDocs.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewDocs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDocs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iservice_documents_id,
            this.iservice_documents_order_id,
            this.iservice_documents_name,
            this.iservice_documents_paid,
            this.iservice_documents_date});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDocs.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDocs.EnableHeadersVisualStyles = false;
            this.dataGridViewDocs.GridColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewDocs.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewDocs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDocs.MultiSelect = false;
            this.dataGridViewDocs.Name = "dataGridViewDocs";
            this.dataGridViewDocs.ReadOnly = true;
            this.dataGridViewDocs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDocs.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewDocs.RowHeadersVisible = false;
            this.dataGridViewDocs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewDocs.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewDocs.RowTemplate.Height = 24;
            this.dataGridViewDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocs.Size = new System.Drawing.Size(748, 351);
            this.dataGridViewDocs.TabIndex = 10;
            this.dataGridViewDocs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocs_CellClick);
            this.dataGridViewDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocs_CellDoubleClick);
            // 
            // iservice_documents_id
            // 
            this.iservice_documents_id.DataPropertyName = "iservice_documents_id";
            this.iservice_documents_id.HeaderText = "iservice_documents_id";
            this.iservice_documents_id.Name = "iservice_documents_id";
            this.iservice_documents_id.ReadOnly = true;
            this.iservice_documents_id.Visible = false;
            // 
            // iservice_documents_order_id
            // 
            this.iservice_documents_order_id.DataPropertyName = "iservice_documents_order_id";
            this.iservice_documents_order_id.HeaderText = "iservice_documents_order_id";
            this.iservice_documents_order_id.Name = "iservice_documents_order_id";
            this.iservice_documents_order_id.ReadOnly = true;
            this.iservice_documents_order_id.Visible = false;
            // 
            // iservice_documents_name
            // 
            this.iservice_documents_name.DataPropertyName = "iservice_documents_name";
            this.iservice_documents_name.HeaderText = "Name";
            this.iservice_documents_name.Name = "iservice_documents_name";
            this.iservice_documents_name.ReadOnly = true;
            // 
            // iservice_documents_paid
            // 
            this.iservice_documents_paid.DataPropertyName = "iservice_documents_paid";
            this.iservice_documents_paid.HeaderText = "Sum";
            this.iservice_documents_paid.Name = "iservice_documents_paid";
            this.iservice_documents_paid.ReadOnly = true;
            // 
            // iservice_documents_date
            // 
            this.iservice_documents_date.DataPropertyName = "iservice_documents_date";
            this.iservice_documents_date.HeaderText = "Date";
            this.iservice_documents_date.Name = "iservice_documents_date";
            this.iservice_documents_date.ReadOnly = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel13);
            this.Name = "Documents";
            this.Resizable = false;
            this.Text = "Documents";
            this.Load += new System.EventHandler(this.Documents_Load);
            this.tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.DataGridView dataGridViewDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn iservice_documents_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn iservice_documents_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn iservice_documents_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn iservice_documents_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn iservice_documents_date;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}