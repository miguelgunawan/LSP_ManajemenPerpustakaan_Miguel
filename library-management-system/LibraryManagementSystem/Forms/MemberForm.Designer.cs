namespace LibraryManagementSystem.Forms
{
    partial class MemberForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private GroupBox groupBoxForm;
        private TextBox txtKodeAnggota, txtNamaLengkap, txtAlamat, txtNoTelepon, txtEmail;
        private Label lblKodeAnggota, lblNamaLengkap, lblAlamat, lblNoTelepon, lblEmail;
        private CheckBox chkActive;
        private GroupBox groupBoxButtons;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dgvMembers;
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
            this.groupBoxForm = new GroupBox();
            this.txtKodeAnggota = new TextBox();
            this.lblKodeAnggota = new Label();
            this.txtNamaLengkap = new TextBox();
            this.lblNamaLengkap = new Label();
            this.txtAlamat = new TextBox();
            this.lblAlamat = new Label();
            this.txtNoTelepon = new TextBox();
            this.lblNoTelepon = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.chkActive = new CheckBox();
            this.groupBoxButtons = new GroupBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            this.dgvMembers = new DataGridView();
            this.btnClose = new Button();

            // Panel Top
            this.panelTop.BackColor = Color.FromArgb(46, 204, 113);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Size = new Size(1200, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(450, 15);
            this.lblTitle.Text = "👥 MANAJEMEN ANGGOTA";

            // GroupBox Form
            this.groupBoxForm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxForm.Location = new Point(20, 80);
            this.groupBoxForm.Size = new Size(350, 340);
            this.groupBoxForm.Text = "Form Data Anggota";
            this.groupBoxForm.Controls.AddRange(new Control[] {
                this.lblKodeAnggota, this.txtKodeAnggota,
                this.lblNamaLengkap, this.txtNamaLengkap,
                this.lblAlamat, this.txtAlamat,
                this.lblNoTelepon, this.txtNoTelepon,
                this.lblEmail, this.txtEmail,
                this.chkActive
            });

            this.lblKodeAnggota.Location = new Point(20, 27);
            this.lblKodeAnggota.Text = "Kode Anggota";
            this.txtKodeAnggota.Location = new Point(20, 45);
            this.txtKodeAnggota.Size = new Size(310, 23);

            this.lblNamaLengkap.Location = new Point(20, 75);
            this.lblNamaLengkap.Text = "Nama Lengkap";
            this.txtNamaLengkap.Location = new Point(20, 93);
            this.txtNamaLengkap.Size = new Size(310, 23);

            this.lblAlamat.Location = new Point(20, 123);
            this.lblAlamat.Text = "Alamat";
            this.txtAlamat.Location = new Point(20, 141);
            this.txtAlamat.Size = new Size(310, 60);
            this.txtAlamat.Multiline = true;

            this.lblNoTelepon.Location = new Point(20, 207);
            this.lblNoTelepon.Text = "No. Telepon";
            this.txtNoTelepon.Location = new Point(20, 225);
            this.txtNoTelepon.Size = new Size(310, 23);

            this.lblEmail.Location = new Point(20, 255);
            this.lblEmail.Text = "Email";
            this.txtEmail.Location = new Point(20, 273);
            this.txtEmail.Size = new Size(310, 23);

            this.chkActive.Location = new Point(20, 305);
            this.chkActive.Text = "Anggota Aktif";
            this.chkActive.Checked = true;

            // GroupBox Buttons
            this.groupBoxButtons.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxButtons.Location = new Point(20, 430);
            this.groupBoxButtons.Size = new Size(350, 100);
            this.groupBoxButtons.Text = "Aksi";
            this.groupBoxButtons.Controls.AddRange(new Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear
            });

            this.btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(20, 30);
            this.btnAdd.Size = new Size(150, 35);
            this.btnAdd.Text = "➕ Tambah";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = Color.FromArgb(52, 152, 219);
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.Location = new Point(180, 30);
            this.btnUpdate.Size = new Size(150, 35);
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(20, 70);
            this.btnDelete.Size = new Size(150, 35);
            this.btnDelete.Text = "🗑️ Hapus";
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(180, 70);
            this.btnClear.Size = new Size(150, 35);
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // DataGridView
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = Color.White;
            this.dgvMembers.Location = new Point(390, 80);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new Size(790, 450);
            this.dgvMembers.CellClick += new DataGridViewCellEventHandler(this.dgvMembers_CellClick);

            // Button Close
            this.btnClose.BackColor = Color.FromArgb(231, 76, 60);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(1040, 540);
            this.btnClose.Size = new Size(140, 40);
            this.btnClose.Text = "❌ Tutup";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1200, 590);
            this.Controls.AddRange(new Control[] {
                this.panelTop, this.groupBoxForm, this.groupBoxButtons,
                this.dgvMembers, this.btnClose
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Manajemen Anggota - Library Management System";
            this.Load += new EventHandler(this.MemberForm_Load);
        }
    }
}
