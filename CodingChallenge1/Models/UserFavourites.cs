using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingChallenge1.Models
{
    public class UserFavourites
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public String UserId { get; set; }
        [ForeignKey("Property")]
        public Guid PropertyId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Property Property { get; set; }

    }
}