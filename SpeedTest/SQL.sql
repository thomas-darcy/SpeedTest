CREATE TABLE [dbo].[SpeedTest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time] [datetime2](7) NOT NULL,
	[server name] [nvarchar](128) NOT NULL,
	[server id] [int] NOT NULL,
	[latency] [float] NOT NULL,
	[jitter] [float] NOT NULL,
	[packet loss] [float] NOT NULL,
	[download] [bigint] NOT NULL,
	[upload] [bigint] NOT NULL,
	[download bytes] [bigint] NOT NULL,
	[upload bytes] [bigint] NOT NULL
);

ALTER TABLE [dbo].[SpeedTest] ADD  DEFAULT (GETDATE()) FOR [time];