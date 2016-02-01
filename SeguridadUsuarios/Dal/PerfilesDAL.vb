Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class PerfilesDAL

    Public Shared Function Insertar(ByVal Descripcion As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadena, "dbo.PerfilesInsertar", isNothingToDBNull(Descripcion))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Descripcion As String)
        SqlHelper.ExecuteNonQuery(strCadena, "dbo.PerfilesActualizar", Id, isNothingToDBNull(Descripcion))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadena, "dbo.PerfilesEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.PerfilesConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadena, "dbo.PerfilesConsultarPorID", Id)
    End Function
    

End Class

