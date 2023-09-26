--Script de inserción/actualización autogenerado de la tabla cPuestos. Tomado del servidor SERVIDOR, Fecha de generación Apr 28 2017 10:31AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cPuestos] where PuestoId = '0')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('0','Administrador de Sistemas')
else
	update [cPuestos]
	set Nombre = 'Administrador de Sistemas' 
	where PuestoId = '0'
if not exists (select * from [cPuestos] where PuestoId = '1')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('1','Director General')
else
	update [cPuestos]
	set Nombre = 'Director General' 
	where PuestoId = '1'
if not exists (select * from [cPuestos] where PuestoId = '2')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('2','Gerente CxP')
else
	update [cPuestos]
	set Nombre = 'Gerente CxP' 
	where PuestoId = '2'
if not exists (select * from [cPuestos] where PuestoId = '3')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('3','Almacenista/Silos')
else
	update [cPuestos]
	set Nombre = 'Almacenista/Silos' 
	where PuestoId = '3'
if not exists (select * from [cPuestos] where PuestoId = '4')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('4','Transportista')
else
	update [cPuestos]
	set Nombre = 'Transportista' 
	where PuestoId = '4'
if not exists (select * from [cPuestos] where PuestoId = '5')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('5','Capturista')
else
	update [cPuestos]
	set Nombre = 'Capturista' 
	where PuestoId = '5'
if not exists (select * from [cPuestos] where PuestoId = '6')
	insert into [cPuestos] (PuestoId, Nombre)
	values ('6','Residente')
else
	update [cPuestos]
	set Nombre = 'Residente' 
	where PuestoId = '6'



--Script de inserción/actualización autogenerado de la tabla sUsuarios. Tomado del servidor SERVIDOR, Fecha de generación Apr 28 2017 10:36AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [sUsuarios] where UsrId = '0')
	insert into [sUsuarios] (UsrId, Nkname, Nombre, Apllidop, Apllidom, Cntrsnia, PerfilId, PuestoId, Ltimoacc, Correoe, Cntrscoe, SmtpId, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Usridan)
	values ('0','Administrador','','','','',NULL,'0','2017-04-11T00:00:00', '','',NULL,1,'2017-04-11T00:00:00', '0','2017-04-11T00:00:00', '0',NULL)
else
	update [sUsuarios]
	set Nkname = 'Administrador',	Nombre = '',	Apllidop = '',	Apllidom = '',	Cntrsnia = '',	PerfilId = NULL,	PuestoId = '0',	Ltimoacc = '2017-04-11T00:00:00',	Correoe = '',	Cntrscoe = '',	SmtpId = NULL,	Activo = 1,	Fchcrea = '2017-04-11T00:00:00',	Usrcrea = '0',	Fchmod = '2017-04-11T00:00:00',	Usrmod = '0',	Usridan = NULL 
	where UsrId = '0'
	



--Script de inserción/actualización autogenerado de la tabla cOpcsist. Tomado del servidor SERVIDOR, Fecha de generación Jul 31 2017 11:07AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cOpcsist] where OpcionId = 0)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (0,'<raíz>','Raíz de opciones',0,0,0)
else
	update [cOpcsist]
	set Nombre = '<raíz>',	Nmbmost = 'Raíz de opciones',	Prmsosap = 0,	Opcnidp = 0,	VisId = 0 
	where OpcionId = 0
if not exists (select * from [cOpcsist] where OpcionId = 1)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (1,'Herramientas','Herramientas',32,0,1)
else
	update [cOpcsist]
	set Nombre = 'Herramientas',	Nmbmost = 'Herramientas',	Prmsosap = 32,	Opcnidp = 0,	VisId = 1 
	where OpcionId = 1
if not exists (select * from [cOpcsist] where OpcionId = 2)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (2,'Opciones','Opciones',35,1,2)
else
	update [cOpcsist]
	set Nombre = 'Opciones',	Nmbmost = 'Opciones',	Prmsosap = 35,	Opcnidp = 1,	VisId = 2 
	where OpcionId = 2
if not exists (select * from [cOpcsist] where OpcionId = 3)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (3,'Administracion','Administración',32,1,3)
else
	update [cOpcsist]
	set Nombre = 'Administracion',	Nmbmost = 'Administración',	Prmsosap = 32,	Opcnidp = 1,	VisId = 3 
	where OpcionId = 3
if not exists (select * from [cOpcsist] where OpcionId = 4)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (4,'Perfiles','Perfiles',39,3,4)
else
	update [cOpcsist]
	set Nombre = 'Perfiles',	Nmbmost = 'Perfiles',	Prmsosap = 39,	Opcnidp = 3,	VisId = 4 
	where OpcionId = 4
if not exists (select * from [cOpcsist] where OpcionId = 5)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (5,'Usuarios','Usuarios',32,3,5)
else
	update [cOpcsist]
	set Nombre = 'Usuarios',	Nmbmost = 'Usuarios',	Prmsosap = 32,	Opcnidp = 3,	VisId = 5 
	where OpcionId = 5
if not exists (select * from [cOpcsist] where OpcionId = 6)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (6,'Usuarios','Usuarios',39,5,6)
else
	update [cOpcsist]
	set Nombre = 'Usuarios',	Nmbmost = 'Usuarios',	Prmsosap = 39,	Opcnidp = 5,	VisId = 6 
	where OpcionId = 6
if not exists (select * from [cOpcsist] where OpcionId = 7)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (7,'Cambio de contrasena','Cambio de contraseña',34,5,7)
else
	update [cOpcsist]
	set Nombre = 'Cambio de contrasena',	Nmbmost = 'Cambio de contraseña',	Prmsosap = 34,	Opcnidp = 5,	VisId = 7 
	where OpcionId = 7
if not exists (select * from [cOpcsist] where OpcionId = 8)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (8,'Registros','Registros',32,1,8)
else
	update [cOpcsist]
	set Nombre = 'Registros',	Nmbmost = 'Registros',	Prmsosap = 32,	Opcnidp = 1,	VisId = 8 
	where OpcionId = 8
if not exists (select * from [cOpcsist] where OpcionId = 9)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (9,'Mensajes del sistema','Mensajes del sistema',33,8,9)
else
	update [cOpcsist]
	set Nombre = 'Mensajes del sistema',	Nmbmost = 'Mensajes del sistema',	Prmsosap = 33,	Opcnidp = 8,	VisId = 9 
	where OpcionId = 9
if not exists (select * from [cOpcsist] where OpcionId = 10)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (10,'Modificaciones','Modificaciones',33,8,10)
else
	update [cOpcsist]
	set Nombre = 'Modificaciones',	Nmbmost = 'Modificaciones',	Prmsosap = 33,	Opcnidp = 8,	VisId = 10 
	where OpcionId = 10
if not exists (select * from [cOpcsist] where OpcionId = 15)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (15,'Catalogos','Catalogos',32,0,15)
else
	update [cOpcsist]
	set Nombre = 'Catalogos',	Nmbmost = 'Catalogos',	Prmsosap = 32,	Opcnidp = 0,	VisId = 15 
	where OpcionId = 15
if not exists (select * from [cOpcsist] where OpcionId = 16)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (16,'Trigos','Trigos',39,15,16)
else
	update [cOpcsist]
	set Nombre = 'Trigos',	Nmbmost = 'Trigos',	Prmsosap = 39,	Opcnidp = 15,	VisId = 16 
	where OpcionId = 16
if not exists (select * from [cOpcsist] where OpcionId = 17)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (17,'Origenes','Origenes',39,15,18)
else
	update [cOpcsist]
	set Nombre = 'Origenes',	Nmbmost = 'Origenes',	Prmsosap = 39,	Opcnidp = 15,	VisId = 18 
	where OpcionId = 17
if not exists (select * from [cOpcsist] where OpcionId = 18)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (18,'Destinos','Destinos',39,15,19)
else
	update [cOpcsist]
	set Nombre = 'Destinos',	Nmbmost = 'Destinos',	Prmsosap = 39,	Opcnidp = 15,	VisId = 19 
	where OpcionId = 18
if not exists (select * from [cOpcsist] where OpcionId = 19)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (19,'SMTP','SMTP',39,15,20)
else
	update [cOpcsist]
	set Nombre = 'SMTP',	Nmbmost = 'SMTP',	Prmsosap = 39,	Opcnidp = 15,	VisId = 20 
	where OpcionId = 19
if not exists (select * from [cOpcsist] where OpcionId = 20)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (20,'Operadores','Operadores',39,15,21)
else
	update [cOpcsist]
	set Nombre = 'Operadores',	Nmbmost = 'Operadores',	Prmsosap = 39,	Opcnidp = 15,	VisId = 21 
	where OpcionId = 20
if not exists (select * from [cOpcsist] where OpcionId = 21)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (21,'Transacciones','Transacciones',32,0,22)
else
	update [cOpcsist]
	set Nombre = 'Transacciones',	Nmbmost = 'Transacciones',	Prmsosap = 32,	Opcnidp = 0,	VisId = 22 
	where OpcionId = 21
if not exists (select * from [cOpcsist] where OpcionId = 22)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (22,'Ordenes','Ordenes',32,21,24)
else
	update [cOpcsist]
	set Nombre = 'Ordenes',	Nmbmost = 'Ordenes',	Prmsosap = 32,	Opcnidp = 21,	VisId = 24 
	where OpcionId = 22
if not exists (select * from [cOpcsist] where OpcionId = 23)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (23,'Ordenes','Ordenes',63,22,25)
else
	update [cOpcsist]
	set Nombre = 'Ordenes',	Nmbmost = 'Ordenes',	Prmsosap = 63,	Opcnidp = 22,	VisId = 25 
	where OpcionId = 23
if not exists (select * from [cOpcsist] where OpcionId = 24)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (24,'Acuerdo de compra de Trigo','Acuerdo de compra de Trigo',33,22,26)
else
	update [cOpcsist]
	set Nombre = 'Acuerdo de compra de Trigo',	Nmbmost = 'Acuerdo de compra de Trigo',	Prmsosap = 33,	Opcnidp = 22,	VisId = 26 
	where OpcionId = 24
if not exists (select * from [cOpcsist] where OpcionId = 25)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (25,'Embarques','Embarques',32,21,27)
else
	update [cOpcsist]
	set Nombre = 'Embarques',	Nmbmost = 'Embarques',	Prmsosap = 32,	Opcnidp = 21,	VisId = 27 
	where OpcionId = 25
if not exists (select * from [cOpcsist] where OpcionId = 26)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (26,'Embarques','Embarques',63,25,28)
else
	update [cOpcsist]
	set Nombre = 'Embarques',	Nmbmost = 'Embarques',	Prmsosap = 63,	Opcnidp = 25,	VisId = 28 
	where OpcionId = 26
if not exists (select * from [cOpcsist] where OpcionId = 27)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (27,'Factura fletes','Factura fletes',32,25,29)
else
	update [cOpcsist]
	set Nombre = 'Factura fletes',	Nmbmost = 'Factura fletes',	Prmsosap = 32,	Opcnidp = 25,	VisId = 29 
	where OpcionId = 27
if not exists (select * from [cOpcsist] where OpcionId = 28)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (28,'Carga masiva','Carga Masiva',32,25,30)
else
	update [cOpcsist]
	set Nombre = 'Carga masiva',	Nmbmost = 'Carga Masiva',	Prmsosap = 32,	Opcnidp = 25,	VisId = 30 
	where OpcionId = 28
if not exists (select * from [cOpcsist] where OpcionId = 29)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (29,'Ajustes','Ajustes',32,21,31)
else
	update [cOpcsist]
	set Nombre = 'Ajustes',	Nmbmost = 'Ajustes',	Prmsosap = 32,	Opcnidp = 21,	VisId = 31 
	where OpcionId = 29
if not exists (select * from [cOpcsist] where OpcionId = 30)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (30,'Ajustes','Ajustes',63,29,32)
else
	update [cOpcsist]
	set Nombre = 'Ajustes',	Nmbmost = 'Ajustes',	Prmsosap = 63,	Opcnidp = 29,	VisId = 32 
	where OpcionId = 30
