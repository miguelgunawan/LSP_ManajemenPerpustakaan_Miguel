using System.Data;
using MySql.Data.MySqlClient;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class BorrowingRepository
    {
        private readonly DatabaseHelper db;

        public BorrowingRepository()
        {
            db = new DatabaseHelper();
        }

        // CREATE - Tambah peminjaman baru
        public bool AddBorrowing(Borrowing borrowing)
        {
            try
            {
                string query = @"INSERT INTO t_Peminjaman (KodePeminjaman, IdAnggota, IdBuku, TanggalPinjam, TanggalJatuhTempo, Status)
                                VALUES (@KodePeminjaman, @IdAnggota, @IdBuku, @TanggalPinjam, @TanggalJatuhTempo, @Status)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@KodePeminjaman", borrowing.KodePeminjaman),
                    new MySqlParameter("@IdAnggota", borrowing.IdAnggota),
                    new MySqlParameter("@IdBuku", borrowing.IdBuku),
                    new MySqlParameter("@TanggalPinjam", borrowing.TanggalPinjam),
                    new MySqlParameter("@TanggalJatuhTempo", borrowing.TanggalJatuhTempo),
                    new MySqlParameter("@Status", borrowing.Status)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // READ - Ambil semua peminjaman
        public List<Borrowing> GetAllBorrowings()
        {
            var borrowings = new List<Borrowing>();
            try
            {
                string query = @"SELECT b.*, m.NamaLengkap as NamaAnggota, bk.Judul as JudulBuku, bk.KodeBuku
                               FROM t_Peminjaman b
                               INNER JOIN t_Anggota m ON b.IdAnggota = m.IdAnggota
                               INNER JOIN t_Buku bk ON b.IdBuku = bk.IdBuku
                               ORDER BY b.TanggalPinjam DESC";
                
                DataTable dt = db.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    borrowings.Add(MapToBorrowing(row));
                }
            }
            catch { }

            return borrowings;
        }

        // READ - Ambil peminjaman aktif (belum dikembalikan)
        public List<Borrowing> GetActiveBorrowings()
        {
            var borrowings = new List<Borrowing>();
            try
            {
                string query = @"SELECT b.*, m.NamaLengkap as NamaAnggota, bk.Judul as JudulBuku, bk.KodeBuku
                               FROM t_Peminjaman b
                               INNER JOIN t_Anggota m ON b.IdAnggota = m.IdAnggota
                               INNER JOIN t_Buku bk ON b.IdBuku = bk.IdBuku
                               WHERE b.TanggalKembali IS NULL
                               ORDER BY b.TanggalJatuhTempo";
                
                DataTable dt = db.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    borrowings.Add(MapToBorrowing(row));
                }
            }
            catch { }

            return borrowings;
        }

        // READ - Ambil peminjaman by member
        public List<Borrowing> GetBorrowingsByMember(int memberId)
        {
            var borrowings = new List<Borrowing>();
            try
            {
                string query = @"SELECT b.*, m.NamaLengkap as NamaAnggota, bk.Judul as JudulBuku, bk.KodeBuku
                               FROM t_Peminjaman b
                               INNER JOIN t_Anggota m ON b.IdAnggota = m.IdAnggota
                               INNER JOIN t_Buku bk ON b.IdBuku = bk.IdBuku
                               WHERE b.IdAnggota = @IdAnggota
                               ORDER BY b.TanggalPinjam DESC";

                MySqlParameter[] parameters = { new MySqlParameter("@IdAnggota", memberId) };
                DataTable dt = db.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    borrowings.Add(MapToBorrowing(row));
                }
            }
            catch { }

            return borrowings;
        }

        // READ - Search peminjaman
        public List<Borrowing> SearchBorrowings(string keyword)
        {
            var borrowings = new List<Borrowing>();
            try
            {
                string query = @"SELECT b.*, m.NamaLengkap as NamaAnggota, bk.Judul as JudulBuku, bk.KodeBuku
                               FROM t_Peminjaman b
                               INNER JOIN t_Anggota m ON b.IdAnggota = m.IdAnggota
                               INNER JOIN t_Buku bk ON b.IdBuku = bk.IdBuku
                               WHERE b.KodePeminjaman LIKE @Keyword 
                               OR m.NamaLengkap LIKE @Keyword
                               OR bk.Judul LIKE @Keyword
                               ORDER BY b.TanggalPinjam DESC";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@Keyword", $"%{keyword}%")
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    borrowings.Add(MapToBorrowing(row));
                }
            }
            catch { }

            return borrowings;
        }

        // UPDATE - Pengembalian buku
        public bool ReturnBook(int borrowingId, DateTime returnDate, decimal fine)
        {
            try
            {
                string query = @"UPDATE t_Peminjaman SET 
                               TanggalKembali = @TanggalKembali,
                               Denda = @Denda,
                               Status = @Status
                               WHERE IdPeminjaman = @IdPeminjaman";

                // Tentukan status
                string status = fine > 0 ? "Terlambat" : "Dikembalikan";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@IdPeminjaman", borrowingId),
                    new MySqlParameter("@TanggalKembali", returnDate),
                    new MySqlParameter("@Denda", fine),
                    new MySqlParameter("@Status", status)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // Function untuk generate borrowing code
        public string GenerateBorrowingCode()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM t_Peminjaman";
                object? result = db.ExecuteScalar(query);
                int count = result != null ? Convert.ToInt32(result) : 0;
                
                return $"BRW{DateTime.Now:yyyyMMdd}{(count + 1):D4}";
            }
            catch
            {
                return $"BRW{DateTime.Now:yyyyMMddHHmmss}";
            }
        }

        // Helper method untuk mapping DataRow ke Borrowing object
        private Borrowing MapToBorrowing(DataRow row)
        {
            var borrowing = new Borrowing
            {
                IdPeminjaman = Convert.ToInt32(row["IdPeminjaman"]),
                KodePeminjaman = row["KodePeminjaman"].ToString() ?? "",
                IdAnggota = Convert.ToInt32(row["IdAnggota"]),
                IdBuku = Convert.ToInt32(row["IdBuku"]),
                TanggalPinjam = Convert.ToDateTime(row["TanggalPinjam"]),
                TanggalJatuhTempo = Convert.ToDateTime(row["TanggalJatuhTempo"]),
                TanggalKembali = row["TanggalKembali"] != DBNull.Value ? Convert.ToDateTime(row["TanggalKembali"]) : null,
                Denda = row["Denda"] != DBNull.Value ? Convert.ToDecimal(row["Denda"]) : 0,
                Status = row["Status"].ToString() ?? "Dipinjam",
                NamaAnggota = row["NamaAnggota"].ToString(),
                JudulBuku = row["JudulBuku"].ToString(),
                KodeBuku = row["KodeBuku"].ToString()
            };

            return borrowing;
        }
    }
}
