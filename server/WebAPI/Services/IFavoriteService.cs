using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IFavoriteService
    {
        IPagedResponse<FavoriteDTO> GetFavorites(int userId, int page, SortState sortOrder, bool isPagedRequestNeeded);
        void AddFavourite(AddFavouriteDTO favoriteDTO);
        void DeleteFavouriteMovie(int movieId);
        void DeleteFavouriteSerial(int serialId);
    }
}