if not exists (select * from [cOpcsist] where OpcionId = 31)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (31,'Ventas','Ventas',63,29,33)
else
	update [cOpcsist]
	set Nombre = 'Ventas',	Nmbmost = 'Ventas',	Prmsosap = 63,	Opcnidp = 29,	VisId = 33 
	where OpcionId = 31
if not exists (select * from [cOpcsist] where OpcionId = 32)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (32,'Reportes','Reportes',32,0,34)
else
	update [cOpcsist]
	set Nombre = 'Reportes',	Nmbmost = 'Reportes',	Prmsosap = 32,	Opcnidp = 0,	VisId = 34 
	where OpcionId = 32
if not exists (select * from [cOpcsist] where OpcionId = 33)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (33,'Trigo embarcado','Trigo embarcado',33,32,35)
else
	update [cOpcsist]
	set Nombre = 'Trigo embarcado',	Nmbmost = 'Trigo embarcado',	Prmsosap = 33,	Opcnidp = 32,	VisId = 35 
	where OpcionId = 33
if not exists (select * from [cOpcsist] where OpcionId = 34)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (34,'Embarques por recibir','Embarques por recibir',33,32,36)
else
	update [cOpcsist]
	set Nombre = 'Embarques por recibir',	Nmbmost = 'Embarques por recibir',	Prmsosap = 33,	Opcnidp = 32,	VisId = 36 
	where OpcionId = 34
if not exists (select * from [cOpcsist] where OpcionId = 35)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (35,'Embarques pendientes','Embarques pendientes',33,32,37)
else
	update [cOpcsist]
	set Nombre = 'Embarques pendientes',	Nmbmost = 'Embarques pendientes',	Prmsosap = 33,	Opcnidp = 32,	VisId = 37 
	where OpcionId = 35
if not exists (select * from [cOpcsist] where OpcionId = 36)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (36,'Embarques sin informacion','Embarques sin informacion',33,32,38)
else
	update [cOpcsist]
	set Nombre = 'Embarques sin informacion',	Nmbmost = 'Embarques sin informacion',	Prmsosap = 33,	Opcnidp = 32,	VisId = 38 
	where OpcionId = 36
if not exists (select * from [cOpcsist] where OpcionId = 37)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (37,'Laboratorio por proveedor','Laboratorio por proveedor',33,32,39)
else
	update [cOpcsist]
	set Nombre = 'Laboratorio por proveedor',	Nmbmost = 'Laboratorio por proveedor',	Prmsosap = 33,	Opcnidp = 32,	VisId = 39 
	where OpcionId = 37
if not exists (select * from [cOpcsist] where OpcionId = 38)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (38,'Reporte de Trigos','Reporte de Trigos',33,32,40)
else
	update [cOpcsist]
	set Nombre = 'Reporte de Trigos',	Nmbmost = 'Reporte de Trigos',	Prmsosap = 33,	Opcnidp = 32,	VisId = 40 
	where OpcionId = 38
if not exists (select * from [cOpcsist] where OpcionId = 39)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (39,'Reporte por Operador','Reporte por Operador',33,32,41)
else
	update [cOpcsist]
	set Nombre = 'Reporte por Operador',	Nmbmost = 'Reporte por Operador',	Prmsosap = 33,	Opcnidp = 32,	VisId = 41 
	where OpcionId = 39
if not exists (select * from [cOpcsist] where OpcionId = 40)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (40,'Reporte por Silo','Reporte por Silo',33,32,42)
else
	update [cOpcsist]
	set Nombre = 'Reporte por Silo',	Nmbmost = 'Reporte por Silo',	Prmsosap = 33,	Opcnidp = 32,	VisId = 42 
	where OpcionId = 40
if not exists (select * from [cOpcsist] where OpcionId = 41)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (41,'Reporte de Ajustes y Ventas','Reporte de Ajustes y Ventas',33,32,43)
else
	update [cOpcsist]
	set Nombre = 'Reporte de Ajustes y Ventas',	Nmbmost = 'Reporte de Ajustes y Ventas',	Prmsosap = 33,	Opcnidp = 32,	VisId = 43 
	where OpcionId = 41
if not exists (select * from [cOpcsist] where OpcionId = 42)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (42,'Reporte de trigo recibido','Reporte de trigo recibido',33,32,44)
else
	update [cOpcsist]
	set Nombre = 'Reporte de trigo recibido',	Nmbmost = 'Reporte de trigo recibido',	Prmsosap = 33,	Opcnidp = 32,	VisId = 44 
	where OpcionId = 42
if not exists (select * from [cOpcsist] where OpcionId = 43)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (43,'Inspecciones al transporte','Inspecciones al transporte',33,32,45)
else
	update [cOpcsist]
	set Nombre = 'Inspecciones al transporte',	Nmbmost = 'Inspecciones al transporte',	Prmsosap = 33,	Opcnidp = 32,	VisId = 45 
	where OpcionId = 43
if not exists (select * from [cOpcsist] where OpcionId = 44)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (44,'Inspecciones prim al trigo','Inspecciones primarias al trigo',33,32,46)
else
	update [cOpcsist]
	set Nombre = 'Inspecciones prim al trigo',	Nmbmost = 'Inspecciones primarias al trigo',	Prmsosap = 33,	Opcnidp = 32,	VisId = 46 
	where OpcionId = 44
if not exists (select * from [cOpcsist] where OpcionId = 45)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (45,'Proveedores de flete','Proveedores de flete',33,32,47)
else
	update [cOpcsist]
	set Nombre = 'Proveedores de flete',	Nmbmost = 'Proveedores de flete',	Prmsosap = 33,	Opcnidp = 32,	VisId = 47 
	where OpcionId = 45
if not exists (select * from [cOpcsist] where OpcionId = 46)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (46,'Proveedores','Proveedores',39,15,17)
else
	update [cOpcsist]
	set Nombre = 'Proveedores',	Nmbmost = 'Proveedores',	Prmsosap = 39,	Opcnidp = 15,	VisId = 17 
	where OpcionId = 46
if not exists (select * from [cOpcsist] where OpcionId = 47)
	insert into [cOpcsist] (OpcionId, Nombre, Nmbmost, Prmsosap, Opcnidp, VisId)
	values (47,'Lotes','Lotes',63,21,23)
else
	update [cOpcsist]
	set Nombre = 'Lotes',	Nmbmost = 'Lotes',	Prmsosap = 63,	Opcnidp = 21,	VisId = 23 
	where OpcionId = 47
	


--Script de inserción/actualización autogenerado de la tabla sPrfls1. Tomado del servidor SERVIDOR, Fecha de generación Apr 28 2017 10:34AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [sPrfls1] where PerfilId = '0')
	insert into [sPrfls1] (PerfilId, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod)
	values ('0','Manager',1,'2017-04-11T00:00:00', NULL,'2017-04-28T10:34:12.907', NULL)
else
	update [sPrfls1]
	set Nombre = 'Manager',	Activo = 1,	Fchcrea = '2017-04-11T00:00:00',	Usrcrea = NULL,	Fchmod = '2017-04-28T10:34:12.907',	Usrmod = NULL 
	where PerfilId = '0'
if not exists (select * from [sPrfls1] where PerfilId = '1')
	insert into [sPrfls1] (PerfilId, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod)
	values ('1','Invitado',1,'2017-04-13T00:00:00', '0','2017-04-13T00:00:00', '0')
else
	update [sPrfls1]
	set Nombre = 'Invitado',	Activo = 1,	Fchcrea = '2017-04-13T00:00:00',	Usrcrea = '0',	Fchmod = '2017-04-13T00:00:00',	Usrmod = '0' 
	where PerfilId = '1'--Script de inserción/actualización autogenerado de la tabla sPrfls2. Tomado del servidor SERVIDOR, Fecha de generación Jul 31 2017 11:12AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 0)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',0,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 0
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 1)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',1,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 1
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 2)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',2,1,1,1,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 2
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 3)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',3,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 3
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 4)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',4,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 4
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 5)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',5,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 5
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 6)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',6,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 6
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 7)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',7,1,0,1,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 1,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 7
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 8)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',8,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 8
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 9)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',9,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 9
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 10)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',10,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 10
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 15)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',15,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 15
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 16)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',16,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 16
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 17)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',17,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 17
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 18)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',18,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 18
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 19)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',19,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 19
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 20)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',20,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 20
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 21)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',21,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 21
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 22)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',22,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 22
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 23)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',23,1,1,1,1,1,1)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 1,	Cierre = 1 
	where PerfilId = '0' and OpcionId = 23
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 24)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',24,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 24
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 25)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',25,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 25
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 26)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',26,1,1,1,1,1,1)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 1,	Cierre = 1 
	where PerfilId = '0' and OpcionId = 26
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 27)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',27,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 27
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 28)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',28,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 28
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 29)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',29,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 29
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 30)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',30,1,1,1,1,1,1)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 1,	Cierre = 1 
	where PerfilId = '0' and OpcionId = 30
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 31)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',31,1,1,1,1,1,1)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 1,	Cierre = 1 
	where PerfilId = '0' and OpcionId = 31
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 32)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',32,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 32
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 33)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',33,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 33
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 34)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',34,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 34
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 35)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',35,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 35
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 36)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',36,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 36
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 37)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',37,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 37
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 38)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',38,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 38
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 39)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',39,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 39
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 40)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',40,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 40
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 41)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',41,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 41
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 42)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',42,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 42
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 43)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',43,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 43
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 44)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',44,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 44
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 45)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',45,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 45
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 46)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',46,1,1,1,1,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '0' and OpcionId = 46
if not exists (select * from [sPrfls2] where PerfilId = '0' and OpcionId = 47)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('0',47,1,1,1,1,1,1)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 1,	Creacion = 1,	Cnlacion = 1,	Cierre = 1 
	where PerfilId = '0' and OpcionId = 47
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 0)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',0,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 0
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 1)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',1,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 1
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 2)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',2,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 2
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 3)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',3,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 3
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 4)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',4,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 4
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 5)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',5,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 5
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 6)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',6,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 6
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 7)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',7,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 7
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 8)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',8,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 8
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 9)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',9,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 9
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 10)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',10,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 10
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 15)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',15,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 15
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 16)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',16,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 16
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 17)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',17,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 17
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 18)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',18,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 18
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 19)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',19,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 19
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 20)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',20,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 20
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 21)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',21,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 21
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 22)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',22,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 22
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 23)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',23,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 23
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 24)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',24,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 24
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 25)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',25,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 25
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 26)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',26,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 26
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 27)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',27,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 27
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 28)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',28,0,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 0,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 28
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 29)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',29,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 29
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 30)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',30,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 30
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 31)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',31,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 31
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 32)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',32,1,0,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 0,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 32
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 33)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',33,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 33
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 34)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',34,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 34
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 35)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',35,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 35
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 36)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',36,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 36
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 37)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',37,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 37
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 38)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',38,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 38
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 39)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',39,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 39
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 40)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',40,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 40
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 41)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',41,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 41
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 42)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',42,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 42
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 43)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',43,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 43
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 44)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',44,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 44
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 45)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',45,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 45
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 46)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',46,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 46
if not exists (select * from [sPrfls2] where PerfilId = '1' and OpcionId = 47)
	insert into [sPrfls2] (PerfilId, OpcionId, Activo, Consulta, Mdfccion, Creacion, Cnlacion, Cierre)
	values ('1',47,1,1,0,0,0,0)
else
	update [sPrfls2]
	set Activo = 1,	Consulta = 1,	Mdfccion = 0,	Creacion = 0,	Cnlacion = 0,	Cierre = 0 
	where PerfilId = '1' and OpcionId = 47






--Script de inserción/actualización autogenerado de la tabla cEstados. Tomado del servidor SERVIDOR, Fecha de generación Apr 28 2017 10:28AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cEstados] where EstadoId = 'A')
	insert into [cEstados] (EstadoId, Nombre)
	values ('A','Abierto')
else
	update [cEstados]
	set Nombre = 'Abierto' 
	where EstadoId = 'A'
if not exists (select * from [cEstados] where EstadoId = 'C')
	insert into [cEstados] (EstadoId, Nombre)
	values ('C','Cerrado')
else
	update [cEstados]
	set Nombre = 'Cerrado' 
	where EstadoId = 'C'
