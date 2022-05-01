using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class UserDao: ConnectionDb
    {

        public Dictionary<String, dynamic> Login(String User, String Password)
        {
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT id_usuario FROM usuarios INNER JOIN roles ON usuarios.rol = roles.id_rol WHERE usuarios.nombre=@nombre AND password=CONCAT('*', UPPER(SHA1(UNHEX(SHA1(@password))))) AND checador = 1";
            command.Parameters.Add("@nombre", MySqlDbType.String).Value = User;
            command.Parameters.Add("@password", MySqlDbType.String).Value = Password;

            Dictionary<string, dynamic> resp = new Dictionary<string, dynamic>();

            try
            {

                MySqlDataReader userdb = command.ExecuteReader();
                User user = null;

                while (userdb.Read())
                {

                    user = new User
                    {
                        Id = userdb.GetInt32("id_usuario")
                    };


                };

                if (user == null)
                {
                    resp["status"] = false;
                    resp["message"] = "Usuario y/o contraseña inválido(s).";

                    return resp;
                }

                resp["status"] = true;

                return resp;
                ;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                resp["status"] = false;
                resp["message"] = "Oops! Ocurrio un error. Hable con el administrador.";

                return resp;
            }


        }

    }
}
