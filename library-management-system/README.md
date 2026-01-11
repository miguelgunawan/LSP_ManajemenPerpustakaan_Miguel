# Library Management System

Aplikasi manajemen perpustakaan berbasis C# WinForms dengan fitur lengkap untuk mengelola buku, anggota, peminjaman, dan pengembalian.

## 🚀 Fitur Utama

- ✅ **CRUD Buku** - Kelola data buku (Kode, Judul, Penulis, Penerbit, Stok)
- ✅ **CRUD Anggota** - Kelola data anggota perpustakaan
- ✅ **Peminjaman Buku** - Proses peminjaman dengan auto calculate jatuh tempo (7 hari)
- ✅ **Pengembalian Buku** - Proses pengembalian dengan perhitungan denda otomatis (Rp 2.000/hari)
- ✅ **Riwayat & Laporan** - Lihat riwayat peminjaman lengkap
- ✅ **Export Data** - Export ke format TXT dan CSV

## 🎯 Konsep yang Diterapkan

### Object-Oriented Programming (OOP)
- **Class**: `Book`, `Member`, `Borrowing`, `User`, `Petugas`
- **Encapsulation**: Properties dengan getter/setter
- **Method**: Functions dan Procedures dalam setiap class

### Inheritance (Pewarisan)
- Base class: `User` (abstract)
- Derived classes: `Petugas`, `Admin`
- Implementasi method override

### Polymorphism
- Virtual method: `HitungDenda()` di class `Borrowing`
- Override method di derived class `SpecialBorrowing`
- Abstract method: `GetRole()`, `ValidateAccess()`

### Database Management
- SQL Server dengan connection pooling
- CRUD operations dengan stored procedures
- Transaction handling
- Indexes untuk performance

### File I/O
- Export data ke TXT format
- Export data ke CSV format
- Generate laporan otomatis

### Data Structures
- Array dan List<T> untuk manajemen koleksi
- Sorting data (by date, name, code)
- Searching dan filtering

### Prosedur & Function
- Procedure untuk operasi database (INSERT, UPDATE, DELETE)
- Function untuk kalkulasi (denda, stok, validasi)
- Helper methods untuk reusable code

## 📋 Prasyarat

- Windows OS (Windows 10/11 recommended)
- .NET 6.0 SDK atau lebih baru
- SQL Server 2019 atau lebih baru (Express Edition sudah cukup)
- Visual Studio 2022 (Community Edition)

## 🛠️ Instalasi

### 1. Install SQL Server

Jika belum memiliki SQL Server:

```bash
# Download SQL Server Express dari:
https://www.microsoft.com/en-us/sql-server/sql-server-downloads

# Atau install menggunakan winget:
winget install Microsoft.SQLServer.2022.Express
```

### 2. Setup Database

```bash
# 1. Buka SQL Server Management Studio (SSMS) atau Azure Data Studio
# 2. Connect ke SQL Server (localhost)
# 3. Open file: Database/SetupDatabase.sql
# 4. Execute script (F5)
```

Database akan otomatis dibuat dengan nama `LibraryManagementDB` lengkap dengan sample data.

### 3. Build dan Run Aplikasi

#### Menggunakan Visual Studio:

```bash
# 1. Open LibraryManagementSystem.sln
# 2. Restore NuGet packages (otomatis)
# 3. Build Solution (Ctrl+Shift+B)
# 4. Run (F5)
```

#### Menggunakan Command Line:

```bash
cd LibraryManagementSystem
dotnet restore
dotnet build
dotnet run --project LibraryManagementSystem
```

## 📁 Struktur Project

```
LibraryManagementSystem/
├── Database/
│   └── SetupDatabase.sql          # SQL script untuk setup database
├── LibraryManagementSystem/
│   ├── Models/                    # Domain models (OOP)
│   │   ├── Book.cs
│   │   ├── Member.cs
│   │   ├── Borrowing.cs
│   │   └── User.cs                # Base class (Inheritance)
│   ├── Data/                      # Data access layer
│   │   ├── DatabaseHelper.cs      # Database connection & helpers
│   │   ├── BookRepository.cs
│   │   ├── MemberRepository.cs
│   │   └── BorrowingRepository.cs
│   ├── Forms/                     # WinForms UI
│   │   ├── MainForm.cs            # Main menu
│   │   ├── BookForm.cs            # CRUD Buku
│   │   ├── MemberForm.cs          # CRUD Anggota
│   │   ├── BorrowingForm.cs       # Peminjaman
│   │   ├── ReturnForm.cs          # Pengembalian
│   │   └── HistoryForm.cs         # Riwayat & Export
│   ├── Utils/                     # Utility classes
│   │   └── FileExporter.cs        # File I/O operations
│   ├── Program.cs                 # Entry point
│   ├── App.config                 # Configuration
│   └── LibraryManagementSystem.csproj
└── LibraryManagementSystem.sln
```

## 🎨 Screenshot & Fitur

### Main Menu
- Dashboard utama dengan navigasi ke semua modul
- Tampilan modern dengan color-coded buttons

### Manajemen Buku
- Tambah, Edit, Hapus buku
- Search & Filter
- Validation lengkap
- Auto-save dengan error handling

### Manajemen Anggota
- CRUD Anggota lengkap
- Status aktif/non-aktif
- Validasi input

### Peminjaman
- Pilih anggota dan buku
- Auto calculate due date (7 hari dari tanggal pinjam)
- Update stok otomatis
- Validasi stok tersedia

