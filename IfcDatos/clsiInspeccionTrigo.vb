Imports Genericas

Public Class iInspeccionTrigo

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
            resultados = ejecutar(1, 0, "", "", "", "", "", "", "", "", 0, "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pCondlimp As Integer, ByVal pOlor As String, ByVal pColor As String, ByVal pDanado As String, ByVal pPlagas As String, ByVal pOtros As String, ByVal pEmbid As String, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pConforme As Integer, ByVal pObserv As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pCondlimp, pOlor, pColor, pDanado, pPlagas, pOtros, pEmbid, pUsrmod, pFchmod, pConforme, pObserv)
        Catch ex As Exception
            msg.setError("No fue posible escribir los valores: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pCondlimp As Integer, ByVal pOlor As String, ByVal pColor As String, ByVal pDanado As String, ByVal pPlagas As String, ByVal pOtros As String, ByVal pEmbid As String, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pConforme As Integer, ByVal pObserv As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pCondlimp, pOlor, pColor, pDanado, pPlagas, pOtros, pEmbid, pUsrmod, pFchmod, pConforme, pObserv)

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
            resultados = ejecutar(4, 0, "", "", "", "", "", pEmbId, "", "", 0, "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró Inspección primaria al Trigo " + pEmbId + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el documento: " + ex.Message)
        End Try

        Return resultados
    End Function


    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pCondlimp As Integer, ByVal pOlor As String, ByVal pColor As String, ByVal pDanado As String, ByVal pPlagas As String, ByVal pOtros As String, ByVal pEmbid As String, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pConforme As Integer, ByVal pObserv As String) As DataTable


        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sEmb2] " + pOpcion.ToString + ", " + pCondlimp.ToString + ", '" + pOlor + "', '" + pColor + "', '" + pDanado + "', '" + pPlagas + "', '" + pOtros + "', '" + pEmbid + "', '" + pUsrmod + "', '" + pFchmod + "', " + pConforme.ToString() + ", '" + pObserv + "'"


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