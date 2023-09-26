Imports Genericas
Imports IfcDatos
Public Class UbicacionTmp
    Private msg As Mensaje
    Private iUbtm As iUbicacionTmp

    Private sUbcTmpId As String
    Private sNombre As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property UbcTmpId() As String
        Get
            Return sUbcTmpId
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return sNombre
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
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pUbcTmpId As String, ByVal pNombre As String, ByVal pActivo As Integer, _
               ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String)
        msg = New Mensaje

        iUbtm = New iUbicacionTmp(pCliente)

        sUbcTmpId = pUbcTmpId
        sNombre = pNombre
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod

    End Sub
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pUbcTmpId As String)
        msg = New Mensaje
        iUbtm = New iUbicacionTmp(pCliente)

        buscarUbicacion(pUbcTmpId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iUbtm = New iUbicacionTmp(pCliente)

        reiniciar()
    End Sub
    Private Function buscarUbicacion(ByVal pUbcTmpId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iUbtm.leer(pUbcTmpId)
            msg = iUbtm.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sUbcTmpId = gen3E.valorCampo(resultados, 0, "UbicaId")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")



            msg.setInfo("Ubicación Temporal" + pUbcTmpId + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Ubicación Temporal desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function
    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sUbcTmpId = iUbtm.siguienteNo().ToString
            msg = iUbtm.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iUbtm.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iUbtm.escribir(sUbcTmpId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod _
                                 ).clonar()

            If msg.EsError Then
                iUbtm.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iUbtm.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iUbtm.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Ubicación Temporal " + sUbcTmpId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function
    Public Function ubicacionAnterior(ByVal pUbcTmpId As String) As String
        Dim dest As String = iUbtm.ubicacionAnterior(pUbcTmpId)
        If iUbtm.Mensaje.EsError Then Throw New Exception(iUbtm.Mensaje.Descripcion)

        Return dest
    End Function

    Public Function ubicacionSiguiente(ByVal pUbcTmpId As String) As String
        Dim dest As String = iUbtm.ubicacionSiguiente(pUbcTmpId)
        If iUbtm.Mensaje.EsError Then Throw New Exception(iUbtm.Mensaje.Descripcion)

        Return dest
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iUbtm.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iUbtm.actualizar(sUbcTmpId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod).clonar()

esError:
            If msg.EsError Then
                iUbtm.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iUbtm.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Ubicación Temporal " + sUbcTmpId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function
    Public Sub reiniciar()
        sUbcTmpId = iUbtm.siguienteNo()

        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""

    End Sub

    Public Sub liberarObjetos()
        sUbcTmpId = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""

        iUbtm = Nothing
    End Sub

End Class
