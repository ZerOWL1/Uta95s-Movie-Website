USE [UTA95S_MOVIE_WEB]
GO
/****** Object:  Table [dbo].[ACTOR]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTOR](
	[AID] [int] IDENTITY(1,1) NOT NULL,
	[AcName] [nvarchar](100) NULL,
	[AcWiki] [nvarchar](max) NULL,
 CONSTRAINT [PK__ACTOR__C69007C88F310D1C] PRIMARY KEY CLUSTERED 
(
	[AID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DIRECTOR]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIRECTOR](
	[DID] [int] IDENTITY(1,1) NOT NULL,
	[DiName] [nvarchar](100) NULL,
	[DiNationality] [nvarchar](50) NULL,
 CONSTRAINT [PK__DIRECTOR__C03656309C357919] PRIMARY KEY CLUSTERED 
(
	[DID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FAVORITE_MOVIES]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAVORITE_MOVIES](
	[UID] [int] NOT NULL,
	[MID] [int] NOT NULL,
 CONSTRAINT [PK_FAVORITE_MOVIES] PRIMARY KEY CLUSTERED 
(
	[UID] ASC,
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GENRE]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GENRE](
	[GID] [int] IDENTITY(1,1) NOT NULL,
	[GName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[GID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MOVIE_ACTOR]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIE_ACTOR](
	[AID] [int] NOT NULL,
	[MID] [int] NOT NULL,
 CONSTRAINT [PK_MOVIE_ACTOR] PRIMARY KEY CLUSTERED 
(
	[AID] ASC,
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MOVIE_DIRECTOR]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIE_DIRECTOR](
	[DID] [int] NOT NULL,
	[MID] [int] NOT NULL,
 CONSTRAINT [PK_MOVIE_DIRECTOR] PRIMARY KEY CLUSTERED 
(
	[DID] ASC,
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MOVIE_EPISODE]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIE_EPISODE](
	[MID] [int] NOT NULL,
	[Episode] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Episode_Link] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MOVIE_GENRE]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIE_GENRE](
	[GID] [int] NOT NULL,
	[MID] [int] NOT NULL,
 CONSTRAINT [PK_MOVIE_GENRE] PRIMARY KEY CLUSTERED 
(
	[GID] ASC,
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MOVIES]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIES](
	[MID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Episode] [int] NULL,
	[Nationality] [nvarchar](50) NULL,
	[Languages] [nvarchar](50) NULL,
	[Release] [nvarchar](50) NULL,
	[MovieLink] [nvarchar](max) NULL,
	[Lenght] [nvarchar](50) NULL,
	[View] [int] NULL CONSTRAINT [DF__MOVIES__View__1A14E395]  DEFAULT ((0)),
	[DateADD] [datetime] NULL,
 CONSTRAINT [PK__MOVIES__C797348A9E691F65] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RATE]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RATE](
	[RID] [int] IDENTITY(1,1) NOT NULL,
	[UID] [int] NOT NULL,
	[MID] [int] NOT NULL,
	[Point] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[DateRate] [datetime] NULL,
 CONSTRAINT [PK__RATE__CAFF4132CB72375F] PRIMARY KEY CLUSTERED 
(
	[RID] ASC,
	[UID] ASC,
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STATUS]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATUS](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[SaName] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USERM]    Script Date: 6/16/2021 12:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERM](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Passwords] [nvarchar](255) NULL,
	[UIMG] [nvarchar](max) NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[FAVORITE_MOVIES]  WITH CHECK ADD  CONSTRAINT [FK__FAVORITE_MO__MID__2F10007B] FOREIGN KEY([MID])
REFERENCES [dbo].[MOVIES] ([MID])
GO
ALTER TABLE [dbo].[FAVORITE_MOVIES] CHECK CONSTRAINT [FK__FAVORITE_MO__MID__2F10007B]
GO
ALTER TABLE [dbo].[FAVORITE_MOVIES]  WITH CHECK ADD  CONSTRAINT [FK__FAVORITE_MO__UID__2E1BDC42] FOREIGN KEY([UID])
REFERENCES [dbo].[USERM] ([UID])
GO
ALTER TABLE [dbo].[FAVORITE_MOVIES] CHECK CONSTRAINT [FK__FAVORITE_MO__UID__2E1BDC42]
GO
ALTER TABLE [dbo].[MOVIE_ACTOR]  WITH CHECK ADD  CONSTRAINT [FK__MOVIE_ACTOR__AID__33D4B598] FOREIGN KEY([AID])
REFERENCES [dbo].[ACTOR] ([AID])
GO
ALTER TABLE [dbo].[MOVIE_ACTOR] CHECK CONSTRAINT [FK__MOVIE_ACTOR__AID__33D4B598]
GO
ALTER TABLE [dbo].[MOVIE_ACTOR]  WITH CHECK ADD  CONSTRAINT [FK__MOVIE_ACTOR__MID__34C8D9D1] FOREIGN KEY([MID])
REFERENCES [dbo].[MOVIES] ([MID])
GO
ALTER TABLE [dbo].[MOVIE_ACTOR] CHECK CONSTRAINT [FK__MOVIE_ACTOR__MID__34C8D9D1]
GO
ALTER TABLE [dbo].[MOVIE_DIRECTOR]  WITH CHECK ADD  CONSTRAINT [FK__MOVIE_DIREC__DID__36B12243] FOREIGN KEY([DID])
REFERENCES [dbo].[DIRECTOR] ([DID])
GO
ALTER TABLE [dbo].[MOVIE_DIRECTOR] CHECK CONSTRAINT [FK__MOVIE_DIREC__DID__36B12243]
GO
ALTER TABLE [dbo].[MOVIE_DIRECTOR]  WITH CHECK ADD  CONSTRAINT [FK__MOVIE_DIREC__MID__37A5467C] FOREIGN KEY([MID])
REFERENCES [dbo].[MOVIES] ([MID])
GO
ALTER TABLE [dbo].[MOVIE_DIRECTOR] CHECK CONSTRAINT [FK__MOVIE_DIREC__MID__37A5467C]
GO
ALTER TABLE [dbo].[MOVIE_EPISODE]  WITH CHECK ADD  CONSTRAINT [FK_MOVIE_EPISODE_MOVIES1] FOREIGN KEY([MID])
REFERENCES [dbo].[MOVIES] ([MID])
GO
ALTER TABLE [dbo].[MOVIE_EPISODE] CHECK CONSTRAINT [FK_MOVIE_EPISODE_MOVIES1]
GO
ALTER TABLE [dbo].[MOVIE_GENRE]  WITH CHECK ADD  CONSTRAINT [FK__MOVIE_GENRE__GID__30F848ED] FOREIGN KEY([GID])
REFERENCES [dbo].[GENRE] ([GID])
GO
ALTER TABLE [dbo].[MOVIE_GENRE] CHECK CONSTRAINT [FK__MOVIE_GENRE__GID__30F848ED]
GO
ALTER TABLE [dbo].[MOVIE_GENRE]  WITH CHECK ADD  CONSTRAINT [FK__MOVIE_GENRE__MID__31EC6D26] FOREIGN KEY([MID])
REFERENCES [dbo].[MOVIES] ([MID])
GO
ALTER TABLE [dbo].[MOVIE_GENRE] CHECK CONSTRAINT [FK__MOVIE_GENRE__MID__31EC6D26]
GO
ALTER TABLE [dbo].[RATE]  WITH CHECK ADD  CONSTRAINT [FK__RATE__MID__2C3393D0] FOREIGN KEY([MID])
REFERENCES [dbo].[MOVIES] ([MID])
GO
ALTER TABLE [dbo].[RATE] CHECK CONSTRAINT [FK__RATE__MID__2C3393D0]
GO
ALTER TABLE [dbo].[RATE]  WITH CHECK ADD  CONSTRAINT [FK__RATE__UID__2B3F6F97] FOREIGN KEY([UID])
REFERENCES [dbo].[USERM] ([UID])
GO
ALTER TABLE [dbo].[RATE] CHECK CONSTRAINT [FK__RATE__UID__2B3F6F97]
GO