Public Class InformacionDocumento
    Private tpo As SysEnums.TiposDocumentos

    Private sBaseDeDatos As String
    Private sTablaEncabezado As String
    Private sDocNum As String
    Private sTablaEncabezadoRef As String
    Private sDocEntryRef As String
    Private _tiposDocumentos As SysEnums.TiposDocumentos
    Private _p2 As String
    Private _p3 As String
    Private _p4 As String
    Private _p5 As String
    Private _p6 As String
    Private _p7 As String

    Sub New(tiposDocumentos As SysEnums.TiposDocumentos, p2 As String, p3 As String, p4 As String, p5 As String, p6 As String, p7 As String)
        ' TODO: Complete member initialization 
        _tiposDocumentos = tiposDocumentos
        _p2 = p2
        _p3 = p3
        _p4 = p4
        _p5 = p5
        _p6 = p6
        _p7 = p7
    End Sub

    Public ReadOnly Property BaseDeDatos() As String
        Get
            Return sBaseDeDatos
        End Get
    End Property

    Public ReadOnly Property TablaEncabezado() As String
        Get
            Return sTablaEncabezado
        End Get
    End Property

    Public ReadOnly Property Tipo() As SysEnums.TiposDocumentos
        Get
            Return tpo
        End Get
    End Property

    Public ReadOnly Property NumDocumento() As String
        Get
            Return sDocNum
        End Get
    End Property

    Public ReadOnly Property TablaEncabezadoRef() As String
        Get
            Return sTablaEncabezadoRef
        End Get
    End Property

    Public ReadOnly Property NumEntradaRef() As String
        Get
            Return sDocEntryRef
        End Get
    End Property

    Public Sub New(ByVal pTipo As SysEnums.TiposDocumentos, ByVal pBaseDeDatos As String, _
                   ByVal pTablaEncabezado As String, ByVal pDocNum As String, _
                   ByVal pTablaEncabezadoRef As String, ByVal pDocEntryRef As String)
        tpo = pTipo
        sBaseDeDatos = pBaseDeDatos
        sTablaEncabezado = pTablaEncabezado
        sDocNum = pDocNum
        sTablaEncabezadoRef = pTablaEncabezadoRef
        sDocEntryRef = pDocEntryRef
    End Sub

    Public Sub New(ByRef pMsgProcesamiento As Mensaje, ByVal pTipo As SysEnums.TiposDocumentos, _
                   ByVal pBaseDeDatos As String, _
               ByVal pTablaEncabezado As String, ByVal pDocNum As String, _
               ByVal pTablaEncabezadoRef As String, ByVal pDocEntryRef As String)
        tpo = pTipo
        sBaseDeDatos = pBaseDeDatos
        sTablaEncabezado = pTablaEncabezado
        sDocNum = pDocNum
        sTablaEncabezadoRef = pTablaEncabezadoRef
        sDocEntryRef = pDocEntryRef
    End Sub



    Public Sub reset()
        tpo = SysEnums.TiposDocumentos.dDesconocido
        sBaseDeDatos = ""
        sTablaEncabezado = ""
        sDocNum = ""
    End Sub
End Class
