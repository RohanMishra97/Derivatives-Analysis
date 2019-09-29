USE [Derivative Analysis]
GO

/****** Object:  Table [dbo].[OptionTrade]    Script Date: 9/29/2019 8:25:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OptionTrade](
	[option_id] [varchar](50) NOT NULL,
	[buying_date] [varchar](50) NOT NULL,
	[num_lots] [int] NOT NULL,
	[premium] [decimal](18, 2) NOT NULL,
	[strategy_id] [int] NOT NULL,
	[symbol] [varchar](20) NOT NULL,
	[trade_type] [varchar](4) NOT NULL,
	[opt_trade_id] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

