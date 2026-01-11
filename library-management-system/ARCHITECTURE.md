# 🏗️ Arsitektur Aplikasi - Library Management System

## 📐 Architecture Overview

```
┌─────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                    │
│                     (WinForms UI)                        │
│  ┌─────────┐  ┌─────────┐  ┌──────────┐  ┌─────────┐  │
│  │  Main   │  │  Book   │  │ Borrowing│  │ History │  │
│  │  Form   │  │  Form   │  │   Form   │  │  Form   │  │
│  └─────────┘  └─────────┘  └──────────┘  └─────────┘  │
│  ┌─────────┐  ┌─────────┐                               │
│  │ Member  │  │ Return  │                               │
│  │  Form   │  │  Form   │                               │
│  └─────────┘  └─────────┘                               │
└────────────────────┬────────────────────────────────────┘
                     │
                     ↓ (Uses)
┌─────────────────────────────────────────────────────────┐
│                   BUSINESS LOGIC LAYER                   │
│                    (Domain Models)                       │
│  ┌─────────┐  ┌─────────┐  ┌──────────┐  ┌─────────┐  │
│  │  Book   │  │ Member  │  │Borrowing │  │  User   │  │
│  │  Class  │  │  Class  │  │  Class   │  │ (Base)  │  │
│  │         │  │         │  │          │  │         │  │
│  │ Methods │  │ Methods │  │ Methods  │  │Abstract │  │
│  └─────────┘  └─────────┘  └──────────┘  └─────────┘  │
│       │             │            │             │        │
│       └─────────────┼────────────┼─────────────┘        │
│                     │            │                      │
│              ┌──────┴──────┐  ┌─┴───────┐              │
│              │  Petugas    │  │  Admin  │              │
│              │  (Derived)  │  │(Derived)│              │
│              └─────────────┘  └─────────┘              │
└────────────────────┬────────────────────────────────────┘
                     │
                     ↓ (Managed by)
┌─────────────────────────────────────────────────────────┐
│                  DATA ACCESS LAYER                       │
│                  (Repository Pattern)                    │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │    Book      │  │   Member     │  │  Borrowing   │  │
│  │  Repository  │  │  Repository  │  │  Repository  │  │
│  │              │  │              │  │              │  │
│  │ • GetAll()   │  │ • GetAll()   │  │ • GetAll()   │  │
│  │ • GetById()  │  │ • GetById()  │  │ • Return()   │  │
│  │ • Add()      │  │ • Add()      │  │ • Search()   │  │
│  │ • Update()   │  │ • Update()   │  │ • Generate() │  │
│  │ • Delete()   │  │ • Delete()   │  │              │  │
│  │ • Search()   │  │ • Search()   │  │              │  │
│  └──────┬───────┘  └──────┬───────┘  └──────┬───────┘  │
│         │                 │                 │           │
│         └─────────────────┼─────────────────┘           │
│                           │                             │
│                  ┌────────┴────────┐                    │
│                  │ DatabaseHelper  │                    │
│                  │                 │                    │
│                  │ • GetConnection │                    │
│                  │ • ExecuteQuery  │                    │
│                  │ • ExecuteScalar │                    │
│                  └────────┬────────┘                    │
└───────────────────────────┼─────────────────────────────┘
                            │
                            ↓ (Connects to)
┌─────────────────────────────────────────────────────────┐
│                      DATABASE LAYER                      │
│                     (SQL Server)                         │
│  ┌─────────────────────────────────────────────────┐    │
│  │              LibraryManagementDB                │    │
│  │                                                 │    │
│  │  ┌──────────┐  ┌──────────┐  ┌──────────────┐ │    │
│  │  │  Books   │  │ Members  │  │  Borrowings  │ │    │
│  │  │          │  │          │  │              │ │    │
│  │  │ • BookId │  │• MemberId│  │• BorrowingId │ │    │
│  │  │ • Code   │  │• Code    │  │• Code        │ │    │
│  │  │ • Title  │  │• Name    │  │• MemberId FK │ │    │
│  │  │ • Author │  │• Address │  │• BookId FK   │ │    │
│  │  │ • Stock  │  │• Phone   │  │• BorrowDate  │ │    │
│  │  │ ...      │  │• Email   │  │• DueDate     │ │    │
│  │  └──────────┘  └──────────┘  │• ReturnDate  │ │    │
│  │                               │• Fine        │ │    │
│  │                               └──────────────┘ │    │
│  └─────────────────────────────────────────────────┘    │
└─────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────┐
│                    UTILITY LAYER                         │
│  ┌──────────────────────────────────────────────────┐   │
│  │              FileExporter                         │   │
│  │                                                   │   │
│  │  • ExportToTxt()   - Export data to TXT         │   │
│  │  • ExportToCsv()   - Export data to CSV         │   │
│  │  • GenerateReport()- Generate statistics report  │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
```

