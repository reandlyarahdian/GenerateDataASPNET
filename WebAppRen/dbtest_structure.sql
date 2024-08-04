-- ----------------------------
-- Table structure for tblM_gender
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblM_gender]') AND type IN ('U'))
	DROP TABLE [dbo].[tblM_gender]
GO

CREATE TABLE [dbo].[tblM_gender] (
  [Id] int  NOT NULL,
  [Nama] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblM_gender] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblM_Hobi
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblM_Hobi]') AND type IN ('U'))
	DROP TABLE [dbo].[tblM_Hobi]
GO

CREATE TABLE [dbo].[tblM_Hobi] (
  [Id] int  NOT NULL,
  [Nama] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblM_Hobi] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblT_Personal
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblT_Personal]') AND type IN ('U'))
	DROP TABLE [dbo].[tblT_Personal]
GO

CREATE TABLE [dbo].[tblT_Personal] (
  [Id] int  NOT NULL,
  [Nama] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [IdGender] int  NULL,
  [IdHobi] char(1) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Umur] int  NULL
)
GO

ALTER TABLE [dbo].[tblT_Personal] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblT_Umur
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblT_Umur]') AND type IN ('U'))
	DROP TABLE [dbo].[tblT_Umur]
GO

CREATE TABLE [dbo].[tblT_Umur] (
  [Umur] int  NULL,
  [Total] int  NULL
)
GO

ALTER TABLE [dbo].[tblT_Umur] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table tblM_gender
-- ----------------------------
ALTER TABLE [dbo].[tblM_gender] ADD CONSTRAINT [PK__tblM_gen__3214EC07D356321F] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblM_Hobi
-- ----------------------------
ALTER TABLE [dbo].[tblM_Hobi] ADD CONSTRAINT [PK__tblM_Hob__3214EC07B324D7FD] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblT_Personal
-- ----------------------------
ALTER TABLE [dbo].[tblT_Personal] ADD CONSTRAINT [PK__tblT_Per__3214EC0760D2DBB6] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

