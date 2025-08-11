-- Create SocialClubDB Database
CREATE DATABASE SocialClubDB;
GO

-- Use the SocialClubDB database
USE SocialClubDB;
GO

-- Create ClubMembership table
CREATE TABLE ClubMembership (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    ClubName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    MembershipFee DECIMAL(10,2) NOT NULL
);
GO

-- Insert sample data for testing (optional)
INSERT INTO ClubMembership (FullName, ClubName, Age, MembershipFee) VALUES
('John Smith', 'Blue Sky', 22, 150.00),
('Sarah Johnson', 'Rotary', 25, 200.00),
('Mike Brown', 'Red Hat', 21, 175.50);
GO

-- Select all records to verify
SELECT * FROM ClubMembership;
GO 