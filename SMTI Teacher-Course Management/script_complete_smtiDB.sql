USE [master]
GO
/****** Object:  Database [smtiDB]    Script Date: 2024-02-21 9:38:30 AM ******/
CREATE DATABASE [smtiDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'smtiDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\smtiDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'smtiDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\smtiDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [smtiDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [smtiDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [smtiDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [smtiDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [smtiDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [smtiDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [smtiDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [smtiDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [smtiDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [smtiDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [smtiDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [smtiDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [smtiDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [smtiDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [smtiDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [smtiDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [smtiDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [smtiDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [smtiDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [smtiDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [smtiDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [smtiDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [smtiDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [smtiDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [smtiDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [smtiDB] SET  MULTI_USER 
GO
ALTER DATABASE [smtiDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [smtiDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [smtiDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [smtiDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [smtiDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [smtiDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [smtiDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [smtiDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [smtiDB]
GO
/****** Object:  Table [dbo].[CourseAssignments]    Script Date: 2024-02-21 9:38:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignments](
	[EmployeeNumber] [int] NOT NULL,
	[CourseCode] [nvarchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC,
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2024-02-21 9:38:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseCode] [nvarchar](8) NOT NULL,
	[CourseTitle] [nvarchar](100) NULL,
	[TotalHour] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2024-02-21 9:38:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeNumber] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Title] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 2024-02-21 9:38:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupNumber] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024-02-21 9:38:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [int] NOT NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP101', N'Introduction to C# Programing', 75)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP102', N'Advanced Programming in C#', 75)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP103', N'Web Applications I', 90)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP104', N'Web Applications II', 90)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP105', N'Web Applications III', 90)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP201', N'Python Programming I', 75)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP202', N'Python Programming II', 75)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP203', N'Python Programming III', 90)
GO
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [Title]) VALUES (1234, N'Mary', N'Brown', N'Teacher')
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [Title]) VALUES (1235, N'Richard', N'Green', N'Teacher')
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [Title]) VALUES (1236, N'Michael', N'Freitag', N'Teacher')
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [Title]) VALUES (4444, N'David', N'Cadieux', N'Program Coordinator')
GO
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7122, N'DEC Networking')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7123, N'DEC Programmation')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7124, N'AEC Programming')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7125, N'AEC Réseaux')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7126, N'DEC Networking')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7127, N'DEC Programmation')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7128, N'AEC Programming')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7129, N'AEC Programmation')
GO
INSERT [dbo].[Users] ([Username], [Password]) VALUES (1234, N'Mary1234')
INSERT [dbo].[Users] ([Username], [Password]) VALUES (1235, N'Richard1235')
INSERT [dbo].[Users] ([Username], [Password]) VALUES (1236, N'Michael1236')
INSERT [dbo].[Users] ([Username], [Password]) VALUES (4444, N'David44444')
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD  CONSTRAINT [FK_CA_CourseCode] FOREIGN KEY([CourseCode])
REFERENCES [dbo].[Courses] ([CourseCode])
GO
ALTER TABLE [dbo].[CourseAssignments] CHECK CONSTRAINT [FK_CA_CourseCode]
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD  CONSTRAINT [FK_CA_EmployeeNumber] FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[CourseAssignments] CHECK CONSTRAINT [FK_CA_EmployeeNumber]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
USE [master]
GO
ALTER DATABASE [smtiDB] SET  READ_WRITE 
GO
