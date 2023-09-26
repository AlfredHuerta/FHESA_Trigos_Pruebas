Imports Genericas

Public Class frmConexion
    Private msg As Mensaje
    Private genW As GenericasWin
    Private cripto As Criptografo

    Private cliente As ClienteSql

    Private reconfigurar As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property ClienteSql() As ClienteSql
        Get
            Return cliente
        End Get
    End Property

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        genW = New GenericasWin
        cripto = New Criptografo
    End Sub

    Public Sub New(ByVal pReconfigurar As Boolean)
        InitializeComponent()

        msg = New Mensaje
        genW = New GenericasWin
        cripto = New Criptografo
        reconfigurar = pReconfigurar
    End Sub

    Private Sub frmConexion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cmdAceptar.Text.Equals("Probar") Then
            genW.mensajePantalla(New Mensaje("Debe configurar un inicio de Sesión del Servidor de SQL para poder continuar.", SysEnums.TiposMensaje.mError))
            e.Cancel = True
        End If
    End Sub

    Private Sub frmConexionSql_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            abrirConexion(My.Settings.Servidor, My.Settings.BaseDatos, My.Settings.login, _
                          My.Settings.contrasenia, My.Settings.TiempoEspera)

            If Not msg.EsError And Not reconfigurar Then
                Me.Close()
            Else
                genW.mensajePantalla(msg)

                txtServidor.Text = My.Settings.Servidor
                txtBaseDatos.Text = My.Settings.BaseDatos
                txtTiempoEspera.Text = My.Settings.TiempoEspera.ToString
                txtlogin.Text = cripto.Desencriptar(My.Settings.login, txtBaseDatos.Text)
                txtContrasenia.Text = cripto.Desencriptar(My.Settings.contrasenia, txtBaseDatos.Text)

                cmdAceptar.Text = "Probar"
            End If


        Catch ex As Exception
            msg.setError("No fue posible inicializar los parámetros de conexión: " + ex.Message)
        End Try
    End Sub

    Private Function abrirConexion(ByVal pServidor As String, ByVal pBaseDatos As String, _
                                   ByVal pLogin As String, ByVal pContrasenia As String, _
                                   ByVal pTiempoEspera As Integer) As Mensaje
        Try
            msg.reset()

            cliente = New ClienteSql(New ParametrosConexion(pServidor, pBaseDatos, pLogin, pContrasenia, pTiempoEspera, _
                                                               "", "", "", "", 0, "", "0", ""))


            msg = cliente.abrirConexion()
        Catch ex As Exception
            msg.setError("No fue posible abrir la conexión con los parámetros especificados: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If cmdAceptar.Text = "Probar" Then
            abrirConexion(txtServidor.Text, txtBaseDatos.Text, cripto.Encriptar(txtlogin.Text, txtBaseDatos.Text), _
                          cripto.Encriptar(txtContrasenia.Text, txtBaseDatos.Text), txtTiempoEspera.Text)

            If Not msg.EsError Then
                My.Settings.Servidor = txtServidor.Text
                My.Settings.BaseDatos = txtBaseDatos.Text
                My.Settings.TiempoEspera = txtTiempoEspera.Text
                My.Settings.login = cripto.Encriptar(txtlogin.Text, txtBaseDatos.Text)
                My.Settings.contrasenia = cripto.Encriptar(txtContrasenia.Text, txtBaseDatos.Text)

                My.Settings.Save()

                cmdAceptar.Text = "Cerrar"

                msg.setInfo("Los parámetros de conexión son correctos.")
            Else
                Me.Close()
            End If

            genW.mensajePantalla(msg)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        msg = cliente.Mensaje
    End Sub

    Private Sub frmConexion_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim r As New Rectangle(249, 108, 65, 65)
        e.Graphics.DrawImage(My.Resources.cambio_contrasena, r)
    End Sub
End Class