using LibraryManagementSystem.Data;

namespace LibraryManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Test database connection
            try
            {
                var db = new DatabaseHelper();
                if (!db.TestConnection())
                {
                    MessageBox.Show("Tidak dapat terhubung ke database.\n\nPastikan:\n1. SQL Server sudah berjalan\n2. Database 'LibraryManagementDB' sudah dibuat\n3. Jalankan script SQL yang tersedia", 
                        "Peringatan Koneksi Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            try
            {
                var bookForm = new BookForm();
                bookForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error membuka form buku: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            try
            {
                var memberForm = new MemberForm();
                memberForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error membuka form anggota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrowing_Click(object sender, EventArgs e)
        {
            try
            {
                var borrowingForm = new BorrowingForm();
                borrowingForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error membuka form peminjaman: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                var returnForm = new ReturnForm();
                returnForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error membuka form pengembalian: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                var historyForm = new HistoryForm();
                historyForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error membuka form riwayat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblFooter_Click(object sender, EventArgs e)
        {

        }
    }
}
