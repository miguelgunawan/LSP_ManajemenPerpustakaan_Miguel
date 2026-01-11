namespace LibraryManagementSystem.Forms
{
    partial class ReturnForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private GroupBox groupBoxData;
        private Label lblKodePeminjaman, lblNamaAnggota, lblJudulBuku, lblTanggalKembali, lblFine, lblFineInfo;
        private TextBox txtKodePeminjaman, txtNamaAnggota, txtJudulBuku, txtFine;
        private DateTimePicker dtpTanggalKembali;
        private Button btnReturn, btnClear, btnClose;
        private DataGridView dgvBorrowings;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.groupBoxData = new GroupBox();
            this.lblKodePeminjaman = new Label();
            this.txtKodePeminjaman = new TextBox();
            this.lblNamaAnggota = new Label();
            this.txtNamaAnggota = new TextBox();
            this.lblJudulBuku = new Label();
            this.txtJudulBuku = new TextBox();
            this.lblTanggalKembali = new Label();
            this.dtpTanggalKembali = new DateTimePicker();
            this.lblFine = new Label();
            this.txtFine = new TextBox();
            this.lblFineInfo = new Label();
            this.btnReturn = new Button();
            this.btnClear = new Button();
            this.dgvBorrowings = new DataGridView();
            this.btnClose = new Button();

            // Panel Top
            this.panelTop.BackColor = Color.FromArgb(230, 126, 34);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Size = new Size(1100, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(350, 15);
            this.lblTitle.Text = "↩️ PENGEMBALIAN BUKU";

            // GroupBox Data
            this.groupBoxData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxData.Location = new Point(20, 80);
            this.groupBoxData.Size = new Size(400, 380);
            this.groupBoxData.Text = "Data Pengembalian";

            this.lblKodePeminjaman.Font = new Font("Segoe UI", 9F);
            this.lblKodePeminjaman.Location = new Point(20, 30);
            this.lblKodePeminjaman.Text = "Kode Peminjaman";
            this.txtKodePeminjaman.Location = new Point(20, 50);
            this.txtKodePeminjaman.ReadOnly = true;
            this.txtKodePeminjaman.Size = new Size(360, 23);
            this.txtKodePeminjaman.BackColor = Color.WhiteSmoke;

            this.lblNamaAnggota.Font = new Font("Segoe UI", 9F);
            this.lblNamaAnggota.Location = new Point(20, 80);
            this.lblNamaAnggota.Text = "Nama Anggota";
            this.txtNamaAnggota.Location = new Point(20, 100);
            this.txtNamaAnggota.ReadOnly = true;
            this.txtNamaAnggota.Size = new Size(360, 23);
            this.txtNamaAnggota.BackColor = Color.WhiteSmoke;

            this.lblJudulBuku.Font = new Font("Segoe UI", 9F);
            this.lblJudulBuku.Location = new Point(20, 130);
            this.lblJudulBuku.Text = "Judul Buku";
            this.txtJudulBuku.Location = new Point(20, 150);
            this.txtJudulBuku.ReadOnly = true;
            this.txtJudulBuku.Size = new Size(360, 23);
            this.txtJudulBuku.BackColor = Color.WhiteSmoke;

            this.lblTanggalKembali.Font = new Font("Segoe UI", 9F);
            this.lblTanggalKembali.Location = new Point(20, 180);
            this.lblTanggalKembali.Text = "Tanggal Pengembalian";
            this.dtpTanggalKembali.Location = new Point(20, 200);
            this.dtpTanggalKembali.Size = new Size(360, 23);
            this.dtpTanggalKembali.ValueChanged += new EventHandler(this.dtpTanggalKembali_ValueChanged);

            this.lblFine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFine.Location = new Point(20, 230);
            this.lblFine.Text = "Denda (Rp)";
            this.txtFine.Location = new Point(20, 250);
            this.txtFine.ReadOnly = true;
            this.txtFine.Size = new Size(360, 23);
            this.txtFine.BackColor = Color.LightYellow;
            this.txtFine.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.txtFine.Text = "0";

            this.lblFineInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblFineInfo.Location = new Point(20, 280);
            this.lblFineInfo.Size = new Size(360, 20);

            this.btnReturn.BackColor = Color.FromArgb(230, 126, 34);
            this.btnReturn.FlatStyle = FlatStyle.Flat;
            this.btnReturn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnReturn.ForeColor = Color.White;
            this.btnReturn.Location = new Point(20, 315);
            this.btnReturn.Size = new Size(270, 40);
            this.btnReturn.Text = "✅ Proses Pengembalian";
            this.btnReturn.Click += new EventHandler(this.btnReturn_Click);

            this.btnClear.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(300, 315);
            this.btnClear.Size = new Size(80, 40);
            this.btnClear.Text = "🔄";
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            this.groupBoxData.Controls.AddRange(new Control[] {
                this.lblKodePeminjaman, this.txtKodePeminjaman,
                this.lblNamaAnggota, this.txtNamaAnggota,
                this.lblJudulBuku, this.txtJudulBuku,
                this.lblTanggalKembali, this.dtpTanggalKembali,
                this.lblFine, this.txtFine, this.lblFineInfo,
                this.btnReturn, this.btnClear
            });

            // DataGridView
            this.dgvBorrowings.AllowUserToAddRows = false;
            this.dgvBorrowings.AllowUserToDeleteRows = false;
            this.dgvBorrowings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowings.BackgroundColor = Color.White;
            this.dgvBorrowings.Location = new Point(440, 80);
            this.dgvBorrowings.MultiSelect = false;
            this.dgvBorrowings.ReadOnly = true;
            this.dgvBorrowings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowings.Size = new Size(640, 380);
            this.dgvBorrowings.CellClick += new DataGridViewCellEventHandler(this.dgvBorrowings_CellClick);

            // Button Close
            this.btnClose.BackColor = Color.FromArgb(231, 76, 60);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(940, 470);
            this.btnClose.Size = new Size(140, 40);
            this.btnClose.Text = "❌ Tutup";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1100, 520);
            this.Controls.AddRange(new Control[] {
                this.panelTop, this.groupBoxData, this.dgvBorrowings, this.btnClose
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pengembalian Buku - Library Management System";
            this.Load += new EventHandler(this.ReturnForm_Load);
        }
    }
}
