create database rsiProject

use rsiProject

drop table activoFijo

create table categoria(
idCategoria int primary key identity (1,1),
nombreCategoria varchar(50) not null
)

create table activoFijo(
idActivoFijo int primary key identity (1,1),
nombreActivoFijo varchar(50) not null,
marca varchar(50) not null,
modelo varchar(50) not null,
numeroSerie varchar(50) not null,
valorAdquisicion decimal(10,2) not null,
codigoRSI varchar(50) null,
fechaCreacion datetime not null,
idCategoria int references categoria(idCategoria) not null
)

insert categoria(nombreCategoria) values ('Equipo de oficina')

insert activoFijo(nombreActivoFijo, marca, modelo, numeroSerie, valorAdquisicion, fechaCreacion, idCategoria, codigoRSI) values 
('Laptop', 'DELL', 'Latitude e7450', 'FDGER4564', 5999.99,  getdate(), 1, 'RSI123456789')

UPDATE activoFijo
SET codigoRSI = 'RSI123456789'
WHERE idActivoFijo = 1;

ALTER TABLE activoFijo
DROP COLUMN codigoRSI;

ALTER TABLE activoFijo
ADD codigoRSI varchar(50) null;

select * from categoria
select * from activoFijo

dbcc checkident('activoFijo', reseed, 0)
dbcc checkident('categoria', reseed, 0)

delete from activoFijo where idActivoFijo in (1,2)
delete from categoria where idCategoria in (2)