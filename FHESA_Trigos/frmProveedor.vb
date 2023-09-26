Imports Genericas
Imports ObjEntidades

Public Class frmProveedor
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean

    Private Prov As Proveedor

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
               Optional ByVal pProvId As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Try
            msg = New Mensaje
            cliente = pCliente
            genW = pgenW

            If inicializarControles().EsError Then GoTo finalize
            If pProvId.Trim.Length.Equals(0) Then pModo = SysEnums.Modos.mCrear
            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dProveedor, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sProveed", "", "", "")

            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(46)

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
                    Prov = New Proveedor(cliente, pProvId)
                    msg = Prov.Mensaje.clonar()
                    If msg.EsError Then GoTo finalize

                    If cargarProveedor().EsError Then GoTo finalize

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
            genW.llenarListadoDesdeTabla(Cats.cargarTiposProveedor(), "Nombre", "Tipo", cmbTipoProv)

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


        txtProvId.ContextMenuStrip = strip
        txtProvId.ContextMenuStrip.Items.Add(mnuCopiarTexto)
    End Sub

    Public Function setCrear() As Mensaje
        Try
            msg.reset()

            If Not Modop = SysEnums.Modos.mCrear Or modificado = True Then _
                If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            msg = genW.initControlesCrear(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtProvId.Enabled = False

            Prov = New Proveedor(cliente)

            txtProvId.Text = Prov.ProvId

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dProveedor, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sProveed", _
                                              Prov.ProvId, "", "")

            genW.seleccionarItem(cmbTipoProv, "T001")
            Try
                chkActivo.Checked = True
            Catch
            End Try

            cmdAceptar.Text = "Crear"
            Modop = SysEnums.Modos.mCrear
            modificado = False

            Me.Text = "Proveedor " + Prov.ProvId + " (Nuevo proveedor)"

            txtRazonSocial.Focus()
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

            txtProvId.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dProveedor, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sProveed", _
                                              Prov.ProvId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

            Me.Text = "Proveedor " + Prov.ProvId + " (Consulta)"
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

            Me.Text = "Proveedor " + Prov.ProvId + " (Modificar)"
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

            txtProvId.Enabled = True
            chkActivo.Enabled = True
            cmbTipoProv.Enabled = True
            txtRazonSocial.Enabled = True
            txtContacto.Enabled = True

            cmbTipoProv.SelectedIndex = -1
            txtProvId.Text = ""
            chkActivo.Checked = True
            cmdAceptar.Text = "Buscar"

            Modop = SysEnums.Modos.mBuscar
            Me.Text = "Proveedor (Buscar)"
            txtProvId.Focus()

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

            Prov.liberarObjetos()

            Prov = New Proveedor(cliente, txtProvId.Text, txtRazonSocial.Text, txtCalle.Text, _
                                 txtNoExt.Text, txtNoInt.Text, txtColonia.Text, txtReferencia.Text, _
                                 txtLocalidad.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, _
                                 txtCodigoPostal.Text, txtContacto.Text, cmbTipoProv.SelectedItem.ItemData.ToString, _
                                 "", Math.Abs(CInt(chkActivo.Checked)), Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                            Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), Usua.UsrId, "")

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarProveedor() As Mensaje
        Try
            msg.reset()

            txtProvId.Text = Prov.ProvId
            chkActivo.Checked = Prov.Activo
            genW.seleccionarItem(cmbTipoProv, Prov.TpoprvId)
            txtRazonSocial.Text = Prov.Nombre
            txtContacto.Text = Prov.Cntcto
            txtCalle.Text = Prov.Calle
            txtNoExt.Text = Prov.Noext
            txtNoInt.Text = Prov.Noint
            txtColonia.Text = Prov.Colonia
            txtReferencia.Text = Prov.Rferenc
            txtMunicipio.Text = Prov.Mnicipio
            txtEstado.Text = Prov.Estado
            txtPais.Text = Prov.Pais
            txtCodigoPostal.Text = Prov.Cdgpstl

        Catch ex As Exception
            msg.setError("No fue posible cargar el Proveedor: " + ex.Message)
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

            msg = Prov.guardar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize
            modificado = False

            setCrear()
        Catch ex As Exception
            msg.setError("No fue posible crear el Proveedor: " + ex.Message)
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

            msg = Prov.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar el Proveedor: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscar() As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing
        Dim tipo As String = ""

        Dim sProvId As String = ""

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not cmbTipoProv.SelectedItem Is Nothing Then _
                tipo = cmbTipoProv.SelectedItem.ItemData.ToString

            frmBusq = New frmBusqueda(cliente, genW, 1, 1, txtProvId.Text, tipo, _
                                      Math.Abs(CInt(chkActivo.Checked)).ToString, _
                                      txtRazonSocial.Text, txtContacto.Text, "")

            If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()

            resultados = frmBusq.Resultados

            If resultados.GetUpperBound(0) >= 0 Then
                sProvId = resultados(0)
                If sProvId.Trim.Length.Equals(0) Then GoTo finalize

                Prov.liberarObjetos()

                Prov = New Proveedor(cliente, sProvId)
                msg = Prov.Mensaje.clonar()
                If msg.EsError Then GoTo finalize

                If cargarProveedor().EsError Then GoTo finalize

                setConsultar()
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Proveedor: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function moverRegistro(ByVal pMenuId As String) As Mensaje
        Dim sProvId As String = ""

        Dim sPref As String = "P"
        Dim icDigit As Integer = 5

        Try
            If Not atmPerf.Consulta Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            If Not genW.continuarSinGuardar(infDoc, modificado) Then GoTo finalize

            If Not Prov Is Nothing Then
                Prov.liberarObjetos()
            End If

            sProvId = txtProvId.Text

            Prov = New Proveedor(cliente)
            If Prov.ProvId = sPref + "".PadRight(icDigit - 1, "0") + "1" Then
                Throw New Exception("No hay datos de Proveedor para consultar.")
            End If

            Select Case pMenuId
                Case "2"
                    If sProvId.Trim.Length.Equals(0) Then
                        sProvId = Prov.proveedorAnterior(Prov.ProvId).ToString
                    Else
                        sProvId = Prov.proveedorAnterior(sProvId).ToString
                    End If
                Case "3"
                    If sProvId.Trim.Length.Equals(0) Then
                        sProvId = Prov.proveedorSiguiente(Prov.ProvId).ToString
                    Else
                        sProvId = Prov.proveedorSiguiente(sProvId.Trim).ToString
                    End If
                Case "1"
                    sProvId = Prov.proveedorSiguiente(sPref + "".PadRight(icDigit, "0")).ToString
                Case "4"
                    sProvId = sPref + (Integer.Parse(Prov.ProvId.Replace(sPref, "")) - 1).ToString.PadLeft(icDigit, "0")
            End Select

            Prov.liberarObjetos()

            Prov = New Proveedor(cliente, sProvId)
            msg = Prov.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarProveedor().EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búsqueda de los datos de Lote: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtRazonSocial.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Razón Social del proveedor.")
                txtRazonSocial.Focus()
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function
#End Region

    Private Sub frmProveedores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Usua.CerrandoSesion Then
            If Not genW.continuarSinGuardar(infDoc, modificado) Then _
                e.Cancel = True
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

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        setModificar()
    End Sub

    Private Sub cmbTipoProv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoProv.SelectedIndexChanged
        setModificar()
    End Sub

    Private Sub txtRazonSocial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRazonSocial.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtRazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRazonSocial.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtRazonSocial_TextChanged(sender As Object, e As EventArgs) Handles txtRazonSocial.TextChanged
        setModificar()
    End Sub

    Private Sub txtContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContacto.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContacto.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtContacto_TextChanged(sender As Object, e As EventArgs) Handles txtContacto.TextChanged
        setModificar()
    End Sub

    Private Sub txtCalle_TextChanged(sender As Object, e As EventArgs) Handles txtCalle.TextChanged
        setModificar()
    End Sub

    Private Sub txtNoExt_TextChanged(sender As Object, e As EventArgs) Handles txtNoExt.TextChanged
        setModificar()
    End Sub

    Private Sub txtNoInt_TextChanged(sender As Object, e As EventArgs) Handles txtNoInt.TextChanged
        setModificar()
    End Sub

    Private Sub txtColonia_TextChanged(sender As Object, e As EventArgs) Handles txtColonia.TextChanged
        setModificar()
    End Sub

    Private Sub txtReferencia_TextChanged(sender As Object, e As EventArgs) Handles txtReferencia.TextChanged
        setModificar()
    End Sub

    Private Sub txtLocalidad_TextChanged(sender As Object, e As EventArgs) Handles txtLocalidad.TextChanged
        setModificar()
    End Sub

    Private Sub txtMunicipio_TextChanged(sender As Object, e As EventArgs) Handles txtMunicipio.TextChanged
        setModificar()
    End Sub

    Private Sub txtEstado_TextChanged(sender As Object, e As EventArgs) Handles txtEstado.TextChanged
        setModificar()
    End Sub

    Private Sub txtPais_TextChanged(sender As Object, e As EventArgs) Handles txtPais.TextChanged
        setModificar()
    End Sub

    Private Sub txtCodigoPostal_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoPostal.TextChanged
        setModificar()
    End Sub

    Private Sub txtProvId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvId.KeyDown
        If e.KeyCode = Keys.Enter And Modop = SysEnums.Modos.mBuscar Then
            e.SuppressKeyPress = True

            buscar()
        End If
    End Sub

    Private Sub txtProvId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProvId.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub frmProveedor_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        If Not txtProvId.Text.Trim.Length.Equals(0) Then Clipboard.SetText(txtProvId.Text)
    End Sub
End Class