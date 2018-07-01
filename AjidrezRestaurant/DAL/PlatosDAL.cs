using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using AjidrezRestaurant.ET;

namespace AjidrezRestaurant.DAL
{
    public class PlatosDAL
    {
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["AjidrezConn"].ToString();
            con = new SqlConnection(constring);
        }

        public List<Platos> Listar()
        {
            var platos = new List<Platos>();

            try
            {
                connection();

                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM PRODUCTO", con);
                    using (var dr = query.ExecuteReader())

                    {


                        while (dr.Read())
                        {
                            // Producto
                            var plato = new Platos();
                            {

                                plato.IdProducto = Convert.ToInt32(dr["IDPRODUCTO"]);
                                plato.Precio = Convert.ToDouble(dr["PRECIO"]);
                                plato.IdClase = Convert.ToInt32(dr["IDCLASE"]);
                                plato.Estado = dr["ESTADO"].ToString(); ;
                                plato.NombreProducto = dr["NOMBREPRODUCTO"].ToString();
                                plato.Lunes = Convert.ToBoolean(dr["LUNES"]);
                                plato.Martes = Convert.ToBoolean(dr["MARTES"]);
                                plato.Miercoles = Convert.ToBoolean(dr["MIERCOLES"]);
                                plato.Jueves = Convert.ToBoolean(dr["JUEVES"]);
                                plato.Viernes = Convert.ToBoolean(dr["VIERNES"]);
                                plato.Sabado = Convert.ToBoolean(dr["SADADO"]);
                                plato.Domingo = Convert.ToBoolean(dr["DOMINGO"]);
                            };

                            // Agregamos el Producto a la lista genérica

                            platos.Add(plato);
                        }

                    }

                    foreach (var u in platos)
                    {
                        query = new SqlCommand("SELECT * FROM Clase WHERE IDClase = @IdClase", con);
                        query.Parameters.AddWithValue("@IDClase", u.IdClase);


                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                u.Clase.IdClase = Convert.ToInt32(dr["IdClase"]);
                                u.Clase.NombreClase = dr["NombreClase"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

            return platos;
        }


        public Platos Obtener(int id)
        {
            var plato = new Platos();

            try
            {
                connection();

                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM PRODUCTO WHERE IDPRODUCTO = @IDPRODUCTO", con);
                    query.Parameters.AddWithValue("@IDPRODUCTO", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            plato.IdProducto = Convert.ToInt32(dr["IDPRODUCTO"]);
                            plato.Precio = Convert.ToDouble(dr["IDPRECIO"]);
                            plato.IdClase = Convert.ToInt32(dr["IDCLASE"]);
                            plato.Estado = dr["ESTADO"].ToString(); ;
                            plato.NombreProducto = dr["NOMBRE"].ToString();
                            plato.Lunes = Convert.ToBoolean(dr["LUNES"]);
                            plato.Martes = Convert.ToBoolean(dr["MARTES"]);
                            plato.Miercoles = Convert.ToBoolean(dr["MIERCOLES"]);
                            plato.Jueves = Convert.ToBoolean(dr["JUEVES"]);
                            plato.Viernes = Convert.ToBoolean(dr["VIERNES"]);
                            plato.Sabado = Convert.ToBoolean(dr["SADADO"]);
                            plato.Domingo = Convert.ToBoolean(dr["DOMINGO"]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return plato;
        }

        public bool Actualizar(Platos plato)
        {
            bool respuesta = false;

            try
            {
                connection();

                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Producto SET Precio = @p0, IdClase = @p1, Estado = @p2, NombreProducto = @p3, Lunes = @p4, Martes = @p5, Miercoles = @p6, Miercoles = @p7, Jueves = @p8, Viernes = @p9, Sabado = @p10, Domingo = @p11  WHERE IdProducto = @p12", con);


                    query.Parameters.AddWithValue("@p0", plato.Precio);
                    query.Parameters.AddWithValue("@p1", plato.IdClase);
                    query.Parameters.AddWithValue("@p2", plato.Estado);
                    query.Parameters.AddWithValue("@p3", plato.NombreProducto);
                    query.Parameters.AddWithValue("@p4", plato.Lunes);
                    query.Parameters.AddWithValue("@p5", plato.Martes);
                    query.Parameters.AddWithValue("@p6", plato.Miercoles);
                    query.Parameters.AddWithValue("@p7", plato.Jueves);
                    query.Parameters.AddWithValue("@p8", plato.Viernes);
                    query.Parameters.AddWithValue("@p10", plato.Sabado);
                    query.Parameters.AddWithValue("@p11", plato.Domingo);
                    query.Parameters.AddWithValue("@p12", plato.IdProducto);

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

        public bool Registrar(Platos plato)
        {
            connection();
            {
                var query = new SqlCommand("INSERT INTO PRODUCTO(Precio, IdClase, Estado, NombreProducto, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo ) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", con);

                query.Parameters.AddWithValue("@p0", plato.Precio);
                query.Parameters.AddWithValue("@p1", plato.IdClase);
                query.Parameters.AddWithValue("@p2", plato.Estado);
                query.Parameters.AddWithValue("@p3", plato.NombreProducto);
                query.Parameters.AddWithValue("@p4", plato.Lunes);
                query.Parameters.AddWithValue("@p5", plato.Martes);
                query.Parameters.AddWithValue("@p6", plato.Miercoles);
                query.Parameters.AddWithValue("@p7", plato.Jueves);
                query.Parameters.AddWithValue("@p8", plato.Viernes);
                query.Parameters.AddWithValue("@p10", plato.Sabado);
                query.Parameters.AddWithValue("@p11", plato.Domingo);

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

                    var query = new SqlCommand("DELETE FROM PRODUCTO WHERE IDPRODUCTO = @p0", con);
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