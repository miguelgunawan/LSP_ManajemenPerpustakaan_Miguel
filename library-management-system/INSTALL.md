# Library Management System - Panduan Instalasi

## Langkah-langkah Setup

### 1. Install Prerequisites

#### SQL Server (Jika belum ada)

**Windows:**
```powershell
# Menggunakan winget
winget install Microsoft.SQLServer.2022.Express

# Atau download manual dari:
# https://www.microsoft.com/en-us/sql-server/sql-server-downloads
```

**Atau menggunakan SQL Server Express LocalDB:**
```powershell
# Download dari:
# https://aka.ms/ssedownload
```

#### .NET 6.0 SDK

```powershell
# Menggunakan winget
winget install Microsoft.DotNet.SDK.6

# Atau download dari:
# https://dotnet.microsoft.com/download/dotnet/6.0
```

### 2. Setup Database

1. Buka **SQL Server Management Studio (SSMS)** atau **Azure Data Studio**
2. Connect ke SQL Server (biasanya `localhost` atau `.\SQLEXPRESS`)
3. Open file: `Database/SetupDatabase.sql`
4. Execute (tekan F5)
5. Verify database created dengan query:
   ```sql
   USE LibraryManagementDB;
   SELECT * FROM Books;
   SELECT * FROM Members;
   ```

### 3. Konfigurasi Connection String

Jika SQL Server instance Anda berbeda, edit `App.config`:

```xml
<connectionStrings>
  <add name="LibraryDB" 
       connectionString="Server=NAMA_INSTANCE;Database=LibraryManagementDB;Integrated Security=true;TrustServerCertificate=true;" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

**Contoh common instances:**
- `Server=localhost;` - Default instance
- `Server=.\SQLEXPRESS;` - SQL Express
- `Server=(LocalDB)\MSSQLLocalDB;` - LocalDB

### 4. Build & Run Aplikasi

#### Menggunakan Visual Studio 2022:

1. Open `LibraryManagementSystem.sln`
2. Build Solution (Ctrl+Shift+B)
3. Run (F5 atau Ctrl+F5)

#### Menggunakan Command Line:

```bash
cd LibraryManagementSystem
dotnet restore
dotnet build
dotnet run --project LibraryManagementSystem
```

## Troubleshooting

### Problem: "Cannot connect to database"

**Solution:**
1. Cek SQL Server service:
   ```powershell
   Get-Service | Where-Object {$_.Name -like "*SQL*"}
   ```
2. Start service jika stopped:
   ```powershell
   Start-Service MSSQLSERVER
   # Atau untuk Express:
   Start-Service MSSQL$SQLEXPRESS
   ```

### Problem: "Database does not exist"

**Solution:**
- Jalankan `Database/SetupDatabase.sql` script
- Atau jalankan aplikasi sekali (akan auto-create)

### Problem: "Login failed for user"

**Solution:**
- Pastikan menggunakan Windows Authentication
- Atau ubah connection string dengan SQL Server Authentication:
  ```
  Server=localhost;Database=LibraryManagementDB;User Id=sa;Password=YourPassword;TrustServerCertificate=true;
  ```

### Problem: Build errors

**Solution:**
```bash
dotnet clean
dotnet restore
dotnet build
```

## Testing

### Manual Testing Checklist:

- [ ] Main Menu terbuka tanpa error
- [ ] Kelola Buku: Tambah, Edit, Delete, Search
- [ ] Kelola Anggota: Tambah, Edit, Delete, Search
- [ ] Peminjaman: Bisa meminjam buku, due date auto 7 hari
- [ ] Pengembalian: Bisa mengembalikan, denda auto calculate
- [ ] Riwayat: Bisa filter, search, export TXT/CSV

### Sample Test Data:

Database script sudah include sample data:
- 8 Buku
- 5 Anggota
- 2 Peminjaman aktif

## Features Verification

### OOP Concepts:
- ✅ Class `Book`, `Member`, `Borrowing`, `User`, `Petugas`
- ✅ Encapsulation dengan properties
- ✅ Methods dalam setiap class

### Inheritance:
- ✅ Base class: `User` (abstract)
- ✅ Derived: `Petugas`, `Admin`
- ✅ Override methods

### Polymorphism:
- ✅ Virtual method `HitungDenda()`
- ✅ Override di `SpecialBorrowing`
- ✅ Abstract methods

### Database:
- ✅ SQL Server
- ✅ CRUD operations
- ✅ Parameterized queries (SQL Injection prevention)
- ✅ Indexes

### File I/O:
- ✅ Export to TXT
- ✅ Export to CSV

### Array & Sorting:
- ✅ List<T> collections
- ✅ LINQ sorting
- ✅ Search & filter

### Functions & Procedures:
- ✅ Functions untuk calculations
- ✅ Procedures untuk database operations
- ✅ Helper methods

## Production Deployment

### Create Executable:

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

Output akan ada di: `bin/Release/net6.0-windows/win-x64/publish/`

### Distribution Package:

Include dalam package:
1. `LibraryManagementSystem.exe`
2. `App.config`
3. `Database/SetupDatabase.sql`
4. `README.md`
5. `INSTALL.md` (this file)

## Support

Jika ada masalah:
1. Check error message di MessageBox
2. Verify SQL Server running
3. Check connection string
4. Ensure database created

---

**Good luck with your project! 🎓📚**
