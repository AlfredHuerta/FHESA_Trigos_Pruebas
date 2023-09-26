Imports Genericas
Imports ObjEntidades

Public Class frmVenta
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

    Private Venta As Venta
    Private sVentaInst As String

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
       ByVal pUsuario As Usuario, Optional ByVal pVentaId As String = "", _
       Optional ByVal pVenta As Venta = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try
            If inicializarControles().EsError Then GoTo finalize
            If pVentaId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear
            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dVenta, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sVentas", "", "", "")

            Cnfg = pConfiguracion
            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(31)

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
                    Venta = New Venta(cliente, pVentaId)
                    msg = Venta.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarVenta().EsError Then GoTo finalize

                    setConsultar()
                Case SysEnums.Modos.mHistorial
                    Venta = pVenta

                    If cargarVenta().EsError Then GoTo finalize

                    sVentaInst = pVentaId
                    setHistorial(pVentaId)
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
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dVenta, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtVentaId.ContextMenuStrip = strip
        txtVentaId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            forzarBusqueda = False
            txtVentaId.Enabled = False
            cmbEstado.Enabled = False

            Venta = New Venta(cliente)

            txtVentaId.Text = Venta.VentaId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dVenta, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sVentas", _
                                              Venta.VentaId, "", "")

            genW.seleccionarItem(cmbEstado, "A")

            Try
                dtpFechaVenta.Focus()
                dtpFechaVenta.Value = Now.Date
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Venta " + Venta.VentaId + " (Nueva Venta)"
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

            txtVentaId.Enabled = False
            cmbEstado.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dVenta, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sVenta", _
                                              Venta.VentaId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Venta " + Venta.VentaId + " (Consulta)"
            dtpFechaVenta.Focus()
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

            Me.Text = "Venta " + Venta.VentaId + " (Modificar)"
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


            txtVentaId.Enabled = True
            txtOrdenId.Enabled = True
            cmbEstado.Enabled = True
            dtpFechaVenta.Enabled = True

            cmbEstado.SelectedIndex = -1
            dtpFechaVenta.Value = New Date(1899, 1, 1)
            txtVentaId.Text = ""
            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Venta (Buscar)"
            txtVentaId.Focus()

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

    Public Function setHistorial(ByVal pVentaId As String) As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesHistorial(Me).clonar()
            If msg.EsError Then GoTo finalize

            cmdAceptar.Enabled = True
            cmdCancelar.Enabled = True

            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mHistorial
            modificado = False

            Me.Text = "Venta " + pVentaId + " (Historial)"
            cmdAceptar.Focus()
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo Historial: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function generarOrigenDatos() As Mensaje
        Try
            msg.reset()

            Venta.liberarObjetos()

            Venta = New Venta(cliente, txtVentaId.Text, txtVenta.Text, txtOrdenId.Text, Format(dtpFechaVenta.Value, "yyyy-MM-ddTHH:mm:dd"), _
                                cmbEstado.SelectedItem.ItemData.ToString, txtObsrv.Text, _
                                Format(Now, "yyyy-MM-ddTHH:mm:dd"), Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, Usua.UsrId)

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarVenta() As Mensaje
        Try
            msg.reset()

            txtVentaId.Text = Venta.VentaId
            dtpFechaVenta.Value = Date.Parse(Venta.Fchventa)
            genW.seleccionarItem(cmbEstado, Venta.EstadoId)
            txtOrdenId.Text = Venta.OrdenId
            txtVenta.Text = Venta.Tonventa
            txtObsrv.Text = Venta.Obsrv

        Catch ex As Exception
            msg.setError("No fue posible cargar la Venta: " + ex.Message)
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

            msg = Venta.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear la Venta: " + ex.Message)
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

            msg = Venta.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar la Venta: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim estado As String = ""

        Dim sVentaId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not cmbEstado.SelectedItem Is Nothing Then _
                estado = cmbEstado.SelectedItem.ItemData.ToString

            frmBusq = New frmBusqueda(cliente, genW, 10, 1, txtVentaId.Text, estado, _
                                      Format(dtpFechaVenta.Value, "yyyy-MM-dd"), txtOrdenId.Text, "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sVentaId = resultados(0)
                If sVentaId.Trim.Length.Equals(0) Then GoTo finalize

                Venta.liberarObjetos()

                Venta = New Venta(cliente, sVentaId)
                msg = Venta.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarVenta().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar la Venta: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarOrden() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOrdenId As String = ""

        Try
            msg.reset()


            frmBusq = New frmBusqueda(cliente, genW, 5, 1, txtOrdenId.Text, "A", "1899-12-31", _
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

                txtVenta.Focus()
            Else
                txtOrdenId.Text = ""

                msg.setError("No se seleccionó un código de Orden correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar la Orden: " + ex.Message)
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
                msg.setError("La Venta debe existir y no tener cambios sin guardar para poder ser cerrada.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual de la Venta no admite la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("La Venta " + txtVentaId.Text + " ya ha sido cancelada y no es posible la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "C" Then
                msg.setPregunta("La Venta " + txtVentaId.Text + " ya ha sido cerrada con anterioridad. ¿Desea abrir la Venta?")
                nuevoEstado = "A"
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "A" Then
                msg.setPregunta("La Venta " + txtVentaId.Text + " se encuentra Abierta. ¿Desea cerrar la Venta?")
                nuevoEstado = "C"
            End If

            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, nuevoEstado)
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Venta.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then GoTo finalize

            msg.setInfo("Venta " + Venta.VentaId + " " + cmbEstado.SelectedItem.Description.ToString + " con éxito.")
            genW.publicar(infDoc, msg)

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar la Venta: " + ex.Message)
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
                msg.setError("La Venta debe existir y no tener cambios sin guardar para poder ser cancelada.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual de la Venta no admite la operación de Cancelación.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("La Venta " + txtVentaId.Text + " ya ha sido cancelada con anterioridad.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            msg.setPregunta("Ha seleccionado la opción de cancelación de documento. Si da clic en Sí, el documento se cancelará y será necesario " _
                            + " abrir un nuevo documento si desea reemplazarlo. ¿Desea continuar cancelando el documento?")
            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, "L")
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Venta.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then
                Venta.liberarObjetos()

                Venta = New Venta(cliente, txtVentaId.Text)
                msg = Venta.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarVenta().EsError Then GoTo finalize
            Else
                msg.setInfo("Venta " + Venta.VentaId + " cancelada con éxito.")
                genW.publicar(infDoc, msg)
            End If

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cancelar la Venta: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sVentaId As String = ""

        Dim sPref As String = "V"
        Dim icDigit As Integer = 7

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            forzarBusqueda = False

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Venta Is Nothing Then
                Venta.liberarObjetos()
            End If

            sVentaId = txtVentaId.Text

            Venta = New Venta(cliente)
            If Venta.VentaId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Venta para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sVentaId.Trim.Length.Equals(0) Then
                        sVentaId = Venta.ventaAnterior(Venta.VentaId).ToString
                    Else
                        sVentaId = Venta.ventaAnterior(sVentaId).ToString
                    End If
                Case "3"
                    If sVentaId.Trim.Length.Equals(0) Then
                        sVentaId = Venta.ventaSiguiente(Venta.VentaId).ToString
                    Else
                        sVentaId = Venta.ventaSiguiente(sVentaId).ToString
                    End If
                Case "1"
                    sVentaId = Venta.ventaSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sVentaId = sPref + (Integer.Parse(Venta.VentaId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Venta.liberarObjetos()

            Venta = New Venta(cliente, sVentaId)
            msg = Venta.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarVenta().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Venta: " + ex.Message)
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

            resultados = Venta.buscarCambios(txtVentaId.Text)
            If resultados.Rows.Count = 0 Then
                msg.setInfo("Este documento no tiene cambios.")
                GoTo finalize
            End If

            frmHist = New frmHistorial(cliente, genW, Cnfg, Usua, _
                                       resultados, SysEnums.TiposDocumentos.dVenta, txtVentaId.Text)
            frmHist.MdiParent = Me.MdiParent
            frmHist.Show()
        Catch ex As Exception
            msg.setError("No fue posible buscar el historial de la Venta: " + ex.Message)
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
                    msg.setError("La Venta ha sido " + cmbEstado.SelectedItem.Description + "(a) y no se puede modificar.")

                    GoTo finalize
                End If
            End If

            If txtOrdenId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Orden origen del ajuste.")
                txtVentaId.Focus()
            End If

            If txtVenta.Text.Trim.Length.Equals(0) Then _
                txtVenta.Text = "0"


            If Not Double.TryParse(txtVenta.Text, 0) Then
                msg.setError("El valor de Venta no es válido.")
                txtVenta.Focus()
            ElseIf Double.Parse(txtVenta.Text) = 0 Then
                msg.setError("Se debe definir un valor de venta.")
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try


finalize:
        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function
#End Region


    Private Sub frmVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub txtOrdenId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrdenId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarOrden()
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
            If buscarOrden().EsError Then txtOrdenId.Focus()
    End Sub

    Private Sub cmdOrden_Click(sender As Object, e As EventArgs) Handles cmdOrden.Click
        Dim frmord As frmOrden = Nothing

        frmord = New frmOrden(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua, txtOrdenId.Text)
        frmord.MdiParent = Me.MdiParent
        frmord.Show()
    End Sub

    Private Sub txtVentaId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentaId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtVentaId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentaId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub dtpFechaVenta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaVenta.ValueChanged
        setModificar()
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub txtOrdenId_TextChanged(sender As Object, e As EventArgs) Handles txtOrdenId.TextChanged
        setModificar()
    End Sub

    Private Sub txtVenta_TextChanged(sender As Object, e As EventArgs) Handles txtVenta.TextChanged
        setModificar()
    End Sub

    Private Sub txtObsrv_TextChanged(sender As Object, e As EventArgs) Handles txtObsrv.TextChanged
        setModificar()
    End Sub

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim eshistorial As Boolean = False

        If Not Venta Is Nothing Then
            If Not Venta.Fchventa.Length.Equals(0) Then
                If Modop = SysEnums.Modos.mHistorial Then eshistorial = True
                dtpFechaVenta.Value = Date.Parse(Venta.Fchventa).AddSeconds(1)

                If eshistorial Then
                    setHistorial(sVentaInst)
                Else
                    setConsultar()
                End If
            End If
        End If
    End Sub


    Private Sub frmVenta_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtVentaId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtVentaId.Text)
    End Sub
End Class