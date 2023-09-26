Imports Genericas
Imports ObjEntidades

Public Class frmHistorial
    Private msg As Mensaje
    Private tipoDoc As SysEnums.TiposDocumentos
    Private sDocNum As String

    Private cliente As ClienteSql
    Private Cnfg As Configuracion
    Private Usua As Usuario

    Private genW As GenericasWin
    Private InfDoc As InformacionDocumento

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property PermiteMoverRegistros() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarDocumentos() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarEstado() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteImprimir() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteBuscarHistorial() As Boolean
        Get
            Return False
        End Get
    End Property

#Region "Métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pGenW As GenericasWin, _
                   ByVal pConfiguracion As Configuracion, ByVal pUsuario As Usuario, _
                   ByVal pHist As DataTable, _
                   ByVal ptipoDoc As SysEnums.TiposDocumentos, ByVal pDocNum As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        msg = New Mensaje
        tipoDoc = ptipoDoc
        sDocNum = pDocNum

        genW = pGenW
        cliente = pCliente
        Cnfg = pConfiguracion
        Usua = pUsuario

        InfDoc = New InformacionDocumento(tipoDoc, cliente.ParametrosConexion.BaseDeDatos, "", pDocNum, "", "")

        cargarHistorial(pHist)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub cargarHistorial(ByVal pHist As DataTable)
        Dim itmCounter As Integer = 0

        Try
            grdHistorial.DataSource = Nothing
            grdHistorial.Rows.Clear()
            grdHistorial.Columns.Clear()

            grdHistorial.Font = New Font(grdHistorial.Font.FontFamily.Name, 7, FontStyle.Regular)
            grdHistorial.DataSource = New DataView(pHist)
            grdHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grdHistorial.AllowUserToDeleteRows = False
            grdHistorial.AllowUserToOrderColumns = True
            grdHistorial.AllowUserToAddRows = False
            grdHistorial.AllowUserToResizeColumns = True
            grdHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grdHistorial.EditMode = DataGridViewEditMode.EditProgrammatically

            For itmCounter = 6 To grdHistorial.ColumnCount - 1
                grdHistorial.Columns(itmCounter).Visible = False
            Next

            Dim eventarg As DataGridViewCellEventArgs = New DataGridViewCellEventArgs(0, 0)

            grdHistorial_CellClick(New Object, eventarg)
        Catch ex As Exception
            msg.setError("No fue posible cargar el historial del documento " + sDocNum + ": " + ex.Message)
        End Try

        genW.publicar(InfDoc, msg, True)
    End Sub

    Private Function detalleModificaciones(ByVal pNoRenglon As Integer) As DataTable
        Dim resultados As DataTable = Nothing
        Dim itmCounter As Integer = 0

        Dim cadCambios As String = ""

        Try
            resultados = estructuraModif(grdHistorial.Rows(pNoRenglon).Cells(0).Value, grdHistorial.RowCount)



            For itmCounter = 6 To grdHistorial.Columns.Count - 1
                cadCambios = buscarCambios(pNoRenglon, itmCounter)
                If Not cadCambios.Trim.Length.Equals(0) Then
                    resultados.Rows.Add(cadCambios.Split("|"))
                End If
            Next

            If resultados.Rows.Count = 0 Then
                msg.setInfo("No hay detalle de modificaciones para mostrar en esta instancia.")
                genW.publicar(InfDoc, msg)
            End If

            grdDetalleCambios.DataSource = Nothing
            grdDetalleCambios.Rows.Clear()
            grdDetalleCambios.Columns.Clear()

            grdDetalleCambios.Font = New Font(grdDetalleCambios.Font.FontFamily.Name, 7, FontStyle.Regular)
            grdDetalleCambios.DataSource = New DataView(resultados)
            grdDetalleCambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grdDetalleCambios.AllowUserToDeleteRows = False
            grdDetalleCambios.AllowUserToOrderColumns = False
            grdDetalleCambios.AllowUserToAddRows = False
            grdDetalleCambios.AllowUserToResizeColumns = True
            grdDetalleCambios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grdDetalleCambios.EditMode = DataGridViewEditMode.EditProgrammatically
        Catch ex As Exception
            msg.setError("No fue posible mostrar el detalle de cambios: " + ex.Message)
        End Try

