# TuNhanTamTinh

## Yêu cầu hệ thống

- **.NET 8 SDK** - [T?i t?i ?ây](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** ho?c **SQL Server LocalDB**
- **Visual Studio 2022+** hoặc **Visual Studio Code**
- **Git** - [Tải tại đây](https://git-scm.com/)

## Cài đặt dự án

### B1: Clone repository

```bash
git clone https://github.com/Datgh37/ltw-first-assignment.git
cd ltw-first-assignment
```

### B2: Restore packages

```bash
dotnet restore
```

### B3: Cấu hình Connection String

Mở file `appsettings.json` và kiểm tra connection string:

```json
{
  "ConnectionStrings": {
    "TuNhanTamTinhContext": "Server=(localdb)\\mssqllocaldb;Database=TuNhanTamTinhContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**Lưu ý:** 
- Nếu dùng **LocalDB**: Giữ nguyên connection string trên
- Nếu dùng **SQL Server**: Thay đổi thành `Server=localhost;Database=TuNhanTamTinhContext;Trusted_Connection=True;`
- Nếu dùng **SQL Server với authentication**: `Server=localhost;Database=TuNhanTamTinhContext;User Id=your_username;Password=your_password;`

### Bước 4: Tạo Database

Chạy lệnh sau trong terminal (tại thư mục dự án):

```bash
dotnet ef database update
```

Lệnh này sẽ tự động:
- Tạo database `TuNhanTamTinhContext`
- Chạy tất cả migrations có sẵn
- Tạo bảng `Food` với cấu trúc đầy đủ

**Nếu gặp lỗi "dotnet ef not found"**, cài đặt EF Core Tools:

```bash
dotnet tool install --global dotnet-ef
```

### B5: Chạy ứng dụng 
* Nên run bằng IIS
```bash
dotnet run
```

Hoặc nhấn **F5** trong Visual Studio.

Truy cập: `https://localhost:5001` hoặc `http://localhost:5000`

## Cấu trúc Database

### Bảng Food

| Column | DataType | Description |
|-----|-------------|-------|
| Id | int (PK) | Mã ??nh danh t? ??ng t?ng |
| FoodName | nvarchar(max) | Tên th?c ph?m |
| Manufacturer | nvarchar(max) | Nhà s?n xu?t |
| ManufacturingDate | datetime2 | Ngày s?n xu?t |
| ExpiryDate | datetime2 | H?n s? d?ng |
| Price | decimal(18,2) | Giá ti?n |

## Các lệnh hữu ích

### Quản lý Database

```bash
# Xem danh sách migrations
dotnet ef migrations list

# Tạo migration mới
dotnet ef migrations add TenMigration

# Cập nhật database
dotnet ef database update

# Rollback database về migration trước
dotnet ef database update TenMigrationTruoc

# Xóa database
dotnet ef database drop
```

### Build và Run

```bash
# Build dự án
dotnet build

# Run dự án
dotnet run

# Run với watch mode (auto reload)
dotnet watch run

# Publish
dotnet publish -c Release
```

## Bảo mật

** QUAN TRỌNG:** Không commit các file sau lên GitHub:

- `appsettings.json` v?i connection string th?t (có password)
- `appsettings.Development.json` v?i thông tin nh?y c?m
- Thư mụcc `bin/`, `obj/`
- File `.vs/`, `*.user`, `*.suo`

File `.gitignore` đã đc cấu hình đã bỏ qua các file này.

## Troubleshooting

### Lỗi:: Connection string not found

**Giải pháp:** Kiểm tra file `appsettings.json` có chứa `ConnectionStrings` chưa.

### Lỗi:: Cannot connect to SQL Server

**Giải pháp:**
1. Kiểm tra SQL Server/LocalDB đã được cài đặt và đang chạy
2. Chạy `sqllocaldb info` để kiểm tra LocalDB
3. Chạy `sqllocaldb start mssqllocaldb` để khởi động LocalDB

### Lỗi: Build failed

**Giải pháp:**
```bash
dotnet clean
dotnet restore
dotnet build
```

### Lỗi: Migration already applied

**Giải pháp:**
```bash
dotnet ef database drop
dotnet ef database update
```

## Đóng góp

1. Fork repository
2. Tạo branch mới: `git checkout -b feature/TenFeature`
3. Commit changes: `git commit -m "Add some feature"`
4. Push to branch: `git push origin feature/TenFeature`
5. Tạo Pull Request



**Phát triển bởi:** Datgh37  
**Framework:** ASP.NET Core 8.0 Razor Pages  
**Database:** SQL Server / LocalDB  
**ORM:** Entity Framework Core 8.0
