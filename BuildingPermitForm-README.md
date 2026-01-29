# استمارة طلب ترخيص بناء - Building Permit Form

## نظرة عامة - Overview
تم تطوير نظام شامل لإدارة طلبات تراخيص البناء في مشروع WinForms (.NET Framework 4.8).

A comprehensive building permit management system has been developed in a WinForms project (.NET Framework 4.8).

## المتطلبات - Requirements
- .NET Framework 4.8
- SQL Server (Express أو أعلى)
- Windows Operating System

## إعداد قاعدة البيانات - Database Setup

1. قم بتشغيل SQL Server
2. نفّذ السكربت `DatabaseSetup.sql` لإنشاء قاعدة البيانات والجداول
3. تأكد من إعدادات الاتصال في `App.config`:

```xml
<connectionStrings>
  <add name="PublicWorksConnection" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=BuildingPermitDB;Integrated Security=True;TrustServerCertificate=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

## مكونات النظام - System Components

### 1. النماذج - Models
- `BuildingPermitRequest`: بيانات طلب الترخيص الأساسية
- `LandDirection`: بيانات الاتجاهات الأربعة (شمال، جنوب، شرق، غرب)
- `Sketch`: بيانات الكروكي والصور

### 2. طبقة الوصول للبيانات - Data Access Layer
- `BuildingPermitRepository`: عمليات CRUD للطلبات
- `LandDirectionRepository`: إدارة بيانات الاتجاهات
- `SketchRepository`: إدارة الكروكيات

### 3. واجهة المستخدم - User Interface
- `FormMain`: الشاشة الرئيسية مع زر فتح استمارة الترخيص
- `FormBuildingPermit`: شاشة استمارة الترخيص الشاملة

## الميزات - Features

### العمليات المتاحة - Available Operations
1. **إضافة** - Add: إنشاء طلب ترخيص جديد
2. **تعديل** - Edit: تحديث طلب موجود
3. **حذف** - Delete: حذف طلب (مع العلاقات)
4. **بحث** - Search: البحث برقم الاستمارة أو اسم المقدم أو رقم الطلب
5. **عرض** - View: عرض جميع السجلات في جدول
6. **طباعة** - Print: طباعة استمارة الترخيص

### التبويبات - Tabs

#### 1. البيانات الأساسية - Main Data
- بيانات الجهة والمقدم
- بيانات المهندسين (مهندس المنطقة ومهندس المراجعة)
- بيانات الأرض والبناء (المساحات، الطوابق، المواد، إلخ)

#### 2. الاتجاهات - Directions
- **الجهة الشمالية** - North Direction
- **الجهة الجنوبية** - South Direction
- **الجهة الشرقية** - East Direction
- **الجهة الغربية** - West Direction

لكل اتجاه:
- حدود الأرض، بعد الأرض، بعد البناء
- الارتداد، نوع الشارع، رقم الشارع، عرض الشارع
- حدود الموقف، بعد الموقف، مساحة الموقف

#### 3. الكروكي - Sketch
- نوع الكروكي
- رفع صورة الكروكي
- عرض الكروكي

#### 4. السجلات - Records
- عرض جميع السجلات في جدول
- البحث في السجلات
- النقر المزدوج لعرض التفاصيل

## استخدام النظام - How to Use

### إضافة طلب جديد - Add New Request
1. انقر على زر "جديد" في الأسفل
2. املأ البيانات في التبويبات المختلفة
3. أضف بيانات الاتجاهات الأربعة
4. ارفع صورة الكروكي (اختياري)
5. انقر على "حفظ"

### تعديل طلب - Edit Request
1. انتقل إلى تبويب "السجلات"
2. انقر نقراً مزدوجاً على السجل المطلوب
3. قم بتعديل البيانات
4. انقر على "حفظ"

### حذف طلب - Delete Request
1. اختر السجل من تبويب "السجلات"
2. انقر على زر "حذف"
3. أكد عملية الحذف

### البحث - Search
1. انتقل إلى تبويب "السجلات"
2. أدخل رقم الاستمارة أو اسم المقدم أو رقم الطلب في حقل البحث
3. انقر على "بحث"

### الطباعة - Print
1. اختر السجل المطلوب
2. انقر على زر "طباعة"
3. اختر الطابعة وأكمل عملية الطباعة

## بنية المشروع - Project Structure
```
PublicWorksAndRoads/
├── Models/
│   ├── BuildingPermitRequest.cs
│   ├── LandDirection.cs
│   └── Sketch.cs
├── Repositories/
│   ├── BuildingPermitRepository.cs
│   ├── LandDirectionRepository.cs
│   └── SketchRepository.cs
├── FormMain.cs
├── FormBuildingPermit.cs
├── Database.cs
└── App.config
```

## ملاحظات تقنية - Technical Notes

### قاعدة البيانات - Database
- يتم استخدام `ON DELETE CASCADE` لضمان حذف جميع البيانات المرتبطة عند حذف طلب
- جميع الحقول النصية تدعم Unicode (NVARCHAR)
- الصور يتم تخزينها كـ VARBINARY(MAX)

### الأمان - Security
- استخدام Parameterized Queries لمنع SQL Injection
- استخدام `using` statements لضمان إغلاق الاتصالات

### الأداء - Performance
- فتح وإغلاق الاتصال في كل عملية
- استخدام SCOPE_IDENTITY() للحصول على ID المُدرج

## الدعم والصيانة - Support & Maintenance
للمساعدة أو الإبلاغ عن مشاكل، يرجى التواصل مع فريق التطوير.

For help or to report issues, please contact the development team.
