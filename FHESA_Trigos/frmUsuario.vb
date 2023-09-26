Imports Genericas
Imports ObjEntidades

Public Class frmUsuario
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean

    Private Usuario As Usuario

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
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pgenW As GenericasWin, _
               ByVal pModo As SysEnums.Modos, ByVal pUsuario As Usuario, _
               Optional ByVal pUsrId As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Try
            msg = New Mensaje
            cliente = pCliente
            genW = pgenW

            If inicializarControles().EsError Then GoTo finalize
            If pUsrId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear
            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUsuario, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sUsuarios", "", "", "")

            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(6)

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
                    Usuario = New Usuario(cliente, pUsrId)
                    msg = Usuario.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarUsuario().EsError Then GoTo finalize

                    setConsultar()
            End Select
        Catch ex As Exception
            msg.setError("No fue posible inicializar la ventana: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
    End Sub

    Private Function inicializarControles() As Mensaje
        Dim Cats As Catalogos = New Catalogos(cliente)

        Try
            msg = genW.initControles(Me)
            If msg.EsError Then GoTo finalize


            Cats = New Catalogos(cliente)
            genW.llenarListadoDesdeTabla(Cats.cargarPuestos(), "Descripcion", "PuestoId", cmbPuestoId)
            genW.llenarListadoDesdeTabla(Cats.cargarPerfiles(), "Descripcion", "PerfilId", cmbPerfil)
            genW.llenarListadoDesdeTabla(Cats.cargarOperadores(), "Descripcion", "OprdorId", cmbOperador)
            genW.llenarListadoDesdeTabla(Cats.cargarSmtp(), "Descripcion", "SmtpId", cmbSmtpId)

            agregarContextuales()
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dUsuario, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtUsrId.ContextMenuStrip = strip
        txtUsrId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtUsrId.Enabled = False

            Usuario = New Usuario(cliente)

            txtUsrId.Text = Usuario.UsrId

            cmbPuestoId.SelectedIndex = -1
            cmbPerfil.SelectedIndex = -1
            cmbOperador.SelectedIndex = -1
            cmbSmtpId.SelectedIndex = -1

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUsuario, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sUsuarios", _
                                              Usuario.UsrId, "", "")

            Try
                chkActivo.Checked = True
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Usuario " + Usuario.UsrId + " (Nuevo Usuario)"

            txtNkName.Focus()
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Crear: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Public Function setConsultar() As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesConsultar(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtUsrId.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOperador, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sUsuarios", _
                                              Usuario.UsrId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Usuario " + Usuario.UsrId + " (Consulta)"
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Consultar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Public Function setModificar() As Mensaje
        Try
            If Modop <> SysEnums.Modos.mBuscar Then modificado = True
            If Modop <> SysEnums.Modos.mConsultar Then GoTo finalize

            msg.reset()

            cmdAceptar.Text = "Actualizar"
            Modop = SysEnums.Modos.mModificar

            Me.Text = "Usuario " + Usuario.UsrId + " (Modificar)"
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Modificar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Public Function setBuscar() As Mensaje
        Try
            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesBuscar(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtUsrId.Enabled = True
            chkActivo.Enabled = True
            txtNombre.Enabled = True
            txtNkName.Enabled = True
            txtApllidop.Enabled = True
            txtApllidom.Enabled = True
            chkActivo.Checked = True

            cmbPuestoId.SelectedIndex = -1
            cmbPerfil.SelectedIndex = -1
            cmbOperador.SelectedIndex = -1
            cmbSmtpId.SelectedIndex = -1

            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Usuario (Buscar)"
            txtUsrId.Focus()

            modificado = False
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Búsqueda: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function generarOrigenDatos() As Mensaje
        Dim cripto As Criptografo = Nothing
        Dim sPuestoId As String = ""
        Dim sSmtpId As String = ""


        Try
            msg.reset()

            Usuario.liberarObjetos()

            cripto = New Criptografo()

            If cmbPuestoId.SelectedItem Is Nothing Then
                sPuestoId = ""
            Else
                sPuestoId = cmbPuestoId.SelectedItem.ItemData
            End If

            If cmbSmtpId.SelectedItem Is Nothing Then
                sSmtpId = ""
            Else
                sSmtpId = cmbPuestoId.SelectedItem.ItemData
            End If

            Usuario = New Usuario(cliente, txtUsrId.Text, txtNkName.Text, txtNombre.Text, txtApllidop.Text, txtApllidom.Text, _
                                  cripto.Encriptar(txtCntrsenia.Text, "tNlTrg"), cmbPerfil.SelectedItem.ItemData, sPuestoId, _
                                  Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                                  txtContraseniaCuentaCorreo.Text, cripto.Encriptar(txtContraseniaCuentaCorreo.Text, "tNlTrg"), _
                                  sSmtpId, Math.Abs(CInt(chkActivo.Checked)), Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                                  Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, "", cmbOperador.SelectedItem.ItemData)
        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarUsuario() As Mensaje
        Dim cripto As Criptografo = Nothing

        Try
            msg.reset()

            cripto = New Criptografo()

            txtUsrId.Text = Usuario.UsrId
            chkActivo.Checked = Usuario.Activo
            txtNkName.Text = Usuario.Nkname
            txtNombre.Text = Usuario.Nombre
            txtApllidop.Text = Usuario.Apllidop
            txtApllidom.Text = Usuario.Apllidom
            txtCntrsenia.Text = cripto.Desencriptar(Usuario.Cntrsnia, "tNlTrg")
            txtConfirmarContrasenia.Text = cripto.Desencriptar(Usuario.Cntrsnia, "tNlTrg")

            cmbPuestoId.SelectedIndex = -1
            cmbPerfil.SelectedIndex = -1
            cmbOperador.SelectedIndex = -1
            cmbSmtpId.SelectedIndex = -1
            genW.seleccionarItem(cmbPuestoId, Usuario.PuestoId)
            genW.seleccionarItem(cmbPerfil, Usuario.PerfilId)
            genW.seleccionarItem(cmbOperador, Usuario.OprdorId)
            genW.seleccionarItem(cmbSmtpId, Usuario.SmtpId)

            txtCuentaCorreo.Text = Usuario.Correoe
            txtContraseniaCuentaCorreo.Text = cripto.Desencriptar(Usuario.Cntrscoe, "tNlTrg")


        Catch ex As Exception
            msg.setError("No fue posible cargar el Operador: " + ex.Message)
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

            msg = Usuario.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el registro del Usuario: " + ex.Message)
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

            msg = Usuario.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el registro del Usuario: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sUsrId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            frmBusq = New frmBusqueda(cliente, genW, 16, 1, txtUsrId.Text, txtNkName.Text, txtNombre.Text, txtApllidop.Text, txtApllidom.Text, Math.Abs(CInt(chkActivo.Checked)))

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sUsrId = resultados(0)
                If sUsrId.Trim.Length.Equals(0) Then GoTo finalize

                Usuario.liberarObjetos()

                Usuario = New Usuario(cliente, sUsrId)
                msg = Usuario.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarUsuario().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Usuario: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sUsrId As String = ""

        Dim sPref As String = ""
        Dim icDigit As Integer = 1

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Usuario Is Nothing Then
                Usuario.liberarObjetos()
            End If

            sUsrId = txtUsrId.Text

            Usuario = New Usuario(cliente)
            If Usuario.UsrId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Usuario para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sUsrId.Trim.Length.Equals(0) Then
                        sUsrId = Usuario.usuarioAnterior(Usuario.UsrId).ToString
                    Else
                        sUsrId = Usuario.usuarioAnterior(sUsrId).ToString
                    End If
                Case "3"
                    If sUsrId.Trim.Length.Equals(0) Then
                        sUsrId = Usuario.usuarioSiguiente(Usuario.UsrId).ToString
                    Else
                        sUsrId = Usuario.usuarioSiguiente(sUsrId).ToString
                    End If
                Case "1"
                    sUsrId = "0"
                Case "4"
                    sUsrId = (Integer.Parse(Usuario.UsrId) - 1).ToString
            End Select

            Usuario.liberarObjetos()

            Usuario = New Usuario(cliente, sUsrId)
            msg = Usuario.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarUsuario().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos del Usuario: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtNkName.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el Nickname del Usuario.")
                txtNkName.Focus()
            ElseIf txtCntrsenia.Text.Trim.Length.Equals(0) Then
                msg.setError("La contraseña de usuario no puede estar vacía.")
                txtCntrsenia.Focus()
            ElseIf Not txtCntrsenia.Text.Equals(txtConfirmarContrasenia.Text) Then
                msg.setError("La contraseña de usuario no coincide.")
                txtCntrsenia.Focus()
            ElseIf txtNombre.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el nombre del Usuario.")
                txtNombre.Focus()
            ElseIf cmbPuestoId.SelectedItem Is Nothing Then
                msg.setError("No se ha definido un Puesto al usuario.")
                cmbPuestoId.Focus()
            ElseIf cmbPerfil.SelectedItem Is Nothing Then
                msg.setError("No se ha definido un Perfil de usuario.")
                cmbPerfil.Focus()
            ElseIf cmbOperador.SelectedItem Is Nothing Then
                msg.setError("No se ha mapeado un operador al usuario.")
                cmbOperador.Focus()
            ElseIf Not cmbSmtpId.SelectedItem Is Nothing Then
                If txtCuentaCorreo.Text.Trim.Length.Equals(0) Then
                    msg.setError("La cuenta de Correo no puede estar vacía.")
                    txtCuentaCorreo.Focus()
                ElseIf txtContraseniaCuentaCorreo.Text.Trim.Length.Equals(0) Then
                    msg.setError("La contraseña de correo electrónico no puede estar vacía.")
                    txtContraseniaCuentaCorreo.Focus()
                ElseIf Not txtContraseniaCuentaCorreo.Text.Equals(txtConfContraseiaCuentaCorreo.Text) Then
                    msg.setError("La contraseña de cuenta de correo no coincide.")
                    txtContraseniaCuentaCorreo.Focus()
                End If
            End If


        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

#End Region

    Private Sub frmUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Usua.CerrandoSesion Then
            If Not genW.continuarSinGuardar(infDoc, modificado) Then e.Cancel = True
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

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        setModificar()
    End Sub

    Private Sub txtNkName_TextChanged(sender As Object, e As EventArgs) Handles txtNkName.TextChanged
        setModificar()
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        setModificar()
    End Sub


    Private Sub txtCntrsenia_TextChanged(sender As Object, e As EventArgs) Handles txtCntrsenia.TextChanged
        setModificar()
    End Sub

    Private Sub txtApllidop_TextChanged(sender As Object, e As EventArgs) Handles txtApllidop.TextChanged
        setModificar()
    End Sub

    Private Sub txtApllidom_TextChanged(sender As Object, e As EventArgs) Handles txtApllidom.TextChanged
        setModificar()
    End Sub

    Private Sub cmbPuestoId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuestoId.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub cmbPerfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPerfil.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub cmbOperador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperador.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub cmbSmtpId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSmtpId.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub txtCuentaCorreo_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaCorreo.TextChanged
        setModificar()
    End Sub

    Private Sub txtContraseniaCuentaCorreo_TextChanged(sender As Object, e As EventArgs) Handles txtContraseniaCuentaCorreo.TextChanged
        setModificar()
    End Sub

    Private Sub frmUsuario_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtUsrId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtUsrId.Text)
    End Sub

    Private Sub txtUsrId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsrId.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            buscar()
        End If

    End Sub

    Private Sub txtUsrId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsrId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub
End Class