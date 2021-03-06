using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Serial, SerialDTO>()
                .ForMember(dto => dto.Celebrities, opt => opt.MapFrom(
                    route => route.SerialCelebrity.ToList().Select(
                        el => new CelebrityDTO {
                            CelebrityId = el.Celebrity.CelebrityId,
                            FirstName = el.Celebrity.FirstName,
                            LastName = el.Celebrity.LastName,
                            CountViews = el.Celebrity.CountViews,
                            ImageSource = el.Celebrity.ImageSource,
                            JobTitles = el.Celebrity.CelebrityJobTitles.Select(g => g.JobTitle).Select(g => new JobTitleDTO
                            { JobTitleId = g.JobTitleId, JobName = g.JobName }).ToList()
                        })
                    )
                )
                .ForMember(dto => dto.GenreTitles, opt => opt.MapFrom(
                    route => route.SerialGenreTitles.ToList().Select(
                        el => new GenreDTO { Id = el.GenreTitle.Id, Name = el.GenreTitle.Name })
                    )
                );
            CreateMap<Serial, FavoriteDTO>()
                .ForMember(x => x.Celebrities,
                     x => x.MapFrom(list => list.SerialCelebrity.ToList()
                     .Select(item => new MovieActorDTO
                     {
                         Id = item.Celebrity.CelebrityId,
                         FullName = item.Celebrity.FirstName + " " + item.Celebrity.LastName
                     })
                    )
                );
            CreateMap<Movie, FavoriteDTO>()
                 .ForMember(x => x.Name,
                      x => x.MapFrom(m => m.Title))
                 .ForMember(x => x.Rating,
                      x => x.MapFrom(m => m.Rate))
                 .ForMember(x => x.Year,
                      x => x.MapFrom(m => m.ReleaseYear))
                 .ForMember(x => x.PosterImageSource,
                      x => x.MapFrom(m => m.ImageSource))
                 .ForMember(x => x.Celebrities,
                      x => x.MapFrom(list => list.ActorsList.ToList()
                      .Select(item => new MovieActorDTO { FullName = item.Actor.FullName, Id = item.ActorId }))
                );

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<News, NewsDTO>()
              .ForMember(dto => dto.Author, opt => opt.MapFrom(
                  route => new NewsAuthorDTO { Id = route.Author.Id, FirstName = route.Author.FirstName, LastName = route.Author.LastName })
              )
              .ForMember(dto => dto.Categories, opt => opt.MapFrom(
                  route => route.NewsCategories.ToList().Select
                  (el => new NewsCategoryDTO { Id = el.Category.Id, Name = el.Category.Name }))
              );
            CreateMap<Movie, MovieDTO>()
                .ForMember(dto => dto.ActorsList, opt => opt.MapFrom(
                        list => list.ActorsList.ToList().Select
                        (item => new MovieActorDTO { FullName = item.Actor.FullName, Id = item.ActorId }))
                );

            CreateMap<Movie, FavoriteDTO>()
                 .ForMember(x => x.Name,
                      x => x.MapFrom(m => m.Title))
                 .ForMember(x => x.Rating,
                      x => x.MapFrom(m => m.Rate))
                 .ForMember(x => x.Year,
                      x => x.MapFrom(m => m.ReleaseYear))
                 .ForMember(x => x.PosterImageSource,
                      x => x.MapFrom(m => m.ImageSource))
                 .ForMember(x => x.Celebrities,
                      x => x.MapFrom(list => list.ActorsList.ToList()
                      .Select(item => new MovieActorDTO { FullName = item.Actor.FullName, Id = item.ActorId }))
                );

            CreateMap<AddReviewDTO, Review>()
                 .ForMember(x => x.UserId,
                      x => x.MapFrom(m => m.UserId))
                 .ForMember(x => x.FilmId,
                      x => x.MapFrom(m => m.FilmId))
                 .ForMember(x => x.ContentType,
                      x => x.MapFrom(m => m.ContentType))
                 .ForMember(x => x.ReviewTitle,
                      x => x.MapFrom(m => m.ReviewTitle))
                 .ForMember(x => x.ReviewContent,
                      x => x.MapFrom(m => m.ReviewContent))
                  .ForMember(x => x.PublishTime,
                      x => x.MapFrom(m => DateTime.Now))
                  .ForMember(x => x.DirectingRating,
                      x => x.MapFrom(m => m.DirectingRating))
                  .ForMember(x => x.PlotRating,
                      x => x.MapFrom(m => m.PlotRating))
                  .ForMember(x => x.SpectacleRating,
                      x => x.MapFrom(m => m.EntertainmentRating))
                  .ForMember(x => x.ActorsRating,
                      x => x.MapFrom(m => m.ActorsRating))
                  .ForMember(x => x.User,
                      x => x.Ignore());

            CreateMap<AddFavouriteDTO, Favorite>()
               .ForMember(x => x.UserId,
                    x => x.MapFrom(m => m.UserId))
               .ForMember(x => x.ContentId,
                    x => x.MapFrom(m => m.ContentId))
               .ForMember(x => x.ContentType,
                    x => x.MapFrom(m => m.ContentType))
                .ForMember(x => x.AddedTime,
                    x => x.MapFrom(m => DateTime.Now));
        }
    }
}
