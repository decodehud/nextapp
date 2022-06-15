create database nextapp;

use nextapp;

CREATE TABLE SolicituEquipo(
id_Solicitud INT IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(50) NOT NULL,
apellido VARCHAR(50) NOT NULL,
codigo_empleado VARCHAR(50) NOT NULL,
correo VARCHAR(50) NOT NULL,
telefono VARCHAR(50) NOT NULL,
cargo VARCHAR(50) NOT NULL,
fecha_solicitud datetime default getdate(),
tipo_solicitud VARCHAR(50) NOT NULL,
mensaje VARCHAR(50) NOT NULL,
tecnico_asignado varchar(50) not null,
);


insert into SolicituEquipo(nombre, apellido, codigo_empleado, correo, telefono, cargo,tecnico_asignado, tipo_solicitud, mensaje) values
('Douglas','Deodanes','86232020','mdeodanes@caexlogistics.com','77958475','Analyst Support','Douglas Deodanes','Prestamo','Solicito prestamos de equipo desktop'),
('Diego','Alvarez','86232021','dalvarez@caexlogistics.com','77889977','System Analyst','Ruth Novoa','Asignacion','Asignacion de equipo laptop para nuevo colaborador')

select * from SolicituEquipo

-- Create table Equipos --
CREATE TABLE equipos(
id_equipos	INT NOT NULL PRIMARY KEY IDENTITY(1,1),
marca		VARCHAR	(50)	NOT NULL,
modelo		VARCHAR	(50)	NOT NULL,
serie		VARCHAR	(50)	NOT NULL,
caracteristicas VARCHAR(50)	NOT NULL,
tipo_equipo	VARCHAR	(50)	NOT NULL,
stock		VARCHAR(50) NOT NULL,
fecha_registro DATETIME default getdate() NOT NULL,
);

ALTER TABLE equipos
add stock VARCHAR(5)

--alter table equipos
--add fecha_registro VARCHAR(25) DEFAULT GETDATE();

SELECT * FROM equipos

INSERT INTO equipos (marca,modelo,serie,caracteristicas,tipo_equipo,stock) 
values	('Lenovo','Yoga Slim','KHFHGLGD','11th Gen Intel(R) Core(TM) i5-1135G7 @ 2.40GHz','Laptop','25'),
		('Asus','Ultra Slim','GTUHGURU','9th Gen Intel(R) Core(TM) i5-1135G7 @ 2.40GHz','Laptop','30'),
		('HP','UltraBook','SBJSNGKG','10th Gen Intel(R) Core(TM) i5-1135G7 @ 2.40GHz','Laptop','10')

-- Create table empleados --
CREATE TABLE empleados(
id_empleados	INT NOT NULL PRIMARY KEY IDENTITY(1,1),
nombre		VARCHAR (50)	NOT NULL,
apellido	VARCHAR	(50)	NOT NULL,
codigo_empleado VARCHAR	(50)	NOT NULL, 
cargo		VARCHAR	(50)	NOT NULL,
correo		VARCHAR (50)	NOT NULL,
departamento VARCHAR(50)	NOT NULL, 
equipo_asignado	VARCHAR(10) NULL,
fecha_asignacion DATETIME default getdate() NOT NULL,
id_equipos INT,
id_guest INT,
id_usuario INT,

CONSTRAINT FK_empleados_id_equipo FOREIGN KEY(id_equipos) REFERENCES equipos(id_equipos),
);

DROP TABLE empleados

INSERT INTO empleados(nombre,apellido, codigo_empleado,cargo,correo,departamento,equipo_asignado) VALUES
('Juan','Pablo','2517212020','System Analyst','jpablo@dudev.com','Infraestructura','no'),
('Benjamin','Vasquez','2517212025','Full Stack Developer','bhernandez@dudev.com','Infraestructura','si'),
('Juan','Vasques','2517212028','Web Desing developer','jvasques@dudev.com','Infraestructura','no'),
('Leticia','Monge','251721202','QA Analyst','lmonge@dudev.com','Infraestructura','no'),
('Ana','Maria','2517212027','Software Architec','amaria@dudev.com','Infraestructura','si')

SELECT id_empleados, nombre,apellido, codigo_empleado,cargo,correo,departamento,equipo_asignado,fecha_asignacion FROM empleados

SELECT * from equipos


