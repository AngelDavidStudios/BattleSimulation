using System.Text.Json.Serialization;

namespace BattleSimulation.Models;

public class BattleLogResponse
{
    [JsonPropertyName("log")]
    public List<string> Log { get; set; }
}