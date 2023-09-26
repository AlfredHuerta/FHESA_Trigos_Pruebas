Imports Genericas
Imports ObjEntidades

Public Class frmOrigen
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean

    Private Origen As Origen

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
       Optional ByVal pOrigenId As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Try
            msg = New Mensaje
            cliente = pCliente
            genW = pgenW

            If inicializarControles().EsError Then GoTo finalize

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOrigen, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sOrigen", "", "", "")
            If pOrigenId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(17)

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
                    Origen = New Origen(cliente, pOrigenId)
                    msg = Origen.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarOrigen().EsError Then GoTo finalize

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
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dOrigen, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtOrigenId.ContextMenuStrip = strip
        txtOrigenId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtOrigenId.Enabled = False

            Origen = New Origen(cliente)

            txtOrigenId.Text = Origen.OrigenId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOrigen, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOrigen", _
                                              Origen.OrigenId, "", "")

            Try
                chkActivo.Checked = True
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Origen " + Origen.OrigenId + " (Nuevo Origen)"

            txtNombre.Focus()
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

            txtOrigenId.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dOrigen, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOrigen", _
                                              Origen.OrigenId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Origen " + Origen.OrigenId + " (Consulta)"
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

            Me.Text = "Origen " + Origen.OrigenId + " (Modificar)"
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

            txtOrigenId.Enabled = True
            chkActivo.Enabled = True
            txtNombre.Enabled = True
            chkActivo.Checked = True

            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Origen (Buscar)"
            txtOrigenId.Focus()

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

            Origen.liberarObjetos()

            Origen = New Origen(cliente, txtOrigenId.Text, txtNombre.Text, _
                                 Math.Abs(CInt(chkActivo.Checked)), Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                            Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, "")

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarOrigen() As Mensaje
        Try
            msg.reset()

            txtOrigenId.Text = Origen.OrigenId
            chkActivo.Checked = Origen.Activo
            txtNombre.Text = Origen.Nombre


        Catch ex As Exception
            msg.setError("No fue posible cargar el Origen: " + ex.Message)
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

            msg = Origen.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el registro del Origen: " + ex.Message)
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

            msg = Origen.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el registro del Origen: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOrigenId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            frmBusq = New frmBusqueda(cliente, genW, 4, 1, txtOrigenId.Text, txtNombre.Text, Math.Abs(CInt(chkActivo.Checked)), "", "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sOrigenId = resultados(0)
                If sOrigenId.Trim.Length.Equals(0) Then GoTo finalize

                Origen.liberarObjetos()

                Origen = New Origen(cliente, sOrigenId)
                msg = Origen.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarOrigen().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Origen: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sOrigenId As String = ""
        Dim sPref As String = "RG"
        Dim icDigit As Integer = 4

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Origen Is Nothing Then
                Origen.liberarObjetos()
            End If

            sOrigenId = txtOrigenId.Text

            Origen = New Origen(cliente)
            If Origen.OrigenId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Origen para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sOrigenId.Trim.Length.Equals(0) Then
                        sOrigenId = Origen.origenAnterior(Origen.OrigenId).ToString
                    Else
                        sOrigenId = Origen.origenAnterior(sOrigenId).ToString
                    End If
                Case "3"
                    If sOrigenId.Trim.Length.Equals(0) Then
                        sOrigenId = Origen.origenSiguiente(Origen.OrigenId).ToString
                    Else
                        sOrigenId = Origen.origenSiguiente(sOrigenId).ToString
                    End If
                Case "1"
                    sOrigenId = Origen.origenSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sOrigenId = sPref + (Integer.Parse(Origen.OrigenId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Origen.liberarObjetos()

            Origen = New Origen(cliente, sOrigenId)
            msg = Origen.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarOrigen().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Origen: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function


    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtNombre.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la el nombre del Origen.")
                txtNombre.Focus()
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

#End Region

    Private Sub frmOrigen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub txtOrigenId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrigenId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtOrigenId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrigenId.KeyPress
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


    Private Sub frmOrigen_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtOrigenId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtOrigenId.Text)
    End Sub
End Class