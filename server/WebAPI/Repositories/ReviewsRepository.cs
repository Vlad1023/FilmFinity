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
    public class ReviewsRepository : Repository<ReviewDTO>, IReviewsRepository
    {
        public ReviewsRepository(FilmFinityDbContext context)
         : base(context)
        { }

        public void AddReview(Review review)
        {
            _dbContext.Reviews
                    .Add(review);
            _dbContext.SaveChanges();
        }

        public void DeleteReview(int reviewId)
        {
           var toRemove = _dbContext.Reviews.Where(x => x.Id == reviewId).First();
            _dbContext.Reviews
                .Remove(toRemove);
            _dbContext.SaveChanges();
        }

        public IQueryable<Review> GetAllReviewsByUserId(int UserId)
        {
            return _dbContext.Reviews
                .Where(r => r.UserId == UserId);
        }
        List<Review> IRepository<Review>.GetAll()
        {
            return _dbContext.Reviews.ToList();
        }
    }
}
