using System.Text;

namespace LibraryManagementSystem.Utils
{
    public static class FileExporter
    {
        // Export ke format TXT
        public static bool ExportToTxt(string filePath, List<string[]> data, string[] headers)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Write header
                    writer.WriteLine(string.Join(" | ", headers));
                    writer.WriteLine(new string('=', 100));

                    // Write data
                    foreach (var row in data)
                    {
                        writer.WriteLine(string.Join(" | ", row));
                    }

                    writer.WriteLine(new string('=', 100));
                    writer.WriteLine($"Total Records: {data.Count}");
                    writer.WriteLine($"Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Export ke format CSV
        public static bool ExportToCsv(string filePath, List<string[]> data, string[] headers)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Write header
                    writer.WriteLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    // Write data
                    foreach (var row in data)
                    {
                        var escapedRow = row.Select(cell => $"\"{cell?.Replace("\"", "\"\"")}\"");
                        writer.WriteLine(string.Join(",", escapedRow));
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Generate borrowing report
        public static string GenerateReport(int totalBooks, int totalMembers, int totalBorrowings, 
            int activeBorrowings, int lateBorrowings)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("========================================");
            report.AppendLine("   LAPORAN PERPUSTAKAAN");
            report.AppendLine("========================================");
            report.AppendLine($"Tanggal: {DateTime.Now:dd MMMM yyyy HH:mm:ss}");
            report.AppendLine();
            report.AppendLine("STATISTIK:");
            report.AppendLine($"- Total Buku: {totalBooks}");
            report.AppendLine($"- Total Anggota: {totalMembers}");
            report.AppendLine($"- Total Peminjaman: {totalBorrowings}");
            report.AppendLine($"- Peminjaman Aktif: {activeBorrowings}");
            report.AppendLine($"- Peminjaman Terlambat: {lateBorrowings}");
            report.AppendLine("========================================");
            return report.ToString();
        }
    }
}
