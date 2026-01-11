namespace LibraryManagementSystem.Models
{
    public class Borrowing
    {
        public int IdPeminjaman { get; set; }
        public string KodePeminjaman { get; set; } = string.Empty;
        public int IdAnggota { get; set; }
        public int IdBuku { get; set; }
        public DateTime TanggalPinjam { get; set; }
        public DateTime TanggalJatuhTempo { get; set; }
        public DateTime? TanggalKembali { get; set; }
        public decimal Denda { get; set; }
        public string Status { get; set; } = "Dipinjam"; // Dipinjam, Dikembalikan, Terlambat

        // Untuk display
        public string? NamaAnggota { get; set; }
        public string? JudulBuku { get; set; }
        public string? KodeBuku { get; set; }

        // Function untuk calculate due date (7 hari dari tanggal pinjam)
        public void SetDueDate()
        {
            TanggalJatuhTempo = TanggalPinjam.AddDays(7);
        }

        // Polymorphism - Virtual method untuk menghitung denda
        public virtual decimal HitungDenda()
        {
            if (TanggalKembali == null || TanggalKembali <= TanggalJatuhTempo)
            {
                return 0;
            }

            // Hitung keterlambatan
            TimeSpan late = TanggalKembali.Value - TanggalJatuhTempo;
            int lateDays = (int)late.TotalDays;

            // Denda Rp 2.000 per hari
            decimal dendaPerHari = 2000;
            return lateDays * dendaPerHari;
        }

        // Function untuk cek apakah terlambat
        public bool IsLate()
        {
            if (TanggalKembali != null)
            {
                return TanggalKembali > TanggalJatuhTempo;
            }
            return DateTime.Now > TanggalJatuhTempo;
        }

        // Function untuk update status
        public void UpdateStatus()
        {
            if (TanggalKembali != null)
            {
                Status = IsLate() ? "Terlambat" : "Dikembalikan";
            }
            else if (DateTime.Now > TanggalJatuhTempo)
            {
                Status = "Terlambat";
            }
            else
            {
                Status = "Dipinjam";
            }
        }

        // Override ToString untuk display
        public override string ToString()
        {
            return $"{KodePeminjaman} - {JudulBuku} ({Status})";
        }
    }

    // Derived class untuk demonstrasi Polymorphism
    public class SpecialBorrowing : Borrowing
    {
        public bool IsPremiumMember { get; set; }

        // Override method HitungDenda - premium member dapat diskon 50%
        public override decimal HitungDenda()
        {
            decimal normalFine = base.HitungDenda();
            if (IsPremiumMember)
            {
                return normalFine * 0.5m; // Diskon 50%
            }
            return normalFine;
        }
    }
}
