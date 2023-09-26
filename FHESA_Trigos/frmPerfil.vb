Imports Genericas
Imports ObjEntidades

Public Class frmPerfil
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean = False
    Private forzarBusqueda As Boolean = False

    Private Perfil As Perfil
    Private bCargarPropiedadesAtomo As Boolean

    Private WithEvents mnuCopiarTexto As ToolStripMenuItem
    Private nodoActual As TreeNode

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

#Region "Métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pgenW As GenericasWin, _
       ByVal pModo As SysEnums.Modos, ByVal pUsuario As Usuario, _
       Optional ByVal pPerfilId As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try
            If inicializarControles().EsError Then GoTo finalize
            If pPerfilId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear
            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dPerfil, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sPrfls1", "", "", "")

            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(4)

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
                    Perfil = New Perfil(cliente, pPerfilId)
                    msg = Perfil.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarPerfil().EsError Then GoTo finalize

                    setConsultar()
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

            agregarContextuales()
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dPerfil, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtPerfilId.ContextMenuStrip = strip
        txtPerfilId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
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
            txtPerfilId.Enabled = False
            chkActivo.Enabled = True
            chkActivo.Checked = True

            Perfil = New Perfil(cliente)

            txtPerfilId.Text = Perfil.PerfilId
            Perfil.Detalle.alimentarArbol(trvDetalle)

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dPerfil, _
                      cliente.ParametrosConexion.BaseDeDatos, "sPrfls1", _
                      Perfil.PerfilId, "", "")

            trvDetalle.SelectedNode = trvDetalle.TopNode


            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False
            txtNombre.Focus()


            Me.Text = "Perfil " + Perfil.PerfilId + " (Nuevo Perfil)"
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

            txtPerfilId.Enabled = False
            chkActivo.Enabled = True

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dPerfil, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sPrfls1", _
                                              Perfil.PerfilId, "", "")

            trvDetalle.SelectedNode = trvDetalle.TopNode


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False
            txtNombre.Focus()

            Me.Text = "Perfil " + Perfil.PerfilId + " (Consulta)"
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
            txtNombre.Focus()

            Me.Text = "Perfil " + Perfil.PerfilId + " (Modificar)"
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

            txtPerfilId.Enabled = True
            chkActivo.Enabled = True
            chkActivo.Checked = True
            txtNombre.Enabled = True

            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Perfil (Buscar)"
            txtPerfilId.Focus()

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

    Private Function generarOrigenDatos() As Mensaje
        Dim nodoRaiz As TreeNode = Nothing

        Try
            msg.reset()

            Perfil.liberarObjetos()

            Perfil = New Perfil(cliente, txtPerfilId.Text, txtNombre.Text, CInt(chkActivo.Checked),
                                    Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId)

            nodoRaiz = trvDetalle.TopNode
            While Not nodoRaiz.Parent Is Nothing
                nodoRaiz = nodoRaiz.Parent
            End While

            Perfil.Detalle.setAtomosPerfil(TryCast(nodoRaiz.Tag, AtomoPerfil))



        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarPerfil() As Mensaje
        Try
            msg.reset()

            txtPerfilId.Text = Perfil.PerfilId
            chkActivo.Checked = Perfil.Activo
            txtNombre.Text = Perfil.Nombre

            msg = Perfil.Detalle.alimentarArbol(trvDetalle).clonar()

        Catch ex As Exception
            msg.setError("No fue posible cargar el Perfil: " + ex.Message)
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

            msg = Perfil.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el Perfil: " + ex.Message)
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

            msg = Perfil.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el Perfil: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim estado As String = ""

        Dim sPerfilId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            frmBusq = New frmBusqueda(cliente, genW, 15, 1, txtPerfilId.Text, txtNombre.Text, Math.Abs(CInt(chkActivo.Checked)), "", "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sPerfilId = resultados(0)
                If sPerfilId.Trim.Length.Equals(0) Then GoTo finalize

                Perfil.liberarObjetos()

                Perfil = New Perfil(cliente, sPerfilId)
                msg = Perfil.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarPerfil().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Perfil: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sPerfilId As String = ""

        Dim sPref As String = ""
        Dim icDigit As Integer = 1

        Try
            forzarBusqueda = False

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Perfil Is Nothing Then
                Perfil.liberarObjetos()
            End If

            sPerfilId = txtPerfilId.Text

            Perfil = New Perfil(cliente)
            If Perfil.PerfilId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Perfil para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sPerfilId.Trim.Length.Equals(0) Then
                        sPerfilId = Perfil.perfilAnterior(Perfil.PerfilId).ToString
                    Else
                        sPerfilId = Perfil.perfilAnterior(sPerfilId).ToString
                    End If
                Case "3"
                    If sPerfilId.Trim.Length.Equals(0) Then
                        sPerfilId = Perfil.perfilSiguiente(Perfil.PerfilId).ToString
                    Else
                        sPerfilId = Perfil.perfilSiguiente(sPerfilId).ToString
                    End If
                Case "1"
                    sPerfilId = "0"
                Case "4"
                    sPerfilId = (Integer.Parse(Perfil.PerfilId) - 1).ToString
            End Select

            Perfil.liberarObjetos()

            Perfil = New Perfil(cliente, sPerfilId)
            msg = Perfil.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarPerfil().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos del Perfil: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtNombre.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la el nombre del Perfil.")
                txtNombre.Focus()
            End If
        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

    Private Sub setValoresNodo(ByVal pAtomo As AtomoPerfil)
        Try

            '1 = Consulta
            '2 = Modificación
            '4 = Creación
            '8 = Cancelación
            '16 = Cierre

            If pAtomo Is Nothing Then
                chkOpcActiva.Checked = False
                chkOpcConsultar.Checked = False
                chkOpcModif.Checked = False
                chkOpcCrear.Checked = False
                chkOpcCancelar.Checked = False
                chkOpcCerrar.Checked = False

                chkOpcActiva.Enabled = False
                chkOpcConsultar.Enabled = False
                chkOpcModif.Enabled = False
                chkOpcCrear.Enabled = False
                chkOpcCancelar.Enabled = False
                chkOpcCerrar.Enabled = False
            Else
                chkOpcActiva.Checked = pAtomo.Activo
                chkOpcConsultar.Checked = pAtomo.Consulta
                chkOpcModif.Checked = pAtomo.Mdfccion
                chkOpcCrear.Checked = pAtomo.Creacion
                chkOpcCancelar.Checked = pAtomo.Cnlacion
                chkOpcCerrar.Checked = pAtomo.Cierre

                chkOpcConsultar.Enabled = Integer.Parse(pAtomo.Prmsosap) And 1
                chkOpcModif.Enabled = Integer.Parse(pAtomo.Prmsosap) And 2
                chkOpcCrear.Enabled = Integer.Parse(pAtomo.Prmsosap) And 4
                chkOpcCancelar.Enabled = Integer.Parse(pAtomo.Prmsosap) And 8
                chkOpcCerrar.Enabled = Integer.Parse(pAtomo.Prmsosap) And 16
                chkOpcActiva.Enabled = Integer.Parse(pAtomo.Prmsosap) And 32


            End If
        Catch ex As Exception
            msg.setError("No fue posible establecer las propiedades de la opción de perfil: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

#End Region


    Private Sub frmPerfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
            Case SysEnums.Modos.mConsultar
                Me.Close()
        End Select

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtPerfilId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPerfilId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtPerfilId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPerfilId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        setModificar()
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        setModificar()
    End Sub

    Private Sub chkOpcActiva_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpcActiva.CheckedChanged
        If Not bCargarPropiedadesAtomo Then
            trvDetalle.SelectedNode.Tag.revalorar(chkOpcActiva.Checked, chkOpcConsultar.Checked, chkOpcModif.Checked, _
                                                  chkOpcCrear.Checked, chkOpcCancelar.Checked, chkOpcCerrar.Checked)

            setModificar()
        End If
    End Sub

    Private Sub chkOpcCrear_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpcCrear.CheckedChanged
        If Not bCargarPropiedadesAtomo Then
            trvDetalle.SelectedNode.Tag.revalorar(chkOpcActiva.Checked, chkOpcConsultar.Checked, chkOpcModif.Checked, _
                                                  chkOpcCrear.Checked, chkOpcCancelar.Checked, chkOpcCerrar.Checked)

            setModificar()
        End If
    End Sub

    Private Sub chkOpcModif_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpcModif.CheckedChanged
        If Not bCargarPropiedadesAtomo Then
            trvDetalle.SelectedNode.Tag.revalorar(chkOpcActiva.Checked, chkOpcConsultar.Checked, chkOpcModif.Checked, _
                                                  chkOpcCrear.Checked, chkOpcCancelar.Checked, chkOpcCerrar.Checked)

            setModificar()
        End If
    End Sub

    Private Sub chkOpcCerrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpcCerrar.CheckedChanged
        If Not bCargarPropiedadesAtomo Then
            trvDetalle.SelectedNode.Tag.revalorar(chkOpcActiva.Checked, chkOpcConsultar.Checked, chkOpcModif.Checked, _
                                                  chkOpcCrear.Checked, chkOpcCancelar.Checked, chkOpcCerrar.Checked)

            setModificar()
        End If
    End Sub

    Private Sub chkOpcCancelar_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpcCancelar.CheckedChanged
        If Not bCargarPropiedadesAtomo Then
            trvDetalle.SelectedNode.Tag.revalorar(chkOpcActiva.Checked, chkOpcConsultar.Checked, chkOpcModif.Checked, _
                                                  chkOpcCrear.Checked, chkOpcCancelar.Checked, chkOpcCerrar.Checked)

            setModificar()
        End If
    End Sub

    Private Sub chkOpcConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpcConsultar.CheckedChanged
        If Not bCargarPropiedadesAtomo Then
            trvDetalle.SelectedNode.Tag.revalorar(chkOpcActiva.Checked, chkOpcConsultar.Checked, chkOpcModif.Checked, _
                                                  chkOpcCrear.Checked, chkOpcCancelar.Checked, chkOpcCerrar.Checked)

            setModificar()
        End If
    End Sub

    Private Sub txtPerfilId_TextChanged(sender As Object, e As EventArgs) Handles txtPerfilId.TextChanged

    End Sub

    Private Sub trvDetalle_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvDetalle.AfterSelect
        Try
            trvDetalle.BeginUpdate()
            e.Node.NodeFont = New Font(trvDetalle.Font, FontStyle.Bold)
            trvDetalle.EndUpdate()
            trvDetalle.Refresh()

            setValoresNodo(TryCast(e.Node.Tag, AtomoPerfil))

            nodoActual = e.Node
        Catch ex As Exception
            msg.setError("No fue posible recuperar las propiedades de la opción de perfil: " + ex.Message)
        End Try

        bCargarPropiedadesAtomo = False

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub trvDetalle_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles trvDetalle.BeforeSelect
        If Not nodoActual Is Nothing Then
            trvDetalle.BeginUpdate()
            nodoActual.NodeFont = New Font(trvDetalle.Font, FontStyle.Regular)

            trvDetalle.EndUpdate()
            trvDetalle.Refresh()
        End If

        bCargarPropiedadesAtomo = True
    End Sub

    Private Sub frmPerfil_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtPerfilId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtPerfilId.Text)
    End Sub

    Private Sub trvDetalle_Click(sender As Object, e As EventArgs) Handles trvDetalle.Click

    End Sub
End Class