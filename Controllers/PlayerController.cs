using LatelierWebApi.Models;
using LatelierWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LatelierWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerRepository _playersRepo;
        public PlayerController(IPlayerRepository playersRepo)
        {
            _playersRepo=playersRepo;
        }
        /// <summary>
        /// Tache n°1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var res = (await this._playersRepo.GetPlayers())
                .OrderBy(x => x.Firstname);
            return Ok(res.AsEnumerable());
        }

        /// <summary>
        /// Tache n°2
        /// </summary>
        /// <param name="Id">Player's Id</param>
        /// <returns>The Player object or null</returns>
        [HttpGet("FindById/{Id}")]
        public async Task<ActionResult> FindById(int Id)
        {
            var res =( await this._playersRepo.GetPlayers())
            .Where(x => x.Id==Id).FirstOrDefault();
            return Ok(res);
        }

        /// <summary>
        /// Tache n°2
        /// </summary>
        /// <param name="Id">Player's Id</param>
        /// <returns>The Player object or null</returns>
        [HttpGet("Stat")]
        public async Task<ActionResult> Stat()
        {
            var list = await this._playersRepo.GetPlayers();
            var avgImc = 
            (from player in list select new
                {
                    IMC = player.Data.Weight / player.Data.Height
                }
            ).Average(x=>x.IMC);

            return Ok(new
            {
                RatioByCountry=10,
                IMC= avgImc
            });
        }
    }
}
