USE [HealthDeclarationDB]
GO
/****** Object:  Table [dbo].[HealthDeclarationRecord]    Script Date: 9/18/2023 8:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthDeclarationRecord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[BusinessEmail] [nvarchar](255) NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
	[Designation] [nvarchar](255) NULL,
	[BusinessNumber] [nvarchar](20) NULL,
	[LicensePlate] [nvarchar](15) NULL,
	[NRICNumber] [nvarchar](20) NULL,
	[IsUnderQuarantine] [bit] NULL,
	[IsCloseContact] [bit] NULL,
	[IsUnderSymptoms] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
