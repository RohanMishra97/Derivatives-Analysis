USE [Derivative Analysis]
GO

/****** Object:  Table [dbo].[Strategy]    Script Date: 9/29/2019 9:20:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Strategy](
	[strategy_id] [int] NOT NULL,
	[user_id] [int] NULL,
	[symbol] [varchar](20) NULL,
	[max_profit] [decimal](18, 2) NULL,
	[max_loss] [decimal](18, 2) NULL,
	[capital_reqd] [decimal](18, 2) NULL,
	[expiry_date] [date] NULL,
	[bep] [varchar](300) NULL,
	[strategy_name] [varchar](50) NOT NULL,
	[curr_pl] [decimal](18, 2) NULL,
	[roi] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Strategy] PRIMARY KEY CLUSTERED 
(
	[strategy_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Strategy]  WITH CHECK ADD  CONSTRAINT [FK_Strategy_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO

ALTER TABLE [dbo].[Strategy] CHECK CONSTRAINT [FK_Strategy_User]
GO

