delete from sVentash
delete from sVentas

delete from sAjustesh
delete from sAjustes

delete from sEmb4h
delete from sEmb3h
delete from sEmb2h
delete from sEmb1h

delete from sEmb4
delete from sEmb3
delete from sEmb2
delete from sEmb1

delete from sDestino

delete from sOrdenesh
delete from sOrdenes

delete from sLotesh
delete from sLotes

delete from sOrigen
delete from sTrigos
delete from sProveed

delete from sPrfls2
where PerfilId not in ('0', '1')

delete from sPrfls1
where PerfilId not in ('0', '1')

delete from sUsuarios
where UsrId not in ('0')

delete from sOprador