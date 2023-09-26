Imports Genericas

Public Class iOrden
    Private msg As Mensaje

    Private puenteSql As ClienteSql

    Private stipoExpr As String
    Private sqlDirecto As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property


    Public Sub New(ByVal pClienteSql As ClienteSql)
        msg = New Mensaje
        puenteSql = pClienteSql
        sqlDirecto = True
    End Sub

    Public Function siguienteNo() As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(1, "", "", "", "", 0, "", "", "", "", "", "", 0, 0,
                                  0, "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                  "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pOrdenid As String, ByVal pCtrtoid As String, ByVal pLoteid As String, ByVal pOrigenid As String, ByVal pTnladas As Decimal, ByVal pTlrancia As String, ByVal pPeremb As String, ByVal pIncoterm As String, ByVal pRitmo As String, ByVal pMoneda As String, ByVal pRefftro As String, ByVal pBase As Decimal, ByVal pMesfutu As Decimal, ByVal pPrcionto As Decimal, ByVal pObsrv As String, ByVal pLaycan As String, ByVal pPtocarga As String, ByVal pPtodscg As String, ByVal pNorcg As String, ByVal pNordscg As String, ByVal pLaytime As String, ByVal pCondpgo As String, ByVal pTasadmra As String, ByVal pUsrmod As String, ByVal pUsrcrea As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pProvid As String, ByVal pFchord As String, ByVal pRspnsble As String, ByVal pRitmod As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pOrdenid, pCtrtoid, pLoteid, pOrigenid, pTnladas, pTlrancia, pPeremb,
                     pIncoterm, pRitmo, pMoneda, pRefftro, pBase, pMesfutu, pPrcionto, pObsrv, pLaycan,
                     pPtocarga, pPtocarga, pNorcg, pNordscg, pLaytime, pCondpgo, pTasadmra, pUsrmod, pUsrcrea,
                     pFchcrea, pFchcrea, pEstadoid, pProvid, pFchord, pRspnsble, pRitmod)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pOrdenid As String, ByVal pCtrtoid As String, ByVal pLoteid As String, ByVal pOrigenid As String, ByVal pTnladas As Decimal, ByVal pTlrancia As String, ByVal pPeremb As String, ByVal pIncoterm As String, ByVal pRitmo As String, ByVal pMoneda As String, ByVal pRefftro As String, ByVal pBase As Decimal, ByVal pMesfutu As Decimal, ByVal pPrcionto As Decimal, ByVal pObsrv As String, ByVal pLaycan As String, ByVal pPtocarga As String, ByVal pPtodscg As String, ByVal pNorcg As String, ByVal pNordscg As String, ByVal pLaytime As String, ByVal pCondpgo As String, ByVal pTasadmra As String, ByVal pUsrmod As String, ByVal pUsrcrea As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pProvid As String, ByVal pFchord As String, ByVal pRspnsble As String, ByVal pRitmod As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pOrdenid, pCtrtoid, pLoteid, pOrigenid, pTnladas, pTlrancia, pPeremb,
                     pIncoterm, pRitmo, pMoneda, pRefftro, pBase, pMesfutu, pPrcionto, pObsrv, pLaycan,
                     pPtocarga, pPtocarga, pNorcg, pNordscg, pLaytime, pCondpgo, pTasadmra, pUsrmod, pUsrcrea,
                     pFchcrea, pFchcrea, pEstadoid, pProvid, pFchord, pRspnsble, pRitmod)

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function actualizarEmbarques(ByVal pOrdenid As String, ByVal pEstadoid As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutarActEdoEmb(pOrdenid, pEstadoid)

        Catch ex As Exception
            msg.setError("No fue posible actualizar Embarques derivados: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function actualizarVentas(ByVal pOrdenid As String, ByVal pEstadoid As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutarActEdoVta(pOrdenid, pEstadoid)

        Catch ex As Exception
            msg.setError("No fue posible actualizar Ventas derivadas: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function actualizarAjustes(ByVal pOrdenid As String, ByVal pEstadoid As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutarActEdoAju(pOrdenid, pEstadoid)

        Catch ex As Exception
            msg.setError("No fue posible actualizar Ajustes derivados: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pOrdenId, "", "", "", 0, "", "", "", "", "", "", 0, 0,
                                  0, "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                  "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró la Orden " + pOrdenId + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el documento: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function ordenAnterior(ByVal pOrdenId As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pOrdenId, "", "", "", 0, "", "", "", "", "", "", 0, 0,
                                  0, "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                  "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "OrdenId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el documento anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function ordenSiguiente(ByVal pOrdenId As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pOrdenId, "", "", "", 0, "", "", "", "", "", "", 0, 0,
                                  0, "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                  "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "OrdenId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el documento siguiente al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function buscarCambios(ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, pOrdenId, "", "", "", 0, "", "", "", "", "", "", 0, 0,
                                  0, "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                  "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el historial de cambios de la Orden: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function iniciarTransaccion(ByVal pNivelAislamiento As System.Data.IsolationLevel) As Mensaje
        Try
            stipoExpr = "E"
            msg = puenteSql.iniciarTransaccion(pNivelAislamiento)

        Catch ex As Exception
            msg.setError("No fue posible inicializar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function cancelarTransaccion() As Mensaje
        Try
            stipoExpr = "E"
            msg = puenteSql.cancelarTransaccion()

        Catch ex As Exception
            msg.setError("No fue posible inicializar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function terminarTransaccion() As Mensaje
        Try
            stipoExpr = "E"
            msg = puenteSql.terminarTransaccion()

        Catch ex As Exception
            msg.setError("No fue posible inicializar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function cerrarConexion() As Mensaje
        Try
            stipoExpr = "E"
            msg = puenteSql.cerrarConexion()

        Catch ex As Exception
            msg.setError("No fue posible inicializar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pOrdenid As String, ByVal pCtrtoid As String, ByVal pLoteid As String, ByVal pOrigenid As String, ByVal pTnladas As Decimal, ByVal pTlrancia As String, ByVal pPeremb As String, ByVal pIncoterm As String, ByVal pRitmo As String, ByVal pMoneda As String, ByVal pRefftro As String, ByVal pBase As Decimal, ByVal pMesfutu As Decimal, ByVal pPrcionto As Decimal, ByVal pObsrv As String, ByVal pLaycan As String, ByVal pPtocarga As String, ByVal pPtodscg As String, ByVal pNorcg As String, ByVal pNordscg As String, ByVal pLaytime As String, ByVal pCondpgo As String, ByVal pTasadmra As String, ByVal pUsrmod As String, ByVal pUsrcrea As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pProvid As String, ByVal pFchord As String, ByVal pRspnsble As String, ByVal pRitmod As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sOrdenes] " + pOpcion.ToString + ", '" + pOrdenid + "', '" + pCtrtoid + "', '" + pLoteid + "', '" + pOrigenid + "', " + pTnladas.ToString + ", '" + pTlrancia + "', '" + pPeremb + "', '" + pIncoterm + "', '" + pRitmo + "', '" + pMoneda + "', '" + pRefftro + "', " + pBase.ToString + ", " + pMesfutu.ToString + ", " + pPrcionto.ToString + ", '" + pObsrv + "', '" + pLaycan + "', '" + pPtocarga + "', '" + pPtodscg + "', '" + pNorcg + "', '" + pNordscg + "', '" + pLaytime + "', '" + pCondpgo + "', '" + pTasadmra + "', '" + pUsrmod + "', '" + pUsrcrea + "', '" + pFchcrea + "', '" + pFchmod + "', '" + pEstadoid + "', '" + pProvid + "', '" + pFchord + "', '" + pRspnsble + "', '" + pRitmod + "'"


            If stipoExpr = "S" Then
                resultados = puenteSql.ejecutarConsulta(consulta)
            Else
                puenteSql.ejecutarExpresion(consulta)
            End If

            msg = puenteSql.Mensaje
        Catch ex As Exception
            msg.setError("No fue posible ejecutar la consulta: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Private Function ejecutarActEdoEmb(ByVal pOrdenid As String, ByVal pEstadoid As String) As DataTable        Dim consulta As String = ""        Dim datos As DataSet = Nothing        Dim resultados As DataTable = Nothing        Try            msg.reset()            consulta = "exec [PA_Embactestado] '" + pOrdenid + "', '" + pEstadoid + "'"            If stipoExpr = "S" Then
                resultados = puenteSql.ejecutarConsulta(consulta)
            Else
                puenteSql.ejecutarExpresion(consulta)
            End If

            msg = puenteSql.Mensaje        Catch ex As Exception            msg.setError("No fue posible ejecutar la consulta: " + ex.Message)        End Try        If msg.EsError Then Throw New Exception(msg.Descripcion)        Return resultados    End Function

    Private Function ejecutarActEdoVta(ByVal pOrdenid As String, ByVal pEstadoid As String) As DataTable        Dim consulta As String = ""        Dim datos As DataSet = Nothing        Dim resultados As DataTable = Nothing        Try            msg.reset()            consulta = "exec [PA_Vtasactestado] '" + pOrdenid + "', '" + pEstadoid + "'"            If stipoExpr = "S" Then
                resultados = puenteSql.ejecutarConsulta(consulta)
            Else
                puenteSql.ejecutarExpresion(consulta)
            End If

            msg = puenteSql.Mensaje        Catch ex As Exception            msg.setError("No fue posible ejecutar la consulta: " + ex.Message)        End Try        If msg.EsError Then Throw New Exception(msg.Descripcion)        Return resultados    End Function

    Private Function ejecutarActEdoAju(ByVal pOrdenid As String, ByVal pEstadoid As String) As DataTable        Dim consulta As String = ""        Dim datos As DataSet = Nothing        Dim resultados As DataTable = Nothing        Try            msg.reset()            consulta = "exec [PA_Ajuactestado] '" + pOrdenid + "', '" + pEstadoid + "'"            If stipoExpr = "S" Then
                resultados = puenteSql.ejecutarConsulta(consulta)
            Else
                puenteSql.ejecutarExpresion(consulta)
            End If

            msg = puenteSql.Mensaje        Catch ex As Exception            msg.setError("No fue posible ejecutar la consulta: " + ex.Message)        End Try        If msg.EsError Then Throw New Exception(msg.Descripcion)        Return resultados    End Function

End Class