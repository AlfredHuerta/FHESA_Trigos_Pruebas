Imports Genericas
Imports ObjEntidades

Public Class frmCambioContrasenia
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

    Private Sub cambiarContrasenia()
        Try
            msg = Usuario.cambiarContrasenia(txtContraseniaAnterior.Text, txtNuevaContrasenia.Text, txtConfirmarContrasenia.Text).clonar
            If msg.EsError Then GoTo finalize

            msg = Usuario.actualizar().clonar
            If Not msg.EsError Then msg.setInfo("Contraseña actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible realizar el cambio de contraseña: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg)
    End Sub
#End Region

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        cambiarContrasenia()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub


    Private Sub frmCambioContrasenia_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim r As New Rectangle(10, 15, 150, 150)
        e.Graphics.DrawImage(My.Resources.usuarios, r)
    End Sub
End Class