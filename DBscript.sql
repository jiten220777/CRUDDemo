USE [master]
GO
/****** Object:  Database [CRUDDemo_DB]    Script Date: 23-03-2021 16:55:45 ******/
CREATE DATABASE [CRUDDemo_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRUDDemo_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.EXPRESS\MSSQL\DATA\CRUDDemo_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CRUDDemo_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.EXPRESS\MSSQL\DATA\CRUDDemo_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CRUDDemo_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRUDDemo_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRUDDemo_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CRUDDemo_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRUDDemo_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRUDDemo_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRUDDemo_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRUDDemo_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRUDDemo_DB] SET  MULTI_USER 
GO
ALTER DATABASE [CRUDDemo_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRUDDemo_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRUDDemo_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRUDDemo_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CRUDDemo_DB]
GO
/****** Object:  Table [dbo].[tbl_Contact]    Script Date: 23-03-2021 16:55:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Contact](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [CRUDDemo_DB] SET  READ_WRITE 
GO
