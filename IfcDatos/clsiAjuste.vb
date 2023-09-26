Imports Genericas

Public Class iAjuste
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
            resultados = ejecutar(1, "", "", "", 0, 0, 0, 0, "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número del Ajuste: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pAjustid As String, ByVal pOrdenid As String, ByVal pFchajus As String, ByVal pCompensa As Decimal, ByVal pMerma1 As Decimal, ByVal pMerma2 As Decimal, ByVal pMerma3 As Decimal, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pAjustid, pOrdenid, pFchajus, pCompensa, pMerma1, pMerma2, pMerma3, pObsrv, _
                     pFchcrea, pUsrcrea, pFchmod, pUsrmod, pEstadoid)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores del Ajuste: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pAjustid As String, ByVal pOrdenid As String, ByVal pFchajus As String, ByVal pCompensa As Decimal, ByVal pMerma1 As Decimal, ByVal pMerma2 As Decimal, ByVal pMerma3 As Decimal, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pAjustid, pOrdenid, pFchajus, pCompensa, pMerma1, pMerma2, pMerma3, pObsrv, _
                     pFchcrea, pUsrcrea, pFchmod, pUsrmod, pEstadoid)

        Catch ex As Exception
            msg.setError("No fue posible actualizar el Ajuste: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pAjustId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pAjustId, "", "", 0, 0, 0, 0, "", "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el Ajuste " + pAjustId + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el lote: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function ajusteAnterior(ByVal pAjustId As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pAjustId, "", "", 0, 0, 0, 0, "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "AjustId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Ajuste anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function ajusteSiguiente(ByVal pAjustId As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pAjustId, "", "", 0, 0, 0, 0, "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "AjustId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Ajuste siguiente al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function buscarCambios(ByVal pAjustId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, pAjustId, "", "", 0, 0, 0, 0, "", "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el historial de cambios del Ajuste: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pAjustid As String, ByVal pOrdenid As String, ByVal pFchajus As String, ByVal pCompensa As Decimal, ByVal pMerma1 As Decimal, ByVal pMerma2 As Decimal, ByVal pMerma3 As Decimal, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sAjustes] " + pOpcion.ToString + ", '" + pAjustid + "', '" + pOrdenid + "', '" + pFchajus + "', " + pCompensa.ToString + ", " + pMerma1.ToString + ", " + pMerma2.ToString + ", " + pMerma3.ToString + ", '" + pObsrv + "', '" + pFchcrea + "', '" + pUsrcrea + "', '" + pFchmod + "', '" + pUsrmod + "', '" + pEstadoid + "'"


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