using AutoMapper;
using Entities.DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class SerialsService : ISerialsService
    {
        private readonly ISerialRepository _serialRepository;
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IMapper _mapper;

        public SerialsService(ISerialRepository _serialRepository, IReviewsRepository _reviewsRepository, IMapper _mapper)
        {
            this._serialRepository = _serialRepository;
            this._mapper = _mapper;
            this._reviewsRepository = _reviewsRepository;
        }
        public List<SerialDTO> GetSerials()
        {
            var serials = _serialRepository.GetAllSerials();
            var allReviews = _reviewsRepository.GetAll();
            foreach (var item in serials)
            {
                int rate = 0;
                var currentSerialReviews = allReviews.Where(x => x.ContentType == ReviewContentType.Serial && x.FilmId == item.Id).ToList();
                if (currentSerialReviews.Count() != 0)
                {
                    var currentMovieReviewsCount = currentSerialReviews.Count();
                    foreach (var review in currentSerialReviews)
                    {
                        rate += (int)((review.ActorsRating + review.DirectingRating + review.PlotRating + review.SpectacleRating) / 4);
                    }
                    item.Rating = rate / currentMovieReviewsCount;
                }
            }
            return _mapper.Map<List<SerialDTO>>(serials.ToList());
        }

        public SerialDTO GetSerialById(int id)
        {
            var serial = _serialRepository.GetSerialById(id);
            return _mapper.Map<SerialDTO>(serial);
        }
    }
}
