Imports ingNovar.Utilidades2

Partial Public Class PerfilesBrl

    Private _Id As Int32
    Private _Descripcion As String

    Private objListPermisos_Perfil As List(Of Permisos_PerfilBrl)
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

    Public Property Permisos_Perfil() As List(Of Permisos_PerfilBrl)
        Get
            If (Me.objListPermisos_Perfil Is Nothing) Then
                objListPermisos_Perfil = Permisos_PerfilBrl.CargarPorId_Perfil(Me.ID)
            End If
            Return Me.objListPermisos_Perfil
        End Get
        Set(ByVal Value As List(Of Permisos_PerfilBrl))
            Me.objListPermisos_Perfil = Value
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
            Me.ID = PerfilesDAL.Insertar(Descripcion)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            PerfilesDAL.Actualizar(ID, Descripcion)
            RaiseEvent Updated()
        End If
        If Not objListPermisos_Perfil Is Nothing Then
            For Each fila As Permisos_PerfilBrl In objListPermisos_Perfil
                fila.Id_Perfil = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
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

            totalHijos += Permisos_Perfil.Count
            totalHijos += Usuarios.Count

            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")

            PerfilesDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As PerfilesBrl

        Dim objPerfiles As New PerfilesBrl

        With objPerfiles
            .ID = fila("Id")
            .Descripcion = isDBNullToNothing(fila("Descripcion"))

        End With

        Return objPerfiles

    End Function

    Public Shared Event LoadingPerfilesList(ByVal LoadType As String)
    Public Shared Event LoadedPerfilesList(ByVal target As List(Of PerfilesBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of PerfilesBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of PerfilesBrl)

        RaiseEvent LoadingPerfilesList("CargarTodos")

        dsDatos = PerfilesDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPerfilesList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As PerfilesBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As PerfilesBrl

        Dim dsDatos As System.Data.DataSet
        Dim objPerfiles As PerfilesBrl = Nothing

        dsDatos = PerfilesDAL.CargarPorID(ID)

        If dsDatos.Tables(0).Rows.Count <> 0 Then objPerfiles = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objPerfiles

    End Function

End Class


