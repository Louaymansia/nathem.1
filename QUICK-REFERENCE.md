# Quick Reference Card - Building Permit System

## 🚀 Quick Start (Windows Only)

```bash
# 1. Clone repository
git clone https://github.com/Louaymansia/nathem.1.git
cd nathem.1

# 2. Setup database (in SSMS or any SQL client)
# Run: DatabaseSetup.sql

# 3. Update connection string if needed
# Edit: PublicWorksAndRoads/App.config

# 4. Build (in Developer Command Prompt)
msbuild PublicWorksAndRoads.sln /p:Configuration=Release

# 5. Run
PublicWorksAndRoads\bin\Release\PublicWorksAndRoads.exe
```

## 📁 Project Structure

```
PublicWorksAndRoads/
├── Models/                  # Data models (3 files)
├── Repositories/            # Data access (3 files)
├── FormMain.cs             # Main menu
├── FormBuildingPermit.cs   # Main form (4 tabs)
├── Database.cs             # Connection helper
└── App.config              # Settings
```

## 🗄️ Database Tables

| Table | Purpose | Key Fields |
|-------|---------|-----------|
| `BuildingPermitRequests` | Main permit data | RequestId (PK), FormNumber, ApplicantName |
| `LandDirections` | Four directions data | DirectionId (PK), RequestId (FK), DirectionName |
| `Sketches` | Images/sketches | SketchId (PK), RequestId (FK), SketchImage |

## 💻 Key Classes

### Models
- `BuildingPermitRequest` - 30 fields
- `LandDirection` - 12 fields
- `Sketch` - 3 fields

### Repositories
```csharp
BuildingPermitRepository
  ├─ Insert(request): int
  ├─ Update(request): void
  ├─ Delete(id): void
  ├─ GetById(id): BuildingPermitRequest
  ├─ Search(term): List<BuildingPermitRequest>
  └─ GetAll(): List<BuildingPermitRequest>

LandDirectionRepository
  ├─ Insert(direction): void
  ├─ Update(direction): void
  ├─ DeleteByRequestId(id): void
  └─ GetByRequestId(id): List<LandDirection>

SketchRepository
  ├─ Insert(sketch): void
  ├─ Update(sketch): void
  ├─ DeleteByRequestId(id): void
  └─ GetByRequestId(id): List<Sketch>
```

## 🎨 UI Structure

```
FormBuildingPermit
├── Tab 1: البيانات الأساسية (Main Data)
│   ├── Entity & Applicant info
│   ├── Engineers data
│   └── Land & Building data
├── Tab 2: الاتجاهات (Directions)
│   ├── North (شمال)
│   ├── South (جنوب)
│   ├── East (شرق)
│   └── West (غرب)
├── Tab 3: الكروكي (Sketch)
│   ├── Sketch type input
│   ├── Image upload
│   └── Image display
└── Tab 4: السجلات (Records)
    ├── DataGridView
    └── Search box

Bottom Buttons:
[جديد] [حفظ] [حذف] [طباعة]
```

## 🔄 CRUD Operations Flow

### Create (إضافة)
```
Click "جديد" → Fill data → Click "حفظ"
  → Insert BuildingPermitRequest
  → Insert 4 LandDirections
  → Insert Sketch (if provided)
  → Refresh grid
```

### Read (عرض)
```
Load form → LoadAllRecords()
  → Display in DataGridView
Double-click row → Load record
  → GetById(requestId)
  → GetByRequestId(requestId) for directions
  → GetByRequestId(requestId) for sketch
```

### Update (تعديل)
```
Load record → Edit data → Click "حفظ"
  → Update BuildingPermitRequest
  → Delete old directions
  → Insert new directions
  → Delete old sketch
  → Insert new sketch
```

### Delete (حذف)
```
Select record → Click "حذف" → Confirm
  → Delete BuildingPermitRequest
  → CASCADE deletes LandDirections
  → CASCADE deletes Sketches
```

### Search (بحث)
```
Enter search term → Click "بحث"
  → Search(term) in repository
  → LIKE query on FormNumber, ApplicantName, RequestId
  → Display results in grid
```

## 🔧 Common Code Patterns

