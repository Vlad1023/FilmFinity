using Entities.DataAccess;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class FavoriteRepository : Repository<FavoriteDTO>, IFavoriteRepository
    {
        public FavoriteRepository(FilmFinityDbContext context)
            : base(context)
        { }

        public void AddFavourite(Favorite favouriteObj)
        {
            _dbContext.Favorites.Add(favouriteObj);
            _dbContext.SaveChanges();
        }

        public void DeleteFavouriteMovie(int movieId)
        {
            var toRemove = _dbContext.Favorites.Where(x => x.ContentType == ContentType.Movie && x.ContentId == movieId).First();
            _dbContext.Favorites
                .Remove(toRemove);
            _dbContext.SaveChanges();
        }

        public void DeleteFavouriteSerial(int serialId)
        {
            var toRemove = _dbContext.Favorites.Where(x => x.ContentType == ContentType.Serial && x.ContentId == serialId).First();
            _dbContext.Favorites
                .Remove(toRemove);
            _dbContext.SaveChanges();
        }

        public List<Favorite> GetAllFavorites()
        {
            return _dbContext.Favorites.ToList();
        }

        public List<Favorite> GetAllFavouritesOfByUserId(int userId)
        {
            return _dbContext.Favorites.Where(x => x.UserId == userId).ToList();
        }
    }
}
