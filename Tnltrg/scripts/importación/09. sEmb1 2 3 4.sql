select  count (*)
from h_Embarques


insert into sEmb1 (EmbId, OrdenId, Reftrans, DstinoId, Provflet, Pesoemb, Fchemb,
					Noselloe, Fchrec, Pesore, Dif, OprdorId, Silo, Sellorec,
					Factfl, Obgen, Usrcrea, Usrmod, Fchcrea, Fchmod, EstadoId, MonedaId, Tarifa, Refcrgmas)
select Numembarque EmbId, Numorden OrdenId, [Referencia Transporte] Reftrans,
isnull (de.DstinoId, 'DE0000') DstinoId, pr.ProvId Provflet, [Peso Embarcado] Pesoemb, [Fecha Embarque] Fchemb,
SEmb Noselloe, [Fecha Recepcion] Fchrec, [Peso Recibido] Pesore,
convert (decimal (19, 3), ltrim (str([Peso Embarcado] - [Peso Recibido], 19, 13))) Dif,
isnull (op.OprdorId, 'R000') OprdorId,
case when ltrim(rtrim (Silo)) = '' then
	NULL
else
	Silo
end Silo, Srec Sellorec,
case when ltrim(rtrim (Numfacturaflete)) = '' then
	NULL
else
	Numfacturaflete
end Factfl, Observaciones Obgen, 0 Usrcrea, 0 Usrmod,
getdate() Fchcrea, getdate() Fchmod, 'A' EstadoId, NULL MonedaId, 0 Tarifa, NULL Refcrgmas
from h_embarques h_e left outer join sDestino de
	on h_e.Destino = de.Dstnidan
inner join sProveed pr
	on h_e.Flete = pr.Providan
left outer join sOprador op
	on h_e.Operador = op.Usridan
where pr.Activo = 1
and pr.TpoPrvId = 'T002'

select *
from sEmb1


insert into sEmb2 (Condlimp, Olor, Color, Danado, Plagas, Otros, EmbId, Usrmod, Fchmod)
select  IPT Condlimp, POlor Olor, PColor Color, Pdado Danado, Pplagas Plagas,
POtros Otros, Numembarque EmbId, 0 Usrmod, getdate () Fchmod
from h_Embarques



insert into sEmb3 (Condtra, Libreba, Libregr, Otros, Sellosc, Servtra, EmbId, Usrmod, Fchmod)
select ITR Condtra, TLBasura Libreba, TLGranos Libregr, TOtros Otros, TSCompletos Sellosc,
TSTrans Servtra, Numembarque EmbId, 0 Usrmod, getdate() Fchmod
from h_Embarques



insert into sEmb4(Eprot, Ehum, Ephl, Eimp, Rprot, Rhum, Rphl, Rimp, Oblab,
EmbId, Usrmod, Fchmod, Lab)
select lo.Proteina Eprot, lo.Humedad Ehum, lo.pesohtl Ephl, lo.Impureza Eimp,
h_e.Proteina Rprot, h_e.Humedad Rhum, h_e.Pesohectolitro Rphl, h_e.Impureza Rimp, 
h_e.Observaciones Oblab, Numembarque EmbId, 0 Usrmod, getdate() Fchmod,
case when h_e.Proteina > 0 or h_e.Humedad > 0 or h_e.Pesohectolitro > 0 or h_e.Impureza > 0 then
	1
else
	0
end
from h_Embarques h_e inner join sOrdenes rd
	on h_e.Numorden = rd.OrdenId
inner join sLotes lo
	on rd.LoteId = lo.LoteId


