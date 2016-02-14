namespace GetABuddy.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Event : BaseModel<int>
    {
        private ICollection<Comment> comments;

        private ICollection<ApplicationUser> participants;

        public Event()
        {
            this.comments = new HashSet<Comment>();
            this.participants = new HashSet<ApplicationUser>();
        }

        [Required]
        [MinLength(5, ErrorMessage = "Name cannot be  shorter than 5 characters.")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Description cannot be  shorter than 20 characters.")]
        [MaxLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int NumberOfParticipants { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<ApplicationUser> Participants
        {
            get
            {
                return this.participants;
            }

            set
            {
                this.participants = value;
            }
        }
    }
}
