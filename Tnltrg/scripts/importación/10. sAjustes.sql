select *
from h_Ajustes


insert into sAjustes (AjustId, OrdenId, Fchajus, Compensa, Merma1, Merma2, Merma3,
					Obsrv, Fchcrea, Usrcrea, Fchmod, Usrmod, EstadoId)
select h_a.NoAjuste AjustId, h_a.Numorde OrdenId, h_a.Fecha Fchajus,
h_a.[Toneladas Ajuste] Compensa, h_a.[Toneladas Ajuste1] Merma1,
h_a.[Toneladas Ajuste2] Merma2, h_a.[Toneladas Ajuste3] Merma3,
h_a.Descripcion Obsrv, getdate() Fchcrea, 0 Usrcrea, getdate() Fchmod, 0 Usrmod,
'A' EstadoId
from h_Ajustes h_a


select *
from sAjustes
