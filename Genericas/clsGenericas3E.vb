Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.OleDb

Public Class Genericas3E
    Private msg As Mensaje

    Private sCarpetaHistorial As String
    Private ultimaFechaReg As Date

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Property CarpetaHistorial() As String
        Get
            Return sCarpetaHistorial
        End Get
        Set(svalue As String)
            sCarpetaHistorial = svalue
        End Set
    End Property

    Public Sub New()
        msg = New Mensaje

        ultimaFechaReg = Now.Date
    End Sub




    Public Function obtenerCodificacion(ByVal pCodifId As Integer) As Object
        Dim CodifObj As Object = Nothing

        Select Case pCodifId
            Case 1
                CodifObj = New UTF8Encoding(False)
        End Select

        Return CodifObj
    End Function

    Public Function tablasExcel(ByVal pRutaArchivo As String) As DataTable
        Dim cn As OleDbConnection = Nothing
        Dim dt As DataTable = Nothing

        Try
            msg.reset()

            Dim Builder As New OleDbConnectionStringBuilder With _
                { _
                    .DataSource = pRutaArchivo, _
                    .Provider = "Microsoft.Jet.OLEDB.4.0" _
                }

            Builder.Add("Extended Properties", "Excel 8.0")

            cn = New OleDbConnection()
            cn.ConnectionString = Builder.ConnectionString

            cn.Open()

            ' Get the data table containg the schema guid.
            dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            If dt Is Nothing Then Throw New Exception("El libro seleccionado no contiene Hojas.")
        Catch ex As Exception
            Throw New Exception("No fue posible recuperar el listado de Hojas: " + ex.Message)
        End Try

        Return dt
    End Function

    Public Function aTabla(ByVal pRutaArchivo As String, ByVal pNombreHoja As String) As DataTable
        Dim dtSheet1 As New DataTable
        Dim cn As New OleDbConnection

        Try
            Dim Builder As New OleDbConnectionStringBuilder With _
                { _
                    .DataSource = pRutaArchivo, _
                    .Provider = "Microsoft.Jet.OLEDB.4.0" _
                }

            Builder.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=1")
            cn.ConnectionString = Builder.ConnectionString

            cn.Open()

            Using cmd As OleDbCommand = New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT * FROM [" + pNombreHoja + "]"
                Dim dr As System.Data.IDataReader = cmd.ExecuteReader

                dtSheet1.Load(dr)
            End Using
        Catch ex As Exception
            msg.setError("No fue posible recuperar la información del origen " + pRutaArchivo + ": " + ex.Message)
        End Try

        Return dtSheet1
    End Function



    Public Function valorCampo(ByVal pDatos As DataTable, pRenglon As Integer, pColumna As String) As String
        Dim valor As String = ""
        Dim colCounter As Integer

        Dim encontrado As Boolean = False
        Try
            msg.reset()

            If pDatos.Rows.Count - 1 < pRenglon Then
                msg.setError("Desbordamiento de índice. No se encontró un valor para la columna '" + pColumna + "'.")
                Throw New Exception(msg.Descripcion)
            End If

            For colCounter = 0 To pDatos.Columns.Count - 1
                If pDatos.Columns.Item(colCounter).ColumnName.ToUpper = pColumna.ToUpper Then
                    If IsDBNull(pDatos.Rows(pRenglon).Item(colCounter)) Then
                        valor = ""
                    Else
                        valor = pDatos.Rows(pRenglon).Item(colCounter).ToString
                    End If

                    encontrado = True
                    Exit For
                End If
            Next

            If Not encontrado Then
                msg.setError("No se encontró la columna '" + pColumna + "'.")
                valor = ""
                Throw New Exception(msg.Descripcion)
            End If
        Catch ex As Exception
            msg.setError("Ocurrió un error al intentar recuperar el valor del Campo '" + pColumna + "': " + ex.Message)
            Throw New Exception(msg.Descripcion)
        End Try

finalize:
        Return valor
    End Function

    Public Function valorCampo(ByVal pDatos As DataTable, pRenglon As Integer, pColumna As String, ByVal pvalorDefecto As String) As String
        Dim valor As String = ""
        Dim colCounter As Integer

        Dim encontrado As Boolean = False
        Try
            msg.reset()

            If pDatos.Rows.Count - 1 < pRenglon Then
                msg.setError("Desbordamiento de índice. No se encontró un valor.")
                GoTo finalize
            End If

            For colCounter = 0 To pDatos.Columns.Count - 1
                If pDatos.Columns.Item(colCounter).ColumnName.ToUpper = pColumna.ToUpper Then
                    If IsDBNull(pDatos.Rows(pRenglon).Item(colCounter)) And pvalorDefecto.Trim.Length > 0 Then
                        valor = pvalorDefecto
                    Else
                        valor = pDatos.Rows(pRenglon).Item(colCounter).ToString
                    End If

                    encontrado = True
                    Exit For
                End If
            Next

            If Not encontrado Then
                msg.setAdvertencia("No se encontró la columna " + pColumna + ".")
                valor = ""
            End If
        Catch ex As Exception
            msg.setError("Ocurrió un error al intentar recuperar el valor del Campo " + pColumna + ": " + ex.Message)
        End Try

