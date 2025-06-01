using BattleSimulation.Models;
using RestSharp;

namespace BattleSimulation.Services;

public class BattleService
{
    private readonly RestClient _client;

    public BattleService(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<BattleLogResponse?> SimularBatallaAsync()
    {
        var request = new RestRequest("poke-api/simulate", Method.Get);

        var response = await _client.ExecuteAsync<BattleLogResponse>(request);

        if (response.IsSuccessful && response.Data != null)
            return response.Data;

        return null;
    }
}