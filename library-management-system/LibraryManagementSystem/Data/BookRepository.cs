using System.Data;
using MySql.Data.MySqlClient;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class BookRepository
    {
        private readonly DatabaseHelper db;

        public BookRepository()
        {
            db = new DatabaseHelper();
        }

        // CREATE - Tambah buku baru
        public bool AddBook(Book book)
        {
            try
            {
                string query = @"INSERT INTO t_Buku (KodeBuku, Judul, Penulis, Penerbit, TahunTerbit, Kategori, Stok, StokTersedia, TanggalInput)
                                VALUES (@KodeBuku, @Judul, @Penulis, @Penerbit, @TahunTerbit, @Kategori, @Stok, @StokTersedia, @TanggalInput)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@KodeBuku", book.KodeBuku),
                    new MySqlParameter("@Judul", book.Judul),
                    new MySqlParameter("@Penulis", book.Penulis),
                    new MySqlParameter("@Penerbit", book.Penerbit),
                    new MySqlParameter("@TahunTerbit", book.TahunTerbit),
                    new MySqlParameter("@Kategori", book.Kategori),
                    new MySqlParameter("@Stok", book.Stok),
                    new MySqlParameter("@StokTersedia", book.StokTersedia),
                    new MySqlParameter("@TanggalInput", DateTime.Now)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // READ - Ambil semua buku
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            try
            {
                string query = "SELECT * FROM t_Buku ORDER BY Judul";
                DataTable dt = db.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    books.Add(MapToBook(row));
                }
            }
            catch { }

            return books;
        }

        // READ - Ambil buku by ID
        public Book? GetBookById(int bookId)
        {
            try
            {
                string query = "SELECT * FROM t_Buku WHERE IdBuku = @IdBuku";
                MySqlParameter[] parameters = { new MySqlParameter("@IdBuku", bookId) };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return MapToBook(dt.Rows[0]);
                }
            }
            catch { }

            return null;
        }

        // READ - Search buku
        public List<Book> SearchBooks(string keyword)
        {
            var books = new List<Book>();
            try
            {
                string query = @"SELECT * FROM t_Buku 
                               WHERE KodeBuku LIKE @Keyword 
                               OR Judul LIKE @Keyword 
                               OR Penulis LIKE @Keyword 
                               ORDER BY Judul";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@Keyword", $"%{keyword}%")
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    books.Add(MapToBook(row));
                }
            }
            catch { }

            return books;
        }

        // UPDATE - Update buku
        public bool UpdateBook(Book book)
        {
            try
            {
                string query = @"UPDATE t_Buku SET 
                               KodeBuku = @KodeBuku,
                               Judul = @Judul,
                               Penulis = @Penulis,
                               Penerbit = @Penerbit,
                               TahunTerbit = @TahunTerbit,
                               Kategori = @Kategori,
                               Stok = @Stok,
                               StokTersedia = @StokTersedia
                               WHERE IdBuku = @IdBuku";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@IdBuku", book.IdBuku),
                    new MySqlParameter("@KodeBuku", book.KodeBuku),
                    new MySqlParameter("@Judul", book.Judul),
                    new MySqlParameter("@Penulis", book.Penulis),
                    new MySqlParameter("@Penerbit", book.Penerbit),
                    new MySqlParameter("@TahunTerbit", book.TahunTerbit),
                    new MySqlParameter("@Kategori", book.Kategori),
                    new MySqlParameter("@Stok", book.Stok),
                    new MySqlParameter("@StokTersedia", book.StokTersedia)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // DELETE - Hapus buku
        public bool DeleteBook(int bookId)
        {
            try
            {
                string query = "DELETE FROM t_Buku WHERE IdBuku = @IdBuku";
                MySqlParameter[] parameters = { new MySqlParameter("@IdBuku", bookId) };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // UPDATE - Update stok buku
        public bool UpdateStock(int bookId, int availableStock)
        {
            try
            {
                string query = "UPDATE t_Buku SET StokTersedia = @StokTersedia WHERE IdBuku = @IdBuku";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@IdBuku", bookId),
                    new MySqlParameter("@StokTersedia", availableStock)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // Helper method untuk mapping DataRow ke Book object
        private Book MapToBook(DataRow row)
        {
            return new Book
            {
                IdBuku = Convert.ToInt32(row["IdBuku"]),
                KodeBuku = row["KodeBuku"].ToString() ?? "",
                Judul = row["Judul"].ToString() ?? "",
                Penulis = row["Penulis"].ToString() ?? "",
                Penerbit = row["Penerbit"].ToString() ?? "",
                TahunTerbit = Convert.ToInt32(row["TahunTerbit"]),
                Kategori = row["Kategori"].ToString() ?? "",
                Stok = Convert.ToInt32(row["Stok"]),
                StokTersedia = Convert.ToInt32(row["StokTersedia"]),
                TanggalInput = Convert.ToDateTime(row["TanggalInput"])
            };
        }
    }
}
