using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQl.Common.Models;

namespace GraphQl.Common.Repositories
{
    public interface IMovieRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        void AddMovie(Movie movie);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="review"></param>
        void AddReview(Review review);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Movie>> GetAllMoviesAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Review>> GetAllReviewsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Movie> GetMovieByIdAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<Movie> AddReviewToMovieAsync(Guid id, Review review);
    }
}
