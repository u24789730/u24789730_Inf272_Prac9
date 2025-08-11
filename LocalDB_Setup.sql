-- LocalDB Setup for SocialClubDB
-- Run this in SQL Server Management Studio connected to (LocalDB)\MSSQLLocalDB

-- Create the database with explicit file path
CREATE DATABASE SocialClubDB
ON (
    NAME = 'SocialClubDB',
    FILENAME = 'C:\Users\Hamza Suleman\OneDrive\Desktop\Bcom Informatics 2025\Inf272\Prac Submissions\u24789730_Inf272_Prac9\App_Data\SocialClubDB.mdf'
)
LOG ON (
    NAME = 'SocialClubDB_Log',
    FILENAME = 'C:\Users\Hamza Suleman\OneDrive\Desktop\Bcom Informatics 2025\Inf272\Prac Submissions\u24789730_Inf272_Prac9\App_Data\SocialClubDB_Log.ldf'
);
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

-- Insert sample data
INSERT INTO ClubMembership (FullName, ClubName, Age, MembershipFee) VALUES
('John Smith', 'Blue Sky', 22, 150.00),
('Sarah Johnson', 'Rotary', 25, 200.00),
('Mike Brown', 'Red Hat', 21, 175.50);
GO

SELECT * FROM ClubMembership;
GO 