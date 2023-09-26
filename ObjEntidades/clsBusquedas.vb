Imports Genericas
Imports IfcDatos
Public Class Busquedas
    Private msg As Mensaje
    Private iBusq As iBusquedas

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iBusq = New iBusquedas(pCliente)

    End Sub

    Public Function buscarProveedor(ByVal pFuncion As Integer, _
                                    ByVal pProvId As String, ByVal pActivo As String, _
                                    ByVal pTpoprvId As String, ByVal pNombre As String, _
                                    ByVal pCntcto As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarProveedor(pFuncion, pProvId, pActivo, pTpoprvId, pNombre, pCntcto)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda por proveedor: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarTrigo(ByVal pFuncion As Integer, _
                                ByVal pTrigoId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarTrigo(pFuncion, pTrigoId, pNombre, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Trigo: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarLote(ByVal pFuncion As Integer, _
                            ByVal pLoteId As String, ByVal pEstadoId As String, _
                            ByVal pProvId As String, ByVal pTrigoId As String, _
                            ByVal pFchlote As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarLote(pFuncion, pLoteId, pEstadoId, pProvId, pTrigoId, pFchlote)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Lote: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarOrigen(ByVal pFuncion As Integer, _
                            ByVal pOrigenId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarOrigen(pFuncion, pOrigenId, pNombre, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Origen: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarOrden(ByVal pFuncion As Integer, _
                        ByVal pOrdenId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                            ByVal pCtrtoId As String, ByVal pLoteId As String, ByVal pOrigenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarOrden(pFuncion, pOrdenId, pEstadoId, pFchord, pCtrtoId, pLoteId, pOrigenId)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de la Orden: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function
    Public Function buscarOrdenOrigen(ByVal pFuncion As Integer, _
                    ByVal pOrdenId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                        ByVal pCtrtoId As String, ByVal pLoteId As String, ByVal pOrigenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarOrdenOrigen(pFuncion, pOrdenId, pEstadoId, pFchord, pCtrtoId, pLoteId, pOrigenId)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de la Orden: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function
    Public Function buscarOrdenSOrigen(ByVal pFuncion As Integer, _
                ByVal pOrdenId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                    ByVal pCtrtoId As String, ByVal pLoteId As String, ByVal pOrigenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarOrdenSOrigen(pFuncion, pOrdenId, pEstadoId, pFchord, pCtrtoId, pLoteId, pOrigenId)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de la Orden: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarDestino(ByVal pFuncion As Integer, _
                        ByVal pDestinoId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarDestino(pFuncion, pDestinoId, pNombre, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Destino: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarOperador(ByVal pFuncion As Integer, _
                    ByVal pOperadorId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarOperador(pFuncion, pOperadorId, pNombre, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Operador: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarAjuste(ByVal pFuncion As Integer, _
                    ByVal pAjustId As String, ByVal pEstadoId As String, ByVal pFchajus As String, _
                        ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarAjuste(pFuncion, pAjustId, pEstadoId, pFchajus, pOrdenId)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Ajustes: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarEmbarque(ByVal pFuncion As Integer, _
                    ByVal pEmbId As String, ByVal pEstadoId As String, ByVal pFchord As String, _
                        ByVal pOrdenId As String, ByVal pLoteId As String, ByVal pReftrans As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarEmbarque(pFuncion, pEmbId, pEstadoId, pFchord, pOrdenId, pLoteId, pReftrans)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda del Embarque: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarVenta(ByVal pFuncion As Integer, _
                ByVal pVentaId As String, ByVal pEstadoId As String, ByVal pFchventa As String, _
                ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarVenta(pFuncion, pVentaId, pEstadoId, pFchventa, pOrdenId)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Ventas: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarSilo(ByVal pFuncion As Integer, _
                ByVal pSiloId As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarSilo(pFuncion, pSiloId, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Silos: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarSilos(ByVal pFuncion As Integer, _
            ByVal pDstinoId As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarSilos(pFuncion, pDstinoId)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Silos: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarPerfiles(ByVal pFuncion As Integer, _
                ByVal pUsrId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarPerfil(pFuncion, pUsrId, pNombre, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Perfiles: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarUsuarios(ByVal pFuncion As Integer, _
                ByVal pUsrId As String, ByVal pNkname As String, ByVal pNombre As String, _
                ByVal pApllidop As String, ByVal pApllidom As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarUsuario(pFuncion, pUsrId, pNkname, pNombre, pApllidop, pApllidom, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Usuarios: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function buscarUbicaciones(ByVal pFuncion As Integer, _
                                ByVal pUbicaId As String, ByVal pNombre As String, ByVal pActivo As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iBusq.buscarUbicaciones(pFuncion, pUbicaId, pNombre, pActivo)

            msg = iBusq.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible terminar la búqueda de Trigo: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Private Sub liberarObjetos()
        iBusq = Nothing
        msg = Nothing
    End Sub
End Class
