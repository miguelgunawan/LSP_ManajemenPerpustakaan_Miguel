namespace LibraryManagementSystem.Models
{
    // Base class untuk implementasi Inheritance
    public abstract class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        // Method abstract untuk Polymorphism
        public abstract string GetRole();
        public abstract bool ValidateAccess(string feature);
    }

    // Derived class - implementasi Inheritance
    public class Petugas : User
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        // Override method untuk Polymorphism
        public override string GetRole()
        {
            return "Petugas Perpustakaan";
        }

        public override bool ValidateAccess(string feature)
        {
            // Petugas punya akses penuh
            return true;
        }

        public string GetEmployeeInfo()
        {
            return $"{EmployeeId} - {FullName} ({Position})";
        }
    }

    // Derived class lain untuk demonstrasi Polymorphism
    public class Admin : User
    {
        public string AdminLevel { get; set; } = "Super";

        public override string GetRole()
        {
            return "Administrator";
        }

        public override bool ValidateAccess(string feature)
        {
            // Admin punya akses ke semua fitur
            return true;
        }
    }
}
