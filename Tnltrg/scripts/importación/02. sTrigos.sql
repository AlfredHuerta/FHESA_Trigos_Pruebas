select *
from h_trigos



insert into sTrigos(TrigoId, Nombre, Activo, Fchcrea, Usrcrea, Fchmod, Usrmod, Trgoidan)
select 'T' + right ('000' + convert (varchar (5), ROW_NUMBER() over (order by h_t.Codigo)), 3) TrigoId,
h_t.Descripcion Nombre, 1 Activo, getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod, h_t.Codigo Trgoidan
from h_trigos h_t


select * 
from sTrigos