use nextapp

--Create procedure listar empleados--
create procedure SP_GetAllEmpleado
as
begin
SELECT id_empleados, nombre,apellido, codigo_empleado,cargo,correo,departamento,equipo_asignado,fecha_asignacion FROM empleados
end
go

--Create Procedure Crear nuevo registro de empleado--
create procedure SP_CreateNewEmpleado
@nombre varchar(50) = '',
@apellido varchar(50) = '',
@codigo_empleado varchar(50) = '',
@cargo varchar(50) = '',
@correo varchar(50) = '',
@departamento varchar(50) = '',
@equipo_asignado varchar(10) = ''
as
begin
insert into empleados(nombre,apellido,codigo_empleado,cargo,correo,departamento,equipo_asignado)values(@nombre, @apellido, @codigo_empleado, @cargo,@correo, @departamento, @equipo_asignado)
end
go

--Create Procedure Actualizar registro de empleados--
create procedure SP_UpdateEmpleado(
@id_empleados int = 0,
@nombre varchar(50) = '',
@apellido varchar(50) = '',
@codigo_empleado varchar(50) = '',
@cargo varchar(50) = '',
@correo varchar(50) = '',
@departamento varchar(50) = '',
@equipo_asignado varchar(10) = ''
)
as
begin
		update empleados set nombre=@nombre, apellido=@apellido, codigo_empleado=@codigo_empleado,cargo=@cargo,correo=@correo, departamento=@departamento, equipo_asignado=@equipo_asignado
		where id_empleados=@id_empleados
end
go

-- Create Procedure eliminar empleado por id--
create procedure SP_DeleteEmpleado(
@id_empleados int = 0

)
as
begin
		delete from empleados where id_empleados=@id_empleados
end
go

---Create procedure obtener listado de empleados por id-
create procedure SP_GetEmpleadoById(
@id_empleados int = 0

)
as
begin
		select * from empleados
		where id_empleados=@id_empleados
end
go
