using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CarritoDTO
    {
        //es la implementacion de la estructura de como se guardara todo en el carrito
        public ProductoDTO? Producto { get; set; }
        public int? Cantidad { get; set; }
        public int? Precio { get; set; }
        public int? Total { get; set; }
    }
}
