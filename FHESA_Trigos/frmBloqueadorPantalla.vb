Imports Genericas
Imports ObjEntidades

Public Class frmBloqueadorPantalla
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Cnfg As Configuracion

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean = False
    Private forzarBusqueda As Boolean = False

    Private usua As Usuario

    Public ReadOnly Property Usuario() As Usuario
        Get
            Return usua
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
           ByVal pConfiguracion As Configuracion, ByVal pUsuario As Usuario)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW

        Try

            Cnfg = pConfiguracion
            usua = pUsuario
            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dUsuario, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sUsuarios", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible inicializar la ventana: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub evaluarContrasenia()
        If Not usua.validarContrasenia(txtContrasenia.Text).EsError Then
            Me.Close()
        Else
            Beep()
            genW.publicar(infDoc, Usuario.Mensaje)
        End If
    End Sub
#End Region

    Private Sub frmBloqueadorPantalla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblBloqueadoPor.Text = "Bloqueado por " + usua.Nombre + " " + usua.Apllidop + " " + usua.Apllidom
    End Sub

    Private Sub cmbDesbloquear_Click(sender As Object, e As EventArgs) Handles cmbDesbloquear.Click
        evaluarContrasenia()
    End Sub

    Private Sub txtContrasenia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContrasenia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            evaluarContrasenia()
        End If
    End Sub

    Private Sub frmBloqueadorPantalla_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim r As New Rectangle(50, 50, 190, 190)
        e.Graphics.DrawImage(My.Resources.log_trig_001, r)
    End Sub
End Class