Imports Genericas
Imports ObjEntidades

Public Class frmEmbarque
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Cnfg As Configuracion
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean = False
    Private forzarBusqueda As Boolean = False

    Private Embarque As Embarque
    Private ipt As InspeccionTrigo
    Private sEmbInst As String

    Private WithEvents mnuCopiarTexto As ToolStripMenuItem

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property Modo() As SysEnums.Modos
        Get
            Return Modop
        End Get
    End Property

    Public ReadOnly Property PermiteMoverRegistros() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarDocumentos() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarEstado() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property PermiteImprimir() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteBuscarHistorial() As Boolean
        Get
            Return True
        End Get
    End Property

#Region "Métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pgenW As GenericasWin, _
           ByVal pModo As SysEnums.Modos, ByVal pConfiguracion As Configuracion, _
           ByVal pUsuario As Usuario, Optional ByVal pEmbId As String = "", _
           Optional ByVal pEmbarque As Embarque = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sEmb1", "", "", "")

            If inicializarControles().EsError Then GoTo finalize
            If pEmbId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            Cnfg = pConfiguracion
            Usua = pUsuario

            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(26)


            If pModo = SysEnums.Modos.mCrear And Not atmPerf.Creacion And atmPerf.Consulta Then
                pModo = SysEnums.Modos.mConsultar

                moverRegistro("4")

                GoTo finalize
            ElseIf pModo = SysEnums.Modos.mConsultar And Not atmPerf.Consulta Then
                Throw New Exception("No tiene los privilegios suficientes para realizar esta acción.")
            End If

            Select Case pModo
                Case SysEnums.Modos.mCrear
                    setCrear()
                Case SysEnums.Modos.mConsultar

                    Embarque = New Embarque(cliente, pEmbId)
                    msg = Embarque.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarEmbarque().EsError Then GoTo finalize

                    setConsultar()
                Case SysEnums.Modos.mHistorial

                    Embarque = pEmbarque

                    If cargarEmbarque().EsError Then GoTo finalize

                    sEmbInst = pEmbId
                    setHistorial(pEmbId)
            End Select
        Catch ex As Exception
            msg.setError("No fue posible inicializar la ventana: " + ex.Message)
        End Try
