Imports ingNovar.Utilidades2

Partial Public Class UsuariosBrl

    Private _Id As Int32
    Private _Login As String
    Private _Contrasena As String
    Private _Nombre_Completo As String
    Private _Correo As String
    Private _Activo As Boolean
    Private _Id_Perfil As Int32
    Private _Id_Sucursal As Int32

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

    Public Event LoginChanging(ByVal Value As String)
    Public Event LoginChanged()

    Public Property Login() As String
        Get
            Return Me._Login
        End Get
        Set(ByVal Value As String)
            If _Login <> Value Then
                RaiseEvent LoginChanging(Value)
				Me._Login = Value
                RaiseEvent LoginChanged()
            End If
        End Set
    End Property

    Public Event ContrasenaChanging(ByVal Value As String)
    Public Event ContrasenaChanged()
	
    Public Property Contrasena() As String
        Get
            Return Me._Contrasena
        End Get
        Set(ByVal Value As String)
            If _Contrasena <> Value Then
                RaiseEvent ContrasenaChanging(Value)
                Me._Contrasena = Value
                RaiseEvent ContrasenaChanged()
            End If
        End Set
    End Property

    Public Event Nombre_CompletoChanging(ByVal Value As String)
    Public Event Nombre_CompletoChanged()

    Public Property Nombre_Completo() As String
        Get
            Return Me._Nombre_Completo
        End Get
        Set(ByVal Value As String)
            If _Nombre_Completo <> Value Then
                RaiseEvent Nombre_CompletoChanging(Value)
				Me._Nombre_Completo = Value
                RaiseEvent Nombre_CompletoChanged()
            End If
        End Set
    End Property

    Public Event CorreoChanging(ByVal Value As String)
    Public Event CorreoChanged()

    Public Property Correo() As String
        Get
            Return Me._Correo
        End Get
        Set(ByVal Value As String)
            If _Correo <> Value Then
                RaiseEvent CorreoChanging(Value)
				Me._Correo = Value
                RaiseEvent CorreoChanged()
            End If
        End Set
    End Property

    Public Event ActivoChanging(ByVal Value As Boolean)
    Public Event ActivoChanged()
	
    Public Property Activo() As Boolean
        Get
            Return Me._Activo
        End Get
        Set(ByVal Value As Boolean)
            If _Activo <> Value Then
                RaiseEvent ActivoChanging(Value)
                Me._Activo = Value
                RaiseEvent ActivoChanged()
            End If
        End Set
    End Property

    Public Event Id_PerfilChanging(ByVal Value As Int32)
    Public Event Id_PerfilChanged()
	
    Public Property Id_Perfil() As Int32
        Get
            Return Me._Id_Perfil
        End Get
        Set(ByVal Value As Int32)
            If _Id_Perfil <> Value Then
                RaiseEvent Id_PerfilChanging(Value)
                Me._Id_Perfil = Value
                RaiseEvent Id_PerfilChanged()
            End If
        End Set
    End Property

    Public Event Id_SucursalChanging(ByVal Value As Int32)
    Public Event Id_SucursalChanged()

    Public Property Id_Sucursal() As Int32
        Get
            Return Me._Id_Sucursal
        End Get
        Set(ByVal Value As Int32)
            If _Id_Sucursal <> Value Then
                RaiseEvent Id_SucursalChanging(Value)
                Me._Id_Sucursal = Value
                RaiseEvent Id_SucursalChanged()
            End If
        End Set
    End Property

    Public Property Permisos_Usuario() As List(Of Permisos_UsuarioBrl)
        Get
            If (Me.objListPermisos_Usuario Is Nothing) Then
                objListPermisos_Usuario = Permisos_UsuarioBrl.CargarPorId_Usuario(Me.ID)
            End If
            Return Me.objListPermisos_Usuario
        End Get
        Set(ByVal Value As List(Of Permisos_UsuarioBrl))
            Me.objListPermisos_Usuario = Value
        End Set
    End Property

    Public Readonly Property Perfiles() As PerfilesBrl
        Get
            Return PerfilesBrl.CargarPorID(Id_Perfil)
        End Get
    End Property

    Public ReadOnly Property Sucursales() As SucursalesBrl
        Get
            Return SucursalesBrl.CargarPorID(Id_Sucursal)
        End Get
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
            Me.ID = UsuariosDAL.Insertar(Login, Contrasena, Nombre_Completo, Correo, Activo, Id_Perfil, Id_Sucursal)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            UsuariosDAL.Actualizar(ID, Login, Contrasena, Nombre_Completo, Correo, Activo, Id_Perfil, Id_Sucursal)
            RaiseEvent Updated()
        End If
        If Not objListPermisos_Usuario Is Nothing Then
            For Each fila As Permisos_UsuarioBrl In objListPermisos_Usuario
                fila.Id_Usuario = Me.ID
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
            totalHijos += Permisos_Usuario.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            UsuariosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As UsuariosBrl

        Dim objUsuarios As New UsuariosBrl

        With objUsuarios
            .ID = fila("Id")
            .Login = isDBNullToNothing(fila("Login"))
            .Contrasena = isDBNullToNothing(fila("Contrasena"))
            .Nombre_Completo = isDBNullToNothing(fila("Nombre_Completo"))
            .Correo = isDBNullToNothing(fila("Correo"))
            .Activo = isDBNullToNothing(fila("Activo"))
            .Id_Perfil = isDBNullToNothing(fila("Id_Perfil"))
            .Id_Sucursal = isDBNullToNothing(fila("Id_Sucursal"))

        End With

        Return objUsuarios

    End Function
	
	Public Shared Event LoadingUsuariosList(ByVal LoadType As String)
	Public Shared Event LoadedUsuariosList(target As List(Of UsuariosBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of UsuariosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of UsuariosBrl)
	
		RaiseEvent LoadingUsuariosList("CargarTodos")
	
		dsDatos = UsuariosDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedUsuariosList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As UsuariosBrl)

	Public Shared Function CargarPorID(ID As Int32) As UsuariosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objUsuarios As UsuariosBrl = Nothing 
		
        dsDatos = UsuariosDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objUsuarios = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objUsuarios
        
    End Function

	Public Shared Function CargarPorId_Perfil(ByVal Id_Perfil As Int32) As List(Of UsuariosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of UsuariosBrl)
	
		RaiseEvent LoadingUsuariosList("CargarPorId_Perfil")
		
		dsDatos = UsuariosDAL.CargarPorId_Perfil(Id_Perfil)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedUsuariosList(lista, "CargarPorId_Perfil")
        
        Return lista
        
	End Function

    Public Shared Function CargarPorloginyContrasena(ByVal login As String, ByVal contrasena As String) As UsuariosBrl

        Dim dsDatos As System.Data.DataSet
        Dim objUsuarios As UsuariosBrl = Nothing
        dsDatos = UsuariosDAL.CargarPorLoginyContrasena(login, contrasena)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objUsuarios = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objUsuarios

    End Function

    Public Shared Function CargarPorLogin(ByVal Login As String) As UsuariosBrl
        Dim dsDatos As System.Data.DataSet
        Dim objUsuarios As UsuariosBrl = Nothing
        dsDatos = UsuariosDAL.CargarPorLogin(Login)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objUsuarios = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objUsuarios
    End Function

End Class


