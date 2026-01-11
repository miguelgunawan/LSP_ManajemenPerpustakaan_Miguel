namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int IdBuku { get; set; }
        public string KodeBuku { get; set; } = string.Empty;
        public string Judul { get; set; } = string.Empty;
        public string Penulis { get; set; } = string.Empty;
        public string Penerbit { get; set; } = string.Empty;
        public int TahunTerbit { get; set; }
        public string Kategori { get; set; } = string.Empty;
        public int Stok { get; set; }
        public int StokTersedia { get; set; }
        public DateTime TanggalInput { get; set; }

        // Function untuk validasi
        public bool IsAvailable()
        {
            return StokTersedia > 0;
        }

        // Function untuk mendapatkan info lengkap
        public string GetFullInfo()
        {
            return $"[{KodeBuku}] {Judul} - {Penulis} ({TahunTerbit})\nStok: {StokTersedia}/{Stok}";
        }

        // Procedure untuk update stok
        public void UpdateStock(int borrowed)
        {
            StokTersedia = Stok - borrowed;
        }

        // Override ToString untuk display
        public override string ToString()
        {
            return $"{KodeBuku} - {Judul}";
        }
    }
}
