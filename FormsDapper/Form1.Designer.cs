
namespace WindowsFormsApp
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
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.lblRoomImage = new System.Windows.Forms.Label();
            this.txtRoomImage = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtRoomPrice = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBookingStatusId = new System.Windows.Forms.TextBox();
            this.txtRoomTypeId = new System.Windows.Forms.TextBox();
            this.txtRoomCapacity = new System.Windows.Forms.TextBox();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.lblBookingStatusId = new System.Windows.Forms.Label();
            this.lblRoomTypeId = new System.Windows.Forms.Label();
            this.lblRoomCapacity = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblRoomDescription = new System.Windows.Forms.Label();
            this.txtRoomDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomNumber.Location = new System.Drawing.Point(-3, 50);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(107, 19);
            this.lblRoomNumber.TabIndex = 0;
            this.lblRoomNumber.Text = "RoomNumber";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoomNumber.Location = new System.Drawing.Point(126, 50);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(311, 26);
            this.txtRoomNumber.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(23, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(455, 58);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.RowTemplate.Height = 25;
            this.dgvEmployee.Size = new System.Drawing.Size(842, 433);
            this.dgvEmployee.TabIndex = 3;
            this.dgvEmployee.DoubleClick += new System.EventHandler(this.dgvEmployee_DoubleClick);
            // 
            // lblRoomImage
            // 
            this.lblRoomImage.AutoSize = true;
            this.lblRoomImage.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomImage.Location = new System.Drawing.Point(12, 82);
            this.lblRoomImage.Name = "lblRoomImage";
            this.lblRoomImage.Size = new System.Drawing.Size(92, 19);
            this.lblRoomImage.TabIndex = 0;
            this.lblRoomImage.Text = "RoomImage";
            // 
            // txtRoomImage
            // 
            this.txtRoomImage.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoomImage.Location = new System.Drawing.Point(126, 82);
            this.txtRoomImage.Name = "txtRoomImage";
            this.txtRoomImage.Size = new System.Drawing.Size(311, 26);
            this.txtRoomImage.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.Location = new System.Drawing.Point(12, 114);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(85, 19);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "RoomPrice";
            // 
            // txtRoomPrice
            // 
            this.txtRoomPrice.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoomPrice.Location = new System.Drawing.Point(126, 114);
            this.txtRoomPrice.Multiline = true;
            this.txtRoomPrice.Name = "txtRoomPrice";
            this.txtRoomPrice.Size = new System.Drawing.Size(311, 27);
            this.txtRoomPrice.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(111, 423);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(211, 423);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(592, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(137, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(759, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBookingStatusId
            // 
            this.txtBookingStatusId.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBookingStatusId.Location = new System.Drawing.Point(126, 147);
            this.txtBookingStatusId.Name = "txtBookingStatusId";
            this.txtBookingStatusId.Size = new System.Drawing.Size(311, 26);
            this.txtBookingStatusId.TabIndex = 1;
            // 
            // txtRoomTypeId
            // 
            this.txtRoomTypeId.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoomTypeId.Location = new System.Drawing.Point(126, 179);
            this.txtRoomTypeId.Name = "txtRoomTypeId";
            this.txtRoomTypeId.Size = new System.Drawing.Size(311, 26);
            this.txtRoomTypeId.TabIndex = 1;
            // 
            // txtRoomCapacity
            // 
            this.txtRoomCapacity.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoomCapacity.Location = new System.Drawing.Point(126, 211);
            this.txtRoomCapacity.Name = "txtRoomCapacity";
            this.txtRoomCapacity.Size = new System.Drawing.Size(311, 26);
            this.txtRoomCapacity.TabIndex = 1;
            // 
            // txtIsActive
            // 
            this.txtIsActive.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIsActive.Location = new System.Drawing.Point(126, 269);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(311, 26);
            this.txtIsActive.TabIndex = 1;
            // 
            // lblBookingStatusId
            // 
            this.lblBookingStatusId.AutoSize = true;
            this.lblBookingStatusId.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBookingStatusId.Location = new System.Drawing.Point(-2, 147);
            this.lblBookingStatusId.Name = "lblBookingStatusId";
            this.lblBookingStatusId.Size = new System.Drawing.Size(122, 19);
            this.lblBookingStatusId.TabIndex = 0;
            this.lblBookingStatusId.Text = "BookingStatusId";
            // 
            // lblRoomTypeId
            // 
            this.lblRoomTypeId.AutoSize = true;
            this.lblRoomTypeId.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomTypeId.Location = new System.Drawing.Point(7, 179);
            this.lblRoomTypeId.Name = "lblRoomTypeId";
            this.lblRoomTypeId.Size = new System.Drawing.Size(98, 19);
            this.lblRoomTypeId.TabIndex = 0;
            this.lblRoomTypeId.Text = "RoomTypeId";
            // 
            // lblRoomCapacity
            // 
            this.lblRoomCapacity.AutoSize = true;
            this.lblRoomCapacity.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomCapacity.Location = new System.Drawing.Point(7, 211);
            this.lblRoomCapacity.Name = "lblRoomCapacity";
            this.lblRoomCapacity.Size = new System.Drawing.Size(108, 19);
            this.lblRoomCapacity.TabIndex = 0;
            this.lblRoomCapacity.Text = "RoomCapacity";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIsActive.Location = new System.Drawing.Point(12, 272);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(63, 19);
            this.lblIsActive.TabIndex = 0;
            this.lblIsActive.Text = "IsActive";
            // 
            // lblRoomDescription
            // 
            this.lblRoomDescription.AutoSize = true;
            this.lblRoomDescription.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomDescription.Location = new System.Drawing.Point(-2, 243);
            this.lblRoomDescription.Name = "lblRoomDescription";
            this.lblRoomDescription.Size = new System.Drawing.Size(130, 19);
            this.lblRoomDescription.TabIndex = 0;
            this.lblRoomDescription.Text = "RoomDescription";
            // 
            // txtRoomDescription
            // 
            this.txtRoomDescription.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoomDescription.Location = new System.Drawing.Point(126, 240);
            this.txtRoomDescription.Name = "txtRoomDescription";
            this.txtRoomDescription.Size = new System.Drawing.Size(311, 26);
            this.txtRoomDescription.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 551);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtRoomPrice);
            this.Controls.Add(this.txtBookingStatusId);
            this.Controls.Add(this.txtIsActive);
            this.Controls.Add(this.txtRoomTypeId);
            this.Controls.Add(this.txtRoomDescription);
            this.Controls.Add(this.txtRoomCapacity);
            this.Controls.Add(this.txtRoomImage);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.lblRoomDescription);
            this.Controls.Add(this.lblRoomCapacity);
            this.Controls.Add(this.lblRoomTypeId);
            this.Controls.Add(this.lblBookingStatusId);
            this.Controls.Add(this.lblRoomImage);
            this.Controls.Add(this.lblRoomNumber);
            this.Name = "Form1";
            this.Text = "Employee Contact Book";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Label lblRoomImage;
        private System.Windows.Forms.TextBox txtRoomImage;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtRoomPrice;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBookingStatusId;
        private System.Windows.Forms.TextBox txtRoomTypeId;
        private System.Windows.Forms.TextBox txtRoomCapacity;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.Label lblBookingStatusId;
        private System.Windows.Forms.Label lblRoomTypeId;
        private System.Windows.Forms.Label lblRoomCapacity;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblRoomDescription;
        private System.Windows.Forms.TextBox txtRoomDescription;
    }
}

