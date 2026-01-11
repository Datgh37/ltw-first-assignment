# TuNhanTamTinh - Hệ thống Quản lý Thực phẩm

## 🎯 Yêu cầu hệ thống

- **.NET 8 SDK** - [Tải tại đây](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** hoặc **SQL Server LocalDB** (đã có sẵn khi cài Visual Studio)
- **Visual Studio 2022+** với workload **ASP.NET and web development**
- **Git** - [Tải tại đây](https://git-scm.com/)

---

## 📦 Hướng dẫn Setup dự án (Visual Studio - Giao diện)

### 🔹 Bước 1: Clone Repository

#### **Cách 1: Dùng Visual Studio**
1. Mở **Visual Studio 2022**
2. Click **Clone a repository**
3. Nhập URL: `https://github.com/Datgh37/ltw-first-assignment.git`
4. Chọn thư mục lưu dự án
5. Click **Clone**

#### **Cách 2: Dùng Git Bash**
```bash
git clone https://github.com/Datgh37/ltw-first-assignment.git
cd ltw-first-assignment
```

Sau đó mở file **TuNhanTamTinh.sln** bằng Visual Studio.

---

### 🔹 Bước 2: Restore NuGet Packages

Visual Studio sẽ **tự động restore packages** khi mở solution. 

Nếu không tự động, làm như sau:
1. Trong **Solution Explorer**, chuột phải vào **Solution** hoặc **Project**
2. Chọn **Restore NuGet Packages**

---

### 🔹 Bước 3: Kiểm tra Connection String

1. Trong **Solution Explorer**, mở file **appsettings.json**
2. Kiểm tra `ConnectionStrings`:

```json
{
  "ConnectionStrings": {
    "TuNhanTamTinhContext": "Server=(localdb)\\mssqllocaldb;Database=TuNhanTamTinhContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**✅ Dùng LocalDB**: Giữ nguyên (LocalDB đã có sẵn khi cài Visual Studio)  
**⚙️ Dùng SQL Server khác**: Sửa `Server=(localdb)\\mssqllocaldb` thành server của bạn

---

### 🔹 Bước 4: Tạo Database (Dùng Package Manager Console)

#### **Cách 1: Package Manager Console (Khuyên dùng) ⭐**

1. Vào menu: **Tools** → **NuGet Package Manager** → **Package Manager Console**
2. Trong cửa sổ console (phía dưới màn hình), gõ lệnh:

```powershell
Update-Database
```

3. Nhấn **Enter** và đợi khoảng 5-10 giây
4. Thấy thông báo **"Done"** hoặc **"Applying migration..."** là thành công! ✅

#### **Cách 2: Dùng Visual Studio Terminal**

1. Vào menu: **View** → **Terminal** (hoặc nhấn `` Ctrl + ` ``)
2. Gõ lệnh:

```bash
dotnet ef database update
```

**⚠️ Nếu gặp lỗi** `"dotnet ef not found"`:
```bash
dotnet tool install --global dotnet-ef
```

---

### 🔹 Bước 5: Chạy Ứng dụng

#### **Cách 1: Nhấn F5 (Khuyên dùng) ⭐**
1. Nhấn phím **F5** hoặc click nút ▶️ **Start Debugging** (màu xanh ở thanh công cụ)
2. Chọn **https** hoặc **IIS Express**
3. Trình duyệt sẽ tự động mở `https://localhost:xxxx`

#### **Cách 2: Chạy không debug**
- Nhấn **Ctrl + F5** hoặc click **Start Without Debugging**

#### **Cách 3: Dùng Terminal**
```bash
dotnet run
```

---

## 🔍 Kiểm tra Database đã được tạo

### **Cách 1: SQL Server Object Explorer (trong Visual Studio) ⭐**
1. Vào menu: **View** → **SQL Server Object Explorer**
2. Mở rộng:
   - **(localdb)\\mssqllocaldb**
   - **Databases**
   - **TuNhanTamTinhContext**
   - **Tables**
3. Thấy bảng **dbo.Food** → Thành công! ✅

### **Cách 2: Server Explorer**
1. Vào menu: **View** → **Server Explorer**
2. Chuột phải **Data Connections** → **Add Connection**
3. Chọn **Microsoft SQL Server** → **Continue**
4. Server name: `(localdb)\mssqllocaldb`
5. Database name: `TuNhanTamTinhContext`
6. Click **OK**

---

## 📊 Cấu trúc Database

### Bảng Food

| Cột | Kiểu dữ liệu | Mô tả |
|-----|-------------|-------|
| **Id** | int (PK, Identity) | Mã định danh tự động tăng |
| **FoodName** | nvarchar(max) | Tên thực phẩm |
| **Manufacturer** | nvarchar(max) | Nhà sản xuất |
| **ManufacturingDate** | datetime2 | Ngày sản xuất (MFD) |
| **ExpiryDate** | datetime2 | Hạn sử dụng (EXP) |
| **Price** | decimal(18,2) | Giá tiền |

---

## 🛠️ Các thao tác khác trong Visual Studio

### ✅ Build Solution
- Menu: **Build** → **Build Solution** (hoặc **Ctrl + Shift + B**)

### ✅ Clean Solution
- Menu: **Build** → **Clean Solution**
- Sau đó: **Build** → **Rebuild Solution**

### ✅ Xem Migrations (Package Manager Console)
```powershell
Get-Migration
```

### ✅ Tạo Migration mới
```powershell
Add-Migration TenMigration
Update-Database
```

### ✅ Xóa Database và tạo lại
```powershell
Drop-Database
Update-Database
```

---

## 🐛 Troubleshooting (Xử lý lỗi thường gặp)

### ❌ Lỗi: "Connection string not found"

**Nguyên nhân:** File `appsettings.json` thiếu `ConnectionStrings`

**Giải pháp:**
1. Mở file **appsettings.json**
2. Thêm đoạn sau vào trong `{ }`:
```json
"ConnectionStrings": {
  "TuNhanTamTinhContext": "Server=(localdb)\\mssqllocaldb;Database=TuNhanTamTinhContext;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

---

### ❌ Lỗi: "Cannot connect to SQL Server"

**Giải pháp:**

#### Cách 1: Kiểm tra LocalDB đang chạy
1. Mở **Command Prompt** hoặc **PowerShell**
2. Gõ:
```bash
sqllocaldb info
sqllocaldb start mssqllocaldb
```

#### Cách 2: Cài lại LocalDB
- Mở **Visual Studio Installer**
- Click **Modify**
- Chọn **Individual components**
- Tìm và check: **SQL Server Express 2019 LocalDB**
- Click **Modify**

---

### ❌ Lỗi: "Update-Database" không chạy được

**Giải pháp:**
1. Đảm bảo đã mở đúng **solution** (.sln file)
2. Trong **Package Manager Console**, kiểm tra **Default project** có đúng là **TuNhanTamTinh** không
3. Thử lại lệnh:
```powershell
Update-Database -Verbose
```

---

### ❌ Lỗi: "Build failed"

**Giải pháp:**
1. Menu: **Build** → **Clean Solution**
2. Chuột phải vào **Solution** → **Restore NuGet Packages**
3. Menu: **Build** → **Rebuild Solution**
4. Xem cửa sổ **Error List** (View → Error List) để biết lỗi cụ thể

---

## 📁 Cấu trúc Project

```
TuNhanTamTinh/
├── 📂 Data/
│   └── TuNhanTamTinhContext.cs    # DbContext
├── 📂 Migrations/                  # EF Core Migrations (QUAN TRỌNG!)
│   └── 20260111043306_Initial-Create.cs
├── 📂 Models/
│   └── Food.cs                    # Model Food với DataAnnotations
├── 📂 Pages/                       # Razor Pages
│   ├── 📂 Foods/                   # CRUD pages cho Food
│   ├── 📂 Shared/
│   │   └── _Layout.cshtml
│   ├── Index.cshtml
│   └── Privacy.cshtml
├── 📂 wwwroot/                     # Static files (CSS, JS, images)
├── 📄 Program.cs                   # Entry point, cấu hình services
├── 📄 appsettings.json            # Configuration & Connection string
└── 📄 TuNhanTamTinh.csproj        # Project file
```

---

## 🔒 Bảo mật - Các file KHÔNG đẩy lên GitHub

**⚠️ QUAN TRỌNG:** File `.gitignore` đã cấu hình tự động bỏ qua các file sau:

- ❌ `bin/`, `obj/` - Thư mục build
- ❌ `.vs/` - Visual Studio settings
- ❌ `*.user`, `*.suo` - User-specific files
- ❌ `appsettings.json` với connection string có **password**

**✅ NÊN commit:**
- ✅ Toàn bộ source code (.cs, .cshtml)
- ✅ Thư mục **Migrations/** (cực kỳ quan trọng!)
- ✅ File `.csproj`, `.sln`
- ✅ `appsettings.json` với connection string **mẫu** (không có password)

---

## 👥 Đóng góp

1. **Fork** repository này
2. Tạo branch mới: `git checkout -b feature/TenFeature`
3. Commit thay đổi: `git commit -m "Add some feature"`
4. Push lên branch: `git push origin feature/TenFeature`
5. Tạo **Pull Request**

---

## 📞 Liên hệ & Hỗ trợ

- **Repository:** [https://github.com/Datgh37/ltw-first-assignment](https://github.com/Datgh37/ltw-first-assignment)
- **Issues:** [https://github.com/Datgh37/ltw-first-assignment/issues](https://github.com/Datgh37/ltw-first-assignment/issues)

---

## 🎓 Tài liệu tham khảo

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Razor Pages Tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/)

---

**👨‍💻 Phát triển bởi:** Datgh37  
**🚀 Framework:** ASP.NET Core 8.0 Razor Pages  
**💾 Database:** SQL Server / LocalDB  
**🔧 ORM:** Entity Framework Core 8.0
