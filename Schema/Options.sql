USE [Derivative Analysis]
GO

/****** Object:  Table [dbo].[Options]    Script Date: 9/29/2019 8:25:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Options](
	[option_id] [varchar](50) NOT NULL,
	[symbol] [varchar](20) NOT NULL,
	[expiry_date] [varchar](50) NOT NULL,
	[ltp] [decimal](18, 2) NOT NULL,
	[oi] [bigint] NOT NULL,
	[oi_change] [bigint] NOT NULL,
	[volume] [bigint] NOT NULL,
	[op_type] [nchar](2) NOT NULL,
	[p_change] [decimal](18, 2) NOT NULL,
	[strike_price] [decimal](18, 2) NOT NULL,
	[iv] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[option_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

