Imports Genericas
Imports ObjEntidades

Public Class frmLote
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

    Private lote As Lote
    Private sLoteInst As String

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


#Region "métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pgenW As GenericasWin, _
               ByVal pModo As SysEnums.Modos, ByVal pConfiguracion As Configuracion, _
               ByVal pUsuario As Usuario, Optional ByVal pLoteId As String = "", _
               Optional ByVal pLote As Lote = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try
            If inicializarControles().EsError Then GoTo finalize
            If pLoteId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dLote, cliente.ParametrosConexion.BaseDeDatos, _
                                  "sLotes", "", "", "")

            Cnfg = pConfiguracion
            Usua = pUsuario

            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(47)

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

                    lote = New Lote(cliente, pLoteId)
                    msg = lote.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarLote().EsError Then GoTo finalize

                    setConsultar()
                Case SysEnums.Modos.mHistorial
                    lote = pLote

                    If cargarLote().EsError Then GoTo finalize

                    sLoteInst = pLoteId
                    setHistorial(pLoteId)
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
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dLote, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtLoteId.ContextMenuStrip = strip
        txtLoteId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            forzarBusqueda = False
            txtLoteId.Enabled = False
            cmbEstado.Enabled = False

            lote = New Lote(cliente)

            txtLoteId.Text = lote.LoteId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dLote, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sLotes", _
                                              lote.LoteId, "", "")

            genW.seleccionarItem(cmbEstado, "A")

            Try
                dtpFechaLote.Focus()
                dtpFechaLote.Value = Now.Date
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Lote " + lote.LoteId + " (Nuevo lote)"
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

            txtLoteId.Enabled = False
            cmbEstado.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dLote, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sLotes", _
                                              lote.LoteId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Lote " + lote.LoteId + " (Consulta)"
            dtpFechaLote.Focus()
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

            Me.Text = "Lote " + lote.LoteId + " (Modificar)"
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


            txtLoteId.Enabled = True
            txtProvId.Enabled = True
            txtTrigoId.Enabled = True
            cmbEstado.Enabled = True
            dtpFechaLote.Enabled = True

            cmbEstado.SelectedIndex = -1
            dtpFechaLote.Value = New Date(1899, 1, 1)
            txtLoteId.Text = ""
            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Lote (Buscar)"
            txtLoteId.Focus()

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

    Public Function setHistorial(ByVal pLoteId As String) As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesHistorial(Me).clonar()
            If msg.EsError Then GoTo finalize

            cmdAceptar.Enabled = True
            cmdCancelar.Enabled = True

            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mHistorial
            modificado = False

            Me.Text = "Lote " + pLoteId + " (Historial)"
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

            lote.liberarObjetos()

            lote = New Lote(cliente, txtLoteId.Text, txtProvId.Text, "", txtTrigoId.Text, "", _
                            txtProteina.Text, txtGrado.Text, txtHumedad.Text, txtPesohtl.Text, _
                            txtImpureza.Text, txtDockage.Text, txtVomitoxina.Text, txtErgot.Text, _
                            txtfllnnum.Text, txtObservaciones.Text, Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                            Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, cmbEstado.SelectedItem.ItemData.ToString, _
                            Format(dtpFechaLote.Value, "yyyy-MM-ddTHH:mm:dd"), txtOtros.Text)

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarLote() As Mensaje
        Try
            msg.reset()

            txtLoteId.Text = lote.LoteId
            dtpFechaLote.Value = DateTime.Parse(lote.Fchlote)
            genW.seleccionarItem(cmbEstado, lote.EstadoId)
            txtProvId.Text = lote.ProvId
            txtProveedor.Text = lote.Proveedor
            txtTrigoId.Text = lote.TrigoId
            txtTrigo.Text = lote.Trigo
            txtProteina.Text = lote.Proteina
            txtGrado.Text = lote.Grado
            txtHumedad.Text = lote.Humedad
            txtPesohtl.Text = lote.Pesohtl
            txtImpureza.Text = lote.Impureza
            txtDockage.Text = lote.Dockage
            txtVomitoxina.Text = lote.Vomitoxn
            txtErgot.Text = lote.Ergot
            txtfllnnum.Text = lote.Fllngnum
            txtObservaciones.Text = lote.Obsrv
            txtOtros.Text = lote.Otros

        Catch ex As Exception
            msg.setError("No fue posible cargar el Lote: " + ex.Message)
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

            If validarDatos().EsError Then GoTo finalize
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = lote.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el Lote: " + ex.Message)
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

            If validarDatos().EsError Then GoTo finalize
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = lote.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el Lote: " + ex.Message)
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

            frmBusq = New frmBusqueda(cliente, genW, 3, 1, txtLoteId.Text, estado, txtProvId.Text, _
                                      txtTrigoId.Text, Format(dtpFechaLote.Value, "yyyy-MM-dd"), "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sLoteId = resultados(0)
                If sLoteId.Trim.Length.Equals(0) Then GoTo finalize

                lote.liberarObjetos()

                lote = New Lote(cliente, sLoteId)
                msg = lote.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarLote().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Lote: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarProveedor(ByVal pBusqueda As Integer) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sProvId As String = ""

        Try
            msg.reset()

            If pBusqueda = 1 Then
                frmBusq = New frmBusqueda(cliente, genW, 1, 1, txtProvId.Text, "T001", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 1, 1, "", "T001", "1", txtProveedor.Text, "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                sProvId = resultados(0)
                If sProvId.Trim.Length.Equals(0) Then GoTo finalize

                txtProvId.Text = resultados(0)
                txtProveedor.Text = resultados(1)

                txtTrigo.Focus()
            Else
                If pBusqueda = 1 Then
                    txtProvId.Text = ""
                Else
                    txtProveedor.Text = ""
                End If

                msg.setError("No se seleccionó un código de Proveedor correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Proveedor: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarTrigo(ByVal pBusqueda As Integer) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            msg.reset()

            If pBusqueda = 1 Then
                frmBusq = New frmBusqueda(cliente, genW, 2, 1, txtTrigoId.Text, "", "1", "", "", "")
            Else
                frmBusq = New frmBusqueda(cliente, genW, 2, 1, "", txtTrigo.Text, "1", "", "", "")
            End If

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) > 0 Then
                txtTrigoId.Text = resultados(0)
                txtTrigo.Text = resultados(1)

                txtProteina.Focus()
            Else
                If pBusqueda = 1 Then
                    txtTrigoId.Text = ""
                Else
                    txtTrigo.Text = ""
                End If

                msg.setError("No se seleccionó un código de Trigo correcto.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de Trigo: " + ex.Message)
        End Try

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
                msg.setError("El Lote debe existir y no tener cambios sin guardar para poder ser cerrado.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos().EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual del Lote no admite la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("El lote " + txtLoteId.Text + " ya ha sido cancelado y no es posible la operación de Cierre o Apertura.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "C" Then
                msg.setPregunta("El lote " + txtLoteId.Text + " ya ha sido cerrado con anterioridad. ¿Desea abrir el Lote?")
                nuevoEstado = "A"
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "A" Then
                msg.setPregunta("El lote " + txtLoteId.Text + " se encuentra Abierto. ¿Desea cerrar el Lote?")
                nuevoEstado = "C"
            End If

            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, nuevoEstado)
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = lote.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then GoTo finalize

            msg.setInfo("Lote " + lote.LoteId + " " + cmbEstado.SelectedItem.Description.ToString + " con éxito.")
            genW.publicar(infDoc, msg)

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar el Lote: " + ex.Message)
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
                msg.setError("El Lote debe existir y no tener cambios sin guardar para poder ser cancelado.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos().EsError Then GoTo finalize

            If Not (Modop = SysEnums.Modos.mConsultar Or Modop = SysEnums.Modos.mModificar) Then
                msg.setError("El modo actual del Lote no admite la operación de Cancelación.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            ElseIf cmbEstado.SelectedItem.ItemData.ToString = "L" Then
                msg.setAdvertencia("El lote " + txtLoteId.Text + " ya ha sido cancelado con anterioridad.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            msg.setPregunta("Ha seleccionado la opción de cancelación de documento. Si da clic en Sí, el documento se cancelará y será necesario " _
                            + " abrir un nuevo documento si desea reemplazarlo. ¿Desea continuar cancelando el documento?")
            genW.publicar(infDoc, msg)
            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo finalize

            genW.seleccionarItem(cmbEstado, "L")
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = lote.actualizar().clonar()
            genW.publicar(infDoc, msg, True)

            If msg.EsError Then
                lote.liberarObjetos()

                lote = New Lote(cliente, txtLoteId.Text)
                msg = lote.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarLote().EsError Then GoTo finalize
            Else
                msg.setInfo("Lote " + lote.LoteId + " cancelado con éxito.")
                genW.publicar(infDoc, msg)
            End If

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible cerrar el Lote: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sloteId As String = ""

        Dim sPref As String = "L"
        Dim icDigit As Integer = 7

        Try
            forzarBusqueda = False

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not lote Is Nothing Then
                lote.liberarObjetos()
            End If

            sloteId = txtLoteId.Text

            lote = New Lote(cliente)
            If lote.LoteId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Lote para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sloteId.Trim.Length.Equals(0) Then
                        sloteId = lote.loteAnterior(lote.LoteId).ToString
                    Else
                        sloteId = lote.loteAnterior(sloteId).ToString
                    End If
                Case "3"
                    If sloteId.Trim.Length.Equals(0) Then
                        sloteId = lote.loteSiguiente(lote.LoteId).ToString
                    Else
                        sloteId = lote.loteSiguiente(sloteId.Trim).ToString
                    End If
                Case "1"
                    sloteId = lote.loteSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sloteId = sPref + (Integer.Parse(lote.LoteId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            lote.liberarObjetos()

            lote = New Lote(cliente, sloteId)
            msg = lote.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarLote().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Lote: " + ex.Message)
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

            resultados = lote.buscarCambios(txtLoteId.Text)
            If resultados.Rows.Count = 0 Then
                msg.setInfo("Este documento no tiene cambios.")
                GoTo finalize
            End If

            frmHist = New frmHistorial(cliente, genW, Cnfg, Usua, _
                                       resultados, SysEnums.TiposDocumentos.dLote, txtLoteId.Text)
            frmHist.MdiParent = Me.MdiParent
            frmHist.Show()
        Catch ex As Exception
            msg.setError("No fue posible buscar el historial del lote: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg)
        Return msg
    End Function

    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If cmbEstado.SelectedItem.ItemData.Equals("C") Or _
                cmbEstado.SelectedItem.ItemData.Equals("L") Then
                msg.setError("El Lote ha sido " + cmbEstado.SelectedItem.Description + " y no se puede modificar.")

                GoTo finalize
            End If

            If txtProvId.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el proveedor de trigo.")
                txtProvId.Focus()
            ElseIf txtTrigo.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el tipo de trigo.")
                txtTrigo.Focus()
            ElseIf txtProteina.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la cantidad de Proteína.")
                txtProteina.Focus()
            ElseIf txtGrado.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el Grado.")
                txtGrado.Focus()
            ElseIf txtHumedad.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la cantidad de Humedad.")
                txtHumedad.Focus()
            ElseIf txtImpureza.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el valor de Impureza.")
            ElseIf txtPesohtl.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el peso por hectolitro.")
                txtPesohtl.Focus()
            ElseIf Not Double.TryParse(txtProteina.Text, 0) Then
                msg.setError("El valor de Proteína no es válido.")
                txtProteina.Focus()
            ElseIf Not Double.TryParse(txtGrado.Text, 0) Then
                msg.setError("El valor de Grado no es válido.")
                txtGrado.Focus()
            ElseIf Not Double.TryParse(txtHumedad.Text, 0) Then
                msg.setError("El valor de Humedad no es válido.")
                txtHumedad.Focus()
            ElseIf Not Double.TryParse(txtPesohtl.Text, 0) Then
                msg.setError("El valor de Peso hectolitro no es válido.")
                txtPesohtl.Focus()
            ElseIf Not Double.TryParse(txtImpureza.Text, 0) Then
                msg.setError("El valor de Impureza no es válido.")
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

#End Region

    Private Sub frmLotes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub txtProvId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarProveedor(1)
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarProveedor(2)
        End If
    End Sub

    Private Sub txtTrigoId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTrigoId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True
            buscar()
        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarTrigo(1)
        End If
    End Sub

    Private Sub txtTrigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTrigo.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            buscarTrigo(2)
        End If
    End Sub

    Private Sub txtProvId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProvId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtProvId_Leave(sender As Object, e As EventArgs) Handles txtProvId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtProvId.Text.Trim.Length.Equals(0) Then _
            If buscarProveedor(1).EsError Then txtProvId.Focus()
    End Sub

    Private Sub txtProvId_TextChanged(sender As Object, e As EventArgs) Handles txtProvId.TextChanged
        setModificar()
    End Sub

    Private Sub dtpFechaLote_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaLote.ValueChanged
        setModificar()
    End Sub

    Private Sub txtTrigoId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTrigoId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtTrigoId_Leave(sender As Object, e As EventArgs) Handles txtTrigoId.Leave
        If Not forzarBusqueda Or Modop = SysEnums.Modos.mBuscar Then Exit Sub
        If Modop = SysEnums.Modos.mBuscar Then Exit Sub

        If Not txtTrigoId.Text.Trim.Length.Equals(0) Then _
            If buscarTrigo(1).EsError Then txtTrigoId.Focus()

    End Sub

    Private Sub txtTrigoId_TextChanged(sender As Object, e As EventArgs) Handles txtTrigoId.TextChanged
        setModificar()
    End Sub

    Private Sub txtProteina_TextChanged(sender As Object, e As EventArgs) Handles txtProteina.TextChanged
        setModificar()
    End Sub

    Private Sub txtGrado_TextChanged(sender As Object, e As EventArgs) Handles txtGrado.TextChanged
        setModificar()
    End Sub

    Private Sub txtHumedad_TextChanged(sender As Object, e As EventArgs) Handles txtHumedad.TextChanged
        setModificar()
    End Sub

    Private Sub txtPesohtl_TextChanged(sender As Object, e As EventArgs) Handles txtPesohtl.TextChanged
        setModificar()
    End Sub

    Private Sub txtImpureza_TextChanged(sender As Object, e As EventArgs) Handles txtImpureza.TextChanged
        setModificar()
    End Sub

    Private Sub txtDockage_TextChanged(sender As Object, e As EventArgs) Handles txtDockage.TextChanged
        setModificar()
    End Sub

    Private Sub txtVomitoxina_TextChanged(sender As Object, e As EventArgs) Handles txtVomitoxina.TextChanged
        setModificar()
    End Sub

    Private Sub txtErgot_TextChanged(sender As Object, e As EventArgs) Handles txtErgot.TextChanged
        setModificar()
    End Sub

    Private Sub txtfllnnum_TextChanged(sender As Object, e As EventArgs) Handles txtfllnnum.TextChanged
        setModificar()
    End Sub

    Private Sub txtOtros_TextChanged(sender As Object, e As EventArgs) Handles txtOtros.TextChanged
        setModificar()
    End Sub

    Private Sub txtObservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged
        setModificar()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click

        Me.Close()
    End Sub

    Private Sub txtNoLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLoteId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtProveedor_Leave(sender As Object, e As EventArgs) Handles txtProveedor.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtProveedor.Text.Trim.Length.Equals(0) Then _
            If buscarProveedor(2).EsError Then txtProveedor.Focus()
    End Sub

    Private Sub txtTrigo_Leave(sender As Object, e As EventArgs) Handles txtTrigo.Leave
        If Not forzarBusqueda Then Exit Sub

        If Not txtTrigo.Text.Trim.Length.Equals(0) Then _
            If buscarTrigo(2).EsError Then txtTrigo.Focus()
    End Sub

    Private Sub txtNoLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        setModificar()
    End Sub

    Private Sub txtTrigo_TextChanged(sender As Object, e As EventArgs) Handles txtTrigo.TextChanged
        setModificar()
    End Sub

    Private Sub cmdprov_Click(sender As Object, e As EventArgs) Handles cmdprov.Click
        Dim frmProv As frmProveedor = Nothing
        'If txtProvId.Text.Trim.Length.Equals(0) Then Exit Sub

        frmProv = New frmProveedor(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtProvId.Text)
        frmProv.MdiParent = Me.MdiParent
        frmProv.Show()

    End Sub

    Private Sub cmdTrigo_Click(sender As Object, e As EventArgs) Handles cmdTrigo.Click
        Dim frmTrigo As frmTrigo = Nothing
        'If txtTrigoId.Text.Trim.Length.Equals(0) Then Exit Sub

        frmTrigo = New frmTrigo(cliente, genW, SysEnums.Modos.mConsultar, Usua, txtTrigoId.Text)
        frmTrigo.MdiParent = Me.MdiParent
        frmTrigo.Show()
    End Sub

    Private Sub frmLote_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim eshistorial As Boolean = False

        If Not lote Is Nothing Then
            If Not lote.Fchlote.Length.Equals(0) Then
                If Modop = SysEnums.Modos.mHistorial Then eshistorial = True
                dtpFechaLote.Value = Date.Parse(lote.Fchlote).AddSeconds(1)
                setConsultar()

                If eshistorial Then
                    setHistorial(sLoteInst)
                Else
                    setConsultar()
                End If
            End If
        End If
    End Sub

    Private Sub frmLote_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtLoteId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtLoteId.Text)
    End Sub
End Class