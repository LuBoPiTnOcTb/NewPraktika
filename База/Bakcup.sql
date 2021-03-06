USE [master]
GO
/****** Object:  Database [AccountingforTransactions]    Script Date: 14.04.2022 20:51:29 ******/
CREATE DATABASE [AccountingforTransactions]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccountingforTransactions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\AccountingforTransactions.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AccountingforTransactions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\AccountingforTransactions_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AccountingforTransactions] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccountingforTransactions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccountingforTransactions] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AccountingforTransactions] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccountingforTransactions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccountingforTransactions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AccountingforTransactions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccountingforTransactions] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AccountingforTransactions] SET  MULTI_USER 
GO
ALTER DATABASE [AccountingforTransactions] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccountingforTransactions] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccountingforTransactions] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccountingforTransactions] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AccountingforTransactions] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AccountingforTransactions] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AccountingforTransactions] SET QUERY_STORE = OFF
GO
USE [AccountingforTransactions]
GO
/****** Object:  UserDefinedFunction [dbo].[PowerSumm]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[PowerSumm](@id int)
returns money
begin
declare @powersum int
declare @kolvo int
Select @kolvo = Quantity,@powersum = [Power] from [Main_Equipment(Boiler)]
Where ID_Equipment = @id
Return @powersum*@kolvo
END
GO
/****** Object:  Table [dbo].[Bank_Details]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_Details](
	[ID_Bank_Details] [int] NOT NULL,
	[INN] [varchar](max) NOT NULL,
	[PPC] [varchar](max) NOT NULL,
	[BIC] [varchar](max) NOT NULL,
	[Payment_Account] [varchar](max) NOT NULL,
	[Correspondent_Account] [varchar](max) NOT NULL,
	[OGRN] [varchar](max) NOT NULL,
 CONSTRAINT [PK__Bank_Det__B8E1EAFAA1E034C9] PRIMARY KEY CLUSTERED 
(
	[ID_Bank_Details] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boiler_Fuel]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boiler_Fuel](
	[ID_Fuel] [int] NOT NULL,
	[ID_Equipment] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Fuel] ASC,
	[ID_Equipment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID_Company] [int] NOT NULL,
	[ID_Bank_Details] [int] NOT NULL,
	[Title_Company] [varchar](max) NOT NULL,
	[Address_Company] [varchar](max) NOT NULL,
	[Number_Phone] [varchar](25) NOT NULL,
	[Director] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ID_Contract] [int] NOT NULL,
	[Date_Conclusion] [date] NOT NULL,
	[Valid_For] [date] NOT NULL,
	[ID_Object] [int] NOT NULL,
	[ID_Employee] [int] NOT NULL,
	[ID_Equipment] [int] NOT NULL,
	[Price] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Contract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID_Employee] [int] NOT NULL,
	[Surname] [varchar](max) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Middle_Name] [varchar](max) NOT NULL,
	[Post] [varchar](max) NOT NULL,
	[Salary] [money] NOT NULL,
	[Login] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fuel]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fuel](
	[ID_Fuel] [int] NOT NULL,
	[Title_Fuel] [varchar](max) NOT NULL,
	[ID_Type_Fuel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Fuel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_Equipment(Boiler)]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Equipment(Boiler)](
	[ID_Equipment] [int] NOT NULL,
	[Stamp] [varchar](max) NOT NULL,
	[Model] [varchar](max) NOT NULL,
	[Power] [int] NOT NULL,
	[Unit_Of_Measurement] [varchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Service] [varchar](max) NOT NULL,
	[PowerSumm]  AS ([dbo].[PowerSumm]([Main_Equipment(Boiler)].[ID_Equipment])),
PRIMARY KEY CLUSTERED 
(
	[ID_Equipment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Object]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[ID_Object] [int] NOT NULL,
	[Title_Object] [varchar](max) NOT NULL,
	[Purpose] [varchar](max) NOT NULL,
	[Work_Mode] [varchar](max) NOT NULL,
	[Address_Object] [varchar](max) NOT NULL,
	[Description] [varchar](max) NULL,
	[ID_Company] [int] NOT NULL,
 CONSTRAINT [PK__Object__7C1EA52AF131F33C] PRIMARY KEY CLUSTERED 
(
	[ID_Object] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Fuel]    Script Date: 14.04.2022 20:51:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Fuel](
	[ID_Type_Fuel] [int] NOT NULL,
	[Title_Type_Fuel] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Type_Fuel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bank_Details] ([ID_Bank_Details], [INN], [PPC], [BIC], [Payment_Account], [Correspondent_Account], [OGRN]) VALUES (1, N'5042021397', N'507301302', N'42523341', N'4050231044', N'3010494040', N'1000005103')
INSERT [dbo].[Bank_Details] ([ID_Bank_Details], [INN], [PPC], [BIC], [Payment_Account], [Correspondent_Account], [OGRN]) VALUES (2, N'5061075359', N'556462245', N'47645632', N'4232423535', N'3654634520', N'1000007655')
INSERT [dbo].[Bank_Details] ([ID_Bank_Details], [INN], [PPC], [BIC], [Payment_Account], [Correspondent_Account], [OGRN]) VALUES (3, N'5084038342', N'509246154', N'42675341', N'4012312443', N'3345653470', N'1000009543')
INSERT [dbo].[Bank_Details] ([ID_Bank_Details], [INN], [PPC], [BIC], [Payment_Account], [Correspondent_Account], [OGRN]) VALUES (5, N'555545', N'45453', N'45353453', N'5345345', N'3453453', N'35345')
INSERT [dbo].[Bank_Details] ([ID_Bank_Details], [INN], [PPC], [BIC], [Payment_Account], [Correspondent_Account], [OGRN]) VALUES (6, N'31231', N'3123123', N'131312', N'54534', N'2342', N'123123')
INSERT [dbo].[Bank_Details] ([ID_Bank_Details], [INN], [PPC], [BIC], [Payment_Account], [Correspondent_Account], [OGRN]) VALUES (7, N'12345', N'1234541', N'12345', N'123415', N'123414', N'123451')
GO
INSERT [dbo].[Boiler_Fuel] ([ID_Fuel], [ID_Equipment]) VALUES (1, 1)
INSERT [dbo].[Boiler_Fuel] ([ID_Fuel], [ID_Equipment]) VALUES (1, 3)
INSERT [dbo].[Boiler_Fuel] ([ID_Fuel], [ID_Equipment]) VALUES (2, 1)
INSERT [dbo].[Boiler_Fuel] ([ID_Fuel], [ID_Equipment]) VALUES (2, 2)
INSERT [dbo].[Boiler_Fuel] ([ID_Fuel], [ID_Equipment]) VALUES (3, 2)
INSERT [dbo].[Boiler_Fuel] ([ID_Fuel], [ID_Equipment]) VALUES (3, 3)
GO
INSERT [dbo].[Company] ([ID_Company], [ID_Bank_Details], [Title_Company], [Address_Company], [Number_Phone], [Director]) VALUES (1, 3, N'МосОблГаз', N'г.Чехов ул.Мира д.3', N'89291231234', N'Максименко Олег Григорьевич')
INSERT [dbo].[Company] ([ID_Company], [ID_Bank_Details], [Title_Company], [Address_Company], [Number_Phone], [Director]) VALUES (2, 2, N'ООО Солнышко', N'г.Чехов ул.Чехова д.10', N'89772312312', N'Дмитренко Степан Федорович')
INSERT [dbo].[Company] ([ID_Company], [ID_Bank_Details], [Title_Company], [Address_Company], [Number_Phone], [Director]) VALUES (3, 1, N'ООО Чистый газ', N'г.Чехов ул.Дружбы д.15', N'89152323125', N'Григорьев Астап Петрович')
GO
INSERT [dbo].[Contract] ([ID_Contract], [Date_Conclusion], [Valid_For], [ID_Object], [ID_Employee], [ID_Equipment], [Price]) VALUES (1, CAST(N'2020-10-10' AS Date), CAST(N'2020-11-10' AS Date), 1, 1, 1, 150000.0000)
INSERT [dbo].[Contract] ([ID_Contract], [Date_Conclusion], [Valid_For], [ID_Object], [ID_Employee], [ID_Equipment], [Price]) VALUES (2, CAST(N'2021-05-20' AS Date), CAST(N'2021-08-20' AS Date), 2, 2, 3, 120000.0000)
INSERT [dbo].[Contract] ([ID_Contract], [Date_Conclusion], [Valid_For], [ID_Object], [ID_Employee], [ID_Equipment], [Price]) VALUES (3, CAST(N'2021-03-15' AS Date), CAST(N'2021-06-15' AS Date), 3, 3, 2, 210000.0000)
INSERT [dbo].[Contract] ([ID_Contract], [Date_Conclusion], [Valid_For], [ID_Object], [ID_Employee], [ID_Equipment], [Price]) VALUES (5, CAST(N'2022-04-06' AS Date), CAST(N'2022-04-07' AS Date), 2, 2, 1, 110000.0000)
INSERT [dbo].[Contract] ([ID_Contract], [Date_Conclusion], [Valid_For], [ID_Object], [ID_Employee], [ID_Equipment], [Price]) VALUES (6, CAST(N'2022-04-10' AS Date), CAST(N'2022-07-09' AS Date), 3, 1, 2, 111.0000)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middle_Name], [Post], [Salary], [Login], [Password]) VALUES (1, N'Жорохов ', N'Роман', N'Серегеевич', N'Генеральный директор', 100000.0000, N'', N'd63d630861a3c7ad1f06a9aaecb6d8753908ae8c778195e478e96621d06f6fcc')
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middle_Name], [Post], [Salary], [Login], [Password]) VALUES (2, N'Шолохова', N'Анжелина', N'Семеновна', N'Главный инженер проекта', 65000.0000, N'', N'8a975e5a8fe756485316bcf76d270eae03b84777a130f8acb125ab84e9266ad2')
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middle_Name], [Post], [Salary], [Login], [Password]) VALUES (3, N'Дорох', N'Алексей', N'Борисович', N'Технический инспектор проектного отдела', 45000.0000, N'qwe', N'2ec9b234f9794947d51f3528eb36c37d340f7da1d4ca00030649aabd3172bb5b')
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middle_Name], [Post], [Salary], [Login], [Password]) VALUES (4, N'Семенова', N'Валентина', N'Олеговна', N'Менеджер', 50000.0000, N'asd', N'f6e0a1e2ac41945a9aa7ff8a8aaa0cebc12a3bcc981a929ad5cf810a090e11ae')
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middle_Name], [Post], [Salary], [Login], [Password]) VALUES (5, N'Кочурина', N'Александра', N'Петровна', N'Технический инспектор проектного отдела', 45000.0000, N'', N'84d62ce0f94277fd07d92f7deafde7a3e3c029bc2975b4ad6a9d4af650f0f027')
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middle_Name], [Post], [Salary], [Login], [Password]) VALUES (6, N'Шолохов', N'Максим', N'Дмитриевич', N'Менеджер', 50000.0000, N'Maksim281179', N'65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5')
GO
INSERT [dbo].[Fuel] ([ID_Fuel], [Title_Fuel], [ID_Type_Fuel]) VALUES (1, N'Природный газ', 1)
INSERT [dbo].[Fuel] ([ID_Fuel], [Title_Fuel], [ID_Type_Fuel]) VALUES (2, N'Нет', 2)
INSERT [dbo].[Fuel] ([ID_Fuel], [Title_Fuel], [ID_Type_Fuel]) VALUES (3, N'Искусственный газ', 1)
GO
INSERT [dbo].[Main_Equipment(Boiler)] ([ID_Equipment], [Stamp], [Model], [Power], [Unit_Of_Measurement], [Quantity], [Service]) VALUES (1, N'Returino', N'R1 N 180 4X', 150, N'кВт', 2, N'Без обслуживания')
INSERT [dbo].[Main_Equipment(Boiler)] ([ID_Equipment], [Stamp], [Model], [Power], [Unit_Of_Measurement], [Quantity], [Service]) VALUES (2, N'Ferroli', N'F3 N 153 2S ', 200, N'кВт', 1, N'Без обслуживания')
INSERT [dbo].[Main_Equipment(Boiler)] ([ID_Equipment], [Stamp], [Model], [Power], [Unit_Of_Measurement], [Quantity], [Service]) VALUES (3, N'Cheroletti', N'Z3 N 211 77W ', 115, N'кВт', 3, N'Без обслуживания')
GO
INSERT [dbo].[Object] ([ID_Object], [Title_Object], [Purpose], [Work_Mode], [Address_Object], [Description], [ID_Company]) VALUES (1, N'Торговый комплекс "Цистерна"', N'Отопительная теплогенераторная для обеспечения нужд отопления торгового комплекса "Цистерна"', N'Отопительный сезон 214 дней, круглосуточный', N'Московская область, г.Чехов, дом №23 на уч. с кад. № 50:55:0030000:30, 50:55:0030004:0013.', N'Подвести безопасное газоснабжение к ТЦ', 1)
INSERT [dbo].[Object] ([ID_Object], [Title_Object], [Purpose], [Work_Mode], [Address_Object], [Description], [ID_Company]) VALUES (2, N'Торговый комплекс "Карусель"', N'Отопительная теплогенераторная для обеспечения нужд отопления торгового комплекса "Карусель"', N'Отопительный сезон 365 дней, круглосуточный', N'Московская область, г.Чехов, дом №11 на уч. с кад. № 50:75:0030000:90, 50:75:0030004:0019.', N'Подвести безопасное газоснабжение к ТЦ', 2)
INSERT [dbo].[Object] ([ID_Object], [Title_Object], [Purpose], [Work_Mode], [Address_Object], [Description], [ID_Company]) VALUES (3, N'Торговый комплекс "Ориентир"', N'Отопительная теплогенераторная для обеспечения нужд отопления торгового комплекса "Ориентир"', N'Отопительный сезон 250 дней, круглосуточный', N'Московская область, г.Чехов, дом №40 на уч. с кад. № 50:25:0030000:10, 50:25:0030004:0015.', N' ', 3)
GO
INSERT [dbo].[Type_Fuel] ([ID_Type_Fuel], [Title_Type_Fuel]) VALUES (1, N'Основное')
INSERT [dbo].[Type_Fuel] ([ID_Type_Fuel], [Title_Type_Fuel]) VALUES (2, N'Резервное')
GO
ALTER TABLE [dbo].[Boiler_Fuel]  WITH CHECK ADD FOREIGN KEY([ID_Equipment])
REFERENCES [dbo].[Main_Equipment(Boiler)] ([ID_Equipment])
GO
ALTER TABLE [dbo].[Boiler_Fuel]  WITH CHECK ADD FOREIGN KEY([ID_Fuel])
REFERENCES [dbo].[Fuel] ([ID_Fuel])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK__Company__ID_Bank__46E78A0C] FOREIGN KEY([ID_Bank_Details])
REFERENCES [dbo].[Bank_Details] ([ID_Bank_Details])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK__Company__ID_Bank__46E78A0C]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD FOREIGN KEY([ID_Employee])
REFERENCES [dbo].[Employee] ([ID_Employee])
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD FOREIGN KEY([ID_Equipment])
REFERENCES [dbo].[Main_Equipment(Boiler)] ([ID_Equipment])
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK__Contract__ID_Obj__4BAC3F29] FOREIGN KEY([ID_Object])
REFERENCES [dbo].[Object] ([ID_Object])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK__Contract__ID_Obj__4BAC3F29]
GO
ALTER TABLE [dbo].[Fuel]  WITH CHECK ADD FOREIGN KEY([ID_Type_Fuel])
REFERENCES [dbo].[Type_Fuel] ([ID_Type_Fuel])
GO
ALTER TABLE [dbo].[Object]  WITH CHECK ADD  CONSTRAINT [FK__Object__ID_Compa__4D94879B] FOREIGN KEY([ID_Company])
REFERENCES [dbo].[Company] ([ID_Company])
GO
ALTER TABLE [dbo].[Object] CHECK CONSTRAINT [FK__Object__ID_Compa__4D94879B]
GO
USE [master]
GO
ALTER DATABASE [AccountingforTransactions] SET  READ_WRITE 
GO
