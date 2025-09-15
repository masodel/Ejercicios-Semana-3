namespace GestionCalificaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subproblema 1: Ingreso de datos
            double[] calificaciones = IngresoCalificaciones();

            // Subproblema 2: Cálculo de promedio
            double promedio = CalcularPromedio(calificaciones);

            // Subproblema 3: Detección de aprobados/reprobados
            string estado = DetectarEstado(promedio);

            // Subproblema 4: Salida de resultados
            MostrarResultados(calificaciones, promedio, estado);
        }

        // Subproblema 1: Ingreso de datos
        static double[] IngresoCalificaciones()
        {
            Console.WriteLine("=== GESTIÓN DE CALIFICACIONES ===");
            Console.Write("Ingrese el número de calificaciones: ");
            int cantidad = int.Parse(Console.ReadLine());

            double[] calificaciones = new double[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese la calificación {i + 1}: ");
                calificaciones[i] = double.Parse(Console.ReadLine());
            }

            return calificaciones;
        }

        // Subproblema 2: Cálculo de promedio
        static double CalcularPromedio(double[] calificaciones)
        {
            double suma = 0;
            foreach (double calificacion in calificaciones)
            {
                suma += calificacion;
            }
            return suma / calificaciones.Length;
        }

        // Subproblema 3: Detección de aprobados/reprobados
        static string DetectarEstado(double promedio)
        {
            return promedio >= 60 ? "APROBADO" : "REPROBADO";
        }

        // Subproblema 4: Salida de resultados
        static void MostrarResultados(double[] calificaciones, double promedio, string estado)
        {
            Console.WriteLine("\n=== RESULTADOS ===");
            Console.WriteLine("Calificaciones ingresadas:");
            for (int i = 0; i < calificaciones.Length; i++)
            {
                Console.WriteLine($"Calificación {i + 1}: {calificaciones[i]}");
            }
            Console.WriteLine($"Promedio: {promedio:F2}");
            Console.WriteLine($"Estado: {estado}");
        }
    }
}
