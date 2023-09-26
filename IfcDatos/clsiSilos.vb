Imports Genericas
Public Class clsiSilos
    Private msg As Mensaje
    Private puenteSql As ClienteSql
    Private stipoExpr As String
    Private sqlDirecto As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Sub New(ByVal pClientesql As ClienteSql)
        msg = New Mensaje
        puenteSql = pClientesql
        sqlDirecto = True
    End Sub

    Public Function escribir(ByVal pDestinoid As String, ByVal pSiloid As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pDescripcion As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pDestinoid, pSiloid, pActivo, pFchcrea, pUsrcrea, pUsrmod, pFchmod, pDescripcion)

        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function actualizar(ByVal pDestinoid As String, ByVal pSiloid As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pDescripcion As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"
            ejecutar(3, pDestinoid, pSiloid, pActivo, pFchcrea, pUsrcrea, pUsrmod, pFchmod, pDescripcion)

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)
            Return msg

        End Try

        Return msg
    End Function

    Public Function leer(ByVal pDestinoid As String, ByVal pSiloid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pDestinoid, pSiloid, 0, "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el registro " + pDestinoid + "," + pSiloid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el registro: " + ex.Message)
        End Try

        Return resultados
    End Function

    'Leer todos
    Public Function leerTodos(ByVal pDestinoid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(10, pDestinoid, "", 0, "", "", "", "", "")

            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontraron registros para el destino " + pDestinoid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar los registros: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pDestinoid As String, ByVal pSiloid As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pDescripcion As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sSilos] " + pOpcion.ToString + ", '" + pDestinoid + "', '" + pSiloid + "', " + pActivo.ToString + ", '" + pFchcrea + "', '" + pUsrcrea + "', '" + pUsrmod + "', '" + pFchmod + "', '" + pDescripcion + "'"


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
