USE [Derivative Analysis]
GO

/****** Object:  Table [dbo].[User]    Script Date: 9/29/2019 8:26:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[user_id] [int] NOT NULL,
	[user_name] [varchar](128) NOT NULL,
	[password] [varchar](256) NOT NULL,
	[e_mail] [varchar](256) NOT NULL,
	[funds] [money] NOT NULL,
	[p_l] [money] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

