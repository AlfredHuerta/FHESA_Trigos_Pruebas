Imports System
Imports System.Security.Cryptography
Imports System.Security.Permissions
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography.X509Certificates


Public Class Criptografo
    Private msg As Mensaje

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Sub New()
        msg = New Mensaje
    End Sub

    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider


    Public Function mostrarCertificados(ByVal pNombreAlmacen As String, ByVal pUbicAlmacen As X509Certificates.StoreLocation) As X509Certificate2
        Dim certificado As X509Certificate2 = Nothing

        Dim store As New X509Store(pNombreAlmacen, pUbicAlmacen)
        store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)
        Try

            Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
            Dim fcollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindByTimeValid, DateTime.Now, False), X509Certificate2Collection)
            Dim scollection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(fcollection, "Seleccionar Certificado de Sello Digital", _
                                                                                                    "Seleccione el Certificado deseado de la lista de abajo.", X509SelectionFlag.SingleSelection)

            For Each x509 As X509Certificate2 In scollection
                certificado = x509
            Next x509

            If certificado Is Nothing Then
                msg.setAdvertencia("No se ha seleccionado ningún certificado.")
            Else
                msg.setInfo("Certificado de Sello Digital Recuperado con éxito")
            End If
        Catch cExcept As CryptographicException
            msg.setError("No fue posible recuperar el certificado de sello digital: " + cExcept.Message)
        End Try
        store.Close()

        Return certificado
    End Function

    Public Function certificadoDesdeAlmacen(ByVal pNombreAlmacen As String, ByVal pUbicAlmacen As X509Certificates.StoreLocation, _
                                             ByVal pHuellaDigital As String) As X509Certificate2
        Dim cert As X509Certificate2 = Nothing

        Try
            msg.reset()

            Dim store As New X509Store(pNombreAlmacen, pUbicAlmacen)
            store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

            Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
            Dim fcollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindByTimeValid, DateTime.Now, False), X509Certificate2Collection)

            For Each x509 As X509Certificate2 In fcollection
                If x509.GetCertHashString() = pHuellaDigital Then
                    cert = x509
                    Exit For
                End If

                x509.Reset()
            Next x509

            store.Close()

            If cert Is Nothing Then Throw New Exception("No se encontró el certificado " + pNombreAlmacen + ".")

            msg.setInfo("Certificado " + pHuellaDigital + " encontrado.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el certificado " + pHuellaDigital + ": " + ex.Message)
        End Try

        Return cert
    End Function

    Public Sub verCertificado(ByVal pCert As X509Certificate2)
        X509Certificate2UI.DisplayCertificate(pCert)
    End Sub

    Private Shared Function MD5Hash(ByVal pValor As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pValor))
    End Function

    Public Function Encriptar(ByVal pCadena As String, ByVal pClave As String) As String
        Dim CadEncriptada As String = ""

        Try
            msg.reset()

            DES.Key = Criptografo.MD5Hash(pClave)
            DES.Mode = CipherMode.ECB

            Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(pCadena)

            CadEncriptada = Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            msg.setError("No fue posible realizar la encriptación de la cadena: " + ex.Message)
            CadEncriptada = ""
        End Try

        Return CadEncriptada
    End Function

    Public Function Desencriptar(ByVal Cadena As String, ByVal Clave As String) As String
        Dim CadDesencriptada As String = ""
        Try
            msg.reset()

            DES.Key = Criptografo.MD5Hash(Clave)
            DES.Mode = CipherMode.ECB

            Dim Buffer As Byte() = Convert.FromBase64String(Cadena)

            CadDesencriptada = ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            msg.setError("No fue posible realizar la desencriptación de la cadena: " + ex.Message)
            CadDesencriptada = ""
        End Try

        Return CadDesencriptada
    End Function

    Public Function obtenerCDSSerie(ByVal CadNumSerie As String) As String
        Dim NoSerie As String = ""
        Dim i As Int16
        Try
            For i = 1 To CadNumSerie.Length
                If i Mod 2 = 1 Then
                    NoSerie += CadNumSerie(i)
                End If
            Next

            msg.setInfo("Número de serie del certificado recuperado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible obtener el número de serie del certificado: " + ex.Message)
            NoSerie = ""
        End Try

        Return NoSerie
    End Function

    Public Function aMD5(ByVal pCadena As String) As String
        Dim cadBytes As Byte() = Nothing
        Dim Hash As Byte() = Nothing
        Dim encriptado As String = ""

        Try
            msg.reset()

            Dim md5 As New MD5CryptoServiceProvider
            cadBytes = Encoding.UTF8.GetBytes(pCadena)

            Hash = md5.ComputeHash(cadBytes)

            md5.Clear()

            For i = 0 To Hash.Length - 1
                encriptado &= Hash(i).ToString("x").PadLeft(2, "0")
            Next

            msg.setInfo("Cadena encriptada correctamente a MD5.")
        Catch ex As Exception
            msg.setError("No fue posible encriptar la cadena a MD5: " + ex.Message)
            encriptado = ""
        End Try

        Return encriptado
    End Function
End Class
