Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class UsuariosDAL

    Public Shared Function Insertar(ByVal Login As String, ByVal Contrasena As String, ByVal Nombre_Completo As String, ByVal Correo As String, ByVal Activo As Boolean, ByVal Id_Perfil As Int32, ByVal Id_Sucursal As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadena, "dbo.UsuariosInsertar", isNothingToDBNull(Login), isNothingToDBNull(Contrasena), isNothingToDBNull(Nombre_Completo), isNothingToDBNull(Correo), isNothingToDBNull(Activo), isNothingToDBNull(Id_Perfil), isNothingToDBNull(Id_Sucursal))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Login As String, ByVal Contrasena As String, ByVal Nombre_Completo As String, ByVal Correo As String, ByVal Activo As Boolean, ByVal Id_Perfil As Int32, ByVal Id_Sucursal As Int32)
        SqlHelper.ExecuteNonQuery(strCadena, "dbo.UsuariosActualizar", Id, isNothingToDBNull(Login), isNothingToDBNull(Contrasena), isNothingToDBNull(Nombre_Completo), isNothingToDBNull(Correo), isNothingToDBNull(Activo), isNothingToDBNull(Id_Perfil), isNothingToDBNull(Id_Sucursal))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadena, "dbo.UsuariosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.UsuariosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.UsuariosConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_Perfil(ByVal Id_Perfil As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.UsuariosConsultarPorId_Perfil", Id_Perfil)
    End Function

    Public Shared Function CargarPorId_Sucursal(ByVal Id_Sucursal As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.UsuariosConsultarPorId_Sucursal", Id_Sucursal)
    End Function

    Public Shared Function CargarPorloginyContrasena(ByVal login As String, ByVal contrasena As String) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.UsuariosConsultarPorloginyContrasena", login, contrasena)
    End Function

    Public Shared Function CargarPorLogin(ByVal Login As String) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.UsuariosConsultarPorlogin", Login)
    End Function

End Class

