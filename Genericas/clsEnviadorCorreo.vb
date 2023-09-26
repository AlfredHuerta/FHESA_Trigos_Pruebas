Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Mime
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates


Public Class EnviadorCorreo
    Private msg As Mensaje

    Private smtp As SmtpClient
    Private networkCredential As NetworkCredential
    Private mess As MailMessage

    Private bEnvioConfigurado As Boolean

    Private correo As PropiedadesCorreo

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property PropiedadesCorreo() As PropiedadesCorreo
        Get
            Return correo
        End Get
    End Property

    Public ReadOnly Property MensajeNet() As MailMessage
        Get
            Return mess
        End Get
    End Property

    Public Sub New(ByVal pCorreo As PropiedadesCorreo)
        correo = pCorreo
        msg = New Mensaje
    End Sub


    Public Function configurar() As Mensaje
        Dim cripto As Criptografo = New Criptografo

        Try
            msg.reset()

            mess = New MailMessage

            networkCredential = New NetworkCredential(correo.CuentaCorreo, cripto.Desencriptar(correo.Contrasenia, ""))

            smtp = New SmtpClient(correo.ServidorSmtp, correo.PuertoSmtp)
            smtp.Credentials = networkCredential
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.EnableSsl = correo.Ssl_Tsl


            mess.Subject = correo.Asunto
            mess.IsBodyHtml = correo.FormatoHtml
            mess.Body = correo.TextoContenido
            mess.From = New MailAddress(correo.CuentaCorreo, correo.NombreMostrar)

            bEnvioConfigurado = True

            msg.setInfo("Configuración de parámetros generales de envío establecida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible configurar la instancia SMTP: " + ex.Message)
            bEnvioConfigurado = False

        End Try

        Return msg
    End Function

    Public Sub limpiarInfoDestino()
        mess.To.Clear()

        For Each adj As Attachment In mess.Attachments
            adj.Dispose()
        Next

        mess.Attachments.Clear()
    End Sub

    Public Function enviarMensaje() As Mensaje
        Dim msgExito As String = ""

        Try
            msg.reset()

            If Not bEnvioConfigurado Then
                msg.setError("Los datos de envío aún no se encuentran configurados. El proceso no continuará.")
                GoTo finalize
            End If

            If correo.ValidarCertificadoRemoto Then
                ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            End If

            smtp.Send(mess)

            msgExito = "Mensaje enviado correctamente a " + correo.Para

            If correo.ConCopia.Trim.Length > 0 Then
                msgExito += ", Con Copia para " + correo.ConCopia
            End If

            If correo.ConCopiaOculta.Trim.Length > 0 Then
                msgExito += ", Con Copia oculta para " + correo.ConCopiaOculta
            End If

            msg.setExclamacion(msgExito)
        Catch ex As Exception
            Dim serror As String = "No fue posible enviar el mensaje: " + ex.Message
            If Not ex.InnerException Is Nothing Then serror += " (" + ex.InnerException.Message + ")"
            msg.setError(serror)
        End Try

finalize:
        Return msg
    End Function

    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, _
                                        ByVal sslPolicyErrors As SslPolicyErrors) As Boolean
        Return True
    End Function

    Public Function adjuntarPdf(ByVal sPathToFile As String) As Mensaje
        Dim attach As Attachment = New Attachment(sPathToFile, MediaTypeNames.Application.Octet)

        Try
            msg.reset()

            If (File.Exists(sPathToFile)) Then mess.Attachments.Add(attach)

            msg.setInfo("Medio " + sPathToFile + " adjuntado correctamente.")
        Catch e As Exception
            msg.setError("No fue posible adjuntar el medio " + sPathToFile + ". El proceso no continuará.")
        End Try

        Return msg
    End Function

    Public Function adjuntarXml(ByVal sPathToFile As String) As Mensaje
        Dim attach As Attachment = New Attachment(sPathToFile, MediaTypeNames.Text.Xml)

        Try
            msg.reset()

            If (File.Exists(sPathToFile)) Then mess.Attachments.Add(attach)

            msg.setInfo("Medio " + sPathToFile + " adjuntado correctamente.")
        Catch e As Exception
            msg.setError("No fue posible adjuntar el medio " + sPathToFile + ". El proceso no continuará.")
        End Try

        Return msg
    End Function

    Public Function cuentaDestino(ByVal pCuenta As String) As Mensaje
        Dim AddreesTo As MailAddress = New MailAddress(pCuenta)

        Try
            msg.reset()

            mess.To.Add(AddreesTo)

            msg.setInfo("Dirección de envío " + pCuenta + " definida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible definir la dirección de envío: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function cuentaDestino(ByVal pCuenta As String, ByVal sName As String) As Mensaje
        Dim AddressTo As MailAddress = New MailAddress(pCuenta, sName)
        Try
            msg.reset()

            mess.To.Add(AddressTo)

            msg.setInfo("Dirección de envío " + pCuenta + " definida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible definir la dirección de envío: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function conCopia(ByVal pCuenta As String) As Mensaje
        Dim cco As MailAddress = New MailAddress(pCuenta)
        Try
            msg.reset()

            mess.CC.Add(cco)

            msg.setInfo("Dirección de envío " + pCuenta + " (con copia) definida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible definir la dirección de envío (con copia): " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function conCopia(ByVal pCuenta As String, ByVal sName As String) As Mensaje
        Dim cco As MailAddress = New MailAddress(pCuenta, sName)

        Try
            msg.reset()

            mess.CC.Add(cco)

            msg.setInfo("Dirección de envío " + pCuenta + " (con copia) definida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible definir la dirección de envío (con copia): " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function conCopiaOculta(ByVal pCuenta As String) As Mensaje
        Dim cco As MailAddress = New MailAddress(pCuenta)
        Try
            msg.reset()

            mess.Bcc.Add(cco)

            msg.setInfo("Dirección de envío " + pCuenta + " (copia oculta) definida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible definir la dirección de envío (copia oculta): " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function conCopiaOculta(ByVal pCuenta As String, ByVal sName As String) As Mensaje
        Dim cco As MailAddress = New MailAddress(pCuenta, sName)

        Try
            msg.reset()

            mess.Bcc.Add(cco)

            msg.setInfo("Dirección de envío " + pCuenta + " (copia oculta) definida con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible definir la dirección de envío (copia oculta): " + ex.Message)
        End Try

        Return msg
    End Function

    Public Sub terminar()
        limpiarInfoDestino()
        mess.Attachments.Dispose()

        correo = Nothing

        smtp = Nothing
        networkCredential = Nothing
        mess = Nothing

        bEnvioConfigurado = False
    End Sub
End Class