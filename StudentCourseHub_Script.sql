IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentCourse]') AND type in (N'U'))
ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT IF EXISTS [FK_StudentCourse_StudentCourse]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentCourse]') AND type in (N'U'))
ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT IF EXISTS [FK_StudentCourse_Course]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U'))
ALTER TABLE [dbo].[Course] DROP CONSTRAINT IF EXISTS [FK_Course_Instructor]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 2020-06-01 8:01:23 PM ******/
DROP TABLE IF EXISTS [dbo].[StudentCourse]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2020-06-01 8:01:23 PM ******/
DROP TABLE IF EXISTS [dbo].[Student]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 2020-06-01 8:01:23 PM ******/
DROP TABLE IF EXISTS [dbo].[Instructor]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2020-06-01 8:01:23 PM ******/
DROP TABLE IF EXISTS [dbo].[Course]
GO
/****** Object:  Database [StudentCourseHub]    Script Date: 2020-06-01 8:01:23 PM ******/
DROP DATABASE IF EXISTS [StudentCourseHub]
GO
/****** Object:  Database [StudentCourseHub]    Script Date: 2020-06-01 8:01:23 PM ******/
CREATE DATABASE [StudentCourseHub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseHub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CourseHub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CourseHub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CourseHub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentCourseHub] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentCourseHub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentCourseHub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentCourseHub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentCourseHub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentCourseHub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentCourseHub] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentCourseHub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentCourseHub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentCourseHub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentCourseHub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentCourseHub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentCourseHub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentCourseHub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentCourseHub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentCourseHub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentCourseHub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentCourseHub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentCourseHub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentCourseHub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentCourseHub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentCourseHub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentCourseHub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentCourseHub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentCourseHub] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentCourseHub] SET  MULTI_USER 
GO
ALTER DATABASE [StudentCourseHub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentCourseHub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentCourseHub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentCourseHub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentCourseHub] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentCourseHub', N'ON'
GO
ALTER DATABASE [StudentCourseHub] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2020-06-01 8:01:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseTitle] [varchar](30) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Campus] [varchar](50) NOT NULL,
	[InstructorId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 2020-06-01 8:01:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[MiddleName] [varchar](30) NULL,
	[LastName] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Phone] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2020-06-01 8:01:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[MiddleName] [varchar](30) NULL,
	[LastName] [varchar](30) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Phone] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 2020-06-01 8:01:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Description], [Campus], [InstructorId]) VALUES (1, N'JavaScript Programming', N'In this course, students study the JavaScript programming language and become familiar with some fundamental programming concepts.', N'Moncton', 2)
