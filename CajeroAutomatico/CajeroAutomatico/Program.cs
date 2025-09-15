namespace CajeroAutomatico
{
    class Program
    {
        static double saldo = 1000.00; // Saldo inicial
        static string pin = "1234"; // PIN de ejemplo

        static void Main(string[] args)
        {
            // Subproblema 1: Inicio de sesión
            if (InicioSesion())
            {
                bool continuar = true;
                while (continuar)
                {
                    int opcion = MostrarMenu();

                    switch (opcion)
                    {
                        case 1:
                            // Subproblema 2: Consulta de saldo
                            ConsultarSaldo();
                            break;
                        case 2:
                            // Subproblema 3: Retiro
                            RealizarRetiro();
                            break;
                        case 3:
                            // Subproblema 4: Depósito
                            RealizarDeposito();
                            break;
                        case 4:
                            // Subproblema 5: Cierre de sesión
                            continuar = CerrarSesion();
                            break;
                    }
                }
            }
        }

        // Subproblema 1: Inicio de sesión
        static bool InicioSesion()
        {
            Console.WriteLine("=== CAJERO AUTOMÁTICO ===");
            Console.Write("Ingrese su PIN: ");
            string pinIngresado = Console.ReadLine();

            if (pinIngresado == pin)
            {
                Console.WriteLine("Acceso autorizado\n");
                return true;
            }
            else
            {
                Console.WriteLine("PIN incorrecto. Acceso denegado.");
                return false;
            }
        }

        static int MostrarMenu()
        {
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Depositar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            return int.Parse(Console.ReadLine());
        }

        // Subproblema 2: Consulta de saldo
        static void ConsultarSaldo()
        {
            Console.WriteLine($"Su saldo actual es: ${saldo:F2}\n");
        }

        // Subproblema 3: Retiro
        static void RealizarRetiro()
        {
            Console.Write("Ingrese la cantidad a retirar: $");
            double cantidad = double.Parse(Console.ReadLine());

            if (cantidad <= saldo && cantidad > 0)
            {
                saldo -= cantidad;
                Console.WriteLine($"Retiro exitoso. Nuevo saldo: ${saldo:F2}\n");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes o cantidad inválida.\n");
            }
        }

        // Subproblema 4: Depósito
        static void RealizarDeposito()
        {
            Console.Write("Ingrese la cantidad a depositar: $");
            double cantidad = double.Parse(Console.ReadLine());

            if (cantidad > 0)
            {
                saldo += cantidad;
                Console.WriteLine($"Depósito exitoso. Nuevo saldo: ${saldo:F2}\n");
            }
            else
            {
                Console.WriteLine("Cantidad inválida.\n");
            }
        }

        // Subproblema 5: Cierre de sesión
        static bool CerrarSesion()
        {
            Console.WriteLine("Gracias por usar nuestro cajero automático.");
            return false;
        }
    }
}