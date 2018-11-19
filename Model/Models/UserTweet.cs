using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class UserTweet
    {
        //This model is for our Function folder in API where we combine results from both models i.e users and tweets.
     
        public int TweetId { get; set; }
        public String Content { get; set; }
        public int UserId { get; set; }
        public String Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        //For recursive relationship will used in to add comments.
        public int? ParentId { get; set; }

        public String UserName { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
