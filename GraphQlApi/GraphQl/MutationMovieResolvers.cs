using GraphQl.Common.Models;
using GraphQl.Common.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQl.Api.GraphQl
{
    [ExtendObjectType(typeof(Mutation))]
    public class MutationMovieResolvers
    {
        private IMovieRepository MovieRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieRepository"></param>
        public MutationMovieResolvers(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [GraphQLName("addMovie")]
        public Movie AddMovie(Movie movie)
        {
            MovieRepository.AddMovie(movie);
            return movie;
        }
    }
}
