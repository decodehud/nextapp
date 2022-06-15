using nextapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace nextapp.Context
{
    public class MantenimientoEmpleado
    {

        readonly string connectionString = "Data Source = DESKTOP-N8JD8L7\\MSVR01; Initial Catalog = nextapp; Integrated Security = True;";

        //This method help get the Empleado List
        public IEnumerable<Empleado> GetAllEmpleado()
        {
            var empleadoList = new List<Empleado>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmpleado", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var empleado = new Empleado();

                    empleado.id_empleados = Convert.ToInt32(dr["id_empleados"].ToString());
                    empleado.nombre = dr["nombre"].ToString();
                    empleado.apellido = dr["apellido"].ToString();
                    empleado.codigo_empleado = dr["codigo_empleado"].ToString();
                    empleado.cargo = dr["cargo"].ToString();
                    empleado.correo = dr["correo"].ToString();
                    empleado.departamento = dr["departamento"].ToString();
                    empleado.equipo_asignado = dr["equipo_asignado"].ToString();
                    empleado.fecha_asignacion = dr["fecha_asignacion"].ToString();
                    

                    empleadoList.Add(empleado);
                }

                con.Close();
            }

            return empleadoList;
        }

        //Create new empleado

        public void CreateEmpleado(Empleado empleado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateNewEmpleado", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@apellido", empleado.apellido);
                cmd.Parameters.AddWithValue("@codigo_empleado", empleado.codigo_empleado);
                cmd.Parameters.AddWithValue("@cargo", empleado.cargo);
                cmd.Parameters.AddWithValue("@correo", empleado.correo);
                cmd.Parameters.AddWithValue("@departamento", empleado.departamento);
                cmd.Parameters.AddWithValue("@equipo_asignado", empleado.@equipo_asignado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Update emepleado
        public void UpdateEmpleado(Empleado empleado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmpleado", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id_empleados", empleado.id_empleados);
                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@apellido", empleado.apellido);
                cmd.Parameters.AddWithValue("@codigo_empleado", empleado.codigo_empleado);
                cmd.Parameters.AddWithValue("@cargo", empleado.cargo);
                cmd.Parameters.AddWithValue("@correo", empleado.correo);
                cmd.Parameters.AddWithValue("@departamento", empleado.departamento);
                cmd.Parameters.AddWithValue("@equipo_asignado", empleado.equipo_asignado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Delete empleado

        public void DeleteEmpleado(int? id_empleados)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_empleados", id_empleados);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

            }
        }

        //
        public Empleado GetEmpleadoById(int? id_empleados)
        {
            var empleado = new Empleado();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmpleadoById", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id_empleados", id_empleados);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    empleado.id_empleados = Convert.ToInt32(dr["id_empleados"].ToString());
                    empleado.nombre = dr["nombre"].ToString();
                    empleado.apellido = dr["apellido"].ToString();
                    empleado.codigo_empleado = dr["codigo_empleado"].ToString();
                    empleado.cargo = dr["cargo"].ToString();
                    empleado.correo = dr["correo"].ToString();
                    empleado.departamento = dr["departamento"].ToString();
                    empleado.equipo_asignado = dr["equipo_asignado"].ToString();
                    empleado.fecha_asignacion = dr["fecha_asignacion"].ToString();

                }
                con.Close();
            }
            return empleado;
        }


    }
}
