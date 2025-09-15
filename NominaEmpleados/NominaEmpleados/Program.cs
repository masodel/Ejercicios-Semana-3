namespace NominaEmpleados
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== CÁLCULO DE NÓMINA ===");

            string nombre = PedirNombre();
            double pagoHora = PedirPagoHora();
            int horas = PedirHoras();

            double salarioBruto = CalcularBruto(pagoHora, horas);
            double deducciones = CalcularDeducciones(salarioBruto);
            double salarioNeto = CalcularNeto(salarioBruto, deducciones);

            MostrarNomina(nombre, horas, pagoHora, salarioBruto, deducciones, salarioNeto);
        }

        // Subproblema 1: Entrada de datos
        static string PedirNombre()
        {
            Console.Write("Ingrese el nombre del empleado: ");
            return Console.ReadLine();
        }

        static double PedirPagoHora()
        {
            Console.Write("Ingrese el pago por hora: ");
            return double.Parse(Console.ReadLine());
        }

        // Subproblema 2: Horas trabajadas
        static int PedirHoras()
        {
            Console.Write("Ingrese las horas trabajadas: ");
            return int.Parse(Console.ReadLine());
        }

        // Subproblema 3: Salario bruto
        static double CalcularBruto(double pagoHora, int horas)
        {
            return pagoHora * horas;
        }

        // Subproblema 4: Deducciones (ejemplo: 7% INSS)
        static double CalcularDeducciones(double salarioBruto)
        {
            return salarioBruto * 0.07;
        }

        // Subproblema 5: Salario neto
        static double CalcularNeto(double salarioBruto, double deducciones)
        {
            return salarioBruto - deducciones;
        }

        // Mostrar resultados
        static void MostrarNomina(string nombre, int horas, double pagoHora, double bruto, double deducciones, double neto)
        {
            Console.WriteLine("\n=== RESUMEN DE NÓMINA ===");
            Console.WriteLine($"Empleado: {nombre}");
            Console.WriteLine($"Horas trabajadas: {horas}");
            Console.WriteLine($"Pago por hora: {pagoHora} C$");
            Console.WriteLine($"Salario bruto: {bruto} C$");
            Console.WriteLine($"Deducciones: {deducciones} C$");
            Console.WriteLine($"Salario neto: {neto} C$");
        }
    }
}
