namespace API.Migrations
{
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserTweetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserTweetContext context)
        {
            var users = new List<User>
            {
                new User() {UserName="aman",Password="1234",FirstName="aman",LastName="deep"},
                new User() {UserName="amandeep",Password="1234",FirstName="aman",LastName="singh"},
                new User() {UserName="predit",Password="1234",FirstName="predit",LastName="khanna"},
                new User() {UserName="sara",Password="1234",FirstName="sara",LastName="dodd"},

            };
            //Lambda expression to add users in db
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            //Region for post data
            var posts = new List<Tweet>
            {
                new Tweet {Content="nice day",Type="Social", ParentId=null,
                CreateDate= new DateTime(2016,2,1), UpdateDate= new DateTime(2016,2,1),UserId=1 },
                 new Tweet {Content="first day ay work",Type="Science", ParentId=null,
                CreateDate= new DateTime(2016,2,1), UpdateDate= new DateTime(2016,2,1),UserId=2 },
                  new Tweet {Content="nice day in Australia",Type="Social", ParentId=null,
                CreateDate= new DateTime(2016,2,1), UpdateDate= new DateTime(2016,2,1),UserId=3 },
                   new Tweet {Content="nice day in India",Type="Social", ParentId=null,
                CreateDate= new DateTime(2016,2,1), UpdateDate= new DateTime(2016,2,1),UserId=4 },
            };
            posts.ForEach(u => context.Tweets.Add(u));
            context.SaveChanges();

        }
    }
}
