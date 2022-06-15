create procedure SP_ValidarUsuario(
@usuario varchar(20),
@contrasena varchar(20)
)
as 
begin
        select * from Usuario where usuario=@usuario and contrasena=@contrasena
end 
go

SP_ValidarUsuario 'mdeodanes','123'