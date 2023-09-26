use tnltrg_ds
select * from sOrdenes


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PA_Rembins](
    @DstinoId varchar(30),
	@OrdenId1 varchar (30),
	@OrdenId2 varchar (30),
	@ProvId varchar (30),
	@TrigoId varchar (30),
	@Sininspeccion bit,
	@Conforme bit,
	@Noconforme bit
)
AS
BEGIN
    SELECT de.Nombre AS 'Destino', e1.EmbId AS 'No. Embarque', e1.Reftrans AS 'Ref. Transporte',
        e1.Fchrec AS 'Fecha Recepcion', e1.Pesoemb AS 'Peso Embarcado',e1.Pesore AS 'Peso Recibido'
    FROM sLotes lo
    INNER JOIN sOrdenes od ON lo.LoteId = od.LoteId
    INNER JOIN sEmb1 e1 ON od.OrdenId = e1.OrdenId
    INNER JOIN sDestino de ON e1.DstinoId = de.DstinoId
    INNER JOIN sProveed pr ON lo.ProvId = pr.ProvId
    INNER JOIN sOrigen og ON od.OrigenId = og.OrigenId
    INNER JOIN sTrigos tr ON lo.TrigoId = tr.TrigoId
	INNER JOIN sEmb2 e2 ON e1.EmbId = e2.EmbId
    where od.OrdenId between @OrdenId1 and @OrdenId2 
	AND e1.DstinoId like '%'+@DstinoId+'%' 
	AND lo.ProvId like '%'+@ProvId+'%' 
	AND lo.TrigoId like '%'+@TrigoId+'%'
    AND lo.EstadoId <> 'L'
    AND od.EstadoId <> 'L'
    AND e1.EstadoId <> 'L'
    AND e1.Silo IS NULL
	AND
	(
		(@Sininspeccion = 0 AND(e2.Condlimp = 0 OR e2.Condlimp = 1))
		OR
		(@Conforme = 1 AND(e2.Conforme = 0 Or e2.Conforme = 1))
		Or
		(@Noconforme = 0 AND(e2.Conforme = 0 Or e2.Conforme = 1))
	)
END

EXEC [dbo].[PA_Rembins]
    '',
    'O0001000',
    'O0001022',
    '',
    '',
	'',
	'',
	'';


	