USE [Derivative Analysis]
GO

/****** Object:  Table [dbo].[Strategy]    Script Date: 9/29/2019 8:26:04 PM ******/
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
	[max_profit] [money] NULL,
	[max_loss] [money] NULL,
	[capital_reqd] [money] NULL,
	[expiry_date] [date] NULL,
	[bep] [varchar](300) NULL,
	[delta] [float] NULL,
	[theta] [float] NULL,
	[vega] [float] NULL,
	[gamma] [float] NULL,
	[strategy_name] [varchar](50) NOT NULL,
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

