namespace Tryitter.Models
{
    public class PostInput
    {
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int UserId { get; init; }

        public Post ToInput()
        {
            return new Post()
            {
                Content = Content,
                ImageUrl = ImageUrl,
                UserId = UserId,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
        }
    }
}
