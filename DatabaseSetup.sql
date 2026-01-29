-- Database Setup Script for Building Permit System
-- This script creates the database and required tables

-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BuildingPermitDB')
BEGIN
    CREATE DATABASE BuildingPermitDB;
END
GO

USE BuildingPermitDB;
GO

-- Create BuildingPermitRequests Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BuildingPermitRequests')
BEGIN
    CREATE TABLE BuildingPermitRequests (
        RequestId INT PRIMARY KEY IDENTITY(1,1),
        EntityName NVARCHAR(200),
        FormNumber NVARCHAR(100),
        ApplicantName NVARCHAR(200),
        ApplicantPhone NVARCHAR(50),
        LicenseType NVARCHAR(100),
        RegionName NVARCHAR(200),
        UnitName NVARCHAR(200),
        BuildFloor NVARCHAR(100),
        ApplicantSignature NVARCHAR(200),
        AreaEngineerName NVARCHAR(200),
        AreaEngineerSignature NVARCHAR(200),
        ReviewEngineerName NVARCHAR(200),
        ReviewEngineerSignature NVARCHAR(200),
        LandAreaSurvey DECIMAL(18,2),
        LandAreaProjection DECIMAL(18,2),
        BuildingArea DECIMAL(18,2),
        ExistingBuilding NVARCHAR(200),
        LicensedMaterialPrev NVARCHAR(500),
        LicensePurpose NVARCHAR(500),
        BlockType NVARCHAR(100),
        FloorsToLicense NVARCHAR(200),
        LicensedMaterial NVARCHAR(500),
        PreviousShopOpenings INT,
        RequestedShopOpenings INT,
        ParkingAreaTotal DECIMAL(18,2),
        LandLayer NVARCHAR(200),
        Curb NVARCHAR(200),
        MiddleSetback NVARCHAR(200),
        LandLocationFromFlood NVARCHAR(200),
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Create LandDirections Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LandDirections')
BEGIN
    CREATE TABLE LandDirections (
        DirectionId INT PRIMARY KEY IDENTITY(1,1),
        RequestId INT NOT NULL,
        DirectionName NVARCHAR(50) NOT NULL,
        LandBoundary NVARCHAR(200),
        LandDimension DECIMAL(18,2),
        BuildingDimension DECIMAL(18,2),
        BuildingSetback DECIMAL(18,2),
        StreetType NVARCHAR(100),
        StreetNumber NVARCHAR(50),
        StreetWidth DECIMAL(18,2),
        ParkingBoundary NVARCHAR(200),
        ParkingDimension DECIMAL(18,2),
        ParkingArea DECIMAL(18,2),
        CONSTRAINT FK_LandDirections_BuildingPermitRequests 
            FOREIGN KEY (RequestId) 
            REFERENCES BuildingPermitRequests(RequestId)
            ON DELETE CASCADE
    );
END
GO

-- Create Sketches Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Sketches')
BEGIN
    CREATE TABLE Sketches (
        SketchId INT PRIMARY KEY IDENTITY(1,1),
        RequestId INT NOT NULL,
        SketchType NVARCHAR(100),
        SketchImage VARBINARY(MAX),
        CONSTRAINT FK_Sketches_BuildingPermitRequests 
            FOREIGN KEY (RequestId) 
            REFERENCES BuildingPermitRequests(RequestId)
            ON DELETE CASCADE
    );
END
GO

PRINT 'Database and tables created successfully!';
