Imports Genericas

Public Class iConfiguracion
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

    Public Function escribir(ByVal pConfId As String, ByVal pCarpanx As String, ByVal pCarpimg As String, ByVal pCarpImp As String, ByVal pTnlmax As Decimal, ByVal pTnlmin As Decimal, ByVal pDifmin As Decimal, ByVal pDifmax As Decimal, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgstl As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "I"
            ejecutar(1, pConfId, pCarpanx, pCarpimg, pCarpImp, pTnlmax, pTnlmax, pDifmin, pDifmax, _
                     pUsrmod, pFchmod, pNombre, pCalle, pNoext, pNoint, pColonia, pRferenc, pLcalidad, _
                     pMnicipio, pEstado, pPais, pCdgstl)

        Catch ex As Exception
            msg.setError("No fue posible escribir los valores del Proveedor: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function actualizar(ByVal pConfId As String, ByVal pCarpanx As String, ByVal pCarpimg As String, ByVal pCarpImp As String, ByVal pTnlmax As Decimal, ByVal pTnlmin As Decimal, ByVal pDifmin As Decimal, ByVal pDifmax As Decimal, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgstl As String) As Mensaje
        Try
            msg.reset()

            stipoExpr = "U"

            ejecutar(2, pConfId, pCarpanx, pCarpimg, pCarpImp, pTnlmax, pTnlmin, pDifmin, pDifmax, _
                     pUsrmod, pFchmod, pNombre, pCalle, pNoext, pNoint, pColonia, pRferenc, pLcalidad, _
                     pMnicipio, pEstado, pPais, pCdgstl)

        Catch ex As Exception
            msg.setError("No fue posible actualizar el Proveedor: " + ex.Message)

            Return msg
        End Try

        Return msg
    End Function

    Public Function leer(ByVal pConfId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(3, pConfId, "", "", "", 0, 0, 0, 0, "", "", "", "", "", "", _
                                  "", "", "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Proveedor: " + ex.Message)
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

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pConfId As String, ByVal pCarpanx As String, ByVal pCarpimg As String, ByVal pCarpImp As String, ByVal pTnlmax As Decimal, ByVal pTnlmin As Decimal, ByVal pDifmin As Decimal, ByVal pDifmax As Decimal, ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgstl As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_sConfig] " + pOpcion.ToString + ", '" + pConfId + "', '" + pCarpanx + "', '" + pCarpimg + "', '" + pCarpImp + "', " + pTnlmax.ToString + ", " + pTnlmin.ToString + ", " + pDifmin.ToString + ", " + pDifmax.ToString + ", '" + pUsrmod + "', '" + pFchmod + "', '" + pNombre + "', '" + pCalle + "', '" + pNoext + "', '" + pNoint + "', '" + pColonia + "', '" + pRferenc + "', '" + pLcalidad + "', '" + pMnicipio + "', '" + pEstado + "', '" + pPais + "', '" + pCdgstl + "'"


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