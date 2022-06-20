using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQl.Common.Database;
using GraphQl.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl.Common.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Movie>> GetAllMoviesAsync()
        {
            return _dbContext.Movies.ToListAsync<Movie>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Review>> GetAllReviewsAsync()
        {
            return _dbContext.Reviews.ToListAsync<Review>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return _dbContext.Movies.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="review"></param>
        /// <returns></returns>
        public async Task<Movie> AddReviewToMovieAsync(Guid id, Review review)
        {
            Movie movie = await _dbContext.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
            movie.AddReview(review);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async void AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="review"></param>
        public async void AddReview(Review review)
        {
            await AddReviewToMovieAsync(review.MovieId, review);
            await _dbContext.SaveChangesAsync();
        }
    }
}
