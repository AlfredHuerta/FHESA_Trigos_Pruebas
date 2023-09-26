Imports Genericas
Imports IfcDatos

Partial Public Class Sesion
    Private msg As Mensaje
    Private ises As iSesion

    Private sLogId As String
    Private sUsrId As String
    Private sFchconex As String
    Private sHostId As String
    Private bconexion As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property LogId() As String        Get            Return sLogId        End Get    End Property
    Public ReadOnly Property UsrId() As String        Get            Return sUsrId        End Get    End Property
    Public ReadOnly Property Fchconex() As String        Get            Return sFchconex        End Get    End Property
    Public ReadOnly Property HostId() As String        Get            Return sHostId        End Get    End Property
    Public ReadOnly Property conexion() As Boolean        Get            Return bconexion        End Get    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pLogid As Integer, ByVal pUsrid As String, ByVal pFchconex As String, ByVal pHostid As Integer, ByVal pconexion As Integer)
        msg = New Mensaje

        ises = New iSesion(pCliente)

        sLogId = pLogid
        sUsrId = pUsrid
        sFchconex = pFchconex
        sHostId = pHostid
        bconexion = pconexion

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pLogid As String)
        msg = New Mensaje
        ises = New iSesion(pCliente)

        buscarSesion(pLogid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        ises = New iSesion(pCliente)

        reiniciar()
    End Sub

    Private Function buscarSesion(ByVal pLogid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = ises.leer(pLogid)
            msg = ises.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sLogId = gen3E.valorCampo(resultados, 0, "LogId")
            sUsrId = gen3E.valorCampo(resultados, 0, "UsrId")
            sFchconex = gen3E.valorCampo(resultados, 0, "Fchconex")
            sHostId = gen3E.valorCampo(resultados, 0, "HostId")
            bconexion = Boolean.Parse(gen3E.valorCampo(resultados, 0, "conexion", "false"))


            msg.setInfo("Sesión " + pLogid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar la Sesión desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sLogId = ises.siguienteNo().ToString
            msg = ises.Mensaje
            If msg.EsError Then GoTo finalize


            msg = ises.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = ises.escribir(sLogId, sUsrId, sFchconex, sHostId, bconexion).clonar()

            If msg.EsError Then
                ises.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                ises.cancelarTransaccion()
                GoTo finalize
            End If

            msg = ises.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Registro de Sesión " + sLogId + " creada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = ises.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = ises.actualizar(sLogId, sUsrId, sFchconex, sHostId, bconexion).clonar()

esError:
            If msg.EsError Then
                ises.cancelarTransaccion()
                GoTo finalize
            End If

            msg = ises.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Registro de Sesión " + sLogId + " actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sLogId = ises.siguienteNo()

        sUsrId = ""
        sFchconex = ""
        sHostId = ""
        bconexion = "0"
    End Sub

    Public Sub liberarObjetos()
        sLogId = ""
        sUsrId = ""
        sFchconex = ""
        sHostId = ""
        bconexion = "0"

        ises = Nothing
    End Sub
End Class