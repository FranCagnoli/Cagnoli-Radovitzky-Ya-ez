USE [NaturalUruguayDB]
GO

/****** Object:  Table [dbo].[ElectricChargingPoints]    Script Date: 13/5/2022 15:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ElectricChargingPoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[RegionId] [int] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_ElectricChargingPoints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ElectricChargingPoints]  WITH CHECK ADD  CONSTRAINT [FK_ElectricChargingPoints_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO

ALTER TABLE [dbo].[ElectricChargingPoints] CHECK CONSTRAINT [FK_ElectricChargingPoints_Regions_RegionId]
GO


