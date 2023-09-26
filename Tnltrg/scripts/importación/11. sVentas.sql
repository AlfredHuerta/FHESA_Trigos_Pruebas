select *
from h_Ventas



insert into sVentas(VentaId, Tonventa, OrdenId, Fchventa, EstadoId, Obsrv,
Fchcrea, Fchmod, Usrcrea, Usrmod)
select NoVenta VentaId, [Toneladas Ajuste] Tonventa, Numord OrdenId,
Fecha Fchventa, 'A' EstadoId, Descripcion Obsrv, getdate() Fchcrea, getdate() Fchmod,
0 Usrcrea, 0 Usrmod
from h_Ventas

select *
from sVentas
