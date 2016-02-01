Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Permisos_UsuarioDAL

    Public Shared Function Insertar(ByVal Id_Pagina As Int32, ByVal Id_Usuario As Int32, ByVal Pver As Boolean, ByVal Pconsultar As Boolean, ByVal Pexportarpdf As Boolean, ByVal Pexportarword As Boolean, ByVal Pexportarcsv As Boolean, ByVal Pexportarexcel As Boolean, ByVal Pcrear As Boolean, ByVal Peditar As Boolean, ByVal Peliminar As Boolean, ByVal Pvertodo As Boolean, ByVal pcontrolvisible As Boolean) As Int32
        Return SqlHelper.ExecuteScalar(strCadena, "dbo.Permisos_UsuarioInsertar", isNothingToDBNull(Id_Pagina), isNothingToDBNull(Id_Usuario), isNothingToDBNull(Pver), isNothingToDBNull(Pconsultar), isNothingToDBNull(Pexportarpdf), isNothingToDBNull(Pexportarword), isNothingToDBNull(Pexportarcsv), isNothingToDBNull(Pexportarexcel), isNothingToDBNull(Pcrear), isNothingToDBNull(Peditar), isNothingToDBNull(Peliminar), isNothingToDBNull(Pvertodo), isNothingToDBNull(pcontrolvisible))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Pagina As Int32, ByVal Id_Usuario As Int32, ByVal Pver As Boolean, ByVal Pconsultar As Boolean, ByVal Pexportarpdf As Boolean, ByVal Pexportarword As Boolean, ByVal Pexportarcsv As Boolean, ByVal Pexportarexcel As Boolean, ByVal Pcrear As Boolean, ByVal Peditar As Boolean, ByVal Peliminar As Boolean, ByVal Pvertodo As Boolean, ByVal pcontrolvisible As Boolean)
        SqlHelper.ExecuteNonQuery(strCadena, "dbo.Permisos_UsuarioActualizar", Id, isNothingToDBNull(Id_Pagina), isNothingToDBNull(Id_Usuario), isNothingToDBNull(Pver), isNothingToDBNull(Pconsultar), isNothingToDBNull(Pexportarpdf), isNothingToDBNull(Pexportarword), isNothingToDBNull(Pexportarcsv), isNothingToDBNull(Pexportarexcel), isNothingToDBNull(Pcrear), isNothingToDBNull(Peditar), isNothingToDBNull(Peliminar), isNothingToDBNull(pvertodo), isNothingToDBNull(pcontrolvisible))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadena, "dbo.Permisos_UsuarioEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_UsuarioConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_UsuarioConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_Pagina(ByVal Id_Pagina As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_UsuarioConsultarPorId_Pagina", Id_Pagina)
    End Function

    Public Shared Function CargarPorId_Usuario(ByVal Id_Usuario As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_UsuarioConsultarPorId_Usuario", Id_Usuario)
    End Function

    Public Shared Function CargarPorId_Usuario_Pagina(ByVal Id_usuario As Int32, ByVal Id_Pagina As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_PerfilConsultarPorId_Usuario_Pagina", Id_usuario, Id_Pagina)
    End Function

End Class

