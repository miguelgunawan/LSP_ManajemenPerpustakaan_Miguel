# Library Management System

Aplikasi ini adalah aplikasi manajemen perpustakaan berbasis C# WinForms dengan menggunakan database MySQL. Aplikasi ini menyedakan berbagai fitur lengkap untuk mendukung manajemen perpustakaan.

## Fitur Utama

- ✅ **Kelola Buku** - Kelola data buku (Kode, Judul, Penulis, Penerbit, Tahun Terbit, Kategori, Stok, Stok Tersedia)
- ✅ **Kelola Anggota** - Kelola data anggota perpustakaan
- ✅ **Peminjaman Buku** - Proses peminjaman dengan auto calculate jatuh tempo (7 hari)
- ✅ **Pengembalian Buku** - Proses pengembalian dengan perhitungan denda otomatis (Rp 2.000/hari)
- ✅ **Riwayat & Laporan** - Lihat riwayat peminjaman lengkap

## Konsep yang Diterapkan

### Object-Oriented Programming (OOP)
- **Class di setiap form**: `Book`, `Member`, `Borrowing`
- **Method**: Functions dan Procedures dalam setiap class

### Encapsulation
- Membungkus fungsi dan data ke 1 class (contoh di form book.cs)
- get, set di form model 
### Abstraction 
- menyembunyikan detail rumit dan hanya menampilkan fungsi penting (bookRepo.AddBook(book);)

### Inheritance 
- class mewarisi class lain (public partial class BookForm : Form) mewarisi class form dari winform.

### Polymorphism 
Method namanya sama tapi perilakunya bisa berbeda tergantung class atau kondisi saat dipanggil
- Virtual method: `HitungDenda()` di class `Borrowing`
- Override method seperti protected override void Dispose(bool disposing)
- Semua aksi 'click' tetapi tergantung menangani apa
  private void btnAdd_Click(object sender, EventArgs e)
  private void btnUpdate_Click(object sender, EventArgs e)
  private void btnDelete_Click(object sender, EventArgs e)

### Database Management
- SQL Server 
- CRUD operations dengan stored procedures
- Transaction handling
- Indexes untuk performance

### Data Structures
- Array dan List<T> untuk manajemen koleksi

### Prosedur & Function
- Procedure untuk operasi database (INSERT, UPDATE, DELETE)
- Function untuk kalkulasi (denda, stok, validasi)
- Helper methods untuk reusable code

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
│   │   └── History.cs               
│   ├── Data/                     
│   │   ├── DatabaseHelper.cs      # Database connection & helpers
│   │   ├── BookRepository.cs
│   │   ├── MemberRepository.cs
│   │   └── BorrowingRepository.cs
│   ├── Forms/                     
│   │   ├── MainForm.cs            # Main menu
│   │   ├── BookForm.cs            # CRUD Buku
│   │   ├── MemberForm.cs          # CRUD Anggota
│   │   ├── BorrowingForm.cs       # Peminjaman
│   │   ├── ReturnForm.cs          # Pengembalian
│   │   └── HistoryForm.cs         # Riwayat & Export
│   ├── Program.cs                 # Entry point
│   ├── App.config                 # Configuration

