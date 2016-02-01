Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Permisos_PerfilDAL

    Public Shared Function Insertar(ByVal Id_Perfil As Int32, ByVal Id_Pagina As Int32, ByVal Pver As Boolean, ByVal Pconsultar As Boolean, ByVal Pexportarpdf As Boolean, ByVal Pexportarword As Boolean, ByVal Pexportarcsv As Boolean, ByVal Pexportarexcel As Boolean, ByVal Pcrear As Boolean, ByVal Peditar As Boolean, ByVal Peliminar As Boolean, ByVal Pvertodo As Boolean, ByVal Pcontrolvisible As Boolean) As Int32
        Return SqlHelper.ExecuteScalar(strCadena, "dbo.Permisos_PerfilInsertar", Id_Perfil, Id_Pagina, isNothingToDBNull(Pver), isNothingToDBNull(Pconsultar), isNothingToDBNull(Pexportarpdf), isNothingToDBNull(Pexportarword), isNothingToDBNull(Pexportarcsv), isNothingToDBNull(Pexportarexcel), isNothingToDBNull(Pcrear), isNothingToDBNull(Peditar), isNothingToDBNull(Peliminar), isNothingToDBNull(Pvertodo), isNothingToDBNull(Pcontrolvisible))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Perfil As Int32, ByVal Id_Pagina As Int32, ByVal Pver As Boolean, ByVal Pconsultar As Boolean, ByVal Pexportarpdf As Boolean, ByVal Pexportarword As Boolean, ByVal Pexportarcsv As Boolean, ByVal Pexportarexcel As Boolean, ByVal Pcrear As Boolean, ByVal Peditar As Boolean, ByVal Peliminar As Boolean, ByVal Pvertodo As Boolean, ByVal Pcontrolvisible As Boolean)
        SqlHelper.ExecuteNonQuery(strCadena, "dbo.Permisos_PerfilActualizar", Id, Id_Perfil, Id_Pagina, isNothingToDBNull(Pver), isNothingToDBNull(Pconsultar), isNothingToDBNull(Pexportarpdf), isNothingToDBNull(Pexportarword), isNothingToDBNull(Pexportarcsv), isNothingToDBNull(Pexportarexcel), isNothingToDBNull(Pcrear), isNothingToDBNull(Peditar), isNothingToDBNull(Peliminar), isNothingToDBNull(Pvertodo), isNothingToDBNull(Pcontrolvisible))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadena, "dbo.Permisos_PerfilEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_PerfilConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_PerfilConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_Pagina(ByVal Id_Pagina As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_PerfilConsultarPorId_Pagina", Id_Pagina)
    End Function

    Public Shared Function CargarPorId_Perfil(ByVal Id_Perfil As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_PerfilConsultarPorId_Perfil", Id_Perfil)
    End Function

    Public Shared Function CargarPorId_Perfil_Pagina(ByVal Id_Perfil As Int32, ByVal Id_Pagina As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.Permisos_PerfilConsultarPorId_Perfil_Pagina", Id_Perfil, Id_Pagina)
    End Function

End Class

