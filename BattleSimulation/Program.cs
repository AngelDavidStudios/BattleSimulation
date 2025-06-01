using BattleSimulation.Services;
using BattleSimulation.Utils;

class Program
{
    static async Task Main(string[] args)
    {
        var battleService = new BattleService("http://pokecore-backend-alb-930486308.us-east-1.elb.amazonaws.com/");

        while (true)
        {
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Simular Batalla Pokémon");
            Console.WriteLine("2. Salir");
            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("⚔️ Simulando batalla...\n");
                    var resultado = await battleService.SimularBatallaAsync();
                    if (resultado?.Log != null)
                    { 
                        LogFormatter.MostrarLog(resultado.Log);
                    }
                    else
                    {
                        Console.WriteLine("❌ Error al obtener el log.");
                    }
                    Console.WriteLine("\nPresiona una tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "2":
                    Console.WriteLine("👋 ¡Hasta pronto!");
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida.\n");
                    break;
            }
        }
    }
}