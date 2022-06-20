using System;
using HotChocolate;

namespace GraphQl.Common.Models
{
    public class Review
    {
        [GraphQLDescription("The id of the review.")]
        public int Id { get; set; }
        [GraphQLDescription("The movie id where the review belongs to.")]
        public Guid MovieId { get; set; }
        [GraphQLDescription("The reviewers name.")]
        public string Reviewer { get; set; }
        [GraphQLDescription("The rating in starts of the belonging movie.")]
        public int Stars { get; set; }
    }
}
