using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IFavoriteRepository : IRepository<FavoriteDTO>
    {
        List<Favorite> GetAllFavorites();
        List<Favorite> GetAllFavouritesOfByUserId(int userId);
        void AddFavourite(Favorite favouriteObj);
        void DeleteFavouriteMovie(int movieId);
        void DeleteFavouriteSerial(int serialId);
    }
}