if not exists (select * from [cEstados] where EstadoId = 'L')
	insert into [cEstados] (EstadoId, Nombre)
	values ('L','Cancelado')
else
	update [cEstados]
	set Nombre = 'Cancelado' 
	where EstadoId = 'L'
	

--Script de inserción/actualización autogenerado de la tabla cTpoprov. Tomado del servidor SERVIDOR, Fecha de generación Apr 28 2017 10:32AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cTpoprov] where TpoprvId = 'T001')
	insert into [cTpoprov] (TpoprvId, Nombre)
	values ('T001','Proveedor de Trigo')
else
	update [cTpoprov]
	set Nombre = 'Proveedor de Trigo' 
	where TpoprvId = 'T001'
if not exists (select * from [cTpoprov] where TpoprvId = 'T002')
	insert into [cTpoprov] (TpoprvId, Nombre)
	values ('T002','Proveedor de Flete')
else
	update [cTpoprov]
	set Nombre = 'Proveedor de Flete' 
	where TpoprvId = 'T002'
if not exists (select * from [cTpoprov] where TpoprvId = 'T003')
	insert into [cTpoprov] (TpoprvId, Nombre)
	values ('T003','Proveedor Flete marítimo')
else
	update [cTpoprov]
	set Nombre = 'Proveedor Flete marítimo' 
	where TpoprvId = 'T003'
if not exists (select * from [cTpoprov] where TpoprvId = 'T004')
	insert into [cTpoprov] (TpoprvId, Nombre)
	values ('T004','Agente Aduanal')
else
	update [cTpoprov]
	set Nombre = 'Agente Aduanal' 
	where TpoprvId = 'T004'
	
	
	
	
	
--Script de inserción/actualización autogenerado de la tabla cTipodat. Tomado del servidor SERVIDOR, Fecha de generación May 28 2017 10:16PM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cTipodat] where TpodatId = 0)
	insert into [cTipodat] (TpodatId, Nombre)
	values (0,'No definido')
else
	update [cTipodat]
	set Nombre = 'No definido' 
	where TpodatId = 0
if not exists (select * from [cTipodat] where TpodatId = 1)
	insert into [cTipodat] (TpodatId, Nombre)
	values (1,'Texto')
else
	update [cTipodat]
	set Nombre = 'Texto' 
	where TpodatId = 1
if not exists (select * from [cTipodat] where TpodatId = 2)
	insert into [cTipodat] (TpodatId, Nombre)
	values (2,'Fecha')
else
	update [cTipodat]
	set Nombre = 'Fecha' 
	where TpodatId = 2
if not exists (select * from [cTipodat] where TpodatId = 3)
	insert into [cTipodat] (TpodatId, Nombre)
	values (3,'Booleano')
else
	update [cTipodat]
	set Nombre = 'Booleano' 
	where TpodatId = 3
if not exists (select * from [cTipodat] where TpodatId = 4)
	insert into [cTipodat] (TpodatId, Nombre)
	values (4,'FechaHora')
else
	update [cTipodat]
	set Nombre = 'FechaHora' 
	where TpodatId = 4
if not exists (select * from [cTipodat] where TpodatId = 5)
	insert into [cTipodat] (TpodatId, Nombre)
	values (5,'Booleano-Radio')
else
	update [cTipodat]
	set Nombre = 'Booleano-Radio' 
	where TpodatId = 5--Script de inserción/actualización autogenerado de la tabla cTipodoc. Tomado del servidor SERVIDOR, Fecha de generación May 28 2017 10:17PM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cTipodoc] where TpodocId = 0)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (0,'Desconocido')
else
	update [cTipodoc]
	set Nombre = 'Desconocido' 
	where TpodocId = 0
if not exists (select * from [cTipodoc] where TpodocId = 1)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (1,'Ninguno')
else
	update [cTipodoc]
	set Nombre = 'Ninguno' 
	where TpodocId = 1
if not exists (select * from [cTipodoc] where TpodocId = 2)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (2,'Lote')
else
	update [cTipodoc]
	set Nombre = 'Lote' 
	where TpodocId = 2
if not exists (select * from [cTipodoc] where TpodocId = 3)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (3,'Orden')
else
	update [cTipodoc]
	set Nombre = 'Orden' 
	where TpodocId = 3
if not exists (select * from [cTipodoc] where TpodocId = 4)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (4,'Embarque')
else
	update [cTipodoc]
	set Nombre = 'Embarque' 
	where TpodocId = 4
if not exists (select * from [cTipodoc] where TpodocId = 5)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (5,'Ajuste')
else
	update [cTipodoc]
	set Nombre = 'Ajuste' 
	where TpodocId = 5
if not exists (select * from [cTipodoc] where TpodocId = 6)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (6,'Venta')
else
	update [cTipodoc]
	set Nombre = 'Venta' 
	where TpodocId = 6
if not exists (select * from [cTipodoc] where TpodocId = 7)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (7,'Proveedor')
else
	update [cTipodoc]
	set Nombre = 'Proveedor' 
	where TpodocId = 7
if not exists (select * from [cTipodoc] where TpodocId = 8)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (8,'Trigo')
else
	update [cTipodoc]
	set Nombre = 'Trigo' 
	where TpodocId = 8
if not exists (select * from [cTipodoc] where TpodocId = 9)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (9,'Origen')
else
	update [cTipodoc]
	set Nombre = 'Origen' 
	where TpodocId = 9
if not exists (select * from [cTipodoc] where TpodocId = 10)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (10,'Destino')
else
	update [cTipodoc]
	set Nombre = 'Destino' 
	where TpodocId = 10
if not exists (select * from [cTipodoc] where TpodocId = 11)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (11,'Operador')
else
	update [cTipodoc]
	set Nombre = 'Operador' 
	where TpodocId = 11
if not exists (select * from [cTipodoc] where TpodocId = 12)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (12,'Proveedor de Trigo')
else
	update [cTipodoc]
	set Nombre = 'Proveedor de Trigo' 
	where TpodocId = 12
if not exists (select * from [cTipodoc] where TpodocId = 13)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (13,'Proveedor de Flete')
else
	update [cTipodoc]
	set Nombre = 'Proveedor de Flete' 
	where TpodocId = 13
if not exists (select * from [cTipodoc] where TpodocId = 14)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (14,'Proveedor de Flete Marítimo')
else
	update [cTipodoc]
	set Nombre = 'Proveedor de Flete Marítimo' 
	where TpodocId = 14
if not exists (select * from [cTipodoc] where TpodocId = 15)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (15,'Agente Aduanal')
else
	update [cTipodoc]
	set Nombre = 'Agente Aduanal' 
	where TpodocId = 15
if not exists (select * from [cTipodoc] where TpodocId = 16)
	insert into [cTipodoc] (TpodocId, Nombre)
	values (16,'Silo')
else
	update [cTipodoc]
	set Nombre = 'Silo' 
	where TpodocId = 16--Script de inserción/actualización autogenerado de la tabla sRprte1. Tomado del servidor SERVIDOR, Fecha de generación Jul 31 2017 11:17AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [sRprte1] where RprteId = 0)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (0,'Trigo Embarcado',1,'2017-05-02T00:00:00', '2017-05-02T00:00:00', 'Rtrigoemb.rpt',33)
else
	update [sRprte1]
	set Titulo = 'Trigo Embarcado',	Activo = 1,	Fchint = '2017-05-02T00:00:00',	Fchmod = '2017-05-02T00:00:00',	Nmbrpt = 'Rtrigoemb.rpt',	OpcionId = 33 
	where RprteId = 0
if not exists (select * from [sRprte1] where RprteId = 1)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (1,'Embarques pendientes por Recibir',1,'2017-05-11T00:00:00', '2017-05-11T00:00:00', 'Rembpend1.rpt',34)
else
	update [sRprte1]
	set Titulo = 'Embarques pendientes por Recibir',	Activo = 1,	Fchint = '2017-05-11T00:00:00',	Fchmod = '2017-05-11T00:00:00',	Nmbrpt = 'Rembpend1.rpt',	OpcionId = 34 
	where RprteId = 1
if not exists (select * from [sRprte1] where RprteId = 2)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (2,'Embarques pendientes Operarios',1,'2017-05-11T00:00:00', '2017-05-11T00:00:00', 'Rembpend2.rpt',35)
else
	update [sRprte1]
	set Titulo = 'Embarques pendientes Operarios',	Activo = 1,	Fchint = '2017-05-11T00:00:00',	Fchmod = '2017-05-11T00:00:00',	Nmbrpt = 'Rembpend2.rpt',	OpcionId = 35 
	where RprteId = 2
if not exists (select * from [sRprte1] where RprteId = 3)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (3,'Embarques sin Información de Laboratorios',1,'2017-05-11T00:00:00', '2017-05-11T00:00:00', 'Rembsin4.rpt',36)
else
	update [sRprte1]
	set Titulo = 'Embarques sin Información de Laboratorios',	Activo = 1,	Fchint = '2017-05-11T00:00:00',	Fchmod = '2017-05-11T00:00:00',	Nmbrpt = 'Rembsin4.rpt',	OpcionId = 36 
	where RprteId = 3
if not exists (select * from [sRprte1] where RprteId = 4)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (4,'Laboratorio por Proveedor',1,'2017-05-11T00:00:00', '2017-05-11T00:00:00', 'Rlabprov.rpt',37)
else
	update [sRprte1]
	set Titulo = 'Laboratorio por Proveedor',	Activo = 1,	Fchint = '2017-05-11T00:00:00',	Fchmod = '2017-05-11T00:00:00',	Nmbrpt = 'Rlabprov.rpt',	OpcionId = 37 
	where RprteId = 4
if not exists (select * from [sRprte1] where RprteId = 5)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (5,'Reporte de Trigos',1,'2017-04-28T00:00:00', '2017-04-28T00:00:00', 'Rtrigos.rpt',38)
else
	update [sRprte1]
	set Titulo = 'Reporte de Trigos',	Activo = 1,	Fchint = '2017-04-28T00:00:00',	Fchmod = '2017-04-28T00:00:00',	Nmbrpt = 'Rtrigos.rpt',	OpcionId = 38 
	where RprteId = 5
if not exists (select * from [sRprte1] where RprteId = 6)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (6,'Reporte por Operador',0,'2017-05-12T00:00:00', '2017-05-12T00:00:00', 'Roperador.rpt',39)
else
	update [sRprte1]
	set Titulo = 'Reporte por Operador',	Activo = 0,	Fchint = '2017-05-12T00:00:00',	Fchmod = '2017-05-12T00:00:00',	Nmbrpt = 'Roperador.rpt',	OpcionId = 39 
	where RprteId = 6
if not exists (select * from [sRprte1] where RprteId = 7)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (7,'Reporte por Silo',1,'2017-05-12T00:00:00', '2017-05-12T00:00:00', 'Rsilo.rpt',40)
else
	update [sRprte1]
	set Titulo = 'Reporte por Silo',	Activo = 1,	Fchint = '2017-05-12T00:00:00',	Fchmod = '2017-05-12T00:00:00',	Nmbrpt = 'Rsilo.rpt',	OpcionId = 40 
	where RprteId = 7
if not exists (select * from [sRprte1] where RprteId = 8)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (8,'Ajustes y Ventas',1,'2017-05-12T00:00:00', '2017-05-12T00:00:00', 'Rajve.rpt',41)
else
	update [sRprte1]
	set Titulo = 'Ajustes y Ventas',	Activo = 1,	Fchint = '2017-05-12T00:00:00',	Fchmod = '2017-05-12T00:00:00',	Nmbrpt = 'Rajve.rpt',	OpcionId = 41 
	where RprteId = 8
if not exists (select * from [sRprte1] where RprteId = 9)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (9,'Reporte de Trigo Recibido',1,'2017-05-12T00:00:00', '2017-05-12T00:00:00', 'Rtrigorec.rpt',42)
else
	update [sRprte1]
	set Titulo = 'Reporte de Trigo Recibido',	Activo = 1,	Fchint = '2017-05-12T00:00:00',	Fchmod = '2017-05-12T00:00:00',	Nmbrpt = 'Rtrigorec.rpt',	OpcionId = 42 
	where RprteId = 9
