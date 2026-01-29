# Building Permit System - Build Instructions

## Overview
This document explains how to build and run the Building Permit System on Windows with .NET Framework 4.8.

## Prerequisites

### Required Software
1. **Windows OS** (Windows 10 or later recommended)
2. **.NET Framework 4.8 Developer Pack**
   - Download from: https://dotnet.microsoft.com/download/dotnet-framework/net48
   - Or install Visual Studio 2019/2022 which includes it

3. **SQL Server**
   - SQL Server Express (free) or higher
   - Download from: https://www.microsoft.com/sql-server/sql-server-downloads

4. **Build Tools** (choose one):
   - **Option A**: Visual Studio 2019 or 2022 (Community Edition is free)
   - **Option B**: MSBuild (comes with Visual Studio or can be installed separately)

## Database Setup

### Step 1: Install SQL Server
1. Download and install SQL Server Express
2. During installation, note the instance name (usually `.\SQLEXPRESS`)
3. Enable SQL Server Browser service

### Step 2: Create Database
1. Open SQL Server Management Studio (SSMS) or any SQL client
2. Connect to your SQL Server instance
3. Run the `DatabaseSetup.sql` script located in the root directory
4. Verify that `BuildingPermitDB` database is created with three tables:
   - `BuildingPermitRequests`
   - `LandDirections`
   - `Sketches`

### Step 3: Configure Connection String
1. Open `PublicWorksAndRoads/App.config`
2. Update the connection string if needed:
   ```xml
   <connectionStrings>
     <add name="PublicWorksConnection" 
          connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=BuildingPermitDB;Integrated Security=True;TrustServerCertificate=True" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
3. Replace `.\SQLEXPRESS` with your SQL Server instance name if different

## Building the Application

### Option A: Using Visual Studio

1. **Open Solution**
   ```
   Double-click PublicWorksAndRoads.sln
   ```

2. **Restore NuGet Packages** (if any)
   - Right-click on the solution → Restore NuGet Packages

3. **Build Solution**
   - Press `Ctrl+Shift+B` or
   - Menu: Build → Build Solution

4. **Run Application**
   - Press `F5` or
   - Menu: Debug → Start Debugging

### Option B: Using MSBuild (Command Line)

1. **Open Developer Command Prompt**
   - Search for "Developer Command Prompt for VS 2019" or "Developer Command Prompt for VS 2022"
   - Or add MSBuild to your PATH

2. **Navigate to Project Directory**
   ```cmd
   cd path\to\nathem.1
   ```

3. **Build Solution**
   ```cmd
   msbuild PublicWorksAndRoads.sln /p:Configuration=Release
   ```

4. **Run Application**
   ```cmd
   PublicWorksAndRoads\bin\Release\PublicWorksAndRoads.exe
   ```

## Project Structure

```
nathem.1/
├── PublicWorksAndRoads/
│   ├── Models/                          # Data models
│   │   ├── BuildingPermitRequest.cs     # Main permit request model
│   │   ├── LandDirection.cs             # Direction data model
│   │   └── Sketch.cs                    # Sketch/image model
│   ├── Repositories/                    # Data access layer
│   │   ├── BuildingPermitRepository.cs  # CRUD for permits
│   │   ├── LandDirectionRepository.cs   # Direction management
│   │   └── SketchRepository.cs          # Sketch management
│   ├── Database.cs                      # Database connection helper
│   ├── FormMain.cs                      # Main application form
│   ├── FormBuildingPermit.cs            # Building permit form
│   ├── App.config                       # Configuration (connection string)
│   └── PublicWorksAndRoads.csproj       # Project file
├── DatabaseSetup.sql                    # Database creation script
├── BuildingPermitForm-README.md         # User guide (Arabic/English)
└── PublicWorksAndRoads.sln              # Solution file
```

## Running the Application

### First Time Setup
1. Build the application (see above)
2. Run the application
3. Click "اختبار الاتصال بقاعدة البيانات" (Test Database Connection)
4. If successful, you'll see "تم الاتصال بقاعدة البيانات بنجاح" message
5. Click "استمارة طلب ترخيص بناء" (Building Permit Form) to open the form

### Using the Building Permit Form

#### Main Interface
The form has 4 tabs:
1. **البيانات الأساسية** (Main Data) - Basic request information
2. **الاتجاهات** (Directions) - Four directions (North, South, East, West)
3. **الكروكي** (Sketch) - Upload and view sketch/image
4. **السجلات** (Records) - View and search all records

#### Adding a New Permit
1. Click "جديد" (New) button at the bottom
2. Fill in the required fields in all tabs
3. Upload a sketch image (optional)
4. Click "حفظ" (Save) button

#### Editing a Permit
1. Go to "السجلات" (Records) tab
2. Double-click on a record
3. Modify the fields
4. Click "حفظ" (Save)

#### Deleting a Permit
1. Select a record from the "السجلات" tab
2. Click "حذف" (Delete) button
3. Confirm the deletion

#### Searching
1. Go to "السجلات" tab
2. Enter search term (form number, applicant name, or request ID)
3. Click "بحث" (Search) button

#### Printing
1. Select a record
2. Click "طباعة" (Print) button
3. Choose printer and print settings

## Troubleshooting

### Build Errors

**Error: "The reference assemblies for .NETFramework,Version=v4.8 were not found"**
- Solution: Install .NET Framework 4.8 Developer Pack
- Download: https://dotnet.microsoft.com/download/dotnet-framework/net48

**Error: "Could not find System.Configuration"**
- Solution: The reference should be added automatically. If not:
  1. Right-click on References in Solution Explorer
  2. Add Reference → Assemblies → System.Configuration
  3. Check the box and click OK

### Database Errors

**Error: "Cannot open database BuildingPermitDB"**
- Solution 1: Run DatabaseSetup.sql to create the database
- Solution 2: Check if SQL Server is running
- Solution 3: Verify connection string in App.config

**Error: "Login failed for user"**
- Solution: Check SQL Server authentication mode
  1. Open SQL Server Configuration Manager
  2. Ensure SQL Server service is running
  3. If using SQL authentication, add username/password to connection string

**Error: "A network-related or instance-specific error occurred"**
- Solution 1: Check if SQL Server is running
- Solution 2: Enable TCP/IP protocol in SQL Server Configuration Manager
- Solution 3: Check firewall settings
- Solution 4: Verify instance name in connection string

### Runtime Errors

**Error: "Invalid object name 'BuildingPermitRequests'"**
- Solution: Run DatabaseSetup.sql to create the tables

**Error: "Cannot insert NULL into column"**
- Solution: The FormNumber field is required. Ensure it's filled before saving.

## Development Notes

### Architecture
- **Pattern**: Repository Pattern for data access
- **Database**: SQL Server with ADO.NET
- **UI**: WinForms with TabControl for organized layout
- **Security**: Parameterized queries to prevent SQL injection

### Key Features
- Full CRUD operations
- Four directions management (North, South, East, West)
- Image/sketch upload and display
- Search functionality
- Print support
- Cascade delete (deleting a request automatically deletes related directions and sketches)
- Arabic UI with RTL support

### Code Quality
- All database connections properly disposed using `using` statements
- NULL handling for optional fields
- Input validation on save
- Error handling with user-friendly messages

## Support

For issues or questions:
1. Check the troubleshooting section above
2. Review BuildingPermitForm-README.md for usage instructions
3. Contact the development team

## License
[Your License Here]

## Version
Version 1.0 - January 2026
