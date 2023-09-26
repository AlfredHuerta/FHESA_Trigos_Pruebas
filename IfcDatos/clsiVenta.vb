Imports Genericas

Public Class iVenta
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
            resultados = ejecutar(1, "", 0, "", "", "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número de Venta: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pVentaid As String, ByVal pTonventa As Decimal, ByVal pOrdenid As String, ByVal pFchventa As String, ByVal pEstadoid As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pUsrcrea As String, ByVal pUsrmod As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pVentaid, pTonventa, pOrdenid, pFchventa, pEstadoid, pObsrv, pFchcrea, pFchmod, pUsrcrea, pUsrmod)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores de la Venta: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pVentaid As String, ByVal pTonventa As Decimal, ByVal pOrdenid As String, ByVal pFchventa As String, ByVal pEstadoid As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pUsrcrea As String, ByVal pUsrmod As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pVentaid, pTonventa, pOrdenid, pFchventa, pEstadoid, pObsrv, pFchcrea, pFchmod, pUsrcrea, pUsrmod)

        Catch ex As Exception
            msg.setError("No fue posible actualizar la Venta: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pVentaid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pVentaid, 0, "", "", "", "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró la Venta " + pVentaid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar la Venta: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function ventaAnterior(ByVal pVentaid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pVentaid, 0, "", "", "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "VentaId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Venta anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function ventaSiguiente(ByVal pVentaid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pVentaid, 0, "", "", "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "VentaId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Ajuste siguiente al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function buscarCambios(ByVal pVentaId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, pVentaId, 0, "", "", "", "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el historial de cambios de la Venta: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pVentaid As String, ByVal pTonventa As Decimal, ByVal pOrdenid As String, ByVal pFchventa As String, ByVal pEstadoid As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pFchmod As String, ByVal pUsrcrea As String, ByVal pUsrmod As String) As DataTable


        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sVentas] " + pOpcion.ToString + ", '" + pVentaid + "', " + pTonventa.ToString + ", '" + pOrdenid + "', '" + pFchventa + "', '" + pEstadoid + "', '" + pObsrv + "', '" + pFchcrea + "', '" + pFchmod + "', '" + pUsrcrea + "', '" + pUsrmod + "'"


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