---

## 🔄 Data Flow

### Example: Peminjaman Buku

```
1. USER ACTION
   ↓
[BorrowingForm.btnBorrow_Click()]
   ↓
2. VALIDATE INPUT
   • Check member selected
   • Check book selected
   • Check book availability
   ↓
3. CREATE MODEL
   var borrowing = new Borrowing {
       BorrowingCode = GenerateCode(),
       MemberId = selectedMember,
       BookId = selectedBook,
       BorrowDate = DateTime.Now,
       DueDate = DateTime.Now.AddDays(7)  ← AUTO CALCULATE
   };
   ↓
4. CALL REPOSITORY
   borrowingRepo.AddBorrowing(borrowing)
   ↓
5. DATABASE OPERATION
   DatabaseHelper.ExecuteNonQuery(
       "INSERT INTO Borrowings (...) VALUES (...)",
       parameters
   )
   ↓
6. UPDATE STOCK
   bookRepo.UpdateStock(bookId, newStock)
   ↓
7. REFRESH UI
   • Show success message
   • Reload data
   • Clear form
```

---

## 🎯 Design Patterns Implemented

### 1. Repository Pattern

**Purpose:** Separate data access logic from business logic

```csharp
// Interface (implicit)
public class BookRepository {
    public List<Book> GetAllBooks() { }
    public Book GetBookById(int id) { }
    public bool AddBook(Book book) { }
    public bool UpdateBook(Book book) { }
    public bool DeleteBook(int id) { }
}
```

**Benefits:**
- ✅ Centralized data access
- ✅ Easy to test
- ✅ Easy to switch database
- ✅ Reusable code

### 2. Factory Pattern

**Purpose:** Generate unique codes

```csharp
public string GenerateBorrowingCode() {
    var count = GetCount();
    return $"BRW{DateTime.Now:yyyyMMdd}{count:D4}";
}
```

### 3. Strategy Pattern (via Polymorphism)

**Purpose:** Different fine calculation strategies

```csharp
// Strategy 1: Normal borrowing
public virtual decimal HitungDenda() {
    return lateDays * 2000;
}

// Strategy 2: Premium borrowing
public override decimal HitungDenda() {
    return base.HitungDenda() * 0.5m;  // 50% discount
}
```

---

## 📊 Class Diagram

```
┌─────────────────────────────────────────┐
│          «abstract» User                │
├─────────────────────────────────────────┤
│ + UserId: int                           │
│ + Username: string                      │
│ + FullName: string                      │
│ + Email: string                         │
├─────────────────────────────────────────┤
│ + GetRole(): string «abstract»          │
│ + ValidateAccess(feature): bool         │
└──────────────┬──────────────────────────┘
               │
       ┌───────┴────────┐
       │                │
       ↓                ↓
┌─────────────┐   ┌─────────────┐
│  Petugas    │   │    Admin    │
├─────────────┤   ├─────────────┤
│ + EmployeeId│   │ + AdminLevel│
│ + Position  │   │             │
├─────────────┤   ├─────────────┤
│ + GetRole() │   │ + GetRole() │
└─────────────┘   └─────────────┘

┌─────────────────────────────────────────┐
│               Book                      │
├─────────────────────────────────────────┤
│ + BookId: int                           │
│ + BookCode: string                      │
│ + Title: string                         │
│ + Author: string                        │
│ + Stock: int                            │
│ + AvailableStock: int                   │
├─────────────────────────────────────────┤
│ + IsAvailable(): bool                   │
│ + GetFullInfo(): string                 │
│ + UpdateStock(borrowed: int): void      │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│               Member                    │
├─────────────────────────────────────────┤
│ + MemberId: int                         │
│ + MemberCode: string                    │
│ + FullName: string                      │
│ + PhoneNumber: string                   │
│ + IsActive: bool                        │
├─────────────────────────────────────────┤
│ + CanBorrow(): bool                     │
│ + GetFullInfo(): string                 │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│             Borrowing                   │
├─────────────────────────────────────────┤
│ + BorrowingId: int                      │
│ + BorrowingCode: string                 │
│ + MemberId: int                         │
│ + BookId: int                           │
│ + BorrowDate: DateTime                  │
│ + DueDate: DateTime                     │
│ + ReturnDate: DateTime?                 │
│ + Fine: decimal                         │
│ + Status: string                        │
├─────────────────────────────────────────┤
│ + SetDueDate(): void                    │
│ + HitungDenda(): decimal «virtual»      │
│ + IsLate(): bool                        │
│ + UpdateStatus(): void                  │
└──────────────┬──────────────────────────┘
               │
               ↓ «inherits»
┌─────────────────────────────────────────┐
│         SpecialBorrowing                │
├─────────────────────────────────────────┤
│ + IsPremiumMember: bool                 │
├─────────────────────────────────────────┤
│ + HitungDenda(): decimal «override»     │
└─────────────────────────────────────────┘
```

