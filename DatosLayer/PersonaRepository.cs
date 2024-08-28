using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class PersonaRepository
    {
        public List<Person> ObtenerDatos()
        {
            // Establece una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para seleccionar todos los campos necesarios de la tabla [Suppliers]
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [SupplierID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "      ,[HomePage] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]";

                // Crea un comando SQL utilizando la consulta construida y la conexión establecida
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Ejecuta el comando y obtiene un SqlDataReader para leer los datos
                    SqlDataReader reader = comando.ExecuteReader();

                    // Crea una lista para almacenar los objetos Person leídos de la base de datos
                    List<Person> persona = new List<Person>();

                    // Lee los datos del SqlDataReader mientras haya filas disponibles
                    while (reader.Read())
                    {
                        // Convierte la fila actual en un objeto Person utilizando el método LeerDelDataReader
                        var person = LeerDelDataReader(reader);

                        // Añade el objeto Person a la lista
                        persona.Add(person);
                    }

                    // Devuelve la lista de objetos Person
                    return persona;
                }
            }
        }

        public Person LeerDelDataReader(SqlDataReader reader)
        {
            // Crea una nueva instancia de Person para almacenar los datos leídos
            Person persona = new Person();

            // Lee el valor de SupplierID del SqlDataReader, manejando posibles valores nulos
            persona.SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : (int)reader["SupplierID"];

            // Lee el valor de CompanyName del SqlDataReader, manejando posibles valores nulos
            persona.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (string)reader["CompanyName"];

            // Lee el valor de ContactName del SqlDataReader, manejando posibles valores nulos
            persona.ContactName = reader["ContactName"] == DBNull.Value ? "" : (string)reader["ContactName"];

            // Lee el valor de ContactTitle del SqlDataReader, manejando posibles valores nulos
            persona.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (string)reader["ContactTitle"];

            // Lee el valor de Address del SqlDataReader, manejando posibles valores nulos
            persona.Address = reader["Address"] == DBNull.Value ? "" : (string)reader["Address"];

            // Lee el valor de City del SqlDataReader, manejando posibles valores nulos
            persona.City = reader["City"] == DBNull.Value ? "" : (string)reader["City"];

            // Lee el valor de Region del SqlDataReader, manejando posibles valores nulos
            persona.Region = reader["Region"] == DBNull.Value ? "" : (string)reader["Region"];

            // Lee el valor de PostalCode del SqlDataReader, manejando posibles valores nulos
            persona.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (string)reader["PostalCode"];

            // Lee el valor de Country del SqlDataReader, manejando posibles valores nulos
            persona.Country = reader["Country"] == DBNull.Value ? "" : (string)reader["Country"];

            // Lee el valor de Phone del SqlDataReader, manejando posibles valores nulos
            persona.Phone = reader["Phone"] == DBNull.Value ? "" : (string)reader["Phone"];

            // Lee el valor de Fax del SqlDataReader, manejando posibles valores nulos
            persona.Fax = reader["Fax"] == DBNull.Value ? "" : (string)reader["Fax"];

            // Lee el valor de HomePage del SqlDataReader, manejando posibles valores nulos
            persona.HomePage = reader["HomePage"] == DBNull.Value ? "" : (string)reader["HomePage"];

            // Devuelve el objeto Person con los datos leídos
            return persona;
        }

        public int añadirPersonal(Person persona)
        {
            // Establece una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para insertar un nuevo registro en la tabla [Suppliers]
                String InsertPerson = "";
                InsertPerson = InsertPerson + "INSERT INTO [dbo].[Suppliers] " + "\n";
                InsertPerson = InsertPerson + "           ([CompanyName] " + "\n";
                InsertPerson = InsertPerson + "           ,[ContactName] " + "\n";
                InsertPerson = InsertPerson + "           ,[ContactTitle] " + "\n";
                InsertPerson = InsertPerson + "           ,[City] " + "\n";
                InsertPerson = InsertPerson + "           ,[PostalCode] " + "\n";
                InsertPerson = InsertPerson + "           ,[Country] " + "\n";
                InsertPerson = InsertPerson + "           ,[Phone])" + "\n";
                InsertPerson = InsertPerson + "     VALUES " + "\n";
                InsertPerson = InsertPerson + "           (@CompanyName" + "\n";
                InsertPerson = InsertPerson + "           ,@ContactName" + "\n";
                InsertPerson = InsertPerson + "           ,@ContactTitle" + "\n";
                InsertPerson = InsertPerson + "           ,@City" + "\n";
                InsertPerson = InsertPerson + "           ,@PostalCode" + "\n";
                InsertPerson = InsertPerson + "           ,@Country" + "\n";
                InsertPerson = InsertPerson + "           ,@Phone)";

                // Crea un comando SQL utilizando la consulta de inserción y la conexión establecida
                using (var comando = new SqlCommand(InsertPerson, conexion))
                {
                    // Configura los parámetros del comando con los datos del objeto Person
                    int insertados = parametrosPersonal(persona, comando);

                    // Devuelve el número de registros insertados
                    return insertados;
                }
            }
        }

        public int parametrosPersonal(Person personal, SqlCommand comando)
        {
            // Añade un parámetro para el nombre de la empresa al comando SQL
            comando.Parameters.AddWithValue("CompanyName", personal.CompanyName);

            // Añade un parámetro para el nombre del contacto al comando SQL
            comando.Parameters.AddWithValue("ContactName", personal.ContactName);

            // Añade un parámetro para el título del contacto al comando SQL
            comando.Parameters.AddWithValue("ContactTitle", personal.ContactTitle);

            // Añade un parámetro para la ciudad al comando SQL
            comando.Parameters.AddWithValue("City", personal.City);

            // Añade un parámetro para el código postal al comando SQL
            comando.Parameters.AddWithValue("PostalCode", personal.PostalCode);

            // Añade un parámetro para el país al comando SQL
            comando.Parameters.AddWithValue("Country", personal.Country);

            // Añade un parámetro para el teléfono al comando SQL
            comando.Parameters.AddWithValue("Phone", personal.Phone);

            // Ejecuta el comando SQL y devuelve el número de filas afectadas por la operación
            var insertados = comando.ExecuteNonQuery();

            // Devuelve el número de registros insertados o actualizados
            return insertados;
        }

        public int ActualizarPersonal(Person person, int id)
        {
            // Establece una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para actualizar un registro en la tabla [Suppliers]
                String ActualizarPersona = "";
                ActualizarPersona = ActualizarPersona + "UPDATE [dbo].[Suppliers] " + "\n";
                ActualizarPersona = ActualizarPersona + "   SET [CompanyName] = @CompanyName" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[ContactName] = @ContactName" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[ContactTitle] = @ContactTitle" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[City] = @City" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[PostalCode] = @PostalCode" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[Country] = @Country" + "\n";
                ActualizarPersona = ActualizarPersona + "      ,[Phone] = @Phone" + "\n";
                // Filtra el registro a actualizar por el SupplierID
                ActualizarPersona = ActualizarPersona + $" WHERE SupplierID='{id}'";

                // Crea un comando SQL utilizando la consulta de actualización y la conexión establecida
                using (var comando = new SqlCommand(ActualizarPersona, conexion))
                {
                    // Configura los parámetros del comando con los datos del objeto Person
                    int actualizados = parametrosPersonal(person, comando);

                    // Devuelve el número de registros actualizados en la base de datos
                    return actualizados;
                }
            }
        }


        public Person ObtenerPorId(int id)
        {
            // Establece una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para seleccionar todos los campos de un registro específico en la tabla [Suppliers]
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [SupplierID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "      ,[HomePage] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]" + "\n";
                // Añade una cláusula WHERE para seleccionar el registro con el SupplierID especificado
                selectFrom = selectFrom + $" Where SupplierID='{id}'";

                // Crea un comando SQL utilizando la consulta construida y la conexión establecida
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Añade un parámetro al comando para evitar inyección SQL y manejar el valor de SupplierID
                    comando.Parameters.AddWithValue("SupplierID", id);

                    // Ejecuta el comando y obtiene un SqlDataReader para leer el resultado
                    var reader = comando.ExecuteReader();

                    // Declara una variable para almacenar el objeto Person que se recuperará
                    Person personas = null;

                    // Si hay resultados, lee el primer registro y lo convierte en un objeto Person
                    if (reader.Read())
                    {
                        personas = LeerDelDataReader(reader);
                    }

                    // Devuelve el objeto Person recuperado (o null si no se encontró ningún registro)
                    return personas;
                }
            }
        }

        public int EleminarPersonal(int id)
        {
            // Establece una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para eliminar un registro específico de la tabla [Suppliers]
                String deletePerson = "";
                deletePerson = deletePerson + "DELETE FROM [dbo].[Suppliers] " + "\n";
                // Añade una cláusula WHERE para eliminar el registro con el SupplierID especificado
                deletePerson = deletePerson + $"      WHERE SupplierID='{id}'";

                // Crea un comando SQL utilizando la consulta de eliminación y la conexión establecida
                using (SqlCommand comando = new SqlCommand(deletePerson, conexion))
                {
                    // Añade un parámetro al comando para evitar inyección SQL y manejar el valor de SupplierID
                    comando.Parameters.AddWithValue("@SupplierID", id);

                    // Ejecuta el comando y obtiene el número de filas afectadas (eliminadas)
                    int elimindos = comando.ExecuteNonQuery();

                    // Devuelve el número de registros eliminados
                    return elimindos;
                }
            }
        }

    }
}
