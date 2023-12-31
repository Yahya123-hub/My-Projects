USE [master]
GO
/****** Object:  Database [ProjectB]    Script Date: 3/11/2023 12:26:24 AM ******/
CREATE DATABASE [ProjectB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProjectB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProjectB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProjectB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectB', N'ON'
GO
ALTER DATABASE [ProjectB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProjectB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProjectB]
GO
/****** Object:  Table [dbo].[Assessment]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssessmentComponent]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentComponent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RubricId] [int] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[AssessmentId] [int] NOT NULL,
 CONSTRAINT [PK_AssessmentRubric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassAttendance]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ClassAttendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clo]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Clo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[LookupId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubric]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubric](
	[Id] [int] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[CloId] [int] NOT NULL,
 CONSTRAINT [PK_Rubric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RubricLevel]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RubricLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RubricId] [int] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[MeasurementLevel] [int] NOT NULL,
 CONSTRAINT [PK_RubricLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RegistrationNumber] [nvarchar](20) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendance](
	[AttendanceId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[AttendanceStatus] [int] NOT NULL,
 CONSTRAINT [PK_StudentAttendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 3/11/2023 12:26:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[StudentId] [int] NOT NULL,
	[AssessmentComponentId] [int] NOT NULL,
	[RubricMeasurementId] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentResult] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[AssessmentComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assessment] ON 

INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (2, N'quiztwo', CAST(N'2023-03-01T19:18:18.157' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (3, N'quizseven', CAST(N'2023-03-04T22:41:27.980' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (5, N'quizfive', CAST(N'2023-03-01T19:31:03.457' AS DateTime), 40, 39)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (7, N'quizsix', CAST(N'2023-03-01T19:33:06.127' AS DateTime), 24, 12)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (8, N'quizeight', CAST(N'2023-03-04T22:41:27.980' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1008, N'quizone', CAST(N'2023-03-08T15:38:25.637' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1009, N'quizthree', CAST(N'2023-03-08T15:38:25.637' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1010, N'quizfour', CAST(N'2023-03-08T15:38:25.637' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1011, N'quiznine', CAST(N'2023-03-08T15:38:57.587' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1012, N'quizten', CAST(N'2023-03-08T21:53:57.283' AS DateTime), 20, 20)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1013, N'quizeleven', CAST(N'2023-03-08T21:53:57.283' AS DateTime), 20, 20)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1014, N'quiztwelve', CAST(N'2023-03-08T21:53:57.283' AS DateTime), 20, 20)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1016, N'midterm', CAST(N'2023-03-08T21:56:25.460' AS DateTime), 30, 30)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (1017, N'quizthirteen', CAST(N'2023-03-08T21:58:33.673' AS DateTime), 20, 20)
SET IDENTITY_INSERT [dbo].[Assessment] OFF
GO
SET IDENTITY_INSERT [dbo].[AssessmentComponent] ON 

INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (14, N'test', 25, 10, CAST(N'2023-03-08T14:35:45.787' AS DateTime), CAST(N'2023-03-08T14:35:45.787' AS DateTime), 2)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (15, N'test', 26, 10, CAST(N'2023-03-08T14:35:45.787' AS DateTime), CAST(N'2023-03-08T14:35:45.787' AS DateTime), 3)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (16, N'testtwo', 39, 10, CAST(N'2023-03-08T14:35:45.787' AS DateTime), CAST(N'2023-03-08T14:37:53.370' AS DateTime), 5)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (19, N'testthree', 60, 10, CAST(N'2023-03-08T14:35:45.787' AS DateTime), CAST(N'2023-03-08T14:35:45.787' AS DateTime), 7)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (20, N'testthree', 64, 10, CAST(N'2023-03-08T14:35:45.787' AS DateTime), CAST(N'2023-03-08T14:35:45.787' AS DateTime), 8)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (21, N'testone', 72, 20, CAST(N'2023-03-08T15:41:39.420' AS DateTime), CAST(N'2023-03-08T15:41:39.420' AS DateTime), 1008)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (22, N'testone', 76, 20, CAST(N'2023-03-08T15:41:39.420' AS DateTime), CAST(N'2023-03-08T15:41:39.420' AS DateTime), 1009)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (23, N'testone', 82, 20, CAST(N'2023-03-08T15:41:39.420' AS DateTime), CAST(N'2023-03-08T15:41:39.420' AS DateTime), 1010)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (24, N'testone', 92, 20, CAST(N'2023-03-08T15:41:39.420' AS DateTime), CAST(N'2023-03-08T15:41:39.420' AS DateTime), 1011)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (25, N'mid', 35, 30, CAST(N'2023-03-08T22:03:20.010' AS DateTime), CAST(N'2023-03-08T22:03:20.010' AS DateTime), 1012)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (26, N'mid', 48, 30, CAST(N'2023-03-08T22:03:20.010' AS DateTime), CAST(N'2023-03-08T22:03:20.010' AS DateTime), 1013)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (27, N'mid', 52, 30, CAST(N'2023-03-08T22:03:20.010' AS DateTime), CAST(N'2023-03-08T22:03:20.010' AS DateTime), 1014)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (28, N'final', 94, 40, CAST(N'2023-03-08T22:06:29.123' AS DateTime), CAST(N'2023-03-08T22:06:29.123' AS DateTime), 1016)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (29, N'final', 24, 40, CAST(N'2023-03-08T22:06:29.123' AS DateTime), CAST(N'2023-03-08T22:06:29.123' AS DateTime), 1017)
SET IDENTITY_INSERT [dbo].[AssessmentComponent] OFF
GO
SET IDENTITY_INSERT [dbo].[ClassAttendance] ON 

INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (52, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (53, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (54, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (57, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (58, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (59, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (60, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (61, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (63, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (64, CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (65, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (66, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ClassAttendance] OFF
GO
SET IDENTITY_INSERT [dbo].[Clo] ON 

INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (8, N'Comprehension', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:49:28.347' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (9, N'Knowledge', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:49:38.430' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (10, N'Application', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:51:43.470' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (11, N'Synthesis', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:49:54.977' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1009, N'Evaluation', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:51:37.747' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1010, N'Analysis', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:48:21.330' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1011, N'Discipline', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:51:48.200' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1012, N'OOD', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:48:21.330' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1013, N'Accreditation', CAST(N'2023-03-06T18:48:21.330' AS DateTime), CAST(N'2023-03-06T18:48:21.330' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1014, N'Comprehensiontwo', CAST(N'2023-03-08T21:59:30.820' AS DateTime), CAST(N'2023-03-08T21:59:30.820' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1015, N'ITC', CAST(N'2023-03-08T21:59:30.820' AS DateTime), CAST(N'2023-03-08T21:59:30.820' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1016, N'DigitalMarketing', CAST(N'2023-03-08T21:59:30.820' AS DateTime), CAST(N'2023-03-08T21:59:30.820' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1017, N'Communication', CAST(N'2023-03-08T22:05:31.160' AS DateTime), CAST(N'2023-03-08T22:05:31.160' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1018, N'DLD', CAST(N'2023-03-08T22:05:31.160' AS DateTime), CAST(N'2023-03-08T22:05:31.160' AS DateTime))
SET IDENTITY_INSERT [dbo].[Clo] OFF
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (1, N'Present', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (2, N'Absent', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (3, N'Leave', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (4, N'Late', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (5, N'Active', N'STUDENT_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (6, N'InActive', N'STUDENT_STATUS')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (24, N'seven', 1017)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (25, N'two', 9)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (26, N'one', 1013)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (35, N'four', 1014)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (39, N'one', 1011)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (48, N'five', 1015)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (52, N'six', 1016)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (60, N'one', 10)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (64, N'three', 1009)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (72, N'two', 1010)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (76, N'one', 11)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (82, N'one', 1012)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (92, N'one', 8)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (94, N'eight', 1018)
GO
SET IDENTITY_INSERT [dbo].[RubricLevel] ON 

INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (11, 25, N'two', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (17, 82, N'five', 3)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (20, 39, N'one', 4)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (21, 26, N'two', 5)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (22, 60, N'two', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (23, 64, N'two', 6)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (24, 72, N'two', 8)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (25, 76, N'two', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (26, 92, N'two', 10)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (27, 52, N'two', 10)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (28, 48, N'two', 10)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (29, 35, N'two', 10)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (30, 94, N'six', 7)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (31, 24, N'six', 7)
SET IDENTITY_INSERT [dbo].[RubricLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1024, N'Hashir', N'Husnain', N'03287787899', N'hashir@gmail.com', N'2021-CS-1', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1026, N'Shahzaib', N'Rafi', N'03256567878', N'shahzaib@gmail.com', N'2021-CS-2', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1027, N'Shakeel', N'Ahmed', N'03234567878', N'shakeel@gmail.com', N'2021-CS-3', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1028, N'Kabir', N'Ahmed', N'03251967878', N'kabir@gmail.com', N'2021-CS-4', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2027, N'Mahnoor', N'Fatima', N'03234567878', N'mahnoor@gmail.com', N'2021-CS-5', 6)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2028, N'Shahzaib', N'Irfan', N'03256567878', N'shahzaibl@gmail.com', N'2021-CS-7', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2029, N'Muhammad', N'Nazir', N'03222567878', N'nazir@gmail.com', N'2021-CS-8', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2030, N'Ayesha', N'Nadeem', N'03233567878', N'ayesha@gmail.com', N'2021-CS-9', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2031, N'Yahya', N'Mirza', N'03299567878', N'yahya@gmail.com', N'2021-CS-11', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2032, N'Afraz', N'Butt', N'03276567878', N'afraz@gmail.com', N'2021-CS-12', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2033, N'Subhan', N'Anjum', N'03288567878', N'anjum@gmail.com', N'2021-CS-13', 6)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2034, N'Fahad', N'Khan', N'03289567878', N'fahad@gmail.com', N'2021-CS-14', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2035, N'Shahbaz', N'Rafiq', N'03201567878', N'shahbaz@gmail.com', N'2021-CS-15', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2036, N'Muhammad', N'Umar', N'03296567878', N'umer@gmail.com', N'2021-CS-16', 5)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (52, 1024, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (53, 1026, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (54, 1027, 3)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (57, 2029, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (58, 2030, 3)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (59, 2031, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (60, 2032, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (61, 2034, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (63, 2036, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (64, 2035, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (65, 2028, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (66, 1028, 2)
GO
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1024, 14, 11, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1026, 15, 17, CAST(N'2023-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1027, 16, 20, CAST(N'2023-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1028, 19, 21, CAST(N'2023-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2027, 20, 22, CAST(N'2023-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2028, 21, 23, CAST(N'2023-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2029, 22, 24, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2030, 23, 25, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2031, 24, 26, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2032, 25, 27, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2033, 26, 28, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2034, 27, 29, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2035, 28, 30, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2036, 29, 31, CAST(N'2023-03-08T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[AssessmentComponent]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentComponent_Assessment] FOREIGN KEY([AssessmentId])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[AssessmentComponent] CHECK CONSTRAINT [FK_AssessmentComponent_Assessment]
GO
ALTER TABLE [dbo].[AssessmentComponent]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentComponent_Rubric] FOREIGN KEY([RubricId])
REFERENCES [dbo].[Rubric] ([Id])
GO
ALTER TABLE [dbo].[AssessmentComponent] CHECK CONSTRAINT [FK_AssessmentComponent_Rubric]
GO
ALTER TABLE [dbo].[Rubric]  WITH CHECK ADD  CONSTRAINT [FK_Rubric_Clo] FOREIGN KEY([CloId])
REFERENCES [dbo].[Clo] ([Id])
GO
ALTER TABLE [dbo].[Rubric] CHECK CONSTRAINT [FK_Rubric_Clo]
GO
ALTER TABLE [dbo].[RubricLevel]  WITH CHECK ADD  CONSTRAINT [FK_RubricLevel_Rubric] FOREIGN KEY([RubricId])
REFERENCES [dbo].[Rubric] ([Id])
GO
ALTER TABLE [dbo].[RubricLevel] CHECK CONSTRAINT [FK_RubricLevel_Rubric]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_ClassAttendance] FOREIGN KEY([AttendanceId])
REFERENCES [dbo].[ClassAttendance] ([Id])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_ClassAttendance]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Lookup] FOREIGN KEY([AttendanceStatus])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Student]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_AssessmentComponent] FOREIGN KEY([AssessmentComponentId])
REFERENCES [dbo].[AssessmentComponent] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_AssessmentComponent]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_RubricLevel] FOREIGN KEY([RubricMeasurementId])
REFERENCES [dbo].[RubricLevel] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_RubricLevel]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Student]
GO
USE [master]
GO
ALTER DATABASE [ProjectB] SET  READ_WRITE 
GO
