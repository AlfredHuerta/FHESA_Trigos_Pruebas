select *
from h_Proveedores

--Agrega proveedores generales
insert into sProveed(ProvId, Nombre, Calle, Cntcto, TpoprvId, Providan, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod)
select 'P' + right ('00000' + convert (varchar (5), ROW_NUMBER() over (order by h_p.Codigo)), 5) ProvId,
h_p.Nombre, h_p.Direccion Calle, h_p.Contacto Cntcto,
'T001' TpoprvId, h_p.Codigo Providan, 1 Activo, getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod
from h_Proveedores h_p


--Agrega proveedores de fletes
insert into sProveed(ProvId, Nombre, Calle, Cntcto, TpoprvId, Providan, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod)
select 'P' + right ('00000' + convert (varchar (5), ROW_NUMBER() over (order by h_f.Codigo) + @@ROWCOUNT), 5) ProvId,
h_f.Descripcion, NULL Calle, '' Cntcto,
'T002' TpoprvId, h_f.Codigo Providan, 1 Activo, getdate() Fhcrea, 0 Usrcrea, getdate() Fhmod, 0 Usrmod
from h_Flete h_f 


update sProveed
set Activo = 0
where Providan in (
select Providan
from sProveed
group by Providan
having count (Providan) > 1)
and TpoprvId = 'T001'


select *
from sProveed