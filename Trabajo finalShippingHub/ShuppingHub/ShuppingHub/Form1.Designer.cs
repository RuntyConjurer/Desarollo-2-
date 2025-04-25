namespace ShuppingHub
{
    partial class Form1
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblArrivedAt = new System.Windows.Forms.Label();
            this.lblPackageNumber = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtPackageNumber = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.GroupBoxPackageInfo = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnScanNew = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtArrivedAt = new System.Windows.Forms.TextBox();
            this.cmbFilterState = new System.Windows.Forms.ComboBox();
            this.lstPackages = new System.Windows.Forms.ListBox();
            this.GroupBoxPackageState = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBoxPackageState.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(44, 221);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address:";
            this.lblAddress.Click += new System.EventHandler(this.lblAddress_Click);
            // 
            // lblArrivedAt
            // 
            this.lblArrivedAt.AutoSize = true;
            this.lblArrivedAt.Location = new System.Drawing.Point(20, 96);
            this.lblArrivedAt.Name = "lblArrivedAt";
            this.lblArrivedAt.Size = new System.Drawing.Size(56, 13);
            this.lblArrivedAt.TabIndex = 2;
            this.lblArrivedAt.Text = "Arrived At:";
            this.lblArrivedAt.Click += new System.EventHandler(this.lblArrivedAt_Click);
            // 
            // lblPackageNumber
            // 
            this.lblPackageNumber.AutoSize = true;
            this.lblPackageNumber.Location = new System.Drawing.Point(20, 166);
            this.lblPackageNumber.Name = "lblPackageNumber";
            this.lblPackageNumber.Size = new System.Drawing.Size(67, 13);
            this.lblPackageNumber.TabIndex = 3;
            this.lblPackageNumber.Text = "Package ID:";
            this.lblPackageNumber.Click += new System.EventHandler(this.lblPackageNumber_Click);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(44, 295);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 4;
            this.lblCity.Text = "City:";
            this.lblCity.Click += new System.EventHandler(this.lblCity_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(98, 218);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(666, 20);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(98, 292);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(168, 20);
            this.txtCity.TabIndex = 6;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(305, 295);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "State:";
            this.lblState.Click += new System.EventHandler(this.lblState_Click);
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(346, 291);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 21);
            this.cmbState.TabIndex = 8;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // txtPackageNumber
            // 
            this.txtPackageNumber.Location = new System.Drawing.Point(93, 163);
            this.txtPackageNumber.Name = "txtPackageNumber";
            this.txtPackageNumber.ReadOnly = true;
            this.txtPackageNumber.Size = new System.Drawing.Size(671, 20);
            this.txtPackageNumber.TabIndex = 9;
            this.txtPackageNumber.TextChanged += new System.EventHandler(this.txtPackageNumber_TextChanged);
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(523, 294);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(25, 13);
            this.lblZip.TabIndex = 10;
            this.lblZip.Text = "Zip:";
            this.lblZip.Click += new System.EventHandler(this.lblZip_Click);
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(554, 291);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(131, 20);
            this.txtZip.TabIndex = 11;
            this.txtZip.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // GroupBoxPackageInfo
            // 
            this.GroupBoxPackageInfo.Location = new System.Drawing.Point(12, 135);
            this.GroupBoxPackageInfo.Name = "GroupBoxPackageInfo";
            this.GroupBoxPackageInfo.Size = new System.Drawing.Size(822, 226);
            this.GroupBoxPackageInfo.TabIndex = 13;
            this.GroupBoxPackageInfo.TabStop = false;
            this.GroupBoxPackageInfo.Text = "Package Information:";
            this.GroupBoxPackageInfo.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(35, 383);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 35);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnScanNew
            // 
            this.btnScanNew.Location = new System.Drawing.Point(160, 383);
            this.btnScanNew.Name = "btnScanNew";
            this.btnScanNew.Size = new System.Drawing.Size(94, 35);
            this.btnScanNew.TabIndex = 15;
            this.btnScanNew.Text = "Scan New";
            this.btnScanNew.UseVisualStyleBackColor = true;
            this.btnScanNew.Click += new System.EventHandler(this.btnScanNew_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(296, 383);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 35);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add/Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(442, 383);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 35);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(579, 383);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 35);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(714, 383);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 35);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "NEXT >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtArrivedAt
            // 
            this.txtArrivedAt.Location = new System.Drawing.Point(82, 96);
            this.txtArrivedAt.Name = "txtArrivedAt";
            this.txtArrivedAt.ReadOnly = true;
            this.txtArrivedAt.Size = new System.Drawing.Size(671, 20);
            this.txtArrivedAt.TabIndex = 20;
            this.txtArrivedAt.TextChanged += new System.EventHandler(this.txtArrivedAt_TextChanged);
            // 
            // cmbFilterState
            // 
            this.cmbFilterState.FormattingEnabled = true;
            this.cmbFilterState.Location = new System.Drawing.Point(32, 28);
            this.cmbFilterState.Name = "cmbFilterState";
            this.cmbFilterState.Size = new System.Drawing.Size(186, 21);
            this.cmbFilterState.TabIndex = 21;
            this.cmbFilterState.SelectedIndexChanged += new System.EventHandler(this.cmbFilterState_SelectedIndexChanged);
            // 
            // lstPackages
            // 
            this.lstPackages.FormattingEnabled = true;
            this.lstPackages.Items.AddRange(new object[] {
            ""});
            this.lstPackages.Location = new System.Drawing.Point(889, 200);
            this.lstPackages.Name = "lstPackages";
            this.lstPackages.Size = new System.Drawing.Size(186, 199);
            this.lstPackages.TabIndex = 22;
            this.lstPackages.SelectedIndexChanged += new System.EventHandler(this.lstPackages_SelectedIndexChanged);
            // 
            // GroupBoxPackageState
            // 
            this.GroupBoxPackageState.Controls.Add(this.cmbFilterState);
            this.GroupBoxPackageState.Location = new System.Drawing.Point(857, 135);
            this.GroupBoxPackageState.Name = "GroupBoxPackageState";
            this.GroupBoxPackageState.Size = new System.Drawing.Size(240, 288);
            this.GroupBoxPackageState.TabIndex = 14;
            this.GroupBoxPackageState.TabStop = false;
            this.GroupBoxPackageState.Text = "Package by State:";
            this.GroupBoxPackageState.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 86);
            this.label1.TabIndex = 23;
            this.label1.Text = "ShippingHub";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 606);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPackages);
            this.Controls.Add(this.txtArrivedAt);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnScanNew);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.txtPackageNumber);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblPackageNumber);
            this.Controls.Add(this.lblArrivedAt);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.GroupBoxPackageInfo);
            this.Controls.Add(this.GroupBoxPackageState);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBoxPackageState.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblArrivedAt;
        private System.Windows.Forms.Label lblPackageNumber;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.TextBox txtPackageNumber;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.GroupBox GroupBoxPackageInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnScanNew;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtArrivedAt;
        private System.Windows.Forms.ComboBox cmbFilterState;
        private System.Windows.Forms.ListBox lstPackages;
        private System.Windows.Forms.GroupBox GroupBoxPackageState;
        private System.Windows.Forms.Label label1;
    }
}

