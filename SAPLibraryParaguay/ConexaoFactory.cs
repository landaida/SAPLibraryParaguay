using System.Data.SqlClient;

namespace SAPLibraryParaguay
{
    public static class ConexaoFactory
    {
        private static SqlConnection connection;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(DBConfig.cadenaConexionBD);
            }
            set
            {
                connection = value;
            }
        }

    }
}

