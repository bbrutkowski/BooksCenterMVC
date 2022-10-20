﻿--1
CREATE DATABASE BooksCenter;
--2
USE[BooksCenter];
--3
CREATE TABLE[Customers] (
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Name] VARCHAR(255) UNIQUE,
[Email] VARCHAR(255) UNIQUE NOT NULL,
[Password] VARCHAR(255) CHECK(LEN(Password) <= 5) NOT NULL,
);
--4
CREATE TABLE[Authors] (
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Name] VARCHAR(255) NOT NULL,
[Surname] VARCHAR(255) NOT NULL,
[YearOfBirth] INT 
);
--5
CREATE TABLE[Books] (
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Title] VARCHAR(255) NOT NULL,
[AuthorId] INT FOREIGN KEY ([AuthorId]) REFERENCES[Authors]([Id]) NOT NULL,
[isAvailable] BIT,
[Price] FLOAT(8)
);