--CREATE DATABASE [OfficeP32];

USE OfficeP32;

-- DROP TABLE Employee;

CREATE TABLE [Employee]
(
    [Id]         INT          NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Name]       VARCHAR(150) NOT NULL,
    [Phone]      VARCHAR(10) UNIQUE,
    [Email]      VARCHAR(100) UNIQUE,
    [PositionId] INT,
    FOREIGN KEY ([PositionId]) REFERENCES Position ([Id])
);


CREATE TABLE [Position]
(
    [Id]   INT          NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Name] VARCHAR(150) NOT NULL
);

CREATE TABLE [Skills]
(
    [Id]   INT          NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Name] VARCHAR(150) NOT NULL
);

ALTER TABLE Employee
    ADD [SkillsId] INT;

ALTER TABLE Employee
    ADD FOREIGN KEY ([SkillsId]) REFERENCES Skills ([Id]);

CREATE TABLE [Client]
(
    [Id]    INT          NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Name]  VARCHAR(150) NOT NULL,
    [Phone] VARCHAR(10),
    [Email] VARCHAR(100)
);

CREATE TABLE [EmployeeClient](
    [Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [ClientId] INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    FOREIGN KEY ([ClientId]) REFERENCES Client([Id]),
    FOREIGN KEY (EmployeeId) REFERENCES Employee([Id])
);




-- VIEWS 
SELECT * FROM View_1;
Select * from View_2;

-- PROCEDURES

EXECUTE GetAllEmployees;

EXEC GetMaxSalary @CurrentSalary = 1000;









