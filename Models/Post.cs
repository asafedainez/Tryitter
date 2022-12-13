using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{
    [Table("Posts")]

    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; init; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [StringLength(300)]
        public string? Content { get; set; }

        [StringLength(300)]
        public string? ImageUrl { get; set; }

        [Required]
        public bool? IsDeleted { get; set; }
        public int UserId { get; init; }
    }
}
