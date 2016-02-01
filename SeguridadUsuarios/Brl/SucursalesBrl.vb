Imports ingnovar.utilidades2

Partial Public Class SucursalesBrl

    Private _Id As Int32
    Private _Descripcion As String
    Private _Id_Enlace As Int32

    Private objListUsuarios As List(Of UsuariosBrl)

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

    Public Event ID_EnlaceChanging(ByVal Value As Int32)
    Public Event ID_EnlaceChanged()

    Public Property ID_Enlace() As Int32
        Get
            Return Me._Id_Enlace
        End Get
        Set(ByVal Value As Int32)
            If _Id_Enlace <> Value Then
                RaiseEvent ID_EnlaceChanging(Value)
                Me._Id_Enlace = Value
                RaiseEvent ID_EnlaceChanged()
            End If
        End Set
    End Property

    Public Property Usuarios() As List(Of UsuariosBrl)
        Get
            If (Me.objListUsuarios Is Nothing) Then
                objListUsuarios = UsuariosBrl.CargarPorId_Perfil(Me.ID)
            End If
            Return Me.objListUsuarios
        End Get
        Set(ByVal Value As List(Of UsuariosBrl))
            Me.objListUsuarios = Value
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
            Me.ID = SucursalesDAL.Insertar(Descripcion, ID_Enlace)
            RaiseEvent Inserted()
        Else
            SucursalesDAL.Actualizar(ID, Descripcion, ID_Enlace)
            RaiseEvent Updated()
        End If

        If Not objListUsuarios Is Nothing Then
            For Each fila As UsuariosBrl In objListUsuarios
                fila.Id_Perfil = Me.ID
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
            totalHijos += Usuarios.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            SucursalesDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As SucursalesBrl

        Dim objSucursales As New SucursalesBrl
        With objSucursales
            .ID = fila("Id")
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
            .ID_Enlace = isDBNullToNothing(fila("ID_Enlace"))
        End With

        Return objSucursales

    End Function

    Public Shared Event LoadingSucursalesList(ByVal LoadType As String)
    Public Shared Event LoadedSucursalesList(ByVal target As List(Of SucursalesBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of SucursalesBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SucursalesBrl)

        RaiseEvent LoadingSucursalesList("CargarTodos")

        dsDatos = SucursalesDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedSucursalesList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As SucursalesBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As SucursalesBrl

        Dim dsDatos As System.Data.DataSet
        Dim objSucursales As SucursalesBrl = Nothing

        dsDatos = SucursalesDAL.CargarPorID(ID)

        If dsDatos.Tables(0).Rows.Count <> 0 Then objSucursales = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objSucursales

    End Function

End Class


