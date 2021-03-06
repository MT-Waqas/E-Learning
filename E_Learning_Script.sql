USE [E_Learning_Management_System]
GO
/****** Object:  Table [dbo].[tbl_Client]    Script Date: 9/2/2021 7:45:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](50) NULL,
	[ClientContact] [nvarchar](50) NULL,
	[ClientAddress] [nvarchar](50) NULL,
	[ClientEmail] [nvarchar](50) NULL,
	[ClientPassword] [nvarchar](50) NULL,
	[ClientImage] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[IsDelete] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Scl_Registory]    Script Date: 9/2/2021 7:45:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Scl_Registory](
	[SchoolID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [nvarchar](50) NULL,
	[SchoolAddress] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[IsDelete] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SchoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[sp_Client]    Script Date: 9/2/2021 7:45:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Client]
@ClientID int=null,
@ClientName nvarchar(50)=null,
@ClientContact nvarchar(50)=null,
@ClientAddress nvarchar(50)=null,
@ClientEmail nvarchar(50)=null,
@ClientPassword nvarchar(50)=null,
@ClientImage nvarchar(50)=null,
@Status int=null,
@IsDelete int=null,
@type int
as
begin
if(@type=1)
begin
insert into tbl_Client values
(
@ClientName,
@ClientContact ,
@ClientAddress ,
@ClientEmail ,
@ClientPassword ,
@ClientImage ,
@Status ,
0
)
end
if(@type=2)
begin
update tbl_Client set 
ClientName=@ClientName,
ClientContact=@ClientContact ,
ClientAddress=@ClientAddress ,
ClientEmail=@ClientEmail ,
ClientPassword=@ClientPassword ,
ClientImage =@ClientImage ,
[Status]=@Status 
where ClientID=@ClientID
end
if(@type=3)
begin
delete tbl_Client where ClientID=@ClientID
end
if(@type=4)
begin
select * from tbl_Client where 
(@ClientID is null or ClientID=@ClientID) and (@ClientName is null or ClientName=@ClientName) and (@ClientContact is null or ClientContact=@ClientContact) and (@ClientAddress is null or ClientAddress=@ClientAddress) and (@ClientEmail is null or ClientEmail=@ClientEmail) and  (@ClientPassword is null or ClientPassword=@ClientPassword)
end 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_School]    Script Date: 9/2/2021 7:45:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_School]
@SchoolID int=null,
@SchoolName nvarchar(50)=null,
@SchoolAddress nvarchar(50)=null,
@Contact nvarchar(50)=null,
@Image nvarchar(max)=null,
@Status int=null,
@IsDelete int=null,
@type int
as
begin
if(@type=1)
begin
insert into tbl_Scl_Registory values
(
@SchoolName ,
@SchoolAddress ,
@Contact ,
@Image ,
@Status,
0
)
end
if(@type=2)
begin
update tbl_Scl_Registory set 
SchoolName =@SchoolName ,
SchoolAddress=@SchoolAddress ,
Contact=@Contact ,
[Image]=@Image ,
[Status]=@Status
where SchoolID=@SchoolID
end 
if(@type=3)
begin
delete tbl_Scl_Registory where SchoolID=@SchoolID
end
if(@type=4)
begin
select * from tbl_Scl_Registory where (@SchoolID is null or SchoolID=@SchoolID) and (@SchoolName is null or SchoolName=@SchoolName) and (@SchoolAddress is null or SchoolAddress=@SchoolAddress) and (@Contact is null or Contact=@Contact) and(@Status is null or Status=@Status)
end
end

GO
