using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using AjidrezRestaurant.ET;

namespace AjidrezRestaurant.DAL
{

    public class ClaseDAL
    {
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["AjidrezConn"].ToString();
            con = new SqlConnection(constring);
        }

        public List<Clase> Listar()
        {
            var clase = new List<Clase>();

            try
            {
                connection();
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM CLASE", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clase.Add(
                                new Clase
                                {
                                    IdClase= Convert.ToInt32(dr["IDCLASE"]),
                                    NombreClase = dr["NombreClase"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return clase;
        }

        public Clase Obtener(int id)
        {
            var clase = new Clase();

            try
            {
                connection();

                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Clase WHERE IdClase = @IdClase", con);
                    query.Parameters.AddWithValue("@IdClase", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            clase.IdClase = Convert.ToInt32(dr["IdCategoria"]);
                            clase.NombreClase = dr["NombreClase"].ToString();
   
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return clase;
        }

        public bool Actualizar(Clase clase)
        {
            bool respuesta = false;

            try
            {
                connection();

                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Clase SET Nombre = @nombre, Estado = @estado WHERE IdCategoria = @idcategoria", con);

                    query.Parameters.AddWithValue("@NombreClase", clase.NombreClase);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return respuesta;
        }

        public bool Registrar(Clase clase)
        {

            connection();

            {
                var query = new SqlCommand("INSERT INTO Clase(NombreClase) VALUES (@p0)", con);


                query.Parameters.AddWithValue("@p0", clase.NombreClase);

                con.Open();
                int i = query.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            try
            {
                connection();

                {
                    con.Open();

                    var query = new SqlCommand("DELETE FROM Clase WHERE IDCATEGORIA = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return respuesta;
        }

    }
}