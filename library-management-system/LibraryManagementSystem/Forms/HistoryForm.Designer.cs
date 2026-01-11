namespace LibraryManagementSystem.Forms
{
    partial class HistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private DataGridView dgvHistory;
        private Label lblStats;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.dgvHistory = new DataGridView();
            this.lblStats = new Label();
            this.btnClose = new Button();

            // Panel Top
            this.panelTop.BackColor = Color.FromArgb(241, 196, 15);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Size = new Size(1200, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(420, 15);
            this.lblTitle.Text = "📋 RIWAYAT & LAPORAN";

            // DataGridView
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = Color.White;
            this.dgvHistory.Location = new Point(20, 80);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new Size(1160, 430);

            // Label Stats
            this.lblStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblStats.Location = new Point(20, 520);
            this.lblStats.Size = new Size(900, 20);
            this.lblStats.Text = "Total: 0 | Aktif: 0 | Terlambat: 0 | Total Denda: Rp 0";

            // Button Close
            this.btnClose.BackColor = Color.FromArgb(231, 76, 60);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(1040, 550);
            this.btnClose.Size = new Size(140, 40);
            this.btnClose.Text = "❌ Tutup";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1200, 610);
            this.Controls.AddRange(new Control[] {
                this.panelTop, this.dgvHistory,
                this.lblStats, this.btnClose
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Riwayat & Laporan - Library Management System";
            this.Load += new EventHandler(this.HistoryForm_Load);
        }
    }
}
