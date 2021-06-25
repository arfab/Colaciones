using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Colaciones
{
    public class Datos
    {

        static readonly string strConnectionString = Tools.GetConnectionString();

        public static List<Models.Categoria> ObtenerCategorias()
        {
            List<Models.Categoria> lCateg = new List<Models.Categoria>();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lCateg = con.Query<Models.Categoria>("CategoriaObtenerTodos").ToList();
            }

            return lCateg;
        }

        public static List<Models.Producto> ObtenerProductos(
              string filtro, 
              int? categoria_id,
              int? colacion,
              int? desayuno,
              int? merienda,
              int? postre,
              int? copetin,
              int? grasas_trans,
              int? ocasional,
              int? reemplazo
              )
        {
            List<Models.Producto> lRespuesta = new List<Models.Producto>();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@filtro", filtro);
                parameter.Add("@categoria_id", categoria_id);
                parameter.Add("@colacion", colacion);
                parameter.Add("@desayuno", desayuno);
                parameter.Add("@merienda", merienda);
                parameter.Add("@postre", postre);
                parameter.Add("@copetin", copetin);
                parameter.Add("@grasas_trans", grasas_trans);
                parameter.Add("@ocasional", ocasional);
                parameter.Add("@reemplazo", reemplazo);

                lRespuesta = con.Query<Models.Producto>("ProductoObtenerTodos", parameter, commandType: CommandType.StoredProcedure).ToList();
            }

            return lRespuesta;
        }
    }
}
