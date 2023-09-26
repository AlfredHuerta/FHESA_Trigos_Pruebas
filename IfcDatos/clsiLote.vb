Imports Genericas

Public Class iLote
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
            resultados = ejecutar(1, "", "", "", 0, 0, 0, 0, 0, "", "", "", "", "", "", "", _
                                  "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número de Lote: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pLoteid As String, ByVal pProvid As String, ByVal pTrigoid As String, ByVal pProteina As Decimal, ByVal pGrado As Integer, ByVal pHumedad As Decimal, ByVal pPesohtl As Decimal, ByVal pImpureza As Decimal, ByVal pDockage As String, ByVal pVomitoxn As String, ByVal pErgot As String, ByVal pFllngnum As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String, ByVal pFchlote As String, ByVal pOtros As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pLoteid, pProvid, pTrigoid, pProteina, pGrado, pHumedad, pPesohtl, pImpureza, pDockage, _
                     pVomitoxn, pErgot, pFllngnum, pObsrv, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pEstadoid, pFchlote, pOtros)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores del Lote: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pLoteid As String, ByVal pProvid As String, ByVal pTrigoid As String, ByVal pProteina As Decimal, ByVal pGrado As Integer, ByVal pHumedad As Decimal, ByVal pPesohtl As Decimal, ByVal pImpureza As Decimal, ByVal pDockage As String, ByVal pVomitoxn As String, ByVal pErgot As String, ByVal pFllngnum As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String, ByVal pFchlote As String, ByVal pOtros As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pLoteid, pProvid, pTrigoid, pProteina, pGrado, pHumedad, pPesohtl, pImpureza, pDockage, _
                     pVomitoxn, pErgot, pFllngnum, pObsrv, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pEstadoid, pFchlote, pOtros)

        Catch ex As Exception
            msg.setError("No fue posible actualizar el Lote: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pLoteId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pLoteId, "", "", 0, 0, 0, 0, 0, "", "", "", "", "", "", "", _
                                  "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el Lote " + pLoteId + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el lote: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function loteAnterior(ByVal pLoteid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pLoteid, "", "", 0, 0, 0, 0, 0, "", "", "", "", "", "", "", _
                                  "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "LoteId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el lote anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function loteSiguiente(ByVal pLoteid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pLoteid, "", "", 0, 0, 0, 0, 0, "", "", "", "", "", "", "", _
                                  "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "LoteId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el lote siguiente al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function buscarCambios(ByVal pLoteId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, pLoteId, "", "", 0, 0, 0, 0, 0, "", "", "", "", "", "", "", _
                                  "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el historial de cambios del lote: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pLoteid As String, ByVal pProvid As String, ByVal pTrigoid As String, ByVal pProteina As Decimal, ByVal pGrado As Integer, ByVal pHumedad As Decimal, ByVal pPesohtl As Decimal, ByVal pImpureza As Decimal, ByVal pDockage As String, ByVal pVomitoxn As String, ByVal pErgot As String, ByVal pFllngnum As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String, ByVal pFchlote As String, ByVal pOtros As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sLotes] " + pOpcion.ToString + ", '" + pLoteid + "', '" + pProvid + "', '" + pTrigoid + "', " + pProteina.ToString + ", " + pGrado.ToString + ", " + pHumedad.ToString + ", " + pPesohtl.ToString + ", " + pImpureza.ToString + ", '" + pDockage + "', '" + pVomitoxn + "', '" + pErgot + "', '" + pFllngnum + "', '" + pObsrv + "', '" + pFchcrea + "', '" + pUsrcrea + "', '" + pFchmod + "', '" + pUsrmod + "', '" + pEstadoid + "', '" + pFchlote + "', '" + pOtros + "'"


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

End Class