finalize:
        genW.publicar(InfDoc, msg, True)
        Return resultados
    End Function

    Private Function estructuraModif(ByVal pNoInstancia As Integer, ByVal pCantInst As Integer) As DataTable
        Dim estruc As DataTable = Nothing
        Dim titulo1 As String = ""
        Dim titulo2 As String = ""

        If pNoInstancia = pCantInst - 1 Then
            titulo1 = "Instancia Actual"
            titulo2 = "No aplica."
        Else
            titulo1 = "Instancia " + pNoInstancia.ToString
            titulo2 = "Instancia " + (pNoInstancia + 1).ToString
        End If


        estruc = New DataTable
        estruc.Columns.Add(New DataColumn("Campo", GetType(String)))
        estruc.Columns.Add(New DataColumn(titulo1, GetType(String)))
        estruc.Columns.Add(New DataColumn(titulo2, GetType(String)))

        Return estruc
    End Function

    Private Function buscarCambios(ByVal pNoRenglon As Integer, ByVal pColumna As Integer) As String
        If pNoRenglon.Equals(grdHistorial.RowCount - 1) Or pNoRenglon < 0 Then
            Return ""
        End If

        If Not grdHistorial.Rows(pNoRenglon).Cells(pColumna).Value.Equals(grdHistorial.Rows(pNoRenglon + 1).Cells(pColumna).Value) Then
            Return grdHistorial.Columns(pColumna).Name + "|" + grdHistorial.Rows(pNoRenglon).Cells(pColumna).Value.ToString + "|" + _
                grdHistorial.Rows(pNoRenglon + 1).Cells(pColumna).Value.ToString
        Else
            Return ""
        End If
    End Function

    Private Sub cargarLote(ByVal pNoRenglon As Integer)
        Dim Lote As Lote = Nothing

        Try
            Lote = TryCast(objDocumento(pNoRenglon), Lote)

            Dim frmLote As frmLote = New frmLote(cliente, genW, SysEnums.Modos.mHistorial, Cnfg, Usua, _
                                                 sDocNum, Lote)
            frmLote.MdiParent = Me.MdiParent
            frmLote.Show()
        Catch ex As Exception
            msg.setError("No fue posible cargar el lote: " + ex.Message)
        End Try

    End Sub

    Private Sub cargarOrden(ByVal pNoRenglon As Integer)
        Dim Orden As Orden = Nothing

        Try
            Orden = TryCast(objDocumento(pNoRenglon), Orden)

            Dim frmOrden As frmOrden = New frmOrden(cliente, genW, SysEnums.Modos.mHistorial, Cnfg, Usua, _
                                                    sDocNum, Orden)
            frmOrden.MdiParent = Me.MdiParent
            frmOrden.Show()
        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden: " + ex.Message)
        End Try

    End Sub

    Private Sub cargarEmbarque(ByVal pNoRenglon As Integer)
        Dim Embarque As Embarque = Nothing

        Try
            Embarque = TryCast(objDocumento(pNoRenglon), Embarque)

            Dim frmEmbarque As frmEmbarque = New frmEmbarque(cliente, genW, SysEnums.Modos.mHistorial, Cnfg, Usua, _
                                                             sDocNum, Embarque)
            frmEmbarque.MdiParent = Me.MdiParent
            frmEmbarque.Show()
        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden: " + ex.Message)
        End Try

    End Sub

    Private Sub cargarAjuste(ByVal pNoRenglon As Integer)
        Dim Ajuste As Ajuste = Nothing

        Try
            Ajuste = TryCast(objDocumento(pNoRenglon), Ajuste)

            Dim frmAjuste As frmAjuste = New frmAjuste(cliente, genW, SysEnums.Modos.mHistorial, Cnfg, Usua, _
                                                       sDocNum, Ajuste)
            frmAjuste.MdiParent = Me.MdiParent
            frmAjuste.Show()
        Catch ex As Exception
            msg.setError("No fue posible cargar el Ajuste: " + ex.Message)
        End Try

    End Sub

    Private Sub cargarVenta(ByVal pNoRenglon As Integer)
        Dim Venta As Venta = Nothing

        Try
            Venta = TryCast(objDocumento(pNoRenglon), Venta)

            Dim frmVenta As frmVenta = New frmVenta(cliente, genW, SysEnums.Modos.mHistorial, Cnfg, Usua, _
                                                    sDocNum, Venta)
            frmVenta.MdiParent = Me.MdiParent
            frmVenta.Show()
        Catch ex As Exception
            msg.setError("No fue posible cargar la Venta: " + ex.Message)
        End Try

    End Sub

    Private Function objDocumento(ByVal pNoRenglon As Integer) As Object
        Dim obj As Object = Nothing
        Dim gen3E As Genericas3E = Nothing
        Dim resultados As DataTable = Nothing

        Try
            gen3E = New Genericas3E
            resultados = TryCast(grdHistorial.DataSource, DataView).Table

            Select Case tipoDoc
                Case SysEnums.TiposDocumentos.dLote
                    obj = New Lote(cliente, gen3E.valorCampo(resultados, pNoRenglon, "LoteId"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "ProvId"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Proveedor"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "TrigoId"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Trigo"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Proteina"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Grado"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Humedad"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Pesohtl"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Impureza"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Dockage"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Vomitoxn"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Ergot"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Fllngnum"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Obsrv"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Fecha Creación"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Creó"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Modificó"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "EstadoId"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Fchlote"), _
                                   gen3E.valorCampo(resultados, pNoRenglon, "Otros"))
                    sDocNum = gen3E.valorCampo(resultados, pNoRenglon, "LoteId") + " - Instancia " + gen3E.valorCampo(resultados, pNoRenglon, "Instancia")
                Case SysEnums.TiposDocumentos.dOrden
                    obj = New Orden(cliente, gen3E.valorCampo(resultados, 0, "OrdenId"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "CtrtoId"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "LoteId"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "OrigenId"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Nmborigen"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Tnladas"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Tlrancia"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Peremb"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Incoterm"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Ritmo"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Moneda"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Refftro"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Base"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Mesfutu"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Prcionto"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Obsrv"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Laycan"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Ptocarga"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Ptodscg"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Norcg"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Nordscg"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Laytime"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Condpgo"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Tasadmra"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Modificó"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Creó"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Fecha Creación"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "EstadoId"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "ProvId"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Nmbprvfl"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Fchord"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Rspnsble"),
                                    gen3E.valorCampo(resultados, pNoRenglon, "Ritmod"))


                    sDocNum = gen3E.valorCampo(resultados, pNoRenglon, "OrdenId") + " - Instancia " + gen3E.valorCampo(resultados, pNoRenglon, "Instancia")
                Case SysEnums.TiposDocumentos.dEmbarque
                    obj = New Embarque(cliente, gen3E.valorCampo(resultados, 0, "EmbId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "OrdenId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Reftrans"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "DstinoId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Dstino"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Provflet"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Provfletn"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Pesoemb"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Fchemb"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Noselloe"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Fchrec"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Pesore"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Dif"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "OprdorId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Silo"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Sellorec"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Factfl"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Obgen"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Creó"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Modificó"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Fecha Creación"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "EstadoId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "MonedaId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Tarifa"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "LoteId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "TrigoId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Trigo"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "ProvTrigoId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "ProvTrigo"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "OrigenId"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Origen"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "Oprdor"),
                                      gen3E.valorCampo(resultados, pNoRenglon, "TipoEmb"))

                    obj.InspeccionTrigo.alimentar(Boolean.Parse(gen3E.valorCampo(resultados, pNoRenglon, "Condlimp", "false")), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Olor"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Color"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Danado"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Plagas"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Otros"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "EmbId"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Modificó"), _
                                                                gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"))
                    'bCondlimp = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Condlimp", "false"))
                    'sOlor = gen3E.valorCampo(resultados, 0, "Olor")
                    'sColor = gen3E.valorCampo(resultados, 0, "Color")
                    'sDanado = gen3E.valorCampo(resultados, 0, "Danado")
                    'sPlagas = gen3E.valorCampo(resultados, 0, "Plagas")
                    'sOtros = gen3E.valorCampo(resultados, 0, "Otros")
                    'sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
                    ''sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
                    'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")


                    obj.InspeccionTransporte.alimentar(Boolean.Parse(gen3E.valorCampo(resultados, pNoRenglon, "Condtra", "false")), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Libreba"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Libregr"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Otros"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Sellosc"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Servtra"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "EmbId"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Modificó"), _
                                                       gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"))

                    'bCondtra = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Condtra", "false"))
                    'sLibreba = gen3E.valorCampo(resultados, 0, "Libreba")
                    'sLibregr = gen3E.valorCampo(resultados, 0, "Libregr")
                    'sOtros = gen3E.valorCampo(resultados, 0, "Otros")
                    'sSellosc = gen3E.valorCampo(resultados, 0, "Sellosc")
                    'sServtra = gen3E.valorCampo(resultados, 0, "Servtra")
                    'sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
                    ''sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
                    'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
                    obj.Laboratorio.alimentar(gen3E.valorCampo(resultados, pNoRenglon, "Eprot"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Ehum"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Ephl"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Eimp"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Rprot"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Rhum"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Rphl"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Rimp"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Oblab"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "EmbId"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Modificó"), _
                                              gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"), _
                                              Boolean.Parse(gen3E.valorCampo(resultados, pNoRenglon, "Lab", "false")))


                    'sEprot = gen3E.valorCampo(resultados, 0, "Eprot")
                    'sEhum = gen3E.valorCampo(resultados, 0, "Ehum")
                    'sEphl = gen3E.valorCampo(resultados, 0, "Ephl")
                    'sEimp = gen3E.valorCampo(resultados, 0, "Eimp")
                    'sRprot = gen3E.valorCampo(resultados, 0, "Rprot")
                    'sRhum = gen3E.valorCampo(resultados, 0, "Rhum")
                    'sRphl = gen3E.valorCampo(resultados, 0, "Rphl")
                    'sRimp = gen3E.valorCampo(resultados, 0, "Rimp")
                    'sOblab = gen3E.valorCampo(resultados, 0, "Oblab")
                    'sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
                    ''sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
                    'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
                    'bLab = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Lab", "false"))

                    sDocNum = gen3E.valorCampo(resultados, pNoRenglon, "EmbId") + " - Instancia " + gen3E.valorCampo(resultados, pNoRenglon, "Instancia")
                Case SysEnums.TiposDocumentos.dAjuste
                    obj = New Ajuste(cliente, gen3E.valorCampo(resultados, 0, "AjustId"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "OrdenId"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Fchajus"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Compensa"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Merma1"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Merma2"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Merma3"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Obsrv"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Fecha Creación"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Creó"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "Modificó"), _
                                     gen3E.valorCampo(resultados, pNoRenglon, "EstadoId"))

                    sDocNum = gen3E.valorCampo(resultados, pNoRenglon, "AjustId") + " - Instancia " + gen3E.valorCampo(resultados, pNoRenglon, "Instancia")
                Case SysEnums.TiposDocumentos.dVenta
                    obj = New Venta(cliente, gen3E.valorCampo(resultados, pNoRenglon, "VentaId"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Tonventa"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "OrdenId"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Fchventa"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "EstadoId"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Obsrv"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Fecha Creación"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Fecha Modificación"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Creó"), _
                                    gen3E.valorCampo(resultados, pNoRenglon, "Modificó"))

                    sDocNum = gen3E.valorCampo(resultados, pNoRenglon, "VentaId") + " - Instancia " + gen3E.valorCampo(resultados, pNoRenglon, "Instancia")
            End Select

        Catch ex As Exception
            msg.setError("No fue posible general el origen para la carga del historial: " + ex.Message)
        End Try


        Return obj
    End Function
#End Region


    Private Sub frmHistorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = sDocNum + " - Historial de cambios"
    End Sub

    Private Sub grdHistorial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdHistorial.CellClick
        detalleModificaciones(e.RowIndex)
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Me.Close()
    End Sub

    Private Sub grdHistorial_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdHistorial.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Select Case tipoDoc
            Case SysEnums.TiposDocumentos.dLote
                cargarLote(e.RowIndex)
            Case SysEnums.TiposDocumentos.dOrden
                cargarOrden(e.RowIndex)
            Case SysEnums.TiposDocumentos.dEmbarque
                cargarEmbarque(e.RowIndex)
            Case SysEnums.TiposDocumentos.dAjuste
                cargarAjuste(e.RowIndex)
            Case SysEnums.TiposDocumentos.dVenta
                cargarVenta(e.RowIndex)
        End Select

        genW.publicar(InfDoc, msg, True)
    End Sub
End Class