Imports ingNovar.Utilidades2

Partial Public Class PaginasBrl

    Private _Id As Int32
    Private _Descripcion As String
    Private _Url As String
    Private objListPermisos_Perfil As List(Of Permisos_PerfilBrl)
    Private objListPermisos_Usuario As List(Of Permisos_UsuarioBrl)

    Public Event Creating()
    Public Event Created()

    Public Sub New()
        RaiseEvent Creating()
        'Adicionar código al costructor aquí

        RaiseEvent Created()
    End Sub

    Public Event IDChanging(ByVal Value As Int32)
    Public Event IDChanged()

    Public Property ID() As Int32
        Get
            Return Me._Id
        End Get
        Set(ByVal Value As Int32)
            If _Id <> Value Then
                RaiseEvent IDChanging(Value)
                Me._Id = Value
                RaiseEvent IDChanged()
            End If
        End Set
    End Property

    Public Event DescripcionChanging(ByVal Value As String)
    Public Event DescripcionChanged()

    Public Property Descripcion() As String
        Get
            Return Me._Descripcion
        End Get
        Set(ByVal Value As String)
            If _Descripcion <> Value Then
                RaiseEvent DescripcionChanging(Value)
                Me._Descripcion = Value
                RaiseEvent DescripcionChanged()
            End If
        End Set
    End Property

    Public Event UrlChanging(ByVal Value As String)
    Public Event UrlChanged()

    Public Property Url() As String
        Get
            Return Me._Url
        End Get
        Set(ByVal Value As String)
            If _Url <> Value Then
                RaiseEvent UrlChanging(Value)
                Me._Url = Value
                RaiseEvent UrlChanged()
            End If
        End Set
    End Property

    Public Property Permisos_Perfil() As List(Of Permisos_PerfilBrl)
        Get
            If (Me.objListPermisos_Perfil Is Nothing) Then
                objListPermisos_Perfil = Permisos_PerfilBrl.CargarPorId_Pagina(Me.ID)
            End If
            Return Me.objListPermisos_Perfil
        End Get
        Set(ByVal Value As List(Of Permisos_PerfilBrl))
            Me.objListPermisos_Perfil = Value
        End Set
    End Property

    Public Property Permisos_Usuario() As List(Of Permisos_UsuarioBrl)
        Get
            If (Me.objListPermisos_Usuario Is Nothing) Then
                objListPermisos_Usuario = Permisos_UsuarioBrl.CargarPorId_Pagina(Me.ID)
            End If
            Return Me.objListPermisos_Usuario
        End Get
        Set(ByVal Value As List(Of Permisos_UsuarioBrl))
            Me.objListPermisos_Usuario = Value
        End Set
    End Property

    Public Event Saving()
    Public Event Saved()

    Public Event Inserting()
    Public Event Inserted()

    Public Event Updating()
    Public Event Updated()

    Public Event Deleting()
    Public Event Deleted()

    Public Sub Guardar()
        RaiseEvent Saving()
        If (Me.ID = Nothing) Then
            RaiseEvent Inserting()
            Me.ID = PaginasDAL.Insertar(Descripcion, Url)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            PaginasDAL.Actualizar(ID, Descripcion, Url)
            RaiseEvent Updated()
        End If
        If Not objListPermisos_Perfil Is Nothing Then
            For Each fila As Permisos_PerfilBrl In objListPermisos_Perfil
                fila.Id_Pagina = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListPermisos_Usuario Is Nothing Then
            For Each fila As Permisos_UsuarioBrl In objListPermisos_Usuario
                fila.Id_Pagina = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If
        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            totalHijos += Permisos_Perfil.Count
            totalHijos += Permisos_Usuario.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            PaginasDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As PaginasBrl

        Dim objPaginas As New PaginasBrl
        With objPaginas
            .ID = fila("Id")
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
            .Url = isDBNullToNothing(fila("Url"))
        End With

        Return objPaginas

    End Function

    Public Shared Event LoadingPaginasList(ByVal LoadType As String)
    Public Shared Event LoadedPaginasList(ByVal target As List(Of PaginasBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of PaginasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of PaginasBrl)
        RaiseEvent LoadingPaginasList("CargarTodos")
        dsDatos = PaginasDAL.CargarTodos()
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedPaginasList(lista, "CargarTodos")
        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As PaginasBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As PaginasBrl
        Dim dsDatos As System.Data.DataSet
        Dim objPaginas As PaginasBrl = Nothing
        dsDatos = PaginasDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPaginas = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPaginas
    End Function


    Public Shared Function CargarPorURL(ByVal URL As String) As PaginasBrl
        Dim dsDatos As System.Data.DataSet
        Dim objPaginas As PaginasBrl = Nothing
        dsDatos = PaginasDAL.CargarPorURL(URL)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPaginas = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPaginas
    End Function

End Class


