Imports Genericas
Imports IfcDatos

Partial Public Class Venta
    Private msg As Mensaje
    Private iVen As iVenta

    Private sVentaId As String
    Private sTonventa As String
    Private sOrdenId As String
    Private sFchventa As String
    Private sEstadoId As String
    Private sObsrv As String
    Private sFchcrea As String
    Private sFchmod As String
    Private sUsrcrea As String
    Private sUsrmod As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property VentaId() As String
        Get
            Return sVentaId
        End Get
    End Property
    Public ReadOnly Property Tonventa() As String
        Get
            Return sTonventa
        End Get
    End Property
    Public ReadOnly Property OrdenId() As String
        Get
            Return sOrdenId
        End Get
    End Property
    Public ReadOnly Property Fchventa() As String
        Get
            Return sFchventa
        End Get
    End Property
    Public ReadOnly Property EstadoId() As String
        Get
            Return sEstadoId
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
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
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

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pVentaid As String, ByVal pTonventa As Decimal, ByVal pOrdenid As String, _
                   ByVal pFchventa As String, ByVal pEstadoid As String, ByVal pObsrv As String, ByVal pFchcrea As String, _
                   ByVal pFchmod As String, ByVal pUsrcrea As String, ByVal pUsrmod As String)
        msg = New Mensaje

        iVen = New iVenta(pCliente)

        sVentaId = pVentaid
        sTonventa = pTonventa
        sOrdenId = pOrdenid
        sFchventa = pFchventa
        sEstadoId = pEstadoid
        sObsrv = pObsrv
        sFchcrea = pFchcrea
        sFchmod = pFchmod
        sUsrcrea = pUsrcrea
        sUsrmod = pUsrmod

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pVentaId As String)
        msg = New Mensaje
        iVen = New iVenta(pCliente)

        buscarVenta(pVentaId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iVen = New iVenta(pCliente)

        reiniciar()
    End Sub

    Private Function buscarVenta(ByVal pVentaId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iVen.leer(pVentaId)
            msg = iVen.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sVentaId = gen3E.valorCampo(resultados, 0, "VentaId")
            sTonventa = gen3E.valorCampo(resultados, 0, "Tonventa")
            sOrdenId = gen3E.valorCampo(resultados, 0, "OrdenId")
            sFchventa = gen3E.valorCampo(resultados, 0, "Fchventa")
            sEstadoId = gen3E.valorCampo(resultados, 0, "EstadoId")
            sObsrv = gen3E.valorCampo(resultados, 0, "Obsrv")
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")


            msg.setInfo("Venta " + pVentaId + " buscada y encontrada desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar la Venta desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sVentaId = iVen.siguienteNo().ToString
            msg = iVen.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iVen.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iVen.escribir(sVentaId, sTonventa, sOrdenId, sFchventa, sEstadoId, sObsrv, sFchcrea, _
                                sFchmod, sUsrcrea, sUsrmod).clonar()

            If msg.EsError Then
                iVen.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iVen.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iVen.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Venta " + sVentaId + " creada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function ventaAnterior(ByVal pVentaId As String) As String
        Dim ven As String = iVen.ventaAnterior(pVentaId)
        If iVen.Mensaje.EsError Then Throw New Exception(iVen.Mensaje.Descripcion)

        Return ven
    End Function

    Public Function ventaSiguiente(ByVal pVentaId As String) As String
        Dim ven As String = iVen.ventaSiguiente(pVentaId)
        If iVen.Mensaje.EsError Then Throw New Exception(iVen.Mensaje.Descripcion)

        Return ven
    End Function

    Public Function buscarCambios(ByVal pVentaId As String) As DataTable
        Dim resultados As DataTable = iVen.buscarCambios(pVentaId)
        If iVen.Mensaje.EsError Then Throw New Exception(iVen.Mensaje.Descripcion)

        Return resultados
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iVen.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iVen.actualizar(sVentaId, sTonventa, sOrdenId, sFchventa, sEstadoId, sObsrv, sFchcrea, _
                                  sFchmod, sUsrcrea, sUsrmod).clonar()

esError:
            If msg.EsError Then
                iVen.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iVen.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Venta " + sVentaId + " actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sVentaId = iVen.siguienteNo()

        sTonventa = "0"
        sOrdenId = ""
        sFchventa = ""
        sEstadoId = ""
        sObsrv = ""
        sFchcrea = ""
        sFchmod = ""
        sUsrcrea = ""
        sUsrmod = ""
    End Sub

    Public Sub liberarObjetos()
        sVentaId = ""
        sTonventa = "0"
        sOrdenId = ""
        sFchventa = ""
        sEstadoId = ""
        sObsrv = ""
        sFchcrea = ""
        sFchmod = ""
        sUsrcrea = ""
        sUsrmod = ""

        iVen = Nothing
    End Sub
End Class