Imports ingNovar.Utilidades2

Partial Public Class Permisos_UsuarioBrl

    Private _Id As Int32
    Private _Id_Pagina As Int32
    Private _Id_Usuario As Int32
    Private _Pver As Boolean
    Private _Pconsultar As Boolean
    Private _Pexportarpdf As Boolean
    Private _Pexportarword As Boolean
    Private _Pexportarcsv As Boolean
    Private _Pexportarexcel As Boolean
    Private _Pcrear As Boolean
    Private _Peditar As Boolean
    Private _Peliminar As Boolean
    Private _Pvertodo As Boolean
    Private _Pcontrolvisible As Boolean

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

    Public Event Id_PaginaChanging(ByVal Value As Int32)
    Public Event Id_PaginaChanged()

    Public Property Id_Pagina() As Int32
        Get
            Return Me._Id_Pagina
        End Get
        Set(ByVal Value As Int32)
            If _Id_Pagina <> Value Then
                RaiseEvent Id_PaginaChanging(Value)
				Me._Id_Pagina = Value
                RaiseEvent Id_PaginaChanged()
            End If
        End Set
    End Property

    Public Event Id_UsuarioChanging(ByVal Value As Int32)
    Public Event Id_UsuarioChanged()
	
    Public Property Id_Usuario() As Int32
        Get
            Return Me._Id_Usuario
        End Get
        Set(ByVal Value As Int32)
            If _Id_Usuario <> Value Then
                RaiseEvent Id_UsuarioChanging(Value)
                Me._Id_Usuario = Value
                RaiseEvent Id_UsuarioChanged()
            End If
        End Set
    End Property

    Public Event PverChanging(ByVal Value As Boolean)
    Public Event PverChanged()
	
    Public Property Pver() As Boolean
        Get
            Return Me._Pver
        End Get
        Set(ByVal Value As Boolean)
            If _Pver <> Value Then
                RaiseEvent PverChanging(Value)
                Me._Pver = Value
                RaiseEvent PverChanged()
            End If
        End Set
    End Property

    Public Event PconsultarChanging(ByVal Value As Boolean)
    Public Event PconsultarChanged()
	
    Public Property Pconsultar() As Boolean
        Get
            Return Me._Pconsultar
        End Get
        Set(ByVal Value As Boolean)
            If _Pconsultar <> Value Then
                RaiseEvent PconsultarChanging(Value)
                Me._Pconsultar = Value
                RaiseEvent PconsultarChanged()
            End If
        End Set
    End Property

    Public Event PexportarpdfChanging(ByVal Value As Boolean)
    Public Event PexportarpdfChanged()
	
    Public Property Pexportarpdf() As Boolean
        Get
            Return Me._Pexportarpdf
        End Get
        Set(ByVal Value As Boolean)
            If _Pexportarpdf <> Value Then
                RaiseEvent PexportarpdfChanging(Value)
                Me._Pexportarpdf = Value
                RaiseEvent PexportarpdfChanged()
            End If
        End Set
    End Property

    Public Event PexportarwordChanging(ByVal Value As Boolean)
    Public Event PexportarwordChanged()

    Public Property Pexportarword() As Boolean
        Get
            Return Me._Pexportarword
        End Get
        Set(ByVal Value As Boolean)
            If _Pexportarword <> Value Then
                RaiseEvent PexportarwordChanging(Value)
				Me._Pexportarword = Value
                RaiseEvent PexportarwordChanged()
            End If
        End Set
    End Property

    Public Event PexportarcsvChanging(ByVal Value As Boolean)
    Public Event PexportarcsvChanged()
	
    Public Property Pexportarcsv() As Boolean
        Get
            Return Me._Pexportarcsv
        End Get
        Set(ByVal Value As Boolean)
            If _Pexportarcsv <> Value Then
                RaiseEvent PexportarcsvChanging(Value)
                Me._Pexportarcsv = Value
                RaiseEvent PexportarcsvChanged()
            End If
        End Set
    End Property

    Public Event PexportarexcelChanging(ByVal Value As Boolean)
    Public Event PexportarexcelChanged()
	
    Public Property Pexportarexcel() As Boolean
        Get
            Return Me._Pexportarexcel
        End Get
        Set(ByVal Value As Boolean)
            If _Pexportarexcel <> Value Then
                RaiseEvent PexportarexcelChanging(Value)
                Me._Pexportarexcel = Value
                RaiseEvent PexportarexcelChanged()
            End If
        End Set
    End Property

    Public Event PcrearChanging(ByVal Value As Boolean)
    Public Event PcrearChanged()
	
    Public Property Pcrear() As Boolean
        Get
            Return Me._Pcrear
        End Get
        Set(ByVal Value As Boolean)
            If _Pcrear <> Value Then
                RaiseEvent PcrearChanging(Value)
                Me._Pcrear = Value
                RaiseEvent PcrearChanged()
            End If
        End Set
    End Property

    Public Event PeditarChanging(ByVal Value As Boolean)
    Public Event PeditarChanged()
	
    Public Property Peditar() As Boolean
        Get
            Return Me._Peditar
        End Get
        Set(ByVal Value As Boolean)
            If _Peditar <> Value Then
                RaiseEvent PeditarChanging(Value)
                Me._Peditar = Value
                RaiseEvent PeditarChanged()
            End If
        End Set
    End Property

    Public Event PeliminarChanging(ByVal Value As Boolean)
    Public Event PeliminarChanged()
	
    Public Property Peliminar() As Boolean
        Get
            Return Me._Peliminar
        End Get
        Set(ByVal Value As Boolean)
            If _Peliminar <> Value Then
                RaiseEvent PeliminarChanging(Value)
                Me._Peliminar = Value
                RaiseEvent PeliminarChanged()
            End If
        End Set
    End Property

    Public Event PvertodoChanging(ByVal Value As Boolean)
    Public Event PvertodoChanged()

    Public Property Pvertodo() As Boolean
        Get
            Return Me._Pvertodo
        End Get
        Set(ByVal Value As Boolean)
            If _Pvertodo <> Value Then
                RaiseEvent PvertodoChanging(Value)
                Me._Pvertodo = Value
                RaiseEvent PvertodoChanged()
            End If
        End Set
    End Property

    Public Event PcontrolvisibleChanging(ByVal Value As Boolean)
    Public Event PcontrolvisibleChanged()

    Public Property Pcontrolvisible() As Boolean
        Get
            Return Me._Pcontrolvisible
        End Get
        Set(ByVal Value As Boolean)
            If _Pcontrolvisible <> Value Then
                RaiseEvent PcontrolvisibleChanging(Value)
                Me._Pcontrolvisible = Value
                RaiseEvent PcontrolvisibleChanged()
            End If
        End Set
    End Property

    Public Readonly Property Paginas() As PaginasBrl
        Get
            Return PaginasBrl.CargarPorID(Id_Pagina)
        End Get
    End Property

    Public Readonly Property Usuarios() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario)
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
            Me.ID = Permisos_UsuarioDAL.Insertar(Id_Pagina, Id_Usuario, Pver, Pconsultar, Pexportarpdf, Pexportarword, Pexportarcsv, Pexportarexcel, Pcrear, Peditar, Peliminar, Pvertodo, Pcontrolvisible)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Permisos_UsuarioDAL.Actualizar(ID, Id_Pagina, Id_Usuario, Pver, Pconsultar, Pexportarpdf, Pexportarword, Pexportarcsv, Pexportarexcel, Pcrear, Peditar, Peliminar, Pvertodo, Pcontrolvisible)
            RaiseEvent Updated()
        End If
        RaiseEvent Saved()

    End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            Permisos_UsuarioDAL.Eliminar(Me.ID)
            RaiseEvent Deleted()
            
        End If
	End Sub
	
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Permisos_UsuarioBrl

        Dim objPermisos_Usuario As New Permisos_UsuarioBrl

        With objPermisos_Usuario
            .ID = fila("Id")
            .Id_Pagina = isDBNullToNothing(fila("Id_Pagina"))
            .Id_Usuario = isDBNullToNothing(fila("Id_Usuario"))
            .Pver = isDBNullToNothing(fila("Pver"))
            .Pconsultar = isDBNullToNothing(fila("Pconsultar"))
            .Pexportarpdf = isDBNullToNothing(fila("Pexportarpdf"))
            .Pexportarword = isDBNullToNothing(fila("Pexportarword"))
            .Pexportarcsv = isDBNullToNothing(fila("Pexportarcsv"))
            .Pexportarexcel = isDBNullToNothing(fila("Pexportarexcel"))
            .Pcrear = isDBNullToNothing(fila("Pcrear"))
            .Peditar = isDBNullToNothing(fila("Peditar"))
            .Peliminar = isDBNullToNothing(fila("Peliminar"))
            .Pvertodo = isDBNullToNothing(fila("Pvertodo"))
            .Pcontrolvisible = isDBNullToNothing(fila("Pcontrolvisible"))
        End With

        Return objPermisos_Usuario

    End Function
	
	Public Shared Event LoadingPermisos_UsuarioList(ByVal LoadType As String)
	Public Shared Event LoadedPermisos_UsuarioList(target As List(Of Permisos_UsuarioBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Permisos_UsuarioBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Permisos_UsuarioBrl)
        RaiseEvent LoadingPermisos_UsuarioList("CargarTodos")
        dsDatos = Permisos_UsuarioDAL.CargarTodos()
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedPermisos_UsuarioList(lista, "CargarTodos")
        Return lista
    End Function

	Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As Permisos_UsuarioBrl)

	Public Shared Function CargarPorID(ID As Int32) As Permisos_UsuarioBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPermisos_Usuario As Permisos_UsuarioBrl = Nothing 

        dsDatos = Permisos_UsuarioDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objPermisos_Usuario = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))


        Return objPermisos_Usuario
        
    End Function

	Public Shared Function CargarPorId_Pagina(ByVal Id_Pagina As Int32) As List(Of Permisos_UsuarioBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Permisos_UsuarioBrl)
	
		RaiseEvent LoadingPermisos_UsuarioList("CargarPorId_Pagina")
		
		dsDatos = Permisos_UsuarioDAL.CargarPorId_Pagina(Id_Pagina)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPermisos_UsuarioList(lista, "CargarPorId_Pagina")
        
        Return lista
        
	End Function

    Public Shared Function CargarPorId_Usuario(ByVal Id_Usuario As Int32) As List(Of Permisos_UsuarioBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Permisos_UsuarioBrl)

        RaiseEvent LoadingPermisos_UsuarioList("CargarPorId_Usuario")

        dsDatos = Permisos_UsuarioDAL.CargarPorId_Usuario(Id_Usuario)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPermisos_UsuarioList(lista, "CargarPorId_Usuario")

        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Pagina(ByVal Id_usuario As Int32, ByVal id_pagina As Int32) As Permisos_UsuarioBrl
        Dim dsDatos As System.Data.DataSet
        Dim objPermisos_Usuario As Permisos_UsuarioBrl = Nothing
        dsDatos = Permisos_UsuarioDAL.CargarPorId_Usuario_Pagina(Id_usuario, id_pagina)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPermisos_Usuario = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPermisos_Usuario
    End Function

End Class


