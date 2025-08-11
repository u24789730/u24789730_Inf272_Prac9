-- Simple Database Creation Script
-- Run this in SQL Server Management Studio
-- Connect to: (LocalDB)\MSSQLLocalDB

-- Drop database if it exists (to avoid conflicts)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'SocialClubDB')
BEGIN
    ALTER DATABASE SocialClubDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SocialClubDB;
END
GO

-- Create the database
CREATE DATABASE SocialClubDB;
GO

-- Use the database
USE SocialClubDB;
GO

-- Create the table
CREATE TABLE ClubMembership (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    ClubName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    MembershipFee DECIMAL(10,2) NOT NULL
);
GO

-- Insert sample data for testing
INSERT INTO ClubMembership (FullName, ClubName, Age, MembershipFee) VALUES
('John Smith', 'Blue Sky', 22, 150.00),
('Sarah Johnson', 'Rotary', 25, 200.00),
('Mike Brown', 'Red Hat', 21, 175.50);
GO

-- Verify the data
SELECT * FROM ClubMembership;
GO

PRINT 'Database SocialClubDB created successfully!'; 