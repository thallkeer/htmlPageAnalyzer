create database HtmlPageAnalysis;
go
use HtmlPageAnalysis

create table [TextAnalysis](
	[Id] int primary key identity,
	[Date] datetime not null,
	[Url] nvarchar(max) not null,
	[Statistics] nvarchar(max) not null,
)