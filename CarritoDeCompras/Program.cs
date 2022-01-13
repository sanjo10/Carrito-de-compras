using System;
using System.Linq;

namespace CarritoDeCompras
{
    class MainClass
    {
        public static void Main(string[] args)
        {           
            StockProductos stock = new StockProductos();
            stock.CrearProductos();
            stock.ImprimirStockProductos();

           
            ClienteSinRegistro cliente = new ClienteSinRegistro();
            cliente.Apellidos = "Zambrano Zambrano";
            cliente.Nombres = "Michael Jackson";
            cliente.Email = "michael@web.com";
            cliente.Cedula = "1112223334";
            cliente.Contrasena = "mzambrano";

            Empresa empresa = new Empresa();
            empresa.RazonSocial = "Amazon";
            empresa.Direccion = "California";

            CabeceraFactura cabeceraCarrito = new CabeceraFactura();
            cabeceraCarrito.ClienteCabecera = cliente;
            cabeceraCarrito.EmpresaCabecera = empresa;

            Factura factura = new Factura();

            factura.Cabecera = cabeceraCarrito;
            string opcion;
            int codigo;
            do
            {
                Console.WriteLine("Ingrese el codigo del producto");
                codigo = int.Parse (Console.ReadLine());
                DetalleFactura detalleCarrito = new DetalleFactura();
                detalleCarrito.ProductoCarrito = stock.ListaStockProductos[codigo-1];
                Console.WriteLine("Ingrese la cantidad del producto elegido:");
                detalleCarrito.Cantidad = int.Parse( Console.ReadLine());
                factura.Detalle.Add(detalleCarrito);
                Console.WriteLine("Escriba A para seguir agregando productos, L para ver el " +
                    "Detalle del carrito o S para salir");
                opcion = Console.ReadLine();
                if(opcion == "L")
                {
                    //IMPRIMIR POR PANTALLA EL NOMBRE DEL PRODUCTO, SU PRECIO Y LA CANTIDAD
                    Console.WriteLine("Productos facturados");
                    Console.WriteLine("Descripcion\tPrecio\tCantidad");

                    var consultaDetalle = factura.Detalle.OrderByDescending(x => x.Cantidad)
                        .Select(x => new
                        {
                            descripcion = x.ProductoCarrito.Descripcion,
                            precio = x.ProductoCarrito.Precio,
                            cantidad = x.Cantidad
                        });

                    foreach (var item in consultaDetalle)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}",
                            item.descripcion, item.precio, item.cantidad);
                    }
                }
            } while (opcion != "S");

            while(opcion == "L")
            {

            }

            Console.WriteLine();                     

            factura.CalcularSubtotal();
            factura.CalcularDescuento();
            factura.CalcularTotal();

            Console.WriteLine(factura.SubTotal);
            Console.WriteLine(factura.Descuento);
            Console.WriteLine(factura.Total);
        }
    }
}