### Database Connection
```csharp
using (var connection = Database.CreateConnection())
{
    connection.Open();
    // Execute commands
}
```

### Parameterized Query
```csharp
var cmd = new SqlCommand("SELECT * FROM Table WHERE Id = @Id", connection);
cmd.Parameters.AddWithValue("@Id", id);
```

### NULL Handling
```csharp
cmd.Parameters.AddWithValue("@Field", (object)value ?? DBNull.Value);
```

### Read from DataReader
```csharp
if (reader.IsDBNull(reader.GetOrdinal("Field")))
    return null;
else
    return reader.GetString(reader.GetOrdinal("Field"));
```

## ⚙️ Configuration

### Connection String (App.config)
```xml
<connectionStrings>
  <add name="PublicWorksConnection" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=BuildingPermitDB;Integrated Security=True;TrustServerCertificate=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### Update for Different SQL Server
```xml
<!-- Local SQL Server -->
connectionString="Data Source=localhost;..."

<!-- Remote SQL Server -->
connectionString="Data Source=192.168.1.100;..."

<!-- Named Instance -->
connectionString="Data Source=.\InstanceName;..."

<!-- SQL Authentication -->
connectionString="Data Source=...;User Id=username;Password=password;..."
```

## 🐛 Troubleshooting

| Problem | Solution |
|---------|----------|
| Build error: .NET Framework 4.8 not found | Install .NET Framework 4.8 Developer Pack |
| Cannot connect to database | Check SQL Server is running |
| Login failed | Use Integrated Security or correct credentials |
| Table not found | Run DatabaseSetup.sql |
| Cannot save permit | Check FormNumber is not empty |

## 📝 Common Tasks

### Add New Field to BuildingPermitRequest
1. Add property to `Models/BuildingPermitRequest.cs`
2. Add parameter in `Repositories/BuildingPermitRepository.cs` → `AddParameters()`
3. Add mapping in `MapFromReader()`
4. Add TextBox in `FormBuildingPermit.Designer.cs`
5. Bind in `FormBuildingPermit.cs` → Save/Load methods
6. Update database: `ALTER TABLE BuildingPermitRequests ADD NewField...`

### Add New Tab
1. Add TabPage in `FormBuildingPermit.Designer.cs`
2. Create initialization method: `InitializeNewTab()`
3. Add controls and layout
4. Bind data in save/load methods

### Customize Print Output
Edit `FormBuildingPermit.cs` → `PrintDocument_PrintPage()`
```csharp
private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
{
    var g = e.Graphics;
    // Add your custom print logic
}
```

## 📚 Documentation Files

| File | Purpose |
|------|---------|
| `DatabaseSetup.sql` | Database schema |
| `BuildingPermitForm-README.md` | User guide (AR/EN) |
| `BUILD-INSTRUCTIONS.md` | Build & setup guide |
| `ARCHITECTURE.md` | System architecture |
| `IMPLEMENTATION-SUMMARY.md` | Complete summary |
| `QUICK-REFERENCE.md` | This file |

## 🔒 Security Checklist

- [x] Parameterized queries (no SQL injection)
- [x] `using` statements for connections
- [x] NULL handling
- [x] Input validation
- [x] Error handling with user messages
- [ ] Consider: Authentication/Authorization
- [ ] Consider: Encryption for sensitive data
- [ ] Consider: Audit logging

## ✅ Testing Checklist

- [ ] Database connection test
- [ ] Add new permit (all tabs)
- [ ] Load existing permit
- [ ] Update permit data
- [ ] Delete permit
- [ ] Search by form number
- [ ] Search by applicant name
- [ ] Upload and view sketch
- [ ] Print permit
- [ ] Verify cascade delete
- [ ] Test with Arabic text
- [ ] Test with empty optional fields

## 📞 Support

For help or issues:
1. Check BUILD-INSTRUCTIONS.md troubleshooting section
2. Review ARCHITECTURE.md for system details
3. Check database connection and schema
4. Contact development team

---

**Version**: 1.0  
**Last Updated**: January 2026  
**Platform**: Windows, .NET Framework 4.8  
**Database**: SQL Server Express or higher
