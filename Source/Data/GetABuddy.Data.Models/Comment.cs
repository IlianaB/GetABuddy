namespace GetABuddy.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Comment : BaseModel<int>, ITKeyEntity<int>
    {
        [MinLength(20, ErrorMessage = "Content cannot be  shorter than 20 characters.")]
        [MaxLength(200, ErrorMessage = "Content cannot be longer than 200 characters.")]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}
