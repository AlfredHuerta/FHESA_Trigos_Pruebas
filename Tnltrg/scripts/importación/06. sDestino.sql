select *
from h_Destino

if not exists (select DstinoId
				from sDestino
				where DstinoId = 'DE0000')
	insert into sDestino (DstinoId, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Dstnidan)
	values ('DE0000', 'NO IDENTIFICADO', 0, getdate(), 0, getdate(), 0, NULL)

insert into sDestino (DstinoId, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Dstnidan)
select 'DE' + right ('0000' + convert (varchar (5), ROW_NUMBER() over (order by h_d.Codigo)), 4) DstinoId,
h_d.Descripcion Nombre, 1 Activo, getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod,
h_d.Codigo Dstnidan
from  h_Destino h_d



select *
from sDestino