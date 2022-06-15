using nextapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace nextapp.Context
{
    public class MantenimientoSolicitud
    {

        readonly string connectionString = "Data Source = DESKTOP-N8JD8L7\\MSVR01; Initial Catalog = nextapp; Integrated Security = True;";

        //This method help get the  List
        public IEnumerable<Solicitud> GetAllSolicitud()
        {
            var solicitudList = new List<Solicitud>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllSolicitudes", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var solicitud = new Solicitud();

                    solicitud.id_Solicitud = Convert.ToInt32(dr["id_Solicitud"].ToString());
                    solicitud.nombre = dr["nombre"].ToString();
                    solicitud.apellido = dr["apellido"].ToString();
                    solicitud.codigo_empleado = dr["codigo_empleado"].ToString();
                    solicitud.cargo = dr["cargo"].ToString();
                    solicitud.correo = dr["correo"].ToString();
                    solicitud.telefono = dr["telefono"].ToString();
                    solicitud.tipo_solicitud = dr["tipo_solicitud"].ToString();
                    solicitud.tecnico_asignado = dr["tecnico_asignado"].ToString();
                    solicitud.fecha_solicitud = dr["fecha_solicitud"].ToString();
                    solicitud.mensaje = dr["mensaje"].ToString();

                    solicitudList.Add(solicitud);
                }

                con.Close();
            }

            return solicitudList;
        }

        //
        public void CreateSolicitud(Solicitud solicitud)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateNewSolicitud", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombre", solicitud.nombre);
                cmd.Parameters.AddWithValue("@apellido", solicitud.apellido);
                cmd.Parameters.AddWithValue("@codigo_empleado", solicitud.codigo_empleado);
                cmd.Parameters.AddWithValue("@correo", solicitud.correo);
                cmd.Parameters.AddWithValue("@telefono", solicitud.telefono);
                cmd.Parameters.AddWithValue("@cargo", solicitud.cargo);
                cmd.Parameters.AddWithValue("@fecha_solicitud", solicitud.fecha_solicitud);
                cmd.Parameters.AddWithValue("@tipo_solicitud", solicitud.tipo_solicitud);
                cmd.Parameters.AddWithValue("@mensaje", solicitud.mensaje);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //

        public void UpdateSolicitud(Solicitud solicitud)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateSolicitud", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id_solicitud", solicitud.id_Solicitud);
                cmd.Parameters.AddWithValue("@nombre", solicitud.nombre);
                cmd.Parameters.AddWithValue("@apellido", solicitud.apellido);
                cmd.Parameters.AddWithValue("@codigo_empleado", solicitud.codigo_empleado);
                cmd.Parameters.AddWithValue("@correo", solicitud.correo);
                cmd.Parameters.AddWithValue("@telefono", solicitud.telefono);
                cmd.Parameters.AddWithValue("@cargo", solicitud.cargo);
                cmd.Parameters.AddWithValue("@tipo_solicitud", solicitud.tipo_solicitud);
                cmd.Parameters.AddWithValue("@tecnico_asignado", solicitud.tecnico_asignado);
                cmd.Parameters.AddWithValue("@mensaje", solicitud.mensaje);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //

        public void DeleteEquipo(int? id_solicitud)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteSolicitud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

            }
        }

        //

        public Solicitud GetSolicitudById(int? id_Solicitud)
        {
            var solicitud = new Solicitud();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetSolicitudById", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id_Solicitud", id_Solicitud);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    solicitud.id_Solicitud = Convert.ToInt32(dr["id_Solicitud"].ToString());
                    solicitud.nombre = dr["nombre"].ToString();
                    solicitud.apellido = dr["apellido"].ToString();
                    solicitud.codigo_empleado = dr["codigo_empleado"].ToString();
                    solicitud.cargo = dr["cargo"].ToString();
                    solicitud.correo = dr["correo"].ToString();
                    solicitud.telefono = dr["telefono"].ToString();
                    solicitud.tipo_solicitud = dr["tipo_solicitud"].ToString();
                    solicitud.fecha_solicitud = dr["fecha_solicitud"].ToString();
                    solicitud.mensaje = dr["mensaje"].ToString();

                }
                con.Close();
            }
            return solicitud;
        }


    }

}

