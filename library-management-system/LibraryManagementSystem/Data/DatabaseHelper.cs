using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace LibraryManagementSystem.Data
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"]?.ConnectionString 
                    ?? "Server=localhost;Database=LibraryManagementDB;Uid=root;Pwd=;";
            }
            catch
            {
                connectionString = "Server=localhost;Database=LibraryManagementDB;Uid=root;Pwd=;";
            }
        }

        // Function untuk mendapatkan connection
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Function untuk test connection
        public bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Procedure untuk execute non-query (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, MySqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing query: {ex.Message}", ex);
            }
        }

        // Function untuk execute scalar (COUNT, MAX, dll)
        public object? ExecuteScalar(string query, MySqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing scalar: {ex.Message}", ex);
            }
        }

        // Function untuk execute reader (SELECT)
        public DataTable ExecuteQuery(string query, MySqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing query: {ex.Message}", ex);
            }
        }

        // Procedure untuk create database jika belum ada
        public void EnsureDatabaseExists()
        {
            try
            {
                // Connection ke server MySQL (gunakan database information_schema untuk cek)
                string masterConnString = "Server=localhost;Uid=root;Pwd=;";
                
                using (var conn = new MySqlConnection(masterConnString))
                {
                    conn.Open();
                    
                    // Check apakah database sudah ada
                    string checkDbQuery = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LibraryManagementDB'";
                    using (var cmd = new MySqlCommand(checkDbQuery, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        
                        if (result == null)
                        {
                            // Create database
                            string createDbQuery = "CREATE DATABASE LibraryManagementDB";
                            using (var createCmd = new MySqlCommand(createDbQuery, conn))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ensuring database exists: {ex.Message}", ex);
            }
        }
    }
}
