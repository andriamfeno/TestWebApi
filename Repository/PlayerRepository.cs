using LatelierWebApi.Models;
using System.Text.Json;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace LatelierWebApi.Repository
{
    public class PlayerRepository: IPlayerRepository
    {
        private IHostingEnvironment _environment;
        public PlayerRepository(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<List<Player>> GetPlayers()
        {
            string path = Path.Combine(this._environment.WebRootPath, "Data/") + "headtohead.json";
            var data =await  System.IO.File.ReadAllTextAsync(path);
            List<Player> list =JsonSerializer.Deserialize<List<Player>>(data);
            return list;
        }
    }
}
