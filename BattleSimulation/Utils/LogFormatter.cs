namespace BattleSimulation.Utils;

public class LogFormatter
{
    public static void MostrarLog(List<string> log)
        {
            foreach (var linea in log)
            {
                var eventos = linea.Split('|', StringSplitOptions.RemoveEmptyEntries);

                // Como ya dividiste por '|', cada evento es una palabra suelta
                // Por eso debes usar un bucle con índice
                for (int i = 0; i < eventos.Length; i++)
                {
                    var comando = eventos[i];

                    switch (comando)
                    {
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

                        case "turn":
                            if (i + 1 < eventos.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n🔄 Turno {eventos[i + 1]}");
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
        }
}