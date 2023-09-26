Imports Genericas
Imports IfcDatos

Partial Public Class Configuracion
    Private msg As Mensaje
    Private iconf As iConfiguracion

    Private sConfId As String
    Private sCarpanx As String
    Private sCarpimg As String
    Private sCarpImp As String
    Private sTnlmax As String
    Private sTnlmin As String
    Private sDifmin As String
    Private sDifmax As String
    Private sUsrmod As String
    Private sFchmod As String
    Private sNombre As String
    Private sCalle As String
    Private sNoext As String
    Private sNoint As String
    Private sColonia As String
    Private sRferenc As String
    Private sLcalidad As String
    Private sMnicipio As String
    Private sEstado As String
    Private sPais As String
    Private sCdgstl As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property ConfId() As String
        Get
            Return sConfId
        End Get
    End Property
    Public ReadOnly Property Carpanx() As String
        Get
            Return sCarpanx
        End Get
    End Property
    Public ReadOnly Property Carpimg() As String
        Get
            Return sCarpimg
        End Get
    End Property
    Public ReadOnly Property CarpImp() As String
        Get
            Return sCarpImp
        End Get
    End Property
    Public ReadOnly Property Tnlmax() As String
        Get
            Return sTnlmax
        End Get
    End Property
    Public ReadOnly Property Tnlmin() As String
        Get
            Return sTnlmin
        End Get
    End Property
    Public ReadOnly Property Difmin() As String
        Get
            Return sDifmin
        End Get
    End Property
    Public ReadOnly Property Difmax() As String
        Get
            Return sDifmax
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return sNombre
        End Get
    End Property
    Public ReadOnly Property Calle() As String
        Get
            Return sCalle
        End Get
    End Property
    Public ReadOnly Property Noext() As String
        Get
            Return sNoext
        End Get
    End Property
    Public ReadOnly Property Noint() As String
        Get
            Return sNoint
        End Get
    End Property
    Public ReadOnly Property Colonia() As String
        Get
            Return sColonia
        End Get
    End Property
    Public ReadOnly Property Rferenc() As String
        Get
            Return sRferenc
        End Get
    End Property
    Public ReadOnly Property Lcalidad() As String
        Get
            Return sLcalidad
        End Get
    End Property
    Public ReadOnly Property Mnicipio() As String
        Get
            Return sMnicipio
        End Get
    End Property
    Public ReadOnly Property Estado() As String
        Get
            Return sEstado
        End Get
    End Property
    Public ReadOnly Property Pais() As String
        Get
            Return sPais
        End Get
    End Property
    Public ReadOnly Property Cdgstl() As String
        Get
            Return sCdgstl
        End Get
    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pConfId As String, ByVal pCarpanx As String, ByVal pCarpimg As String, ByVal pCarpImp As String, _
                   ByVal pTnlmax As Decimal, ByVal pTnlmin As Decimal, ByVal pDifmin As Decimal, ByVal pDifmax As Decimal, _
                   ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, _
                   ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, _
                   ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgstl As String)
        msg = New Mensaje

        iconf = New iConfiguracion(pCliente)

        sConfId = pConfId
        sCarpanx = pCarpanx
        sCarpimg = pCarpimg
        sCarpImp = pCarpImp
        sTnlmax = pTnlmax
        sTnlmin = pTnlmin
        sDifmin = pDifmin
        sDifmax = pDifmax
        sUsrmod = pUsrmod
        sFchmod = pFchmod
        sNombre = pNombre
        sCalle = pCalle
        sNoext = pNoext
        sNoint = pNoint
        sColonia = pColonia
        sRferenc = pRferenc
        sLcalidad = pLcalidad
        sMnicipio = pMnicipio
        sEstado = pEstado
        sPais = pPais
        sCdgstl = pCdgstl
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pConfId As String)
        msg = New Mensaje
        iconf = New iConfiguracion(pCliente)

        buscarConfiguracion(pConfId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iconf = New iConfiguracion(pCliente)

        reiniciar()
    End Sub

    Public Sub actualizarValores(ByVal pConfId As String, ByVal pCarpanx As String, ByVal pCarpimg As String, ByVal pCarpImp As String, _
               ByVal pTnlmax As Decimal, ByVal pTnlmin As Decimal, ByVal pDifmin As Decimal, ByVal pDifmax As Decimal, _
               ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pNombre As String, ByVal pCalle As String, ByVal pNoext As String, _
               ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, ByVal pLcalidad As String, _
               ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCdgstl As String)
        msg = New Mensaje

        sConfId = pConfId
        sCarpanx = pCarpanx
        sCarpimg = pCarpimg
        sCarpImp = pCarpImp
        sTnlmax = pTnlmax
        sTnlmin = pTnlmin
        sDifmin = pDifmin
        sDifmax = pDifmax
        sUsrmod = pUsrmod
        sFchmod = pFchmod
        sNombre = pNombre
        sCalle = pCalle
        sNoext = pNoext
        sNoint = pNoint
        sColonia = pColonia
        sRferenc = pRferenc
        sLcalidad = pLcalidad
        sMnicipio = pMnicipio
        sEstado = pEstado
        sPais = pPais
        sCdgstl = pCdgstl
    End Sub

    Private Function buscarConfiguracion(ByVal pConfId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iconf.leer("0")
            msg = iconf.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            If resultados.Rows.Count > 0 Then
                sConfId = gen3E.valorCampo(resultados, 0, "ConfId")
                sCarpanx = gen3E.valorCampo(resultados, 0, "Carpanx")
                sCarpimg = gen3E.valorCampo(resultados, 0, "Carpimg")
                sCarpImp = gen3E.valorCampo(resultados, 0, "CarpImp")
                sTnlmax = gen3E.valorCampo(resultados, 0, "Tnlmax")
                sTnlmin = gen3E.valorCampo(resultados, 0, "Tnlmin")
                sDifmin = gen3E.valorCampo(resultados, 0, "Difmin")
                sDifmax = gen3E.valorCampo(resultados, 0, "Difmax")
                sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
                sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
                sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
                sCalle = gen3E.valorCampo(resultados, 0, "Calle")
                sNoext = gen3E.valorCampo(resultados, 0, "Noext")
                sNoint = gen3E.valorCampo(resultados, 0, "Noint")
                sColonia = gen3E.valorCampo(resultados, 0, "Colonia")
                sRferenc = gen3E.valorCampo(resultados, 0, "Rferenc")
                sLcalidad = gen3E.valorCampo(resultados, 0, "Lcalidad")
                sMnicipio = gen3E.valorCampo(resultados, 0, "Mnicipio")
                sEstado = gen3E.valorCampo(resultados, 0, "Estado")
                sPais = gen3E.valorCampo(resultados, 0, "Pais")
                sCdgstl = gen3E.valorCampo(resultados, 0, "Cdgstl")
            Else
                reiniciar()
            End If

            msg.setInfo("Configuración buscada y encontrada desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar la Configuración desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iconf.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iconf.actualizar(sConfId, sCarpanx, sCarpimg, sCarpImp, sTnlmax, sTnlmin, sDifmin, sDifmax, sUsrmod, _
                                   sFchmod, sNombre, sCalle, sNoext, sNoint, sColonia, sRferenc, sLcalidad, sMnicipio, _
                                   sEstado, sPais, sCdgstl).clonar()

esError:
            If msg.EsError Then
                iconf.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iconf.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Configuración actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar la configuración: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sConfId = "0"
        sCarpanx = ""
        sCarpimg = My.Application.Info.DirectoryPath + "\img\"
        sCarpImp = My.Application.Info.DirectoryPath + "\rpt\"
        sTnlmax = "120"
        sTnlmin = "0"
        sDifmin = "0"
        sDifmax = "0"
        sUsrmod = ""
        sFchmod = ""
        sNombre = ""
        sCalle = ""
        sNoext = ""
        sNoint = ""
        sColonia = ""
        sRferenc = ""
        sLcalidad = ""
        sMnicipio = ""
        sEstado = ""
        sPais = ""
        sCdgstl = ""

    End Sub

    Public Sub liberarObjetos()
        sConfId = ""
        sCarpanx = ""
        sCarpimg = ""
        sCarpImp = ""
        sTnlmax = "120"
        sTnlmin = "0"
        sDifmin = "0"
        sDifmax = "0"
        sUsrmod = ""
        sFchmod = ""
        sNombre = ""
        sCalle = ""
        sNoext = ""
        sNoint = ""
        sColonia = ""
        sRferenc = ""
        sLcalidad = ""
        sMnicipio = ""
        sEstado = ""
        sPais = ""
        sCdgstl = ""

        iconf = Nothing
    End Sub
End Class