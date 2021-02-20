CREATE DATABASE Shelk

CREATE TABLE ROLES 
(RoleID int PRIMARY KEY IDENTITY(1,1),
RoleName VARCHAR (30));

CREATE TABLE Users
(
 ID int primary key IDENTITY(1,1),
 UserName varchar(max),
 UserLogin varchar(max),
 UserPassword varchar(max),
 RoleFK int foreign key references Roles(RoleID )
)

create table arendator
(
ArendatorID int primary key IDENTITY(1,1),
ArendatorName varchar(max),
ArendatorFloor varchar(max),
 LegalPerson varchar(max),
 GeneralDirector varchar(max),
 NumberContract varchar(max),
 DateContract date,
 AdressLegal varchar(max),
 AdressFact varchar(max),
  Commercial varchar(max),
  Contact varchar(max),
  Object varchar(max),
  PastArenda varchar(max),
  Curator varchar(max),
  Rate varchar(max),
  Marketing varchar(max),
  Communal varchar(max),
 Contact1 varchar(max),
 Post varchar(max),
 Email varchar(max))

CREATE table Comment
(
CommentID int primary key identity(1,1),
CommentName varchar(max),
CommentFK int foreign key references Arendator(ArendatorID)
)

INSERT INTO Roles VALUES('Админ')
INSERT INTO Roles VALUES('Бухгалтер')
INSERT INTO Roles VALUES('Юрист')
INSERT INTO Roles VALUES('Аренда')

INSERT INTO Users VALUES ('Андрей Черепанов','Cherep','123',1)

INSERT INTO q VALUES('фывыф')

SELECT * FROM Users
SELECT * FROM info
SELECT * FROM arendator

UPDATE arendator SET LegalPerson='adasdas' WHERE ArendatorID=1
DELETE FROM arendator where ArendatorID=5