Imports System.IO

Imports Genericas
Imports ObjEntidades

Public Class frmOrden
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

    Private Orden As Orden
    Private sOrdenInst As String

    Private WithEvents mnuAniadirAdjunto As ToolStripMenuItem
    Private WithEvents mnuQuitarAdjunto As ToolStripMenuItem
    Private WithEvents mnuVerAdjunto As ToolStripMenuItem
    Private WithEvents mnuCopiarTexto As ToolStripMenuItem

    Private ubicMouse As DataGridViewCellEventArgs


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
            Return True
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
               ByVal pUsuario As Usuario, Optional ByVal pOrdenId As String = "", _
               Optional ByVal pOrden As Orden = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try
            If inicializarControles().EsError Then GoTo finalize
            If pOrdenId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOrden, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sOrdenes", "", "", "")

            Cnfg = pConfiguracion
            Usua = pUsuario

            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(23)

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
                    Orden = New Orden(cliente, pOrdenId)
                    msg = Orden.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarOrden().EsError Then GoTo finalize

                    setConsultar()
                Case SysEnums.Modos.mHistorial
                    Orden = pOrden

                    If cargarOrden().EsError Then GoTo finalize

                    sOrdenInst = pOrdenId
                    setHistorial(pOrdenId)
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

            agregarContextuales()
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dOrden, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuAniadirAdjunto = New ToolStripMenuItem()
        mnuAniadirAdjunto.Text = "Añadir"

        mnuQuitarAdjunto = New ToolStripMenuItem()
        mnuQuitarAdjunto.Text = "Quitar"

        mnuVerAdjunto = New ToolStripMenuItem()
        mnuVerAdjunto.Text = "Ver"

        dgvAdjuntos.ContextMenuStrip = strip
        dgvAdjuntos.ContextMenuStrip.Items.Add(mnuAniadirAdjunto)
        dgvAdjuntos.ContextMenuStrip.Items.Add(mnuQuitarAdjunto)
        dgvAdjuntos.ContextMenuStrip.Items.Add(mnuVerAdjunto)

        strip = New ContextMenuStrip()
        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"

        txtOrdenId.ContextMenuStrip = strip
        txtOrdenId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            forzarBusqueda = False
            txtOrdenId.Enabled = False
            cmbEstado.Enabled = False

            Orden = New Orden(cliente)

            txtOrdenId.Text = Orden.OrdenId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOrden, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOrdenes", _
                                              Orden.OrdenId, "", "")
            genW.publicar(infDoc, Orden.Mensaje, True)
            genW.seleccionarItem(cmbEstado, "A")

            Try
                dtpFechaOrden.Focus()
                dtpFechaOrden.Value = Now.Date
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Orden " + Orden.OrdenId + " (Nueva Orden)"
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

            txtOrdenId.Enabled = False
            cmbEstado.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOrden, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOrdenes", _
                                              Orden.OrdenId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Orden " + Orden.OrdenId + " (Consulta)"
            dtpFechaOrden.Focus()
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
            If Modop <> SysEnums.Modos.mConsultar Then GoTo finalize

            msg.reset()

            cmdAceptar.Text = "Actualizar"
            Modop = SysEnums.Modos.mModificar

            Me.Text = "Orden " + Orden.OrdenId + " (Modificar)"
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

            txtOrdenId.Enabled = True
            txtLoteId.Enabled = True
            txtContrato.Enabled = True
            cmbEstado.Enabled = True
            dtpFechaOrden.Enabled = True
            txtOrigenId.Enabled = True

            cmbEstado.SelectedIndex = -1
            dtpFechaOrden.Value = New Date(1899, 1, 1)
            txtOrdenId.Text = ""
            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Orden (Buscar)"
            txtOrdenId.Focus()

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

    Public Function setHistorial(ByVal pOrdenId As String) As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesHistorial(Me).clonar()
            If msg.EsError Then GoTo finalize

            cmdAceptar.Enabled = True
            cmdCancelar.Enabled = True

            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mHistorial
            modificado = False

            Me.Text = "Orden " + pOrdenId + " (Historial)"
            cmdAceptar.Focus()
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo Historial: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function generarOrigenDatos() As Mensaje
        Dim itmCounter As Integer = 0
        Dim Adjuntos As List(Of AdjuntoOrden)

        Try
            msg.reset()

            Orden.liberarObjetos()

            Orden = New Orden(cliente, txtOrdenId.Text, txtContrato.Text, txtLoteId.Text, txtOrigenId.Text, "", _
                              txtToneladas.Text, txtTolerancia.Text, txtPeremb.Text, txtIncoterm.Text, _
                              txtRitmo.Text, txtMoneda.Text, txtRefftro.Text, txtBase.Text, txtFutuMes.Text, _
                              txtPrecioNeto.Text, txtObservaciones.Text, txtLaycan.Text, txtPtoCarga.Text, _
                              txtPtoDescarga.Text, txtNorCarga.Text, txtNorDescarga.Text, txtLayTime.Text, _
                              txtCondPago.Text, txtTasaDmora.Text, Usua.UsrId, Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                              Format(Now, "yyyy-MM-ddTHH:mm:dd"), cmbEstado.SelectedItem.ItemData.ToString, _
                              txtProvflId.Text, "", Format(dtpFechaOrden.Value, "yyyy-MM-ddTHH:mm:dd"), txtResponsable.Text, txtRitmod.Text)

            Adjuntos = New List(Of AdjuntoOrden)

            For itmCounter = 0 To dgvAdjuntos.RowCount - 1
                If Not dgvAdjuntos.Rows(itmCounter).Cells(1).Value Is Nothing Then
                    Dim adj As AdjuntoOrden = New AdjuntoOrden(txtOrdenId.Text, itmCounter, _
                                                               dgvAdjuntos.Rows(itmCounter).Cells(0).Value, _
                                                               dgvAdjuntos.Rows(itmCounter).Cells(1).Value, _
                                                               dgvAdjuntos.Rows(itmCounter).Cells(3).Value, _
                                                               dgvAdjuntos.Rows(itmCounter).Cells(2).Value)
                    Adjuntos.Add(adj)
                End If
            Next

            Orden.setAdjuntos(Adjuntos)
        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarOrden() As Mensaje
        Try
            msg.reset()

            txtOrdenId.Text = Orden.OrdenId
            dtpFechaOrden.Value = DateTime.Parse(Orden.Fchord)
            dtpFechaOrden.Refresh()
            dtpFechaOrden.Update()
            genW.seleccionarItem(cmbEstado, Orden.EstadoId)
            txtContrato.Text = Orden.CtrtoId
            txtLoteId.Text = Orden.LoteId
            txtOrigenId.Text = Orden.OrigenId
            txtOrigen.Text = Orden.Nmborigen
            txtToneladas.Text = Orden.Tnladas
            txtTolerancia.Text = Orden.Tlrancia
            txtPeremb.Text = Orden.Peremb
            txtIncoterm.Text = Orden.Incoterm
            txtMoneda.Text = Orden.Moneda
            txtRefftro.Text = Orden.Refftro
            txtBase.Text = Orden.Base
            txtFutuMes.Text = Orden.Mesfutu
            txtPrecioNeto.Text = Orden.Prcionto
            txtObservaciones.Text = Orden.Obsrv
            txtProvflId.Text = Orden.ProvId
            txtProveedorfl.Text = Orden.Nmbprvfl
            txtLaycan.Text = Orden.Laycan
            txtLayTime.Text = Orden.Laytime
            txtPtoCarga.Text = Orden.Ptocarga
            txtPtoDescarga.Text = Orden.Ptodscg
            txtRitmo.Text = Orden.Ritmo
            txtRitmod.Text = Orden.Ritmod
            txtNorCarga.Text = Orden.Norcg
            txtNorDescarga.Text = Orden.Nordscg
            txtCondPago.Text = Orden.Condpgo
            txtResponsable.Text = Orden.Rspnsble

            dgvAdjuntos.Rows.Clear()
            dgvAdjuntos.Rows.Add()

            For Each adjunto As AdjuntoOrden In Orden.AdjuntosOrden
                dgvAdjuntos.Rows.Add()

                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(0).Value = adjunto.ArchivoOrigen
                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(1).Value = adjunto.Ruta
                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(2).Value = adjunto.extnsion
                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(3).Value = adjunto.Coments
            Next

        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden: " + ex.Message)
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


            msg = Orden.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear la Orden: " + ex.Message)
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

            msg = Orden.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar la Orden: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim estado As String = ""

        Dim sLoteId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not cmbEstado.SelectedItem Is Nothing Then _
                estado = cmbEstado.SelectedItem.ItemData.ToString

            frmBusq = New frmBusqueda(cliente, genW, 5, 1, txtOrdenId.Text, estado, Format(dtpFechaOrden.Value, "yyyy-MM-dd"), _
                                      txtContrato.Text, txtLoteId.Text, txtOrigenId.Text)

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sLoteId = resultados(0)
                If sLoteId.Trim.Length.Equals(0) Then GoTo finalize

                Orden.liberarObjetos()

                Orden = New Orden(cliente, sLoteId)
                msg = Orden.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarOrden().EsError Then GoTo finalize

                setConsultar()
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

                txtOrigen.Focus()
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

    Private Function buscarOrigen(ByVal pBusqueda As Integer) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOrigenId As String = ""

        Try
            msg.reset()

            If pBusqueda = 1 Then
                frmBusq = New frmBusqueda(cliente, genW, 4, 1, txtOrigenId.Text, "", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 4, 1, "", txtOrigen.Text, "1", "", "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                sOrigenId = resultados(0)
                If sOrigenId.Trim.Length.Equals(0) Then GoTo finalize

                txtOrigenId.Text = resultados(0)
                txtOrigen.Text = resultados(1)

                txtToneladas.Focus()
            Else
                If pBusqueda = 1 Then
                    txtOrigenId.Text = ""
                Else
                    txtOrigen.Text = ""
                End If

                msg.setError("No se seleccionó un código de Origen correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Origen: " + ex.Message)
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
                frmBusq = New frmBusqueda(cliente, genW, 1, 1, txtProvflId.Text, "T003", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 1, 1, "", "T003", "1", txtProveedorfl.Text, "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                sProvId = resultados(0)
                If sProvId.Trim.Length.Equals(0) Then GoTo finalize

                txtProvflId.Text = resultados(0)
                txtProveedorfl.Text = resultados(1)

                txtLaycan.Focus()
            Else
                If pBusqueda = 1 Then
                    txtProvflId.Text = ""
                Else
                    txtProveedorfl.Text = ""
                End If

                msg.setError("No se seleccionó un código de Proveedor de flete correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Proveedor de flete: " + ex.Message)
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
                msg.setError("La Orden debe existir y no tener cambios sin guardar para poder ser cerrada.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual de la Orden no admite la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("La Orden " + txtOrdenId.Text + " ya ha sido cancelada y no es posible la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "C" Then
                msg.setPregunta("La Orden " + txtOrdenId.Text + " ya ha sido cerrada con anterioridad. ¿Desea abrir la Orden?")
                nuevoEstado = "A"
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "A" Then
                msg.setPregunta("La Orden " + txtOrdenId.Text + " se encuentra Abierta. ¿Desea cerrar la Orden?")
                nuevoEstado = "C"
            End If

            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, nuevoEstado)
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Orden.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then GoTo finalize

            msg.setInfo("Orden " + Orden.OrdenId + " " + cmbEstado.SelectedItem.Description.ToString + "(a) con éxito.")
            genW.publicar(infDoc, msg)

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar la Orden: " + ex.Message)
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
                msg.setError("La Orden debe existir y no tener cambios sin guardar para poder ser cancelada.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual de la Orden no admite la operación de Cancelación.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("La Orden " + txtOrdenId.Text + " ya ha sido cancelada con anterioridad.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            msg.setPregunta("Ha seleccionado la opción de cancelación de documento. Si da clic en Sí, el documento se cancelará y será necesario " _
                            + " abrir un nuevo documento si desea reemplazarlo. ¿Desea continuar cancelando el documento?")
            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, "L")
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Orden.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then
                Orden.liberarObjetos()

                Orden = New Orden(cliente, txtOrdenId.Text)
                msg = Orden.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarOrden().EsError Then GoTo finalize
            Else
                msg.setInfo("Orden " + Orden.OrdenId + " cancelada con éxito.")
                genW.publicar(infDoc, msg)
            End If

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar la Orden: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sOrdenId As String = ""

        Dim sPref As String = "O"
        Dim icDigit As Integer = 7

        Try
            forzarBusqueda = False

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not Orden Is Nothing Then
                Orden.liberarObjetos()
            End If

            sOrdenId = txtOrdenId.Text

            Orden = New Orden(cliente)
            If Orden.OrdenId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Orden para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sOrdenId.Trim.Length.Equals(0) Then
                        sOrdenId = Orden.ordenAnterior(Orden.OrdenId).ToString
                    Else
                        sOrdenId = Orden.ordenAnterior(sOrdenId).ToString
                    End If
                Case "3"
                    If sOrdenId.Trim.Length.Equals(0) Then
                        sOrdenId = Orden.ordenSiguiente(Orden.OrdenId).ToString
                    Else
                        sOrdenId = Orden.ordenSiguiente(sOrdenId).ToString
                    End If
                Case "1"
                    sOrdenId = Orden.ordenSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sOrdenId = sPref + (Integer.Parse(Orden.OrdenId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Orden.liberarObjetos()

            Orden = New Orden(cliente, sOrdenId)
            msg = Orden.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarOrden().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de la Orden: " + ex.Message)
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

            resultados = Orden.buscarCambios(txtOrdenId.Text)
            If resultados.Rows.Count = 0 Then
                msg.setInfo("Este documento no tiene cambios.")
                GoTo finalize
            End If

            frmHist = New frmHistorial(cliente, genW, Cnfg, Usua, _
                                       resultados, SysEnums.TiposDocumentos.dOrden, txtOrdenId.Text)
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
                If cmbEstado.SelectedItem.ItemData.Equals("C") Or _
                    cmbEstado.SelectedItem.ItemData.Equals("L") Then
                    msg.setError("La Orden ha sido " + cmbEstado.SelectedItem.Description + "(a) y no se puede modificar.")

                    GoTo finalize
                End If
            End If


            If txtContrato.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el contrato de compra de trigo.")
                txtContrato.Focus()
            ElseIf txtLoteId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el lote de origen de la orden.")
                txtLoteId.Focus()
            ElseIf txtOrigenId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el lugar de origen del trigo.")
                txtOrigenId.Focus()
            ElseIf txtToneladas.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el tonaleje esperado para la Orden.")
                txtToneladas.Focus()
            ElseIf txtBase.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Base.")
                txtBase.Focus()
            ElseIf txtFutuMes.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el valor Mes Futuro.")
                txtFutuMes.Focus()
            ElseIf txtPrecioNeto.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el precio neto de la Orden.")
                txtPrecioNeto.Focus()
            ElseIf Not Double.TryParse(txtToneladas.Text, 0) Then
                msg.setError("El valor del tonelaje no es válido.")
                txtToneladas.Focus()
            ElseIf Not Double.TryParse(txtBase.Text, 0) Then
                msg.setError("El valor de Base no es válido.")
                txtBase.Focus()
            ElseIf Not Double.TryParse(txtFutuMes.Text, 0) Then
                msg.setError("El valor de Futuro no es válido.")
                txtFutuMes.Focus()
            ElseIf Not Double.TryParse(txtPrecioNeto.Text, 0) Then
                msg.setError("El valor de Precio Neto no es válido.")
                txtPrecioNeto.Focus()
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function


    Public Function imprimir() As Mensaje
        Dim frmVisorInf As frmVisorInforme = Nothing
        Dim param As List(Of ParametroImpresion) = New List(Of ParametroImpresion)

        Try
            msg.reset()

            If Modop <> SysEnums.Modos.mConsultar Then
                msg.setAdvertencia("Para poder imprimir este documento se debe encontrar en modo Consulta.")

                GoTo finalize
            End If

            param.Add(New ParametroImpresion(0, "@ordenid", "", txtOrdenId.Text))

            frmVisorInf = New frmVisorInforme(cliente, genW, param, _
                                              Cnfg.CarpImp + "RvistaimpCtocmpvta.rpt", "Contrato de Compra-Venta " + txtOrdenId.Text)

            frmVisorInf.MdiParent = Me.MdiParent
            frmVisorInf.Show()

            msg = frmVisorInf.Mensaje
        Catch ex As Exception
            msg.setError("No fue posible imprimir el documento: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg)
        Return msg
    End Function
#End Region

    Private Sub frmOrdenes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub txtLoteId_Leave(sender As Object, e As EventArgs) Handles txtLoteId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtLoteId.Text.Trim.Length.Equals(0) Then _
            If buscarLote().EsError Then txtLoteId.Focus()
    End Sub


    Private Sub txtOrigenId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrigenId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarOrigen(1)
        End If
    End Sub

    Private Sub txtOrigenId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrigenId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtOrigenId_Leave(sender As Object, e As EventArgs) Handles txtOrigenId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtOrigenId.Text.Trim.Length.Equals(0) Then _
            If buscarOrigen(1).EsError Then txtOrigenId.Focus()
    End Sub

    Private Sub txtOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrigen.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarOrigen(2)
        End If
    End Sub

    Private Sub txtOrigen_Leave(sender As Object, e As EventArgs) Handles txtOrigen.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtOrigen.Text.Trim.Length.Equals(0) Then _
            If buscarOrigen(2).EsError Then txtOrigen.Focus()
    End Sub

    Private Sub txtProvflId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvflId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarProveedorFlete(1)
        End If
    End Sub

    Private Sub txtProvflId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProvflId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub


    Private Sub txtProveedorfl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedorfl.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarProveedorFlete(2)
        End If
    End Sub

    Private Sub txtProveedorfl_Leave(sender As Object, e As EventArgs) Handles txtProveedorfl.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtProveedorfl.Text.Trim.Length.Equals(0) Then _
            If buscarProveedorFlete(2).EsError Then txtProveedorfl.Focus()
    End Sub

    Private Sub txtOrdenId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrdenId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtOrdenId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrdenId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub dtpFechaOrden_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaOrden.ValueChanged
        setModificar()
    End Sub

    Private Sub txtContrato_TextChanged(sender As Object, e As EventArgs) Handles txtContrato.TextChanged
        setModificar()
    End Sub

    Private Sub txtLoteId_TextChanged(sender As Object, e As EventArgs) Handles txtLoteId.TextChanged
        setModificar()
    End Sub

    Private Sub txtOrigenId_TextChanged(sender As Object, e As EventArgs) Handles txtOrigenId.TextChanged
        setModificar()
    End Sub

    Private Sub txtOrigen_TextChanged(sender As Object, e As EventArgs) Handles txtOrigen.TextChanged
        setModificar()
    End Sub

    Private Sub txtToneladas_TextChanged(sender As Object, e As EventArgs) Handles txtToneladas.TextChanged
        setModificar()
    End Sub

    Private Sub txtTolerancia_TextChanged(sender As Object, e As EventArgs) Handles txtTolerancia.TextChanged
        setModificar()
    End Sub

    Private Sub txtPeremb_TextChanged(sender As Object, e As EventArgs) Handles txtPeremb.TextChanged
        setModificar()
    End Sub

    Private Sub txtIncoterm_TextChanged(sender As Object, e As EventArgs) Handles txtIncoterm.TextChanged
        setModificar()
    End Sub

    Private Sub txtRitmo_TextChanged(sender As Object, e As EventArgs)
        setModificar()
    End Sub

    Private Sub txtMoneda_TextChanged(sender As Object, e As EventArgs) Handles txtMoneda.TextChanged
        setModificar()
    End Sub

    Private Sub txtRefftro_TextChanged(sender As Object, e As EventArgs) Handles txtRefftro.TextChanged
        setModificar()
    End Sub

    Private Sub txtBase_TextChanged(sender As Object, e As EventArgs) Handles txtBase.TextChanged
        setModificar()
    End Sub

    Private Sub txtFutuMes_TextChanged(sender As Object, e As EventArgs) Handles txtFutuMes.TextChanged
        setModificar()
    End Sub

    Private Sub txtPrecioNeto_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioNeto.TextChanged
        setModificar()
    End Sub

    Private Sub txtObservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged
        setModificar()
    End Sub

    Private Sub txtResponsable_TextChanged(sender As Object, e As EventArgs) Handles txtResponsable.TextChanged
        setModificar()
    End Sub

    Private Sub txtProvflId_Leave(sender As Object, e As EventArgs) Handles txtProvflId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtProvflId.Text.Trim.Length.Equals(0) Then _
            If buscarProveedorFlete(1).EsError Then txtProvflId.Focus()
    End Sub

    Private Sub txtProvflId_TextChanged(sender As Object, e As EventArgs) Handles txtProvflId.TextChanged
        setModificar()
    End Sub

    Private Sub txtProveedorfl_TextChanged(sender As Object, e As EventArgs) Handles txtProveedorfl.TextChanged
        setModificar()
    End Sub

    Private Sub txtLaycan_TextChanged(sender As Object, e As EventArgs) Handles txtLaycan.TextChanged
        setModificar()
    End Sub

    Private Sub txtLayTime_TextChanged(sender As Object, e As EventArgs) Handles txtLayTime.TextChanged
        setModificar()
    End Sub

    Private Sub txtPtoCarga_TextChanged(sender As Object, e As EventArgs) Handles txtPtoCarga.TextChanged
        setModificar()
    End Sub

    Private Sub txtPtoDescarga_TextChanged(sender As Object, e As EventArgs) Handles txtPtoDescarga.TextChanged
        setModificar()
    End Sub

    Private Sub txtNorCarga_TextChanged(sender As Object, e As EventArgs) Handles txtNorCarga.TextChanged
        setModificar()
    End Sub

    Private Sub txtNorDescarga_TextChanged(sender As Object, e As EventArgs) Handles txtNorDescarga.TextChanged
        setModificar()
    End Sub

    Private Sub txtCondPago_TextChanged(sender As Object, e As EventArgs) Handles txtCondPago.TextChanged
        setModificar()
    End Sub

    Private Sub txtTasaDmora_TextChanged(sender As Object, e As EventArgs) Handles txtTasaDmora.TextChanged
        setModificar()
    End Sub

    Private Sub cmdProvfl_Click(sender As Object, e As EventArgs) Handles cmdProvfl.Click
        Dim frmProv As frmProveedor = Nothing

        frmProv = New frmProveedor(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtProvflId.Text)
        frmProv.MdiParent = Me.MdiParent
        frmProv.Show()
    End Sub

    Private Sub cmdLote_Click(sender As Object, e As EventArgs) Handles cmdLote.Click
        Dim frmLote As frmLote = Nothing

        frmLote = New frmLote(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua, txtLoteId.Text)
        frmLote.MdiParent = Me.MdiParent
        frmLote.Show()
    End Sub

    Private Sub cmdOrig_Click(sender As Object, e As EventArgs) Handles cmdOrig.Click
        Dim frmOri As frmOrigen = Nothing

        frmOri = New frmOrigen(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtOrigenId.Text)
        frmOri.MdiParent = Me.MdiParent
        frmOri.Show()
    End Sub

    Private Sub txtRitmod_TextChanged(sender As Object, e As EventArgs) Handles txtRitmod.TextChanged
        setModificar()
    End Sub

    Private Sub dgvAdjuntos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvAdjuntos.CellBeginEdit
        If e.RowIndex = dgvAdjuntos.RowCount - 1 Then e.Cancel = True
    End Sub

    Private Sub dgvAdjuntos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdjuntos.CellEndEdit
        setModificar()
    End Sub

    Private Sub dgvAdjuntos_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdjuntos.CellMouseEnter
        ubicMouse = e
    End Sub

    Private Sub mnuAniadirAdjunto_Click(ByVal sender As Object, ByVal args As EventArgs) Handles mnuAniadirAdjunto.Click
        Dim arch As String = ""

        Try
            If Cnfg.Carpanx.Trim.Length.Equals(0) Then Throw New Exception("No se ha definido carpeta de archivos adjuntos.")

            arch = genW.obtenerArchivo("")
            If Not arch.Length.Equals(0) Then
                dgvAdjuntos.Rows.Add()
                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(0).Value = arch
                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(1).Value = Cnfg.Carpanx + Path.GetFileName(arch)
                dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(2).Value = Path.GetExtension(arch)

                Dim celda As DataGridViewCell = dgvAdjuntos.Rows(dgvAdjuntos.RowCount - 2).Cells(3)
                dgvAdjuntos.CurrentCell = celda

                setModificar()
                dgvAdjuntos.BeginEdit(True)
            End If
        Catch ex As Exception
            msg.setError("No fue posible añadir el archivo adjunto: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub mnuQuitarAdjunto_Click(ByVal sender As Object, ByVal args As EventArgs) Handles mnuQuitarAdjunto.Click
        Dim arch As String = ""

        Try
            If ubicMouse.RowIndex >= 0 And ubicMouse.RowIndex < dgvAdjuntos.RowCount - 1 Then
                dgvAdjuntos.Rows.RemoveAt(ubicMouse.RowIndex)

                setModificar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible quitar el archivo adjunto: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub mnuVerAdjunto_Click(ByVal sender As Object, ByVal args As EventArgs) Handles mnuVerAdjunto.Click
        Dim arch As String = ""

        Try
            If ubicMouse.RowIndex >= 0 And ubicMouse.RowIndex < dgvAdjuntos.RowCount - 1 Then
                If File.Exists(dgvAdjuntos.Rows(ubicMouse.RowIndex).Cells(1).Value.ToString) Then
                    Process.Start(dgvAdjuntos.Rows(ubicMouse.RowIndex).Cells(1).Value)
                Else
                    msg.setError("El archivo que desea ver aun no ha sido guardado o fue movido del repositorio de manera manual.")
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible quitar el archivo adjunto: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub frmOrden_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim eshistorial As Boolean = False

        If Not Orden Is Nothing Then
            If Not Orden.Fchord.Length.Equals(0) Then
                If Modop = SysEnums.Modos.mHistorial Then eshistorial = True
                dtpFechaOrden.Value = DateTime.Parse(Orden.Fchord).AddSeconds(1)

                If eshistorial Then
                    setHistorial(sOrdenInst)
                Else
                    setConsultar()
                End If
            End If
        End If
    End Sub

    Private Sub frmOrden_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtOrdenId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtOrdenId.Text)
    End Sub
End Class

