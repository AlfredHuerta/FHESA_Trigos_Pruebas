Imports Genericas
Imports ObjEntidades

Public Class frmAjuste
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

    Private Ajuste As Ajuste
    Private sAjustInst As String
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
           ByVal pUsuario As Usuario, _
           Optional ByVal pAjustId As String = "", _
           Optional ByVal pAjuste As Ajuste = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try
            If inicializarControles().EsError Then GoTo finalize
            If pAjustId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dAjuste, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sAjustes", "", "", "")

            Cnfg = pConfiguracion
            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(30)

            If pModo = SysEnums.Modos.mCrear And Not atmPerf.Creacion And atmPerf.Consulta Then
                Ajuste = New Ajuste(pCliente)
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
                    Ajuste = New Ajuste(cliente, pAjustId)
                    msg = Ajuste.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarAjuste().EsError Then GoTo finalize

                    setConsultar()
                Case SysEnums.Modos.mHistorial
                    Ajuste = pAjuste

                    If cargarAjuste().EsError Then GoTo finalize

                    sAjustInst = pAjustId
                    setHistorial(pAjustId)
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
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dAjuste, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtAjustId.ContextMenuStrip = strip
        txtAjustId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()



            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            forzarBusqueda = False
            txtAjustId.Enabled = False
            cmbEstado.Enabled = False

            Ajuste = New Ajuste(cliente)

            txtAjustId.Text = Ajuste.AjustId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dAjuste, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sAjustes", _
                                              Ajuste.AjustId, "", "")

            genW.seleccionarItem(cmbEstado, "A")

            Try
                dtpFechaAjuste.Focus()
                dtpFechaAjuste.Value = Now.Date
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Ajuste " + Ajuste.AjustId + " (Nuevo Ajuste)"
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

            txtAjustId.Enabled = False
            cmbEstado.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dAjuste, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sAjustes", _
                                              Ajuste.AjustId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Ajuste " + Ajuste.AjustId + " (Consulta)"
            dtpFechaAjuste.Focus()
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

            Me.Text = "Ajuste " + Ajuste.AjustId + " (Modificar)"
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


            txtAjustId.Enabled = True
            txtOrdenId.Enabled = True
            cmbEstado.Enabled = True
            dtpFechaAjuste.Enabled = True

            cmbEstado.SelectedIndex = -1
            dtpFechaAjuste.Value = New Date(1899, 1, 1)
            txtAjustId.Text = ""
            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Venta (Buscar)"
            txtAjustId.Focus()

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

    Public Function setHistorial(ByVal pAjustId As String) As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesHistorial(Me).clonar()
            If msg.EsError Then GoTo finalize

            cmdAceptar.Enabled = True
            cmdCancelar.Enabled = True

            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mHistorial
            modificado = False

            Me.Text = "Ajuste " + pAjustId + " (Historial)"
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

            Ajuste.liberarObjetos()

            Ajuste = New Ajuste(cliente, txtAjustId.Text, txtOrdenId.Text, Format(dtpFechaAjuste.Value, "yyyy-MM-ddTHH:mm:dd"), _
                                txtCompensa.Text, txtMerma1.Text, txtMerma2.Text, txtMerma3.Text, txtObsrv.Text, _
                                Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, _
                                cmbEstado.SelectedItem.ItemData.ToString)

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarAjuste() As Mensaje
        Try
            msg.reset()

            txtAjustId.Text = Ajuste.AjustId
            dtpFechaAjuste.Value = DateTime.Parse(Ajuste.Fchajus)
            genW.seleccionarItem(cmbEstado, Ajuste.EstadoId)
            txtOrdenId.Text = Ajuste.OrdenId
            txtCompensa.Text = Ajuste.Compensa
            txtMerma1.Text = Ajuste.Merma1
            txtMerma2.Text = Ajuste.Merma2
            txtMerma3.Text = Ajuste.Merma3
            txtObsrv.Text = Ajuste.Obsrv

        Catch ex As Exception
            msg.setError("No fue posible cargar el Ajuste: " + ex.Message)
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

            msg = Ajuste.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el Ajuste: " + ex.Message)
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

            msg = Ajuste.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el Ajuste: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim estado As String = ""

        Dim sAjustId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not cmbEstado.SelectedItem Is Nothing Then _
                estado = cmbEstado.SelectedItem.ItemData.ToString

            frmBusq = New frmBusqueda(cliente, genW, 9, 1, txtAjustId.Text, estado, _
                                      Format(dtpFechaAjuste.Value, "yyyy-MM-dd"), txtOrdenId.Text, "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sAjustId = resultados(0)
                If sAjustId.Trim.Length.Equals(0) Then GoTo finalize

                Ajuste.liberarObjetos()

                Ajuste = New Ajuste(cliente, sAjustId)
                msg = Ajuste.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarAjuste().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Ajuste: " + ex.Message)
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

                txtCompensa.Focus()
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

            If Modop <> SysEnums.Modos.mConsultar Then
                msg.setError("El Ajuste debe existir y no tener cambios sin guardar para poder ser cerrado.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not atmPerf.Cierre Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual del Ajuste no admite la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("El Ajuste " + txtAjustId.Text + " ya ha sido cancelado y no es posible la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "C" Then
                msg.setPregunta("El Ajuste " + txtAjustId.Text + " ya ha sido cerrado con anterioridad. ¿Desea abrir el Ajuste?")
                nuevoEstado = "A"

            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "A" Then
                msg.setPregunta("El Ajuste " + txtAjustId.Text + " se encuentra Abierto. ¿Desea cerrar el Ajuste?")
                nuevoEstado = "C"
            End If

            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, nuevoEstado)
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Ajuste.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then GoTo finalize

            msg.setInfo("Ajuste " + Ajuste.AjustId + " " + cmbEstado.SelectedItem.Description.ToString + " con éxito.")
            genW.publicar(infDoc, msg)

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar el Ajuste: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function cancelar() As Mensaje
        Try
            msg.reset()

            forzarBusqueda = False

            If Modop <> SysEnums.Modos.mConsultar Then
                msg.setError("El Ajuste debe existir y no tener cambios sin guardar para poder ser cancelado.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not atmPerf.Cnlacion Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos(True).EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual del Ajuste no admite la operación de Cancelación.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("El Ajuste " + txtAjustId.Text + " ya ha sido cancelado con anterioridad.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            msg.setPregunta("Ha seleccionado la opción de cancelación de documento. Si da clic en Sí, el documento se cancelará y será necesario " _
                            + " abrir un nuevo documento si desea reemplazarlo. ¿Desea continuar cancelando el documento?")
            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, "L")
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = Ajuste.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then
                Ajuste.liberarObjetos()

                Ajuste = New Ajuste(cliente, txtAjustId.Text)
                msg = Ajuste.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarAjuste().EsError Then GoTo finalize
            Else
                msg.setInfo("Ajuste " + Ajuste.AjustId + " cancelado con éxito.")
                genW.publicar(infDoc, msg)
            End If

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar el Ajuste: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sAjustId As String = ""

        Dim sPref As String = "A"
        Dim icDigit As Integer = 7

        Try
            forzarBusqueda = False

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Ajuste Is Nothing Then
                Ajuste.liberarObjetos()
            End If

            sAjustId = txtAjustId.Text

            Ajuste = New Ajuste(cliente)
            If Ajuste.AjustId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Venta para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sAjustId.Trim.Length.Equals(0) Then
                        sAjustId = Ajuste.ajusteAnterior(Ajuste.AjustId).ToString
                    Else
                        sAjustId = Ajuste.ajusteAnterior(sAjustId).ToString
                    End If
                Case "3"
                    If sAjustId.Trim.Length.Equals(0) Then
                        sAjustId = Ajuste.ajusteSiguiente(Ajuste.AjustId).ToString
                    Else
                        sAjustId = Ajuste.ajusteSiguiente(sAjustId).ToString
                    End If
                Case "1"
                    sAjustId = Ajuste.ajusteSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sAjustId = sPref + (Integer.Parse(Ajuste.AjustId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Ajuste.liberarObjetos()

            Ajuste = New Ajuste(cliente, sAjustId)
            msg = Ajuste.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarAjuste().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Ajuste: " + ex.Message)
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

            resultados = Ajuste.buscarCambios(txtAjustId.Text)
            If resultados.Rows.Count = 0 Then
                msg.setInfo("Este documento no tiene cambios.")
                GoTo finalize
            End If

            frmHist = New frmHistorial(cliente, genW, Cnfg, Usua, _
                                       resultados, SysEnums.TiposDocumentos.dAjuste, txtAjustId.Text)
            frmHist.MdiParent = Me.MdiParent
            frmHist.Show()
        Catch ex As Exception
            msg.setError("No fue posible buscar el historial del Ajuste: " + ex.Message)
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
                    msg.setError("El Ajuste ha sido " + cmbEstado.SelectedItem.Description + " y no se puede modificar.")

                    GoTo finalize
                End If
            End If

            If txtOrdenId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Orden origen del ajuste.")
                txtAjustId.Focus()
            End If

            If txtCompensa.Text.Trim.Length.Equals(0) Then _
                txtCompensa.Text = "0"

            If txtMerma1.Text.Trim.Length.Equals(0) Then _
                txtMerma1.Text = "0"

            If txtMerma2.Text.Trim.Length.Equals(0) Then _
                txtMerma2.Text = "0"

            If txtMerma3.Text.Trim.Length.Equals(0) Then _
                txtMerma3.Text = "0"

            If Not Double.TryParse(txtCompensa.Text, 0) Then
                msg.setError("El valor de Compensación no es válido.")
                txtCompensa.Focus()
            ElseIf Not Double.TryParse(txtMerma1.Text, 0) Then
                msg.setError("El valor de Merma 1 no es válido.")
                txtMerma1.Focus()
            ElseIf Not Double.TryParse(txtMerma2.Text, 0) Then
                msg.setError("El valor de Merma 2 no es válido.")
                txtMerma2.Focus()
            ElseIf Not Double.TryParse(txtMerma3.Text, 0) Then
                msg.setError("El valor de Merma 3 no es válido.")
                txtMerma3.Focus()
            ElseIf Double.Parse(txtCompensa.Text) = 0 And Double.Parse(txtMerma1.Text) = 0 _
                And Double.Parse(txtMerma2.Text) = 0 And Double.Parse(txtMerma3.Text) = 0 Then
                msg.setError("Se debe definir al menos un valor de ajuste.")
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

            param.Add(New ParametroImpresion(0, "@doc", "", "8"))
            param.Add(New ParametroImpresion(0, "@instid", "", ""))
            param.Add(New ParametroImpresion(0, "@docid", "", txtAjustId.Text))

            frmVisorInf = New frmVisorInforme(cliente, genW, param, _
                                              Cnfg.CarpImp + "RvistaimpAjustes.rpt", "Vista Previa Ajute " + txtAjustId.Text)

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

    Private Sub frmAjuste_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub txtOrdenId_TextChanged(sender As Object, e As EventArgs) Handles txtOrdenId.TextChanged
        setModificar()
    End Sub

    Private Sub txtCompensa_TextChanged(sender As Object, e As EventArgs) Handles txtCompensa.TextChanged
        setModificar()
    End Sub

    Private Sub txtMerma1_TextChanged(sender As Object, e As EventArgs) Handles txtMerma1.TextChanged
        setModificar()
    End Sub

    Private Sub txtMerma2_TextChanged(sender As Object, e As EventArgs) Handles txtMerma2.TextChanged
        setModificar()
    End Sub

    Private Sub txtMerma3_TextChanged(sender As Object, e As EventArgs) Handles txtMerma3.TextChanged
        setModificar()
    End Sub

    Private Sub txtObsrv_TextChanged(sender As Object, e As EventArgs) Handles txtObsrv.TextChanged
        setModificar()
    End Sub

    Private Sub txtAjustId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAjustId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtAjustId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAjustId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub frmAjuste_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim eshistorial As Boolean = False

        If Not Ajuste Is Nothing Then
            If Not Ajuste.Fchajus.Length.Equals(0) Then
                If Modop = SysEnums.Modos.mHistorial Then eshistorial = True
                dtpFechaAjuste.Value = Date.Parse(Ajuste.Fchajus).AddSeconds(1)

                If eshistorial Then
                    setHistorial(sAjustInst)
                Else
                    setConsultar()
                End If
            End If
        End If
    End Sub

    Private Sub frmAjuste_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtAjustId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtAjustId.Text)
    End Sub
End Class