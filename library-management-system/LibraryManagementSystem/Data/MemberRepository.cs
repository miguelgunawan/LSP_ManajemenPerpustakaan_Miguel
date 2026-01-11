using System.Data;
using MySql.Data.MySqlClient;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class MemberRepository
    {
        private readonly DatabaseHelper db;

        public MemberRepository()
        {
            db = new DatabaseHelper();
        }

        // CREATE - Tambah anggota baru
        public bool AddMember(Member member)
        {
            try
            {
                string query = @"INSERT INTO t_Anggota (KodeAnggota, NamaLengkap, Alamat, NoTelepon, Email, TanggalBergabung, Aktif)
                                VALUES (@KodeAnggota, @NamaLengkap, @Alamat, @NoTelepon, @Email, @TanggalBergabung, @Aktif)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@KodeAnggota", member.KodeAnggota),
                    new MySqlParameter("@NamaLengkap", member.NamaLengkap),
                    new MySqlParameter("@Alamat", member.Alamat),
                    new MySqlParameter("@NoTelepon", member.NoTelepon),
                    new MySqlParameter("@Email", member.Email),
                    new MySqlParameter("@TanggalBergabung", DateTime.Now),
                    new MySqlParameter("@Aktif", member.Aktif)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // READ - Ambil semua anggota
        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            try
            {
                string query = "SELECT * FROM t_Anggota ORDER BY NamaLengkap";
                DataTable dt = db.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    members.Add(MapToMember(row));
                }
            }
            catch { }

            return members;
        }

        // READ - Ambil anggota by ID
        public Member? GetMemberById(int memberId)
        {
            try
            {
                string query = "SELECT * FROM t_Anggota WHERE IdAnggota = @IdAnggota";
                MySqlParameter[] parameters = { new MySqlParameter("@IdAnggota", memberId) };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return MapToMember(dt.Rows[0]);
                }
            }
            catch { }

            return null;
        }

        // READ - Search anggota
        public List<Member> SearchMembers(string keyword)
        {
            var members = new List<Member>();
            try
            {
                string query = @"SELECT * FROM t_Anggota 
                               WHERE KodeAnggota LIKE @Keyword 
                               OR NamaLengkap LIKE @Keyword 
                               OR NoTelepon LIKE @Keyword 
                               ORDER BY NamaLengkap";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@Keyword", $"%{keyword}%")
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    members.Add(MapToMember(row));
                }
            }
            catch { }

            return members;
        }

        // READ - Ambil anggota aktif saja
        public List<Member> GetActiveMembers()
        {
            var members = new List<Member>();
            try
            {
                string query = "SELECT * FROM t_Anggota WHERE Aktif = 1 ORDER BY NamaLengkap";
                DataTable dt = db.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    members.Add(MapToMember(row));
                }
            }
            catch { }

            return members;
        }

        // UPDATE - Update anggota
        public bool UpdateMember(Member member)
        {
            try
            {
                string query = @"UPDATE t_Anggota SET 
                               KodeAnggota = @KodeAnggota,
                               NamaLengkap = @NamaLengkap,
                               Alamat = @Alamat,
                               NoTelepon = @NoTelepon,
                               Email = @Email,
                               Aktif = @Aktif
                               WHERE IdAnggota = @IdAnggota";

                MySqlParameter[] parameters = { new MySqlParameter("@IdAnggota", member.IdAnggota),
                    new MySqlParameter("@KodeAnggota", member.KodeAnggota),
                    new MySqlParameter("@NamaLengkap", member.NamaLengkap),
                    new MySqlParameter("@Alamat", member.Alamat),
                    new MySqlParameter("@NoTelepon", member.NoTelepon),
                    new MySqlParameter("@Email", member.Email),
                    new MySqlParameter("@Aktif", member.Aktif)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // DELETE - Hapus anggota
        public bool DeleteMember(int memberId)
        {
            try
            {
                string query = "DELETE FROM t_Anggota WHERE IdAnggota = @IdAnggota";
                MySqlParameter[] parameters = { new MySqlParameter("@IdAnggota", memberId) };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // Helper method untuk mapping DataRow ke Member object
        private Member MapToMember(DataRow row)
        {
            return new Member
            {
                IdAnggota = Convert.ToInt32(row["IdAnggota"]),
                KodeAnggota = row["KodeAnggota"].ToString() ?? "",
                NamaLengkap = row["NamaLengkap"].ToString() ?? "",
                Alamat = row["Alamat"].ToString() ?? "",
                NoTelepon = row["NoTelepon"].ToString() ?? "",
                Email = row["Email"].ToString() ?? "",
                TanggalBergabung = Convert.ToDateTime(row["TanggalBergabung"]),
                Aktif = Convert.ToBoolean(row["Aktif"])
            };
        }
    }
}
