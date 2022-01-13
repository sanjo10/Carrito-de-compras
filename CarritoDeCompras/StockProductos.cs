using System;
using System.Collections.Generic;
using System.Linq;

namespace CarritoDeCompras
{
    public class StockProductos
    {
        public StockProductos()
        {
            this.ListaStockProductos = new List<Producto>();
        }

       public List<Producto> ListaStockProductos { get; set; }

        public void CrearProductos()
        {
            Random random = new Random();
            int numero;
            for (int i = 1; i <= 10; i++)
            {
               
                Producto producto = new Producto();
                producto.Identificador = i;
                numero = random.Next(20);
                char letra = (char)(((int)'A') + random.Next(26));
                producto.Descripcion = "PRODUCTO" +letra + numero + i;                
                producto.Precio = numero;

                Random existencia = new Random();
                producto.Existencia = existencia.Next(100);
                this.ListaStockProductos.Add(producto);
            }
        }

        //Modificar este método
       public void ImprimirStockProductos()
       {
            var consultaStockProductos = ListaStockProductos.Select(x => new
            {
                identificador = x.Identificador,
                descripcion = x.Descripcion,
                precio = x.Precio,
                existencia = x.Existencia
            });
           Console.WriteLine("Stock de Productos");
           Console.WriteLine("Identificador\tDescripción\tPrecio\tExistencia");
           foreach (var item in consultaStockProductos)
           {
                   Console.WriteLine("{0}\t\t{1}\t{2}\t{3}",
                   item.identificador, item.descripcion, item.precio, item.existencia);
           }
       }

    }
}
