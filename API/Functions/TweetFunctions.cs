using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Functions
{
    public class TweetFunctions
    {
        private UserTweetContext db = new UserTweetContext();

        public IQueryable<UserTweet> GetAllTweets()
        {
            //We customize it so we can retrive data from both tables i.e. all tweets + user name .

            var data = from t in db.Tweets join 
                       u in db.Users on t.UserId equals u.Id
                       where t.ParentId == null
                       select new UserTweet
                       {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            UserName = u.UserName,
                            Content = u.Content,
                            Type = u.Type,
                            CreateDate = u.CreateDate


                       }
        }

    }
}