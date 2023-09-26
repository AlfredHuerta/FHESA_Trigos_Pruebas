Imports Genericas

Public Class iBusquedas
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

    Public Function buscarProveedor(ByVal pFuncion As Integer, _
                                    ByVal pProvId As String, ByVal pActivo As String, _
                                    ByVal pTpoprvId As String, ByVal pNombre As String, _
                                    ByVal pCntcto As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(1, pFuncion, pProvId, pActivo, pTpoprvId, pNombre, pCntcto, "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Proveedor: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarTrigo(ByVal pFuncion As Integer, _
                                ByVal pTrigoId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(2, pFuncion, pTrigoId, pNombre, pActivo, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Trigo: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarLote(ByVal pFuncion As Integer, _
                            ByVal pLoteId As String, ByVal pEstadoId As String, _
                            ByVal pProvId As String, ByVal pTrigoId As String, _
                            ByVal pFchlote As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(3, pFuncion, pLoteId, pEstadoId, pProvId, pTrigoId, pFchlote, "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Trigo: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarOrigen(ByVal pFuncion As Integer, _
                            ByVal pOrigenId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, pFuncion, pOrigenId, pNombre, pActivo, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Origen: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarOrden(ByVal pFuncion As Integer, _
                            ByVal pOrdenId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                            ByVal pCtrtoId As String, ByVal pLoteId As String, ByVal pOrigenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(5, pFuncion, pOrdenId, pEstadoId, pFchord, pCtrtoId, pLoteId, pOrigenId)

        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden: " + ex.Message)
        End Try

        Return resultados
    End Function
    Public Function buscarOrdenOrigen(ByVal pFuncion As Integer, _
                        ByVal pOrdenId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                        ByVal pCtrtoId As String, ByVal pLoteId As String, ByVal pOrigenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(17, pFuncion, pOrdenId, pEstadoId, pFchord, pCtrtoId, pLoteId, pOrigenId)

        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden: " + ex.Message)
        End Try

        Return resultados
    End Function
    Public Function buscarOrdenSOrigen(ByVal pFuncion As Integer, _
                    ByVal pOrdenId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                    ByVal pCtrtoId As String, ByVal pLoteId As String, ByVal pOrigenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(19, pFuncion, pOrdenId, pEstadoId, pFchord, pCtrtoId, pLoteId, pOrigenId)

        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarDestino(ByVal pFuncion As Integer, _
                        ByVal pDestinoId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(6, pFuncion, pDestinoId, pNombre, pActivo, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Destino: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarOperador(ByVal pFuncion As Integer, _
                    ByVal pOperadorId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, pFuncion, pOperadorId, pNombre, pActivo, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Operador: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarEmbarque(ByVal pFuncion As Integer, _
                        ByVal pEmbId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                        ByVal pOrdenId As String, ByVal pLoteId As String, ByVal pReftrans As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(8, pFuncion, pEmbId, pEstadoId, pFchord, pOrdenId, pLoteId, pReftrans)

        Catch ex As Exception
            msg.setError("No fue posible cargar el Embarque: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarAjuste(ByVal pFuncion As Integer, _
                    ByVal pAjustId As String, ByVal pEstadoId As String, ByVal pFchajus As String, _
                    ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(9, pFuncion, pAjustId, pEstadoId, pFchajus, pOrdenId, "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Ajuste: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarVenta(ByVal pFuncion As Integer, _
                ByVal pVentaId As String, ByVal pEstadoId As String, ByVal pFchventa As String, _
                ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(10, pFuncion, pVentaId, pEstadoId, pFchventa, pOrdenId, "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar la Venta: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarSilo(ByVal pFuncion As Integer, _
                ByVal pSiloId As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(11, pFuncion, pSiloId, pActivo, "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Silo: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarSilos(ByVal pFuncion As Integer, _
                ByVal pDstinoId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(14, pFuncion, pDstinoId, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Silos: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarPerfil(ByVal pFuncion As Integer, _
                ByVal pUsrId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(15, pFuncion, pUsrId, pNombre, pActivo, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de usuarios: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarUsuario(ByVal pFuncion As Integer, _
                ByVal pUsrId As String, ByVal pNkname As String, ByVal pNombre As String, _
                ByVal pApllidop As String, ByVal pApllidom As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(16, pFuncion, pUsrId, pNkname, pNombre, pApllidop, pApllidom, pActivo)

        Catch ex As Exception
            msg.setError("No fue posible cargar el Operador: " + ex.Message)
        End Try

        Return resultados
    End Function
    Public Function buscarUbicaciones(ByVal pFuncion As Integer, _
                        ByVal pUbicaId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(18, pFuncion, pUbicaId, pNombre, pActivo, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Origen: " + ex.Message)
        End Try

        Return resultados
    End Function

    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pFuncion As Integer, ByVal pParam1 As String, ByVal pParam2 As String, ByVal pParam3 As String, ByVal pParam4 As String, ByVal pParam5 As String, ByVal pParam6 As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_Busquedas] " + pOpcion.ToString + ", " + pFuncion.ToString + ", '" + pParam1 + "', '" + pParam2 + "', '" + pParam3 + "', '" + pParam4 + "', '" + pParam5 + "', '" + pParam6 + "'"


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
