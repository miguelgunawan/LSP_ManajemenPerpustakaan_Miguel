using LibraryManagementSystem.Data;

namespace LibraryManagementSystem.Forms
{
    public partial class HistoryForm : Form
    {
        private readonly BorrowingRepository borrowingRepo;
        private readonly BookRepository bookRepo;
        private readonly MemberRepository memberRepo;

        public HistoryForm()
        {
            InitializeComponent();
            borrowingRepo = new BorrowingRepository();
            bookRepo = new BookRepository();
            memberRepo = new MemberRepository();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHistory()
        {
            try
            {
                var borrowings = borrowingRepo.GetAllBorrowings();

                dgvHistory.DataSource = borrowings;

                if (dgvHistory.Columns.Count > 0)
                {
                    dgvHistory.Columns["IdPeminjaman"].Visible = false;
                    dgvHistory.Columns["IdAnggota"].Visible = false;
                    dgvHistory.Columns["IdBuku"].Visible = false;
                    dgvHistory.Columns["KodePeminjaman"].HeaderText = "Kode";
                    dgvHistory.Columns["NamaAnggota"].HeaderText = "Anggota";
                    dgvHistory.Columns["JudulBuku"].HeaderText = "Buku";
                    dgvHistory.Columns["KodeBuku"].HeaderText = "Kode Buku";
                    dgvHistory.Columns["TanggalPinjam"].HeaderText = "Tgl Pinjam";
                    dgvHistory.Columns["TanggalPinjam"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvHistory.Columns["TanggalJatuhTempo"].HeaderText = "Jatuh Tempo";
                    dgvHistory.Columns["TanggalJatuhTempo"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvHistory.Columns["TanggalKembali"].HeaderText = "Tgl Kembali";
                    dgvHistory.Columns["TanggalKembali"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvHistory.Columns["Denda"].HeaderText = "Denda";
                    dgvHistory.Columns["Denda"].DefaultCellStyle.Format = "N0";
                    dgvHistory.Columns["Status"].HeaderText = "Status";
                }

                // Calculate statistics
                int totalBorrowings = borrowings.Count;
                int activeBorrowings = borrowings.Count(b => b.Status == "Dipinjam");
                int lateBorrowings = borrowings.Count(b => b.Status == "Terlambat");
                decimal totalFines = borrowings.Sum(b => b.Denda);

                lblStats.Text = $"Total: {totalBorrowings} | Aktif: {activeBorrowings} | Terlambat: {lateBorrowings} | Total Denda: Rp {totalFines:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading history: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
