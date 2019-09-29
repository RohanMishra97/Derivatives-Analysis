USE [Derivative Analysis]
GO

/****** Object:  Table [dbo].[FutureTrade]    Script Date: 9/29/2019 8:25:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FutureTrade](
	[future_id] [varchar](50) NOT NULL,
	[buying_date] [varchar](50) NOT NULL,
	[num_lots] [int] NOT NULL,
	[margin_avail] [decimal](18, 2) NOT NULL,
	[strategy_id] [int] NOT NULL,
	[symbol] [varchar](20) NOT NULL,
	[trade_type] [varchar](4) NOT NULL,
	[exercise_price] [decimal](18, 2) NOT NULL,
	[fut_trade_id] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FutureTrade]  WITH CHECK ADD  CONSTRAINT [FK_FutureTrade_Strategy] FOREIGN KEY([strategy_id])
REFERENCES [dbo].[Strategy] ([strategy_id])
GO

ALTER TABLE [dbo].[FutureTrade] CHECK CONSTRAINT [FK_FutureTrade_Strategy]
GO

