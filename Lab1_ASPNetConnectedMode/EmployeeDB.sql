USE [master]
GO
/****** Object:  Database [EmployeeDB]    Script Date: 2024-01-31 10:43:01 AM ******/
CREATE DATABASE [EmployeeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EmployeeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EmployeeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EmployeeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeDB] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EmployeeDB] SET QUERY_STORE = OFF
GO
USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2024-01-31 10:43:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JobTitle] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (1111, N'Mary', N'Brown', N'Java Programmer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (2222, N'John', N'Abbot', N'C# Programmer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (3333, N'Mary', N'Green', N'DB Programmer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (4444, N'Tom', N'Green', N'Programmer Analyst')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (5555, N'Mary', N'Green', N'Programmer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (6666, N'Henry', N'Brown', N'Programmer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (7777, N'Henry', N'Brown', N'Programmer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (8888, N'Henry', N'Green', N'Oracle Developer')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (9191, N'Julia', N'Brown', N'Programmer Analyst')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle]) VALUES (9999, N'Julia', N'White', N'System Analyst')
GO
USE [master]
GO
ALTER DATABASE [EmployeeDB] SET  READ_WRITE 
GO
