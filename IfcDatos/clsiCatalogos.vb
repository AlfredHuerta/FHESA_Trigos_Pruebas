Imports Genericas

Public Class iCatalogos
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

    Public Function cargarEstadosDoc() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(1, 0, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Estado de documento: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function cargarTiposProveedor() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(2, 0, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Tipos de proveedor: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarTrigo(ByVal pOpcion As Integer, ByVal pFuncion As Integer, _
                                ByVal pParam1 As String, ByVal pParam2 As String) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(pOpcion, pFuncion, pParam1, pParam2, "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el Trigo: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function buscarMonedas(ByVal pOpcion As Integer, ByVal pFuncion As Integer) As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(pOpcion, pFuncion, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Monedas: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function cargarPuestos() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(4, 0, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Puestos: " + ex.Message)
        End Try

        Return resultados
    End Function


    Public Function cargarSmtp() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(7, 0, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Servidores Smtp: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function cargarOperadores() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(6, 0, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Operadores: " + ex.Message)
        End Try

        Return resultados
    End Function

    Public Function cargarPerfiles() As DataTable
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            stipoExpr = "S"
            resultados = ejecutar(5, 0, "", "", "", "", "")

        Catch ex As Exception
            msg.setError("No fue posible cargar el listado de Perfiles de Usuario: " + ex.Message)
        End Try

        Return resultados
    End Function



    Private Function ejecutar(ByVal pOpcion As Integer, ByVal pFuncion As Integer, ByVal pParam1 As String, ByVal pParam2 As String, ByVal pParam3 As String, ByVal pParam4 As String, ByVal pParam5 As String) As DataTable

        Dim consulta As String = ""
        Dim datos As DataSet = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()

            consulta = "exec [PA_Catalogos] " + pOpcion.ToString + ", " + pFuncion.ToString + ", '" + pParam1 + "', '" + pParam2 + "', '" + pParam3 + "', '" + pParam4 + "', '" + pParam5 + "'"


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