if not exists (select * from [sRprte1] where RprteId = 10)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (10,'Inspecciones al Transporte No Adecuadas',1,'2017-05-15T00:00:00', '2017-05-15T00:00:00', 'Rinstrsp.rpt',43)
else
	update [sRprte1]
	set Titulo = 'Inspecciones al Transporte No Adecuadas',	Activo = 1,	Fchint = '2017-05-15T00:00:00',	Fchmod = '2017-05-15T00:00:00',	Nmbrpt = 'Rinstrsp.rpt',	OpcionId = 43 
	where RprteId = 10
if not exists (select * from [sRprte1] where RprteId = 11)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (11,'Inspecciones Primarias al Trigo, no Adecuadas',1,'2017-05-15T00:00:00', '2017-05-15T00:00:00', 'Rinprtrg.rpt',44)
else
	update [sRprte1]
	set Titulo = 'Inspecciones Primarias al Trigo, no Adecuadas',	Activo = 1,	Fchint = '2017-05-15T00:00:00',	Fchmod = '2017-05-15T00:00:00',	Nmbrpt = 'Rinprtrg.rpt',	OpcionId = 44 
	where RprteId = 11
if not exists (select * from [sRprte1] where RprteId = 12)
	insert into [sRprte1] (RprteId, Titulo, Activo, Fchint, Fchmod, Nmbrpt, OpcionId)
	values (12,'Proveedor de Flete',1,'2017-05-09T00:00:00', '2017-05-09T00:00:00', 'Rprvflt.rpt',45)
else
	update [sRprte1]
	set Titulo = 'Proveedor de Flete',	Activo = 1,	Fchint = '2017-05-09T00:00:00',	Fchmod = '2017-05-09T00:00:00',	Nmbrpt = 'Rprvflt.rpt',	OpcionId = 45 
	where RprteId = 12





