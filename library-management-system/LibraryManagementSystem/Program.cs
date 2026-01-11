using LibraryManagementSystem.Forms;
using LibraryManagementSystem.Data;

namespace LibraryManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Cek dan buat database jika belum ada
                var dbHelper = new DatabaseHelper();
                dbHelper.EnsureDatabaseExists();

                // Jalankan aplikasi
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error memulai aplikasi: {ex.Message}\n\nPastikan MySQL server sudah terinstall, database telah dibuat dan service berjalan.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
