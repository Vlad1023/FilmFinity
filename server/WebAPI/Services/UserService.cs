using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using WebAPI.Repositories;
using AutoMapper;
using WebAPI.DTO;
using System.Linq;
using WebAPI.Helpers;
using Microsoft.Extensions.Options;
using WebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewsRepository _reviewRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IReviewsRepository _reviewRepository, IFavoriteRepository _favouriteRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this._favoriteRepository = _favouriteRepository;
            this._reviewRepository = _reviewRepository;
            this.mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = GetUsers().SingleOrDefault(x => x.UserName == model.Username && x.UserPassword == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        private string generateJwtToken(UserDTO user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = userRepository.GetAllUsers();
            return mapper.Map<IEnumerable<UserDTO>>(users.ToList());
        }
        public bool isEmailInUse(string email)
        {
            return userRepository.isEmailInUse(email);
        }
        public void CreateUser(UserDTO userDTO)
        {
            User user = mapper.Map<UserDTO, User>(userDTO);
            userRepository.Create(user);
        }


        public UserInfoDTO GetUserInfo(int userId)
        {
            var userFavourites = _favoriteRepository.GetAllFavouritesOfByUserId(userId);
            var userReviews = _reviewRepository.GetAllReviewsByUserId(userId);
            var userReviewsCount = userReviews.Count();
            double meanValue = 0;
            foreach (var item in userReviews)
            {
                meanValue += (item.ActorsRating + item.DirectingRating + item.PlotRating + item.SpectacleRating) / 4 ;
            }
            var meanValueInt = (int)meanValue / userReviewsCount;
            return new UserInfoDTO { countOfFavourites = userFavourites.Count, meanMark = meanValueInt };
        }
    }
}
