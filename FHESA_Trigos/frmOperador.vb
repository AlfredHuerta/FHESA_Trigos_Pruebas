Imports Genericas
Imports ObjEntidades

Public Class frmOperador
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql

    Private Usua As Usuario
    Private atmPerf As AtomoPerfil


    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean

    Private Operador As Operador

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
                   Optional ByVal pOpradorId As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Try
            msg = New Mensaje
            cliente = pCliente
            genW = pgenW

            If inicializarControles().EsError Then GoTo finalize

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOperador, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sOprador", "", "", "")

            If pOpradorId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(20)

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
                    Operador = New Operador(cliente, pOpradorId)
                    msg = Operador.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarOperador().EsError Then GoTo finalize

                    setConsultar()
            End Select
        Catch ex As Exception
            msg.setError("No fue posible inicializar la ventana: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
    End Sub

    Private Function inicializarControles() As Mensaje

        Try
            msg = genW.initControles(Me)
            If msg.EsError Then GoTo finalize

            agregarContextuales()
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dOperador, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtOprdorId.ContextMenuStrip = strip
        txtOprdorId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtOprdorId.Enabled = False

            Operador = New Operador(cliente)

            txtOprdorId.Text = Operador.OprdorId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOperador, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOprador", _
                                              Operador.OprdorId, "", "")

            Try
                chkActivo.Checked = True
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Operador " + Operador.OprdorId + " (Nuevo Usuario)"

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

            txtOprdorId.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOperador, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOprador", _
                                              Operador.OprdorId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Operador " + Operador.OprdorId + " (Consulta)"
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

            Me.Text = "Operador " + Operador.OprdorId + " (Modificar)"
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

            txtOprdorId.Enabled = True
            chkActivo.Enabled = True
            txtNombre.Enabled = True
            chkActivo.Checked = True

            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Operador (Buscar)"
            txtOprdorId.Focus()

            modificado = False
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Búsqueda: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function generarOrigenDatos() As Mensaje
        Try
            msg.reset()

            Operador.liberarObjetos()

            Operador = New Operador(cliente, txtOprdorId.Text, txtNkName.Text, txtNombre.Text, _
                                 Math.Abs(CInt(chkActivo.Checked)), Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                            Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, "")

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarOperador() As Mensaje
        Try
            msg.reset()

            txtOprdorId.Text = Operador.OprdorId
            chkActivo.Checked = Operador.Activo
            txtNkName.Text = Operador.Nkname
            txtNombre.Text = Operador.Nombre

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

            msg = Operador.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el registro del Operador: " + ex.Message)
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

            msg = Operador.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el registro del Operador: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOprdorId As String = ""

        Try

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            frmBusq = New frmBusqueda(cliente, genW, 7, 1, txtOprdorId.Text, txtNombre.Text, Math.Abs(CInt(chkActivo.Checked)), "", "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sOprdorId = resultados(0)
                If sOprdorId.Trim.Length.Equals(0) Then GoTo finalize

                Operador.liberarObjetos()

                Operador = New Operador(cliente, sOprdorId)
                msg = Operador.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarOperador().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Operador: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sOprdorId As String = ""
        Dim sPref As String = "R"
        Dim icDigit As Integer = 3

        Try
            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not Operador Is Nothing Then
                Operador.liberarObjetos()
            End If

            sOprdorId = txtOprdorId.Text

            Operador = New Operador(cliente)
            If Operador.OprdorId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Operador para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sOprdorId.Trim.Length.Equals(0) Then
                        sOprdorId = Operador.operadorAnterior(Operador.OprdorId).ToString
                    Else
                        sOprdorId = Operador.operadorAnterior(sOprdorId).ToString
                    End If
                Case "3"
                    If sOprdorId.Trim.Length.Equals(0) Then
                        sOprdorId = Operador.operadorSiguiente(Operador.OprdorId).ToString
                    Else
                        sOprdorId = Operador.operadorSiguiente(sOprdorId).ToString
                    End If
                Case "1"
                    sOprdorId = Operador.operadorSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sOprdorId = sPref + (Integer.Parse(Operador.OprdorId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Operador.liberarObjetos()

            Operador = New Operador(cliente, sOprdorId)
            msg = Operador.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarOperador().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Operador: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function


    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtNkName.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el Nickname de Operador.")
                txtNombre.Focus()
            ElseIf txtNombre.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido el nombre del Operador.")
                txtNombre.Focus()
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

#End Region

    Private Sub frmOperador_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub txtOprdorId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOprdorId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtOprdorId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOprdorId.KeyPress
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

    Private Sub frmOperador_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtOprdorId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtOprdorId.Text)
    End Sub

 
End Class