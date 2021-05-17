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
