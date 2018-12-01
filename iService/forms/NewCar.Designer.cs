namespace iService
{
    partial class NewCar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCar));
            this.iservicecustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxReg = new System.Windows.Forms.TextBox();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxVin = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iservicecustomersBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iservicecustomersBindingSource
            // 
            this.iservicecustomersBindingSource.DataMember = "iservice_customers";
            // 
            // textBoxReg
            // 
            resources.ApplyResources(this.textBoxReg, "textBoxReg");
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxReg, 2);
            this.textBoxReg.Name = "textBoxReg";
            // 
            // textBoxBrand
            // 
            resources.ApplyResources(this.textBoxBrand, "textBoxBrand");
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxBrand, 2);
            this.textBoxBrand.Name = "textBoxBrand";
            // 
            // textBoxModel
            // 
            resources.ApplyResources(this.textBoxModel, "textBoxModel");
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxModel, 2);
            this.textBoxModel.Name = "textBoxModel";
            // 
            // textBoxVin
            // 
            resources.ApplyResources(this.textBoxVin, "textBoxVin");
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxVin, 2);
            this.textBoxVin.Name = "textBoxVin";
            // 
            // textBoxYear
            // 
            resources.ApplyResources(this.textBoxYear, "textBoxYear");
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxYear, 2);
            this.textBoxYear.Name = "textBoxYear";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Name = "label5";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReg, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYear, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxColor, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxVin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxModel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxBrand, 1, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Name = "label6";
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.tableLayoutPanel1.SetColumnSpan(this.labelName, 3);
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelName.Name = "labelName";
            // 
            // textBoxColor
            // 
            resources.ApplyResources(this.textBoxColor, "textBoxColor");
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxColor, 2);
            this.textBoxColor.Name = "textBoxColor";
            // 
            // labelDate
            // 
            resources.ApplyResources(this.labelDate, "labelDate");
            this.labelDate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelDate.Name = "labelDate";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Name = "label15";
            // 
            // labelEmployee
            // 
            resources.ApplyResources(this.labelEmployee, "labelEmployee");
            this.labelEmployee.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEmployee.Name = "labelEmployee";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Name = "label13";
            // 
            // NewCar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Name = "NewCar";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.NewCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iservicecustomersBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource iservicecustomersBindingSource;
        private System.Windows.Forms.TextBox textBoxReg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxVin;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxColor;
    }
}