using System.Collections.Generic;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{   //TODO: Make static function to getID of tables so it will less memory uses and fast
    public interface iDatabase<T>
    {
        int InsertData( T obj );

        int UpdateData( T obj );

        int Delete( object obj );

        bool IsTableExist( );

        int GetID( string colName, object colValue );

        T GetByID( int id );

        T GetByColName( string colName, object colValue );

        int GenerateId( );

        List<T> GetAllRecord( );
    }
}