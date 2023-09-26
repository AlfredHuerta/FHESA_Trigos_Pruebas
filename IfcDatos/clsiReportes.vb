Imports Genericas

Public Class iReportes
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


    Public Function leerEncabezados() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(1, 0)


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontraron reportes activos para generar.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar encabezados de reportes: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function leerParametros(ByVal pRprteid As Integer) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(2, pRprteid)

        Catch ex As Exception
            msg.setError("No fue posible cargar los parámetros del reporte " + pRprteid + ": " + ex.Message)
        End Try

        Return resultados
    End Function


    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pRprteid As Integer) As DataTable
        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sRprte] " + pOpcion.ToString + ", " + pRprteid.ToString + ""


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