```

## 🎨 Screenshot & Fitur

<img width="905" height="790" alt="image" src="https://github.com/user-attachments/assets/2f142e12-76fc-482a-a894-9ec98b1ab24b" />

### Main Form
- Dashboard utama dengan navigasi ke semua modul
- Tampilan modern dengan color-coded buttons


  
<img width="1364" height="867" alt="image" src="https://github.com/user-attachments/assets/8678accf-2e5f-4fcb-bb9f-f4597183e573" />

### Manajemen Buku
- Tambah, Edit, Hapus buku
- Tampilan DataGridView Katalog Buku
- Auto-save


  
<img width="1364" height="817" alt="image" src="https://github.com/user-attachments/assets/8fe5319c-d9d7-4ea0-b8bd-13c62e1b34c4" />

### Manajemen Anggota
- Tambah, Edit, Hapus Anggota lengkap
- Tampilan DataGridView Anggota
- Auto-save


<img width="809" height="632" alt="image" src="https://github.com/user-attachments/assets/e42b826b-ac19-41c5-978a-3882f6674d09" />

### Peminjaman
- Pilih anggota dan buku
- Auto calculate due date (7 hari dari tanggal pinjam)
- Update stok otomatis


<img width="1094" height="551" alt="image" src="https://github.com/user-attachments/assets/cac1dab2-e4c9-46d1-b2f6-5f91027bf131" />

### Pengembalian
- List peminjaman aktif
- Perhitungan denda otomatis (Rp 2.000/hari)
- Polymorphism dalam perhitungan denda
- Update stok otomatis


<img width="1363" height="842" alt="image" src="https://github.com/user-attachments/assets/860eb6fb-ead6-4a4e-91c1-f37540f0138c" />

### Riwayat & Laporan
- View semua riwayat buku yang sudah dikembalikan

## 📈 ER-Diagram
<img width="911" height="746" alt="ERD- LSP- Miguel drawio" src="https://github.com/user-attachments/assets/3119a1d2-f75b-468b-97ee-88b3eb5b24b9" />


## 🔐 SQl Schema
```Text
-- Create Books table
CREATE TABLE `t_Buku` (
  `IdBuku` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `KodeBuku` VARCHAR(50) NOT NULL UNIQUE,
  `Judul` VARCHAR(200) NOT NULL,
  `Penulis` VARCHAR(100) NOT NULL,
  `Penerbit` VARCHAR(100) NOT NULL,
  `TahunTerbit` INT NOT NULL,
  `Kategori` VARCHAR(50) NOT NULL,
  `Stok` INT NOT NULL DEFAULT 0,
  `StokTersedia` INT NOT NULL DEFAULT 0,
  `TanggalInput` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Create Members table
CREATE TABLE `t_Anggota` (
  `IdAnggota` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `KodeAnggota` VARCHAR(50) NOT NULL UNIQUE,
  `NamaLengkap` VARCHAR(100) NOT NULL,
  `Alamat` VARCHAR(255) NOT NULL,
  `NoTelepon` VARCHAR(20) NOT NULL,
  `Email` VARCHAR(100),
  `TanggalBergabung` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Aktif` TINYINT(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Create Borrowings table
CREATE TABLE `t_Peminjaman` (
  `IdPeminjaman` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `KodePeminjaman` VARCHAR(50) NOT NULL UNIQUE,
  `IdAnggota` INT NOT NULL,
  `IdBuku` INT NOT NULL,
  `TanggalPinjam` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `TanggalJatuhTempo` DATETIME NOT NULL,
  `TanggalKembali` DATETIME NULL,
  `Denda` DECIMAL(18,2) NOT NULL DEFAULT 0,
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Dipinjam',
  CONSTRAINT `fk_peminjaman_anggota` FOREIGN KEY (`IdAnggota`) REFERENCES `t_Anggota`(`IdAnggota`) ON UPDATE CASCADE ON DELETE RESTRICT,
  CONSTRAINT `fk_peminjaman_buku` FOREIGN KEY (`IdBuku`) REFERENCES `t_Buku`(`IdBuku`) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
```
 -- 
## 📝 Cara Penggunaan

### 1. Kelola Buku
1. Klik "📚 KELOLA BUKU"
2. Isi form data buku
3. Klik "➕ Tambah" untuk menambah buku baru
4. Klik row di tabel untuk edit/hapus


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


## ⚙️ Installation & Setup

Panduan ini menjelaskan langkah-langkah untuk menjalankan aplikasi **Library Management System** menggunakan database yang sudah tersedia (**LibraryManagementDb**).

---

### 🧩 Prerequisites

Pastikan perangkat telah memenuhi kebutuhan berikut:

* **Windows OS**
* **Visual Studio 2022** (atau versi terbaru)

  * Workload: **.NET Desktop Development**
* **.NET Framework** (sesuai project, misalnya .NET Framework 4.8)
* **MySQL Server** (database sudah tersedia)
* **MySQL Workbench** (opsional, untuk pengecekan data)

---

### 📦 1. Clone atau Download Project

Clone repository dari GitHub:

```bash
git clone https://github.com/username/LibraryManagementSystem.git
```

Atau download repository dalam bentuk **ZIP**, lalu ekstrak ke komputer lokal.

---

### 🗂️ 2. Buka Project di Visual Studio

1. Buka **Visual Studio**
2. Pilih **Open a project or solution**
3. Arahkan ke folder hasil clone / extract
4. Buka file:

   ```
   LibraryManagementSystem.sln
   ```

---

### 🛢️ 3. Pastikan Database Aktif

Database **`LibraryManagementDb`** sudah tersedia.

Pastikan:

* MySQL Server **sudah berjalan**
* Database **LibraryManagementDb** dapat diakses melalui MySQL Workbench

❗ Tidak perlu membuat atau mengimpor database baru.

---

### 🔐 4. Konfigurasi Koneksi Database

Buka file:

```
DatabaseHelper.cs
```

Sesuaikan **connection string** agar mengarah ke database yang sudah tersedia:

```csharp
string connectionString = "server=localhost;database=LibraryManagementDb;uid=root;pwd=;";
```

Sesuaikan jika perlu:

* `server` → alamat server MySQL
* `uid` → username MySQL
* `pwd` → password MySQL

---

### ▶️ 5. Menjalankan Aplikasi

1. Pastikan **MySQL Server aktif**
2. Di Visual Studio, klik **Start (▶️)** atau tekan `F5`
3. Aplikasi akan menampilkan **Form Login**

---

### 👤 6. Akses Aplikasi

#### Login User

Digunakan untuk:

* Melihat katalog buku
* Melihat informasi buku

#### Login Admin

Digunakan untuk:

* Kelola data buku
* Kelola data anggota
* Peminjaman buku
* Pengembalian buku
* Melihat riwayat / laporan peminjaman

---

### 🧪 7. Pengujian Sistem

Pengujian dilakukan menggunakan **Black Box Testing**, meliputi:

* Login User
* Login Admin
* Katalog Buku
* Kelola Buku
* Kelola Anggota
* Peminjaman
* Pengembalian
* Riwayat / Laporan

Detail pengujian tersedia pada bagian **Test Case** di dokumentasi.

---

### ⚠️ Troubleshooting

* **Aplikasi tidak dapat terhubung ke database**

  * Pastikan MySQL Server berjalan
  * Pastikan nama database **LibraryManagementDb** benar
  * Periksa username dan password MySQL
* **Data tidak tampil**

  * Pastikan tabel database sudah berisi data
* **Error saat menjalankan aplikasi**

  * Pastikan .NET Framework sesuai dengan project

---

### ✅ Installation Checklist

* [x] Visual Studio terpasang
* [x] MySQL Server aktif
* [x] Database **LibraryManagementDb** tersedia
* [x] Connection string sesuai
* [x] Aplikasi berhasil dijalankan

---

## 🧪Skenario Pengujian (Testing Case)

### Pengujian Login User

| Keterangan                | Deskripsi                            |
| ------------------------- | ------------------------------------ |
| **Test Case ID**          | TC-01                                |
| **Nama Fitur**            | Login User                           |
| **Langkah Pengujian**     | Klik tombol **User** pada form Login |
| **Data Input**            | -                                    |
| **Hasil yang Diharapkan** | Sistem menampilkan **UserForm**      |
| **Hasil Aktual**          | Sesuai                               |
| **Status**                | Lulus                                |

---

### Pengujian Tampilan Katalog Buku (User)

| Keterangan                | Deskripsi                            |
| ------------------------- | ------------------------------------ |
| **Test Case ID**          | TC-02                                |
| **Nama Fitur**            | Katalog Buku                         |
| **Langkah Pengujian**     | Masuk sebagai User                   |
| **Data Input**            | Data dari tabel `t_Buku`             |
| **Hasil yang Diharapkan** | Data buku tampil di **DataGridView** |
| **Hasil Aktual**          | Sesuai                               |
| **Status**                | Lulus                                |

---

### Pengujian Login Admin

| Keterangan                | Deskripsi                             |
| ------------------------- | ------------------------------------- |
| **Test Case ID**          | TC-03                                 |
| **Nama Fitur**            | Login Admin                           |
| **Langkah Pengujian**     | Klik tombol **Admin** pada form Login |
| **Data Input**            | Username dan Password Admin           |
| **Hasil yang Diharapkan** | Sistem menampilkan **MainForm Admin** |
| **Hasil Aktual**          | Sesuai                                |
| **Status**                | Lulus                                 |

---

### Pengujian Kelola Buku

| Keterangan                | Deskripsi                   |
| ------------------------- | --------------------------- |
| **Test Case ID**          | TC-04                       |
| **Nama Fitur**            | Kelola Buku                 |
| **Langkah Pengujian**     | Admin membuka menu **Buku** |
| **Data Input**            | Data buku                   |
| **Hasil yang Diharapkan** | Data buku dapat dikelola    |
| **Hasil Aktual**          | Sesuai                      |
| **Status**                | Lulus                       |

---

### Pengujian Kelola Anggota

| Keterangan                | Deskripsi                               |
| ------------------------- | --------------------------------------- |
| **Test Case ID**          | TC-05                                   |
| **Nama Fitur**            | Kelola Anggota                          |
| **Langkah Pengujian**     | Admin membuka menu **Anggota**          |
| **Data Input**            | Data anggota                            |
| **Hasil yang Diharapkan** | Data anggota tampil di **DataGridView** |
| **Hasil Aktual**          | Sesuai                                  |
| **Status**                | Lulus                                   |

---

### Pengujian Peminjaman Buku

| Keterangan                | Deskripsi                                   |
| ------------------------- | ------------------------------------------- |
| **Test Case ID**          | TC-06                                       |
| **Nama Fitur**            | Peminjaman Buku                             |
| **Langkah Pengujian**     | Pilih anggota dan buku lalu klik **Simpan** |
| **Data Input**            | Anggota aktif dan buku tersedia             |
| **Hasil yang Diharapkan** | Transaksi peminjaman berhasil               |
| **Hasil Aktual**          | Sesuai                                      |
| **Status**                | Lulus                                       |

---

### Pengujian Pengembalian Buku

| Keterangan                | Deskripsi                                |
| ------------------------- | ---------------------------------------- |
| **Test Case ID**          | TC-07                                    |
| **Nama Fitur**            | Pengembalian Buku                        |
| **Langkah Pengujian**     | Klik **Kembalikan** pada data peminjaman |
| **Data Input**            | Data peminjaman aktif                    |
| **Hasil yang Diharapkan** | Status berubah menjadi **Dikembalikan**  |
| **Hasil Aktual**          | Sesuai                                   |
| **Status**                | Lulus                                    |

---

### Pengujian Riwayat Peminjaman

| Keterangan                | Deskripsi                      |
| ------------------------- | ------------------------------ |
| **Test Case ID**          | TC-08                          |
| **Nama Fitur**            | Riwayat Peminjaman             |
| **Langkah Pengujian**     | Admin membuka menu **Riwayat** |
| **Data Input**            | Data tabel `t_Peminjaman`      |
| **Hasil yang Diharapkan** | Data riwayat tampil            |
| **Hasil Aktual**          | Sesuai                         |
| **Status**                | Lulus                          |

---

### 📊 Testing Categories

- UI Interface
  Main Form menampilkan seluruh modul fitur

- Manajemen Buku
  Melihat Seluruh Katalog Buku
  Menambah buku baru
  Update kolom
  Hapus buku

- Manajemen Peminjaman
  Pinjam Buku
  Input data
  Simpan data peminjaman

- Manajemen Pengembalian
  Datagridview Pengembalian

- Business Logic
  Kalkulasi Perhitungan Otomatis Denda Keterlambatan

### ✅ Testing Checklist

- ✅ Database sudah di-setup dengan benar
- ✅ Sample data sudah ter-load
- ✅ Semua form bisa dibuka tanpa error
- ✅ CRUD operations berfungsi sempurna
- ✅ Peminjaman bisa diproses
- ✅ Pengembalian dengan denda bekerja
- ✅ Validasi input bekerja dengan baik
- ✅ Error handling menampilkan pesan yang jelas
- ✅ UI tampil rapi dan friendly

### 🎓 Learning Resources

Aplikasi ini merupakan implementasi dari konsep:
- OOP (Encapsulation, Inheritance, Polymorphism)
- Database Management
- Data Structures (Array, List)
- Error Handling & Debugging
- UI/UX Design

### 📄 Author
Project ini dibuat untuk tujuan edukasi dan memenuhi tes sertifikasi LSP 
Miguel Stanley Gunawan - 0706022210031
---
**Dibuat dengan menggunakan C# WinForms**