### Pengembalian
- List peminjaman aktif
- Perhitungan denda otomatis (Rp 2.000/hari)
- Polymorphism dalam perhitungan denda
- Update stok otomatis

### Riwayat & Laporan
- View semua transaksi
- Filter by status
- Export ke TXT/CSV
- Generate laporan statistik

## 🔧 Konfigurasi

### Connection String

Edit di `App.config` jika perlu:

```xml
<connectionStrings>
  <add name="LibraryDB" 
       connectionString="Server=localhost;Database=LibraryManagementDB;Integrated Security=true;TrustServerCertificate=true;" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

Ubah `Server=localhost` sesuai SQL Server instance Anda.

## 📝 Cara Penggunaan

### 1. Kelola Buku
1. Klik "📚 KELOLA BUKU"
2. Isi form data buku
3. Klik "➕ Tambah" untuk menambah buku baru
4. Klik row di tabel untuk edit/hapus
5. Gunakan search untuk mencari buku

### 2. Kelola Anggota
1. Klik "👥 KELOLA ANGGOTA"
2. Isi form data anggota
3. Centang "Aktif" untuk anggota aktif
4. Klik "➕ Tambah" untuk menambah anggota

### 3. Peminjaman Buku
1. Klik "📖 PEMINJAMAN"
2. Pilih anggota dari dropdown
3. Pilih buku yang akan dipinjam
4. Tanggal pinjam otomatis hari ini
5. Jatuh tempo otomatis 7 hari dari tanggal pinjam
6. Klik "💾 Simpan Peminjaman"

### 4. Pengembalian Buku
1. Klik "↩️ PENGEMBALIAN"
2. Pilih peminjaman dari list
3. Sistem akan auto-calculate denda jika terlambat
4. Klik "✅ Proses Pengembalian"

### 5. Riwayat & Export
1. Klik "📋 RIWAYAT & LAPORAN"
2. Lihat semua transaksi
3. Filter by status jika perlu
4. Klik "📄 Export TXT" atau "📊 Export CSV"

## 🐛 Debugging & Troubleshooting

### Database Connection Error

**Problem**: "Cannot connect to database"

**Solution**:
1. Pastikan SQL Server sedang berjalan:
   ```bash
   # Check SQL Server service status
   Get-Service MSSQLSERVER
   ```
2. Verify connection string di App.config
3. Test connection menggunakan SSMS

### Database Not Found

**Problem**: "Database 'LibraryManagementDB' does not exist"

**Solution**:
1. Run `Database/SetupDatabase.sql` script
2. Atau jalankan aplikasi sekali (akan auto-create database)

### Build Errors

**Problem**: Package restore errors

**Solution**:
```bash
dotnet restore
dotnet clean
dotnet build
```

## 📊 Unit Testing

Aplikasi sudah include validasi di setiap operasi:

- Input validation
- Business logic validation
- Database constraint validation
- Try-catch error handling
- User-friendly error messages

## 🔐 Security Features

- SQL Injection prevention (Parameterized queries)
- Input sanitization
- Data validation
- Error handling yang aman

## 📈 Performance Optimization

- Database indexes pada kolom yang sering di-search
- Connection pooling
- Efficient LINQ queries
- Lazy loading untuk data besar

## 🎓 Learning Resources

Aplikasi ini merupakan implementasi dari konsep:
- OOP (Encapsulation, Inheritance, Polymorphism)
- Database Management
- File I/O Operations
- Data Structures (Array, List, Sorting)
- Error Handling & Debugging
- UI/UX Design

## 👨‍💻 Developer Notes

### Code Style
- Pascal Case untuk class dan method names
- Camel Case untuk parameters dan local variables
- Descriptive naming conventions
- XML comments untuk dokumentasi

### Best Practices Applied
- Repository pattern untuk data access
- Separation of concerns
- DRY (Don't Repeat Yourself)
- Single Responsibility Principle
- Error handling di semua layer

## 📄 License

Project ini dibuat untuk tujuan edukasi dan portfolio.

## 💬 Support

Jika ada pertanyaan atau issue:
1. Check documentation terlebih dahulu
2. Verify database setup
3. Check error messages di MessageBox

## 🔄 Version History

### Version 1.0.0 (Current)
- ✅ Complete CRUD operations
- ✅ Borrowing & Return system
- ✅ Auto fine calculation
- ✅ Export to TXT/CSV
- ✅ Full validation
- ✅ Error handling
- ✅ Sample data included
- ✅ Modern UI design

## 🎯 Future Enhancements (Optional)

- [ ] Login system dengan User authentication
- [ ] Barcode scanning untuk buku
- [ ] Email notification untuk jatuh tempo
- [ ] Dashboard dengan charts
- [ ] Backup & Restore database
- [ ] Multi-language support
- [ ] Print receipts
- [ ] Advanced reporting

## ✅ Testing Checklist

Sebelum demo/presentasi, pastikan:

- [x] Database sudah di-setup dengan benar
- [x] Sample data sudah ter-load
- [x] Semua form bisa dibuka tanpa error
- [x] CRUD operations berfungsi sempurna
- [x] Peminjaman bisa diproses
- [x] Pengembalian dengan denda bekerja
- [x] Export TXT/CSV berfungsi
- [x] Validasi input bekerja dengan baik
- [x] Error handling menampilkan pesan yang jelas
- [x] UI tampil rapi dan profesional

---

**Dibuat dengan ❤️ menggunakan C# WinForms**

**© 2026 Library Management System**
