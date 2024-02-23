USE [master]
GO
/****** Object:  Database [StudentProjectsDB]    Script Date: 2024-02-19 6:19:04 PM ******/
CREATE DATABASE [StudentProjectsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentProjectsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StudentProjectsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentProjectsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StudentProjectsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StudentProjectsDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentProjectsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentProjectsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentProjectsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentProjectsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentProjectsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentProjectsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentProjectsDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudentProjectsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentProjectsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentProjectsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentProjectsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentProjectsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentProjectsDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StudentProjectsDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [StudentProjectsDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StudentProjectsDB]
GO
/****** Object:  Table [dbo].[ProjectAssignments]    Script Date: 2024-02-19 6:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAssignments](
	[ProjectCode] [nvarchar](6) NOT NULL,
	[StudentId] [int] NOT NULL,
	[AssignedDate] [date] NOT NULL,
	[SubmittedDate] [date] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_ProjectAssignments] PRIMARY KEY CLUSTERED 
(
	[ProjectCode] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 2024-02-19 6:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectCode] [nvarchar](6) NOT NULL,
	[ProjectTitle] [nvarchar](50) NOT NULL,
	[DueDate] [date] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2024-02-19 6:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 2024-02-19 6:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ProjectAssignments] ([ProjectCode], [StudentId], [AssignedDate], [SubmittedDate], [Grade]) VALUES (N'PRJ101', 1111111, CAST(N'2023-09-10' AS Date), CAST(N'2024-02-05' AS Date), 90)
GO
INSERT [dbo].[Projects] ([ProjectCode], [ProjectTitle], [DueDate]) VALUES (N'PRJ101', N'Property Rental Web App', CAST(N'2024-04-19' AS Date))
INSERT [dbo].[Projects] ([ProjectCode], [ProjectTitle], [DueDate]) VALUES (N'PRJ102', N'Order Management in C#', CAST(N'2024-04-10' AS Date))
INSERT [dbo].[Projects] ([ProjectCode], [ProjectTitle], [DueDate]) VALUES (N'PRJ103', N'Calculator in C++', CAST(N'2024-03-20' AS Date))
INSERT [dbo].[Projects] ([ProjectCode], [ProjectTitle], [DueDate]) VALUES (N'PRJ104', N'Online Course Registration', CAST(N'2024-04-25' AS Date))
GO
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Password]) VALUES (1111111, N'Mary', N'Brown', N'1111Mary')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Password]) VALUES (2222222, N'Laura', N'White', N'2222Laura')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Password]) VALUES (3333333, N'Richard', N'Moore', N'3333Richard')
GO
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Password]) VALUES (11111, N'Marie', N'Brown', N'11111Marie')
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Password]) VALUES (22222, N'Laura', N'White', N'22222Laura')
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Password]) VALUES (33333, N'Thomas', N'Moore', N'33333Thomas')
GO
ALTER TABLE [dbo].[ProjectAssignments]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssignments_Projects] FOREIGN KEY([ProjectCode])
REFERENCES [dbo].[Projects] ([ProjectCode])
GO
ALTER TABLE [dbo].[ProjectAssignments] CHECK CONSTRAINT [FK_ProjectAssignments_Projects]
GO
ALTER TABLE [dbo].[ProjectAssignments]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssignments_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[ProjectAssignments] CHECK CONSTRAINT [FK_ProjectAssignments_Students]
GO
USE [master]
GO
ALTER DATABASE [StudentProjectsDB] SET  READ_WRITE 
GO
