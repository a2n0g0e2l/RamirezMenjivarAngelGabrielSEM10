// See https://aka.ms/new-console-template for more information


using AlmacenConsol.Models;
using AlmacenConsol.Dao;
using System.Runtime.CompilerServices;

CrudProducto CrudProducto = new CrudProducto();
Producto Producto = new Producto();

bool continuar = true;
while (continuar)
{

    Console.WriteLine("Menu");
    Console.WriteLine("Presione 1 para insertar un nuevo producto");
    Console.WriteLine("Presione 2 para Actuliazar un producto");
    Console.WriteLine("Presione 3 para eliminar un producto");
    Console.WriteLine("Presione 4 para listar los productos");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {

        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Por favor ingrese el nombre del producto");
                Producto.Nombre = Console.ReadLine();

                Console.WriteLine("Por favor ingrese una corta descripcion del producto");
                Producto.Descripcion = Console.ReadLine();

                Console.WriteLine("Por favor ingrese el precio del producto 00.00");
                Producto.Precio = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Por favor ingrese la cantidad en stock");
                Producto.Stock = Convert.ToInt32(Console.ReadLine());

                CrudProducto.AgregarProducto(Producto);
                Console.WriteLine("El producto se agrego con exito ");
                Console.WriteLine("Presione 1 para agregar otro producto");
                Console.WriteLine("Presione 0 para abandonar");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;

        case 2:
            Console.WriteLine("Actualizar datos");
            Console.WriteLine("Introdusca el ID del producto a actualizar");
            var productoIndividual = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (productoIndividual == null)
            {
                Console.WriteLine("El producto no extiste");
            }
            else
            {

                Console.WriteLine($"Nombre {productoIndividual.Nombre},descripcion {productoIndividual.Descripcion}, Precio {productoIndividual.Precio}, Stock{productoIndividual.Stock}");
                Console.WriteLine("Para actualizar nombre presiona 1");
                Console.WriteLine("Para actualizar la descripcion presiona 2");
                Console.WriteLine("Para actualizar el precio presiona 3");
                Console.WriteLine("Para actualizar la catidad en stock presiona 4");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("Ingrese el nombre");
                    productoIndividual.Nombre = Console.ReadLine();
                }
                if (Lector == 2)
                {
                    Console.WriteLine("Ingrese la descripcion");
                    productoIndividual.Descripcion = Console.ReadLine();
                }
                if (Lector == 3)
                {
                    Console.WriteLine("Ingrese el precio");
                    productoIndividual.Precio = Convert.ToDecimal(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Ingrese la cantidad en stock");
                    productoIndividual.Stock = Convert.ToInt32(Console.ReadLine());
                }
                CrudProducto.ActualizarProducto(productoIndividual, Lector);
            }
            break;
        case 3:
            Console.WriteLine("Ingrese el id a eliminar");
            var ProductoIndividualD = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualD == null)
            {
                Console.WriteLine("Este producto no existe");
            }
            else
            {
                Console.WriteLine("Eliminar producto");

                Console.WriteLine($"Nombre {ProductoIndividualD.Nombre},descripcion {ProductoIndividualD.Descripcion}, Precio {ProductoIndividualD.Precio}, Stock{ProductoIndividualD.Stock}");
                Console.WriteLine("El producto es correcto, si desea eliminarlo presio 1 para eliminar");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var id = Convert.ToInt32(ProductoIndividualD.Id);
                    Console.WriteLine(CrudProducto.EliminarProducto(id));
                }

            }

            break;
        case 4:
            Console.WriteLine("Lista de productos");
            var ListarProductos = CrudProducto.ListarProductos();
            foreach (var iteracionProductos in ListarProductos)
            {
                Console.WriteLine($"{iteracionProductos.Id},{iteracionProductos.Nombre},{iteracionProductos.Descripcion},{iteracionProductos.Precio},{iteracionProductos.Stock}");
            }
            break;



    }

    Console.WriteLine("Desea continuar? Presione S (si), N (no)");
    var cont = Console.ReadLine();
    if (cont.Equals("N"))
    {
        continuar = false;
    }
}


