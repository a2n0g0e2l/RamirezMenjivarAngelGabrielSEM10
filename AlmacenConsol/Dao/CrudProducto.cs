using AlmacenConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenConsol.Dao
{
    internal class CrudProducto
    {
        public void AgregarProducto(Producto ParametroProducto)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                Producto producto = new Producto();

                producto.Nombre = ParametroProducto.Nombre;

                producto.Descripcion = ParametroProducto.Descripcion;

                producto.Precio = ParametroProducto.Precio;

                producto.Stock = ParametroProducto.Stock;
                db.Add(producto);
                db.SaveChanges();

            }
        }
        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);
                return buscar;
            }
        }
        public void ActualizarProducto(Producto ParametrosProducto, int Lector)
        {
            using (AlmacenContext db =
                new AlmacenContext())
            {

                var buscar = db.Productos.FirstOrDefault(x => x.Id == ParametrosProducto.Id);
                if (buscar == null)
                {

                    Console.WriteLine("El id no existe");

                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParametrosProducto.Nombre;
                    }
                    if (Lector == 2)
                    {
                        buscar.Descripcion = ParametrosProducto.Descripcion;
                    }
                    if (Lector == 3)
                    {
                        buscar.Precio = ParametrosProducto.Precio;
                    }
                    else
                    {
                        buscar.Stock = ParametrosProducto.Stock;
                    }


                    db.Update(buscar);
                    db.SaveChanges();

                }

            }
        }
        public string EliminarProducto(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El producto no existe ";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El producto se elimino";
                }
            }
        }
        public List<Producto> ListarProductos()
        {
            using (AlmacenContext db = new AlmacenContext())
            { return db.Productos.ToList(); }
        }
    }
}
