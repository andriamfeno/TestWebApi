using LatelierWebApi.Models;

namespace LatelierWebApi.Repository
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
    }
}
