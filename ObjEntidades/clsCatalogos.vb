Imports Genericas
Imports IfcDatos

Public Class Catalogos
    Private msg As Mensaje
    Private iCat As iCatalogos

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iCat = New iCatalogos(pCliente)

    End Sub

    Public Function cargarEstadosDoc() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.cargarEstadosDoc()

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de Estados de Documento: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function cargarTiposProveedor() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.cargarTiposProveedor()

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de Tipos de proveedor: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function cargarMonedas() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.buscarMonedas(3, 0)

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de monedas: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function cargarPuestos() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.cargarPuestos()

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de puestos: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function cargarSmtp() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.cargarSmtp()

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de Servidores Smtp: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function cargarOperadores() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.cargarOperadores()

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de Operadores: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Function cargarPerfiles() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            resultados = iCat.cargarPerfiles()

            msg = iCat.Mensaje.clonar()
        Catch ex As Exception
            msg.setError("No fue posible cargar el catálogo de Perfiles: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Private Sub liberarObjetos()
        iCat = Nothing
        msg = Nothing
    End Sub
End Class
