using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;

    public class DataBase
    {
        // Propiedad estática para establecer el tiempo de espera de conexión en segundos
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para establecer el nombre de la aplicación en la cadena de conexión
        public static string ApplicationName { get; set; }

        // Propiedad estática de solo lectura que genera y devuelve la cadena de conexión completa
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión desde el archivo de configuración usando la clave "NWConnection"
                string CadenaConexion = ConfigurationManager.ConnectionStrings["NWConnection"].ConnectionString;

                // Crea un objeto SqlConnectionStringBuilder a partir de la cadena de conexión obtenida
                SqlConnectionStringBuilder conexionBuilder = new SqlConnectionStringBuilder(CadenaConexion);

                // Actualiza el nombre de la aplicación si se ha especificado uno
                conexionBuilder.ApplicationName = ApplicationName ?? conexionBuilder.ApplicationName;

                // Actualiza el tiempo de espera de conexión si se ha especificado un valor mayor que 0
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión actualizada como una cadena de texto
                return conexionBuilder.ToString();
            }
        }

        // Método estático que crea y abre una conexión a la base de datos
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva instancia de SqlConnection usando la cadena de conexión generada
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión a la base de datos
            conexion.Open();

            // Devuelve la conexión abierta
            return conexion;
        }
    }

}
