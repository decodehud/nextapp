using nextapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace nextapp.Context
{
    public class MantenimientoEquipo
    {

        readonly string connectionString = "Data Source = DESKTOP-N8JD8L7\\MSVR01; Initial Catalog = nextapp; Integrated Security = True;";

        public IEnumerable<Equipo> GetAllEquipo()
        {
            var equipoList = new List<Equipo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEquipo", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var equipo = new Equipo();

                    equipo.id_equipos = Convert.ToInt32(dr["id_equipos"].ToString());
                    equipo.marca = dr["marca"].ToString();
                    equipo.modelo = dr["modelo"].ToString();
                    equipo.serie = dr["serie"].ToString();
                    equipo.caracteristicas = dr["caracteristicas"].ToString();
                    equipo.tipo_equipo = dr["tipo_equipo"].ToString();
                    equipo.stock = dr["stock"].ToString();
                    equipo.fecha_registro = dr["fecha_registro"].ToString();

                    equipoList.Add(equipo);
                }

                con.Close();
            }

            return equipoList;
        }

        //Create new desktop
        public void CreateEquipo(Equipo equipo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateNewEquipo", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@marca", equipo.marca);
                cmd.Parameters.AddWithValue("@modelo", equipo.modelo);
                cmd.Parameters.AddWithValue("@serie", equipo.serie);
                cmd.Parameters.AddWithValue("@caracteristicas", equipo.caracteristicas);
                cmd.Parameters.AddWithValue("@tipo_equipo", equipo.tipo_equipo);
                cmd.Parameters.AddWithValue("@stock", equipo.stock);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Update equipo
        public void UpdateEquipo(Equipo equipo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEquipo", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id_equipos", equipo.id_equipos);
                cmd.Parameters.AddWithValue("@marca", equipo.marca);
                cmd.Parameters.AddWithValue("@modelo", equipo.modelo);
                cmd.Parameters.AddWithValue("@serie", equipo.serie);
                cmd.Parameters.AddWithValue("@caracteristicas", equipo.caracteristicas);
                cmd.Parameters.AddWithValue("@tipo_equipo", equipo.tipo_equipo);
                cmd.Parameters.AddWithValue("@stock", equipo.stock);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteEquipo(int? id_equipos)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEquipo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_equipos", id_equipos);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

            }
        }

        //
        public Equipo GetEquipoById(int? id_equipos)
        {
            var equipo = new Equipo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEquipoById", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id_equipos", id_equipos);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    equipo.id_equipos = Convert.ToInt32(dr["id_equipos"].ToString());
                    equipo.marca = dr["marca"].ToString();
                    equipo.modelo = dr["modelo"].ToString();
                    equipo.serie = dr["serie"].ToString();
                    equipo.caracteristicas = dr["caracteristicas"].ToString();
                    equipo.tipo_equipo = dr["tipo_equipo"].ToString();
                    equipo.stock = dr["stock"].ToString();


                }
                con.Close();
            }
            return equipo;
        }

    }
}
