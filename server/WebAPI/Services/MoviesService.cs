using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repositories;
using WebAPI.DTO;
using AutoMapper;
using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Entities.Models;

namespace WebAPI.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMapper _mapper;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IReviewsRepository _reviewsRepository;

        public MoviesService(IMoviesRepository _moviesRepository, IReviewsRepository _reviewsRepository, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._moviesRepository = _moviesRepository;
            this._reviewsRepository = _reviewsRepository;
        }
        public IEnumerable<MovieDTO> GetAllMovies()
        {
            var movies = _moviesRepository.GetAllMovies().ToList();
            var allReviews = _reviewsRepository.GetAll();
            foreach (var item in movies)
            {
                int rate = 0;
                var currentMovieReviews = allReviews.Where(x => x.ContentType == ReviewContentType.Movie && x.FilmId == item.Id).ToList();
                if(currentMovieReviews.Count() != 0)
                {
                    var currentMovieReviewsCount = currentMovieReviews.Count();
                    foreach (var review in currentMovieReviews)
                    {
                        rate += (int)((review.ActorsRating + review.DirectingRating + review.PlotRating + review.SpectacleRating) / 4);
                    }
                    item.Rate = (int)(rate / currentMovieReviews.Count());
                }
            }
            return _mapper.Map<IEnumerable<Movie>, IEnumerable < MovieDTO >> (movies.ToList());
        }

        public MovieDTO GetMovieById(int id)
        {
            var movie = _moviesRepository.GetMovieById(id);
            return _mapper.Map<MovieDTO>(movie);
        }
    }
}