---

## 🔐 Security Features

### 1. SQL Injection Prevention

```csharp
// ❌ BAD (Vulnerable)
string query = "SELECT * FROM Books WHERE BookCode = '" + code + "'";

// ✅ GOOD (Safe)
string query = "SELECT * FROM Books WHERE BookCode = @BookCode";
SqlParameter[] parameters = {
    new SqlParameter("@BookCode", code)
};
```

### 2. Input Validation

```csharp
private bool ValidateInput() {
    if (string.IsNullOrWhiteSpace(txtBookCode.Text)) {
        MessageBox.Show("Kode buku tidak boleh kosong!");
        return false;
    }
    
    if (numStock.Value <= 0) {
        MessageBox.Show("Stok harus lebih dari 0!");
        return false;
    }
    
    return true;
}
```

### 3. Error Handling

```csharp
try {
    // Database operation
}
catch (SqlException ex) {
    MessageBox.Show($"Database error: {ex.Message}");
}
catch (Exception ex) {
    MessageBox.Show($"Error: {ex.Message}");
}
finally {
    // Cleanup
}
```

---

## ⚡ Performance Optimizations

### 1. Database Indexes

```sql
CREATE INDEX IX_Books_BookCode ON Books(BookCode);
CREATE INDEX IX_Books_Title ON Books(Title);
CREATE INDEX IX_Borrowings_Status ON Borrowings(Status);
```

### 2. Connection Pooling

```xml
<connectionString>
  ...;Pooling=true;Min Pool Size=5;Max Pool Size=100;
</connectionString>
```

### 3. DataGridView Optimization

```csharp
dgvBooks.SuspendLayout();
// ... update data ...
dgvBooks.ResumeLayout();
```

---

## 📈 Scalability Considerations

### Current Design Supports:

- ✅ Multiple users (extend with login system)
- ✅ Large datasets (pagination can be added)
- ✅ Multiple branches (add BranchId to tables)
- ✅ Reporting (statistical queries optimized)
- ✅ Backup & restore (SQL Server native)

### Future Enhancements:

- [ ] User authentication & authorization
- [ ] Role-based access control
- [ ] Barcode scanning
- [ ] Email notifications
- [ ] Advanced reporting (charts, graphs)
- [ ] Web/mobile version
- [ ] Cloud database support
- [ ] Multi-language support

---

## 🧪 Testing Strategy

### Unit Testing Targets:

```csharp
[TestClass]
public class BorrowingTests {
    [TestMethod]
    public void HitungDenda_TidakTerlambat_ReturnZero() { }
    
    [TestMethod]
    public void HitungDenda_Terlambat3Hari_Return6000() { }
    
    [TestMethod]
    public void SetDueDate_AutoAdd7Days() { }
}
```

### Integration Testing:

- Database connection
- CRUD operations
- Transaction handling
- Foreign key constraints

### UI Testing:

- Form validation
- Button clicks
- Data binding
- Error messages

---

## 📝 Code Standards

### Naming Conventions:

- **Classes:** PascalCase (`BookRepository`, `FileExporter`)
- **Methods:** PascalCase (`GetAllBooks()`, `HitungDenda()`)
- **Variables:** camelCase (`selectedBookId`, `totalFine`)
- **Constants:** UPPER_CASE (`DEFAULT_FINE_PER_DAY`)
- **UI Controls:** prefixType (`btnAdd`, `txtBookCode`, `dgvBooks`)

### Comments:

```csharp
// Single-line comment for simple explanations

/// <summary>
/// Method summary for documentation
/// </summary>
/// <param name="bookId">Description</param>
/// <returns>Description</returns>
public Book GetBookById(int bookId) { }
```

---

## 🎓 Learning Outcomes

Dengan arsitektur ini, Anda telah belajar:

1. ✅ **Separation of Concerns** - Layer terpisah
2. ✅ **Repository Pattern** - Data access abstraction
3. ✅ **OOP Principles** - Encapsulation, Inheritance, Polymorphism
4. ✅ **Database Design** - Normalization, relationships, indexes
5. ✅ **Error Handling** - Try-catch, validation, user feedback
6. ✅ **UI/UX Design** - User-friendly interfaces
7. ✅ **Code Organization** - Clean, maintainable structure
8. ✅ **Best Practices** - Naming, comments, structure

---

**Dokumentasi ini menjelaskan arsitektur lengkap aplikasi Library Management System** 🏗️✨
