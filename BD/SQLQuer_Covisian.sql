CREATE DATABASE [PruebaCovisian]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaCovisian', FILENAME = N'D:\Prueba Covisian\Data\PruebaCovisian.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaCovisian_log', FILENAME = N'D:\Prueba Covisian\Log\PruebaCovisian_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )

use PruebaCovisian
/*Creacion de tabla carro*/
create table TblCarro(
	CarroId int identity(1,1) primary key,
	Placa varchar(50) not null,
	Marca varchar(50) not null,
	Modelo varchar (200) not null,
	Costo decimal(18,2) not null,
	Disponible bit not null
);
/*Creacion de tabla cliente*/
create table TblCliente(
	ClienteId int identity(1,1) primary key,
	Cedula varchar(50) not null,
	Nombre varchar(100) not null,
	Telefono1 numeric(10) not null,
	Telefono2 numeric(10)
);

/*Creacion de tabla alquiler*/

create table TblAlquiler(
	AlquilerId int identity(1,1) primary key,
	FechaInicio datetime not null,
	FechaFin datetime,
	ValorTotal decimal(18,2) not null,
	AbonoInicial decimal (18,2) not null,
	Saldo decimal(18,2) not null,
	Devuelto bit not null,
	CarroId int not null,
	ClienteId int not null,
	foreign key(CarroId) references TblCarro(CarroId),
	foreign key(ClienteId) references TblCliente(ClienteId),
);

/*Creacion de tabla pagos*/

create table TblPago(
	PagoId int identity(1,1) primary key,
	FechaDePago datetime not null,
	Valor decimal(18,2) not null,
	AlquilerId int,
	foreign key(AlquilerId) references TblAlquiler(AlquilerId)
);

-- Insertar datos en la tabla TblCarro
INSERT INTO TblCarro (Placa, Marca, Modelo, Costo, Disponible) VALUES
('ABC123', 'Toyota', 'Corolla', 50000.00, 1),
('XYZ987', 'Honda', 'Civic', 45000.00, 1),
('DEF456', 'Ford', 'Focus', 40000.00, 1),
('GHI789', 'Chevrolet', 'Malibu', 55000.00, 0),
('JKL012', 'Nissan', 'Sentra', 42000.00, 1),
('MNO345', 'Mazda', '3', 47000.00, 1),
('PQR678', 'Hyundai', 'Elantra', 21000.00, 1),
('STU901', 'Volkswagen', 'Jetta', 23000.00, 1),
('VWX234', 'Mazda', '3', 20000.00, 1),
('YZA567', 'Subaru', 'Impreza', 22000.00, 1),
('BCD890', 'Kia', 'Forte', 18000.00, 1),
('EFG123', 'Tesla', 'Model 3', 35000.00, 1),
('HIJ456', 'BMW', '3 Series', 40000.00, 1),
('KLM789', 'Mercedes-Benz', 'C-Class', 42000.00, 1),
('NOP012', 'Audi', 'A4', 39000.00, 1),
('QRS345', 'Lexus', 'IS', 37000.00, 1);

-- Insertar datos en la tabla TblCliente
INSERT INTO TblCliente (Cedula, Nombre, Telefono1, Telefono2) VALUES
('1234567890', 'Juan Perez', 3001234567, 3101234567),
('0987654321', 'Maria Gomez', 3007654321, 3107654321),
('1122334455', 'Carlos Martinez', 3001122334, 3101122334),
('6677889900', 'Ana Rodriguez', 3006677889, 3106677889),
('3344556677', 'Luis Fernandez', 3003344556, 3103344556),
('4455667788', 'Marta Suarez', 3004455667, 3104455667),
('5678901234', 'Luis Garcia', 3005678901, 3005432109),
('6789012345', 'Laura Hernandez', 3006789012, 3004321098),
('7890123456', 'David Lopez', 3007890123, 3003210987),
('8901234567', 'Carolina Sanchez', 3008901234, 3002109876),
('9012345678', 'Jorge Torres', 3009012345, 3001098765),
('0123456789', 'Diana Ramirez', 3000123456, 3000987654);

