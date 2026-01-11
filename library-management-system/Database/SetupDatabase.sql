-- MySQL Library Management System Database Setup Script
-- Run this script in MySQL client (mysql) or MySQL Workbench

CREATE DATABASE IF NOT EXISTS `LibraryManagementDB` CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci;
USE `LibraryManagementDB`;

-- Drop existing tables if they exist (for clean install)
DROP TABLE IF EXISTS `t_Peminjaman`;
DROP TABLE IF EXISTS `t_Buku`;
DROP TABLE IF EXISTS `t_Anggota`;

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

-- Insert sample data for Books
INSERT INTO `t_Buku` (`KodeBuku`, `Judul`, `Penulis`, `Penerbit`, `TahunTerbit`, `Kategori`, `Stok`, `StokTersedia`) VALUES
('BK001', 'Pemrograman C# untuk Pemula', 'John Doe', 'Tech Publisher', 2024, 'Teknologi', 5, 5),
('BK002', 'Database SQL Server Advanced', 'Jane Smith', 'Database Press', 2023, 'Teknologi', 3, 3),
('BK003', 'Algoritma dan Struktur Data', 'Robert Johnson', 'CS Books', 2024, 'Teknologi', 4, 4),
('BK004', 'Sejarah Dunia Modern', 'Michael Brown', 'History Publishing', 2022, 'Sejarah', 6, 6),
('BK005', 'Fisika Dasar', 'Sarah Wilson', 'Science Press', 2023, 'Sains', 4, 4),
('BK006', 'Matematika Diskrit', 'David Lee', 'Math Publishers', 2024, 'Pendidikan', 5, 5),
('BK007', 'Bahasa Indonesia yang Baik', 'Ahmad Dahlan', 'Bahasa Press', 2023, 'Pendidikan', 7, 7),
('BK008', 'Manajemen Proyek IT', 'Linda Garcia', 'Tech Publisher', 2024, 'Teknologi', 3, 3);

-- Insert sample data for Members
INSERT INTO `t_Anggota` (`KodeAnggota`, `NamaLengkap`, `Alamat`, `NoTelepon`, `Email`, `Aktif`) VALUES
('MBR001', 'Budi Santoso', 'Jl. Merdeka No. 123, Jakarta', '081234567890', 'budi@email.com', 1),
('MBR002', 'Siti Nurhaliza', 'Jl. Sudirman No. 45, Bandung', '081234567891', 'siti@email.com', 1),
('MBR003', 'Ahmad Rizky', 'Jl. Gatot Subroto No. 67, Surabaya', '081234567892', 'ahmad@email.com', 1),
('MBR004', 'Dewi Lestari', 'Jl. Diponegoro No. 89, Yogyakarta', '081234567893', 'dewi@email.com', 1),
('MBR005', 'Rudi Hermawan', 'Jl. Ahmad Yani No. 12, Semarang', '081234567894', 'rudi@email.com', 1);

-- Insert sample borrowing data
SET @BorrowDate = DATE_SUB(NOW(), INTERVAL 5 DAY);
SET @DueDate = DATE_ADD(NOW(), INTERVAL 2 DAY);

INSERT INTO `t_Peminjaman` (`KodePeminjaman`, `IdAnggota`, `IdBuku`, `TanggalPinjam`, `TanggalJatuhTempo`, `Status`) VALUES
(CONCAT('BRW', DATE_FORMAT(NOW(), '%Y%m%d'), '0001'), 1, 1, @BorrowDate, @DueDate, 'Dipinjam'),
(CONCAT('BRW', DATE_FORMAT(NOW(), '%Y%m%d'), '0002'), 2, 3, @BorrowDate, @DueDate, 'Dipinjam');

-- Update available stock for borrowed books
UPDATE `t_Buku` SET `StokTersedia` = `StokTersedia` - 1 WHERE `IdBuku` IN (1, 3);

-- Create indexes for better performance (use prefix length for long utf8mb4 columns where needed)
CREATE INDEX `IX_Buku_KodeBuku` ON `t_Buku`(`KodeBuku`);
CREATE INDEX `IX_Buku_Judul` ON `t_Buku`(`Judul`(100));
CREATE INDEX `IX_Anggota_KodeAnggota` ON `t_Anggota`(`KodeAnggota`);
CREATE INDEX `IX_Anggota_NamaLengkap` ON `t_Anggota`(`NamaLengkap`(100));
CREATE INDEX `IX_Peminjaman_Status` ON `t_Peminjaman`(`Status`);
CREATE INDEX `IX_Peminjaman_TanggalPinjam` ON `t_Peminjaman`(`TanggalPinjam`);

-- Procedure to update late borrowings
DELIMITER $$
CREATE PROCEDURE `UpdateLateStatus`()
BEGIN
  UPDATE `t_Peminjaman`
  SET `Status` = 'Terlambat'
  WHERE `TanggalKembali` IS NULL
    AND `TanggalJatuhTempo` < NOW()
    AND `Status` != 'Terlambat';
END$$
DELIMITER ;

-- Summary output
SELECT 'Database LibraryManagementDB berhasil dibuat dan diinisialisasi!' AS Info;
SELECT 'Total Books: ' AS Label, COUNT(*) AS TotalBooks FROM `t_Buku`;
SELECT 'Total Members: ' AS Label, COUNT(*) AS TotalMembers FROM `t_Anggota`;
SELECT 'Total Borrowings: ' AS Label, COUNT(*) AS TotalBorrowings FROM `t_Peminjaman`;
