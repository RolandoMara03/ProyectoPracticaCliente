create database CV
restore database CV from disk='D:\CV.bak' with replace
use CV



--CRUD PARA CLIENTE
--Ingresa Nuevo Cliente
alter procedure AgregarCliente
@PN nvarchar(15),
@SN nvarchar(15),
@PA nvarchar(15),
@SA nvarchar(15),
@DIR nvarchar(70),
@TEL char(8),
@IDD int
as
declare @iddep int
set @iddep=(select Id_Dpto from Dept where Id_Dpto = @IDD)
if(@PN='' or @SN='' or @PA='' or @SA='' or @DIR='' or @TEL='')
begin
   print 'Se tienen que llenar todos los campos'
end
else
begin
   if(@IDD =@iddep)
   begin
      insert into Clientes values(@PN,@SN,@PA,@SA,@DIR,@TEL,@IDD,'A')
   end
end

AgregarCliente 'Nestor','José','Ramírez','Novoa','km8BoHugoChavez','78809876',1
select * from Clientes
select * from Dept

--DarBajaCliente
alter proc CambiarEstadoCliente
@ID int
as
declare @idc int
set @idc=(select Id_Cliente from Clientes where Id_Cliente=@ID)
declare @est nchar(10)
set @est=(select Estado from Clientes where Id_Cliente=@ID)
if(@ID=@idc)
begin
   if(@est='A')
   begin
      update Clientes 
	  set Estado ='I' where Id_Cliente=@ID
   end
   else
   begin
      if(@est='I')
   begin
      update Clientes 
	  set Estado ='A' where Id_Cliente=@ID
   end
end
end

CambiarEstadoCliente 4
select * from Clientes

--Busqueda Cliente
create procedure BC
@ID int 
as
declare @idc as int
set @idc=(select Id_Cliente from Clientes where Id_Cliente=@ID)
if(@idc=@ID)
begin
   select * from Clientes where Id_Cliente=@ID
end
else
begin
   print 'Cliente no encontrado'
end

BC 4

CambiarEstadoCliente 2
select * from Clientes

--ActualizarCliente
create procedure ActualizarCliente
@ID int,
@PN char(15),
@SN char(15),
@PA char(15),
@SA char(15),
@TEL char(8),
@DIR nvarchar(70),
@IDD int
as
declare @pnom char(15)
set @pnom=(select PN from Clientes where PN=@PN)
declare @snom char(15)
set @snom=(select SN from Clientes where SN=@SN)
declare @pApe char(15)
set @pApe=(select PA from Clientes where PA=@PA)
declare @sApe char(15)
set @sApe=(select SA from Clientes where SA=@SA)
declare @telf char(8)
set @telf =(select TelC from Clientes where TelC=@TEL)
declare @direc nvarchar(70)
set @direc=(select DirC from Clientes where DirC=@DIR)
declare @iddep int
set @iddep=(select Id_Dpto from Dept where Id_Dpto=@IDD)
if(@PN=@pnom or @SN=@snom or @PA=@pApe or @SA=@sApe or @DIR=@direc or @IDD=@iddep)
begin
   print 'No puede duplicarse el registro'
end
else
begin
   if(@PN='' or @SN='' or @PA='' or @SA='' or @DIR='')
   begin
      print 'No puede ser nulo'
   end
   else
   begin
      if(@IDD=@iddep)
	  begin
	     update Clientes
		 set PN=@PN,SN=@SN,PA=@PA,SA=@SA,DirC=@DIR,TelC=@TEL,Id_Dpto=@IDD
		 where Id_Cliente=@ID
	  end
	  else
	  begin
	     print 'El departamento no existe'
	  end
   end
end

ActualizarCliente 4, 'Carlos', 'Joel', 'Arcia','Zambrana','BoHugoChavez','89495467',1
select * from Clientes




--CRUD PARA PRODUCTOS
--AgregarNuevoProducto
alter proc ANProducto
@CODP char(5),
@NP nvarchar(25),
@P float,
@EX int,
@DESCP nvarchar(35),
@IDPROV char(5)
as
declare @codprod char(5)
set @codprod=(select CodProd from Productos where CodProd=@CODP)
declare @nomp nvarchar(25)
set @nomp =(select NProd from Productos where NProd=@NP)
declare @idpro char(5)
set @idpro=(select Id_Prov from Proveedor where Id_Prov=@IDPROV)
if(@CODP=@codprod or @NP=@nomp)
begin
   print 'Producto existente'
end
else
begin 
   if(@P>0 and @EX>0)
   begin
      if(@IDPROV=@idpro)
	  begin
	     insert into Productos values(@CODP,@NP,@P,@EX,@DESCP,@IDPROV,'A')
	  end
	  else
	  begin
	     print 'No existe el proveedor'
	  end
   end
   else
   begin
      print 'No puede ser menor ni igual a cero'
   end
end

ANProducto '06','Gencloben',90,80,'Irritacion','0001'
select * from Productos

--DarBajaProducto
ALTER TABLE Productos 
ADD Estado char(1)
update Productos
set Estado = 'A'

create proc DBProducto
@COD char(5)
as
declare @codProd char(5)
set @codProd=(select CodProd from Productos where CodProd=@COD)
declare @est char(1)
set @est=(select Estado from Productos where CodProd=@COD)
if(@COD=@codProd)
begin
   if(@est='A')
   begin
      update Productos
	  set Estado='I' where CodProd = @COD
   end
   else
   begin
      if(@est='I')
      begin
         update Productos
	     set Estado='A' where CodProd = @COD
	  end
   end
end

DBProducto '03'
select * from Productos






--USUARIO
-- 1.- Administrador
-- Creando cuenta
sp_addlogin 'Jefe','Admin2022','CV'
-- Asociar role a la cuenta
sp_addsrvrolemember 'Jefe',sysadmin

-- Crear Usuario
sp_adduser 'Jefe','Rey'

-- Asociar privilegios al usuario
sp_addrolemember 'db_ddladmin','Rey'

-- Usuario Solo lectura
sp_addlogin 'Pepito','Pepito123','CV'
sp_addsrvrolemember 'Pepito','dbcreator'
sp_adduser 'Pepito','Pepito'
sp_addrolemember 'db_denydatawriter','Pepito'
sp_addrolemember 'db_datareader','Pepito'



CREATE PROCEDURE ViewClientes
as
begin
select* from Clientes
end

exec ViewClientes