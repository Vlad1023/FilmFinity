using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService favoriteService;
        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [HttpGet("{userId}/{page}/{sortOrder}")]
        public ActionResult<IPagedResponse<FavoriteDTO>> GetListFavorites(int userId, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IPagedResponse<FavoriteDTO> objectList = favoriteService.GetFavorites(userId, page, sortOrder);
            return Ok(objectList);
        }

        [HttpPost]
        [Route("AddFavourite")]
        public IActionResult AddFavourite(AddFavouriteDTO addFavouriteObj)
        {
            favoriteService.AddFavourite(addFavouriteObj);
            return Ok();
        }
    }
}