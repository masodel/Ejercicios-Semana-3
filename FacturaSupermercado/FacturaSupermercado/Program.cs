namespace FacturaSupermercado
{
    class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Subproblema 1: Entrada de productos
            List<Producto> productos = EntradaProductos();

            // Subproblema 2: Cálculo subtotal
            double subtotal = CalcularSubtotal(productos);

            // Subproblema 3: Aplicación de impuestos
            double impuestos = AplicarImpuestos(subtotal);

            // Subproblema 4: Impresión del total
            ImprimirFactura(productos, subtotal, impuestos);
        }

        // Subproblema 1: Entrada de productos
        static List<Producto> EntradaProductos()
        {
            Console.WriteLine("=== FACTURA SUPERMERCADO ===");
            List<Producto> productos = new List<Producto>();
            string continuar;

            do
            {
                string nombre;
                while (true)
                {
                    Console.Write("Nombre del producto: ");
                    nombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        break;
                    }
                    Console.WriteLine("Por favor ingrese un nombre válido.");
                }

                double precio;
                while (true)
                {
                    Console.Write("Precio unitario: ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out precio) && precio > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Por favor ingrese un precio válido mayor que 0.");
                }

                int cantidad;
                while (true)
                {
                    Console.Write("Cantidad: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out cantidad) && cantidad > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Por favor ingrese una cantidad válida mayor que 0.");
                }

                productos.Add(new Producto { Nombre = nombre, Precio = precio, Cantidad = cantidad });

                while (true)
                {
                    Console.Write("¿Agregar otro producto? (s/n): ");
                    continuar = Console.ReadLine()?.ToLower();
                    if (continuar == "s" || continuar == "n")
                    {
                        break;
                    }
                    Console.WriteLine("Por favor ingrese 's' para sí o 'n' para no.");
                }

            } while (continuar == "s");

            return productos;
        }

        // Subproblema 2: Cálculo subtotal
        static double CalcularSubtotal(List<Producto> productos)
        {
            double subtotal = 0;
            foreach (Producto producto in productos)
            {
                subtotal += producto.Precio * producto.Cantidad;
            }
            return subtotal;
        }

        // Subproblema 3: Aplicación de impuestos
        static double AplicarImpuestos(double subtotal)
        {
            double porcentajeImpuesto = 0.15; // 15% de impuesto
            return subtotal * porcentajeImpuesto;
        }

        // Subproblema 4: Impresión del total
        static void ImprimirFactura(List<Producto> productos, double subtotal, double impuestos)
        {
            Console.WriteLine("\n=== FACTURA ===");
            Console.WriteLine("Productos:");

            foreach (Producto producto in productos)
            {
                double totalProducto = producto.Precio * producto.Cantidad;
                Console.WriteLine($"{producto.Nombre} - Cantidad: {producto.Cantidad} - Precio: ${producto.Precio:F2} - Total: ${totalProducto:F2}");
            }

            Console.WriteLine($"\nSubtotal: ${subtotal:F2}");
            Console.WriteLine($"Impuestos (15%): ${impuestos:F2}");
            Console.WriteLine($"TOTAL A PAGAR: ${subtotal + impuestos:F2}");
        }
    }
}
