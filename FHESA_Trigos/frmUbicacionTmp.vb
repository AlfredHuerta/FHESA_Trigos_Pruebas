Imports Genericas
Imports ObjEntidades
Public Class frmUbicacionTmp
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Cnfg As Configuracion

    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean

    Private UbicacionTmp As UbicacionTmp

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

#Region "Métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pgenW As GenericasWin, _
                   ByVal pModo As SysEnums.Modos, ByVal pUsuario As Usuario, _
   Optional ByVal pUbicaId As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Try
            msg = New Mensaje
            cliente = pCliente
            genW = pgenW

            If inicializarControles().EsError Then GoTo finalize

            If pUbicaId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUbcTmpId, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sUbcTmpId", "", "", "")

            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(18)

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

                    UbicacionTmp = New UbicacionTmp(cliente, pUbicaId)
                    msg = UbicacionTmp.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarUbicacion().EsError Then GoTo finalize

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
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dUbcTmpId, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuCopiarTexto = New ToolStripMenuItem()
        mnuCopiarTexto.Text = "Copiar"


        txtUbcTmpId.ContextMenuStrip = strip
        txtUbcTmpId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtUbcTmpId.Enabled = False

            UbicacionTmp = New UbicacionTmp(cliente)

            txtUbcTmpId.Text = UbicacionTmp.UbcTmpId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUbcTmpId, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sUbctTmpId", _
                                              UbicacionTmp.UbcTmpId, "", "")

            Try
                chkActivo.Checked = True
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Ubicación Temporal " + UbicacionTmp.UbcTmpId + " (Nueva Ubicación)"

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

            txtUbcTmpId.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUbcTmpId, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sUbctTmpId", _
                                              UbicacionTmp.UbcTmpId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Ubicación Temporal " + UbicacionTmp.UbcTmpId + " (Consulta)"
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

            Me.Text = "Ubicación" + UbicacionTmp.UbcTmpId + " (Modificar)"
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

            txtUbcTmpId.Enabled = True
            chkActivo.Enabled = True
            txtNombre.Enabled = True
            chkActivo.Checked = True

            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Ubicación Temporal (Buscar)"
            txtUbcTmpId.Focus()

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

            UbicacionTmp.liberarObjetos()

            UbicacionTmp = New UbicacionTmp(cliente, txtUbcTmpId.Text, txtNombre.Text, _
                                 Math.Abs(CInt(chkActivo.Checked)), Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                            Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId)

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarUbicacion() As Mensaje
        Try
            msg.reset()

            txtUbcTmpId.Text = UbicacionTmp.UbcTmpId
            chkActivo.Checked = UbicacionTmp.Activo
            txtNombre.Text = UbicacionTmp.Nombre

        Catch ex As Exception
            msg.setError("No fue posible cargar el Ubicación Temporal: " + ex.Message)
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

            msg = UbicacionTmp.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el registro del Ubicación Temporal: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function modificar() As Mensaje
        Try
            msg.reset()

            msg.reset()

            If Not atmPerf.Mdfccion Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If validarDatos().EsError Then GoTo finalize
            If generarOrigenDatos().EsError Then GoTo finalize

            msg = UbicacionTmp.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el registro del Ubicación Temporal: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Dim sOrigenId As String = ""

        Try

            msg.reset()

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            frmBusq = New frmBusqueda(cliente, genW, 18, 1, txtUbcTmpId.Text, txtNombre.Text, Math.Abs(CInt(chkActivo.Checked)), "", "", "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sOrigenId = resultados(0)
                If sOrigenId.Trim.Length.Equals(0) Then GoTo finalize

                UbicacionTmp.liberarObjetos()

                UbicacionTmp = New UbicacionTmp(cliente, sOrigenId)
                msg = UbicacionTmp.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarUbicacion().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Ubicación Temporal: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sUbcTmpId As String = ""
        Dim sPref As String = "UT"
        Dim icDigit As Integer = 4

        Try
            msg.reset()

            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not UbicacionTmp Is Nothing Then
                UbicacionTmp.liberarObjetos()
            End If

            sUbcTmpId = txtUbcTmpId.Text

            UbicacionTmp = New UbicacionTmp(cliente)
            If UbicacionTmp.UbcTmpId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Ubicaciones Temporales  para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sUbcTmpId.Trim.Length.Equals(0) Then
                        sUbcTmpId = UbicacionTmp.ubicacionAnterior(UbicacionTmp.UbcTmpId).ToString
                    Else
                        sUbcTmpId = UbicacionTmp.ubicacionAnterior(sUbcTmpId).ToString
                    End If
                Case "3"
                    If sUbcTmpId.Trim.Length.Equals(0) Then
                        sUbcTmpId = UbicacionTmp.ubicacionSiguiente(UbicacionTmp.UbcTmpId).ToString
                    Else
                        sUbcTmpId = UbicacionTmp.ubicacionSiguiente(sUbcTmpId).ToString
                    End If
                Case "1"
                    sUbcTmpId = UbicacionTmp.ubicacionSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sUbcTmpId = sPref + (Integer.Parse(UbicacionTmp.UbcTmpId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            UbicacionTmp.liberarObjetos()

            UbicacionTmp = New UbicacionTmp(cliente, sUbcTmpId)
            msg = UbicacionTmp.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarUbicacion().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Ubicaciones Temporales: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function


    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtNombre.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la el nombre del Destino.")
                txtNombre.Focus()
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

#End Region

    Private Sub frmUbicacionTmp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub txtUbcTmpId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUbcTmpId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtUbcTmpId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUbcTmpId.KeyPress
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


    Private Sub frmUbicacionTmp_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtUbcTmpId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtUbcTmpId.Text)
    End Sub

    Private Sub lblUbcTmpIdId_Click(sender As System.Object, e As System.EventArgs) Handles lblUbcTmpId.Click

    End Sub

    Private Sub txtUbcTmpId_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUbcTmpId.TextChanged

    End Sub

    Private Sub frmUbicacionTmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class