finalize:
        Return valor
    End Function

    Public Function buscarArchivo(ByVal pDirectorioPadre As String, ByVal pNombreArch As String) As String
        Dim di As New DirectoryInfo(pDirectorioPadre)  'Falta parametrizar en Tabla Definida por Usuario
        Dim diar1 As FileInfo() = di.GetFiles(pNombreArch, SearchOption.AllDirectories)

        Dim RutaArch As String = ""

        Try
            msg.reset()

            If diar1.Length > 0 Then
                RutaArch = diar1(0).DirectoryName
                msg.setInfo("se ha encontrado la ubicación del archivo " + pNombreArch + ".")
            Else
                msg.setError("Búsqueda terminada. No se pudo encontrar el archivo " + pNombreArch + ".")
            End If
        Catch ex As Exception
            RutaArch = ""
            msg.setError("No fue posible encontrar la ruta del archivo " + pNombreArch + ": " + ex.Message)
        End Try

        Return RutaArch
    End Function

    Public Function aListaSubitem(ByVal pEnum As Type) As List(Of SubItem)
        Dim lista As List(Of SubItem) = Nothing
        Dim item As SubItem = Nothing

        Try
            msg.reset()

            Dim nombres() As String = System.Enum.GetNames(pEnum)
            Dim valores As Array = System.Enum.GetValues(pEnum)

            lista = New List(Of SubItem)

            Dim c As Integer = 0

            For c = 0 To nombres.GetUpperBound(0)
                item = New SubItem(nombres(c).ToString, CStr(valores.GetValue(c)))

                lista.Add(item)
            Next

            msg.setInfo("Listado de items recuperado con éxito.")
        Catch ex As Exception
            msg.setInfo("No fue posible recuperar el listado de artículos: " + ex.Message)
        End Try

        Return lista
    End Function

    Public Function seleccionarItem(ByRef pLista As ComboBox, ByVal pValor As String) As Mensaje
        Dim itmCounter As Integer = 0

        Try
            For itmCounter = 0 To pLista.Items.Count - 1
                If pLista.Items(itmCounter).ItemData = pValor Then
                    pLista.SelectedIndex = itmCounter
                    msg.setInfo("Item seleccionado con éxito")

                    GoTo finalize
                End If
            Next

        Catch ex As Exception
            msg.setError("No fue posible seleccionar el Item del listado: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function aBit(ByVal pValor As Boolean) As Integer
        If pValor Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function existeProceso(ByVal pProceso As Process) As Boolean
        Dim existe As Boolean = False
        Dim listaProc() As Process = Nothing

        Try
            msg.reset()

            listaProc = Process.GetProcessesByName(pProceso.ProcessName)

            For Each proceso As Process In listaProc
                If Not proceso.Id.Equals(pProceso.Id) Then
                    existe = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            msg.setError("No fue posible definir si ya hay un proceso ejecutándose con el usuario actual: " + ex.Message)
        End Try

        Return existe
    End Function

    Public Function anotar(ByVal pmsg As Mensaje, ByVal cuadro As RichTextBox, _
                   Optional ByVal pSoloSiError As Boolean = False) As Mensaje
        Dim avisoTexto As String = ""
        Dim colorFuente As Color = Nothing

        Try
            msg.reset()

            If pSoloSiError And Not pmsg.Tipo = SysEnums.TiposMensaje.mError Then GoTo finalize

            registrarArchivo(pmsg.Descripcion)
            If ultimaFechaReg < Now.Date Or cuadro.GetLineFromCharIndex(cuadro.TextLength) + 1 >= 1000 Then
                ultimaFechaReg = Now.Date
                cuadro.Clear()
            End If

            avisoTexto = Now.ToString("HH:mm:ss") + "->" + pmsg.Descripcion + vbCrLf
            Select Case pmsg.Tipo
                Case SysEnums.TiposMensaje.mNinguno
                    colorFuente = Color.Black
                Case SysEnums.TiposMensaje.mInformacion
                    colorFuente = Color.DarkBlue
                Case SysEnums.TiposMensaje.mExclamacion
                    colorFuente = Color.Green
                Case SysEnums.TiposMensaje.mAdvertencia
                    colorFuente = Color.OrangeRed
                Case SysEnums.TiposMensaje.mError
                    colorFuente = Color.Red
                Case Else
                    colorFuente = Color.Gray
            End Select

            cuadro.SelectionStart = cuadro.TextLength
            cuadro.SelectionColor = colorFuente
            cuadro.AppendText(avisoTexto)
            cuadro.Update()

            cuadro.ScrollToCaret()

        Catch ex As Exception
            msg.setError("No fue posible registrar la nota: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function registrarArchivo(ByVal strText As String, Optional ByVal bAppend As Boolean = True) As Mensaje
        Dim Sw1 As StreamWriter
        Dim Sr1 As StreamReader
        Dim ruta As String = sCarpetaHistorial + "Registro"
        Try
            msg.reset()

            If Not Directory.Exists(ruta) Then Directory.CreateDirectory(ruta)
            ruta += "\Org_" + Now.Date.ToString("yyyyMMdd") + ".txt"

            Sw1 = New StreamWriter(ruta, bAppend)

            Sw1.WriteLine(Now.ToLongTimeString + ": " + strText)

            Sw1.Flush()
            Sw1.Close()
            'Solo no aplica para el documento que lleve a cabo el 
            'registro de errores
            If bAppend = False Then _
                Sr1 = New StreamReader(File.Open(ruta, FileMode.OpenOrCreate, _
                    FileAccess.ReadWrite))

        Catch ex As Exception
            msg.setError("No fue posible aplicar registro en archivo Log: " + ex.Message)
        End Try

        Return msg
    End Function

End Class
