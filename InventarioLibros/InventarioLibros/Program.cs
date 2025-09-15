namespace InventarioLibros
{
    using System;
    using System.Collections.Generic;

    class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
    }

    class Program
    {
        static List<Libro> inventario = new List<Libro>();
        static int contadorId = 1;

        static void Main()
        {
            int opcion;

            do
            {
                Console.WriteLine("\n--- INVENTARIO DE LIBROS ---");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Buscar libro");
                Console.WriteLine("3. Actualizar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Mostrar todos");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: RegistrarLibro(); break;
                    case 2: BuscarLibro(); break;
                    case 3: ActualizarLibro(); break;
                    case 4: EliminarLibro(); break;
                    case 5: MostrarLibros(); break;
                }

            } while (opcion != 0);
        }

        // 1. Registrar
        static void RegistrarLibro()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Libro nuevo = new Libro { Id = contadorId++, Titulo = titulo, Autor = autor };
            inventario.Add(nuevo);

            Console.WriteLine("✅ Libro registrado con éxito.");
        }

        // 2. Buscar
        static void BuscarLibro()
        {
            Console.Write("Escribe el título a buscar: ");
            string titulo = Console.ReadLine();

            foreach (var libro in inventario)
            {
                if (libro.Titulo.ToLower().Contains(titulo.ToLower()))
                {
                    Console.WriteLine($"📖 Id: {libro.Id}, Título: {libro.Titulo}, Autor: {libro.Autor}");
                    return;
                }
            }

            Console.WriteLine("❌ Libro no encontrado.");
        }

        // 3. Actualizar
        static void ActualizarLibro()
        {
            Console.Write("Ingresa el Id del libro a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var libro in inventario)
            {
                if (libro.Id == id)
                {
                    Console.Write("Nuevo título: ");
                    libro.Titulo = Console.ReadLine();

                    Console.Write("Nuevo autor: ");
                    libro.Autor = Console.ReadLine();

                    Console.WriteLine("✅ Libro actualizado.");
                    return;
                }
            }

            Console.WriteLine("❌ Libro no encontrado.");
        }

        // 4. Eliminar
        static void EliminarLibro()
        {
            Console.Write("Ingresa el Id del libro a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < inventario.Count; i++)
            {
                if (inventario[i].Id == id)
                {
                    inventario.RemoveAt(i);
                    Console.WriteLine("✅ Libro eliminado.");
                    return;
                }
            }

            Console.WriteLine("❌ Libro no encontrado.");
        }

        // Extra: Mostrar todos
        static void MostrarLibros()
        {
            Console.WriteLine("\n📚 Inventario de libros:");
            foreach (var libro in inventario)
            {
                Console.WriteLine($"Id: {libro.Id}, Título: {libro.Titulo}, Autor: {libro.Autor}");
            }
        }
    }

}