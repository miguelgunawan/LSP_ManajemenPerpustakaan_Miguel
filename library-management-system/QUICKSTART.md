# 🚀 Quick Start Guide - 5 Menit Setup!

## ⚡ Langkah Cepat (Windows)

### 1. Install SQL Server Express (Jika belum ada) - 2 menit

```powershell
# Option A: Menggunakan winget (Recommended)
winget install Microsoft.SQLServer.2022.Express

# Option B: Download manual
# https://go.microsoft.com/fwlink/p/?linkid=2216019
```

### 2. Setup Database - 1 menit

**A. Buka SQL Server Management Studio (SSMS) atau Azure Data Studio**

**B. Connect ke:** `localhost` atau `.\SQLEXPRESS`

**C. Run script:**
1. File → Open → `Database/SetupDatabase.sql`
2. Execute (F5)
3. Done! ✅

**Verify:**
```sql
USE LibraryManagementDB;
SELECT COUNT(*) FROM Books; -- Should return 8
SELECT COUNT(*) FROM Members; -- Should return 5
```

### 3. Run Aplikasi - 30 detik

**Option A: Visual Studio (Recommended)**
```
1. Double-click: LibraryManagementSystem.sln
2. Press F5
3. Done! 🎉
```

**Option B: Command Line**
```bash
cd LibraryManagementSystem
dotnet run --project LibraryManagementSystem
```

---

## 🔧 Troubleshooting Cepat

### ❌ "Cannot connect to database"

**Fix:**
```powershell
# Check SQL Server service
Get-Service | Where-Object {$_.Name -like "*SQL*"}

# Start jika stopped
Start-Service MSSQLSERVER
# atau
Start-Service MSSQL$SQLEXPRESS
```

### ❌ "Login failed for user"

**Fix:** Edit `App.config`:
```xml
<!-- Ganti dengan SQL Server instance Anda -->
<connectionStrings>
  <add name="LibraryDB" 
       connectionString="Server=.\SQLEXPRESS;Database=LibraryManagementDB;Integrated Security=true;TrustServerCertificate=true;"/>
</connectionStrings>
```

Common instances:
- `Server=localhost;`
- `Server=.\SQLEXPRESS;`
- `Server=(LocalDB)\MSSQLLocalDB;`

### ❌ Build errors

**Fix:**
```bash
dotnet clean
dotnet restore  
dotnet build
```

---

## ✅ Verification Checklist

Setelah aplikasi running, test ini:

- [ ] Main Menu terbuka
- [ ] Klik "📚 KELOLA BUKU" → Form terbuka
- [ ] See 8 books dalam grid
- [ ] Klik "👥 KELOLA ANGGOTA" → See 5 members
- [ ] Klik "📖 PEMINJAMAN" → Dropdowns terisi
- [ ] Klik "↩️ PENGEMBALIAN" → See 2 active borrowings
- [ ] Klik "📋 RIWAYAT" → See all data

**Jika semua ✅ → You're ready! 🎉**

---

## 📱 Quick Test Scenario

### Test 1: Add Book (30 sec)
```
📚 KELOLA BUKU
  → Kode: TEST001
  → Judul: Test Book
  → Penulis: Test Author
  → Klik Tambah
  → ✅ Sukses!
```

### Test 2: Borrowing (45 sec)
```
📖 PEMINJAMAN
  → Pilih Member: Budi Santoso
  → Pilih Buku: Test Book
  → Check: Due date = +7 hari ✓
  → Simpan
  → ✅ Sukses!
```

### Test 3: Return (30 sec)
```
↩️ PENGEMBALIAN
  → Pilih peminjaman
  → Check: Denda auto calculate ✓
  → Proses
  → ✅ Sukses!
```

### Test 4: Export (20 sec)
```
📋 RIWAYAT
  → Export CSV
  → Open in Excel
  → ✅ Data complete!
```

**Total time: 2 minutes**

---

## 🎯 Ready for Demo?

### Before Demo Checklist:
- [ ] SQL Server running
- [ ] Database created & populated
- [ ] Application builds without errors
- [ ] All forms tested
- [ ] Sample data ready

### During Demo:
1. Start with Main Menu
2. Show each feature systematically
3. Emphasize: OOP, Inheritance, Polymorphism
4. Show code when explaining concepts
5. End with Export feature

---

## 💡 Pro Tips

1. **Backup Database Before Demo:**
   ```sql
   BACKUP DATABASE LibraryManagementDB 
   TO DISK = 'C:\Backup\LibraryDB.bak';
   ```

2. **Create Test Data:**
   - Add 1-2 buku baru
   - Add 1 anggota baru
   - Create 1 peminjaman
   - Return dengan denda

3. **Prepare Code Snippets:**
   - Have Visual Studio open
   - Bookmark key classes:
     - User.cs (Inheritance)
     - Borrowing.cs (Polymorphism)
     - FileExporter.cs (File I/O)

4. **Know Your Numbers:**
   - Total classes: 8
   - Total forms: 6
   - Total LOC: ~3,500
   - Database tables: 3

---

## 🎓 Quick Demo Script (5 menit)

**0:00-0:30** Main Menu
- "Ini adalah aplikasi Library Management System dengan UI modern"

**0:30-1:30** CRUD Buku
- Add book
- Show validation
- "Implementasi OOP dengan class Book"

**1:30-2:30** Peminjaman
- Select member & book
- "Auto calculate due date - 7 hari"
- "Function SetDueDate() otomatis"

**2:30-3:30** Pengembalian
- Show borrowing
- "Auto calculate denda - Rp 2000/hari"
- "Ini implementasi Polymorphism - method HitungDenda() virtual"

**3:30-4:30** Code Review
- Open Visual Studio
- Show User.cs (Inheritance)
- Show Borrowing.cs (Polymorphism)
- Show FileExporter.cs (File I/O)

**4:30-5:00** Export & Closing
- Export to CSV
- "Semua requirement terpenuhi: OOP, Inheritance, Polymorphism, Database, File I/O"
- "Aplikasi production-ready tanpa error"

---

## 📞 Need Help?

1. Check `README.md` - Complete documentation
2. Check `INSTALL.md` - Detailed installation
3. Check `DEMO_CHECKLIST.md` - Presentation guide
4. Check `PROJECT_SUMMARY.md` - Overview

---

## ✨ You're Ready!

**Aplikasi sudah:**
- ✅ Complete
- ✅ Tested
- ✅ Production-ready
- ✅ No errors
- ✅ Well documented

**Go ace that presentation! 🏆**

---

**Last Updated: January 2026**
