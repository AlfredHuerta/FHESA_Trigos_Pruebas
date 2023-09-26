Partial Public Class PropiedadesCorreo
    Private msg As Mensaje
    Dim gen3E As Genericas3E

    'Private sapCompania As SAPbobsCOM.Company

    Private sServidorSmtp As String
    Private sPuertoSmtp As String
    Private bSsl_Tsl As Boolean
    Private bValidarCertificadoRemoto As Boolean
    Private sCuentaCorreo As String
    Private sNombreMostrar As String
    Private sContrasenia As String
    Private sPara As String
    Private sConCopia As String
    Private sConCopiaOculta As String
    Private bFormatoHtml As Boolean
    Private sAsunto As String
    Private sTextoContenido As String

    'Public ReadOnly Property Compania() As SAPbobsCOM.Company
    '    Get
    '        Return sapCompania
    '    End Get
    'End Property

    Public ReadOnly Property ServidorSmtp() As String
        Get
            Return sServidorSmtp
        End Get
    End Property

    Public ReadOnly Property PuertoSmtp() As String
        Get
            Return sPuertoSmtp
        End Get
    End Property

    Public ReadOnly Property Ssl_Tsl() As Boolean
        Get
            Return bSsl_Tsl
        End Get
    End Property

    Public ReadOnly Property ValidarCertificadoRemoto() As Boolean
        Get
            Return bValidarCertificadoRemoto
        End Get
    End Property

    Public ReadOnly Property CuentaCorreo() As String
        Get
            Return sCuentaCorreo
        End Get
    End Property

    Public ReadOnly Property NombreMostrar() As String
        Get
            Return sNombreMostrar
        End Get
    End Property

    Public ReadOnly Property Contrasenia() As String
        Get
            Return sContrasenia
        End Get
    End Property

    Public ReadOnly Property Para() As String
        Get
            Return sPara
        End Get
    End Property

    Public ReadOnly Property ConCopia() As String
        Get
            Return sConCopia
        End Get
    End Property

    Public ReadOnly Property ConCopiaOculta() As String
        Get
            Return sConCopiaOculta
        End Get
    End Property

    Public ReadOnly Property FormatoHtml() As Boolean
        Get
            Return bFormatoHtml
        End Get
    End Property

    Public ReadOnly Property Asunto() As String
        Get
            Return sAsunto
        End Get
    End Property

    Public ReadOnly Property TextoContenido() As String
        Get
            Return sTextoContenido
        End Get
    End Property

    Public Sub New(ByVal pEsPrueba As Boolean)
        msg = New Mensaje
        gen3E = New Genericas3E

        'sapCompania = psapCompania

        definirValores(pEsPrueba)
    End Sub

    Private Function definirValores(ByVal pEsPrueba As Boolean) As Mensaje
        'Dim tconfig As SAPbobsCOM.UserTable = Nothing

        Dim resultados As DataTable = Nothing
        Dim lparametrosEnu As List(Of String) = Nothing

        ' Dim genSap As GenericasSap = Nothing

        Try
            msg.reset()

            '  tconfig = sapCompania.UserTables.Item("ADV_CORREO")

            '    If Not tconfig.GetByKey("CFG") Then _
            If resultados.Rows.Count.Equals(0) Then Throw New Exception("Valores generales de Propiedades de Correo, no se encontraron datos en el origen.")

            '  genSap = New GenericasSap

            'sServidorSmtp = tconfig.UserFields.Fields.Item("U_ADV_SERVSMTP").Value
            'sPuertoSmtp = tconfig.UserFields.Fields.Item("U_ADV_PTOSMTP").Value
            'bSsl_Tsl = genSap.aBooleano(tconfig.UserFields.Fields.Item("U_ADV_SSLTSL").Value)
            'bValidarCertificadoRemoto = genSap.aBooleano(tconfig.UserFields.Fields.Item("U_ADV_VALCERTREMOTO").Value)
            'sCuentaCorreo = tconfig.UserFields.Fields.Item("U_ADV_CTAORIGEN").Value
            'sNombreMostrar = My.Application.Info.ProductName + " v" + My.Application.Info.Version.ToString
            'sContrasenia = tconfig.UserFields.Fields.Item("U_ADV_CONTRCTAORIGEN").Value

            'If pEsPrueba Then
            '    sPara = tconfig.UserFields.Fields.Item("U_ADV_CTAORIGEN").Value
            '    sConCopia = ""
            '    sConCopiaOculta = ""

            '    bFormatoHtml = False
            '    sAsunto = "Prueba de Credenciales de Correo Electrónico"
            '    sTextoContenido = "Este es un mensaje de prueba para verificación de credenciales capturadas en Menshen Sales Advisor. Ya que es un mensaje automático, no es necesario que responda al presente."
            'Else
            '    sPara = tconfig.UserFields.Fields.Item("U_ADV_PARA").Value
            '    sConCopia = tconfig.UserFields.Fields.Item("U_ADV_CONCOPIA").Value
            '    sConCopiaOculta = tconfig.UserFields.Fields.Item("U_ADV_CONCOPIAOCULTA").Value

            '    bFormatoHtml = genSap.aBooleano(tconfig.UserFields.Fields.Item("U_ADV_FORMATOHTML").Value)
            '    sAsunto = tconfig.UserFields.Fields.Item("U_ADV_ASUNTO").Value
            '    sTextoContenido = tconfig.UserFields.Fields.Item("U_ADV_CUERPOMENSAJE").Value
            'End If

            'lparametrosEnu = parametrosEnunciado(sAsunto)
            'lparametrosEnu.AddRange(parametrosEnunciado(sTextoContenido))

            'If lparametrosEnu.Count > 0 Then
            '    resultados = iArchiv.parametrosEnunciado(pIdArch, pIdCorreo)
            '    msg = iArchiv.Mensaje
            '    If msg.EsError Then GoTo finalize

            '    If resultados.Rows.Count.Equals(0) Then Throw New Exception("Valores generales de parámetros de enunciados, no se encontraron datos en el origen.")

            '    sAsunto = enunciadoValoresParametros(lparametrosEnu, sAsunto, resultados)
            '    sTextoContenido = enunciadoValoresParametros(lparametrosEnu, sTextoContenido, resultados)
            'End If

        Catch ex As Exception
            msg.setError("Propiedades de Correo: " + ex.Message)
        End Try

        ' genSap.liberarObjeto(tconfig)
finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Private Function parametrosEnunciado(ByVal pEnunciado As String) As List(Of String)
        Dim listaVariables As List(Of String) = Nothing
        Dim enunciado As String = pEnunciado.Trim()
        Dim indiceA As Integer = 0
        Dim indiceB As Integer = -1

        Try
            listaVariables = New List(Of String)

            Do While indiceA < enunciado.Length
                indiceA = enunciado.IndexOf("[?", indiceA)

                If indiceA >= 0 Then
                    indiceB = enunciado.IndexOf("]", indiceA)

                    If indiceB >= 0 Then
                        listaVariables.Add(enunciado.Substring(indiceA, indiceB + 1 - indiceA))

                        indiceA = indiceB
                    Else
                        Throw New Exception("El parámetro <<" + enunciado.Substring(indiceA, enunciado.Length - indiceA) + ">> no es válido o no se encuentra correctamente delimitado.")
                    End If
                Else
                    Exit Do
                End If
            Loop

        Catch ex As Exception
            msg.setError("No fue posible recuperar el listado de parámetros del enunciado <<" + pEnunciado + ">>: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return listaVariables
    End Function

    Private Function enunciadoValoresParametros(ByVal pListaParametros As List(Of String), _
                                            ByVal pEnunciado As String, ByVal pTablaValores As DataTable) As String
        Dim enunciadoConValores As String = pEnunciado

        Try
            For Each parametro As String In pListaParametros
                enunciadoConValores = enunciadoConValores.Replace(parametro, _
                    gen3E.valorCampo(pTablaValores, 0, aNombreColumna(parametro)))
            Next


        Catch ex As Exception
            msg.setError("No fue posible asignar valores de parámetro al enunciado <<" + pEnunciado + ">>:" + ex.Message)
        End Try

        Return enunciadoConValores
    End Function

    Private Function aNombreColumna(ByVal pParametro As String) As String
        Return pParametro.Replace("[", "").Replace("?", "").Replace("]", "")
    End Function
End Class

Partial Public Class ParametroImpresion
    Private sIdParametro As String
    Private sNombreParametro As String
    Private sColumnaValor As String
    Private sValor As String

    Public ReadOnly Property IdParametro() As String
        Get
            Return sIdParametro
        End Get
    End Property
    Public ReadOnly Property NombreParametro() As String
        Get
            Return sNombreParametro
        End Get
    End Property
    Public ReadOnly Property ColumnaValor() As String
        Get
            Return sColumnaValor
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return sValor
        End Get
    End Property

    Public Sub New(ByVal pIdParametro As String, ByVal pNombreParametro As String, _
                   ByVal pColumnaValor As String, ByVal pValor As String)


        sIdParametro = pIdParametro
        sNombreParametro = pNombreParametro
        sColumnaValor = pColumnaValor
        sValor = pValor
    End Sub

End Class