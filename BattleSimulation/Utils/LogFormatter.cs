namespace BattleSimulation.Utils;

public class LogFormatter
{
    public static void MostrarLog(List<string> log)
        {
            Console.WriteLine("=== ⚔️ BATALLA POKÉMON INICIADA ===\n");

            foreach (var linea in log)
            {
                var eventos = linea.Split('|', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < eventos.Length; i++)
                {
                    var comando = eventos[i];

                    switch (comando)
                    {
                        case "t:":
                            // Timestamp ignorado
                            i += 1;
                            break;

                        case "gametype":
                            if (i + 1 < eventos.Length)
                            {
                                Console.WriteLine($"🔧 Tipo de juego: {eventos[i + 1]}");
                                i += 1;
                            }
                            break;

                        case "player":
                            if (i + 2 < eventos.Length)
                            {
                                Console.WriteLine($"🎮 {eventos[i + 1]} → {eventos[i + 2]}");
                                i += 2;
                            }
                            break;

                        case "teamsize":
                            if (i + 2 < eventos.Length)
                            {
                                Console.WriteLine($"👥 Tamaño del equipo {eventos[i + 1]}: {eventos[i + 2]} Pokémon");
                                i += 2;
                            }
                            break;

                        case "gen":
                            if (i + 1 < eventos.Length)
                            {
                                Console.WriteLine($"🧬 Generación: {eventos[i + 1]}");
                                i += 1;
                            }
                            break;

                        case "tier":
                            if (i + 1 < eventos.Length)
                            {
                                Console.WriteLine($"🏷️ Formato: {eventos[i + 1]}");
                                i += 1;
                            }
                            break;

                        case "poke":
                            if (i + 2 < eventos.Length)
                            {
                                Console.WriteLine($"🔸 {eventos[i + 1]} tiene a {eventos[i + 2]}");
                                i += 2;
                            }
                            break;

                        case "teampreview":
                            Console.WriteLine("\n✅ Equipos listos. ¡La batalla va a comenzar!\n");
                            break;

                        // Turnos y eventos ya estaban antes:
                        case "turn":
                            if (i + 1 < eventos.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n🔄 Turno {eventos[i + 1]}");
                                Console.ResetColor();
                                i += 1;
                            }
                            break;

                        case "move":
                            if (i + 3 < eventos.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"➡ {eventos[i + 1]} usó {eventos[i + 2]} sobre {eventos[i + 3]}");
                                Console.ResetColor();
                                i += 3;
                            }
                            break;

                        case "switch":
                            if (i + 2 < eventos.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"🔁 Cambio: {eventos[i + 1]} entra {eventos[i + 2]}");
                                Console.ResetColor();
                                i += 2;
                            }
                            break;

                        case "faint":
                            if (i + 1 < eventos.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"💀 {eventos[i + 1]} ha sido debilitado.");
                                Console.ResetColor();
                                i += 1;
                            }
                            break;

                        case "win":
                            if (i + 1 < eventos.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"\n🏆 Ganador: {eventos[i + 1]}");
                                Console.ResetColor();
                                i += 1;
                            }
                            break;

                        case "-damage":
                            if (i + 2 < eventos.Length)
                            {
                                Console.WriteLine($"💢 Daño: {eventos[i + 1]} → {eventos[i + 2]}");
                                i += 2;
                            }
                            break;

                        case "-heal":
                            if (i + 2 < eventos.Length)
                            {
                                Console.WriteLine($"💚 Cura: {eventos[i + 1]} → {eventos[i + 2]}");
                                i += 2;
                            }
                            break;

                        case "-status":
                            if (i + 2 < eventos.Length)
                            {
                                Console.WriteLine($"⚠️ Estado alterado: {eventos[i + 1]} → {eventos[i + 2]}");
                                i += 2;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("\n=== 🔚 Fin de la simulación ===");
        }
}