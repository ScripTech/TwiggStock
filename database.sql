-- Note: Use este ficheiro para ciar a DB e suas tabales
-- Edilson Mucanze
Create database kz_twigg_stock
Go
use kz_twigg_stock

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[budget]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [department_id] [uniqueidentifier] NOT NULL,
    [budget_value] [float] NULL,
    [budget_used] [float] NULL,
    [budget_year] [int] NOT NULL,
    [author_id] [uniqueidentifier] NOT NULL,
    [created_on] [datetime] NOT NULL,
    [updated_on] [datetime] NOT NULL,
    [deleted_on] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[budget] ADD PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [uuid] [uniqueidentifier] NOT NULL,
    [description] [varchar](194) NOT NULL,
    [supplier_id] [uniqueidentifier] NOT NULL,
    [author_id] [uniqueidentifier] NOT NULL,
    [created_on] [datetime] NOT NULL,
    [updated_on] [datetime] NOT NULL,
    [deleted_on] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[categories] ADD PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [uuid] [uniqueidentifier] NOT NULL,
    [name] [varchar](74) NOT NULL,
    [slug_name] [varchar](15) NOT NULL,
    [group_email] [varchar](100) NOT NULL,
    [remarks] [text] NULL,
    [is_active] [tinyint] NOT NULL,
    [created_on] [datetime] NOT NULL,
    [updated_on] [datetime] NOT NULL,
    [deleted_on] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[departments] ADD PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stocks]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [uuid] [uniqueidentifier] NOT NULL,
    [description] [varchar](194) NOT NULL,
    [quantity] [int] NOT NULL,
    [value] [float] NOT NULL,
    [item_model] [varchar](30) NULL,
    [spent_category] [varchar](190) NULL,
    [spent_date] [datetime] NOT NULL,
    [supplier_id] [uniqueidentifier] NOT NULL,
    [author_id] [uniqueidentifier] NOT NULL,
    [created_on] [datetime] NOT NULL,
    [updated_on] [datetime] NOT NULL,
    [deleted_on] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stocks] ADD PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suppliers]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [uuid] [uniqueidentifier] NOT NULL,
    [name] [varchar](74) NOT NULL,
    [nuit] [varchar](15) NOT NULL,
    [country] [varchar](100) NOT NULL,
    [city] [varchar](100) NOT NULL,
    [address] [varchar](100) NOT NULL,
    [cell_number] [varchar](100) NOT NULL,
    [email_address] [varchar](100) NOT NULL,
    [remarks] [text] NULL,
    [is_active] [tinyint] NOT NULL,
    [created_on] [datetime] NOT NULL,
    [updated_on] [datetime] NOT NULL,
    [deleted_on] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[suppliers] ADD PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[suppliers] ADD  DEFAULT ((1)) FOR [is_active]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [uuid] [uniqueidentifier] NOT NULL,
    [firstname] [varchar](70) NOT NULL,
    [lastname] [varchar](50) NOT NULL,
    [login] [varchar](30) NOT NULL,
    [password] [varchar](192) NOT NULL,
    [must_change_passwd] [tinyint] NOT NULL,
    [passwd_changed_on] [datetime] NULL,
    [mail_notification] [varchar](192) NULL,
    [email_verified_at] [datetime] NULL,
    [last_login_on] [datetime] NULL,
    [language] [varchar](5) NOT NULL,
    [created_on] [datetime] NOT NULL,
    [updated_on] [datetime] NOT NULL,
    [deleted_on] [datetime] NULL,
    [salt] [nvarchar](195) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[users] ADD PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((1)) FOR [must_change_passwd]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (NULL) FOR [passwd_changed_on]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (NULL) FOR [email_verified_at]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (NULL) FOR [last_login_on]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ('PT-pt') FOR [language]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (NULL) FOR [deleted_on]
GO

