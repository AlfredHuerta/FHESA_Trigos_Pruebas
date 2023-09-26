Imports Genericas
Imports ObjEntidades

Public Class frmSesion
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Cnfg As Configuracion

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean = False
    Private forzarBusqueda As Boolean = False

    Private sesion As Sesion
    Private usua As Usuario

    Private bSesionIni As Boolean

    Public ReadOnly Property Usuario() As Usuario
        Get
            Return usua
        End Get
    End Property

    Public ReadOnly Property SesionIniciada() As Boolean
        Get
            Return bSesionIni
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
           ByVal pConfiguracion As Configuracion)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try

            Cnfg = pConfiguracion

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUsuario, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sUsuarios", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible inicializar la ventana: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
    End Sub

    Private Function iniciarSesion() As Mensaje
        Try
            usua = New Usuario(cliente)
            msg = usua.cargarPorSesion(cliente, txtNkname.Text, txtCntrsnia.Text)
            genW.publicar(infDoc, msg)

            If Not msg.EsError Then
                My.Settings.Nkname = txtNkname.Text
                My.Settings.Save()

                bSesionIni = True
                Me.Close()
            Else
                bSesionIni = False
                Beep()
            End If
        Catch ex As Exception
            msg.setError("No fue posible iniciar la sesión: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Function cancelarSesion() As Boolean
        msg.setPregunta("No ha iniciado sesión en Logística de Trigos. ¿Desea cerrar el programa?")
        If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Return True
        End If

        Return False
    End Function

    Private Sub procesarInicioSesion()
        If Not txtNkname.Text.Length.Equals(0) Then
            If txtCntrsnia.Text.Length.Equals(0) Then
                genW.publicar(infDoc, New Mensaje("El campo de Contraseña de usuario no se puede encontrar vacío.", SysEnums.TiposMensaje.mError))
                txtCntrsnia.Focus()
            Else
                iniciarSesion()
            End If
        Else
            genW.publicar(infDoc, New Mensaje("El campo de Nombre de Id. de usuario no se puede encontrar vacío.", SysEnums.TiposMensaje.mError))
            txtNkname.Focus()
        End If
    End Sub
#End Region

    Private Sub frmSesion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not bSesionIni Then e.Cancel = Not cancelarSesion()
    End Sub


    Private Sub frmSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBaseDatos.Enabled = False
        txtBaseDatos.Text = My.Settings.BaseDatos
        txtNkname.Text = My.Settings.Nkname
    End Sub


    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        iniciarSesion()
    End Sub


    Private Sub txtNkname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNkname.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            procesarInicioSesion()
        End If

    End Sub

    Private Sub txtCntrsnia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCntrsnia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            procesarInicioSesion()
        End If
    End Sub

    Private Sub frmSesion_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim r As New Rectangle(10, 15, 200, 150)
        e.Graphics.DrawImage(My.Resources.log_trig_003, r)
    End Sub
End Class