
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DPFP;

namespace Checador.Models
{
    public class EmployeeDao: ConnectionDb
    {
        
        // Buscar un empleado por ID
        public Employee FindById(int Id)
        {
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM trabajadores WHERE id_trabajador =  @id";
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;

            try
            {

                MySqlDataReader employeedb = command.ExecuteReader();
                Employee employee = null;

                while (employeedb.Read())
                {
                    employee = new Employee();


                    employee.Id = employeedb.GetInt32("id_trabajador");
                    employee.Titulo = employeedb.GetString("titulo");
                    employee.Nombre = employeedb.GetString("nombre");
                    employee.Paterno = employeedb.GetString("ap_paterno");
                    employee.Materno = employeedb.GetString("ap_materno");
                    employee.Sexo = employeedb.GetString("sexo");
                    employee.RFC = employeedb.GetString("RFC");
                    employee.CURP = employeedb.GetString("CURP");
                    employee.Contrato = employeedb.GetString("contrato");
                    employee.Tipo = employeedb.GetString("tipo_trabajador");
                    employee.TotalHoras = employeedb.GetInt32("total_horas");
                    employee.Status = employeedb.GetString("status");
                    employee.Email = employeedb.GetString("email");
                    employee.CodigoTarjeta = employeedb.GetString("codigo_tarjeta");

                    try
                    {
                        byte[] b = (byte[])employeedb.GetValue(employeedb.GetOrdinal("foto"));
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(b);

                        if (ms != null)
                        {
                            employee.Foto = System.Drawing.Image.FromStream(ms);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NO TIENE FOTO");
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);

                    }

                };

                return employee;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }


        }


        // Generar la checada del empleado
        public Checking Check(int Id, DateTime Date)
        {

            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "INSERT INTO checadas(id_trabajador, fecha, hora) VALUES( @id, now(), now() ); SELECT * FROM checadas ORDER BY id_checada DESC LIMIT 1;";
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;
            //command.Parameters.Add("@date", MySqlDbType.Date).Value = Date.Date;
            //command.Parameters.Add("@time", MySqlDbType.Time).Value = Date.TimeOfDay;

            try
            {
     
                MySqlDataReader response = command.ExecuteReader();
                Checking lastCheck = null;

                while (response.Read())
                {
                    lastCheck = new Checking();

                    lastCheck.Id = response.GetInt32("id_checada");
                    lastCheck.Employee = response.GetInt32("id_trabajador");
                    lastCheck.Date = (DateTime)response.GetMySqlDateTime("fecha");
                    lastCheck.Time =  response.GetTimeSpan("hora");
                }
                    

                return lastCheck;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }

        }


        // Obtener todos los empleados
        public List<Employee> FindAll()
        {
            System.IO.MemoryStream ms;
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM trabajadores";

            MySqlDataReader trabajadores = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();
            while (trabajadores.Read())
            {
                Employee employee = new Employee();
                employee.Id = trabajadores.GetInt32("id_trabajador");
                employee.Titulo = !(String.IsNullOrEmpty(trabajadores.GetValue(1).ToString())) ? trabajadores.GetString("titulo").ToUpper() : "C";
                employee.Nombre = trabajadores.GetString("nombre").ToUpper();
                employee.Paterno = trabajadores.GetString("ap_paterno").ToUpper();
                employee.Materno = trabajadores.GetString("ap_materno").ToUpper();
                employee.Sexo = trabajadores.GetString("sexo");
                employee.RFC = trabajadores.GetString("RFC").ToUpper();
                employee.CURP = trabajadores.GetString("CURP").ToUpper();
                employee.Contrato = trabajadores.GetString("contrato").ToUpper();
                employee.Tipo = trabajadores.GetString("tipo_trabajador");
                employee.TotalHoras = trabajadores.GetInt32("total_horas");
                employee.Status = trabajadores.GetString("status").ToUpper();
                employee.CodigoTarjeta = trabajadores.GetString("codigo_tarjeta").ToUpper();
                try
                {
                    byte[] b = null;
                    b = (byte[])trabajadores.GetValue(trabajadores.GetOrdinal("huella"));
                    ms = new System.IO.MemoryStream(b);
                    employee.Huella = new DPFP.Template(ms);
                }
                catch (Exception)
                {

                }

                try
                {
                    byte[] b = null;
                    b = (byte[])trabajadores.GetValue(trabajadores.GetOrdinal("huella2"));
                    ms = new System.IO.MemoryStream(b);
                    employee.Huella2 = new DPFP.Template(ms);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    byte[] b = null;
                    b = (byte[])trabajadores.GetValue(trabajadores.GetOrdinal("foto"));
                    ms = new System.IO.MemoryStream(b);

                    if (ms == null)
                    {

                    }
                    else
                    {
                        employee.Foto = System.Drawing.Image.FromStream(ms);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                employees.Add(employee);
            }
            return employees;
        }

        // Verificar si tiene Horario

        public Boolean HasWorkingHours(int Id)
        {
            int id = 0;
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT id_horario FROM horarios WHERE fecha_inicio<=@fecha and fecha_final>=@fecha and id_trabajador = @id";

            command.Parameters.Add("@fecha", MySqlDbType.Date).Value = DateTime.Now;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;

            try
            {
                MySqlDataReader h = command.ExecuteReader();
                while (h.Read())
                {
                    id = h.GetInt32("id_horario");
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            };

            if (id == 0) { return false; }

            return true;
        }




        // Empleado activo

        public Boolean IsActive(int Id)
        {
            Boolean isActive = false;
            MySqlConnection connection = Connection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT status FROM trabajadores WHERE id_trabajador=@id";

            command.Parameters.Add("@fecha", MySqlDbType.Date).Value = DateTime.Now;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;

            try
            {
                MySqlDataReader status = command.ExecuteReader();
                while (status.Read())
                {
                    if (status.GetString("status").ToLower() == "activo")
                    {
                        isActive = true;
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            };


            return isActive;
        }


    }
}
