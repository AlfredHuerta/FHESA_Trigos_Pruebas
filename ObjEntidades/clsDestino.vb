Imports Genericas
Imports IfcDatos

Partial Public Class Destino
    Private msg As Mensaje
    Private iDest As iDestino

    Private sDstinoId As String
    Private sNombre As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sDstnidan As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property DstinoId() As String
        Get
            Return sDstinoId
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
    Public ReadOnly Property Dstnidan() As String
        Get
            Return sDstnidan
        End Get
    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pDstinoid As String, ByVal pNombre As String, ByVal pActivo As Integer, _
                   ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, _
                   ByVal pDstnidan As String)
        msg = New Mensaje

        iDest = New iDestino(pCliente)

        sDstinoId = pDstinoid
        sNombre = pNombre
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sDstnidan = pDstnidan


    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pDstinoId As String)
        msg = New Mensaje
        iDest = New iDestino(pCliente)

        buscarDestino(pDstinoId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iDest = New iDestino(pCliente)

        reiniciar()
    End Sub

    Private Function buscarDestino(ByVal pDstinoId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iDest.leer(pDstinoId)
            msg = iDest.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sDstinoId = gen3E.valorCampo(resultados, 0, "DstinoId")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sDstnidan = gen3E.valorCampo(resultados, 0, "Dstnidan")


            msg.setInfo("Destino " + pDstinoId + " buscado y encontrado desde su origen de datos.")
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
            sDstinoId = iDest.siguienteNo().ToString
            msg = iDest.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iDest.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iDest.escribir(sDstinoId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, _
                                 sDstnidan).clonar()

            If msg.EsError Then
                iDest.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iDest.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iDest.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Destino " + sDstinoId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function destinoAnterior(ByVal pDstinoId As String) As String
        Dim dest As String = iDest.destinoAnterior(pDstinoId)
        If iDest.Mensaje.EsError Then Throw New Exception(iDest.Mensaje.Descripcion)

        Return dest
    End Function

    Public Function destinoSiguiente(ByVal pDstinoId As String) As String
        Dim dest As String = iDest.destinoSiguiente(pDstinoId)
        If iDest.Mensaje.EsError Then Throw New Exception(iDest.Mensaje.Descripcion)

        Return dest
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iDest.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iDest.actualizar(sDstinoId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, _
                                 sDstnidan).clonar()

esError:
            If msg.EsError Then
                iDest.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iDest.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Destino " + sDstinoId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sDstinoId = iDest.siguienteNo()

        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sDstnidan = ""

    End Sub

    Public Sub liberarObjetos()
        sDstinoId = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sDstnidan = ""

        iDest = Nothing
    End Sub
End Class
