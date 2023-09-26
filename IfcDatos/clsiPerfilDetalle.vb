Imports Genericas

Public Class iPerfilDetalle
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
            resultados = ejecutar(1, 0, 0, 0, 0, 0, 0, 0, 0)

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pPerfilid As String, ByVal pOpcionid As Integer, ByVal pActivo As Integer, ByVal pConsulta As Integer, ByVal pMdfccion As Integer, ByVal pCreacion As Integer, ByVal pCnlacion As Integer, ByVal pCierre As Integer) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pPerfilid, pOpcionid, pActivo, pConsulta, pMdfccion, pCreacion, pCnlacion, pCierre)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pPerfilid As String, ByVal pOpcionid As Integer, ByVal pActivo As Integer, ByVal pConsulta As Integer, ByVal pMdfccion As Integer, ByVal pCreacion As Integer, ByVal pCnlacion As Integer, ByVal pCierre As Integer) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pPerfilid, pOpcionid, pActivo, pConsulta, pMdfccion, pCreacion, pCnlacion, pCierre)

        Catch ex As Exception
            msg.setError("No fue posible actualizar: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pPerfilid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pPerfilid, 0, 0, 0, 0, 0, 0, 0)


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró Detalle de perfil " + pPerfilid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el documento: " + ex.Message)
        End Try

        Return resultados
    End Function


    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pPerfilid As String, ByVal pOpcionid As Integer, ByVal pActivo As Integer, ByVal pConsulta As Integer, ByVal pMdfccion As Integer, ByVal pCreacion As Integer, ByVal pCnlacion As Integer, ByVal pCierre As Integer) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sPrfls2] " + pOpcion.ToString + ", '" + pPerfilid + "', " + pOpcionid.ToString + ", " + pActivo.ToString + ", " + pConsulta.ToString + ", " + pMdfccion.ToString + ", " + pCreacion.ToString + ", " + pCnlacion.ToString + ", " + pCierre.ToString + ""

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
