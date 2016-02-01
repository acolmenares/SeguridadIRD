
Public Class Usuarios

    Public Shared Function EstadoPerPagina(ByVal id_perfil As Int32, ByVal id_pagina As Int32) As Permisos_PerfilBrl
        Dim objpermisoPer As New Permisos_PerfilBrl
        objpermisoPer = Permisos_PerfilBrl.CargarPorId_Perfil_Pagina(id_perfil, id_pagina)
        Return objpermisoPer
    End Function

    Public Shared Function EstadoPerUsuario(ByVal id_usuario As Int32, ByVal id_pagina As Int32) As Permisos_UsuarioBrl
        Dim objpermisoUsu As New Permisos_UsuarioBrl
        objpermisoUsu = Permisos_UsuarioBrl.CargarPorId_Usuario_Pagina(id_usuario, id_pagina)
        Return objpermisoUsu
    End Function

    Public Shared Function RegionalUsuario(ByVal id_usuario As Int32) As Int32
        Dim objusuario As UsuariosBrl = UsuariosBrl.CargarPorID(id_usuario)
        Return objusuario.Sucursales.ID_Enlace
    End Function


End Class
