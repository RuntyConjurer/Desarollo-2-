namespace aplicacionInformeVentas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnLoadItem = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPrice = new TextBox();
            txtFri = new TextBox();
            txtThu = new TextBox();
            txtWed = new TextBox();
            txtTue = new TextBox();
            txtMon = new TextBox();
            txtItem = new TextBox();
            groupBox2 = new GroupBox();
            lvSalesReport = new ListBox();
            lblTotalGeneral = new Label();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoadItem);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtFri);
            groupBox1.Controls.Add(txtThu);
            groupBox1.Controls.Add(txtWed);
            groupBox1.Controls.Add(txtTue);
            groupBox1.Controls.Add(txtMon);
            groupBox1.Controls.Add(txtItem);
            groupBox1.Location = new Point(38, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 378);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnLoadItem
            // 
            btnLoadItem.Location = new Point(77, 349);
            btnLoadItem.Name = "btnLoadItem";
            btnLoadItem.Size = new Size(100, 23);
            btnLoadItem.TabIndex = 14;
            btnLoadItem.Text = "Cargar Item";
            btnLoadItem.UseVisualStyleBackColor = true;
            btnLoadItem.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 309);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 13;
            label7.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 265);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 12;
            label6.Text = "Friday";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 224);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 11;
            label5.Text = "Thursday";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 184);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 10;
            label4.Text = "Wednesday ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 139);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 9;
            label3.Text = "Tuesday";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 99);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 8;
            label2.Text = "Monday";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 7;
            label1.Text = "Item";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(77, 306);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 6;
            // 
            // txtFri
            // 
            txtFri.Location = new Point(77, 265);
            txtFri.Name = "txtFri";
            txtFri.Size = new Size(100, 23);
            txtFri.TabIndex = 5;
            // 
            // txtThu
            // 
            txtThu.Location = new Point(77, 221);
            txtThu.Name = "txtThu";
            txtThu.Size = new Size(100, 23);
            txtThu.TabIndex = 4;
            // 
            // txtWed
            // 
            txtWed.Location = new Point(77, 181);
            txtWed.Name = "txtWed";
            txtWed.Size = new Size(100, 23);
            txtWed.TabIndex = 3;
            // 
            // txtTue
            // 
            txtTue.Location = new Point(77, 136);
            txtTue.Name = "txtTue";
            txtTue.Size = new Size(100, 23);
            txtTue.TabIndex = 2;
            // 
            // txtMon
            // 
            txtMon.Location = new Point(77, 99);
            txtMon.Name = "txtMon";
            txtMon.Size = new Size(100, 23);
            txtMon.TabIndex = 1;
            // 
            // txtItem
            // 
            txtItem.Location = new Point(43, 40);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(100, 23);
            txtItem.TabIndex = 0;
            txtItem.TextChanged += textBox1_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(426, 428);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(10, 10);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // lvSalesReport
            // 
            lvSalesReport.FormattingEnabled = true;
            lvSalesReport.ItemHeight = 15;
            lvSalesReport.Location = new Point(361, 50);
            lvSalesReport.Name = "lvSalesReport";
            lvSalesReport.Size = new Size(410, 319);
            lvSalesReport.TabIndex = 0;
            lvSalesReport.SelectedIndexChanged += lvSalesReport_SelectedIndexChanged;
            // 
            // lblTotalGeneral
            // 
            lblTotalGeneral.AutoSize = true;
            lblTotalGeneral.Location = new Point(688, 344);
            lblTotalGeneral.Name = "lblTotalGeneral";
            lblTotalGeneral.Size = new Size(71, 15);
            lblTotalGeneral.TabIndex = 2;
            lblTotalGeneral.Text = "totalGeneral";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(361, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(410, 257);
            dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(lblTotalGeneral);
            Controls.Add(lvSalesReport);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtPrice;
        private TextBox txtFri;
        private TextBox txtThu;
        private TextBox txtWed;
        private TextBox txtTue;
        private TextBox txtMon;
        private TextBox txtItem;
        private GroupBox groupBox2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnLoadItem;
        private ListBox lvSalesReport;
        private Label lblTotalGeneral;
        private DataGridView dataGridView1;
    }
}
