select *
from h_lotes

 

insert into sLotes(LoteId, ProvId, TrigoId, Proteina, Grado, Humedad, Pesohtl, Impureza,
Dockage, Vomitoxn, Ergot, Fllngnum, Obsrv, Fchcrea, Usrcrea, Fchmod, Usrmod, EstadoId, Fchlote, Otros)
select h_l.NumLotes LoteId, pr.ProvId ProvId, tr.TrigoId TrigoId, h_l.Proteina Proteina, 0 Grado,
h_l.Humedad Humedad, h_l.PesoHectolitro Pesohtl, h_l.Impureza Impureza, h_l.Dockage Dockage,
h_l.Vomitoxina Vomitoxn, h_l.Ergot Ergot, h_l.FallingN Fllngnum, h_l.Observaciones Obsrv,
getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod, 'A' EstadoId,
convert (date, dateadd (year, h_l.Ciclo - year(getdate()), getdate())) Fchlote, h_l.Otros Otros
from h_lotes h_l inner join sProveed pr
	on h_l.Proveedor = pr.Providan
inner join sTrigos tr
	on h_l.Trigo = tr.Trgoidan
where TpoPrvId = 'T001'




select *
from sLotes
