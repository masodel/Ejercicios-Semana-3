namespace SistemaParqueo
{
    using System;
    class Program
    {
        const double tarifaPorHora = 20.0; // Tarifa fija
        static Random random = new Random(); // Para generar aleatorios

        static void Main()
        {
            Console.WriteLine("=== SISTEMA DE PARQUEO ===");

            string placa = GenerarPlaca();
            int horas = PedirHoras();
            double total = CalcularPago(horas);

            MostrarTicket(placa, horas, total);

            Console.WriteLine("\nGracias por usar el sistema de parqueo.");
        }

        // --- Subproblema 1: generar placa aleatoria ---
        static string GenerarPlaca()
        {
            int numero = random.Next(100000, 999999); // número de 6 dígitos
            return "M" + numero;
        }

        // --- Subproblema 2: pedir horas ---
        static int PedirHoras()
        {
            Console.Write("Ingrese el tiempo de parqueo (en horas): ");
            return int.Parse(Console.ReadLine());
        }

        // --- Subproblema 3: calcular pago ---
        static double CalcularPago(int horas)
        {
            return horas * tarifaPorHora;
        }

        // --- Subproblema 4: mostrar información ---
        static void MostrarTicket(string placa, int horas, double total)
        {
            Console.WriteLine($"\nVehículo con placa: {placa}");
            Console.WriteLine($"Tiempo: {horas} horas");
            Console.WriteLine($"Total a pagar: {total} C$");
        }
    }
}
