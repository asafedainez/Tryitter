using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            Posts = new Collection<Post>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        [StringLength(90)]
        public string? Name { get; set; }

        [Required]
        [StringLength(15)]
        public string? Password { get; set; }

        [Required]
        [StringLength(20)]
        public string? Email { get; set; }

        [Required]
        [StringLength(300)]
        public ModulesTypes Module { get; set; }

        [StringLength(100)]
        public string? Status { get; set; }

        [Required]
        public bool? IsDeleted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; init; }

        public ICollection<Post> Posts { get; set; }
    }
}
