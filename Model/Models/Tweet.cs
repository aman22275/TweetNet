using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Content { get; set; }
        public int UserId { get; set; }
  
        [Required]
        public String Type { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        //For recursive relationship will used in to add comments.
        public int? ParentId { get; set; }

        //User type because user is identical
        public User User { get; set; }

    }
}
