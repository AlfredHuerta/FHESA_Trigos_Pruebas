select *
from h_origenes




insert into sOrigen (OrigenId, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Orgnidan)
select 'RG' + right ('0000' + convert (varchar (5), ROW_NUMBER() over (order by h_o.Codigo)), 4) OrigenId,
h_o.Descripcion Nombre, 1 Activo, getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod, h_o.Codigo Orgnidan
from h_origenes h_o



select *
from sOrigen
