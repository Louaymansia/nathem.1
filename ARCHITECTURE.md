# Building Permit System - Architecture Overview

## System Architecture

```
┌─────────────────────────────────────────────────────────────────┐
│                        User Interface Layer                      │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌──────────────┐         ┌───────────────────────────────┐    │
│  │              │         │                                │    │
│  │   FormMain   │────────>│   FormBuildingPermit          │    │
│  │              │         │                                │    │
│  │  - Test DB   │         │  Tabs:                         │    │
│  │  - Open Form │         │  1. Main Data (البيانات)      │    │
│  │              │         │  2. Directions (الاتجاهات)    │    │
│  └──────────────┘         │  3. Sketch (الكروكي)           │    │
│                            │  4. Records (السجلات)         │    │
│                            │                                │    │
│                            │  Actions:                      │    │
│                            │  - New/Save/Delete             │    │
│                            │  - Search/Print                │    │
│                            └───────────────────────────────┘    │
│                                          │                       │
└──────────────────────────────────────────┼───────────────────────┘
                                           │
                                           ▼
┌─────────────────────────────────────────────────────────────────┐
│                     Business Logic Layer                         │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌──────────────────────┐  ┌──────────────────────┐            │
│  │ BuildingPermit       │  │ LandDirection        │            │
│  │ Repository           │  │ Repository           │            │
│  │                      │  │                      │            │
│  │ - Insert()           │  │ - Insert()           │            │
│  │ - Update()           │  │ - Update()           │            │
│  │ - Delete()           │  │ - DeleteByRequestId()│            │
│  │ - GetById()          │  │ - GetByRequestId()   │            │
│  │ - Search()           │  │                      │            │
│  │ - GetAll()           │  │                      │            │
│  └──────────────────────┘  └──────────────────────┘            │
│                                                                   │
│                    ┌──────────────────────┐                     │
│                    │ Sketch               │                     │
│                    │ Repository           │                     │
│                    │                      │                     │
│                    │ - Insert()           │                     │
│                    │ - Update()           │                     │
│                    │ - DeleteByRequestId()│                     │
│                    │ - GetByRequestId()   │                     │
│                    └──────────────────────┘                     │
│                             │                                    │
└─────────────────────────────┼────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                        Data Access Layer                         │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌──────────────────────────────────────────────────────────┐  │
│  │                    Database.cs                            │  │
│  │                                                            │  │
│  │  CreateConnection()                                        │  │
│  │  ↓                                                         │  │
│  │  Returns: SqlConnection                                    │  │
│  │  Connection String from App.config                         │  │
│  └──────────────────────────────────────────────────────────┘  │
│                             │                                    │
└─────────────────────────────┼────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                        Database Layer                            │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│                    BuildingPermitDB (SQL Server)                 │
│                                                                   │
│  ┌────────────────────────────────────────────────────────┐    │
│  │  BuildingPermitRequests (Main Table)                    │    │
│  │  ─────────────────────────────────────────────────────  │    │
│  │  - RequestId (PK)                                        │    │
│  │  - EntityName, FormNumber, ApplicantName...             │    │
│  │  - 30 fields total                                       │    │
│  └────────────────────────────────────────────────────────┘    │
│                      │              │                            │
│         ┌────────────┴──────┐      └──────────┐                │
│         │                   │                  │                │
│         ▼                   ▼                  ▼                │
│  ┌────────────────┐  ┌────────────────┐  ┌─────────────┐      │
│  │ LandDirections │  │   Sketches     │  │   CASCADE   │      │
│  │                │  │                │  │   DELETE    │      │
│  │ - DirectionId  │  │ - SketchId     │  │             │      │
│  │ - RequestId(FK)│  │ - RequestId(FK)│  │  Automatic  │      │
│  │ - North        │  │ - SketchType   │  │  cleanup of │      │
│  │ - South        │  │ - SketchImage  │  │  related    │      │
│  │ - East         │  │   (VARBINARY)  │  │  records    │      │
│  │ - West         │  │                │  │             │      │
│  └────────────────┘  └────────────────┘  └─────────────┘      │
│                                                                   │
└─────────────────────────────────────────────────────────────────┘
```

## Data Models

### BuildingPermitRequest
```
┌─────────────────────────────────────────┐
│     BuildingPermitRequest Model          │
├─────────────────────────────────────────┤
│ • RequestId: int (PK)                    │
│ • EntityName: string                     │
│ • FormNumber: string                     │
│ • ApplicantName: string                  │
│ • ApplicantPhone: string                 │
│ • LicenseType: string                    │
│ • RegionName: string                     │
│ • UnitName: string                       │
│ • BuildFloor: string                     │
│ • ApplicantSignature: string             │
│ • AreaEngineerName: string               │
│ • AreaEngineerSignature: string          │
│ • ReviewEngineerName: string             │
│ • ReviewEngineerSignature: string        │
│ • LandAreaSurvey: decimal?               │
│ • LandAreaProjection: decimal?           │
│ • BuildingArea: decimal?                 │
│ • ExistingBuilding: string               │
│ • LicensedMaterialPrev: string           │
│ • LicensePurpose: string                 │
│ • BlockType: string                      │
│ • FloorsToLicense: string                │
│ • LicensedMaterial: string               │
│ • PreviousShopOpenings: int?             │
│ • RequestedShopOpenings: int?            │
│ • ParkingAreaTotal: decimal?             │
│ • LandLayer: string                      │
│ • Curb: string                           │
│ • MiddleSetback: string                  │
│ • LandLocationFromFlood: string          │
│ • CreatedAt: DateTime                    │
└─────────────────────────────────────────┘
```