--Script de inserción/actualización autogenerado de la tabla sRprte2. Tomado del servidor SERVIDOR, Fecha de generación May 28 2017 10:21PM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,0,'@Loteid','No. Lote',1,2,1,'Número de lote. Si selecciona un lote únicamente, se recomienda dejar en blanco <No. Orden Inicial> y <No. Orden Final>.',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@Loteid',	Dscrpcion = 'No. Lote',	TpodatId = 1,	TpodocId = 2,	Activo = 1,	Leyenda = 'Número de lote. Si selecciona un lote únicamente, se recomienda dejar en blanco <No. Orden Inicial> y <No. Orden Final>.',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 0 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,1,'@OrdenId1','No. Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No. Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No. Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 0 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,2,'@OrdenId2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>.','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>.',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 0 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,3,'@OrigenId','Origen',1,9,1,'Seleccione Lugar de Origen...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@OrigenId',	Dscrpcion = 'Origen',	TpodatId = 1,	TpodocId = 9,	Activo = 1,	Leyenda = 'Seleccione Lugar de Origen...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 0 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,4,'@DstinoId','Destino',1,10,1,'Seleccione un Lugar de destino...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@DstinoId',	Dscrpcion = 'Destino',	TpodatId = 1,	TpodocId = 10,	Activo = 1,	Leyenda = 'Seleccione un Lugar de destino...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 0 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 5)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,5,'@TrigoId','Trigo',1,8,1,'Seleccione tipo de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@TrigoId',	Dscrpcion = 'Trigo',	TpodatId = 1,	TpodocId = 8,	Activo = 1,	Leyenda = 'Seleccione tipo de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 0 and ParamId = 5
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 6)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,6,'@ProvId','Proveedor de Trigo',1,12,1,'Seleccione un Proveedor de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@ProvId',	Dscrpcion = 'Proveedor de Trigo',	TpodatId = 1,	TpodocId = 12,	Activo = 1,	Leyenda = 'Seleccione un Proveedor de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 0 and ParamId = 6
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 7)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,7,'@Fchemb1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 0 and ParamId = 7
if not exists (select * from [sRprte2] where RprteId = 0 and ParamId = 8)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (0,8,'@Fchemb2','Hasta la fecha',2,4,1,'Hasta la fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 0 and ParamId = 8
if not exists (select * from [sRprte2] where RprteId = 1 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (1,0,'@OrdenId1','No.Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No.Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 1 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 1 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (1,1,'@OrdenId2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 1 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 1 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (1,2,'@DstinoId','Destino',1,10,1,'Seleccione un Lugar de destino...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@DstinoId',	Dscrpcion = 'Destino',	TpodatId = 1,	TpodocId = 10,	Activo = 1,	Leyenda = 'Seleccione un Lugar de destino...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 1 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 1 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (1,3,'@ProvId','Proveedor de Trigo',1,12,1,'Seleccione un Proveedor de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@ProvId',	Dscrpcion = 'Proveedor de Trigo',	TpodatId = 1,	TpodocId = 12,	Activo = 1,	Leyenda = 'Seleccione un Proveedor de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 1 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 1 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (1,4,'@TrigoId','Trigo',1,8,1,'Seleccione tipo de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@TrigoId',	Dscrpcion = 'Trigo',	TpodatId = 1,	TpodocId = 8,	Activo = 1,	Leyenda = 'Seleccione tipo de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 1 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 2 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (2,0,'@DstinoId','Destino',1,10,1,'Seleccione un Lugar de Destino...',NULL,1)
else
	update [sRprte2]
	set Nmbparam = '@DstinoId',	Dscrpcion = 'Destino',	TpodatId = 1,	TpodocId = 10,	Activo = 1,	Leyenda = 'Seleccione un Lugar de Destino...',	Valordef = NULL,	Rqrido = 1 
	where RprteId = 2 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 3 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (3,0,'@OrdenId1','No. Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 3 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 3 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (3,1,'@OrdenId2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 3 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 3 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (3,2,'@ProvId','Proveedor de Trigo',1,12,1,'Seleccione un Proveedor de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@ProvId',	Dscrpcion = 'Proveedor de Trigo',	TpodatId = 1,	TpodocId = 12,	Activo = 1,	Leyenda = 'Seleccione un Proveedor de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 3 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 3 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (3,3,'@TrigoId','Trigo',1,8,1,'Seleccione tipo de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@TrigoId',	Dscrpcion = 'Trigo',	TpodatId = 1,	TpodocId = 8,	Activo = 1,	Leyenda = 'Seleccione tipo de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 3 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,0,'@LoteId1','No. Lote Inicial',1,2,1,'Lote inicial de búsqueda. Funciona en conjunto con <No. Lote Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@LoteId1',	Dscrpcion = 'No. Lote Inicial',	TpodatId = 1,	TpodocId = 2,	Activo = 1,	Leyenda = 'Lote inicial de búsqueda. Funciona en conjunto con <No. Lote Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,1,'@LoteId2','No. Lote Final',1,2,1,'Lote final de búsqueda. Funciona en conjunto con <No. Lote Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@LoteId2',	Dscrpcion = 'No. Lote Final',	TpodatId = 1,	TpodocId = 2,	Activo = 1,	Leyenda = 'Lote final de búsqueda. Funciona en conjunto con <No. Lote Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,2,'@OrdenId1','No. Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,3,'@OrdenId2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,4,'@ProvId','Proveedor de Trigo',1,12,1,'Seleccione un Proveedor de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@ProvId',	Dscrpcion = 'Proveedor de Trigo',	TpodatId = 1,	TpodocId = 12,	Activo = 1,	Leyenda = 'Seleccione un Proveedor de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 4 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 5)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,5,'@TrigoId','Trigo',1,8,1,'Seleccione un tipode Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@TrigoId',	Dscrpcion = 'Trigo',	TpodatId = 1,	TpodocId = 8,	Activo = 1,	Leyenda = 'Seleccione un tipode Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 4 and ParamId = 5
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 6)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,6,'@DstinoId','Destino',1,10,1,'Seleccione un Lugar de Destino...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@DstinoId',	Dscrpcion = 'Destino',	TpodatId = 1,	TpodocId = 10,	Activo = 1,	Leyenda = 'Seleccione un Lugar de Destino...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 4 and ParamId = 6
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 7)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,7,'@Fchemb1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 7
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 8)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,8,'@Fchemb2','Hasta la fecha',2,4,1,'Hasta la Fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la Fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 8
if not exists (select * from [sRprte2] where RprteId = 4 and ParamId = 9)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (4,9,'@Solores','Sólo resumen',3,1,1,'Presentar sólo resumen informativo...','<FALSO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Solores',	Dscrpcion = 'Sólo resumen',	TpodatId = 3,	TpodocId = 1,	Activo = 1,	Leyenda = 'Presentar sólo resumen informativo...',	Valordef = '<FALSO>',	Rqrido = 1 
	where RprteId = 4 and ParamId = 9
if not exists (select * from [sRprte2] where RprteId = 5 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (5,0,'@Ordenid1','No. Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No. Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Ordenid1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No. Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 5 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 5 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (5,1,'@Ordenid2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>.','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Ordenid2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>.',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 5 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 5 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (5,2,'@Loteid','No. Lote',1,2,1,'Número de lote. Si selecciona un lote únicamente, se recomienda dejar en blanco <No. Orden Inicial> y <No. Orden Final>.',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@Loteid',	Dscrpcion = 'No. Lote',	TpodatId = 1,	TpodocId = 2,	Activo = 1,	Leyenda = 'Número de lote. Si selecciona un lote únicamente, se recomienda dejar en blanco <No. Orden Inicial> y <No. Orden Final>.',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 5 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 5 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (5,3,'@fchcons','Hasta la Fecha',2,1,1,'Fecha de corte del reporte.','<FECHA_ACTUAL>',1)
else
	update [sRprte2]
	set Nmbparam = '@fchcons',	Dscrpcion = 'Hasta la Fecha',	TpodatId = 2,	TpodocId = 1,	Activo = 1,	Leyenda = 'Fecha de corte del reporte.',	Valordef = '<FECHA_ACTUAL>',	Rqrido = 1 
	where RprteId = 5 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 5 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (5,4,'@Cerradas','Incluir Órdenes totalmente cerradas',3,1,1,'Incluir órdenes que cuyo ciclo ya ha concluido.','<FALSO>',0)
else
	update [sRprte2]
	set Nmbparam = '@Cerradas',	Dscrpcion = 'Incluir Órdenes totalmente cerradas',	TpodatId = 3,	TpodocId = 1,	Activo = 1,	Leyenda = 'Incluir órdenes que cuyo ciclo ya ha concluido.',	Valordef = '<FALSO>',	Rqrido = 0 
	where RprteId = 5 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 6 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (6,0,'@OprdorId','Operador',1,11,1,'Seleccione un Operador...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@OprdorId',	Dscrpcion = 'Operador',	TpodatId = 1,	TpodocId = 11,	Activo = 1,	Leyenda = 'Seleccione un Operador...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 6 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 6 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (6,1,'@Silo','Silo',1,1,1,'Seleccione un Silo',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@Silo',	Dscrpcion = 'Silo',	TpodatId = 1,	TpodocId = 1,	Activo = 1,	Leyenda = 'Seleccione un Silo',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 6 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 6 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (6,2,'@Fchrec1','De la fecha',2,4,1,'Desde la fecha...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchrec1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 6 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 6 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (6,3,'@Fchrec2','Hasta la fecha',2,4,1,'Hasta la fecha...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchrec2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 6 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 7 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (7,0,'@Silo','Silo',1,16,1,'Seleccione un Silo',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@Silo',	Dscrpcion = 'Silo',	TpodatId = 1,	TpodocId = 16,	Activo = 1,	Leyenda = 'Seleccione un Silo',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 7 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 7 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (7,1,'@TrigoId','Trigo',1,8,1,'Seleccione un tipo de Trigo',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@TrigoId',	Dscrpcion = 'Trigo',	TpodatId = 1,	TpodocId = 8,	Activo = 1,	Leyenda = 'Seleccione un tipo de Trigo',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 7 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 7 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (7,2,'@Fchrec1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchrec1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 7 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 7 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (7,3,'@Fchrec2','Hasta la fecha',2,4,1,'Hasta la fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchrec2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 7 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 8 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (8,0,'@OrdenId','No. Orden',1,3,1,'Seleccione un No. de Orden...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId',	Dscrpcion = 'No. Orden',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Seleccione un No. de Orden...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 8 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,0,'@fch1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@fch1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 9 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,1,'@fch2','Hasta la fecha',2,4,1,'Hasta la fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@fch2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 9 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,2,'@LoteId','No. Lote',1,2,1,'Seleccione un No. de Lote...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@LoteId',	Dscrpcion = 'No. Lote',	TpodatId = 1,	TpodocId = 2,	Activo = 1,	Leyenda = 'Seleccione un No. de Lote...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 9 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,3,'@OrdenId','No. Orden',1,3,1,'Seleccione un No. de Orden...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId',	Dscrpcion = 'No. Orden',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Seleccione un No. de Orden...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 9 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,4,'@TrigoId','Trigo',1,8,1,'Seleccione un tipo de Trigo...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@TrigoId',	Dscrpcion = 'Trigo',	TpodatId = 1,	TpodocId = 8,	Activo = 1,	Leyenda = 'Seleccione un tipo de Trigo...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 9 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 5)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,5,'@DstinoId','Destino',1,10,1,'Seleccione un Destino...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@DstinoId',	Dscrpcion = 'Destino',	TpodatId = 1,	TpodocId = 10,	Activo = 1,	Leyenda = 'Seleccione un Destino...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 9 and ParamId = 5
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 6)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,6,'@Solores','Sólo resumen',3,1,1,'Presentar sólo resumen informativo...','<FALSO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Solores',	Dscrpcion = 'Sólo resumen',	TpodatId = 3,	TpodocId = 1,	Activo = 1,	Leyenda = 'Presentar sólo resumen informativo...',	Valordef = '<FALSO>',	Rqrido = 1 
	where RprteId = 9 and ParamId = 6
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 7)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,7,'@Aorden','Agrupación por No. Orden',5,1,1,'Presentar agrupación por No. de Orden...','<VERDADERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Aorden',	Dscrpcion = 'Agrupación por No. Orden',	TpodatId = 5,	TpodocId = 1,	Activo = 1,	Leyenda = 'Presentar agrupación por No. de Orden...',	Valordef = '<VERDADERO>',	Rqrido = 1 
	where RprteId = 9 and ParamId = 7
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 8)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,8,'@Atrigo','Agrupación por Trigo',5,1,1,'Presentar agrupación por tipo de Trigo...','<FALSO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Atrigo',	Dscrpcion = 'Agrupación por Trigo',	TpodatId = 5,	TpodocId = 1,	Activo = 1,	Leyenda = 'Presentar agrupación por tipo de Trigo...',	Valordef = '<FALSO>',	Rqrido = 1 
	where RprteId = 9 and ParamId = 8
if not exists (select * from [sRprte2] where RprteId = 9 and ParamId = 9)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (9,9,'@Adstino','Agrupación por Destino',5,1,1,'Presentar agrupación por Destino...','<FALSO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Adstino',	Dscrpcion = 'Agrupación por Destino',	TpodatId = 5,	TpodocId = 1,	Activo = 1,	Leyenda = 'Presentar agrupación por Destino...',	Valordef = '<FALSO>',	Rqrido = 1 
	where RprteId = 9 and ParamId = 9
if not exists (select * from [sRprte2] where RprteId = 10 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (10,0,'@OrdenId1','No. Orden Inicial',1,3,1,'Funciona en conjunto con <No.Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Funciona en conjunto con <No.Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 10 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 10 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (10,1,'@OrdenId2','No. Orden Final',1,3,1,'Funciona en conjunto con <No.Orden Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Funciona en conjunto con <No.Orden Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 10 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 10 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (10,2,'@Provflet','Proveedor de Flete',1,13,1,'Seleccione un Proveedor de Flete',NULL,1)
else
	update [sRprte2]
	set Nmbparam = '@Provflet',	Dscrpcion = 'Proveedor de Flete',	TpodatId = 1,	TpodocId = 13,	Activo = 1,	Leyenda = 'Seleccione un Proveedor de Flete',	Valordef = NULL,	Rqrido = 1 
	where RprteId = 10 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 10 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (10,3,'@Fchemb1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 10 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 10 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (10,4,'@Fchemb2','Hasta la fecha',2,4,1,'Hasta la fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 10 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 11 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (11,0,'@OrdenId1','No. Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 11 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 11 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (11,1,'@OrdenId2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 11 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 11 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (11,2,'@DstinoId','Destino',1,10,1,'Seleccione un Destino...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@DstinoId',	Dscrpcion = 'Destino',	TpodatId = 1,	TpodocId = 10,	Activo = 1,	Leyenda = 'Seleccione un Destino...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 11 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 11 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (11,3,'@Fchemb1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 11 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 11 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (11,4,'@Fchemb2','Hasta la fecha',2,4,1,'Hasta la fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 11 and ParamId = 4
if not exists (select * from [sRprte2] where RprteId = 12 and ParamId = 0)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (12,0,'@OrdenId1','No. Orden Inicial',1,3,1,'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId1',	Dscrpcion = 'No. Orden Inicial',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden inicial de búsqueda. Funciona en conjunto con <No.Orden Final>',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 12 and ParamId = 0
if not exists (select * from [sRprte2] where RprteId = 12 and ParamId = 1)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (12,1,'@OrdenId2','No. Orden Final',1,3,1,'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@OrdenId2',	Dscrpcion = 'No. Orden Final',	TpodatId = 1,	TpodocId = 3,	Activo = 1,	Leyenda = 'Orden final de búsqueda. Funciona en conjunto con <No. Orden Inicial>',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 12 and ParamId = 1
if not exists (select * from [sRprte2] where RprteId = 12 and ParamId = 2)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (12,2,'@Fchemb1','De la fecha',2,4,1,'Desde la fecha de Embarque...','<PRIMERO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb1',	Dscrpcion = 'De la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Desde la fecha de Embarque...',	Valordef = '<PRIMERO>',	Rqrido = 1 
	where RprteId = 12 and ParamId = 2
if not exists (select * from [sRprte2] where RprteId = 12 and ParamId = 3)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (12,3,'@Fchemb2','Hasta la fecha',2,4,1,'Hasta la fecha de Embarque...','<ULTIMO>',1)
else
	update [sRprte2]
	set Nmbparam = '@Fchemb2',	Dscrpcion = 'Hasta la fecha',	TpodatId = 2,	TpodocId = 4,	Activo = 1,	Leyenda = 'Hasta la fecha de Embarque...',	Valordef = '<ULTIMO>',	Rqrido = 1 
	where RprteId = 12 and ParamId = 3
if not exists (select * from [sRprte2] where RprteId = 12 and ParamId = 4)
	insert into [sRprte2] (RprteId, ParamId, Nmbparam, Dscrpcion, TpodatId, TpodocId, Activo, Leyenda, Valordef, Rqrido)
	values (12,4,'@ProvId','Prov. Flete',1,13,1,'Proveedor de flete...',NULL,0)
else
	update [sRprte2]
	set Nmbparam = '@ProvId',	Dscrpcion = 'Prov. Flete',	TpodatId = 1,	TpodocId = 13,	Activo = 1,	Leyenda = 'Proveedor de flete...',	Valordef = NULL,	Rqrido = 0 
	where RprteId = 12 and ParamId = 4




--Script de inserción/actualización autogenerado de la tabla cMoneda. Tomado del servidor SERVIDOR, Fecha de generación May 29 2017 11:38AM.
--¡Úselo bajo su propia responsabilidad!
set dateformat ymd

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if not exists (select * from [cMoneda] where MonedaId = 'AED')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AED','Dirham de EAU',0)
else
	update [cMoneda]
	set Descripcion = 'Dirham de EAU',	Activo = 0 
	where MonedaId = 'AED'
if not exists (select * from [cMoneda] where MonedaId = 'AFN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AFN','Afghani',0)
else
	update [cMoneda]
	set Descripcion = 'Afghani',	Activo = 0 
	where MonedaId = 'AFN'
if not exists (select * from [cMoneda] where MonedaId = 'ALL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ALL','Lek',0)
else
	update [cMoneda]
	set Descripcion = 'Lek',	Activo = 0 
	where MonedaId = 'ALL'
if not exists (select * from [cMoneda] where MonedaId = 'AMD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AMD','Dram armenio',0)
else
	update [cMoneda]
	set Descripcion = 'Dram armenio',	Activo = 0 
	where MonedaId = 'AMD'
if not exists (select * from [cMoneda] where MonedaId = 'ANG')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ANG','Florín antillano neerlandés',0)
else
	update [cMoneda]
	set Descripcion = 'Florín antillano neerlandés',	Activo = 0 
	where MonedaId = 'ANG'
if not exists (select * from [cMoneda] where MonedaId = 'AOA')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AOA','Kwanza',0)
else
	update [cMoneda]
	set Descripcion = 'Kwanza',	Activo = 0 
	where MonedaId = 'AOA'
if not exists (select * from [cMoneda] where MonedaId = 'ARS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ARS','Peso Argentino',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Argentino',	Activo = 0 
	where MonedaId = 'ARS'
if not exists (select * from [cMoneda] where MonedaId = 'AUD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AUD','Dólar Australiano',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar Australiano',	Activo = 0 
	where MonedaId = 'AUD'
if not exists (select * from [cMoneda] where MonedaId = 'AWG')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AWG','Aruba Florin',0)
else
	update [cMoneda]
	set Descripcion = 'Aruba Florin',	Activo = 0 
	where MonedaId = 'AWG'
if not exists (select * from [cMoneda] where MonedaId = 'AZN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('AZN','Azerbaijanian Manat',0)
else
	update [cMoneda]
	set Descripcion = 'Azerbaijanian Manat',	Activo = 0 
	where MonedaId = 'AZN'
if not exists (select * from [cMoneda] where MonedaId = 'BAM')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BAM','Convertibles marca',0)
else
	update [cMoneda]
	set Descripcion = 'Convertibles marca',	Activo = 0 
	where MonedaId = 'BAM'
if not exists (select * from [cMoneda] where MonedaId = 'BBD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BBD','Dólar de Barbados',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Barbados',	Activo = 0 
	where MonedaId = 'BBD'
if not exists (select * from [cMoneda] where MonedaId = 'BDT')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BDT','Taka',0)
else
	update [cMoneda]
	set Descripcion = 'Taka',	Activo = 0 
	where MonedaId = 'BDT'
if not exists (select * from [cMoneda] where MonedaId = 'BGN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BGN','Lev búlgaro',0)
else
	update [cMoneda]
	set Descripcion = 'Lev búlgaro',	Activo = 0 
	where MonedaId = 'BGN'
if not exists (select * from [cMoneda] where MonedaId = 'BHD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BHD','Dinar de Bahrein',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar de Bahrein',	Activo = 0 
	where MonedaId = 'BHD'
if not exists (select * from [cMoneda] where MonedaId = 'BIF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BIF','Burundi Franc',0)
else
	update [cMoneda]
	set Descripcion = 'Burundi Franc',	Activo = 0 
	where MonedaId = 'BIF'
if not exists (select * from [cMoneda] where MonedaId = 'BMD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BMD','Dólar de Bermudas',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Bermudas',	Activo = 0 
	where MonedaId = 'BMD'
if not exists (select * from [cMoneda] where MonedaId = 'BND')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BND','Dólar de Brunei',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Brunei',	Activo = 0 
	where MonedaId = 'BND'
if not exists (select * from [cMoneda] where MonedaId = 'BOB')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BOB','Boliviano',0)
else
	update [cMoneda]
	set Descripcion = 'Boliviano',	Activo = 0 
	where MonedaId = 'BOB'
if not exists (select * from [cMoneda] where MonedaId = 'BOV')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BOV','Mvdol',0)
else
	update [cMoneda]
	set Descripcion = 'Mvdol',	Activo = 0 
	where MonedaId = 'BOV'
if not exists (select * from [cMoneda] where MonedaId = 'BRL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BRL','Real brasileño',0)
else
	update [cMoneda]
	set Descripcion = 'Real brasileño',	Activo = 0 
	where MonedaId = 'BRL'
if not exists (select * from [cMoneda] where MonedaId = 'BSD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BSD','Dólar de las Bahamas',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de las Bahamas',	Activo = 0 
	where MonedaId = 'BSD'
if not exists (select * from [cMoneda] where MonedaId = 'BTN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BTN','Ngultrum',0)
else
	update [cMoneda]
	set Descripcion = 'Ngultrum',	Activo = 0 
	where MonedaId = 'BTN'
if not exists (select * from [cMoneda] where MonedaId = 'BWP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BWP','Pula',0)
else
	update [cMoneda]
	set Descripcion = 'Pula',	Activo = 0 
	where MonedaId = 'BWP'
if not exists (select * from [cMoneda] where MonedaId = 'BYR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BYR','Rublo bielorruso',0)
else
	update [cMoneda]
	set Descripcion = 'Rublo bielorruso',	Activo = 0 
	where MonedaId = 'BYR'
if not exists (select * from [cMoneda] where MonedaId = 'BZD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('BZD','Dólar de Belice',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Belice',	Activo = 0 
	where MonedaId = 'BZD'
if not exists (select * from [cMoneda] where MonedaId = 'CAD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CAD','Dolar Canadiense',0)
else
	update [cMoneda]
	set Descripcion = 'Dolar Canadiense',	Activo = 0 
	where MonedaId = 'CAD'
if not exists (select * from [cMoneda] where MonedaId = 'CDF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CDF','Franco congoleño',0)
else
	update [cMoneda]
	set Descripcion = 'Franco congoleño',	Activo = 0 
	where MonedaId = 'CDF'
if not exists (select * from [cMoneda] where MonedaId = 'CHE')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CHE','WIR Euro',0)
else
	update [cMoneda]
	set Descripcion = 'WIR Euro',	Activo = 0 
	where MonedaId = 'CHE'
if not exists (select * from [cMoneda] where MonedaId = 'CHF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CHF','Franco Suizo',0)
else
	update [cMoneda]
	set Descripcion = 'Franco Suizo',	Activo = 0 
	where MonedaId = 'CHF'
if not exists (select * from [cMoneda] where MonedaId = 'CHW')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CHW','Franc WIR',0)
else
	update [cMoneda]
	set Descripcion = 'Franc WIR',	Activo = 0 
	where MonedaId = 'CHW'
if not exists (select * from [cMoneda] where MonedaId = 'CLF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CLF','Unidad de Fomento',0)
else
	update [cMoneda]
	set Descripcion = 'Unidad de Fomento',	Activo = 0 
	where MonedaId = 'CLF'
if not exists (select * from [cMoneda] where MonedaId = 'CLP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CLP','Peso chileno',0)
else
	update [cMoneda]
	set Descripcion = 'Peso chileno',	Activo = 0 
	where MonedaId = 'CLP'
if not exists (select * from [cMoneda] where MonedaId = 'CNY')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CNY','Yuan Renminbi',0)
else
	update [cMoneda]
	set Descripcion = 'Yuan Renminbi',	Activo = 0 
	where MonedaId = 'CNY'
if not exists (select * from [cMoneda] where MonedaId = 'COP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('COP','Peso Colombiano',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Colombiano',	Activo = 0 
	where MonedaId = 'COP'
if not exists (select * from [cMoneda] where MonedaId = 'COU')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('COU','Unidad de Valor real',0)
else
	update [cMoneda]
	set Descripcion = 'Unidad de Valor real',	Activo = 0 
	where MonedaId = 'COU'
if not exists (select * from [cMoneda] where MonedaId = 'CRC')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CRC','Colón costarricense',0)
else
	update [cMoneda]
	set Descripcion = 'Colón costarricense',	Activo = 0 
	where MonedaId = 'CRC'
if not exists (select * from [cMoneda] where MonedaId = 'CUC')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CUC','Peso Convertible',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Convertible',	Activo = 0 
	where MonedaId = 'CUC'
if not exists (select * from [cMoneda] where MonedaId = 'CUP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CUP','Peso Cubano',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Cubano',	Activo = 0 
	where MonedaId = 'CUP'
if not exists (select * from [cMoneda] where MonedaId = 'CVE')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CVE','Cabo Verde Escudo',0)
else
	update [cMoneda]
	set Descripcion = 'Cabo Verde Escudo',	Activo = 0 
	where MonedaId = 'CVE'
if not exists (select * from [cMoneda] where MonedaId = 'CZK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('CZK','Corona checa',0)
else
	update [cMoneda]
	set Descripcion = 'Corona checa',	Activo = 0 
	where MonedaId = 'CZK'
if not exists (select * from [cMoneda] where MonedaId = 'DJF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('DJF','Franco de Djibouti',0)
else
	update [cMoneda]
	set Descripcion = 'Franco de Djibouti',	Activo = 0 
	where MonedaId = 'DJF'
if not exists (select * from [cMoneda] where MonedaId = 'DKK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('DKK','Corona danesa',0)
else
	update [cMoneda]
	set Descripcion = 'Corona danesa',	Activo = 0 
	where MonedaId = 'DKK'
if not exists (select * from [cMoneda] where MonedaId = 'DOP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('DOP','Peso Dominicano',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Dominicano',	Activo = 0 
	where MonedaId = 'DOP'
if not exists (select * from [cMoneda] where MonedaId = 'DZD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('DZD','Dinar argelino',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar argelino',	Activo = 0 
	where MonedaId = 'DZD'
if not exists (select * from [cMoneda] where MonedaId = 'EGP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('EGP','Libra egipcia',0)
else
	update [cMoneda]
	set Descripcion = 'Libra egipcia',	Activo = 0 
	where MonedaId = 'EGP'
if not exists (select * from [cMoneda] where MonedaId = 'ERN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ERN','Nakfa',0)
else
	update [cMoneda]
	set Descripcion = 'Nakfa',	Activo = 0 
	where MonedaId = 'ERN'
if not exists (select * from [cMoneda] where MonedaId = 'ETB')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ETB','Birr etíope',0)
else
	update [cMoneda]
	set Descripcion = 'Birr etíope',	Activo = 0 
	where MonedaId = 'ETB'
if not exists (select * from [cMoneda] where MonedaId = 'EUR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('EUR','Euro',1)
else
	update [cMoneda]
	set Descripcion = 'Euro',	Activo = 1 
	where MonedaId = 'EUR'
if not exists (select * from [cMoneda] where MonedaId = 'FJD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('FJD','Dólar de Fiji',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Fiji',	Activo = 0 
	where MonedaId = 'FJD'
if not exists (select * from [cMoneda] where MonedaId = 'FKP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('FKP','Libra malvinense',0)
else
	update [cMoneda]
	set Descripcion = 'Libra malvinense',	Activo = 0 
	where MonedaId = 'FKP'
if not exists (select * from [cMoneda] where MonedaId = 'GBP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GBP','Libra Esterlina',0)
else
	update [cMoneda]
	set Descripcion = 'Libra Esterlina',	Activo = 0 
	where MonedaId = 'GBP'
if not exists (select * from [cMoneda] where MonedaId = 'GEL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GEL','Lari',0)
else
	update [cMoneda]
	set Descripcion = 'Lari',	Activo = 0 
	where MonedaId = 'GEL'
if not exists (select * from [cMoneda] where MonedaId = 'GHS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GHS','Cedi de Ghana',0)
else
	update [cMoneda]
	set Descripcion = 'Cedi de Ghana',	Activo = 0 
	where MonedaId = 'GHS'
if not exists (select * from [cMoneda] where MonedaId = 'GIP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GIP','Libra de Gibraltar',0)
else
	update [cMoneda]
	set Descripcion = 'Libra de Gibraltar',	Activo = 0 
	where MonedaId = 'GIP'
if not exists (select * from [cMoneda] where MonedaId = 'GMD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GMD','Dalasi',0)
else
	update [cMoneda]
	set Descripcion = 'Dalasi',	Activo = 0 
	where MonedaId = 'GMD'
if not exists (select * from [cMoneda] where MonedaId = 'GNF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GNF','Franco guineano',0)
else
	update [cMoneda]
	set Descripcion = 'Franco guineano',	Activo = 0 
	where MonedaId = 'GNF'
if not exists (select * from [cMoneda] where MonedaId = 'GTQ')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GTQ','Quetzal',0)
else
	update [cMoneda]
	set Descripcion = 'Quetzal',	Activo = 0 
	where MonedaId = 'GTQ'
if not exists (select * from [cMoneda] where MonedaId = 'GYD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('GYD','Dólar guyanés',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar guyanés',	Activo = 0 
	where MonedaId = 'GYD'
if not exists (select * from [cMoneda] where MonedaId = 'HKD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('HKD','Dolar De Hong Kong',0)
else
	update [cMoneda]
	set Descripcion = 'Dolar De Hong Kong',	Activo = 0 
	where MonedaId = 'HKD'
if not exists (select * from [cMoneda] where MonedaId = 'HNL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('HNL','Lempira',0)
else
	update [cMoneda]
	set Descripcion = 'Lempira',	Activo = 0 
	where MonedaId = 'HNL'
if not exists (select * from [cMoneda] where MonedaId = 'HRK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('HRK','Kuna',0)
else
	update [cMoneda]
	set Descripcion = 'Kuna',	Activo = 0 
	where MonedaId = 'HRK'
if not exists (select * from [cMoneda] where MonedaId = 'HTG')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('HTG','Gourde',0)
else
	update [cMoneda]
	set Descripcion = 'Gourde',	Activo = 0 
	where MonedaId = 'HTG'
if not exists (select * from [cMoneda] where MonedaId = 'HUF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('HUF','Florín',0)
else
	update [cMoneda]
	set Descripcion = 'Florín',	Activo = 0 
	where MonedaId = 'HUF'
if not exists (select * from [cMoneda] where MonedaId = 'IDR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('IDR','Rupia',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia',	Activo = 0 
	where MonedaId = 'IDR'
if not exists (select * from [cMoneda] where MonedaId = 'ILS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ILS','Nuevo Shekel Israelí',0)
else
	update [cMoneda]
	set Descripcion = 'Nuevo Shekel Israelí',	Activo = 0 
	where MonedaId = 'ILS'
if not exists (select * from [cMoneda] where MonedaId = 'INR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('INR','Rupia india',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia india',	Activo = 0 
	where MonedaId = 'INR'
if not exists (select * from [cMoneda] where MonedaId = 'IQD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('IQD','Dinar iraquí',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar iraquí',	Activo = 0 
	where MonedaId = 'IQD'
if not exists (select * from [cMoneda] where MonedaId = 'IRR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('IRR','Rial iraní',0)
else
	update [cMoneda]
	set Descripcion = 'Rial iraní',	Activo = 0 
	where MonedaId = 'IRR'
if not exists (select * from [cMoneda] where MonedaId = 'ISK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ISK','Corona islandesa',0)
else
	update [cMoneda]
	set Descripcion = 'Corona islandesa',	Activo = 0 
	where MonedaId = 'ISK'
if not exists (select * from [cMoneda] where MonedaId = 'JMD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('JMD','Dólar Jamaiquino',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar Jamaiquino',	Activo = 0 
	where MonedaId = 'JMD'
if not exists (select * from [cMoneda] where MonedaId = 'JOD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('JOD','Dinar jordano',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar jordano',	Activo = 0 
	where MonedaId = 'JOD'
if not exists (select * from [cMoneda] where MonedaId = 'JPY')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('JPY','Yen',0)
else
	update [cMoneda]
	set Descripcion = 'Yen',	Activo = 0 
	where MonedaId = 'JPY'
if not exists (select * from [cMoneda] where MonedaId = 'KES')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KES','Chelín keniano',0)
else
	update [cMoneda]
	set Descripcion = 'Chelín keniano',	Activo = 0 
	where MonedaId = 'KES'
if not exists (select * from [cMoneda] where MonedaId = 'KGS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KGS','Som',0)
else
	update [cMoneda]
	set Descripcion = 'Som',	Activo = 0 
	where MonedaId = 'KGS'
if not exists (select * from [cMoneda] where MonedaId = 'KHR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KHR','Riel',0)
else
	update [cMoneda]
	set Descripcion = 'Riel',	Activo = 0 
	where MonedaId = 'KHR'
if not exists (select * from [cMoneda] where MonedaId = 'KMF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KMF','Franco Comoro',0)
else
	update [cMoneda]
	set Descripcion = 'Franco Comoro',	Activo = 0 
	where MonedaId = 'KMF'
if not exists (select * from [cMoneda] where MonedaId = 'KPW')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KPW','Corea del Norte ganó',0)
else
	update [cMoneda]
	set Descripcion = 'Corea del Norte ganó',	Activo = 0 
	where MonedaId = 'KPW'
if not exists (select * from [cMoneda] where MonedaId = 'KRW')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KRW','Won',0)
else
	update [cMoneda]
	set Descripcion = 'Won',	Activo = 0 
	where MonedaId = 'KRW'
if not exists (select * from [cMoneda] where MonedaId = 'KWD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KWD','Dinar kuwaití',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar kuwaití',	Activo = 0 
	where MonedaId = 'KWD'
if not exists (select * from [cMoneda] where MonedaId = 'KYD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KYD','Dólar de las Islas Caimán',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de las Islas Caimán',	Activo = 0 
	where MonedaId = 'KYD'
if not exists (select * from [cMoneda] where MonedaId = 'KZT')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('KZT','Tenge',0)
else
	update [cMoneda]
	set Descripcion = 'Tenge',	Activo = 0 
	where MonedaId = 'KZT'
if not exists (select * from [cMoneda] where MonedaId = 'LAK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('LAK','Kip',0)
else
	update [cMoneda]
	set Descripcion = 'Kip',	Activo = 0 
	where MonedaId = 'LAK'
if not exists (select * from [cMoneda] where MonedaId = 'LBP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('LBP','Libra libanesa',0)
else
	update [cMoneda]
	set Descripcion = 'Libra libanesa',	Activo = 0 
	where MonedaId = 'LBP'
if not exists (select * from [cMoneda] where MonedaId = 'LKR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('LKR','Rupia de Sri Lanka',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia de Sri Lanka',	Activo = 0 
	where MonedaId = 'LKR'
if not exists (select * from [cMoneda] where MonedaId = 'LRD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('LRD','Dólar liberiano',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar liberiano',	Activo = 0 
	where MonedaId = 'LRD'
if not exists (select * from [cMoneda] where MonedaId = 'LSL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('LSL','Loti',0)
else
	update [cMoneda]
	set Descripcion = 'Loti',	Activo = 0 
	where MonedaId = 'LSL'
if not exists (select * from [cMoneda] where MonedaId = 'LYD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('LYD','Dinar libio',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar libio',	Activo = 0 
	where MonedaId = 'LYD'
if not exists (select * from [cMoneda] where MonedaId = 'MAD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MAD','Dirham marroquí',0)
else
	update [cMoneda]
	set Descripcion = 'Dirham marroquí',	Activo = 0 
	where MonedaId = 'MAD'
if not exists (select * from [cMoneda] where MonedaId = 'MDL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MDL','Leu moldavo',0)
else
	update [cMoneda]
	set Descripcion = 'Leu moldavo',	Activo = 0 
	where MonedaId = 'MDL'
if not exists (select * from [cMoneda] where MonedaId = 'MGA')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MGA','Ariary malgache',0)
else
	update [cMoneda]
	set Descripcion = 'Ariary malgache',	Activo = 0 
	where MonedaId = 'MGA'
if not exists (select * from [cMoneda] where MonedaId = 'MKD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MKD','Denar',0)
else
	update [cMoneda]
	set Descripcion = 'Denar',	Activo = 0 
	where MonedaId = 'MKD'
if not exists (select * from [cMoneda] where MonedaId = 'MMK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MMK','Kyat',0)
else
	update [cMoneda]
	set Descripcion = 'Kyat',	Activo = 0 
	where MonedaId = 'MMK'
if not exists (select * from [cMoneda] where MonedaId = 'MNT')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MNT','Tugrik',0)
else
	update [cMoneda]
	set Descripcion = 'Tugrik',	Activo = 0 
	where MonedaId = 'MNT'
if not exists (select * from [cMoneda] where MonedaId = 'MOP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MOP','Pataca',0)
else
	update [cMoneda]
	set Descripcion = 'Pataca',	Activo = 0 
	where MonedaId = 'MOP'
if not exists (select * from [cMoneda] where MonedaId = 'MRO')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MRO','Ouguiya',0)
else
	update [cMoneda]
	set Descripcion = 'Ouguiya',	Activo = 0 
	where MonedaId = 'MRO'
if not exists (select * from [cMoneda] where MonedaId = 'MUR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MUR','Rupia de Mauricio',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia de Mauricio',	Activo = 0 
	where MonedaId = 'MUR'
if not exists (select * from [cMoneda] where MonedaId = 'MVR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MVR','Rupia',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia',	Activo = 0 
	where MonedaId = 'MVR'
if not exists (select * from [cMoneda] where MonedaId = 'MWK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MWK','Kwacha',0)
else
	update [cMoneda]
	set Descripcion = 'Kwacha',	Activo = 0 
	where MonedaId = 'MWK'
if not exists (select * from [cMoneda] where MonedaId = 'MXN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MXN','Peso Mexicano',1)
else
	update [cMoneda]
	set Descripcion = 'Peso Mexicano',	Activo = 1 
	where MonedaId = 'MXN'
if not exists (select * from [cMoneda] where MonedaId = 'MXV')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MXV','México Unidad de Inversión (UDI)',0)
else
	update [cMoneda]
	set Descripcion = 'México Unidad de Inversión (UDI)',	Activo = 0 
	where MonedaId = 'MXV'
if not exists (select * from [cMoneda] where MonedaId = 'MYR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MYR','Ringgit malayo',0)
else
	update [cMoneda]
	set Descripcion = 'Ringgit malayo',	Activo = 0 
	where MonedaId = 'MYR'
if not exists (select * from [cMoneda] where MonedaId = 'MZN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('MZN','Mozambique Metical',0)
else
	update [cMoneda]
	set Descripcion = 'Mozambique Metical',	Activo = 0 
	where MonedaId = 'MZN'
if not exists (select * from [cMoneda] where MonedaId = 'NAD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('NAD','Dólar de Namibia',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Namibia',	Activo = 0 
	where MonedaId = 'NAD'
if not exists (select * from [cMoneda] where MonedaId = 'NGN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('NGN','Naira',0)
else
	update [cMoneda]
	set Descripcion = 'Naira',	Activo = 0 
	where MonedaId = 'NGN'
if not exists (select * from [cMoneda] where MonedaId = 'NIO')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('NIO','Córdoba Oro',0)
else
	update [cMoneda]
	set Descripcion = 'Córdoba Oro',	Activo = 0 
	where MonedaId = 'NIO'
if not exists (select * from [cMoneda] where MonedaId = 'NOK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('NOK','Corona noruega',0)
else
	update [cMoneda]
	set Descripcion = 'Corona noruega',	Activo = 0 
	where MonedaId = 'NOK'
if not exists (select * from [cMoneda] where MonedaId = 'NPR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('NPR','Rupia nepalí',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia nepalí',	Activo = 0 
	where MonedaId = 'NPR'
if not exists (select * from [cMoneda] where MonedaId = 'NZD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('NZD','Dólar de Nueva Zelanda',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Nueva Zelanda',	Activo = 0 
	where MonedaId = 'NZD'
if not exists (select * from [cMoneda] where MonedaId = 'OMR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('OMR','Rial omaní',0)
else
	update [cMoneda]
	set Descripcion = 'Rial omaní',	Activo = 0 
	where MonedaId = 'OMR'
if not exists (select * from [cMoneda] where MonedaId = 'PAB')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PAB','Balboa',0)
else
	update [cMoneda]
	set Descripcion = 'Balboa',	Activo = 0 
	where MonedaId = 'PAB'
if not exists (select * from [cMoneda] where MonedaId = 'PEN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PEN','Nuevo Sol',0)
else
	update [cMoneda]
	set Descripcion = 'Nuevo Sol',	Activo = 0 
	where MonedaId = 'PEN'
if not exists (select * from [cMoneda] where MonedaId = 'PGK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PGK','Kina',0)
else
	update [cMoneda]
	set Descripcion = 'Kina',	Activo = 0 
	where MonedaId = 'PGK'
if not exists (select * from [cMoneda] where MonedaId = 'PHP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PHP','Peso filipino',0)
else
	update [cMoneda]
	set Descripcion = 'Peso filipino',	Activo = 0 
	where MonedaId = 'PHP'
if not exists (select * from [cMoneda] where MonedaId = 'PKR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PKR','Rupia de Pakistán',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia de Pakistán',	Activo = 0 
	where MonedaId = 'PKR'
if not exists (select * from [cMoneda] where MonedaId = 'PLN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PLN','Zloty',0)
else
	update [cMoneda]
	set Descripcion = 'Zloty',	Activo = 0 
	where MonedaId = 'PLN'
if not exists (select * from [cMoneda] where MonedaId = 'PYG')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('PYG','Guaraní',0)
else
	update [cMoneda]
	set Descripcion = 'Guaraní',	Activo = 0 
	where MonedaId = 'PYG'
if not exists (select * from [cMoneda] where MonedaId = 'QAR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('QAR','Qatar Rial',0)
else
	update [cMoneda]
	set Descripcion = 'Qatar Rial',	Activo = 0 
	where MonedaId = 'QAR'
if not exists (select * from [cMoneda] where MonedaId = 'RON')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('RON','Leu rumano',0)
else
	update [cMoneda]
	set Descripcion = 'Leu rumano',	Activo = 0 
	where MonedaId = 'RON'
if not exists (select * from [cMoneda] where MonedaId = 'RSD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('RSD','Dinar serbio',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar serbio',	Activo = 0 
	where MonedaId = 'RSD'
if not exists (select * from [cMoneda] where MonedaId = 'RUB')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('RUB','Rublo ruso',0)
else
	update [cMoneda]
	set Descripcion = 'Rublo ruso',	Activo = 0 
	where MonedaId = 'RUB'
if not exists (select * from [cMoneda] where MonedaId = 'RWF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('RWF','Franco ruandés',0)
else
	update [cMoneda]
	set Descripcion = 'Franco ruandés',	Activo = 0 
	where MonedaId = 'RWF'
if not exists (select * from [cMoneda] where MonedaId = 'SAR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SAR','Riyal saudí',0)
else
	update [cMoneda]
	set Descripcion = 'Riyal saudí',	Activo = 0 
	where MonedaId = 'SAR'
if not exists (select * from [cMoneda] where MonedaId = 'SBD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SBD','Dólar de las Islas Salomón',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de las Islas Salomón',	Activo = 0 
	where MonedaId = 'SBD'
if not exists (select * from [cMoneda] where MonedaId = 'SCR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SCR','Rupia de Seychelles',0)
else
	update [cMoneda]
	set Descripcion = 'Rupia de Seychelles',	Activo = 0 
	where MonedaId = 'SCR'
if not exists (select * from [cMoneda] where MonedaId = 'SDG')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SDG','Libra sudanesa',0)
else
	update [cMoneda]
	set Descripcion = 'Libra sudanesa',	Activo = 0 
	where MonedaId = 'SDG'
if not exists (select * from [cMoneda] where MonedaId = 'SEK')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SEK','Corona sueca',0)
else
	update [cMoneda]
	set Descripcion = 'Corona sueca',	Activo = 0 
	where MonedaId = 'SEK'
if not exists (select * from [cMoneda] where MonedaId = 'SGD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SGD','Dolar De Singapur',0)
else
	update [cMoneda]
	set Descripcion = 'Dolar De Singapur',	Activo = 0 
	where MonedaId = 'SGD'
if not exists (select * from [cMoneda] where MonedaId = 'SHP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SHP','Libra de Santa Helena',0)
else
	update [cMoneda]
	set Descripcion = 'Libra de Santa Helena',	Activo = 0 
	where MonedaId = 'SHP'
if not exists (select * from [cMoneda] where MonedaId = 'SLL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SLL','Leona',0)
else
	update [cMoneda]
	set Descripcion = 'Leona',	Activo = 0 
	where MonedaId = 'SLL'
if not exists (select * from [cMoneda] where MonedaId = 'SOS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SOS','Chelín somalí',0)
else
	update [cMoneda]
	set Descripcion = 'Chelín somalí',	Activo = 0 
	where MonedaId = 'SOS'
if not exists (select * from [cMoneda] where MonedaId = 'SRD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SRD','Dólar de Suriname',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Suriname',	Activo = 0 
	where MonedaId = 'SRD'
if not exists (select * from [cMoneda] where MonedaId = 'SSP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SSP','Libra sudanesa Sur',0)
else
	update [cMoneda]
	set Descripcion = 'Libra sudanesa Sur',	Activo = 0 
	where MonedaId = 'SSP'
if not exists (select * from [cMoneda] where MonedaId = 'STD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('STD','Dobra',0)
else
	update [cMoneda]
	set Descripcion = 'Dobra',	Activo = 0 
	where MonedaId = 'STD'
if not exists (select * from [cMoneda] where MonedaId = 'SVC')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SVC','Colon El Salvador',0)
else
	update [cMoneda]
	set Descripcion = 'Colon El Salvador',	Activo = 0 
	where MonedaId = 'SVC'
if not exists (select * from [cMoneda] where MonedaId = 'SYP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SYP','Libra Siria',0)
else
	update [cMoneda]
	set Descripcion = 'Libra Siria',	Activo = 0 
	where MonedaId = 'SYP'
if not exists (select * from [cMoneda] where MonedaId = 'SZL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('SZL','Lilangeni',0)
else
	update [cMoneda]
	set Descripcion = 'Lilangeni',	Activo = 0 
	where MonedaId = 'SZL'
if not exists (select * from [cMoneda] where MonedaId = 'THB')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('THB','Baht',0)
else
	update [cMoneda]
	set Descripcion = 'Baht',	Activo = 0 
	where MonedaId = 'THB'
if not exists (select * from [cMoneda] where MonedaId = 'TJS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TJS','Somoni',0)
else
	update [cMoneda]
	set Descripcion = 'Somoni',	Activo = 0 
	where MonedaId = 'TJS'
if not exists (select * from [cMoneda] where MonedaId = 'TMT')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TMT','Turkmenistán nuevo manat',0)
else
	update [cMoneda]
	set Descripcion = 'Turkmenistán nuevo manat',	Activo = 0 
	where MonedaId = 'TMT'
if not exists (select * from [cMoneda] where MonedaId = 'TND')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TND','Dinar tunecino',0)
else
	update [cMoneda]
	set Descripcion = 'Dinar tunecino',	Activo = 0 
	where MonedaId = 'TND'
if not exists (select * from [cMoneda] where MonedaId = 'TOP')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TOP','Pa'anga',0)
else
	update [cMoneda]
	set Descripcion = 'Pa'anga',	Activo = 0 
	where MonedaId = 'TOP'
if not exists (select * from [cMoneda] where MonedaId = 'TRY')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TRY','Lira turca',0)
else
	update [cMoneda]
	set Descripcion = 'Lira turca',	Activo = 0 
	where MonedaId = 'TRY'
if not exists (select * from [cMoneda] where MonedaId = 'TTD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TTD','Dólar de Trinidad y Tobago',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar de Trinidad y Tobago',	Activo = 0 
	where MonedaId = 'TTD'
if not exists (select * from [cMoneda] where MonedaId = 'TWD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TWD','Nuevo dólar de Taiwán',0)
else
	update [cMoneda]
	set Descripcion = 'Nuevo dólar de Taiwán',	Activo = 0 
	where MonedaId = 'TWD'
if not exists (select * from [cMoneda] where MonedaId = 'TZS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('TZS','Shilling tanzano',0)
else
	update [cMoneda]
	set Descripcion = 'Shilling tanzano',	Activo = 0 
	where MonedaId = 'TZS'
if not exists (select * from [cMoneda] where MonedaId = 'UAH')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('UAH','Hryvnia',0)
else
	update [cMoneda]
	set Descripcion = 'Hryvnia',	Activo = 0 
	where MonedaId = 'UAH'
if not exists (select * from [cMoneda] where MonedaId = 'UGX')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('UGX','Shilling de Uganda',0)
else
	update [cMoneda]
	set Descripcion = 'Shilling de Uganda',	Activo = 0 
	where MonedaId = 'UGX'
if not exists (select * from [cMoneda] where MonedaId = 'USD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('USD','Dolar americano',1)
else
	update [cMoneda]
	set Descripcion = 'Dolar americano',	Activo = 1 
	where MonedaId = 'USD'
if not exists (select * from [cMoneda] where MonedaId = 'USN')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('USN','Dólar estadounidense (día siguiente)',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar estadounidense (día siguiente)',	Activo = 0 
	where MonedaId = 'USN'
if not exists (select * from [cMoneda] where MonedaId = 'UYI')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('UYI','Peso Uruguay en Unidades Indexadas (URUIURUI)',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Uruguay en Unidades Indexadas (URUIURUI)',	Activo = 0 
	where MonedaId = 'UYI'
if not exists (select * from [cMoneda] where MonedaId = 'UYU')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('UYU','Peso Uruguayo',0)
else
	update [cMoneda]
	set Descripcion = 'Peso Uruguayo',	Activo = 0 
	where MonedaId = 'UYU'
if not exists (select * from [cMoneda] where MonedaId = 'UZS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('UZS','Uzbekistán Sum',0)
else
	update [cMoneda]
	set Descripcion = 'Uzbekistán Sum',	Activo = 0 
	where MonedaId = 'UZS'
if not exists (select * from [cMoneda] where MonedaId = 'VEF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('VEF','Bolívar',0)
else
	update [cMoneda]
	set Descripcion = 'Bolívar',	Activo = 0 
	where MonedaId = 'VEF'
if not exists (select * from [cMoneda] where MonedaId = 'VND')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('VND','Dong',0)
else
	update [cMoneda]
	set Descripcion = 'Dong',	Activo = 0 
	where MonedaId = 'VND'
if not exists (select * from [cMoneda] where MonedaId = 'VUV')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('VUV','Vatu',0)
else
	update [cMoneda]
	set Descripcion = 'Vatu',	Activo = 0 
	where MonedaId = 'VUV'
if not exists (select * from [cMoneda] where MonedaId = 'WST')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('WST','Tala',0)
else
	update [cMoneda]
	set Descripcion = 'Tala',	Activo = 0 
	where MonedaId = 'WST'
if not exists (select * from [cMoneda] where MonedaId = 'XAF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XAF','Franco CFA BEAC',0)
else
	update [cMoneda]
	set Descripcion = 'Franco CFA BEAC',	Activo = 0 
	where MonedaId = 'XAF'
if not exists (select * from [cMoneda] where MonedaId = 'XAG')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XAG','Plata',0)
else
	update [cMoneda]
	set Descripcion = 'Plata',	Activo = 0 
	where MonedaId = 'XAG'
if not exists (select * from [cMoneda] where MonedaId = 'XAU')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XAU','Oro',0)
else
	update [cMoneda]
	set Descripcion = 'Oro',	Activo = 0 
	where MonedaId = 'XAU'
if not exists (select * from [cMoneda] where MonedaId = 'XBA')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XBA','Unidad de Mercados de Bonos Unidad Europea Composite (EURCO)',0)
else
	update [cMoneda]
	set Descripcion = 'Unidad de Mercados de Bonos Unidad Europea Composite (EURCO)',	Activo = 0 
	where MonedaId = 'XBA'
if not exists (select * from [cMoneda] where MonedaId = 'XBB')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XBB','Unidad Monetaria de Bonos de Mercados Unidad Europea (UEM-6)',0)
else
	update [cMoneda]
	set Descripcion = 'Unidad Monetaria de Bonos de Mercados Unidad Europea (UEM-6)',	Activo = 0 
	where MonedaId = 'XBB'
if not exists (select * from [cMoneda] where MonedaId = 'XBC')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XBC','Mercados de Bonos Unidad Europea unidad de cuenta a 9 (UCE-9)',0)
else
	update [cMoneda]
	set Descripcion = 'Mercados de Bonos Unidad Europea unidad de cuenta a 9 (UCE-9)',	Activo = 0 
	where MonedaId = 'XBC'
if not exists (select * from [cMoneda] where MonedaId = 'XBD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XBD','Mercados de Bonos Unidad Europea unidad de cuenta a 17 (UCE-17)',0)
else
	update [cMoneda]
	set Descripcion = 'Mercados de Bonos Unidad Europea unidad de cuenta a 17 (UCE-17)',	Activo = 0 
	where MonedaId = 'XBD'
if not exists (select * from [cMoneda] where MonedaId = 'XCD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XCD','Dólar del Caribe Oriental',0)
else
	update [cMoneda]
	set Descripcion = 'Dólar del Caribe Oriental',	Activo = 0 
	where MonedaId = 'XCD'
if not exists (select * from [cMoneda] where MonedaId = 'XDR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XDR','DEG (Derechos Especiales de Giro)',0)
else
	update [cMoneda]
	set Descripcion = 'DEG (Derechos Especiales de Giro)',	Activo = 0 
	where MonedaId = 'XDR'
if not exists (select * from [cMoneda] where MonedaId = 'XOF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XOF','Franco CFA BCEAO',0)
else
	update [cMoneda]
	set Descripcion = 'Franco CFA BCEAO',	Activo = 0 
	where MonedaId = 'XOF'
if not exists (select * from [cMoneda] where MonedaId = 'XPD')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XPD','Paladio',0)
else
	update [cMoneda]
	set Descripcion = 'Paladio',	Activo = 0 
	where MonedaId = 'XPD'
if not exists (select * from [cMoneda] where MonedaId = 'XPF')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XPF','Franco CFP',0)
else
	update [cMoneda]
	set Descripcion = 'Franco CFP',	Activo = 0 
	where MonedaId = 'XPF'
if not exists (select * from [cMoneda] where MonedaId = 'XPT')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XPT','Platino',0)
else
	update [cMoneda]
	set Descripcion = 'Platino',	Activo = 0 
	where MonedaId = 'XPT'
if not exists (select * from [cMoneda] where MonedaId = 'XSU')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XSU','Sucre',0)
else
	update [cMoneda]
	set Descripcion = 'Sucre',	Activo = 0 
	where MonedaId = 'XSU'
if not exists (select * from [cMoneda] where MonedaId = 'XTS')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XTS','Códigos reservados específicamente para propósitos de prueba',0)
else
	update [cMoneda]
	set Descripcion = 'Códigos reservados específicamente para propósitos de prueba',	Activo = 0 
	where MonedaId = 'XTS'
if not exists (select * from [cMoneda] where MonedaId = 'XUA')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XUA','Unidad ADB de Cuenta',0)
else
	update [cMoneda]
	set Descripcion = 'Unidad ADB de Cuenta',	Activo = 0 
	where MonedaId = 'XUA'
if not exists (select * from [cMoneda] where MonedaId = 'XXX')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('XXX','Los códigos asignados para las transacciones en que intervenga ninguna moneda',0)
else
	update [cMoneda]
	set Descripcion = 'Los códigos asignados para las transacciones en que intervenga ninguna moneda',	Activo = 0 
	where MonedaId = 'XXX'
if not exists (select * from [cMoneda] where MonedaId = 'YER')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('YER','Rial yemení',0)
else
	update [cMoneda]
	set Descripcion = 'Rial yemení',	Activo = 0 
	where MonedaId = 'YER'
if not exists (select * from [cMoneda] where MonedaId = 'ZAR')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ZAR','Rand',0)
else
	update [cMoneda]
	set Descripcion = 'Rand',	Activo = 0 
	where MonedaId = 'ZAR'
if not exists (select * from [cMoneda] where MonedaId = 'ZMW')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ZMW','Kwacha zambiano',0)
else
	update [cMoneda]
	set Descripcion = 'Kwacha zambiano',	Activo = 0 
	where MonedaId = 'ZMW'
if not exists (select * from [cMoneda] where MonedaId = 'ZWL')
	insert into [cMoneda] (MonedaId, Descripcion, Activo)
	values ('ZWL','Zimbabwe Dólar',0)
else
	update [cMoneda]
	set Descripcion = 'Zimbabwe Dólar',	Activo = 0 
	where MonedaId = 'ZWL'
