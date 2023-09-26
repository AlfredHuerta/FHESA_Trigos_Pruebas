Imports Genericas

Public Class iProveedor
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
            resultados = ejecutar(1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _
                                  "", 0, "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "Consecutivo")
        Catch ex As Exception
            msg.setError("No fue posible obtener el siguiente número de Proveedor: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function escribir(ByVal pProvid As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgpstl As String, ByVal pCntcto As String, ByVal pTpoprvid As String, ByVal pProvidan As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pCardcode As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(2, pProvid, pNombre, pCalle, pNoext, pNoint, pColonia, pRferenc, pLcalidad, pMnicipio, _
                     pEstado, pPais, pCdgpstl, pCntcto, pTpoprvid, pProvidan, _
                     pActivo, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pCardcode)

        Catch ex As Exception
            msg.setError("No fue posible escribir los valores del Proveedor: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pProvid As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgpstl As String, ByVal pCntcto As String, ByVal pTpoprvid As String, ByVal pProvidan As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pCardcode As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(3, pProvid, pNombre, pCalle, pNoext, pNoint, pColonia, pRferenc, pLcalidad, pMnicipio, _
                     pEstado, pPais, pCdgpstl, pCntcto, pTpoprvid, pProvidan, _
                     pActivo, pFchcrea, pUsrcrea, pFchmod, pUsrmod, pCardcode)

        Catch ex As Exception
            msg.setError("No fue posible actualizar el Proveedor: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pProvid As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pProvid, "", "", "", "", "", "", "", "", "", "", "", "", "", _
                                  "", 0, "", "", "", "", "")


            If Not resultados Is Nothing Then
                If resultados.Rows.Count = 0 Then Throw New Exception("No se encontró el Proveedor " + pProvid + ".")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cargar el Proveedor: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function proveedorAnterior(ByVal pProvid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(5, pProvid, "", "", "", "", "", "", "", "", "", "", "", "", "", _
                                  "", 0, "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "ProvId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Proveedor anterior al actual: " + ex.Message)
        End Try

        Return No
    End Function

    Public Function proveedorSiguiente(ByVal pProvid As String) As String
        Dim No As String = "-1000"
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Try
            stipoExpr = "S"
            resultados = ejecutar(6, pProvid, "", "", "", "", "", "", "", "", "", "", "", "", "", _
                                  "", 0, "", "", "", "", "")

            gen3E = New Genericas3E
            No = gen3E.valorCampo(resultados, 0, "ProvId")
        Catch ex As Exception
            msg.setError("No fue posible obtener el Proveedor siguiente al actual: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pProvid As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgpstl As String, ByVal pCntcto As String, ByVal pTpoprvid As String, ByVal pProvidan As String, ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pCardcode As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sProveed] " + pOpcion.ToString + ", '" + pProvid + "', '" + pNombre + "', '" + pCalle + "', '" + pNoext + "', '" + pNoint + "', '" + pColonia + "', '" + pRferenc + "', '" + pLcalidad + "', '" + pMnicipio + "', '" + pEstado + "', '" + pPais + "', '" + pCdgpstl + "', '" + pCntcto + "', '" + pTpoprvid + "', '" + pProvidan + "', " + pActivo.ToString + ", '" + pFchcrea + "', '" + pUsrcrea + "', '" + pFchmod + "', '" + pUsrmod + "', '" + pCardcode + "'"


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