-- Insertar datos en la tabla TblAlquiler
INSERT INTO TblAlquiler (FechaInicio, FechaFin, ValorTotal, AbonoInicial, Saldo, Devuelto, CarroId, ClienteId) VALUES
('2024-06-01 10:00:00', '2024-06-08 10:00:00', 350.00, 100.00, 250.00, 0, 1, 1),
('2024-06-02 11:00:00', '2024-06-06 11:00:00', 250.00, 50.00, 200.00, 0, 2, 2),
('2024-06-03 09:00:00', '2024-06-10 09:00:00', 300.00, 75.00, 225.00, 0, 3, 3),
('2024-06-04 14:00:00', '2024-06-09 14:00:00', 400.00, 150.00, 250.00, 0, 4, 4),
('2024-06-05 15:00:00', '2024-06-07 15:00:00', 200.00, 50.00, 150.00, 0, 5, 5),
('2024-06-06 08:00:00', '2024-06-12 08:00:00', 450.00, 100.00, 350.00, 0, 6, 6),
('2024-07-01 08:00:00', '2024-07-03 08:00:00', 450.00, 100.00, 350.00, 0, 6, 6),
('2024-07-01 09:00:00', '2024-07-10 08:00:00', 450.00, 100.00, 350.00, 0, 6, 6),
('2024-07-01 09:00:00', '2024-07-11 08:00:00', 450.00, 100.00, 350.00, 0, 6, 6);
-- Insertar datos en la tabla TblPago
INSERT INTO TblPago (FechaDePago, Valor, AlquilerId) VALUES
('2024-06-02 12:00:00', 100.00, 1),
('2024-06-03 12:00:00', 150.00, 1),
('2024-06-04 12:00:00', 50.00, 2),
('2024-06-05 12:00:00', 150.00, 2),
('2024-06-07 12:00:00', 75.00, 3),
('2024-06-08 12:00:00', 150.00, 4),
('2024-06-09 12:00:00', 100.00, 5),
('2024-06-10 12:00:00', 100.00, 6);

--1.2.Cuantos alquileres ha tenido un carro específico desde una fecha específica. (10 %)declare @fecha date = '2024-06-10'declare @placa varchar = 'DEF456'select count(*) from TblAlquiler aljoin TblCarro ca on al.CarroId = ca.CarroIdwhere ca.Placa = @placa and convert(date,al.FechaInicio) >= @fecha--1.3.El total de saldo en un día específico. (10 %)select sum(Saldo) saldoTotal,DATEPART(DD,FechaInicio)  DíaEspecifico from TblAlquilerwhere convert(date,FechaInicio)= @fechagroup by FechaInicio--1.4.Realice una consulta así: (20 %)Select cli.Cedula,cli.Nombre, DATEDIFF(DD,A.FechaInicio,A.FechaFin) as TiempoAlquilado, A.Saldo, ca.Placa,ca.Marca from TblAlquiler AJoin TblCliente cli on a.ClienteId = cli.ClienteIdJoin TblCarro Ca on a.CarroId = Ca.CarroId--Los clientes que no han alquilado en un periodo específicoSELECT 
    C.Cedula,
    C.Nombre
FROM 
    TblCliente C
WHERE 
    C.ClienteId NOT IN (
        SELECT 
            A.ClienteId
        FROM 
            TblAlquiler A
        WHERE 
            A.FechaInicio >= '2024-05-01 00:00:00'
            AND A.FechaInicio <= '2024-05-10 23:59:59'
    );

---.Realice la siguiente consulta desde una fecha específica


Select a.AlquilerId,a.FechaInicio,count(Pa.PagoId) CuantosPagos, Sum(Pa.Valor) TotalPagado, max(Pa.Valor) ValorMaximo from TblAlquiler A
join TblPago Pa on a.AlquilerId = Pa.AlquilerId
where A.FechaInicio >= '2024-06-01 00:00:00'
            AND A.FechaInicio <= '2024-06-10 23:59:59'
Group By FechaInicio, a.AlquilerId

--una consulta así: consolidado por carros en un periodo específico

Select 
b.CarroId, b.Modelo,b.Marca,b.Costo,count(a.CarroId) CuantosAlquileres ,Sum(A.ValorTotal) as ValorTotal
from TblAlquiler A
Join TblCarro B on a.CarroId = b.CarroId
where A.FechaInicio >= '2024-06-01 00:00:00'
            AND A.FechaInicio <= '2024-06-10 23:59:59'
group by b.CarroId, b.Modelo,b.Marca,b.Costo

--El primer alquiler de un cliente 

Select Cli.ClienteId, Cli.Nombre, min(A.FechaInicio)PrimerAlquiler,ca.Marca from  TblCliente Cli 
Join TblAlquiler A on Cli.ClienteId = A.ClienteId
Join TblCarro Ca on A.CarroId = Ca.CarroId
Group by Cli.ClienteId, Cli.Nombre,ca.Marca
Order by 3 

