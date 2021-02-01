USE [master]
GO
/****** Object:  Database [SIBERSPROJECTS]    Script Date: 28.01.2021 12:50:41 ******/
CREATE DATABASE [SIBERSPROJECTS]
GO
ALTER DATABASE [SIBERSPROJECTS] SET COMPATIBILITY_LEVEL = 120
GO
USE [SIBERSPROJECTS]
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 28.01.2021 12:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[SurName] [varchar](50) NOT NULL,
	[Patronymic] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[IsActive] [int] NOT NULL,
 CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROJECT]    Script Date: 28.01.2021 12:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROJECT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Customer] [varchar](50) NOT NULL,
	[Executor] [varchar](50) NOT NULL,
	[ProjectLeader] [int] NULL,
	[StartDate] [datetime] NULL,
	[ExpirationDate] [datetime] NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_PROJECT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FILE]    Script Date: 28.01.2021 12:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ID_PROJECT] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_FILE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROJECT_EMPLOYEE]    Script Date: 28.01.2021 12:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROJECT_EMPLOYEE](
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_PROJECT_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATUS]    Script Date: 28.01.2021 12:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATUS](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_STATUS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TASK]    Script Date: 28.01.2021 12:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TASK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Author] [int] NOT NULL,
	[Executor] [int] NULL,
	[StatusID] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Comment] [text] NULL,
 CONSTRAINT [PK_TASK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EMPLOYEE] ON 

INSERT [dbo].[EMPLOYEE] ([ID], [FirstName], [SurName], [Patronymic], [Email], [IsActive]) VALUES (1, N'Алексей', N'Капитаненко', N'Алексеевич', N'alexcaptain@icloud.com', 0)
INSERT [dbo].[EMPLOYEE] ([ID], [FirstName], [SurName], [Patronymic], [Email], [IsActive]) VALUES (2, N'Любовь', N'Квасница', N'Владимировна', N'liuboff2007@gmail.com', 1)
INSERT [dbo].[EMPLOYEE] ([ID], [FirstName], [SurName], [Patronymic], [Email], [IsActive]) VALUES (3, N'Олеся', N'Миренич', N'Олеговна', N'olesymirenich@icloud.com', 1)
INSERT [dbo].[EMPLOYEE] ([ID], [FirstName], [SurName], [Patronymic], [Email], [IsActive]) VALUES (4, N'Робин', N'Перман', null , N'angelfirst54rus@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[EMPLOYEE] OFF
GO
SET IDENTITY_INSERT [dbo].[PROJECT] ON 

INSERT [dbo].[PROJECT] ([ID], [Name], [Customer], [Executor], [ProjectLeader], [StartDate], [ExpirationDate], [Priority]) VALUES (1, N'Транспорт', N'СибТранс', N'Sibers', 3, CAST(N'2021-01-28T00:00:00.000' AS DateTime), CAST(N'2021-02-28T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PROJECT] ([ID], [Name], [Customer], [Executor], [ProjectLeader], [StartDate], [ExpirationDate], [Priority]) VALUES (2, N'Учеба', N'Школа №6', N'Sibers', 3, CAST(N'2021-02-02T00:00:00.000' AS DateTime), CAST(N'2022-02-02T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[PROJECT] OFF
GO
INSERT [dbo].[PROJECT_EMPLOYEE] ([ProjectID], [EmployeeID]) VALUES (1, 1)
INSERT [dbo].[PROJECT_EMPLOYEE] ([ProjectID], [EmployeeID]) VALUES (1, 2)
INSERT [dbo].[PROJECT_EMPLOYEE] ([ProjectID], [EmployeeID]) VALUES (1, 3)
GO
INSERT [dbo].[STATUS] ([ID], [Name]) VALUES (1, N'ToDo')
INSERT [dbo].[STATUS] ([ID], [Name]) VALUES (2, N'InProgress')
INSERT [dbo].[STATUS] ([ID], [Name]) VALUES (3, N'Done')
GO
SET IDENTITY_INSERT [dbo].[TASK] ON 

INSERT [dbo].[TASK] ([ID], [Name], [Author], [Executor], [StatusID], [Priority], [ProjectID], [Comment]) VALUES (7, N'Дизайн', 3, 3, 2, 2, 1, N'Дизайн страниц')
INSERT [dbo].[TASK] ([ID], [Name], [Author], [Executor], [StatusID], [Priority], [ProjectID], [Comment]) VALUES (13, N'Дизайн', 1, 1, 1, 1, 1, N'Дизайн шапки')
INSERT [dbo].[TASK] ([ID], [Name], [Author], [Executor], [StatusID], [Priority], [ProjectID], [Comment]) VALUES (22, N'Разработка БД', 3, 2, 1, 3, 2, NULL)
SET IDENTITY_INSERT [dbo].[TASK] OFF
GO
ALTER TABLE [dbo].[FILE]  WITH CHECK ADD  CONSTRAINT [FK_FILE_PROJECT] FOREIGN KEY([Id])
REFERENCES [dbo].[PROJECT] ([ID])
GO
ALTER TABLE [dbo].[FILE] CHECK CONSTRAINT [FK_FILE_PROJECT]
GO
ALTER TABLE [dbo].[PROJECT]  WITH CHECK ADD  CONSTRAINT [FK_PROJECT_EMPLOYEE] FOREIGN KEY([ProjectLeader])
REFERENCES [dbo].[EMPLOYEE] ([ID])
GO
ALTER TABLE [dbo].[PROJECT] CHECK CONSTRAINT [FK_PROJECT_EMPLOYEE]
GO
ALTER TABLE [dbo].[PROJECT_EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_PROJECT_EMPLOYEE_EMPLOYEE] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[EMPLOYEE] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PROJECT_EMPLOYEE] CHECK CONSTRAINT [FK_PROJECT_EMPLOYEE_EMPLOYEE]
GO
ALTER TABLE [dbo].[PROJECT_EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_PROJECT_EMPLOYEE_PROJECT] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[PROJECT] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PROJECT_EMPLOYEE] CHECK CONSTRAINT [FK_PROJECT_EMPLOYEE_PROJECT]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_EMPLOYEE] FOREIGN KEY([Author])
REFERENCES [dbo].[EMPLOYEE] ([ID])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_EMPLOYEE]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_EMPLOYEE1] FOREIGN KEY([Executor])
REFERENCES [dbo].[EMPLOYEE] ([ID])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_EMPLOYEE1]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_PROJECT] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[PROJECT] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_PROJECT]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_STATUS] FOREIGN KEY([StatusID])
REFERENCES [dbo].[STATUS] ([ID])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_STATUS]
GO
USE [master]
GO
ALTER DATABASE [SIBERSPROJECTS] SET  READ_WRITE 
GO