finalize:
        genW.publicar(infDoc, msg, True)
    End Sub



    Private Function inicializarControles() As Mensaje
        Dim Cats As Catalogos = Nothing

        Try
            msg = genW.initControles(Me).clonar()
            If msg.EsError Then GoTo finalize


            Cats = New Catalogos(cliente)
            genW.llenarListadoDesdeTabla(Cats.cargarEstadosDoc(), "Nombre", "EstadoId", cmbEstado)
            genW.llenarListadoDesdeTabla(Cats.cargarMonedas(), "Descripcion", "MonedaId", cmbMonedaId)

            agregarContextuales()
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtEmbId.ContextMenuStrip = strip
        txtEmbId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, _
                                  cliente.ParametrosConexion.BaseDeDatos, "sEmb1", _
                                  "", "", "")

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            forzarBusqueda = False
            txtEmbId.Enabled = False
            cmbEstado.Enabled = False
            txtDiferencia.Enabled = False

            tbpRecepcion.Enabled = True
            tbpInspeccionTransporte.Enabled = True
            tbpInspeccionTrigo.Enabled = True
            tbpLaboratorio.Enabled = True


            cmbMonedaId.SelectedIndex = -1

            setObjetosVis()

            chkCondLimpieza.Checked = False
            activarInspeccionTrigo(chkCondLimpieza.Checked)
            activarInspeccionTransporte(chkCondTransporte.Checked)
            activarLaboratorio(chkLaboratorio.Checked)


            Embarque = New Embarque(cliente)

            txtEmbId.Text = Embarque.EmbId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, _
                      cliente.ParametrosConexion.BaseDeDatos, "sEmb1", _
                      Embarque.EmbId, "", "")

            genW.seleccionarItem(cmbEstado, "A")

            Try
                dtpFechaEmbarque.Focus()
                dtpFechaEmbarque.Value = Now.Date
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Embarque " + Embarque.EmbId + " (Nuevo Embarque)"
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Crear: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        forzarBusqueda = True
        Return msg
    End Function


    Public Function setConsultar() As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesConsultar(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtEmbId.Enabled = False
            cmbEstado.Enabled = False
            txtDiferencia.Enabled = False

            txtPesoembc.Enabled = False

            setObjetosVis()
            activarInspeccionTrigo(chkCondLimpieza.Checked)
            activarInspeccionTransporte(chkCondTransporte.Checked)
            activarLaboratorio(chkLaboratorio.Checked)

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sEmb1", _
                                              Embarque.EmbId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            If Decimal.Parse(txtDiferencia.Text) <= Decimal.Parse(Cnfg.Difmin) Then
                lblAlertaDif.Text = "El rango de diferencia se encuentra dentro de lo normal."
                lblAlertaDif.ForeColor = Color.Black
            ElseIf Decimal.Parse(txtDiferencia.Text) <= Decimal.Parse(Cnfg.Difmax) Then
                lblAlertaDif.Text = "El rango de diferencia se encuentra elevado sin alcanzar niveles críticos."
                lblAlertaDif.ForeColor = Color.DarkOrange
            Else
                lblAlertaDif.Text = "El rango de diferencia es demasiado elevado. Se sugiere buscar una solución a este conflicto."
                lblAlertaDif.ForeColor = Color.DarkRed
            End If


            Me.Text = "Embarque " + Embarque.EmbId + " (Consulta)"
            dtpFechaEmbarque.Focus()
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Consultar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Public Function setModificar() As Mensaje
        Try
            forzarBusqueda = False

            If Modop <> SysEnums.Modos.mBuscar Then modificado = True

            lblInformacionEmbarque.Text = "Información de embarque." + vbCrLf + _
                vbCrLf + _
                "Fecha de Embarque: " + dtpFechaEmbarque.Value.ToLongDateString + vbCrLf + _
                "Orden: " + txtOrdenId.Text + vbCrLf + _
                "Lote: " + txtLoteId.Text + vbCrLf + _
                "Trigo: " + txtTrigo.Text + vbCrLf + _
                "Prov. Trigo: " + txtProvTrigo.Text + vbCrLf + _
                "Origen: " + txtOrigen.Text + vbCrLf + _
                "Referencia de Transporte: " + txtReftrans.Text + vbCrLf + _
                "Destino: " + txtDestino.Text + vbCrLf + _
                "Proveedor de Flete: " + txtProvFlete.Text + vbCrLf + _
                "Peso Embarcado (Tn.): " + txtPesoEmb.Text + vbCrLf + _
                "Factura Flete: " + txtFactfl.Text + vbCrLf + _
                "Moneda: " + cmbMonedaId.Text + vbCrLf + _
                "Tarifa: " + txtTarifa.Text + vbCrLf + _
                "Sello Embarque: " + txtSelloe.Text + vbCrLf + _
                "Cadena de Silos: " + Embarque.Silo



            txtPesoembc.Enabled = False
            txtPesoembc.Text = txtPesoEmb.Text

            If Modop <> SysEnums.Modos.mConsultar Then GoTo finalize

            msg.reset()

            cmdAceptar.Text = "Actualizar"
            Modop = SysEnums.Modos.mModificar
            txtDiferencia.Enabled = False

            Me.Text = "Embarque " + Embarque.EmbId + " (Modificar)"
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Modificar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        If Not Modop = SysEnums.Modos.mBuscar Then forzarBusqueda = True

        Return msg
    End Function

    Public Function setBuscar() As Mensaje
        Dim modoant As SysEnums.Modos = Modop

        Try

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            forzarBusqueda = False
            Modop = SysEnums.Modos.mBuscar

            msg = genW.initControlesBuscar(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtEmbId.Enabled = True
            cmbEstado.Enabled = True
            dtpFechaEmbarque.Enabled = True
            txtOrdenId.Enabled = True
            txtLoteId.Enabled = True
            txtReftrans.Enabled = True


            cmbEstado.SelectedIndex = -1
            dtpFechaEmbarque.Value = New Date(1899, 1, 1)
            cmbMonedaId.SelectedIndex = -1

            'txtOrdenId.Text = ""
            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Embarque (Buscar)"
            txtEmbId.Focus()

            modificado = False
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Búsqueda: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        forzarBusqueda = True
        If msg.EsError Then Modop = modoant
        Return msg
    End Function

    Public Function setHistorial(ByVal pEmbId As String) As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesHistorial(Me).clonar()
            If msg.EsError Then GoTo finalize

            cmdAceptar.Enabled = True
            cmdCancelar.Enabled = True

            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mHistorial
            modificado = False

            Me.Text = "Embarque " + pEmbId + " (Historial)"
            cmdAceptar.Focus()
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo Historial: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function generarOrigenDatos() As Mensaje
        Dim monedaId As String = ""
        Dim silos As String = ""
        Dim silosAnt As String = ""
        Try
            msg.reset()

            silosAnt = Embarque.Silo
            silos = silosSeleccionados()

            'If Not chkEmbTr.Checked Then
            If Not silosAnt.Length.Equals(0) And silos.Equals("-") Then
                msg.setPregunta("No se han restablecido los silos. Si continúa los silos establecidos previamente se perderán. ¿Desea continuar?")
                If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    msg.setError("Operación cancelada por el usuario.")
                    GoTo finalize
                End If
            End If

            'End If

            Embarque.liberarObjetos()

            If cmbMonedaId.SelectedItem Is Nothing Then
                monedaId = ""
            Else
                monedaId = cmbMonedaId.SelectedItem.ItemData.ToString
            End If



            Embarque = New Embarque(cliente, txtEmbId.Text, txtOrdenId.Text, txtReftrans.Text, txtDstinoId.Text, "", txtProvFleteId.Text, "",
                                    txtPesoEmb.Text, Format(dtpFechaEmbarque.Value, "yyyy-MM-ddTHH:mm:dd"), txtSelloe.Text,
                                    Format(dtpFchrec.Value, "yyyy-MM-ddTHH:mm:dd"), txtPesoRecibido.Text, txtDiferencia.Text, txtOperadorId.Text,
                                    silos, txtSelloRecep.Text, txtFactfl.Text, txtObgen.Text, Usua.UsrId, Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"),
                                    Format(Now, "yyyy-MM-ddTHH:mm:dd"), cmbEstado.SelectedItem.ItemData.ToString, monedaId,
                                    txtTarifa.Text, "", "", "", "", "", "", "", "", "")

            msg = Embarque.InspeccionTrigo.alimentar(Math.Abs(CInt(chkCondLimpieza.Checked)), txtOlor.Text, txtColor.Text, txtDaniado.Text, txtPlagas.Text,
                                               txtOtrost.Text, txtEmbId.Text, Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"),
                                               chkConformetri.Checked, txtObservacionestri.Text).clonar()

            msg = Embarque.InspeccionTransporte.alimentar(Math.Abs(CInt(chkCondTransporte.Checked)), txtLibreba.Text, txtLibregra.Text, txtOtrosp.Text,
                                                    txtSellosc.Text, txtServtra.Text, txtEmbId.Text, Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"),
                                                    chkConformetra.Checked, txtObservacionestra.Text).clonar()

            msg = Embarque.Laboratorio.alimentar(txtProteinal.Text, txtHumedadl.Text, txtphectolitrol.Text, txtImpurezal.Text, _
                                                 txtProteinar.Text, txtHumedadr.Text, txtPhectolitror.Text, txtImpurezar.Text, _
                                                 txtObslab.Text, txtEmbId.Text, Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                                                 (Math.Abs(CInt(chkLaboratorio.Checked))))
        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarEmbarque() As Mensaje
        Dim gen3E As Genericas3E = Nothing
        Dim bcats As Busquedas = Nothing
        Dim tResultados As DataTable = Nothing

        Try
            msg.reset()
            gen3E = New Genericas3E

            txtEmbId.Text = Embarque.EmbId
            genW.seleccionarItem(cmbEstado, Embarque.EstadoId)
            dtpFechaEmbarque.Value = DateTime.Parse(Embarque.Fchemb)
            txtOrdenId.Text = Embarque.OrdenId
            txtLoteId.Text = Embarque.LoteId
            txtTrigoId.Text = Embarque.TrigoId
            txtTrigo.Text = Embarque.Trigo
            txtProvTrigoId.Text = Embarque.ProvTrigoId
            txtProvTrigo.Text = Embarque.ProvTrigo
            txtOrigenId.Text = Embarque.OrigenId
            txtOrigen.Text = Embarque.Origen
            txtReftrans.Text = Embarque.Reftrans
            txtDstinoId.Text = Embarque.DstinoId

            bcats = New Busquedas(cliente)
            tResultados = bcats.buscarSilos(1, txtDstinoId.Text)
            genW.llenarListadoDesdeTabla(tResultados, "SiloId", "SiloId", lstSilos)
            lstSilos.CheckOnClick = True



            txtDestino.Text = Embarque.Dstino
            txtProvFleteId.Text = Embarque.Provflet
            txtProvFlete.Text = Embarque.Provfletn
            txtPesoEmb.Text = Embarque.Pesoemb
            txtFactfl.Text = Embarque.Factfl

            cmbMonedaId.SelectedIndex = -1
            gen3E.seleccionarItem(cmbMonedaId, Embarque.MonedaId)


            txtTarifa.Text = Embarque.Tarifa
            txtSelloe.Text = Embarque.Noselloe
            txtObgen.Text = Embarque.Obgen

            dtpFchrec.Value = DateTime.Parse(Embarque.Fchrec)

            'txtUbTmpId.Text = Embarque.UbicaTmp
            'txtUbicacion.Text = Embarque.Ubicacion


            txtPesoRecibido.Text = Embarque.Pesore
            txtDiferencia.Text = Embarque.Dif
            txtOperadorId.Text = Embarque.OprdorId
            txtOperador.Text = Embarque.Oprdor
            asignarSilos(Embarque.Silo)
            '"" = Embarque.Silo
            txtSelloRecep.Text = Embarque.Sellorec

            chkCondLimpieza.Checked = Embarque.InspeccionTrigo.Condlimp
            txtOlor.Text = Embarque.InspeccionTrigo.Olor
            txtColor.Text = Embarque.InspeccionTrigo.Color
            txtDaniado.Text = Embarque.InspeccionTrigo.Danado
            txtPlagas.Text = Embarque.InspeccionTrigo.Plagas
            txtOtrost.Text = Embarque.InspeccionTrigo.Otros
            chkConformetri.Checked = Embarque.InspeccionTrigo.Conforme
            txtObservacionestri.Text = Embarque.InspeccionTrigo.Observ

            chkCondTransporte.Checked = Embarque.InspeccionTransporte.Condtra
            txtLibreba.Text = Embarque.InspeccionTransporte.Libreba
            txtLibregra.Text = Embarque.InspeccionTransporte.Libregr
            txtOtrosp.Text = Embarque.InspeccionTransporte.Otros
            txtSellosc.Text = Embarque.InspeccionTransporte.Sellosc
            txtServtra.Text = Embarque.InspeccionTransporte.Servtra
            chkConformetra.Checked = Embarque.InspeccionTransporte.Conforme
            txtObservacionestra.Text = Embarque.InspeccionTransporte.Observ


            chkLaboratorio.Checked = Embarque.Laboratorio.Lab
            txtProteinal.Text = Embarque.Laboratorio.Eprot
            txtHumedadl.Text = Embarque.Laboratorio.Ehum
            txtphectolitrol.Text = Embarque.Laboratorio.Ephl
            txtImpurezal.Text = Embarque.Laboratorio.Eimp
            txtProteinar.Text = Embarque.Laboratorio.Rprot
            txtHumedadr.Text = Embarque.Laboratorio.Rhum
            txtPhectolitror.Text = Embarque.Laboratorio.Rphl
            txtImpurezar.Text = Embarque.Laboratorio.Rimp

        Catch ex As Exception
            msg.setError("No fue posible cargar el Embarque: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function crear() As Mensaje
        Try
            msg.reset()

            If Not atmPerf.Creacion Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If


            If validarDatos(False).EsError Then GoTo finalize
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Embarque.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el Embarque: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function modificar() As Mensaje
        Try
            msg.reset()

            If Not atmPerf.Mdfccion Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If


            If validarDatos(False).EsError Then GoTo finalize
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Embarque.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el Embarque: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim estado As String = ""

        Dim sEmbId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If


            If Not cmbEstado.SelectedItem Is Nothing Then _
                estado = cmbEstado.SelectedItem.ItemData.ToString

            frmBusq = New frmBusqueda(cliente, genW, 8, 1, txtEmbId.Text, estado, Format(dtpFechaEmbarque.Value, "yyyy-MM-dd"), _
                                      txtOrdenId.Text, txtLoteId.Text, txtReftrans.Text)

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sEmbId = resultados(0)
                If sEmbId.Trim.Length.Equals(0) Then GoTo finalize

                Embarque.liberarObjetos()

                Embarque = New Embarque(cliente, sEmbId)
                msg = Embarque.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarEmbarque().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Embarque: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function busquedaOrden() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOrdenId As String = ""

        Try
            msg.reset()

            frmBusq = New frmBusqueda(cliente, genW, 5, 1, txtOrdenId.Text, "A", "1899-12-31",
                          "", "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sOrdenId = resultados(0)
                If sOrdenId.Trim.Length.Equals(0) Then
                    txtOrdenId.Text = ""
                    msg.setError("No se seleccionó un código de Orden correcto.")

                    GoTo finalize
                End If

                txtOrdenId.Text = resultados(0)
                txtLoteId.Text = resultados(2)
                txtTrigoId.Text = resultados(3)
                txtTrigo.Text = resultados(4)
                txtProvTrigoId.Text = resultados(6)
                txtProvTrigo.Text = resultados(7)
                txtOrigenId.Text = resultados(8)
                txtOrigen.Text = resultados(9)
                txtProteinal.Text = resultados(5)
                txtHumedadl.Text = resultados(10)
                txtphectolitrol.Text = resultados(11)
                txtImpurezal.Text = resultados(12)

                txtReftrans.Focus()
            Else
                txtLoteId.Text = ""

                msg.setError("No se seleccionó un código de Orden correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar la Orden: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Private Function buscarLote() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sLoteId As String = ""

        Try
            msg.reset()

            frmBusq = New frmBusqueda(cliente, genW, 3, 1, txtLoteId.Text, "A", "", "", "1899-12-31", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sLoteId = resultados(0)
                If sLoteId.Trim.Length.Equals(0) Then
                    txtLoteId.Text = ""
                    msg.setError("No se seleccionó un código de Lote correcto.")

                    GoTo finalize
                End If

                txtLoteId.Text = resultados(0)

                txtOrigenId.Focus()
            Else
                txtLoteId.Text = ""

                msg.setError("No se seleccionó un código de Lote correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Lote: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarDestino(ByVal pBusqueda As Integer) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim bcats As Busquedas = Nothing
        Dim tResultados As DataTable = Nothing

        Dim sDstinoId As String = ""
        Dim silos As String = ""

        Try
            msg.reset()

            If pBusqueda = 1 Then
                frmBusq = New frmBusqueda(cliente, genW, 6, 1, txtDstinoId.Text, "", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 6, 1, "", txtDestino.Text, "1", "", "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                sDstinoId = resultados(0)
                If sDstinoId.Trim.Length.Equals(0) Then GoTo finalize

                txtDstinoId.Text = resultados(0)
                txtDestino.Text = resultados(1)

                silos = silosSeleccionados()
                bcats = New Busquedas(cliente)
                tResultados = bcats.buscarSilos(1, txtDstinoId.Text)
                genW.llenarListadoDesdeTabla(tResultados, "SiloId", "SiloId", lstSilos)
                lstSilos.CheckOnClick = True

                asignarSilos(silos)

                bcats = Nothing

                txtProvFlete.Focus()
            Else
                If pBusqueda = 1 Then
                    txtDstinoId.Text = ""
                Else
                    txtDestino.Text = ""
                End If

                msg.setError("No se seleccionó un código de Destino correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Destino: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Private Function buscarProveedorFlete(ByVal pBusqueda As Integer) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sProvId As String = ""

        Try
            msg.reset()

            If pBusqueda = 1 Then
                frmBusq = New frmBusqueda(cliente, genW, 1, 1, txtProvFleteId.Text, "T002", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 1, 1, "", "T002", "1", txtProvFlete.Text, "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                sProvId = resultados(0)
                If sProvId.Trim.Length.Equals(0) Then GoTo finalize

                txtProvFleteId.Text = resultados(0)
                txtProvFlete.Text = resultados(1)

                txtPesoEmb.Focus()
            Else
                If pBusqueda = 1 Then
                    txtProvFleteId.Text = ""
                Else
                    txtProvFlete.Text = ""
                End If

                msg.setError("No se seleccionó un código de Proveedor de flete correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Proveedor de flete: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Private Function buscarOperador(ByVal pBusqueda As Integer) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOpradorId As String = ""

        Try
            msg.reset()

            If pBusqueda = 1 Then
                frmBusq = New frmBusqueda(cliente, genW, 7, 1, txtOperadorId.Text, "", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 7, 1, "", txtOperador.Text, "1", "", "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                sOpradorId = resultados(0)
                If sOpradorId.Trim.Length.Equals(0) Then
                    If pBusqueda = 1 Then
                        txtOperadorId.Text = ""
                    Else
                        txtOperador.Text = ""
                    End If

                    msg.setError("No se seleccionó un código de Operador correcto.")

                    GoTo finalize
                End If

                txtOperadorId.Text = resultados(0)
                txtOperador.Text = resultados(1)

                txtSelloRecep.Focus()
            Else
                If pBusqueda = 1 Then
                    txtOperadorId.Text = ""
                Else
                    txtOperador.Text = ""
                End If

                msg.setError("No se seleccionó un código de Operador correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Operador: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function cerrarAbrir() As Mensaje
        Dim nuevoEstado As String = ""

        Try
            msg.reset()

            forzarBusqueda = False

            If Not atmPerf.Cierre Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If


            If Modop <> SysEnums.Modos.mConsultar Then
                msg.setError("El Embarque debe existir y no tener cambios sin guardar para poder ser cerrada.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual del Embarque no admite la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("El Embarque " + txtEmbId.Text + " ya ha sido cancelado y no es posible la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "C" Then
                msg.setPregunta("El Embarque " + txtEmbId.Text + " ya ha sido cerrado con anterioridad. ¿Desea abrir el Embarque?")
                nuevoEstado = "A"
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "A" Then
                msg.setPregunta("El Embarque " + txtEmbId.Text + " se encuentra Abierto. ¿Desea cerrar el Embarque?")
                nuevoEstado = "C"
            End If

            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, nuevoEstado)
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Embarque.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then GoTo finalize

            msg.setInfo("Embarque " + Embarque.EmbId + " " + cmbEstado.SelectedItem.Description.ToString + " con éxito.")
            genW.publicar(infDoc, msg)

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible Abrir/Cerrar el Embarque: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function cancelar() As Mensaje
        Try
            msg.reset()

            forzarBusqueda = False

            If Not atmPerf.Cnlacion Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If


            If Modop <> SysEnums.Modos.mConsultar Then
                msg.setError("El Embarque debe existir y no tener cambios sin guardar para poder ser cancelado.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual del Embarque no admite la operación de Cancelación.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("El Embarque " + txtEmbId.Text + " ya ha sido cancelada con anterioridad.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            msg.setPregunta("Ha seleccionado la opción de cancelación de documento. Si da clic en Sí, el documento se cancelará y será necesario " _
                            + " abrir un nuevo documento si desea reemplazarlo. ¿Desea continuar cancelando el documento?")
            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, "L")
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Embarque.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then
                Embarque.liberarObjetos()

                Embarque = New Embarque(cliente, txtEmbId.Text)
                msg = Embarque.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarEmbarque().EsError Then GoTo finalize
            Else
                msg.setInfo("Embarque " + Embarque.EmbId + " cancelado con éxito.")
                genW.publicar(infDoc, msg)
            End If

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cancelar el Embarque: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sEmbId As String = ""

        Dim sPref As String = "E"
        Dim icDigit As Integer = 7

        Try
            forzarBusqueda = False

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If


            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Embarque Is Nothing Then
                Embarque.liberarObjetos()
            End If

            sEmbId = txtEmbId.Text

            Embarque = New Embarque(cliente)
            If Embarque.OrdenId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Orden para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sEmbId.Trim.Length.Equals(0) Then
                        sEmbId = Embarque.embarqueAnterior(Embarque.EmbId).ToString
                    Else
                        sEmbId = Embarque.embarqueAnterior(sEmbId).ToString
                    End If
                Case "3"
                    If sEmbId.Trim.Length.Equals(0) Then
                        sEmbId = Embarque.embarqueSiguiente(Embarque.EmbId).ToString
                    Else
                        sEmbId = Embarque.embarqueSiguiente(sEmbId).ToString
                    End If
                Case "1"
                    sEmbId = Embarque.embarqueSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sEmbId = sPref + (Integer.Parse(Embarque.EmbId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Embarque.liberarObjetos()

            Embarque = New Embarque(cliente, sEmbId)
            msg = Embarque.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarEmbarque().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos del Embarque: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Public Function buscarHistorial() As Mensaje
        Dim resultados As DataTable = Nothing
        Dim frmHist As frmHistorial = Nothing

        Try
            msg.reset()

            If Not Usua.Perfil.Detalle.obtenerAtomo(10).Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Modop = SysEnums.Modos.mCrear Or Modop = SysEnums.Modos.mBuscar Then
                msg.setAdvertencia("Sólo se puede consultar el historial de un documento guardado.")
                GoTo finalize
            End If

            resultados = Embarque.buscarCambios(txtEmbId.Text)
            If resultados.Rows.Count = 0 Then
                msg.setInfo("Este documento no tiene cambios.")
                GoTo finalize
            End If

            frmHist = New frmHistorial(cliente, genW, Cnfg, Usua,
                                       resultados, SysEnums.TiposDocumentos.dEmbarque, txtEmbId.Text)
            frmHist.MdiParent = Me.MdiParent
            frmHist.Show()
        Catch ex As Exception
            msg.setError("No fue posible buscar el historial de la Orden: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg)
        Return msg

    End Function

    Private Function validarDatos(ByVal bCerrarAbrir As Boolean) As Mensaje
        Try
            msg.reset()

            If Not bCerrarAbrir Then
                If cmbEstado.SelectedItem.ItemData.Equals("C") Or
                    cmbEstado.SelectedItem.ItemData.Equals("L") Then
                    msg.setError("El Embarque ha sido " + cmbEstado.SelectedItem.Description + " y no se puede modificar.")

                    GoTo finalize
                End If
            End If

            If txtPesoRecibido.Text.Trim.Length.Equals(0) Then txtPesoRecibido.Text = "0"
            If txtDiferencia.Text.Trim.Length.Equals(0) Then txtDiferencia.Text = "0"
            If txtTarifa.Text.Trim.Length.Equals(0) Then txtTarifa.Text = "0"

            If txtProteinar.Text.Trim.Length.Equals(0) Then txtProteinar.Text = "0"
            If txtHumedadr.Text.Trim.Length.Equals(0) Then txtHumedadr.Text = "0"
            If txtPhectolitror.Text.Trim.Length.Equals(0) Then txtPhectolitror.Text = "0"
            If txtImpurezar.Text.Trim.Length.Equals(0) Then txtImpurezar.Text = "0"

            If txtOrdenId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Orden que origina el Embarque.")
                txtOrdenId.Focus()
            ElseIf txtReftrans.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Referencia de transporte.")
                txtReftrans.Focus()
            ElseIf txtDstinoId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el Destino del Embarque.")
                txtDstinoId.Focus()
            ElseIf txtDstinoId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el Destino del Embarque.")
                txtDstinoId.Focus()
            ElseIf txtProvFleteId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el Proveedor de flete.")
                txtProvFleteId.Focus()
            ElseIf txtPesoEmb.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el peso del Embarque.")
                txtPesoEmb.Focus()
            ElseIf Not Double.TryParse(txtPesoEmb.Text, 0) Then
                msg.setError("El valor del Peso embarcado no es válido.")
                txtPesoEmb.Focus()
            ElseIf Not Double.TryParse(txtPesoRecibido.Text, 0) Then
                msg.setError("El valor de Peso recibido no es válido.")
                txtPesoRecibido.Focus()
            ElseIf Not Double.TryParse(txtTarifa.Text, 0) Then
                msg.setError("El valor de Tarifa no es válido.")
                txtTarifa.Focus()
            ElseIf Double.Parse(txtPesoEmb.Text) < Double.Parse(Cnfg.Tnlmin) Then
                msg.setError("El peso embarcado es menor al mínimo permitido (" + Cnfg.Tnlmin.ToString + ").")
                txtPesoEmb.Focus()
            ElseIf Double.Parse(txtPesoEmb.Text) > Double.Parse(Cnfg.Tnlmax) Then
                msg.setError("El peso embarcado es mayor al máximo permitido (" + Cnfg.Tnlmax.ToString + ").")
                txtPesoEmb.Focus()
            End If


            If chkLaboratorio.Checked Then
                If txtProteinar.Text.Trim.Length.Equals(0) Then
                    msg.setError("No se ha definido  el valor de Proteína en el reporte de Laboratorio.")
                    tbcEmbarques.SelectedIndex = 4
                    txtProteinar.Focus()
                ElseIf txtHumedadr.Text.Trim.Length.Equals(0) Then
                    msg.setError("No se ha definido el valor de Humedad en el reporte de Laboratorio.")
                    tbcEmbarques.SelectedIndex = 4
                    txtHumedadr.Focus()
                ElseIf txtPhectolitror.Text.Trim.Length.Equals(0) Then
                    msg.setError("No se ha definido el valor de Peso Hectolitro en el reporte de Laboratorio.")
                    tbcEmbarques.SelectedIndex = 4
                    txtPhectolitror.Focus()
                ElseIf txtImpurezar.Text.Trim.Length.Equals(0) Then
                    msg.setError("El valor de Impureza en el reporte de Laboratorio es inválido.")
                    tbcEmbarques.SelectedIndex = 4
                    txtSellosc.Focus()
                ElseIf Not Double.TryParse(txtProteinar.Text, 0) Then
                    msg.setError("El valor de Proteína en el reporte de Laboratorio es inválido.")
                    tbcEmbarques.SelectedIndex = 4
                    txtProteinar.Focus()
                ElseIf Not Double.TryParse(txtHumedadr.Text, 0) Then
                    msg.setError("El valor de Humedad en el reporte de Laboratorio es inválido.")
                    tbcEmbarques.SelectedIndex = 4
                    txtHumedadr.Focus()
                ElseIf Not Double.TryParse(txtPhectolitror.Text, 0) Then
                    msg.setError("El valor de Peso Hectolitro en el reporte de Laboratorio es inválido.")
                    tbcEmbarques.SelectedIndex = 4
                    txtPhectolitror.Focus()
                ElseIf Not Double.TryParse(txtImpurezar.Text, 0) Then
                    msg.setError("El valor de Impureza en el reporte de Laboratorio es inválido.")
                    tbcEmbarques.SelectedIndex = 4
                    txtSellosc.Focus()
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

    Private Sub setObjetosVis()
        txtLoteId.Enabled = False
        txtTrigoId.Enabled = False
        txtTrigo.Enabled = False
        txtProvTrigoId.Enabled = False
        txtProvTrigo.Enabled = False
        txtOrigenId.Enabled = False
        txtOrigen.Enabled = False

        txtProteinal.Enabled = False
        txtHumedadl.Enabled = False
        txtphectolitrol.Enabled = False
        txtImpurezal.Enabled = False
    End Sub

    Private Sub activarInspeccionTrigo(ByVal pActivo As Boolean)
        txtOlor.Enabled = pActivo
        txtColor.Enabled = pActivo
        txtDaniado.Enabled = pActivo
        txtPlagas.Enabled = pActivo
        txtOtrost.Enabled = pActivo
        txtObservacionestri.Enabled = pActivo
    End Sub


    Private Sub activarInspeccionTransporte(ByVal pActivo As Boolean)
        txtLibreba.Enabled = pActivo
        txtLibregra.Enabled = pActivo
        txtOtrosp.Enabled = pActivo
        txtSellosc.Enabled = pActivo
        txtServtra.Enabled = pActivo
        txtObservacionestra.Enabled = pActivo
    End Sub

    Private Sub activarLaboratorio(ByVal pActivo As Boolean)
        txtProteinar.Enabled = pActivo
        txtHumedadr.Enabled = pActivo
        txtPhectolitror.Enabled = pActivo
        txtImpurezar.Enabled = pActivo
        txtObslab.Enabled = pActivo
    End Sub

    Private Sub calcularDiferenciaP(ByVal pOpcion As Integer)
        Dim dPesoe As Decimal = 0
        Dim dPesor As Decimal = 0

        msg.reset()

        If Not Decimal.TryParse(txtPesoEmb.Text, dPesoe) Then
            msg.setError("El valor de Peso Embarcado no es válido.")
            tbcEmbarques.SelectedIndex = 0
            txtPesoEmb.Focus()

            GoTo finalize
        End If

        If pOpcion = 1 Then
            If Decimal.TryParse(txtPesoRecibido.Text, dPesor) Then
                txtDiferencia.Text = (dPesoe - dPesor).ToString
            Else
                txtDiferencia.Text = "0.000"
            End If
        ElseIf pOpcion = 2 Then
            If Decimal.TryParse(txtPesoRecibido.Text, dPesor) Then
                txtDiferencia.Text = (dPesoe - dPesor).ToString
            Else
                msg.setError("El valor de Peso recibido no es válido.")
            End If
        End If

        If Math.Abs(Decimal.Parse(txtDiferencia.Text)) <= Decimal.Parse(Cnfg.Difmin) Then
            lblAlertaDif.Text = "El rango de diferencia se encuentra dentro de lo normal."
            lblAlertaDif.ForeColor = Color.Black
        ElseIf Math.Abs(Decimal.Parse(txtDiferencia.Text)) <= Decimal.Parse(Cnfg.Difmax) Then
            lblAlertaDif.Text = "El rango de diferencia se encuentra elevado sin alcanzar niveles críticos."
            lblAlertaDif.ForeColor = Color.DarkOrange
        Else
            lblAlertaDif.Text = "El rango de diferencia es demasiado elevado. Se sugiere buscar una solución a este conflicto."
            lblAlertaDif.ForeColor = Color.DarkRed
        End If
finalize:
        genW.publicar(infDoc, msg, True)
    End Sub

    Private Function silosSeleccionados() As String
        Dim silos As String = "-"
        Dim itmCounter As Integer = 0

        If lstSilos.Items.Count > 0 Then
            For Each item As SubItem In lstSilos.Items
                If lstSilos.GetItemChecked(itmCounter) Then
                    silos += item.ItemData + "-"
                End If

                itmCounter += 1
            Next
        End If

        Return silos
    End Function

    Private Sub asignarSilos(ByVal pSilos As String)
        Dim itmCounter As Integer = 0

        For itmCounter = 0 To lstSilos.Items.Count - 1
            If pSilos.Contains("-" + lstSilos.Items.Item(itmCounter).ItemData.ToString + "-") Then
                lstSilos.SetItemChecked(itmCounter, True)
            End If
        Next
    End Sub
#End Region

    Private Sub frmEmbarque_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Usua.CerrandoSesion Then
            If Not genW.continuarSinGuardar(infDoc, modificado) Then
                e.Cancel = True
            Else
                forzarBusqueda = False
            End If
        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Select Case Modop
            Case SysEnums.Modos.mCrear
                crear()
            Case SysEnums.Modos.mModificar
                modificar()
            Case SysEnums.Modos.mBuscar
                buscar()
            Case SysEnums.Modos.mConsultar, SysEnums.Modos.mHistorial
                Me.Close()
        End Select
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub dtpFechaEmbarque_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEmbarque.ValueChanged
        setModificar()
    End Sub

    Private Sub txtOrdenId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrdenId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            busquedaOrden()
        End If
    End Sub

    Private Sub txtOrdenId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrdenId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtOrdenId_Leave(sender As Object, e As EventArgs) Handles txtOrdenId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtOrdenId.Text.Trim.Length.Equals(0) Then _
            If busquedaOrden().EsError Then txtOrdenId.Focus()
    End Sub

    Private Sub txtOrdenId_TextChanged(sender As Object, e As EventArgs) Handles txtOrdenId.TextChanged
        setModificar()
    End Sub

    Private Sub txtReftrans_TextChanged(sender As Object, e As EventArgs) Handles txtReftrans.TextChanged
        setModificar()
    End Sub

    Private Sub txtDstinoId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDstinoId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarDestino(1)
        End If
    End Sub

    Private Sub txtDstinoId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDstinoId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtDstinoId_Leave(sender As Object, e As EventArgs) Handles txtDstinoId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtDstinoId.Text.Trim.Length.Equals(0) Then _
            If buscarDestino(1).EsError Then txtOrigenId.Focus()
    End Sub

    Private Sub txtDstinoId_TextChanged(sender As Object, e As EventArgs) Handles txtDstinoId.TextChanged
        setModificar()
    End Sub

    Private Sub txtDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDestino.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarDestino(2)
        End If
    End Sub

    Private Sub txtDestino_Leave(sender As Object, e As EventArgs) Handles txtDestino.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtDestino.Text.Trim.Length.Equals(0) Then _
            If buscarDestino(2).EsError Then txtOrigen.Focus()
    End Sub

    Private Sub txtDestino_TextChanged(sender As Object, e As EventArgs) Handles txtDestino.TextChanged
        setModificar()
    End Sub

    Private Sub txtProvFleteId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvFleteId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarProveedorFlete(1)
        End If
    End Sub

    Private Sub txtProvFleteId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProvFleteId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtProvFleteId_Leave(sender As Object, e As EventArgs) Handles txtProvFleteId.Leave
        If Not forzarBusqueda Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtProvFleteId.Text.Trim.Length.Equals(0) Then _
            If buscarProveedorFlete(1).EsError Then txtProvFleteId.Focus()
    End Sub

    Private Sub txtProvFleteId_TextChanged(sender As Object, e As EventArgs) Handles txtProvFleteId.TextChanged
        setModificar()
    End Sub

    Private Sub txtProvFlete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvFlete.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarProveedorFlete(2)
        End If
    End Sub

    Private Sub txtProvFlete_Leave(sender As Object, e As EventArgs) Handles txtProvFlete.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtProvFlete.Text.Trim.Length.Equals(0) Then _
            If buscarProveedorFlete(2).EsError Then txtProvFlete.Focus()
    End Sub

    Private Sub txtProvFlete_TextChanged(sender As Object, e As EventArgs) Handles txtProvFlete.TextChanged
        setModificar()
    End Sub




    Private Sub txtPesoEmb_Leave(sender As Object, e As EventArgs) Handles txtPesoEmb.Leave
        calcularDiferenciaP(1)
        If msg.EsError Then txtPesoRecibido.Focus()
    End Sub

    Private Sub txtPesoEmb_TextChanged(sender As Object, e As EventArgs) Handles txtPesoEmb.TextChanged
        setModificar()
    End Sub

    Private Sub txtFactfl_TextChanged(sender As Object, e As EventArgs) Handles txtFactfl.TextChanged
        setModificar()
    End Sub

    Private Sub txtSelloe_TextChanged(sender As Object, e As EventArgs) Handles txtSelloe.TextChanged
        setModificar()
    End Sub

    Private Sub txtObgen_TextChanged(sender As Object, e As EventArgs) Handles txtObgen.TextChanged
        setModificar()
    End Sub

    Private Sub dtpFchrec_ValueChanged(sender As Object, e As EventArgs) Handles dtpFchrec.ValueChanged
        setModificar()
    End Sub


    Private Sub txtOperadorId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOperadorId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarOperador(1)
        End If
    End Sub

    Private Sub txtOperadorId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOperadorId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub


    Private Sub txtOperadorId_Leave(sender As Object, e As EventArgs) Handles txtOperadorId.Leave
        If Not forzarBusqueda Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtOperadorId.Text.Trim.Length.Equals(0) Then _
            buscarOperador(1)
    End Sub

    Private Sub txtOperadorId_TextChanged(sender As Object, e As EventArgs) Handles txtOperadorId.TextChanged
        setModificar()
    End Sub

    Private Sub txtOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOperador.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarOperador(2)
        End If
    End Sub

    Private Sub txtOperador_Leave(sender As Object, e As EventArgs) Handles txtOperador.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtOperador.Text.Trim.Length.Equals(0) Then _
            buscarOperador(2)
    End Sub

    Private Sub txtOperador_TextChanged(sender As Object, e As EventArgs) Handles txtOperador.TextChanged
        setModificar()
    End Sub

    Private Sub txtSilo_TextChanged(sender As Object, e As EventArgs)
        setModificar()
    End Sub

    Private Sub txtSelloRecep_TextChanged(sender As Object, e As EventArgs) Handles txtSelloRecep.TextChanged
        setModificar()
    End Sub

    Private Sub txtEmbId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmbId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtEmbId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmbId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtPesoRecibido_Leave(sender As Object, e As EventArgs) Handles txtPesoRecibido.Leave
        calcularDiferenciaP(2)
        If msg.EsError Then txtPesoRecibido.Focus()
    End Sub

    Private Sub txtLoteId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLoteId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarLote()
        End If
    End Sub

    Private Sub txtLoteId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub cmdOrden_Click(sender As Object, e As EventArgs) Handles cmdOrden.Click
        Dim frmord As frmOrden = Nothing

        frmord = New frmOrden(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua,
                              txtOrdenId.Text)
        frmord.MdiParent = Me.MdiParent
        frmord.Show()
    End Sub

    Private Sub cmbLote_Click(sender As Object, e As EventArgs) Handles cmbLote.Click
        Dim frmlot As frmLote = Nothing

        frmlot = New frmLote(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua,
                             txtLoteId.Text)
        frmlot.MdiParent = Me.MdiParent
        frmlot.Show()
    End Sub

    Private Sub cmdTrigo_Click(sender As Object, e As EventArgs) Handles cmdTrigo.Click
        Dim frmtr As frmTrigo = Nothing

        frmtr = New frmTrigo(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtTrigoId.Text)
        frmtr.MdiParent = Me.MdiParent
        frmtr.Show()
    End Sub

    Private Sub cmdProvTrigo_Click(sender As Object, e As EventArgs) Handles cmdProvTrigo.Click
        Dim frmprvt As frmProveedor = Nothing

        frmprvt = New frmProveedor(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtProvTrigoId.Text)
        frmprvt.MdiParent = Me.MdiParent
        frmprvt.Show()
    End Sub


    Private Sub cmdOrigen_Click(sender As Object, e As EventArgs) Handles cmdOrigen.Click
        Dim frmorig As frmOrigen = Nothing

        frmorig = New frmOrigen(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtOrigenId.Text)
        frmorig.MdiParent = Me.MdiParent
        frmorig.Show()
    End Sub

    Private Sub cmdDstino_Click(sender As Object, e As EventArgs) Handles cmdDstino.Click
        Dim frmdest As frmDestino = Nothing

        frmdest = New frmDestino(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtDstinoId.Text)
        frmdest.MdiParent = Me.MdiParent
        frmdest.Show()
    End Sub

    Private Sub cmdProvFlete_Click(sender As Object, e As EventArgs) Handles cmdProvFlete.Click
        Dim frmprvf As frmProveedor = Nothing

        frmprvf = New frmProveedor(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtProvFleteId.Text)
        frmprvf.MdiParent = Me.MdiParent
        frmprvf.Show()
    End Sub

    Private Sub cmdOperador_Click(sender As Object, e As EventArgs) Handles cmdOperador.Click
        Dim frmop As frmOperador = Nothing

        frmop = New frmOperador(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtOperadorId.Text)
        frmop.MdiParent = Me.MdiParent
        frmop.Show()
    End Sub

    Private Sub frmEmbarque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim modif As Boolean = False
        Dim eshistorial As Boolean = False

        If Not Embarque Is Nothing Then
            If Not Embarque.Fchemb.Length.Equals(0) Then
                If Modop = SysEnums.Modos.mHistorial Then eshistorial = True
                dtpFechaEmbarque.Value = Date.Parse(Embarque.Fchemb).AddSeconds(1)
                modif = True
            End If

            If Not Embarque.Fchrec.Length.Equals(0) Then
                If Modop = SysEnums.Modos.mHistorial Then eshistorial = True
                dtpFchrec.Value = Date.Parse(Embarque.Fchrec).AddSeconds(1)
                modif = True
            End If

            If modif Then
                If eshistorial Then
                    setHistorial(sEmbInst)
                Else
                    setConsultar()
                End If
            End If
        End If
    End Sub

    Private Sub chkCondLimpieza_CheckedChanged(sender As Object, e As EventArgs) Handles chkCondLimpieza.CheckedChanged
        activarInspeccionTrigo(chkCondLimpieza.Checked)
        setModificar()
    End Sub

    Private Sub txtOlor_TextChanged(sender As Object, e As EventArgs) Handles txtOlor.TextChanged
        setModificar()
    End Sub

    Private Sub txtColor_TextChanged(sender As Object, e As EventArgs) Handles txtColor.TextChanged
        setModificar()
    End Sub

    Private Sub txtDaniado_TextChanged(sender As Object, e As EventArgs) Handles txtDaniado.TextChanged
        setModificar()
    End Sub

    Private Sub txtPlagas_TextChanged(sender As Object, e As EventArgs) Handles txtPlagas.TextChanged
        setModificar()
    End Sub

    Private Sub txtOtrost_TextChanged(sender As Object, e As EventArgs) Handles txtOtrost.TextChanged
        setModificar()
    End Sub

    Private Sub chkCondTransporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkCondTransporte.CheckedChanged
        activarInspeccionTransporte(chkCondTransporte.Checked)

        setModificar()
    End Sub

    Private Sub txtLibreba_TextChanged(sender As Object, e As EventArgs) Handles txtLibreba.TextChanged
        setModificar()
    End Sub

    Private Sub txtLibregra_TextChanged(sender As Object, e As EventArgs) Handles txtLibregra.TextChanged
        setModificar()
    End Sub

    Private Sub txtOtrosp_TextChanged(sender As Object, e As EventArgs) Handles txtOtrosp.TextChanged
        setModificar()
    End Sub

    Private Sub txtSellosc_TextChanged(sender As Object, e As EventArgs) Handles txtSellosc.TextChanged
        setModificar()
    End Sub
    Private Sub txtUbTmpId_TextChanged(sender As Object, e As EventArgs)
        setModificar()
    End Sub
    Private Sub txtUbicacion_TextChanged(sender As Object, e As EventArgs)
        setModificar()
    End Sub

    Private Sub txtServtra_TextChanged(sender As Object, e As EventArgs) Handles txtServtra.TextChanged
        setModificar()
    End Sub

    Private Sub chkLaboratorio_CheckedChanged(sender As Object, e As EventArgs) Handles chkLaboratorio.CheckedChanged
        setModificar()

        activarLaboratorio(chkLaboratorio.Checked)
    End Sub

    Private Sub cmbMonedaId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonedaId.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub txtTarifa_TextChanged(sender As Object, e As EventArgs) Handles txtTarifa.TextChanged
        setModificar()
    End Sub

    Private Sub lstSilos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstSilos.ItemCheck
        setModificar()
    End Sub

    Private Sub txtPesoRecibido_TextChanged(sender As Object, e As EventArgs) Handles txtPesoRecibido.TextChanged
        setModificar()
    End Sub

    Private Sub frmEmbarque_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim control As Control = Nothing

        If e.Button = Windows.Forms.MouseButtons.Right Then
            control = Me.GetChildAtPoint(e.Location)

            If Not control Is Nothing Then
                If Not control.Enabled And Not control.ContextMenuStrip Is Nothing Then
                    control.ContextMenuStrip.Show(Me, e.Location)
                End If
            End If
        End If
    End Sub

    Private Sub mnuCopiarTexto_Click(sender As Object, e As EventArgs) Handles mnuCopiarTexto.Click
        If Not txtEmbId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtEmbId.Text)
    End Sub

    Private Sub chkConformetra_CheckedChanged(sender As Object, e As EventArgs) Handles chkConformetra.CheckedChanged
        setModificar()
    End Sub

    Private Sub txtObservacionestra_TextChanged(sender As Object, e As EventArgs) Handles txtObservacionestra.TextChanged
        setModificar()
    End Sub

    Private Sub txtObservacionestri_TextChanged(sender As Object, e As EventArgs) Handles txtObservacionestri.TextChanged
        setModificar()
    End Sub

    Private Sub chkConformetri_CheckedChanged(sender As Object, e As EventArgs) Handles chkConformetri.CheckedChanged
        setModificar()
    End Sub
End Class