namespace LibraryManagementSystem.Forms
{
    partial class BorrowingForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private GroupBox groupBoxForm;
        private Label lblMember, lblBook, lblTanggalPinjam, lblTanggalJatuhTempo;
        private ComboBox cmbMember, cmbBook;
        private DateTimePicker dtpTanggalPinjam, dtpTanggalJatuhTempo;
        private Button btnBorrow, btnClear, btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxForm = new System.Windows.Forms.GroupBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblTanggalPinjam = new System.Windows.Forms.Label();
            this.dtpTanggalPinjam = new System.Windows.Forms.DateTimePicker();
            this.lblTanggalJatuhTempo = new System.Windows.Forms.Label();
            this.dtpTanggalJatuhTempo = new System.Windows.Forms.DateTimePicker();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.groupBoxForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(813, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(263, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(327, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📖 PEMINJAMAN BUKU";
            // 
            // groupBoxForm
            // 
            this.groupBoxForm.Controls.Add(this.lblMember);
            this.groupBoxForm.Controls.Add(this.cmbMember);
            this.groupBoxForm.Controls.Add(this.lblBook);
            this.groupBoxForm.Controls.Add(this.cmbBook);
            this.groupBoxForm.Controls.Add(this.lblTanggalPinjam);
            this.groupBoxForm.Controls.Add(this.dtpTanggalPinjam);
            this.groupBoxForm.Controls.Add(this.lblTanggalJatuhTempo);
            this.groupBoxForm.Controls.Add(this.dtpTanggalJatuhTempo);
            this.groupBoxForm.Controls.Add(this.btnBorrow);
            this.groupBoxForm.Controls.Add(this.btnClear);
            this.groupBoxForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxForm.Location = new System.Drawing.Point(57, 120);
            this.groupBoxForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxForm.Name = "groupBoxForm";
            this.groupBoxForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxForm.Size = new System.Drawing.Size(686, 373);
            this.groupBoxForm.TabIndex = 1;
            this.groupBoxForm.TabStop = false;
            this.groupBoxForm.Text = "Form Peminjaman";
            // 
            // lblMember
            // 
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMember.Location = new System.Drawing.Point(34, 40);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(114, 31);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "Pilih Anggota";
            // 
            // cmbMember
            // 
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Location = new System.Drawing.Point(34, 67);
            this.cmbMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(617, 28);
            this.cmbMember.TabIndex = 1;
            // 
            // lblBook
            // 
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBook.Location = new System.Drawing.Point(34, 113);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(114, 31);
            this.lblBook.TabIndex = 2;
            this.lblBook.Text = "Pilih Buku";
            // 
            // cmbBook
            // 
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.Location = new System.Drawing.Point(34, 140);
            this.cmbBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(617, 28);
            this.cmbBook.TabIndex = 3;
            // 
            // lblTanggalPinjam
            // 
            this.lblTanggalPinjam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTanggalPinjam.Location = new System.Drawing.Point(34, 187);
            this.lblTanggalPinjam.Name = "lblTanggalPinjam";
            this.lblTanggalPinjam.Size = new System.Drawing.Size(114, 31);
            this.lblTanggalPinjam.TabIndex = 4;
            this.lblTanggalPinjam.Text = "Tanggal Pinjam";
            // 
            // dtpTanggalPinjam
            // 
            this.dtpTanggalPinjam.Location = new System.Drawing.Point(34, 213);
            this.dtpTanggalPinjam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTanggalPinjam.Name = "dtpTanggalPinjam";
            this.dtpTanggalPinjam.Size = new System.Drawing.Size(285, 27);
            this.dtpTanggalPinjam.TabIndex = 5;
            this.dtpTanggalPinjam.ValueChanged += new System.EventHandler(this.dtpTanggalPinjam_ValueChanged);
            // 
            // lblTanggalJatuhTempo
            // 
            this.lblTanggalJatuhTempo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTanggalJatuhTempo.Location = new System.Drawing.Point(366, 187);
            this.lblTanggalJatuhTempo.Name = "lblTanggalJatuhTempo";
            this.lblTanggalJatuhTempo.Size = new System.Drawing.Size(114, 31);
            this.lblTanggalJatuhTempo.TabIndex = 6;
            this.lblTanggalJatuhTempo.Text = "Tanggal Jatuh Tempo";
            // 
            // dtpTanggalJatuhTempo
            // 
            this.dtpTanggalJatuhTempo.Enabled = false;
            this.dtpTanggalJatuhTempo.Location = new System.Drawing.Point(366, 213);
            this.dtpTanggalJatuhTempo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTanggalJatuhTempo.Name = "dtpTanggalJatuhTempo";
            this.dtpTanggalJatuhTempo.Size = new System.Drawing.Size(285, 27);
            this.dtpTanggalJatuhTempo.TabIndex = 7;
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Location = new System.Drawing.Point(34, 280);
            this.btnBorrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(400, 60);
            this.btnBorrow.TabIndex = 8;
            this.btnBorrow.Text = "💾 Simpan Peminjaman";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(446, 280);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(206, 60);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(314, 520);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(171, 53);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "❌ Tutup";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BorrowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(813, 600);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.groupBoxForm);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "BorrowingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peminjaman Buku - Library Management System";
            this.Load += new System.EventHandler(this.BorrowingForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.groupBoxForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
