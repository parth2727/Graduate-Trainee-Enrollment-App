USE [GraduateTraineeEnrollmentDB]
GO
/****** Object:  StoredProcedure [dbo].[TraineeEnrollmentReport]    Script Date: 4/18/2024 6:53:57 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[TraineeEnrollmentReport]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Streams]') AND type in (N'U'))
ALTER TABLE [dbo].[Streams] DROP CONSTRAINT IF EXISTS [FK__Streams__DegreeI__398D8EEE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GraduateTrainees]') AND type in (N'U'))
ALTER TABLE [dbo].[GraduateTrainees] DROP CONSTRAINT IF EXISTS [FK__GraduateT__Strea__4316F928]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GraduateTrainees]') AND type in (N'U'))
ALTER TABLE [dbo].[GraduateTrainees] DROP CONSTRAINT IF EXISTS [FK__GraduateT__Degre__4222D4EF]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 4/18/2024 6:53:57 PM ******/
DROP TABLE IF EXISTS [dbo].[Streams]
GO
/****** Object:  Table [dbo].[GraduateTrainees]    Script Date: 4/18/2024 6:53:57 PM ******/
DROP TABLE IF EXISTS [dbo].[GraduateTrainees]
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 4/18/2024 6:53:57 PM ******/
DROP TABLE IF EXISTS [dbo].[Degrees]
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 4/18/2024 6:53:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degrees](
	[DegreeId] [int] IDENTITY(1,1) NOT NULL,
	[DegreeName] [varchar](20) NOT NULL,
	[DegreeDescription] [varchar](100) NULL,
 CONSTRAINT [PK_Degrees] PRIMARY KEY CLUSTERED 
(
	[DegreeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GraduateTrainees]    Script Date: 4/18/2024 6:53:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GraduateTrainees](
	[GraduateTraineeId] [int] IDENTITY(1,1) NOT NULL,
	[DegreeId] [int] NULL,
	[StreamId] [int] NULL,
	[TraineeName] [varchar](20) NOT NULL,
	[TraineeEmail] [varchar](25) NOT NULL,
	[UniversityName] [varchar](25) NOT NULL,
	[IsLastSemesterPending] [bit] NOT NULL,
	[Gender] [varchar](1) NOT NULL,
	[DateOfApplication] [date] NOT NULL,
	[Image] [varchar](150) NULL,
	[AI] [decimal](18, 0) NULL,
	[Phyton] [decimal](18, 0) NULL,
	[BusinessAnalysis] [decimal](18, 0) NULL,
	[MachineLearning] [decimal](18, 0) NULL,
	[Practical] [decimal](18, 0) NULL,
	[TotalMarks] [decimal](18, 0) NULL,
	[Percentages] [decimal](18, 0) NULL,
	[IsAdmisisonConfirmed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GraduateTraineeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 4/18/2024 6:53:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streams](
	[StreamId] [int] IDENTITY(1,1) NOT NULL,
	[StreamName] [varchar](20) NOT NULL,
	[StreamDescription] [varchar](max) NULL,
	[DegreeId] [int] NOT NULL,
 CONSTRAINT [PK__Streams__07C87A9256158F35] PRIMARY KEY CLUSTERED 
(
	[StreamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Degrees] ON 
GO
INSERT [dbo].[Degrees] ([DegreeId], [DegreeName], [DegreeDescription]) VALUES (1, N'Bachelor Degree', N'IT')
GO
INSERT [dbo].[Degrees] ([DegreeId], [DegreeName], [DegreeDescription]) VALUES (2, N'Master Degree', N'Security')
GO
SET IDENTITY_INSERT [dbo].[Degrees] OFF
GO
SET IDENTITY_INSERT [dbo].[GraduateTrainees] ON 
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (4, NULL, 1, N'Kashyap', N'kashyap1@gmail.com', N'string', 0, N'f', CAST(N'2024-04-18' AS Date), N'string', CAST(90 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (5, 2, 2, N'Lav', N'lav@gmail.com', N'CVM', 0, N'm', CAST(N'2022-05-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (6, NULL, 3, N'Rachit1', N'rachit1@gmail.com', N'GTU', 1, N'm', CAST(N'2024-04-18' AS Date), N'string', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (8, 1, 4, N'vkt', N'vkt@gmail.com', N'BVM', 0, N'f', CAST(N'2024-04-18' AS Date), N'', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (9, NULL, 5, N'Jinal', N'jinal@gmail.com', N'GTU', 1, N'f', CAST(N'2024-04-18' AS Date), N'string', CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (12, NULL, 4, N'string', N'string', N'string', 1, N'f', CAST(N'2024-04-18' AS Date), N'string', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[GraduateTrainees] OFF
GO
SET IDENTITY_INSERT [dbo].[Streams] ON 
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (1, N'BCA', N'Bachelor Of Computer Application', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (2, N'B-Tech IT', N'Bachelor Of Technology in IT', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (3, N'BE Com Engg ', N'Bachelor Of Engineer in Computer', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (4, N'B-Tech CSE', N'Bachelor of Technology in Computer Science and Engineering', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (5, N'MCA', N'Master Of Computer Application ', 2)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (6, N'M-Tech IT ', N'Master Of Technology in IT', 2)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (7, N'ME Com Engg', N'Master Of Engineer in Computer', 2)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (8, N'M-Tech CSE', N'Master of Technology in Computer Science and Engineering', 2)
GO
SET IDENTITY_INSERT [dbo].[Streams] OFF
GO
ALTER TABLE [dbo].[GraduateTrainees]  WITH CHECK ADD FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Degrees] ([DegreeId])
GO
ALTER TABLE [dbo].[GraduateTrainees]  WITH CHECK ADD FOREIGN KEY([StreamId])
REFERENCES [dbo].[Streams] ([StreamId])
GO
ALTER TABLE [dbo].[Streams]  WITH CHECK ADD  CONSTRAINT [FK__Streams__DegreeI__398D8EEE] FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Degrees] ([DegreeId])
GO
ALTER TABLE [dbo].[Streams] CHECK CONSTRAINT [FK__Streams__DegreeI__398D8EEE]
GO
/****** Object:  StoredProcedure [dbo].[TraineeEnrollmentReport]    Script Date: 4/18/2024 6:53:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[TraineeEnrollmentReport]  
	
AS
BEGIN
	SELECT d.DegreeName, s.StreamName, COUNT(gt.TraineeName) as TotalTraineeCount  FROM GraduateTrainees gt 
	JOIN Degrees d on d.DegreeId = gt.DegreeId
	JOIN Streams s on s.StreamId = gt.StreamId
	GROUP BY d.DegreeName , s.StreamName
END
GO
