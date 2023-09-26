Imports Genericas

Public Class iOperador
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
            resultados = ejecutar(1, "", "", "", 0, "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo", "-1000")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pOprdorid As String, ByVal pNkname As String, ByVal pNombre As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pUsridan As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pOprdorid, pNkname, pNombre, pActivo, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pUsridan)

        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pOprdorid As String, ByVal pNkname As String, ByVal pNombre As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pUsridan As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pOprdorid, pNkname, pNombre, pActivo, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pUsridan)

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pOprdorid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pOprdorid, "", "", 0, "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el registro " + pOprdorid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el registro: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function operadorAnterior(ByVal pOprdorid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pOprdorid, "", "", 0, "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "OprdorId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Origen anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function operadorSiguiente(ByVal pOprdorid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pOprdorid, "", "", 0, "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "OprdorId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Origen siguiente al actual: " + ex.Message)
        End Try

        Return No
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

private function ejecutar (byval pOpcion as integer, byval pOprdorid as  string, byval pNkname as  string, byval pNombre as  string, byval pActivo as integer, byval pFchcrea as  string, byval pUsrcrea as  string, byval pFchmod as  string, byval pUsrmod as  string, byval pUsridan as  string) as DataTable
        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sOprador] " + pOpcion.ToString + ", '" + pOprdorid + "', '" + pNkname + "', '" + pNombre + "', " + pActivo.ToString + ", '" + pFchcrea + "', '" + pUsrcrea + "', '" + pFchmod + "', '" + pUsrmod + "', '" + pUsridan + "'"


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