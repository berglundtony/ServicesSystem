USE [ServiceSystemDb]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2024-09-24 07:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 2024-09-24 07:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licenses](
	[LicenseId] [int] IDENTITY(1,1) NOT NULL,
	[QuantityOfUsers] [int] NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[State] [nvarchar](max) NULL,
	[AccountId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED 
(
	[LicenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024-09-24 07:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[LicenseId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [CompanyName]) VALUES (1, N'Arla')
GO
INSERT [dbo].[Customers] ([CustomerId], [CompanyName]) VALUES (2, N'Alfa Laval')
GO
INSERT [dbo].[Customers] ([CustomerId], [CompanyName]) VALUES (3, N'Volvo')
GO
INSERT [dbo].[Customers] ([CustomerId], [CompanyName]) VALUES (4, N'Saab')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Licenses] ON 
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (1, 5, CAST(N'2024-11-23T03:08:45.5879389' AS DateTime2), N'inactive', 1, 3)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (2, 5, CAST(N'2025-05-23T00:08:26.6611423' AS DateTime2), N'active', 2, 1)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (3, 4, CAST(N'2025-03-23T00:09:30.6613727' AS DateTime2), N'active', 3, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (4, 2, CAST(N'2025-03-23T00:19:02.5042105' AS DateTime2), N'active', 4, 2)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (5, 3, CAST(N'2025-03-23T15:39:03.5902248' AS DateTime2), N'active', 1, 1)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (6, 5, CAST(N'2025-03-23T15:54:37.6473900' AS DateTime2), N'active', 3, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (7, 3, CAST(N'2025-03-23T21:27:24.4878173' AS DateTime2), N'inactive', 1, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (8, 3, CAST(N'2025-03-23T21:27:26.4809005' AS DateTime2), N'inactive', 1, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (9, 2, CAST(N'2025-03-23T21:30:16.6991915' AS DateTime2), N'active', 1, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (10, 2, CAST(N'2025-03-23T21:58:50.6304234' AS DateTime2), N'active', 2, 3)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (13, 2, CAST(N'2025-03-23T23:04:54.1322182' AS DateTime2), N'active', 2, 1)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (14, 2, CAST(N'2025-03-24T05:36:04.8146120' AS DateTime2), N'active', 4, 2)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (15, 2, CAST(N'2025-03-24T05:55:22.6712692' AS DateTime2), N'active', 4, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (17, 2, CAST(N'2025-03-24T06:31:15.7405259' AS DateTime2), N'active', 3, 3)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (18, 2, CAST(N'2025-03-24T06:37:15.1231302' AS DateTime2), N'active', 4, 4)
GO
INSERT [dbo].[Licenses] ([LicenseId], [QuantityOfUsers], [ValidTo], [State], [AccountId], [ServiceId]) VALUES (19, 2, CAST(N'2025-03-24T06:49:07.5952918' AS DateTime2), N'active', 3, 4)
GO
SET IDENTITY_INSERT [dbo].[Licenses] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (1, 1, N'Ture Svensson', 5)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (2, 1, N'Lena Modin', 5)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (3, 1, N'Peter Norberg', 5)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (4, 2, N'Peter Forsberg', 13)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (5, 5, N'Göran Persson', 3)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (6, 1, N'Hans Vakander', 9)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (7, 2, N'Gertrud Örn', 10)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (8, 3, N'Mattias Gunnarsson', 6)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (9, 1, N'Jerker Johansson', 4)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (10, 4, N'Ole-Henning Seater', 14)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (11, 4, N'Petra Marklund', 15)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (12, 1, N'Per Gessle', 17)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (13, 3, N'Jacob Jacobsson', 18)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (14, 4, N'Lennart Hyland', 19)
GO
INSERT [dbo].[Users] ([UserId], [CustomerId], [UserName], [LicenseId]) VALUES (15, 4, N'Gunde Swan', 3)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Licenses] ADD  DEFAULT ((0)) FOR [AccountId]
GO
ALTER TABLE [dbo].[Licenses] ADD  DEFAULT ((0)) FOR [ServiceId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [LicenseId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Licenses_LicenseId] FOREIGN KEY([LicenseId])
REFERENCES [dbo].[Licenses] ([LicenseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Licenses_LicenseId]
GO
