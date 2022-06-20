using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl.Common.Models;
using GraphQl.Common.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQl.Api.GraphQl
{
    [ExtendObjectType(typeof(Query))]
    public class QueryMovieResolvers
    {
        private IMovieRepository MovieRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieRepository"></param>
        public QueryMovieResolvers(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [GraphQLName("movie-test")]
        public Movie GetMovie()
        {
            return new Movie()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Reviews = new List<Review>()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        [GraphQLName("movies")]
        public async Task<IQueryable<Movie>> GetMovies()
        {
            List<Movie> movieList = await MovieRepository.GetAllMoviesAsync();
            return movieList.AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        [GraphQLName("getMovieById")]
        public async Task<Movie> GetMovies(Guid id)
        {
            return await MovieRepository.GetMovieByIdAsync(id);
        }
    }
}
