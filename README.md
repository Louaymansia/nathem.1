# nathem.1
نظام اتمتة الاشغال العامة والطرق  
Public Works and Roads Automation System

## 🏗️ Building Permit Management System

A comprehensive WinForms application for managing building permit requests with full CRUD operations, four-direction land data, sketch management, and Arabic RTL support.

## ✨ Features

### Core Functionality
- ✅ **Full CRUD Operations**: Create, Read, Update, Delete, Search, Print
- ✅ **Building Permit Management**: Complete form with 30+ fields
- ✅ **Four Directions Data**: North, South, East, West (44 fields total)
- ✅ **Sketch Management**: Upload and store images with permits
- ✅ **Advanced Search**: Search by form number, applicant name, or request ID
- ✅ **Print Support**: Print formatted permit documents
- ✅ **Arabic Interface**: Full RTL support with Arabic labels

### Technical Features
- 🔒 **Security**: Parameterized queries, SQL injection prevention
- 📊 **Database**: SQL Server with cascade delete relationships
- 🎨 **UI**: Organized tab-based interface with 4 sections
- 📝 **Documentation**: 7 comprehensive guides included
- 🌐 **Architecture**: Repository pattern with clean separation of concerns

## 🚀 Quick Start

### Prerequisites
- Windows OS (Windows 10 or later)
- Visual Studio 2019/2022
- .NET Framework 4.8
- SQL Server Express or higher

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Louaymansia/nathem.1.git
   cd nathem.1
   ```

2. **Setup the database**
   - Open SQL Server Management Studio
   - Run the script: `DatabaseSetup.sql`
   - Verify `BuildingPermitDB` database is created

3. **Configure connection** (if needed)
   - Edit `PublicWorksAndRoads/App.config`
   - Update the connection string for your SQL Server instance

4. **Build the project**
   ```bash
   # Open Developer Command Prompt
   msbuild PublicWorksAndRoads.sln /p:Configuration=Release
   ```

5. **Run the application**
   ```bash
   PublicWorksAndRoads\bin\Release\PublicWorksAndRoads.exe
   ```

## 📖 Documentation

Comprehensive documentation is included in the repository:

| Document | Description | Language |
|----------|-------------|----------|
| [BuildingPermitForm-README.md](BuildingPermitForm-README.md) | User guide | Arabic/English |
| [BUILD-INSTRUCTIONS.md](BUILD-INSTRUCTIONS.md) | Build and setup guide | English |
| [ARCHITECTURE.md](ARCHITECTURE.md) | System architecture | English |
| [IMPLEMENTATION-SUMMARY.md](IMPLEMENTATION-SUMMARY.md) | Implementation overview | Arabic/English |
| [QUICK-REFERENCE.md](QUICK-REFERENCE.md) | Developer quick reference | English |
| [VISUAL-LAYOUT-GUIDE.md](VISUAL-LAYOUT-GUIDE.md) | UI layout diagrams | English |
| [DatabaseSetup.sql](DatabaseSetup.sql) | Database creation script | SQL |

## 🏗️ Project Structure

```
nathem.1/
├── PublicWorksAndRoads/           # Main application
│   ├── Models/                    # Data models (3 files)
│   ├── Repositories/              # Data access layer (3 files)
│   ├── FormMain.cs               # Main menu
│   ├── FormBuildingPermit.cs     # Building permit form
│   ├── Database.cs               # Connection helper
│   └── App.config                # Configuration
├── DatabaseSetup.sql              # Database creation script
└── Documentation files (7 files)  # Comprehensive guides
```

## 💡 Usage

### Main Menu
1. Launch the application
2. Click **"اختبار الاتصال بقاعدة البيانات"** to test database connection
3. Click **"استمارة طلب ترخيص بناء"** to open the building permit form

### Building Permit Form

#### Four Tabs:
1. **البيانات الأساسية** (Main Data) - Basic permit information
2. **الاتجاهات** (Directions) - Four directions data
3. **الكروكي** (Sketch) - Upload and view images
4. **السجلات** (Records) - View and search all records

#### Operations:
- **جديد** (New) - Create a new permit
- **حفظ** (Save) - Save current permit
- **حذف** (Delete) - Delete selected permit
- **طباعة** (Print) - Print permit document
- **بحث** (Search) - Search existing permits

## 📊 Database Schema

### Tables
- **BuildingPermitRequests** - Main permit data (30 fields)
- **LandDirections** - Four directions data (12 fields per direction)
- **Sketches** - Images and sketches (3 fields)

### Relationships
- `LandDirections.RequestId` → `BuildingPermitRequests.RequestId` (CASCADE DELETE)
- `Sketches.RequestId` → `BuildingPermitRequests.RequestId` (CASCADE DELETE)

## 🔧 Technology Stack

- **Framework**: .NET Framework 4.8
- **UI**: Windows Forms
- **Database**: SQL Server (Express or higher)
- **Data Access**: ADO.NET with Repository Pattern
- **Language**: C# 7.3
- **UI Language**: Arabic (RTL supported)

## 📈 Statistics

- **Total Files**: 19 new files
- **Lines of Code**: ~2,500+ lines
- **Database Tables**: 3 tables
- **Total Fields**: 81 fields
- **UI Components**: 4 tabs, 81+ controls
- **Documentation**: 7 guides (~60+ pages)

## 🛡️ Security

- ✅ Parameterized SQL queries
- ✅ SQL injection prevention
- ✅ Input validation
- ✅ Proper resource disposal
- ✅ Error handling with user messages

## 🤝 Contributing

Contributions are welcome! Please read the documentation before making changes.

## 📝 License

[Your License Here]

## 👥 Authors

- Development Team - Louaymansia

## 🆘 Support

For help or issues:
1. Check [BUILD-INSTRUCTIONS.md](BUILD-INSTRUCTIONS.md) troubleshooting section
2. Review [QUICK-REFERENCE.md](QUICK-REFERENCE.md)
3. Contact the development team

## 📅 Version History

- **v1.0** (January 2026)
  - Initial release
  - Complete building permit management system
  - Full CRUD operations
  - Four directions management
  - Sketch upload functionality
  - Comprehensive documentation

---

**Status**: ✅ Production Ready  
**Build Status**: Ready for Windows build  
**Last Updated**: January 2026  

For detailed information, see the [documentation](#-documentation) section above.
