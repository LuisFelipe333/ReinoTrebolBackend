CREATE TABLE [dbo].[applications](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[lastName] [varchar](20) NOT NULL,
	[identification] [varchar](10) NOT NULL,
	[age] [int] NOT NULL,
	[magicalAff] [varchar](9) NOT NULL,
	[status] [bit] NOT NULL,
	[grimoireLevel] [varchar](13) NOT NULL,
 CONSTRAINT [PK_applications] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[GetApplications]
AS
BEGIN
	SELECT * FROM applications
END
GO


CREATE TABLE [dbo].[grimoires](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[applicationId] [int] NOT NULL,
	[grimoireLevel] [varchar](13) NOT NULL,
 CONSTRAINT [PK_grimoires] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE PROCEDURE [dbo].[AddApplications] 
@sName varchar(20),
@sLastName varchar(20),
@sIdentification varchar(10),
@iAge int,
@sMagicalAff varchar(9),
@bStatus bit,
@iGrimoireLevel varchar(13)
AS
BEGIN
	DECLARE @applicationId int
	INSERT applications (name, lastName, identification, age, magicalAff, status, grimoireLevel) 
	VALUES (@sName, @sLastName, @sIdentification, @iAge, @sMagicalAff, @bStatus, @iGrimoireLevel)	
	SET @applicationId = SCOPE_IDENTITY();
	INSERT grimoires (applicationId, grimoireLevel) 
	VALUES (@applicationId, @iGrimoireLevel)
END
GO

CREATE PROCEDURE [dbo].[UpdateApplications]
@iId int,
@sName varchar(20) = null,
@sLastName varchar(20) = null,
@sIdentification varchar(10) = null,
@iAge int = null,
@sMagicalAff varchar(9) = null
AS
BEGIN
	UPDATE applications
	SET name = ISNULL(@sName, name),
	lastName = ISNULL(@sLastName, lastName),
	identification = ISNULL(@sIdentification, identification),
	age = ISNULL(@iAge, age),
	magicalAff = ISNULL(@sMagicalAff, magicalAff)
	WHERE id = @iId
END
GO

CREATE PROCEDURE [dbo].[UpdateStatus]
@iId int,
@bStatus bit
AS
BEGIN
	UPDATE applications
	SET status = @bStatus
	WHERE id = @iId
END
GO

CREATE PROCEDURE [dbo].[DeleteApplication]
@iId int
AS
BEGIN
	DELETE FROM applications
	WHERE id = @iId
END
GO

CREATE PROCEDURE [dbo].[GetGrimoires]
AS
BEGIN
	SELECT * FROM grimoires
END