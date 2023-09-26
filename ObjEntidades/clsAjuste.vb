Imports Genericas
Imports IfcDatos

Partial Public Class Ajuste
    Private msg As Mensaje
    Private iAjus As iAjuste

    Private sAjustId As String
    Private sOrdenId As String
    Private sFchajus As String
    Private sCompensa As String
    Private sMerma1 As String
    Private sMerma2 As String
    Private sMerma3 As String
    Private sObsrv As String
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sEstadoId As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property AjustId() As String
        Get
            Return sAjustId
        End Get
    End Property
    Public ReadOnly Property OrdenId() As String
        Get
            Return sOrdenId
        End Get
    End Property
    Public ReadOnly Property Fchajus() As String
        Get
            Return sFchajus
        End Get
    End Property
    Public ReadOnly Property Compensa() As String
        Get
            Return sCompensa
        End Get
    End Property
    Public ReadOnly Property Merma1() As String
        Get
            Return sMerma1
        End Get
    End Property
    Public ReadOnly Property Merma2() As String
        Get
            Return sMerma2
        End Get
    End Property
    Public ReadOnly Property Merma3() As String
        Get
            Return sMerma3
        End Get
    End Property
    Public ReadOnly Property Obsrv() As String
        Get
            Return sObsrv
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
    Public ReadOnly Property EstadoId() As String
        Get
            Return sEstadoId
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pAjustid As String, ByVal pOrdenid As String, ByVal pFchajus As String, _
                   ByVal pCompensa As Decimal, ByVal pMerma1 As Decimal, ByVal pMerma2 As Decimal, ByVal pMerma3 As Decimal, _
                   ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, _
                   ByVal pUsrmod As String, ByVal pEstadoid As String)
        msg = New Mensaje

        iAjus = New iAjuste(pCliente)

        sAjustId = pAjustid
        sOrdenId = pOrdenid
        sFchajus = pFchajus
        sCompensa = pCompensa
        sMerma1 = pMerma1
        sMerma2 = pMerma2
        sMerma3 = pMerma3
        sObsrv = pObsrv
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sEstadoId = pEstadoid

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pAjustId As String)
        msg = New Mensaje
        iAjus = New iAjuste(pCliente)

        buscarAjuste(pAjustId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iAjus = New iAjuste(pCliente)

        reiniciar()
    End Sub

    Private Function buscarAjuste(ByVal pAjustId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iAjus.leer(pAjustId)
            msg = iAjus.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sAjustId = gen3E.valorCampo(resultados, 0, "AjustId")
            sOrdenId = gen3E.valorCampo(resultados, 0, "OrdenId")
            sFchajus = gen3E.valorCampo(resultados, 0, "Fchajus")
            sCompensa = gen3E.valorCampo(resultados, 0, "Compensa")
            sMerma1 = gen3E.valorCampo(resultados, 0, "Merma1")
            sMerma2 = gen3E.valorCampo(resultados, 0, "Merma2")
            sMerma3 = gen3E.valorCampo(resultados, 0, "Merma3")
            sObsrv = gen3E.valorCampo(resultados, 0, "Obsrv")
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sEstadoId = gen3E.valorCampo(resultados, 0, "EstadoId")


            msg.setInfo("Ajuste " + pAjustId + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Ajuste desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sAjustId = iAjus.siguienteNo().ToString
            msg = iAjus.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iAjus.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iAjus.escribir(sAjustId, sOrdenId, sFchajus, sCompensa, sMerma1, sMerma2, sMerma3, _
                                 sObsrv, sFchcrea, sUsrcrea, sFchmod, sUsrmod, EstadoId).clonar()

            If msg.EsError Then
                iAjus.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iAjus.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iAjus.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Ajuste " + sAjustId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function ajusteAnterior(ByVal pAjustId As String) As String
        Dim ajus As String = iAjus.ajusteAnterior(pAjustId)
        If iAjus.Mensaje.EsError Then Throw New Exception(iAjus.Mensaje.Descripcion)

        Return ajus
    End Function

    Public Function ajusteSiguiente(ByVal pAjustId As String) As String
        Dim ajus As String = iAjus.ajusteSiguiente(pAjustId)
        If iAjus.Mensaje.EsError Then Throw New Exception(iAjus.Mensaje.Descripcion)

        Return ajus
    End Function

    Public Function buscarCambios(ByVal pAjustId As String) As DataTable
        Dim resultados As DataTable = iAjus.buscarCambios(pAjustId)
        If iAjus.Mensaje.EsError Then Throw New Exception(iAjus.Mensaje.Descripcion)

        Return resultados
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iAjus.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iAjus.actualizar(sAjustId, sOrdenId, sFchajus, sCompensa, sMerma1, sMerma2, sMerma3, _
                                 sObsrv, sFchcrea, sUsrcrea, sFchmod, sUsrmod, EstadoId).clonar()

esError:
            If msg.EsError Then
                iAjus.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iAjus.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Ajuste " + sAjustId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sAjustId = iAjus.siguienteNo()

        sOrdenId = ""
        sFchajus = ""
        sCompensa = "0"
        sMerma1 = "0"
        sMerma2 = "0"
        sMerma3 = "0"
        sObsrv = ""
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sEstadoId = ""
    End Sub

    Public Sub liberarObjetos()

        sAjustId = ""
        sOrdenId = ""
        sFchajus = ""
        sCompensa = "0"
        sMerma1 = "0"
        sMerma2 = "0"
        sMerma3 = "0"
        sObsrv = ""
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sEstadoId = ""

        iAjus = Nothing
    End Sub
End Class