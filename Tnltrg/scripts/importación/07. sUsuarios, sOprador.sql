select *
from h_USUARIOS



insert into sUsuarios(UsrId, Nkname, Apllidop, Cntrsnia, PerfilId, PuestoId, LtimoAcc, SmtpId,
						Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Usridan)
select convert (varchar (10), ROW_NUMBER() over (order by h_u.Usuario)) UsrId,
h_u.Usuario Nkname, h_u.Nombre Apllidop, h_u.[Password] Cntrsnia, 1 PerfilId, 6 PuestoId,
getdate() Ltimoacc, NULL SmtpId, case when Operador = 1 then
									0
								else
									1
								end activo,
getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod, h_u.Usuario Usridan
from h_Usuarios h_u


select *
from sUsuarios
  

if not exists (select OprdorId
				from sOprador
				where OprdorId = 'R000')
	insert into sOprador (OprdorId, Nkname, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Usridan)
	values ('R000', 'NOIDENTIF', 'NO IDENTIFICADO', 0, getdate(), 0, getdate(), 0, NULL)

insert into sOprador (OprdorId, Nkname, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Usridan)
select 'R' + right ('000' + convert (varchar (5), ROW_NUMBER() over (order by h_u.Usuario)), 3) OprdorId,
h_u.Usuario Nkname, h_u.Nombre Nombre,
1 Activo,
getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod, h_u.Usuario Usridan
from h_Usuarios h_u
where operador = 1

update sUsuarios
set OprdorId = op.OprdorId
from sUsuarios us inner join sOprador op
	on us.Usridan = op.Usridan

select *
from sOprador



