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
    public class QueryReviewResolvers
    {

        private IMovieRepository MovieRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieRepository"></param>
        public QueryReviewResolvers(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [GraphQLName("reviews")]
        public async Task<IQueryable<Review>> GetReviews()
        {
            List<Review> movieList = await MovieRepository.GetAllReviewsAsync();
            return movieList.AsQueryable();
        }
    }
}
