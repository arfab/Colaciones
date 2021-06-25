namespace Colaciones.Models
{
    public class Producto
    {

        public int id { get; set; }

        public string descripcion { get; set; }

        public string porcion { get; set; }

        public string calorias { get; set; }

        public string grasas_totales { get; set; }

        public string sodio { get; set; }

        public string azucar { get; set; }

        public int colacion { get; set; }
        public int desayuno { get; set; }
        public int merienda { get; set; }
        public int postre { get; set; }
        public int copetin { get; set; }
        public int grasas_trans { get; set; }
        public int ocasional { get; set; }
        public int reemplazo { get; set; }

        public string observaciones { get; set; }


        public string Categoria { get; set; }
        public int CategoriaId { get; set; }

    }
}
