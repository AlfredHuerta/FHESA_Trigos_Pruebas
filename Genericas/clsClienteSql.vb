Imports System.Data
Imports System.Data.SqlClient

Public Class ClienteSql
    Private sultimaConsulta As String
    Private pcnn As ParametrosConexion
    Private msg As Mensaje

    Dim SqlCnn As SqlConnection
    Private Tran As SqlTransaction

    Private iFilasAfectadas As Integer


    Public Property ParametrosConexion() As ParametrosConexion
        Get
            Return pcnn
        End Get
        Set(parvalue As ParametrosConexion)
            pcnn = parvalue
        End Set
    End Property

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property


    Public ReadOnly Property FilasAfectadas() As Integer
        Get
            Return iFilasAfectadas
        End Get
    End Property

    Public Sub New(ByVal pConnParameters As ParametrosConexion)
        pcnn = pConnParameters
        Tran = Nothing

        msg = New Mensaje
    End Sub

    Public Function abrirConexion() As Mensaje
        Dim cripto As Criptografo = New Criptografo


        Try
            Dim cnstrg As String = "Server=" + pcnn.ServidorBd + ";DataBase=" + pcnn.BaseDeDatos + ";" + _
                "User ID =" + cripto.Desencriptar(pcnn.UsuarioBd, pcnn.BaseDeDatos) + _
                ";password=" + cripto.Desencriptar(pcnn.ContraseniaBd, pcnn.BaseDeDatos) + _
                ";Connection Timeout=" + pcnn.TiempoEsperaBd.ToString

            msg.reset()

            SqlCnn = New SqlConnection(cnstrg)
            SqlCnn.Open()

            msg.setInfo("Conexión con la Base de Datos abierta correctamente.")
        Catch ex As Exception
            msg.setError("No fue posible abrir la conexión con la Base de Datos: " + ex.Message)
        End Try

        Return Mensaje
    End Function

    Public Function cerrarConexion() As Mensaje
        msg.reset()

        Try
            SqlCnn.Close()
            SqlCnn.Dispose()

            msg.setInfo("Conexion con la Base de Datos cerrada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible cerrar la conexión con la Base de Datos: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function iniciarTransaccion(ByVal pNivelAslamiento As System.Data.IsolationLevel) As Mensaje
        Try
            Tran = SqlCnn.BeginTransaction(pNivelAslamiento)

            msg.setInfo("Transacción inicializada correctamente.")
        Catch ex As Exception
            msg.setError("No fue posible inicializar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function cancelarTransaccion() As Mensaje
        Try
            If Not Tran Is Nothing Then
                Tran.Rollback()
                Tran = Nothing
            End If

            msg.setInfo("Transacción cancelada correctamente.")
        Catch ex As Exception
            msg.setError("No fue posible cancelar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function terminarTransaccion() As Mensaje
        Try
            If Not Tran Is Nothing Then
                Tran.Commit()
                Tran = Nothing
            End If

            msg.setInfo("Transacción terminada correctamente.")
        Catch ex As Exception
            msg.setError("No fue posible terminar la transacción: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function ejecutarConsulta(ByVal pQueryString As String, Optional ByVal pCompileOnly As Boolean = False, _
                              Optional ByVal pMinCols As Integer = 0) As DataTable
        Dim sda As SqlDataAdapter
        Dim dt As DataTable
        Dim dset As DataSet

        Dim RowCount As Integer = 0
        Dim AgregaColumna, i, j As Integer

        Try
            msg.reset()

            If SqlCnn.State = ConnectionState.Broken Or SqlCnn.State = ConnectionState.Closed Then
                If abrirConexion().EsError Then Return Nothing
            End If

            If pCompileOnly Then pQueryString = "SET FMTONLY ON " + pQueryString + " SET FMTONLY OFF"

            Dim scmd As New SqlCommand(pQueryString, SqlCnn)
            scmd.CommandTimeout = pcnn.TiempoEsperaBd

            If Not Tran Is Nothing And scmd.Transaction Is Nothing Then scmd.Transaction = Tran

            sda = New SqlDataAdapter(scmd)

            Debug.Print(pQueryString)

            dset = New DataSet()
            sda.Fill(dset, "Table")
            dt = dset.Tables("Table")

            If dt.Rows.Count > 0 Then
                If dt.Columns.Count < pMinCols Then
                    AgregaColumna = 1

                    While dt.Columns.Count < pMinCols
                        dt.Columns.Add("DEF" + AgregaColumna.ToString, GetType(String), CStr(" "))

                        AgregaColumna += 1
                    End While

                    For i = 0 To dt.Rows.Count - 1
                        For j = 1 To AgregaColumna - 1
                            dt.Rows(i).Item("DEF" + j.ToString) = " "
                        Next
                    Next
                End If
            End If

            scmd.Dispose()
            sda.Dispose()
        Catch ex As Exception
            msg.setError("No fue posible devolver datos para la consulta requerida: " + ex.Message)

            Return Nothing
        End Try

        If Not IsNothing(dt) Then
            RowCount = dt.Rows.Count.ToString
        End If

        msg.setInfo("Consulta realizada con éxito (" + RowCount.ToString + " fila(s) afectada(s)).")

        sultimaConsulta = pQueryString
        Return dt
    End Function

    Public Function ejecutarExpresion(ByVal pExpressionString As String, Optional ByVal pCompileOnly As Boolean = False) As SqlDataReader
        Dim dr As SqlDataReader = Nothing

        Try
            msg.reset()

            If SqlCnn.State = ConnectionState.Broken Then
                If abrirConexion().EsError Then Return Nothing
            End If

            If pCompileOnly Then pExpressionString = "SET FMTONLY ON " + pExpressionString + " SET FMTONLY OFF"

            Dim scmd As New SqlCommand(pExpressionString, SqlCnn)
            scmd.CommandTimeout = pcnn.TiempoEsperaBd

            If Not Tran Is Nothing And scmd.Transaction Is Nothing Then scmd.Transaction = Tran

            Debug.Print(pExpressionString)
            dr = scmd.ExecuteReader

            scmd.Dispose()

            msg.setInfo("Expresión ejecutada con éxito " + dr.RecordsAffected.ToString + " fila(s) afectadas (s).")

            iFilasAfectadas = dr.RecordsAffected

            dr.Close()
        Catch ex As Exception
            msg.setError("No fue posible ejecutar la expresión: " + ex.Message)

            Return Nothing
        End Try

        Return dr
    End Function
End Class
