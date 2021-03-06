﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Model.Models;

namespace API.Controllers
{
    public class TweetsController : ApiController
    {
        private UserTweetContext db = new UserTweetContext();

        // GET: api/Tweets
        public IQueryable<Tweet> GetTweets()
        {
            //We customize it so we can retrive data from both tables i.e. all tweets + user name .

            //###Previous commands 
            return db.Tweets;
        }

        // GET: api/Tweets/5
        [ResponseType(typeof(Tweet))]
        public IHttpActionResult GetTweet(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // PUT: api/Tweets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTweet(int id, Tweet tweet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tweet.Id)
            {
                return BadRequest();
            }

            db.Entry(tweet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tweets
        [ResponseType(typeof(Tweet))]
        public IHttpActionResult PostTweet(Tweet tweet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tweets.Add(tweet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tweet.Id }, tweet);
        }

        // DELETE: api/Tweets/5
        [ResponseType(typeof(Tweet))]
        public IHttpActionResult DeleteTweet(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return NotFound();
            }

            db.Tweets.Remove(tweet);
            db.SaveChanges();

            return Ok(tweet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TweetExists(int id)
        {
            return db.Tweets.Count(e => e.Id == id) > 0;
        }
    }
}