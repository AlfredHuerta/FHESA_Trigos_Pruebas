USE [TNLTRG]
GO
/****** Object:  UserDefinedFunction [dbo].[FE_Valordefp]    Script Date: 05/10/2017 12:26:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[FE_Valordefp](
	@TpodatId smallint,
	@TpodocId smallint,
	@Entrada varchar (50)
	)
	
	
	returns varchar (50)
	
begin
	declare @Valor varchar (50)
	
	if @Entrada in ('<PRIMERO>', '<ULTIMO>')
	begin
		if @TpodocId = 2
			select @Valor = case @TpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(lo.LoteId)
									else
										max(lo.LoteId)
									end
								when 2 then
									convert (varchar (10), (case when @Entrada = '<PRIMERO>' then
																min(lo.Fchlote)
															else
																max(lo.Fchlote)
															end), 120)
								else
									''
								end
			from sLotes lo
			where lo.EstadoId <> 'L'
		else if @tpodocId = 3
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(od.OrdenId)
									else
										max(od.OrdenId)
									end
								when 2 then
									convert (varchar (10), (case when @Entrada = '<PRIMERO>' then
																min(od.Fchord)
															else
																max(od.Fchord)
															end), 120)
								else
									''
								end
			from sOrdenes od
			where od.EstadoId <> 'L'
		else if @tpodocId = 4
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(e1.EmbId)
									else
										max(e1.EmbId)
									end
								when 2 then
									convert (varchar (10), (case when @Entrada = '<PRIMERO>' then
																min(e1.Fchemb)
															else
																max(e1.Fchemb)
															end), 120)
								else
									''
								end
			from sEmb1 e1
			where e1.EstadoId <> 'L'	
		else if @tpodocId = 5
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(aj.AjustId)
									else
										max(aj.AjustId)
									end
								when 2 then
									convert (varchar (10), (case when @Entrada = '<PRIMERO>' then
																min(aj.Fchajus)
															else
																max(aj.Fchajus)
															end), 120)
								else
									''
								end
								
			from sAjustes aj
			where aj.EstadoId <> 'L'
		else if @tpodocId = 6
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(ve.VentaId)
									else
										max(ve.VentaId)
									end
								when 2 then
									convert (varchar (10), (case when @Entrada = '<PRIMERO>' then
																min(ve.Fchventa)
															else
																max(ve.Fchventa)
															end), 120)
								else
									''
								end
			from sVentas ve
			where ve.EstadoId <> 'L'
		else if @tpodocId in (7, 12, 13, 14, 15)
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(pr.ProvId)
									else
										max(pr.ProvId)
									end
								else
									''
								end
			from sProveed pr
			where pr.Activo = 1
			and TpoprvId like '%' + case @tpodocId
										when 7 then
											''
										when 12 then
											'T001'
										when 13 then
											'T002'
										when 14 then
											'T003'
										when 15 then
											'T004'
									end
		else if @tpodocId = 8
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(tr.TrigoId)
									else
										max(tr.TrigoId)
									end
								else
									''
								end
			from sTrigos tr
			where tr.Activo = 1
		else if @tpodocId = 9
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(og.OrigenId)
									else
										max(og.OrigenId)
									end
								else
									''
								end
			from sOrigenes og
			where og.Activo = 1
		else if @tpodocId = 10
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(de.DstinoId)
									else
										max(de.DstinoId)
									end
								else
									''
								end
			from sDestino de
			where de.Activo = 1
		else if @tpodocId = 11
			select @Valor = case @tpodatId
								when 1 then
									case when @Entrada = '<PRIMERO>' then
										min(op.OprdorId)
									else
										max(op.OprdorId)
									end
								else
									''
								end
			from sOprador op
			where op.Activo = 1
	end
	else if @Entrada = '<FECHA_ACTUAL>'
		select @Valor = case @tpodatId
							when 2 then
								convert (varchar (10), getdate(), 120)
							when 4 then
								convert (varchar (30), getdate(), 126)
							else
								convert (varchar (30), getdate())
							end
	else if @Entrada in ('<FALSO>', '<VERDADERO>')
		select @Valor = case when @tpodatId in (3, 5) then
							case when @Entrada = '<FALSO>' then
								'False'
							else
								'True'
							end
						else
							@Entrada
						end
	else
		select @Valor = @Entrada
	
	
	return @Valor
END

GO
