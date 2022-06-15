use nextapp

--Create procedure Listar Equipos--
create procedure SP_GetAllEquipo
as
begin
SELECT id_equipos, marca, modelo, serie,caracteristicas,tipo_equipo,stock,fecha_registro FROM equipos
end
go

--Create procedure Crear nuevo registro de equipo--
create procedure SP_CreateNewEquipo(
@marca varchar(50) = '',
@modelo varchar(50) = '',
@serie varchar(50) = '',
@caracteristicas varchar(50) = '',
@tipo_equipo varchar(50) = ''
)
as
begin
insert into equipos(marca, modelo, serie,caracteristicas,tipo_equipo)values(@marca, @modelo, @serie,@caracteristicas,@tipo_equipo)
end
go

--Create procedure actualizar registro de equipo--
create procedure SP_UpdateEquipo(
@id_equipos int = 0,
@marca varchar(50) = '',
@modelo varchar(50) = '',
@serie varchar(50) = '',
@caracteristicas varchar(50) = '',
@tipo_equipo varchar(50) = '',
@stock varchar(50) = ''
)
as
begin
		update equipos set marca=@marca, modelo=@modelo, serie=@serie,caracteristicas=@caracteristicas, tipo_equipo=@tipo_equipo, stock=@stock where id_equipos=@id_equipos
end
go

--Create procedure eliminar equipo por id---
create procedure SP_DeleteEquipo(
@id_equipos int = 0
)
as
begin
		delete from equipos where id_equipos=@id_equipos
end
go

--Create procedure Obtener listado de equipos por id--

create procedure SP_GetEquipoById(
@id_equipos int = 0
)
as
begin
		select * from equipos
		where id_equipos=@id_equipos
end
go
