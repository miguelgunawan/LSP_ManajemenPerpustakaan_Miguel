using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Forms
{
    public partial class BookForm : Form
    {
        private readonly BookRepository bookRepo;
        private int selectedIdBuku = 0;

        public BookForm()
        {
            InitializeComponent();
            bookRepo = new BookRepository();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBooks();
                cmbKategori.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var books = bookRepo.GetAllBooks();
                dgvBooks.DataSource = books;

                // Customize column headers
                if (dgvBooks.Columns.Count > 0)
                {
                    dgvBooks.Columns["IdBuku"].HeaderText = "ID";
                    dgvBooks.Columns["IdBuku"].Width = 50;
                    dgvBooks.Columns["KodeBuku"].HeaderText = "Kode Buku";
                    dgvBooks.Columns["KodeBuku"].Width = 100;
                    dgvBooks.Columns["Judul"].HeaderText = "Judul";
                    dgvBooks.Columns["Judul"].Width = 200;
                    dgvBooks.Columns["Penulis"].HeaderText = "Penulis";
                    dgvBooks.Columns["Penulis"].Width = 150;
                    dgvBooks.Columns["Penerbit"].HeaderText = "Penerbit";
                    dgvBooks.Columns["TahunTerbit"].HeaderText = "Tahun";
                    dgvBooks.Columns["TahunTerbit"].Width = 70;
                    dgvBooks.Columns["Kategori"].HeaderText = "Kategori";
                    dgvBooks.Columns["Stok"].HeaderText = "Stok";
                    dgvBooks.Columns["Stok"].Width = 60;
                    dgvBooks.Columns["StokTersedia"].HeaderText = "Tersedia";
                    dgvBooks.Columns["StokTersedia"].Width = 70;
                    dgvBooks.Columns["TanggalInput"].HeaderText = "Tanggal Input";
                    dgvBooks.Columns["TanggalInput"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                lblTitle.Text = $"📚 MANAJEMEN BUKU ({books.Count} Buku)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input
                if (!ValidateInput())
                    return;

                var book = new Book
                {
                    KodeBuku = txtKodeBuku.Text.Trim(),
                    Judul = txtTitle.Text.Trim(),
                    Penulis = txtPenulis.Text.Trim(),
                    Penerbit = txtPenerbit.Text.Trim(),
                    TahunTerbit = (int)numYear.Value,
                    Kategori = cmbKategori.Text,
                    Stok = (int)numStock.Value,
                    StokTersedia = (int)numStock.Value
                };

                if (bookRepo.AddBook(book))
                {
                    MessageBox.Show("Buku berhasil ditambahkan!", "Sukses", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan buku. Pastikan kode buku belum digunakan.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedIdBuku == 0)
                {
                    MessageBox.Show("Pilih buku yang akan diupdate terlebih dahulu!", "Peringatan", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi input
                if (!ValidateInput())
                    return;

                var book = new Book
                {
                    IdBuku = selectedIdBuku,
                    KodeBuku = txtKodeBuku.Text.Trim(),
                    Judul = txtTitle.Text.Trim(),
                    Penulis = txtPenulis.Text.Trim(),
                    Penerbit = txtPenerbit.Text.Trim(),
                    TahunTerbit = (int)numYear.Value,
                    Kategori = cmbKategori.Text,
                    Stok = (int)numStock.Value,
                    StokTersedia = (int)numStock.Value
                };

                if (bookRepo.UpdateBook(book))
                {
                    MessageBox.Show("Buku berhasil diupdate!", "Sukses", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate buku.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedIdBuku == 0)
                {
                    MessageBox.Show("Pilih buku yang akan dihapus terlebih dahulu!", "Peringatan", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Apakah Anda yakin ingin menghapus buku ini?", 
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (bookRepo.DeleteBook(selectedIdBuku))
                    {
                        MessageBox.Show("Buku berhasil dihapus!", "Sukses", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus buku. Buku mungkin masih memiliki peminjaman aktif.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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



        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                    
                    selectedIdBuku = Convert.ToInt32(row.Cells["IdBuku"].Value);
                    txtKodeBuku.Text = row.Cells["KodeBuku"].Value.ToString();
                    txtTitle.Text = row.Cells["Judul"].Value.ToString();
                    txtPenulis.Text = row.Cells["Penulis"].Value.ToString();
                    txtPenerbit.Text = row.Cells["Penerbit"].Value.ToString();
                    numYear.Value = Convert.ToInt32(row.Cells["TahunTerbit"].Value);
                    cmbKategori.Text = row.Cells["Kategori"].Value.ToString();
                    numStock.Value = Convert.ToInt32(row.Cells["Stok"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper Methods
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtKodeBuku.Text))
            {
                MessageBox.Show("Kode buku tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeBuku.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Judul buku tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPenulis.Text))
            {
                MessageBox.Show("Penulis tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPenulis.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPenerbit.Text))
            {
                MessageBox.Show("Penerbit tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPenerbit.Focus();
                return false;
            }

            if (cmbKategori.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kategori buku!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKategori.Focus();
                return false;
            }

            if (numStock.Value <= 0)
            {
                MessageBox.Show("Stok buku harus lebih dari 0!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numStock.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedIdBuku = 0;
            txtKodeBuku.Clear();
            txtTitle.Clear();
            txtPenulis.Clear();
            txtPenerbit.Clear();
            numYear.Value = 2026;
            cmbKategori.SelectedIndex = 0;
            numStock.Value = 1;
            txtKodeBuku.Focus();
        }
    }
}
