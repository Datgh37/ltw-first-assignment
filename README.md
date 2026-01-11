# TuNhanTamTinh - H? th?ng Qu?n lý Th?c ph?m

D? án ASP.NET Core Razor Pages qu?n lý thông tin th?c ph?m bao g?m tên, nhà s?n xu?t, ngày s?n xu?t, h?n s? d?ng và giá c?.

## ?? Yêu c?u h? th?ng

- **.NET 8 SDK** - [T?i t?i ?ây](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** ho?c **SQL Server LocalDB**
- **Visual Studio 2022+** ho?c **Visual Studio Code**
- **Git** - [T?i t?i ?ây](https://git-scm.com/)

## ?? Cài ??t d? án

### B??c 1: Clone repository

```bash
git clone https://github.com/Datgh37/ltw-first-assignment.git
cd ltw-first-assignment
```

### B??c 2: Restore packages

```bash
dotnet restore
```

### B??c 3: C?u hình Connection String

M? file `appsettings.json` và ki?m tra connection string:

```json
{
  "ConnectionStrings": {
    "TuNhanTamTinhContext": "Server=(localdb)\\mssqllocaldb;Database=TuNhanTamTinhContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**L?u ý:** 
- N?u dùng **LocalDB**: Gi? nguyên connection string trên
- N?u dùng **SQL Server**: Thay ??i thành `Server=localhost;Database=TuNhanTamTinhContext;Trusted_Connection=True;`
- N?u dùng **SQL Server v?i authentication**: `Server=localhost;Database=TuNhanTamTinhContext;User Id=your_username;Password=your_password;`

### B??c 4: T?o Database

Ch?y l?nh sau trong terminal (t?i th? m?c d? án):

```bash
dotnet ef database update
```

L?nh này s? t? ??ng:
- ? T?o database `TuNhanTamTinhContext`
- ? Ch?y t?t c? migrations có s?n
- ? T?o b?ng `Food` v?i c?u trúc ??y ??

**N?u g?p l?i "dotnet ef not found"**, cài ??t EF Core Tools:

```bash
dotnet tool install --global dotnet-ef
```

### B??c 5: Ch?y ?ng d?ng

```bash
dotnet run
```

Ho?c nh?n **F5** trong Visual Studio.

Truy c?p: `https://localhost:5001` ho?c `http://localhost:5000`

## ?? C?u trúc Database

### B?ng Food

| C?t | Ki?u d? li?u | Mô t? |
|-----|-------------|-------|
| Id | int (PK) | Mã ??nh danh t? ??ng t?ng |
| FoodName | nvarchar(max) | Tên th?c ph?m |
| Manufacturer | nvarchar(max) | Nhà s?n xu?t |
| ManufacturingDate | datetime2 | Ngày s?n xu?t |
| ExpiryDate | datetime2 | H?n s? d?ng |
| Price | decimal(18,2) | Giá ti?n |

## ??? C?u trúc d? án

```
TuNhanTamTinh/
??? Data/
?   ??? TuNhanTamTinhContext.cs    # DbContext
??? Migrations/                     # EF Core Migrations
?   ??? 20260111043306_Initial-Create.cs
??? Models/
?   ??? Food.cs                    # Model Food
??? Pages/                         # Razor Pages
?   ??? Foods/                     # CRUD pages cho Food
?   ??? Shared/
?   ?   ??? _Layout.cshtml
?   ??? Index.cshtml
??? wwwroot/                       # Static files
??? Program.cs                     # Entry point
??? appsettings.json              # Configuration
```

## ?? Các l?nh h?u ích

### Qu?n lý Database

```bash
# Xem danh sách migrations
dotnet ef migrations list

# T?o migration m?i
dotnet ef migrations add TenMigration

# C?p nh?t database
dotnet ef database update

# Rollback database v? migration tr??c
dotnet ef database update TenMigrationTruoc

# Xóa database
dotnet ef database drop
```

### Build và Run

```bash
# Build d? án
dotnet build

# Run d? án
dotnet run

# Run v?i watch mode (auto reload)
dotnet watch run

# Publish
dotnet publish -c Release
```

## ?? B?o m?t

**?? QUAN TR?NG:** Không commit các file sau lên GitHub:

- ? `appsettings.json` v?i connection string th?t (có password)
- ? `appsettings.Development.json` v?i thông tin nh?y c?m
- ? Th? m?c `bin/`, `obj/`
- ? File `.vs/`, `*.user`, `*.suo`

File `.gitignore` ?ã ???c c?u hình ?? b? qua các file này.

## ?? Troubleshooting

### L?i: Connection string not found

**Gi?i pháp:** Ki?m tra file `appsettings.json` có ch?a `ConnectionStrings` ch?a.

### L?i: Cannot connect to SQL Server

**Gi?i pháp:**
1. Ki?m tra SQL Server/LocalDB ?ã ???c cài ??t và ?ang ch?y
2. Ch?y `sqllocaldb info` ?? ki?m tra LocalDB
3. Ch?y `sqllocaldb start mssqllocaldb` ?? kh?i ??ng LocalDB

### L?i: Build failed

**Gi?i pháp:**
```bash
dotnet clean
dotnet restore
dotnet build
```

### L?i: Migration already applied

**Gi?i pháp:**
```bash
dotnet ef database drop
dotnet ef database update
```

## ?? ?óng góp

1. Fork repository
2. T?o branch m?i: `git checkout -b feature/TenFeature`
3. Commit changes: `git commit -m "Add some feature"`
4. Push to branch: `git push origin feature/TenFeature`
5. T?o Pull Request

## ?? License

D? án này ???c t?o cho m?c ?ích h?c t?p.

## ?? Liên h?

- Repository: [https://github.com/Datgh37/ltw-first-assignment](https://github.com/Datgh37/ltw-first-assignment)
- Issues: [https://github.com/Datgh37/ltw-first-assignment/issues](https://github.com/Datgh37/ltw-first-assignment/issues)

---

**Phát tri?n b?i:** Datgh37  
**Framework:** ASP.NET Core 8.0 Razor Pages  
**Database:** SQL Server / LocalDB  
**ORM:** Entity Framework Core 8.0
