
Imports System.Security.Cryptography
Imports Genericas
Imports IfcDatos
Partial Public Class clsSilos
    Private msg As Mensaje
    Private iSilos As clsiSilos

    Private sDestinoId As String
    Private sSiloId As String
    Private bActivo As String
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sUsrmod As String
    Private sFchmod As String
    Private sDescripcion As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property DestinoId() As String
        Get
            Return sDestinoId
        End Get
    End Property

    Public ReadOnly Property SiloId() As String
        Get
            Return sSiloId
        End Get
    End Property

    Public ReadOnly Property Activo() As Boolean
        Get
            Return bActivo
        End Get
    End Property

    Public ReadOnly Property Fchcrea() As String
        Get
            Return sFchcrea
        End Get
    End Property

    Public ReadOnly Property Usrcrea() As String
        Get
            Return sUsrcrea
        End Get
    End Property

    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property

    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return sDescripcion
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pDestinoid As String, ByVal pSiloid As String, ByVal pActivo As Integer,
                   ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchmod As String,
                   ByVal pDescripcion As String)
        msg = New Mensaje

        iSilos = New clsiSilos(pCliente)

        sDestinoId = pDestinoid
        sSiloId = pSiloid
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sUsrmod = pUsrmod
        sFchmod = pFchmod
        sDescripcion = pDescripcion


    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pDestinoid As String, ByVal pSiloid As String)
        msg = New Mensaje
        iSilos = New clsiSilos(pCliente)

        buscarSilo(pDestinoid, pSiloid)
    End Sub

    Private Function buscarSilo(ByVal pDestinoid As String, ByVal pSiloid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iSilos.leer(pDestinoid, pSiloid)
            msg = iSilos.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sDestinoId = gen3E.valorCampo(resultados, 0, "DestinoId")
            sSiloId = gen3E.valorCampo(resultados, 0, "SiloId")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            sDescripcion = gen3E.valorCampo(resultados, 0, "Descripcion")


            msg.setInfo("Destino " + pDestinoid + "y Silo" + pSiloid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Destino desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing
        Try

            msg = iSilos.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iSilos.escribir(sDestinoId, sSiloId, bActivo, sFchcrea, sUsrcrea, sUsrmod, sFchmod,
                                 sDescripcion).clonar()
            If msg.EsError Then
                iSilos.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iSilos.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iSilos.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Silo " + sSiloId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iSilos.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iSilos.actualizar(sDestinoId, sSiloId, bActivo, sFchcrea, sUsrcrea, sUsrmod, Fchmod,
                                 sDescripcion).clonar()

esError:
            If msg.EsError Then
                iSilos.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iSilos.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Silo " + sSiloId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub liberarObjetos()
        sDestinoId = ""
        sSiloId = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sDescripcion = ""

        iSilos = Nothing
    End Sub


End Class
