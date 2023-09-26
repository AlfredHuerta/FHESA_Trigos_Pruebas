Imports Genericas

Public Class iSesion
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
            resultados = ejecutar(1, 0, "", "", 0, 0)

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número de registro: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pLogid As Integer, ByVal pUsrid As String, ByVal pFchconex As String, ByVal pHostid As Integer, ByVal pconexion As Integer) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pLogid, pUsrid, pFchconex, pHostid, pconexion)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores del registro: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pLogid As Integer, ByVal pUsrid As String, ByVal pFchconex As String, ByVal pHostid As Integer, ByVal pconexion As Integer) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pLogid, pUsrid, pFchconex, pHostid, pconexion)

        Catch ex As Exception
            msg.setError("No fue posible actualizar el registro: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pLogid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, 0, "", "", 0, 0)


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el registro " + pLogid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el registro: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pLogid As Integer, ByVal pUsrid As String, ByVal pFchconex As String, ByVal pHostid As Integer, ByVal pconexion As Integer) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sLogeo] " + pOpcion.ToString + ", " + pLogid.ToString + ", '" + pUsrid + "', '" + pFchconex + "', " + pHostid.ToString + ", " + pconexion.ToString + ""


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