Imports Genericas

Public Class clsiUsuario
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
            resultados = ejecutar(1, "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo", "-1000")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pUsrid As String, ByVal pNkname As String, ByVal pNombre As String, ByVal pApllidop As String, ByVal pApllidom As String, ByVal pCntrsnia As String, ByVal pPerfilid As String, ByVal pPuestoid As String, ByVal pLtimoacc As String, ByVal pCorreoe As String, ByVal pCntrscoe As String, ByVal pSmtpid As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pUsridan As String, ByVal pOprdorId As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pUsrid, pNkname, pNombre, pApllidop, pApllidom, pCntrsnia, pPerfilid, pPuestoid, pLtimoacc, pCorreoe, pCntrscoe, _
                     pSmtpid, pActivo, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pUsridan, pOprdorId)

        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pUsrid As String, ByVal pNkname As String, ByVal pNombre As String, ByVal pApllidop As String, ByVal pApllidom As String, ByVal pCntrsnia As String, ByVal pPerfilid As String, ByVal pPuestoid As String, ByVal pLtimoacc As String, ByVal pCorreoe As String, ByVal pCntrscoe As String, ByVal pSmtpid As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pUsridan As String, ByVal pOprdorId As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pUsrid, pNkname, pNombre, pApllidop, pApllidom, pCntrsnia, pPerfilid, pPuestoid, pLtimoacc, pCorreoe, pCntrscoe, _
                     pSmtpid, pActivo, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pUsridan, pOprdorId)

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pUsrid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pUsrid, "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el registro " + pUsrid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el registro: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function usuarioAnterior(ByVal pUsrid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pUsrid, "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "UsrId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Usuario anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function usuarioSiguiente(ByVal pUsrid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pUsrid, "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "UsrId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Usuario siguiente al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function buscarPorNikname(ByVal pNkname As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, "", pNkname, "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el usuario " + pNkname + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el registro: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function registrarAcceso(ByVal pUsrid As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(8, pUsrid, "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)

            Return msg
        End Try

        Return msg
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pUsrid As String, ByVal pNkname As String, ByVal pNombre As String, ByVal pApllidop As String, ByVal pApllidom As String, ByVal pCntrsnia As String, ByVal pPerfilid As String, ByVal pPuestoid As String, ByVal pLtimoacc As String, ByVal pCorreoe As String, ByVal pCntrscoe As String, ByVal pSmtpid As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pUsridan As String, ByVal pOprdorId As String) As DataTable
        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sUsuarios] " + pOpcion.ToString + ", '" + pUsrid + "', '" + pNkname + "', '" + pNombre + "', '" + pApllidop + "', '" + pApllidom + "', '" + pCntrsnia + "', '" + pPerfilid + "', '" + pPuestoid + "', '" + pLtimoacc + "', '" + pCorreoe + "', '" + pCntrscoe + "', '" + pSmtpid + "', " + pActivo.ToString + ", '" + pFchcrea + "', '" + pUsrcrea + "', '" + pFchmod + "', '" + pUsrmod + "', '" + pUsridan + "', '" + pOprdorId + "'"


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