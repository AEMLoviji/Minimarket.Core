using Minimarket.API.Domain.Models;


namespace Minimarket.API.Domain.Services.Response
{
    public class CategoryOperationResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private CategoryOperationResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CategoryOperationResponse(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryOperationResponse(string message) : this(false, message, null)
        { }
    }
}