GO
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Description], [Campus], [InstructorId]) VALUES (5, N'Introduction to Networks', N'This course introduces students to fundamental networking concepts and technologies including architecture, structure, functions and components.', N'Moncton', 6)
GO
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Description], [Campus], [InstructorId]) VALUES (9, N'Responsive Web Design', N'Responsive Web Design is a web design approach aimed at providing optimal viewing across a wide variety of devices from desktop computers to mobile devices.', N'Moncton', 4)
GO
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Description], [Campus], [InstructorId]) VALUES (10, N'Quality Assurance Testing', N'In this course, students gain exposure to the software testing process with a focus on product quality subsequent to unit testing. Software testing is examined from the perspective of the stakeholders involved.', N'Moncton', 5)
GO
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Description], [Campus], [InstructorId]) VALUES (11, N'Database Programming', N'This course introduces the students to database programming.   As an essential part of understanding and building user applications, students learn to connect and update the data in a database.
', N'Moncton', 2)
GO
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Description], [Campus], [InstructorId]) VALUES (12, N'N-tier Development', N'This course introduces students to an n-tier design methodology that utilizes advanced architectural concepts to optimize scalability and performance.', N'Moncton', 6)
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Instructor] ON 
GO
INSERT [dbo].[Instructor] ([InstructorId], [FirstName], [MiddleName], [LastName], [Email], [Phone]) VALUES (2, N'Meera', NULL, N'Stewart', N'meeragriffin@gmail.com', N'1 (506) 962-2576')
GO
INSERT [dbo].[Instructor] ([InstructorId], [FirstName], [MiddleName], [LastName], [Email], [Phone]) VALUES (4, N'Roger', NULL, N'Van Houten', N'rvanhouten@gmail.com', N'1 (506) 962-9857')
GO
INSERT [dbo].[Instructor] ([InstructorId], [FirstName], [MiddleName], [LastName], [Email], [Phone]) VALUES (5, N'Jasmine', NULL, N'Gao', N'jgao@gmail.com', N'1 (506) 962-0295')
GO
INSERT [dbo].[Instructor] ([InstructorId], [FirstName], [MiddleName], [LastName], [Email], [Phone]) VALUES (6, N'Aahil', NULL, N'Lutz', N'ahillutz@gmail.com', N'1 (506) 962-3436')
GO
SET IDENTITY_INSERT [dbo].[Instructor] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (3, N'Jerry', N'M', N'Enyeart', N'2461 Mountain Rd', N'xtqp9xrz0vh@powerencry.com', N'506-871-9759')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (7, N'Linda', N'D', N'Watson', N'3862 Mountain Rd', N'mr9x9zvl2o@classesmail.com', N'506-961-0828')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (9, N'Alberta', N'C', N'Rogers', N'634 Mountain Rd', N'pwb5z4mwzm@groupbuff.com', N'506-961-1329')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (10, N'Colleen', N'T', N'Fields', N'1548 Mountain Rd', N'xq4cmkgrhuj@groupbuff.com', N'506-961-6576')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (12, N'Sydney', N'C', N'Wilder', N'4379 Mountain Rd', N'mqtpgtv5jzc@groupbuff.com', N'506-871-9172')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (13, N'Ruth', NULL, N'Morrissey', N'3265 Mountain Rd', N'theruth@gmail.com', N'506-961-2867')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (14, N'Anna', NULL, N'Pires', N'4431 Mountain Rd', N'buhxqirsry6@groupbuff.com', N'506-871-5578')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (19, N'Jerry', NULL, N'Rivera', N'1931 Gorham Street', N'1bc33d7@mail.net', N'519-661-3617')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (20, N'Fadi', NULL, N'Fakhouri', N'8 Derry Rd', N'm7j6t2mqjf@powerencry.com', N'416-270-8447')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (21, N'Arturo', NULL, N'Anand', N'2626 Granville St', N'd3zh8c7xnda@powerencry.com', N'902-448-1787')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (22, N'Yan', NULL, N'Li', N'551 Adelaide St', N'y5vl96bcl3l@groupbuff.com', N'416-607-3185')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (23, N'Wayne', NULL, N'Tang', N'2402 St. John Street', N'lwh28j78y4h@groupbuff.com', N'306-254-6590')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (24, N'Sophia', NULL, N'Lopez', N'4336 rue Saint-Antoine', N'z9vg39k7sse@powerencry.com', N'819-850-1777')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (25, N'Roger', NULL, N'Harui', N'2715 Churchill Plaza', N'705-987-1945', N'5ardabtr8g9@classesmail.com')
GO
INSERT [dbo].[Student] ([StudentId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Phone]) VALUES (30, N'Carson', NULL, N'Powell', N'2213 Burdett Avenue', N'73hmv5cpmww@classesmail.com', N'250-655-7995')
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (3, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (3, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (3, 12)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (7, 9)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (7, 11)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (9, 10)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (10, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (10, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (10, 12)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (12, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (12, 9)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (12, 12)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (13, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (13, 9)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (14, 11)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (19, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (19, 12)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (20, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (21, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (21, 9)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (21, 10)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (21, 11)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (22, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (22, 9)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (23, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (23, 11)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (24, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (24, 9)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (24, 12)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (25, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (25, 10)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (30, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (30, 10)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (30, 11)
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructor] ([InstructorId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Instructor]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_StudentCourse] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_StudentCourse]
GO
ALTER DATABASE [StudentCourseHub] SET  READ_WRITE 
GO
