using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Forms
{
    public partial class BorrowingForm : Form
    {
        private readonly BorrowingRepository borrowingRepo;
        private readonly BookRepository bookRepo;
        private readonly MemberRepository memberRepo;

        public BorrowingForm()
        {
            InitializeComponent();
            borrowingRepo = new BorrowingRepository();
            bookRepo = new BookRepository();
            memberRepo = new MemberRepository();
        }

        private void BorrowingForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMembers();
                LoadBooks();
                dtpTanggalPinjam.Value = DateTime.Now;
                dtpTanggalJatuhTempo.Value = DateTime.Now.AddDays(7); // Auto 7 hari
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMembers()
        {
            try
            {
                var members = memberRepo.GetActiveMembers();
                cmbMember.DataSource = members;
                cmbMember.DisplayMember = "NamaLengkap";
                cmbMember.ValueMember = "IdAnggota";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var books = bookRepo.GetAllBooks().Where(b => b.IsAvailable()).ToList();
                cmbBook.DataSource = books;
                cmbBook.DisplayMember = "Title";
                cmbBook.ValueMember = "IdBuku";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpTanggalPinjam_ValueChanged(object sender, EventArgs e)
        {
            // Auto update due date (7 hari dari tanggal pinjam)
            dtpTanggalJatuhTempo.Value = dtpTanggalPinjam.Value.AddDays(7);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMember.SelectedValue == null || cmbBook.SelectedValue == null)
                {
                    MessageBox.Show("Pilih anggota dan buku terlebih dahulu!", "Validasi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int IdAnggota = Convert.ToInt32(cmbMember.SelectedValue);
                int IdBuku = Convert.ToInt32(cmbBook.SelectedValue);

                // Check stok
                var book = bookRepo.GetBookById(IdBuku);
                if (book == null || !book.IsAvailable())
                {
                    MessageBox.Show("Buku tidak tersedia!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create borrowing
                var borrowing = new Borrowing
                {
                    KodePeminjaman = borrowingRepo.GenerateBorrowingCode(),
                    IdAnggota = IdAnggota,
                    IdBuku = IdBuku,
                    TanggalPinjam = dtpTanggalPinjam.Value,
                    TanggalJatuhTempo = dtpTanggalJatuhTempo.Value,
                    Status = "Dipinjam"
                };

                if (borrowingRepo.AddBorrowing(borrowing))
                {
                    // Update stok buku
                    bookRepo.UpdateStock(IdBuku, book.StokTersedia - 1);

                    MessageBox.Show("Peminjaman berhasil disimpan!", "Sukses", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    ClearForm();
                    LoadBooks(); // Refresh books list
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan peminjaman.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            if (cmbMember.Items.Count > 0) cmbMember.SelectedIndex = 0;
            if (cmbBook.Items.Count > 0) cmbBook.SelectedIndex = 0;
            dtpTanggalPinjam.Value = DateTime.Now;
            dtpTanggalJatuhTempo.Value = DateTime.Now.AddDays(7);
        }
    }
}
