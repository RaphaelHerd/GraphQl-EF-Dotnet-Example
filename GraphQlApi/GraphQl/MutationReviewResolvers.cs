using GraphQl.Common.Models;
using GraphQl.Common.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQl.Api.GraphQl
{
    [ExtendObjectType(typeof(Mutation))]
    public class MutationReviewResolvers
    {
        private IMovieRepository MovieRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieRepository"></param>
        public MutationReviewResolvers(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [GraphQLName("addReview")]
        public Review AddReview(Review review)
        {
            MovieRepository.AddReview(review);
            return review;
        }
    }
}
