CREATE DATABASE TaskManager
GO
USE TaskManager
GO
CREATE TABLE Users(
Id int primary key identity(1,1),
Usuario varchar(150) not null,
Password nvarchar(150) not null,
FechaCreacion datetime not null default getdate()
)
GO
INSERT INTO Users (Usuario, Password)
VALUES ('demo', '123456')
GO
CREATE TABLE Estado(
Id int primary key identity(1,1),
Nombre varchar(150) not null
)
GO
INSERT INTO Estado(Nombre)
VALUES('Nueva'),('En progreso'),('Terminada')
GO
CREATE TABLE Tasks(
Id int primary key identity(1,1),
Titulo varchar(150) not null,
Descripcion text not null,
CodigoEstado int not null,
CodigoUsuario int not null,
foreign key(CodigoEstado) references Estado(Id),
foreign key(CodigoUsuario) references Users(Id)
)
GO
