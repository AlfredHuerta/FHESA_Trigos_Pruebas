Imports Genericas

Public Class iEmbarque
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
            resultados = ejecutar(1, "", "", "", "", "", 0, "", "", "", 0, 0, "", "", "", "", "",
                                  "", "", "", "", "", "", 0, "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pEmbid As String, ByVal pOrdenid As String, ByVal pReftrans As String, ByVal pDstinoid As String, ByVal pProvflet As String, ByVal pPesoemb As Decimal, ByVal pFchemb As String, ByVal pNoselloe As String, ByVal pFchrec As String, ByVal pPesore As Decimal, ByVal pDif As Decimal, ByVal pOprdorid As String, ByVal pSilo As String, ByVal pSellorec As String, ByVal pFactfl As String, ByVal pObgen As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pMonedaId As String, ByVal pTarifa As Decimal, ByVal pRefcrgmas As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pEmbid, pOrdenid, pReftrans, pDstinoid, pProvflet, pPesoemb, pFchemb, pNoselloe, pFchrec, pPesore,
                     pDif, pOprdorid, pSilo, pSellorec, pFactfl, pObgen,
                     pUsrcrea, pUsrmod, pFchcrea, pFchmod, pEstadoid, pMonedaId, pTarifa, pRefcrgmas)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pEmbid As String, ByVal pOrdenid As String, ByVal pReftrans As String, ByVal pDstinoid As String, ByVal pProvflet As String, ByVal pPesoemb As Decimal, ByVal pFchemb As String, ByVal pNoselloe As String, ByVal pFchrec As String, ByVal pPesore As Decimal, ByVal pDif As Decimal, ByVal pOprdorid As String, ByVal pSilo As String, ByVal pSellorec As String, ByVal pFactfl As String, ByVal pObgen As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pMonedaId As String, ByVal pTarifa As Decimal, ByVal pRefcrgmas As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pEmbid, pOrdenid, pReftrans, pDstinoid, pProvflet, pPesoemb, pFchemb, pNoselloe, pFchrec, pPesore,
                     pDif, pOprdorid, pSilo, pSellorec, pFactfl, pObgen,
                     pUsrcrea, pUsrmod, pFchcrea, pFchmod, pEstadoid, pMonedaId, pTarifa, pRefcrgmas)

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pEmbId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pEmbId, "", "", "", "", 0, "", "", "", 0, 0, "", "", "", "", "",
                                  "", "", "", "", "", "", 0, "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el Embarque " + pEmbId + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el documento: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function embarqueAnterior(ByVal pEmbId As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pEmbId, "", "", "", "", 0, "", "", "", 0, 0, "", "", "", "", "",
                                  "", "", "", "", "", "", 0, "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "EmbId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el documento anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function embarqueSiguiente(ByVal pEmbId As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pEmbId, "", "", "", "", 0, "", "", "", 0, 0, "", "", "", "", "",
                                  "", "", "", "", "", "", 0, "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "EmbId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el documento siguiente al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function sinFacturaFlete() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(8, "", "", "", "", "", 0, "", "", "", 0, 0, "", "", "", "", "",
                                  "", "", "", "", "", "", 0, "")

        Catch ex As Exception
            msg.setError("No fue posible obtener el listado de Embarques sin Factura Flete: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarCambios(ByVal pEmbId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, pEmbId, "", "", "", "", 0, "", "", "", 0, 0, "", "", "", "", "",
                                  "", "", "", "", "", "", 0, "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el historial de cambios del Embarque: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pEmbid As String, ByVal pOrdenid As String, ByVal pReftrans As String, ByVal pDstinoid As String, ByVal pProvflet As String, ByVal pPesoemb As Decimal, ByVal pFchemb As String, ByVal pNoselloe As String, ByVal pFchrec As String, ByVal pPesore As Decimal, ByVal pDif As Decimal, ByVal pOprdorid As String, ByVal pSilo As String, ByVal pSellorec As String, ByVal pFactfl As String, ByVal pObgen As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pMonedaId As String, ByVal pTarifa As Decimal, ByVal pRefcrgmas As String) As DataTable




        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sEmb1] " + pOpcion.ToString + ", '" + pEmbid + "', '" + pOrdenid + "', '" + pReftrans + "', '" + pDstinoid + "', '" + pProvflet + "', " + pPesoemb.ToString + ", '" + pFchemb + "', '" + pNoselloe + "', '" + pFchrec + "', " + pPesore.ToString + ", " + pDif.ToString + ", '" + pOprdorid + "', '" + pSilo + "', '" + pSellorec + "', '" + pFactfl + "', '" + pObgen + "', '" + pUsrcrea + "', '" + pUsrmod + "', '" + pFchcrea + "', '" + pFchmod + "', '" + pEstadoid + "', '" + pMonedaId + "', " + pTarifa.ToString + ", '" + pRefcrgmas + "'"


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