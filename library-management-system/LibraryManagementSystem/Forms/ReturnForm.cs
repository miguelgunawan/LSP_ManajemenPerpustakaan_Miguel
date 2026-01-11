using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Forms
{
    public partial class ReturnForm : Form
    {
        private readonly BorrowingRepository borrowingRepo;
        private readonly BookRepository bookRepo;
        private int selectedIdPeminjaman = 0;

        public ReturnForm()
        {
            InitializeComponent();
            borrowingRepo = new BorrowingRepository();
            bookRepo = new BookRepository();
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadActiveBorrowings();
                dtpTanggalKembali.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadActiveBorrowings()
        {
            try
            {
                var borrowings = borrowingRepo.GetActiveBorrowings();
                dgvBorrowings.DataSource = borrowings;

                if (dgvBorrowings.Columns.Count > 0)
                {
                    dgvBorrowings.Columns["IdPeminjaman"].Visible = false;
                    dgvBorrowings.Columns["IdAnggota"].Visible = false;
                    dgvBorrowings.Columns["IdBuku"].Visible = false;
                    dgvBorrowings.Columns["KodePeminjaman"].HeaderText = "Kode";
                    dgvBorrowings.Columns["NamaAnggota"].HeaderText = "Anggota";
                    dgvBorrowings.Columns["JudulBuku"].HeaderText = "Buku";
                    dgvBorrowings.Columns["KodeBuku"].HeaderText = "Kode Buku";
                    dgvBorrowings.Columns["TanggalPinjam"].HeaderText = "Tgl Pinjam";
                    dgvBorrowings.Columns["TanggalPinjam"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvBorrowings.Columns["TanggalJatuhTempo"].HeaderText = "Jatuh Tempo";
                    dgvBorrowings.Columns["TanggalJatuhTempo"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvBorrowings.Columns["Status"].HeaderText = "Status";
                }

                lblTitle.Text = $"↩️ PENGEMBALIAN BUKU ({borrowings.Count} Peminjaman Aktif)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBorrowings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvBorrowings.Rows[e.RowIndex];
                    selectedIdPeminjaman = Convert.ToInt32(row.Cells["IdPeminjaman"].Value);
                    
                    txtKodePeminjaman.Text = row.Cells["KodePeminjaman"].Value.ToString();
                    txtNamaAnggota.Text = row.Cells["NamaAnggota"].Value.ToString();
                    txtJudulBuku.Text = row.Cells["JudulBuku"].Value.ToString();
                    
                    DateTime TanggalJatuhTempo = Convert.ToDateTime(row.Cells["TanggalJatuhTempo"].Value);
                    DateTime TanggalKembali = dtpTanggalKembali.Value;
                    
                    // Hitung denda menggunakan Polymorphism
                    var borrowing = new Borrowing
                    {
                        TanggalJatuhTempo = TanggalJatuhTempo,
                        TanggalKembali = TanggalKembali
                    };
                    
                    decimal fine = borrowing.HitungDenda();
                    txtFine.Text = fine.ToString("N0");
                    
                    if (fine > 0)
                    {
                        lblFineInfo.Text = $"⚠️ Terlambat {(TanggalKembali - TanggalJatuhTempo).Days} hari (Rp 2.000/hari)";
                        lblFineInfo.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblFineInfo.Text = "✓ Tidak ada denda";
                        lblFineInfo.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpTanggalKembali_ValueChanged(object sender, EventArgs e)
        {
            // Re-calculate fine when return date changes
            if (selectedIdPeminjaman > 0 && dgvBorrowings.SelectedRows.Count > 0)
            {
                dgvBorrowings_CellClick(dgvBorrowings, 
                    new DataGridViewCellEventArgs(0, dgvBorrowings.SelectedRows[0].Index));
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedIdPeminjaman == 0)
                {
                    MessageBox.Show("Pilih peminjaman yang akan dikembalikan!", "Validasi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal fine = decimal.Parse(txtFine.Text);
                var result = MessageBox.Show(
                    $"Proses pengembalian buku?\n\nDenda: Rp {fine:N0}", 
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (borrowingRepo.ReturnBook(selectedIdPeminjaman, dtpTanggalKembali.Value, fine))
                    {
                        // Get book ID and update stock
                        var row = dgvBorrowings.SelectedRows[0];
                        int IdBuku = Convert.ToInt32(row.Cells["IdBuku"].Value);
                        var book = bookRepo.GetBookById(IdBuku);
                        if (book != null)
                        {
                            bookRepo.UpdateStock(IdBuku, book.StokTersedia + 1);
                        }

                        MessageBox.Show("Pengembalian berhasil diproses!", "Sukses", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        ClearForm();
                        LoadActiveBorrowings();
                    }
                    else
                    {
                        MessageBox.Show("Gagal memproses pengembalian.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            selectedIdPeminjaman = 0;
            txtKodePeminjaman.Clear();
            txtNamaAnggota.Clear();
            txtJudulBuku.Clear();
            txtFine.Text = "0";
            lblFineInfo.Text = "";
            dtpTanggalKembali.Value = DateTime.Now;
        }
    }
}
