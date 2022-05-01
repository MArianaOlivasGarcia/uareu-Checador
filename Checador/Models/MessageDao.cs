using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class MessageDao: ConnectionDb
    {

        // Buscar mensaje por empleado ID
        public Message FindByEmployeId(Int32 Id)
        {
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            //  TODO: CAMBIAR FECHAS
            command.CommandText = "SELECT * FROM mensajes WHERE fecha_inicio <= @today AND fecha_final >= @today AND id_trabajador = @employeeId;";
            command.Parameters.Add("@today", MySqlDbType.Date).Value = DateTime.Now;
            command.Parameters.Add("@employeeId", MySqlDbType.Int32).Value = Id;

            try
            {

                MySqlDataReader messagedb = command.ExecuteReader();
                Message message = null;

                while (messagedb.Read())
                {
                    message = new Message()
                    {
                        Id = messagedb.GetInt32("id_mensaje"),
                        IdEmployee = messagedb.IsDBNull(1) ? 0 : messagedb.GetInt32("id_trabajador"),
                        FechaInicio = messagedb.GetDateTime("fecha_inicio"),
                        FechaFinal = messagedb.GetDateTime("fecha_final"),
                        IsGeneral = !messagedb.IsDBNull(4) && (messagedb.GetInt32("general") != 0),
                        Asunto = messagedb.GetString("asunto"),
                        Mensaje = messagedb.GetString("mensaje")
                    };

                };

                return message;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }


        }



        // Buscard Mensajes generales
        public Message FindGeneral()
        {
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            //  TODO: CAMBIAR FECHAS
            command.CommandText = "SELECT * FROM mensajes WHERE fecha_inicio <= @today AND fecha_final >= @today AND general = 1;";
            command.Parameters.Add("@today", MySqlDbType.Date).Value = DateTime.Now;

            try
            {

                MySqlDataReader messagedb = command.ExecuteReader();
                Message message = null;

                while (messagedb.Read())
                {
                    message = new Message()
                    {
                        Id = messagedb.GetInt32("id_mensaje"),
                        IdEmployee = messagedb.IsDBNull(1) ? 0 : messagedb.GetInt32("id_trabajador"),
                        FechaInicio = messagedb.GetDateTime("fecha_inicio"),
                        FechaFinal = messagedb.GetDateTime("fecha_final"),
                        IsGeneral = !messagedb.IsDBNull(4) && (messagedb.GetInt32("general") != 0),
                        Asunto = messagedb.GetString("asunto"),
                        Mensaje = messagedb.GetString("mensaje")
                    };

                };

                return message;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }


        }
    }
}
