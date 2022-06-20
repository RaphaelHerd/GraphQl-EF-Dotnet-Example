using System;
using System.Collections.Generic;
using HotChocolate;

namespace GraphQl.Common.Models
{
    public class Movie
    {
        [GraphQLDescription("The reviews of the movie.")]
        public IList<Review> Reviews { get; set; }

        [GraphQLName("ImdbNumber")]
        [GraphQLDescription("The Id of the movie.")]
        public Guid Id { get; set; }

        [GraphQLDescription("The name of the movie.")] 
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="review"></param>
        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }
    }
}
