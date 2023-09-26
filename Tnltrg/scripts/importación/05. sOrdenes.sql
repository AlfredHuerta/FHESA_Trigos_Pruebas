select *
from h_Ordenes



insert into sOrdenes(OrdenId, CtrtoId, LoteId, OrigenId, Tnladas, Tlrancia, Peremb,
					Incoterm, Ritmo, Moneda, Refftro, Base, Mesfutu, Prcionto,
					Obsrv, Laycan, Ptocarga, Ptodscg, Norcg, Nordscg, Laytime,
					Condpgo, Tasadmra, Usrmod, Usrcrea, Fchcrea, Fchmod,
					EstadoId, ProvId, Fchord, Rspnsble,Ritmod)
select h_o.Numorden OrdenId, h_o.NumContrato CtrtoId, h_o.NumLote LoteId, ri.OrigenId OrigenId,
h_o.[Toneladas metricas] Tnladas, h_o.Tolerancia Tlrancia, h_o.[Periodo Embarque] Peremb,
h_l.Incoterm Incoterm, h_l.RitmoE Ritmo, h_l.Moneda Moneda,
h_o.Refuturo Refftro, h_o.[Base Base] Base, h_o.[Base Futuro] Mesfutu, h_o.PrecioN Prcionto,
h_o.Observaciones Obsrv,
NULL Laycan, NULL Ptocarga, NULL Ptodscg, NULL Norcg, NULL Nordscg, NULL Laytime,
NULL Condpgo, NULL Tasadmra, 0 Usrmod, 0 Usrcrea, getdate () Fchcrea, getdate() Fchmod, 'A' EstadoId,
NULL ProvId, getdate () Fchord, h_o.Responsable Rspnsble, NULL Ritmod
from h_Ordenes h_o inner join h_lotes h_l
	on h_o.NumLote = h_l.NumLotes
inner join sOrigen ri
	on h_l.Origen = ri.Orgnidan


select *
from sOrigen


