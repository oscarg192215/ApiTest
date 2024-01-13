USE [ApiTest]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 13/01/2024 9:19:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[IdOwner] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Photo] [varbinary](max) NULL,
	[Birthday] [nvarchar](10) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOwner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 13/01/2024 9:19:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[IdProperty] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CodeInternal] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[IdOwner] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyImage]    Script Date: 13/01/2024 9:19:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImage](
	[IdPropertyImage] [int] IDENTITY(1,1) NOT NULL,
	[IdProperty] [int] NULL,
	[Files] [varbinary](max) NULL,
	[Enabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPropertyImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyTrace]    Script Date: 13/01/2024 9:19:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTrace](
	[IdPropertyTrace] [int] IDENTITY(1,1) NOT NULL,
	[IdProperty] [int] NULL,
	[DateSale] [nvarchar](10) NULL,
	[Name] [nvarchar](255) NULL,
	[Value] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPropertyTrace] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD FOREIGN KEY([IdOwner])
REFERENCES [dbo].[Owner] ([IdOwner])
GO
ALTER TABLE [dbo].[PropertyImage]  WITH CHECK ADD FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Property] ([IdProperty])
GO
ALTER TABLE [dbo].[PropertyTrace]  WITH CHECK ADD FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Property] ([IdProperty])
GO
