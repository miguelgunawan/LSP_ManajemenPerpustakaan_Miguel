namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int IdAnggota { get; set; }
        public string KodeAnggota { get; set; } = string.Empty;
        public string NamaLengkap { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public string NoTelepon { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime TanggalBergabung { get; set; }
        public bool Aktif { get; set; }

        // Function untuk validasi member aktif
        public bool CanBorrow()
        {
            return Aktif;
        }

        // Function untuk mendapatkan info lengkap
        public string GetFullInfo()
        {
            string status = Aktif ? "Aktif" : "Tidak Aktif";
            return $"[{KodeAnggota}] {NamaLengkap}\nTelp: {NoTelepon}\nStatus: {status}";
        }

        // Override ToString untuk display
        public override string ToString()
        {
            return $"{KodeAnggota} - {NamaLengkap}";
        }
    }
}