### LandDirection
```
┌─────────────────────────────────────────┐
│        LandDirection Model               │
├─────────────────────────────────────────┤
│ • DirectionId: int (PK)                  │
│ • RequestId: int (FK)                    │
│ • DirectionName: string                  │
│   (شمال/جنوب/شرق/غرب)                   │
│ • LandBoundary: string                   │
│ • LandDimension: decimal?                │
│ • BuildingDimension: decimal?            │
│ • BuildingSetback: decimal?              │
│ • StreetType: string                     │
│ • StreetNumber: string                   │
│ • StreetWidth: decimal?                  │
│ • ParkingBoundary: string                │
│ • ParkingDimension: decimal?             │
│ • ParkingArea: decimal?                  │
└─────────────────────────────────────────┘
```

### Sketch
```
┌─────────────────────────────────────────┐
│            Sketch Model                  │
├─────────────────────────────────────────┤
│ • SketchId: int (PK)                     │
│ • RequestId: int (FK)                    │
│ • SketchType: string                     │
│ • SketchImage: byte[]                    │
└─────────────────────────────────────────┘
```

## Data Flow

### Adding a New Permit
```
User clicks "جديد" (New)
    ↓
FormBuildingPermit.ButtonNew_Click()
    ↓
ClearForm() - Reset all fields
    ↓
User fills data in 4 tabs
    ↓
User clicks "حفظ" (Save)
    ↓
FormBuildingPermit.ButtonSave_Click()
    ↓
Create BuildingPermitRequest object
    ↓
BuildingPermitRepository.Insert()
    ↓
Returns RequestId
    ↓
For each direction (4x):
    Create LandDirection object
    ↓
    LandDirectionRepository.Insert()
    ↓
If sketch uploaded:
    Create Sketch object
    ↓
    SketchRepository.Insert()
    ↓
LoadAllRecords() - Refresh grid
    ↓
Show success message
```

### Searching Records
```
User enters search term
    ↓
User clicks "بحث" (Search)
    ↓
FormBuildingPermit.ButtonSearch_Click()
    ↓
BuildingPermitRepository.Search(searchTerm)
    ↓
SQL: SELECT * WHERE FormNumber LIKE '%term%'
     OR ApplicantName LIKE '%term%'
     OR RequestId LIKE '%term%'
    ↓
Return List<BuildingPermitRequest>
    ↓
Bind to DataGridView
    ↓
Display results
```

### Loading a Record
```
User double-clicks on record in grid
    ↓
FormBuildingPermit.DataGridViewRecords_CellDoubleClick()
    ↓
Get RequestId from selected row
    ↓
BuildingPermitRepository.GetById(requestId)
    ↓
Load main data into form fields
    ↓
LandDirectionRepository.GetByRequestId(requestId)
    ↓
Load 4 directions into respective fields
    ↓
SketchRepository.GetByRequestId(requestId)
    ↓
Load sketch image into PictureBox
    ↓
Set _isEditMode = true
```

## Security Features

1. **SQL Injection Prevention**
   - All queries use parameterized commands
   - No string concatenation for SQL queries

2. **Connection Management**
   - All connections wrapped in `using` statements
   - Automatic disposal prevents connection leaks

3. **Data Validation**
   - Required field validation (FormNumber)
   - Type validation (decimal, int parsing)
   - NULL handling for optional fields

4. **Error Handling**
   - Try-catch blocks around database operations
   - User-friendly error messages in Arabic
   - Detailed error information for debugging

## Performance Considerations

1. **Database Operations**
   - Open/close connections per operation (prevents connection leaks)
   - Use of SCOPE_IDENTITY() for efficient ID retrieval
   - Cascade delete eliminates need for manual cleanup

2. **UI Performance**
   - TabControl prevents loading all controls at once
   - DataGridView with selective column display
   - Image loading on-demand (not preloaded)

3. **Memory Management**
   - Proper disposal of database resources
   - Image stream disposal after loading
   - Form disposal on close

## Future Enhancements

1. **Features**
   - Export to PDF
   - Email integration
   - Digital signatures
   - Document versioning
   - Audit trail

2. **Technical**
   - Move to Entity Framework
   - Add unit tests
   - Implement caching
   - Add logging framework
   - Multi-language support

3. **UI**
   - Modern UI framework (MaterialSkin, MetroFramework)
   - Responsive design
   - Dark mode
   - Customizable reports
