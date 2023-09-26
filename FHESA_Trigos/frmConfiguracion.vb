Imports Genericas
Imports ObjEntidades

Public Class frmConfiguracion
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil


    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean

    Private Conf As Configuracion

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
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarDocumentos() As Boolean
        Get
            Return False
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
                   ByRef pConfiguracion As Configuracion, ByVal pUsuario As Usuario)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Try
            msg = New Mensaje
            cliente = pCliente
            genW = pgenW

            If inicializarControles().EsError Then GoTo finalize



            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dConfiguracion, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sConfig", "", "", "")

            Conf = pConfiguracion
            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(4)

            msg = Conf.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            If cargarConfiguracion().EsError Then GoTo finalize

            setConsultar()

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

        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dConfiguracion, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function


    Public Function setConsultar() As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesConsultar(Me).clonar()
            If msg.EsError Then GoTo finalize

            'txtAdjuntos.Enabled = False
            'txtImagenes.Enabled = False
            'txtReportes.Enabled = False

            txtServidorBd.Enabled = False
            txtBaseDatos.Enabled = False
            txtUsuarioBd.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dConfiguracion, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sConfig", _
                                              Conf.ConfId, "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar
            modificado = False

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

        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Modificar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function


    Private Function generarOrigenDatos() As Mensaje
        Try
            msg.reset()

            Conf.actualizarValores("0", txtAdjuntos.Text, txtImagenes.Text, txtReportes.Text, txtTnlmax.Text, txtTnlmin.Text, _
                                 txtAlAmarilla.Text, txtAlRoja.Text, "0", Format(Now, "yyyy-MM-ddTHH:mm:dd"), _
                                 txtRazonSocial.Text, txtCalle.Text, txtNoExt.Text, txtNoInt.Text, txtColonia.Text, _
                                 txtReferencia.Text, txtLocalidad.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, _
                                 txtCodigoPostal.Text)

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarConfiguracion() As Mensaje
        Try
            msg.reset()

            txtRazonSocial.Text = Conf.Nombre
            txtCalle.Text = Conf.Calle
            txtNoExt.Text = Conf.Noext
            txtNoInt.Text = Conf.Noint
            txtColonia.Text = Conf.Colonia
            txtReferencia.Text = Conf.Rferenc
            txtMunicipio.Text = Conf.Mnicipio
            txtEstado.Text = Conf.Estado
            txtPais.Text = Conf.Pais
            txtCodigoPostal.Text = Conf.Cdgstl

            txtAdjuntos.Text = Conf.Carpanx
            txtImagenes.Text = Conf.Carpimg
            txtReportes.Text = Conf.CarpImp

            txtTnlmin.Text = Conf.Tnlmin
            txtTnlmax.Text = Conf.Tnlmax
            txtAlAmarilla.Text = Conf.Difmin
            txtAlRoja.Text = Conf.Difmax

            txtServidorBd.Text = My.Settings.Servidor
            txtBaseDatos.Text = My.Settings.BaseDatos
            txtUsuarioBd.Text = My.Settings.login

        Catch ex As Exception
            msg.setError("No fue posible cargar la configuración: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
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

            msg = Conf.actualizar().clonar()
            genW.publicar(infDoc, msg)

            If msg.EsError Then GoTo finalize

            setConsultar()
        Catch ex As Exception
            msg.setError("No fue posible modificar la Configuración General: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function validarDatos() As Mensaje
        Try
            msg.reset()

            If txtTnlmin.Text.Trim.Equals(0) Then txtTnlmin.Text = "0"
            If txtTnlmax.Text.Trim.Equals(0) Then txtTnlmax.Text = "120"

            If txtAlAmarilla.Text.Trim.Equals(0) Then txtTnlmin.Text = "0"
            If txtAlRoja.Text.Trim.Equals(0) Then txtTnlmin.Text = "0"

            If txtRazonSocial.Text.Trim.Length.Equals(0) Then
                msg.setError("No se ha definido la Razón Social.")
                txtRazonSocial.Focus()
            End If

        Catch ex As Exception
            msg.setError("No fue posible validar los datos del documento: " + ex.Message)
        End Try

        If msg.EsError Then genW.publicar(infDoc, msg)
        Return msg
    End Function

    Private Sub reconfigurarConexion()

        Try
            msg.setPregunta("Todos los cambios sobre documentos abiertos no se guardarán. ¿Seguro que desea continuar cerrando la sesión?")
            genW.publicar(infDoc, msg)

            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                msg.setInfo(msg.Descripcion + ": Sí")
                genW.publicar(infDoc, msg)

                Usua.cerrarSesion()
                For Each ChildForm As Form In Me.MdiParent.MdiChildren
                    If Not ChildForm.Name = "frmConfiguracion" Then ChildForm.Close()
                Next

                Me.Visible = False
                Dim frmConexion As frmConexion = New frmConexion(True)
                frmConexion.ShowDialog()

                msg = frmConexion.Mensaje

                If Not msg.EsError Then
                    Application.Restart()
                Else
                    Me.Visible = True
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible reconfigurar la conexión: " + ex.Message)
            Usua.abrirSesion()
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub
#End Region

    Private Sub frmProveedores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Usua.CerrandoSesion Then
            If Not genW.continuarSinGuardar(infDoc, modificado) Then _
                e.Cancel = True
        End If
    End Sub


    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Select Case Modop
            Case SysEnums.Modos.mModificar
                modificar()
            Case SysEnums.Modos.mConsultar
                Me.Close()
        End Select
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtRazonSocial_TextChanged(sender As Object, e As EventArgs) Handles txtRazonSocial.TextChanged
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

    Private Sub cmdAdjuntos_Click(sender As Object, e As EventArgs) Handles cmdAdjuntos.Click
        Dim dir As String = genW.obtenerCarpeta()

        If Not dir.Length.Equals(0) Then txtAdjuntos.Text = dir
    End Sub

    Private Sub txtAdjuntos_TextChanged(sender As Object, e As EventArgs) Handles txtAdjuntos.TextChanged
        setModificar()
    End Sub

    Private Sub cmdImagenes_Click(sender As Object, e As EventArgs) Handles cmdImagenes.Click
        Dim dir As String = genW.obtenerCarpeta()

        If Not dir.Length.Equals(0) Then txtImagenes.Text = dir
    End Sub

    Private Sub txtImagenes_TextChanged(sender As Object, e As EventArgs) Handles txtImagenes.TextChanged
        setModificar()
    End Sub

    Private Sub cmdReportes_Click(sender As Object, e As EventArgs) Handles cmdReportes.Click
        Dim dir As String = genW.obtenerCarpeta()

        If Not dir.Length.Equals(0) Then txtReportes.Text = dir
    End Sub

    Private Sub txtReportes_TextChanged(sender As Object, e As EventArgs) Handles txtReportes.TextChanged
        setModificar()
    End Sub

    Private Sub txtTnlmin_TextChanged(sender As Object, e As EventArgs) Handles txtTnlmin.TextChanged
        setModificar()
    End Sub

    Private Sub txtTnlmax_TextChanged(sender As Object, e As EventArgs) Handles txtTnlmax.TextChanged
        setModificar()
    End Sub

    Private Sub txtAlAmarilla_TextChanged(sender As Object, e As EventArgs) Handles txtAlAmarilla.TextChanged
        setModificar()
    End Sub

    Private Sub txtAlRoja_TextChanged(sender As Object, e As EventArgs) Handles txtAlRoja.TextChanged
        setModificar()
    End Sub

    Private Sub cmbConexion_Click(sender As Object, e As EventArgs) Handles cmbConexion.Click
        reconfigurarConexion()
    End Sub
End Class