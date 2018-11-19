using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }

        //Navigation Property and Icollection so one user can have many tweets.
        public ICollection<Tweet> Tweets { get; set; }
   
    }
}
