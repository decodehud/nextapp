use nextapp

--Create procedure Listar solicitudes--
create procedure SP_GetAllSolicitudes
as
begin
select id_Solicitud,nombre,apellido,codigo_empleado,correo,telefono,cargo,fecha_solicitud,tipo_solicitud,mensaje,tecnico_asignado from SolicituEquipo
end
go

--Create procedure Crear nuevo registro de solicitud--
create procedure SP_CreateNewSolicitud
@nombre VARCHAR(50) ='',
@apellido VARCHAR(50) ='',
@codigo_empleado VARCHAR(50) ='',
@correo VARCHAR(50) ='',
@telefono VARCHAR(50) ='',
@cargo VARCHAR(50) ='',
@fecha_solicitud DATE ='',
@tipo_solicitud VARCHAR(50) ='',
@mensaje VARCHAR(50) =''
as
begin
insert into SolicituEquipo(nombre, apellido, codigo_empleado, correo, telefono, cargo, fecha_solicitud, tipo_solicitud, mensaje) values(@nombre,@apellido,@codigo_empleado,@correo,@telefono,@cargo,@fecha_solicitud,@tipo_solicitud,@mensaje)
end
go

--Create procedure Actualizar solictud--
create procedure SP_UpdateSolicitud(
@id_Solicitud int = 0,
@nombre varchar(50) = '',
@apellido varchar(50) = '',
@codigo_empleado varchar(50) ='',
@correo varchar(50) = '',
@telefono varchar(50)= '',
@cargo varchar(50)= '',
@fecha_solicitud varchar(50)= '',
@tipo_solicitud varchar(50)= '',
@mensaje varchar(50)= '',
@tecnico_asignado varchar(50)=''
)
as
begin
	update SolicituEquipo set nombre=@nombre, apellido=@apellido, codigo_empleado=@codigo_empleado, correo=@correo, telefono=@telefono, cargo=@cargo, tipo_solicitud=@tipo_solicitud, mensaje=@mensaje, tecnico_asignado=@tecnico_asignado where id_Solicitud=@id_Solicitud
end
go

--Create procedure Eliminar solicitud por id--
create procedure SP_DeleteSolicitud
@id_Solicitud int = 0
as
begin
		delete from SolicituEquipo where id_Solicitud=@id_Solicitud
end
go

--Create procedure obtener listado por Id--
create procedure SP_GetSolicitudById
@id_Solicitud int = 0
as
begin
		select * from SolicituEquipo
		where id_Solicitud=@id_Solicitud
end
go